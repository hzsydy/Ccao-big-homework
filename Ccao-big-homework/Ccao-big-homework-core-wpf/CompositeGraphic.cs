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
        public CompositeGraphic(Brush _backcolorbrush, Pen _borderpen)
            : base()
        {
            _list.Clear();
            backgroundmode = new GeometryMode();
            isCombined = false;
        }
        public CompositeGraphic()
            : this(defaultConstant.defaultbrush, defaultConstant.defaultpen) { }
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

        public override bool isContained(Point p, double left = 0.0f, double top = 0.0f)
        {
            MyGraphic g = SelectPoint(p, left, top);
            if (g != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override MyGraphic SelectPoint(Point p, double left = 0.0f, double top = 0.0f)
        {
            if (!isCombined)
            {
                foreach (_graphicpos gp in _list)
                {
                    MyGraphic g = gp.g.SelectPoint(p, left + gp.left, top + gp.top);
                    if (g != null)
                    {
                        return g;
                    }
                }
                return null;
            }
            else
            {
                if (getBorder(left, top).FillContains(p))
                {
                    return this;
                }
                else
                {
                    return null;
                }
            }
        }
        public override List<MyGraphic> SelectRect(Point p1, Point p2, double left = 0.0f, double top = 0.0f)
        {
            List<MyGraphic> lm = new List<MyGraphic>();
            lm.Clear();
            Point p = new Point(left, top);
            RectangleGeometry rg = new RectangleGeometry(new Rect(_addpoint(p1, p), _addpoint(p2, p)));
            if (getBorder(left, top).FillContainsWithDetail(rg) != IntersectionDetail.Empty)
            {
                if (!isCombined)
                {
                    foreach (_graphicpos gp in _list)
                    {
                        List<MyGraphic> lg = gp.g.SelectRect(p1, p2, left + gp.left, top + gp.top);
                        if (lg != null)
                        {
                            foreach (MyGraphic mg in lg)
                            {
                                lm.Add(mg);
                            }
                        }
                    }
                    return lm;
                }
                else
                {
                    lm.Add(this);
                    return lm;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 为了实现composite的辅助函数
        /// <summary>
        /// 这个类只是包装一下数据，或者说当结构使了
        /// 三个参数分别是图像，left和top，都是字面意思
        /// </summary>
        protected class _graphicpos
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
        /// <summary>
        /// 充当iterator
        /// </summary>
        private int _currentindex = 0;
        /// <summary>
        /// 这个辅助函数用来删掉一个子graphic
        /// </summary>
        public void DeleteChildren(MyGraphic g)
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
            g.FatherDeleteMePlease += new Remove(this.DeleteChildren);
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
