//Du 2015.8
//All rights reserved.
using System;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 基本的图像类
    /// </summary>
    public abstract class MyGraphic
    {
        #region basic properties and methods
        public int Height { get; set; }
        public int Width { get; set; }
        /// <summary>
        /// draw this graphic
        /// </summary>
        /// <param name="w">window to draw on</param>
        /// <param name="left">left</param>
        /// <param name="top">top</param>
        public abstract void Draw(MyWindow w, int left, int top);
        #endregion

        #region composite
        /// <summary>
        /// to ensure whether it is a composite
        /// </summary>
        /// <returns></returns>
        public virtual MyGraphic GetComposite() { return null; }
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

        #region IEnumerator Interface
        public virtual Object Current { get { return null; } }
        public virtual bool MoveNext() { return false; }
        public virtual void Reset() { }
        #endregion


        #endregion

    }
}
