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
        #region IEnumerator Interface
        public virtual Object Current { get { return null; } }
        public virtual bool MoveNext() { return false; }
        public virtual void Reset() { }
        #endregion


        #endregion
    }
}
