using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BasicImageProcessing
{
    class BitmapImage
    {
        private Bitmap image;

        public BitmapImage() { }

        public BitmapImage(Bitmap newImage)
        {
            image = newImage;
        }

        public Bitmap getBitmap()
        {
            return image;
        }

        public BitmapImage histogram()
        {
            int width = image.Width;
            int height = image.Height;
            int[] hist = new int[256];
            int largestValue = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int greyscale = (pixel.R + pixel.G + pixel.B) / 3;
                    hist[greyscale]++;
                    largestValue = hist[greyscale] > largestValue ? hist[greyscale] : largestValue;
                }
            Bitmap histGraph = new Bitmap(256, 200);
            decimal factor = largestValue / 200;
            for (int x = 0; x < 256; x++)
                for (int y = 0; y < 200; y++)
                {
                    if (y < Math.Min((int)(hist[x] / factor), 255))
                    {
                        histGraph.SetPixel(x, 200 - 1 - y, Color.Black);
                    }
                    else
                    {
                        histGraph.SetPixel(x, 200 - 1 - y, Color.White);
                    }
                }
            return new BitmapImage(histGraph);
        }

        public BitmapImage copy()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    newImage.SetPixel(x, y, pixel);
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage greyscale()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int greyscale = (pixel.R + pixel.G + pixel.B) / 3;
                    newImage.SetPixel(x, y, Color.FromArgb(greyscale, greyscale, greyscale));
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage invert()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    newImage.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage sepia()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int nR = (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189);
                    int nG = (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168);
                    int nB = (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131);
                    newImage.SetPixel(x, y, Color.FromArgb(nR <= 255 ? nR : 255, nG <= 255 ? nG : 255, nB <= 255 ? nB : 255));
                }
            return new BitmapImage(newImage);
        }

        private int colorCorrect(int color)
        {
            if (color > 255)
                return 255;
            else if (color < 0)
                return 0;
            else
                return color;
        }

        public BitmapImage brightness(int brightness)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    newImage.SetPixel(x, y, Color.FromArgb(
                        colorCorrect(pixel.R + brightness),
                        colorCorrect(pixel.G + brightness),
                        colorCorrect(pixel.B + brightness)
                    ));
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage contrast(float degree = 0)
        {
            int width = image.Width;
            int height = image.Height;
            int[] histRed = new int[256];
            int[] histGreen = new int[256];
            int[] histBlue = new int[256];
            int redMax = -1;
            int greenMax = -1;
            int blueMax = -1;
            int redMin = 256;
            int greenMin = 256;
            int blueMin = 256;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    histRed[pixel.R]++;
                    histGreen[pixel.G]++;
                    histBlue[pixel.B]++;
                    redMax = pixel.R >= redMax ? pixel.R : redMax;
                    greenMax = pixel.G >= greenMax ? pixel.G : greenMax;
                    blueMax = pixel.B >= blueMax ? pixel.B : blueMax;
                    redMin = pixel.R <= redMin ? pixel.R : redMin;
                    greenMin = pixel.G <= greenMin ? pixel.G : greenMin;
                    blueMin = pixel.B <= blueMin ? pixel.B : blueMin;
                }
            int[] YmapRed = new int[256];
            int[] YmapGreen = new int[256];
            int[] YmapBlue = new int[256];
            int totalSample = width * height;
            int histRedSum = 0;
            int histGreenSum = 0;
            int histBlueSum = 0;
            for (int i = 0; i < 256; i++)
            {
                histRedSum += histRed[i];
                YmapRed[i] = (int)((histRedSum * 255 / totalSample) * degree / 100);
                histGreenSum += histGreen[i];
                YmapGreen[i] = (int)((histGreenSum * 255 / totalSample) * degree / 100);
                histBlueSum += histBlue[i];
                YmapBlue[i] = (int)((histBlueSum * 255 / totalSample) * degree / 100);
            }
            for (int i = 0; i < 256; i++)
            {
                YmapRed[i] = (int)(i + (YmapRed[i] - i) * degree / 100);
                YmapGreen[i] = (int)(i + (YmapGreen[i] - i) * degree / 100);
                YmapBlue[i] = (int)(i + (YmapBlue[i] - i) * degree / 100);
            }
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color temp = Color.FromArgb(YmapRed[image.GetPixel(x, y).R], YmapGreen[image.GetPixel(x, y).G], YmapBlue[image.GetPixel(x, y).B]);
                    newImage.SetPixel(x, y, temp);
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage flipHorizontal()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    newImage.SetPixel(x, height - 1 - y, pixel);
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage flipVertical()
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    newImage.SetPixel(width - 1 - x, y, pixel);
                }
            return new BitmapImage(newImage);
        }

        public BitmapImage rotate(float degree)
        {
            int width = image.Width;
            int height = image.Height;
            int xCenter = width / 2;
            int yCenter = height / 2;
            double radiance = (degree * Math.PI / 180);
            float cosA = (float)Math.Cos(radiance);
            float sinA = (float)Math.Sin(radiance);
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int xi = x - xCenter;
                    int yi = y - yCenter;
                    newImage.SetPixel(x, y, image.GetPixel(
                        Math.Max(0, Math.Min(width - 1, (int)(xi * cosA + yi * sinA) + xCenter)),
                        Math.Max(0, Math.Min(height - 1, (int)(-xi * sinA + yi * cosA) + yCenter))
                        ));
                }
            return new BitmapImage(newImage);
        }
    }
}
