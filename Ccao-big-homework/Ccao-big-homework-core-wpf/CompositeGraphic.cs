//Du 2015.9
//All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Ccao_big_homework_core_wpf.Draw_Mode;

namespace Ccao_big_homework_core_wpf
{
    /// <summary>
    /// 可以包含其他graphic的graphic的基本实现。
    /// </summary>
    public class CompositeGraphic : MyGraphic
    {

        #region basic properties and methods
        public CompositeGraphic(DrawMode _drawmode)
            : base()
        {
            _list.Clear();
            backgroundmode = _drawmode;
            isCombined = false;
            isTemporary = false;
        }
        public CompositeGraphic()
            : this(new GeometryMode()) { }
        public double Width { get; set; }
        public double Height { get; set; }

        public DrawMode backgroundmode { get; set; }
        /// <summary>
        /// 辅助函数。获得边界
        /// </summary>
        private Geometry getBorder(double left = 0.0f, double top = 0.0f) { return new RectangleGeometry(new Rect(left, top, Width, Height)); }
        public override Drawing Draw(double left = 0.0f, double top = 0.0f)
        {
            if (isVisible)
            {
                DrawingGroup dg = new DrawingGroup();
                if (isCombined)
                {
                    dg.Children.Add(backgroundmode.draw(getBorder(left, top)));
                }
                foreach (_graphicpos gp in _list)
                {
                    Drawing d = gp.g.Draw(left + gp.left, top + gp.top);
                    if (d != null)
                    {
                        dg.Children.Add(d);
                    }
                }
                return dg;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region interactivities
        /// <summary>
        /// 这个选项被置true的时候整个compositegraphic被视为一个整体，
        /// 不然被视为（对用户）透明的存在
        /// </summary>
        public bool isCombined { get; set; }
        /// <summary>
        /// 这个bool成员用来指示这个Composite是不是临时的，对于用户没有什么重要作用。
        /// </summary>
        public bool isTemporary { get; set; }

        public override CompositeGraphic SelectRect(Rect r, double left = 0.0f, double top = 0.0f)
        {
            CompositeGraphic compositegraphic = new CompositeGraphic();
            compositegraphic.isTemporary = true;
            RectangleGeometry rg = new RectangleGeometry(r);
            if (getBorder(left, top).FillContainsWithDetail(rg) != IntersectionDetail.Empty || isTemporary)
            {
                if (!isCombined)
                {
                    List<_graphicpos> lg = new List<_graphicpos>(_list);
                    for (int i = 0; i < lg.Count; i++)
                    {
                        _graphicpos gp = lg[i];
                        CompositeGraphic cg = gp.g.SelectRect(r, gp.left, gp.top);
                        if (cg == null || cg.isEmpty()) continue;
                        cg.isTemporary = true;
                        compositegraphic.MergeComposite(cg, left, top);
                    }
                }
                else
                {
                    return this;
                }
            }
            if (compositegraphic.isEmpty()) return null;
            this.Add(compositegraphic);
            return compositegraphic;
        }
        /// <summary>
        /// 给定两个点，返回其中图形所成的Composite或者null（如果为空）
        /// </summary>
        public CompositeGraphic SelectRect(Point p1, Point p2, double left = 0.0f, double top = 0.0f)
        {
            return DisposeNullComposite(SelectRect(new Rect(p1, p2), left, top));
        }
        /// <summary>
        /// 判定是否为空
        /// </summary>
        public bool isEmpty()
        {
            return (_list.Count == 0) ? true : false;
        }
        /// <summary>
        /// 将一个compositegraphic的内容merge到本对象中
        /// </summary>
        public void MergeComposite(CompositeGraphic cg, double left = 0.0f, double top = 0.0f)
        {
            List<_graphicpos> lgp = cg.getGraphicPosList();
            List<_graphicpos> l = new List<_graphicpos>(lgp);
            for (int i = 0; i < l.Count; i++)
            {
                _graphicpos gp = l[i];
                this.Add(gp.g, left + gp.left, top + gp.top);
            }
            cg.Dispose();
        }

        /// <summary>
        /// 将所有成员都移动一个距离
        /// </summary>
        public void Move(double left = 0.0f, double top = 0.0f)
        {
            foreach (_graphicpos gp in _list)
            {
                gp.left += left;
                gp.top += top;
            }
        }

        public override MyGraphic Clone()
        {
            CompositeGraphic cg = new CompositeGraphic(backgroundmode);
            cg.isVisible = this.isVisible;
            foreach (_graphicpos gp in _list)
            {
                MyGraphic g = gp.g.Clone();
                cg.Add(g, gp.left, gp.top);
            }
            cg.Width = this.Width;
            cg.Height = this.Height;
            cg.isCombined = this.isCombined;
            cg.isTemporary = this.isTemporary;
            return cg;
        }

        /// <summary>
        /// 全选
        /// </summary>
        public CompositeGraphic SelectAll()
        {
            CompositeGraphic cg = new CompositeGraphic();
            cg.Width = this.Width;
            cg.Height = this.Height;
            List<_graphicpos> l = new List<_graphicpos>(_list);
            for (int i = 0; i < l.Count; i++)
            {
                _graphicpos gp = l[i];
                cg.Add(gp.g, gp.left, gp.top);
            }
            this.Add(cg);
            return cg;
        }

        public override int count
        {
            get
            {
                if (isCombined) return 1;
                int num = 0;
                foreach (MyGraphic g in this)
                {
                    num += g.count;
                }
                return num;
            }
        }

        #endregion

        #region 为了实现composite的辅助函数
        /// <summary>
        /// 这个类只是包装一下数据，或者说当结构使了
        /// 三个参数分别是图像，left和top，都是字面意思
        /// </summary>
        public class _graphicpos
        {
            public MyGraphic g { get; set; }
            public double left { get; set; }
            public double top { get; set; }
            public _graphicpos(MyGraphic _g, double _left, double _top) { g = _g; left = _left; top = _top; }
        }
        /// <summary>
        /// 储存child的位置和内容
        /// </summary>
        protected List<_graphicpos> _list = new List<_graphicpos>();
        public List<_graphicpos> getGraphicPosList() { return _list; }
        /// <summary>
        /// 充当iterator
        /// </summary>
        private int _currentindex = 0;
        /// <summary>
        /// 这个辅助函数用来删掉一个子graphic
        /// </summary>
        public void Remove(MyGraphic g)
        {
            _graphicpos mgp = null;
            foreach (_graphicpos gp in _list)
            {
                if (gp.g == g)
                {
                    mgp = gp;
                    break;
                }
            }
            if (mgp != null)
            {
                _list.Remove(mgp);
            }
        }
        #endregion

        #region 以下实现composite功能，函数功能请见Mygraphic介绍
        public override bool isComposite() { return true; }
        public override void Add(MyGraphic g, double left = 0.0f, double top = 0.0f)
        {
            g.Father = this;
            _list.Add(new _graphicpos(g, left, top));
            _currentindex = -1;
        }
        public override void Clear()
        {
            _list.Clear();
        }
        public override bool MoveNext()
        {
            if (++_currentindex >= _list.Count)
            {
                Reset();
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                _curMyGraphic = _list[_currentindex].g;
            }
            return true;
        }
        public override void Reset()
        {
            _currentindex = -1;
        }
        #endregion


    }
}
