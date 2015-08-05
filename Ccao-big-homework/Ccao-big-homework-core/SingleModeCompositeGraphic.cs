﻿//Du 2015.8
//All rights reserved.

using System.Drawing.Drawing2D;

namespace Ccao_big_homework_core
{
    /// <summary>
    /// 整个graphic采用同一种drawmode的composite graphic
    /// </summary>
    public class SingleModeCompositeGraphic : CompositeGraphic
    {
        /// <summary>
        /// drawmode。
        /// 设置的时候将会把此graphic下属的所有graphic的drawmode都设置的跟母体一样。
        /// </summary>
        public DrawMode drawmode 
        {
            get
            {
                return drawmode;
            }
            set
            {
                foreach (_graphicpos gp in _list)
                {
                    MyGraphic g = gp.g;
                    SingleModeGraphic smg = g as SingleModeGraphic;
                    if (smg != null)
                    {
                        smg.drawmode = value;
                        continue;
                    }
                    SingleModeCompositeGraphic smcg = g as SingleModeCompositeGraphic;
                    if (smcg != null)
                    {
                        smg.drawmode = value;
                        continue;
                    }
                }
            }
        }
        /// <summary>
        /// 本函数返回所有的下属图形合并在一起所形成的graphicpath
        /// </summary>
        public GraphicsPath Combine()
        {
            GraphicsPath p = new GraphicsPath();
            foreach (_graphicpos gp in _list)
            {
                MyGraphic g = gp.g;
                SingleModeGraphic smg = g as SingleModeGraphic;
                if (smg != null)
                {
                    p.AddPath(smg.GetGraphicsPath(gp.left, gp.top), true);
                    continue;
                }
                SingleModeCompositeGraphic smcg = g as SingleModeCompositeGraphic;
                if (smcg != null)
                {
                    p.AddPath(smcg.Combine(), true);
                    continue;
                }
            }
            return p;
        }

        /// <summary>
        /// 假冒伪劣的空构造函数
        /// </summary>
        public SingleModeCompositeGraphic() : base() { }
    }
}
