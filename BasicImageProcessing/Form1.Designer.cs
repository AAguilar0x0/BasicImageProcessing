
namespace BasicImageProcessing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.source = new System.Windows.Forms.PictureBox();
            this.result = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.histogram = new System.Windows.Forms.ToolStripMenuItem();
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscale = new System.Windows.Forms.ToolStripMenuItem();
            this.invert = new System.Windows.Forms.ToolStripMenuItem();
            this.sepia = new System.Windows.Forms.ToolStripMenuItem();
            this.brightness = new System.Windows.Forms.ToolStripMenuItem();
            this.contrast = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(12, 27);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(385, 238);
            this.source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.source.TabIndex = 0;
            this.source.TabStop = false;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(403, 27);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(385, 238);
            this.result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.result.TabIndex = 1;
            this.result.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmp";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load,
            this.histogram,
            this.copy,
            this.greyscale,
            this.invert,
            this.sepia,
            this.brightness,
            this.contrast,
            this.flipHorizontal,
            this.flipVertical,
            this.save});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // load
            // 
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(45, 20);
            this.load.Text = "Load";
            // 
            // histogram
            // 
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(75, 20);
            this.histogram.Text = "Histogram";
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(47, 20);
            this.copy.Text = "Copy";
            // 
            // greyscale
            // 
            this.greyscale.Name = "greyscale";
            this.greyscale.Size = new System.Drawing.Size(69, 20);
            this.greyscale.Text = "Greyscale";
            // 
            // invert
            // 
            this.invert.Name = "invert";
            this.invert.Size = new System.Drawing.Size(49, 20);
            this.invert.Text = "Invert";
            // 
            // sepia
            // 
            this.sepia.Name = "sepia";
            this.sepia.Size = new System.Drawing.Size(47, 20);
            this.sepia.Text = "Sepia";
            // 
            // brightness
            // 
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(74, 20);
            this.brightness.Text = "Brightness";
            // 
            // contrast
            // 
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(64, 20);
            this.contrast.Text = "Contrast";
            // 
            // flipHorizontal
            // 
            this.flipHorizontal.Name = "flipHorizontal";
            this.flipHorizontal.Size = new System.Drawing.Size(96, 20);
            this.flipHorizontal.Text = "Flip Horizontal";
            // 
            // flipVertical
            // 
            this.flipVertical.Name = "flipVertical";
            this.flipVertical.Size = new System.Drawing.Size(79, 20);
            this.flipVertical.Text = "Flip Vertical";
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(43, 20);
            this.save.Text = "Save";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(12, 271);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = -255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(385, 45);
            this.trackBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 382);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.source);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox source;
        private System.Windows.Forms.PictureBox result;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.ToolStripMenuItem copy;
        private System.Windows.Forms.ToolStripMenuItem greyscale;
        private System.Windows.Forms.ToolStripMenuItem invert;
        private System.Windows.Forms.ToolStripMenuItem histogram;
        private System.Windows.Forms.ToolStripMenuItem sepia;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem brightness;
        private System.Windows.Forms.ToolStripMenuItem contrast;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem flipVertical;
    }
}

