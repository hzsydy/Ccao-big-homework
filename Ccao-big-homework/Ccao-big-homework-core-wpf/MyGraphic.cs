//Du 2015.9
//All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

/* 关于wpf与winform的关系
 *     本来我写了一个core，是基于system.drawing也就是传说中的gdi+的
 * 然而突然被告知说新一代界面WPF不资瓷system.drawing库而改用了
 * system.windows.media库。于是我瞬间爆炸，只好重写了一个。
 *     您现在看到的这个core-wpf与core-winform版如此相像，就是这个原因。
 */
namespace Ccao_big_homework_core_wpf
{
    /// <summary>
    /// 基本的图像类。
    /// </summary>
    public abstract class MyGraphic : 
        IEnumerator<MyGraphic>, IEnumerable<MyGraphic>, ICloneable
    {
        #region basic properties and methods
        /// <summary>
        /// 初始化
        /// </summary>
        public MyGraphic()
        {
            Father = null;
            isVisible = true;
        }
        /// <summary>
        /// 画图
        /// </summary>
        public abstract Drawing Draw(double left = 0.0f, double top = 0.0f);
        /// <summary>
        /// 指示是否绘制这个图形
        /// </summary>
        public bool isVisible { get; set; }
        #endregion

        #region interactivities
        /// <summary>
        /// 感知点p是否在图形内部，如是返回true
        /// left和top是两个修正值，因为如你所见你draw的时候也是要给left和top的，取iscontain的时候当然也要给。
        /// 你draw的时候给的0，0那你iscontained的时候也可以0，0
        /// </summary>
        public abstract bool isContained(Point p, double left = 0.0f, double top = 0.0f);
        /// <summary>
        /// 同上，返回找到的第一个被这个点选中的graphic
        /// </summary>
        public abstract MyGraphic SelectPoint(Point p, double left = 0.0f, double top = 0.0f);
        /// <summary>
        /// 返回这两个点组成矩形内的所有mygraphic的list
        /// </summary>
        public abstract CompositeGraphic SelectRect(Point p1, Point p2, double left = 0.0f, double top = 0.0f);
        /// <summary>
        /// 一个傻逼辅助函数，如字面意思相加两个point
        /// </summary>
        protected Point _addpoint(Point p1, Point p2) { return new Point(p1.X + p2.X, p1.Y + p2.Y); }
        /// <summary>
        /// 复制一份拷贝。
        /// </summary>
        public abstract MyGraphic Clone();
        Object ICloneable.Clone() { return this.Clone(); }
        #endregion

        #region composite
        /// <summary>
        /// add a graphic
        /// </summary>
        public virtual void Add(MyGraphic g, double left = 0.0f, double top = 0.0f) { }
        /// <summary>
        /// Clear all child graphics
        /// </summary>
        public virtual void Clear() { }
        /// <summary>
        /// 确定这是否是一个composite
        /// </summary>
        public virtual bool isComposite() { return false; }
        /// <summary>
        /// 父节点。
        /// </summary>
        private CompositeGraphic _father;
        public CompositeGraphic Father 
        {
            get
            {
                return _father;
            }
            set
            {
                if (_father != null)
                {
                    _father.Remove(this);
                }
                _father = value;
            }
        }
        /// <summary>
        /// 对象删除
        /// </summary>
        public void Dispose() 
        {
<<<<<<< HEAD
            Father = null;
=======
            if (Father != null)
            {
                Father.DeleteChildren(this);
            }
>>>>>>> origin/Pierre
        }

        #region IEnumerable<MyGraphic> Interface
        protected MyGraphic _curMyGraphic = null;
        public MyGraphic Current { get { return _curMyGraphic; } }
        public virtual bool MoveNext() { return false; }
        public virtual void Reset() { }
        public IEnumerator<MyGraphic> GetEnumerator() { return this; }
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        Object IEnumerator.Current { get { return this.Current; } }
        #endregion


        #endregion
    
}
}
