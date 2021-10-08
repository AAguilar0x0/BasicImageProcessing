using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicImageProcessing
{
    public partial class Form1 : Form
    {
        BitmapImage sourceImage, resultImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "load":
                    trackBar1.Value = 0;
                    openFileDialog1.ShowDialog();
                    break;
                case "save":
                    saveFileDialog1.ShowDialog();
                    break;
                default:
                    resultImage = null;
                    break;
            }
            switch (e.ClickedItem.Name)
            {
                case "histogram":
                    resultImage = sourceImage.histogram();
                    break;
                case "copy":
                    resultImage = sourceImage.copy();
                    break;
                case "greyscale":
                    resultImage = sourceImage.greyscale();
                    break;
                case "invert":
                    resultImage = sourceImage.invert();
                    break;
                case "sepia":
                    resultImage = sourceImage.sepia();
                    break;
                case "brightness":
                    resultImage = sourceImage.brightness(trackBar1.Value);
                    break;
                case "contrast":
                    resultImage = sourceImage.contrast(trackBar1.Value);
                    break;
                case "flipHorizontal":
                    resultImage = sourceImage.flipHorizontal();
                    break;
                case "flipVertical":
                    resultImage = sourceImage.flipVertical();
                    break;
            }
            if (resultImage != null)
                result.Image = resultImage.getBitmap();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage = new BitmapImage(new Bitmap(openFileDialog1.FileName));
            source.Image = sourceImage.getBitmap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            resultImage.getBitmap().Save(saveFileDialog1.FileName);
        }
    }
}
