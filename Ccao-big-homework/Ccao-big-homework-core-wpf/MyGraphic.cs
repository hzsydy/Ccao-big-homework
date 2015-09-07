//Du 2015.9
//All rights reserved.

using System;
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
    /// 基本的图像类
    /// </summary>
    public abstract class MyGraphic
    {
        #region basic properties and methods
        /// <summary>
        /// 画图
        /// </summary>
        public abstract Drawing Draw(int left = 0, int top = 0);
        #endregion

        #region interactivities
        /// <summary>
        /// 感知点p是否在图形内部，如是返回true
        /// left和top是两个修正值，因为如你所见你draw的时候也是要给left和top的，取iscontain的时候当然也要给。
        /// 你draw的时候给的0，0那你iscontained的时候也可以0，0
        /// </summary>
        public abstract bool isContained(Point p, int left = 0, int top = 0);
        /// <summary>
        /// 同上，返回找到的第一个被这个点选中的graphic
        /// </summary>
        public abstract MyGraphic SelectPoint(Point p, int left = 0, int top = 0);
        #endregion

        #region composite
        /// <summary>
        /// add a graphic
        /// </summary>
        /// <param name="g">graphic</param>
        /// <param name="left">left</param>
        /// <param name="top">top</param>
        public virtual void Add(MyGraphic g, int left, int top) { }
        /// <summary>
        /// Clear all child graphics
        /// </summary>
        public virtual void Clear() { }
        /// <summary>
        /// 确定这是否是一个composite
        /// </summary>
        public virtual bool isComposite() { return false; }

        /// <summary>
        /// 在自己挂掉的时候通知父节点删掉自己的callback
        /// </summary>
        /// <param name="o"></param>
        public delegate void Remove(MyGraphic g);
        public Remove FatherDeleteMePlease { get; set; }
        /// <summary>
        /// 对象删除
        /// </summary>
        public void Dispose() 
        {
            if (FatherDeleteMePlease != null)
            {
                FatherDeleteMePlease(this);
            }
        }

        #region IEnumerator Interface
        public virtual Object Current { get { return null; } }
        public virtual bool MoveNext() { return false; }
        public virtual void Reset() { }
        #endregion


        #endregion
    }
}
