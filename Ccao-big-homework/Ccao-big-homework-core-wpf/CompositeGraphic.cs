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
    /// 可以包含其他graphic的graphic的基本实现。实现了IEnumerator，所以可以使用foreach
    /// </summary>
    public class CompositeGraphic : MyGraphic, IEnumerator
    {

        #region basic properties and methods
        public CompositeGraphic(Brush _backcolorbrush, Pen _borderpen)
        {
            _list.Clear();
            BackColorBrush = _backcolorbrush;
            BorderPen = _borderpen;
        }
        public CompositeGraphic()
            : this(defaultConstant.defaultbrush, defaultConstant.defaultpen) { }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// 背景色。
        /// </summary>
        public Brush BackColorBrush { get; set; }
        /// <summary>
        /// 边框。
        /// </summary>
        public Pen BorderPen { get; set; }
        public override Drawing Draw(int left = 0, int top = 0)
        {
            DrawingGroup dg = new DrawingGroup();
            GeometryDrawing drawbackcolor =
                new GeometryDrawing(
                    BackColorBrush,
                    BorderPen,
                    new RectangleGeometry(new Rect(left, top, Width, Height))
                );
            dg.Children.Add(drawbackcolor);
            foreach (_graphicpos gp in _list)
            {
                dg.Children.Add(gp.g.Draw(left + gp.left, top + gp.top));
            }
            return dg;
        }
        #endregion

        #region composite
        /// <summary>
        /// 这个类只是包装一下数据，或者说当结构使了
        /// </summary>
        protected class _graphicpos
        {
            public MyGraphic g { get; set; }
            public int left { get; set; }
            public int top { get; set; }
            public _graphicpos(MyGraphic _g, int _left, int _top) { g = _g; left = _left; top = _top; }
        }
        /// <summary>
        /// 储存child的位置和内容
        /// </summary>
        protected List<_graphicpos> _list = new List<_graphicpos>();
        /// <summary>
        /// 充当iterator
        /// </summary>
        private int _currentindex = 0;

        // 以下实现composite功能，函数功能请见Mygraphic介绍
        public override bool isComposite() { return true; }
        public override void Add(MyGraphic g, int left, int top)
        {
            _list.Add(new _graphicpos(g, left, top));
            _currentindex = 0;
        }
        public override void Clear()
        {
            _list.Clear();
        }
        public override Object Current
        {
            get
            {
                return _list[_currentindex].g;
            }
        }
        public override bool MoveNext()
        {
            _currentindex++;
            return (_currentindex < _list.Count) ? true : false;
        }
        public override void Reset()
        {
            _currentindex = 0;
        }

        #endregion
    }
}
