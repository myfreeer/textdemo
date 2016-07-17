using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToImageVector
{
    class Program
    {
        static void Main(string[] args)
        {
            //usage:
            //text2png string
            //text2png string width height
            System.Console.WriteLine("parameter count = {0}", args.Length);
            string text="";
            int w=950;
            int h=500;
            for (int i = 0; i < args.Length; i++) {System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);}
            try{text=args[0];} catch{text="error, no arguments.";}
            try{w=Convert.ToInt32(args[1]);h=Convert.ToInt32(args[2]);}catch{}
            var bitmapimage = new Bitmap(w, h);
            Graphics bitmapGraphics = Graphics.FromImage(bitmapimage);
            bitmapGraphics.Clear(Color.Black);
            bitmapGraphics.DrawString(text, new Font("Arial", 50, GraphicsUnit.Pixel), Brushes.White, new RectangleF(16, 16,w,h));
            bitmapimage.Save("Image.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
