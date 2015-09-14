using Ccao_big_homework_core_wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ccao_big_homework
{
    /// <summary>
    /// 图形操作相关方法
    /// </summary>
    public partial class WorkWindow : Window
    {
        #region 变量定义
        private List<CompositeGraphic> selectedGraphics = new List<CompositeGraphic>();
        private List<CompositeGraphic> clonedGraphics = new List<CompositeGraphic>();
        #endregion

        #region 相关方法
        //剪切
        private void Cut()
        {
            if (selectedGraphics != null)
            {
                clonedGraphics.Clear();
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.isVisible = true;
                    clonedGraphics.Add((CompositeGraphic)cg.Clone());
                    cg.Dispose();
                }
                selectedGraphics.Clear();
            }
        }
        //复制
        private void Copy()
        {
            if (selectedGraphics != null)
            {
                clonedGraphics.Clear();
                foreach (CompositeGraphic cg in selectedGraphics)
                {
                    cg.isVisible = true;
                    clonedGraphics.Add((CompositeGraphic)cg.Clone());
                }
                selectedGraphics.Clear();
            }
        }
        //粘贴
        private void Paste()
        {
            if (clonedGraphics != null)
            {
                foreach (CompositeGraphic cg in clonedGraphics)
                {
                    compositeGraphic.Add(cg, 10, 10);
                    if (cg != null)
                        selectedGraphics.Add(cg);
                }
                clonedGraphics.Clear();
                rbSelect.IsChecked = true;
                du_refresh();
            }
        }
        //删除
        private void Delete()
        {
            foreach (MyGraphic mg in selectedGraphics)
            {
                if (mg != null)
                    mg.Dispose();
            }
            if (selectedGraphics != null)
                selectedGraphics.Clear();
            du_refresh();
        }
        //全选
        private void SelectAll()
        {
            CompositeGraphic mg = compositeGraphic.SelectRect(new Point(0, 0), new Point(canvas1.Width, canvas1.Height));
            if (mg != null)
                selectedGraphics.Add(mg);
            canvas1.ReleaseMouseCapture();
        }
        #endregion
    }
}
