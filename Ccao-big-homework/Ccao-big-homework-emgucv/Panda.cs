//Du 2015.9
//All rights reserved.
//训练库来自Intel的Open Source Computer Vision Library

using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Ccao_big_homework_emgucv
{
    public class Panda
    {
        private string haarXmlPath = "D:\\learn\\Git\\Ccao-big-homework\\Ccao-big-homework\\Ccao-big-homework-emgucv\\haarcascade_frontalface_alt_tree.xml";
        private HaarCascade haar;

        /// <summary>
        /// 初始化一个HaarCascade
        /// </summary>
        private void initHaar(string fileName)
        {
            if (haar != null) return;
            haar = new HaarCascade(fileName);
        }

        /// <summary>
        /// 用指定的HaarCascade和img识别人脸
        /// 返回一个Image list
        /// </summary>
        private List<Image<Bgr, byte>> markFaces(Image<Bgr, byte> img, HaarCascade haar)
        {
            List<Image<Bgr, byte>> l = new List<Image<Bgr, byte>>();
            l.Clear();
            if (haar == null || img == null) return l;
            MCvAvgComp[] faces = haar.Detect(
                img.Convert<Gray, Byte>(),
                1.4,
                1,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new System.Drawing.Size(20, 20),
                new System.Drawing.Size(100, 100)
            );
            foreach (MCvAvgComp face in faces)
            {
                l.Add(img.Copy(face.rect));
            }
            return l;
        }

        public Image<Bgr, Byte> getPanda(Image<Bgr, Byte> i, Image<Bgr, Byte> panda,
            int left, int top, int width, int height)
        {
            if (panda == null || i == null) return null;
            initHaar(haarXmlPath);
            List<Image<Bgr, byte>> l = markFaces(i, haar);
            if (l.Count == 0) return null;
            Image<Bgr, Byte> originface = l[0];
            Emgu.CV.Image<Bgr, byte> face = originface.Resize(width, height, INTER.CV_INTER_CUBIC);  
            Image<Bgr, Byte> final = panda.Copy();
            final.ROI = new System.Drawing.Rectangle(left, top, width, height);
            final.Add(face, face.Convert<Gray, Byte>());
            final.ROI = System.Drawing.Rectangle.Empty;
            return final;
        }
    }
}
