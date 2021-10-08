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

        /*public BitmapImage contrast(int contrast)
        {
            int width = image.Width;
            int height = image.Height;
            float contrastCorrectionFactor = (259 * (contrast + 255)) / (255 * (259 - contrast));
            Bitmap newImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Console.WriteLine((contrastCorrectionFactor * (pixel.R - 128) + 128) + " " +
                        (contrastCorrectionFactor * (pixel.G - 128) + 128) + " " +
                        (contrastCorrectionFactor * (pixel.B - 128) + 128) + " ");
                    newImage.SetPixel(x, y, Color.FromArgb(
                        colorCorrect((int)(contrastCorrectionFactor * (pixel.R - 128) + 128)),
                        colorCorrect((int)(contrastCorrectionFactor * (pixel.G - 128) + 128)),
                        colorCorrect((int)(contrastCorrectionFactor * (pixel.B - 128) + 128))
                    *//*colorCorrector((int)(((pixel.R / 255.0f * contrast) + 0.5f) * 255.0f)),
                    colorCorrector((int)(((pixel.G / 255.0f * contrast) + 0.5f) * 255.0f)),
                    colorCorrector((int)(((pixel.B / 255.0f * contrast) + 0.5f) * 255.0f))*//*
                    ));
                }
            return new BitmapImage(newImage);
        }*/

        public BitmapImage contrast(int degree)
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
                YmapRed[i] = histRedSum * 255 / totalSample;
                histGreenSum += histGreen[i];
                YmapGreen[i] = histGreenSum * 255 / totalSample;
                histBlueSum += histBlue[i];
                YmapBlue[i] = histBlueSum * 255 / totalSample;
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

        /*public void equalization(ref Bitmap a, ref Bitmap b, int degree)
        {​
            int height = a.Height;
            int width = a.Width;
            int numSamples, histSum;
            int[] Ymap = new int[256];
            int[] hist = new int[256];
            int percent = degree;
            // compute the histogram from the sub-image
            Color nakuha;
            Color gray;
            Byte graydata;
            //compute greyscale
            for (int x = 0; x < a.Width; x++)
            {​
                for (int y = 0; y < a.Height; y++)
                {​
                    nakuha = a.GetPixel(x, y);
                    graydata = (byte)((nakuha.R + nakuha.G + nakuha.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }​
            }​
            //histogram 1d data;
            for (int x = 0; x < a.Width; x++)
            {​
                for (int y = 0; y < a.Height; y++)
                {​
                    nakuha = a.GetPixel(x, y);
                    hist[nakuha.B]++;
                }​
            }​
            // remap the Ys, use the maximum contrast (percent == 100)
            // based on histogram equalization
            numSamples = (a.Width * a.Height); // # of samples that contributed to the histogram
            histSum = 0;
            for (int h = 0; h < 256; h++)
            {​
                histSum += hist[h];
                Ymap[h] = histSum * 255 / numSamples;
            }​
             // if desired contrast is not maximum (percent < 100), then adjust the mapping
            if (percent < 100)
            {​
                for (int h = 0; h < 256; h++)
                {​
                    Ymap[h] = h + ((int)Ymap[h] - h) * percent / 100;
                }​
            }​
             b = new Bitmap(a.Width, a.Height);
            // enhance the region by remapping the intensities
            for (int y = 0; y < a.Height; y++)
            {​
                for (int x = 0; x < a.Width; x++)
                {​
                    // set the new value of the gray value
                    Color temp = Color.FromArgb(Ymap[a.GetPixel(x, y).R], Ymap[a.GetPixel(x, y).G], Ymap[a.GetPixel(x, y).B]);
                    b.SetPixel(x, y, temp);
                }​
             }​
        }*/


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
    }
}
