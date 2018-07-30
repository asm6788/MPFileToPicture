using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = File.ReadAllBytes("input.png");
            Bitmap image = (Bitmap)Image.FromFile("input.png");
            List<Color> Colors = new List<Color>();
            for (int x = 0; x != image.Width; x++)
            {
                for (int y = 0; y != image.Height; y++)
                {
                    Colors.Add(image.GetPixel(x, y));
                }
            }
            List<byte> result = new List<byte>();
            for (int i = 0; i < Colors.Count; i++)
            {
                if (i + 1 == bytes.Length)
                {
                    result.Add(Colors[i].R);
                }
                else if (i + 2 == bytes.Length)
                {
                    result.Add(Colors[i].R);
                    result.Add(Colors[i].G);
                }
                else
                {
                    result.Add(Colors[i].R);
                    result.Add(Colors[i].G);
                    result.Add(Colors[i].B);
                }
            }
            File.WriteAllBytes("output", result.ToArray());
            List<Divisor> divisors = GetDivisors(result.Count);
            Console.WriteLine("입력가능한 쓰레드들");
            foreach(Divisor divi in divisors)
            {
                int EachByte = result.Count / divi.A;
                if(EachByte % 3 == 0)
                {
                    Console.WriteLine(divi.A);
                }
            }
            Console.Read();
        }

        private static List<Divisor> GetDivisors(int num)
        {
            List<Divisor> temp = new List<Divisor>();
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    temp.Add(new Divisor(i, num / i));
                }
            }
            return temp;
        }
    }


    class Divisor
    {
        public int A;
        public int B;

        public Divisor(int a, int b)
        {
            A = a;
            B = b;
        }

    }
    class PictureSize
    {
        public int W;
        public int H;
        public bool IsCircle;

        public PictureSize(int w, int h)
        {
            W = w;
            H = h;
        }

        public PictureSize(int w, int h, bool isCircle) : this(w, h)
        {
            IsCircle = isCircle;
        }
    }
}
