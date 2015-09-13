//Du 2015.9
//All rights reserved.

using System;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Ccao_big_homework_emgucv
{
    public class Panda
    {
        public static IImage getPanda(Image<Rgba, Byte> i)
        {
            Image<Gray, Byte> grey_img = i.Convert<Gray, Byte>();
            return grey_img;
        }
    }
}
