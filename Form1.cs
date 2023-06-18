using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap img1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void umaImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void duasImagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form1 = new Form2();
            form1.Show();
        }

        private void espelhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form1 = new Form3();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            openFileDialog1.InitialDirectory = "C:\\Matlab";
            openFileDialog1.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 5;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filePath = openFileDialog1.FileName;
                bool bLoadImgOK = false;
                try
                {
                    img1 = new Bitmap(filePath);
                    bLoadImgOK = true;

                    if (bLoadImgOK == true)
                    {
                        int[] histogram = new int[256];
                        int totalPixels = img1.Width * img1.Height;

                        for (int i = 0; i < img1.Width; i++)
                        {
                            for (int j = 0; j < img1.Height; j++)
                            {
                                Color pixel = img1.GetPixel(i, j);
                                int intensity = (pixel.R + pixel.G + pixel.B) / 3;
                                histogram[intensity]++;
                            }
                        }

                        int maxCount = histogram.Max();
                        int numLabelsY = 5;
                        int labelIntervalY = maxCount / numLabelsY;
                        int panelWidth = panel1.Width;
                        int panelHeight = panel1.Height;
                        int barWidth = panelWidth / 256;

                        Bitmap histogramImage = new Bitmap(panelWidth, panelHeight);

                        using (Graphics g = Graphics.FromImage(histogramImage))
                        {
                            g.Clear(Color.White);

                            g.DrawLine(Pens.Black, 30, panelHeight - 30, panelWidth - 30, panelHeight - 30);
                            g.DrawLine(Pens.Black, 30, panelHeight - 30, 30, 30);

                            Font labelFont = new Font("Arial", 8);
                            StringFormat labelFormat = new StringFormat();
                            labelFormat.Alignment = StringAlignment.Center;

                            for (int i = 0; i <= 255; i += 25)
                            {
                                int labelX = i * barWidth + 30;
                                g.DrawString(i.ToString(), labelFont, Brushes.Black, new PointF(labelX, panelHeight - 15), labelFormat);
                            }

                            for (int i = 0; i <= numLabelsY; i++)
                            {
                                int labelValueY = i * labelIntervalY;
                                int labelY = panelHeight - 30 - (int)(labelValueY * (panelHeight - 60) / (double)maxCount);
                                g.DrawString(labelValueY.ToString(), labelFont, Brushes.Black, new RectangleF(5, labelY - 7, 25, 15), labelFormat);
                            }

                            for (int i = 0; i < 256; i++)
                            {
                                int barHeight = (int)((histogram[i] / (double)maxCount) * (panelHeight - 60));
                                int barX = i * barWidth + 30;
                                int barY = panelHeight - barHeight - 30;

                                g.FillRectangle(Brushes.Black, barX, barY, barWidth, barHeight);
                            }
                        }

                        panel1.BackgroundImage = histogramImage;
                        pictureBox1.Image = img1;
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Não foi possivel carregar a imagem", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bLoadImgOK = false;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double addValue;

            try
            {

                if (!double.TryParse(textBox1.Text, out addValue))
                {
                    addValue = 1;
                }

                if (img1 != null)
                {
                    Bitmap img3 = new Bitmap(img1.Height, img1.Width);


                    for (int i = 0; i < img3.Width; i++)
                    {
                        for (int j = 0; j < img3.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            double R = pixelP.R + addValue;
                            double G = pixelP.G + addValue;
                            double B = pixelP.B + addValue;
                            double A = pixelP.A + addValue;

                            R = Math.Min(R, 255);
                            G = Math.Min(G, 255);
                            B = Math.Min(B, 255);

                            img3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                            pictureBox3.Image = img3;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor a imagem", "Verifique o valor digitado...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double subValue;

            try
            {
                if (!double.TryParse(textBox2.Text, out subValue))
                {
                    subValue = 1.0;
                }

                if (img1 != null)
                {
                    Bitmap img4 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img4.Width; i++)
                    {
                        for (int j = 0; j < img4.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            int R = Math.Max(0, (int)(pixelP.R - subValue));
                            int G = Math.Max(0, (int)(pixelP.G - subValue));
                            int B = Math.Max(0, (int)(pixelP.B - subValue));
                            int A = Math.Max(0, (int)(pixelP.A - subValue));

                            img4.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img4;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao subtrair um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double value;

            try
            {

                if (!double.TryParse(textBox3.Text, out value))
                {
                    value = 1.0;
                }

                if (img1 != null)
                {
                    Bitmap img5 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img5.Width; i++)
                    {
                        for (int j = 0; j < img5.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            int R = (int)(pixelP.R * value / 255);
                            int G = (int)(pixelP.G * value / 255);
                            int B = (int)(pixelP.B * value / 255);
                            int A = (int)(pixelP.A * value / 255);

                            img5.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img5;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao multiplicar pelo valor", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double value;

            try
            {

                if (!double.TryParse(textBox4.Text, out value))
                {
                    value = 1.0;
                }

                if (img1 != null)
                {
                    Bitmap img6 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img6.Width; i++)
                    {
                        for (int j = 0; j < img6.Height; j++)
                        {
                            int R = 0, G = 0, B = 0, A = 0;
                            Color pixelP = img1.GetPixel(i, j);

                            if (value != 0.0)
                            {
                                R = (int)(pixelP.R / value);
                                G = (int)(pixelP.G / value);
                                B = (int)(pixelP.B / value);
                                A = (int)(pixelP.A / value);
                            }

                            img6.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img6;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao dividir um valor a imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double blendValue;

            try
            {

                if (!double.TryParse(textBox5.Text, out blendValue))
                {
                    blendValue = 0.5f;
                }

                if (img1 != null)
                {
                    Bitmap img8 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img8.Width; i++)
                    {
                        for (int j = 0; j < img8.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            int R = (int)(pixelP.R * blendValue + (1 - blendValue) * pixelP.R);
                            int G = (int)(pixelP.G * blendValue + (1 - blendValue) * pixelP.G);
                            int B = (int)(pixelP.B * blendValue + (1 - blendValue) * pixelP.B);
                            int A = (int)(pixelP.A * blendValue + (1 - blendValue) * pixelP.A);

                            img8.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img8;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor a imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {  
            double value = 128;

            try
            {

                if (img1 != null)
                {
                    Bitmap img9 = new Bitmap(img1.Width, img1.Height);

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color pixel = img1.GetPixel(i, j);

                            int intensity = (pixel.R + pixel.G + pixel.B) / 3;

                            Color pixelBinaria = (intensity > value) ? Color.White : Color.Black;
                            img9.SetPixel(i, j, pixelBinaria);

                        }
                    }

                    pictureBox3.Image = img9;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor a imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    Bitmap img10 = new Bitmap(img1.Width, img1.Height);

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color pixel = img1.GetPixel(i, j);

                            int intensity = (pixel.R + pixel.G + pixel.B) / 3;

                            Color grayPixel = Color.FromArgb(intensity, intensity, intensity);
                            img10.SetPixel(i, j, grayPixel);
                        }
                    }

                    pictureBox3.Image = img10;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    Bitmap img11 = new Bitmap(img1.Width, img1.Height);

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color pixel = img1.GetPixel(i, j);

                            int intensity = pixel.R;

                            int negativeIntensity = 255 - intensity;

                            Color negativePixel = Color.FromArgb(negativeIntensity, negativeIntensity, negativeIntensity);

                            img11.SetPixel(i, j, negativePixel);
                        }
                    }

                    pictureBox3.Image = img11;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    Bitmap img12 = new Bitmap(img1.Width, img1.Height);

                    int filterSize = 3;
                    int halfSize = filterSize / 2;

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color maxPixel = img1.GetPixel(i, j);

                            for (int k = i - halfSize; k <= i + halfSize; k++)
                            {
                                for (int l = j - halfSize; l <= j + halfSize; l++)
                                {
                                    if (k >= 0 && k < img1.Width && l >= 0 && l < img1.Height)
                                    {
                                        Color neighborPixel = img1.GetPixel(k, l);

                                        if (neighborPixel.GetBrightness() > maxPixel.GetBrightness())
                                        {
                                            maxPixel = neighborPixel;
                                        }
                                    }
                                }
                            }

                            img12.SetPixel(i, j, maxPixel);
                        }
                    }

                    pictureBox3.Image = img12;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    Bitmap img13 = new Bitmap(img1.Width, img1.Height);

                    int filterSize = 3;
                    int halfSize = filterSize / 2;

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color minPixel = img1.GetPixel(i, j);

                            for (int k = i - halfSize; k <= i + halfSize; k++)
                            {
                                for (int l = j - halfSize; l <= j + halfSize; l++)
                                {
                                    if (k >= 0 && k < img1.Width && l >= 0 && l < img1.Height)
                                    {
                                        Color neighborPixel = img1.GetPixel(k, l);

                                        if (neighborPixel.GetBrightness() < minPixel.GetBrightness())
                                        {
                                            minPixel = neighborPixel;
                                        }
                                    }
                                }
                            }

                            img13.SetPixel(i, j, minPixel);
                        }
                    }

                    pictureBox3.Image = img13;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    Bitmap img14 = new Bitmap(img1.Width, img1.Height);

                    int filterSize = 3;
                    int halfSize = filterSize / 2;

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            int sumR = 0;
                            int sumG = 0;
                            int sumB = 0;
                            int count = 0;

                            for (int k = i - halfSize; k <= i + halfSize; k++)
                            {
                                for (int l = j - halfSize; l <= j + halfSize; l++)
                                {
                                    if (k >= 0 && k < img1.Width && l >= 0 && l < img1.Height)
                                    {
                                        Color neighborPixel = img1.GetPixel(k, l);

                                        sumR += neighborPixel.R;
                                        sumG += neighborPixel.G;
                                        sumB += neighborPixel.B;
                                        count++;
                                    }
                                }
                            }

                            int avgR = sumR / count;
                            int avgG = sumG / count;
                            int avgB = sumB / count;

                            Color avgPixel = Color.FromArgb(avgR, avgG, avgB);
                            img14.SetPixel(i, j, avgPixel);
                        }
                    }

                    pictureBox3.Image = img14;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    int[] equalizedHistogram = CalculateEqualizedHistogram(img1);

                    Bitmap equalizedImage = new Bitmap(img1.Width, img1.Height);

                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color pixel = img1.GetPixel(i, j);

                            int equalizedRed = equalizedHistogram[pixel.R];
                            int equalizedGreen = equalizedHistogram[pixel.G];
                            int equalizedBlue = equalizedHistogram[pixel.B];

                            Color equalizedPixel = Color.FromArgb(equalizedRed, equalizedGreen, equalizedBlue);

                            equalizedImage.SetPixel(i, j, equalizedPixel);
                        }
                    }

                    CalculateEqualizedHistogram(img1);
                    pictureBox3.Image = equalizedImage;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {

                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png|Todos os Arquivos|*.*";
                        saveFileDialog.Title = "Salvar Imagem";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string outputPath = saveFileDialog.FileName;
                            pictureBox3.Image.Save(outputPath);
                        }
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao salvar a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }        
            }
            else
            {
                MessageBox.Show("Nenhuma imagem para salvar!");
            }
        }

        public int[] CalculateEqualizedHistogram(Bitmap img)
        {
            int[] histogram = new int[256];
            int[] cumulativeHistogram = new int[256];
            int[] equalizedHistogram = new int[256];
            int totalPixels = img1.Width * img1.Height;

            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color pixel = img1.GetPixel(i, j);
                    int intensity = (pixel.R + pixel.G + pixel.B) / 3;
                    histogram[intensity]++;
                }
            }

            cumulativeHistogram[0] = histogram[0];

            for (int i = 1; i < 256; i++)
            {
                cumulativeHistogram[i] = cumulativeHistogram[i - 1] + histogram[i];
            }

            for (int i = 0; i < 256; i++)
            {
                equalizedHistogram[i] = (int)(cumulativeHistogram[i] * 255.0 / totalPixels);
            }

            int panelWidth = panel2.Width;
            int panelHeight = panel2.Height;
            int barWidth = panelWidth / 256;
            int maxCount = histogram.Max();
            int numLabelsY = 5;
            int labelIntervalY = maxCount / numLabelsY;


            Bitmap histogramImage = new Bitmap(panelWidth, panelHeight);

            using (Graphics g = Graphics.FromImage(histogramImage))
            {
                g.Clear(Color.White);

                g.DrawLine(Pens.Black, 30, panelHeight - 30, panelWidth - 30, panelHeight - 30); // Eixo X
                g.DrawLine(Pens.Black, 30, panelHeight - 30, 30, 30); // Eixo Y

                Font labelFont = new Font("Arial", 8);
                StringFormat labelFormat = new StringFormat();
                labelFormat.Alignment = StringAlignment.Center;

                for (int i = 0; i <= 255; i += 25)
                {
                    int labelX = i * barWidth + 30;
                    g.DrawString(i.ToString(), labelFont, Brushes.Black, new PointF(labelX, panelHeight - 15), labelFormat);
                }

                for (int i = 0; i <= numLabelsY; i++)
                {
                    int labelValueY = i * labelIntervalY;
                    int labelY = panelHeight - 30 - (int)(labelValueY * (panelHeight - 60) / (double)maxCount);
                    g.DrawString(labelValueY.ToString(), labelFont, Brushes.Black, new RectangleF(5, labelY - 7, 25, 15), labelFormat);
                }

                for (int i = 0; i < 256; i++)
                {
                    int barHeight = (int)(equalizedHistogram[i] * (panelHeight - 60) / (double)equalizedHistogram.Max());
                    int barX = i * barWidth + 30;
                    int barY = panelHeight - barHeight - 30;

                    g.FillRectangle(Brushes.Black, barX, barY, barWidth, barHeight);
                }
            }

            panel2.BackgroundImage = histogramImage;
            return equalizedHistogram;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    int width = img1.Width;
                    int height = img1.Height;
                    int windowSize = 3;

                    Bitmap medianImage = new Bitmap(width, height);

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            List<int> pixelValues = new List<int>();
                            for (int ni = i - windowSize / 2; ni <= i + windowSize / 2; ni++)
                            {
                                for (int nj = j - windowSize / 2; nj <= j + windowSize / 2; nj++)
                                {
                                    if (ni >= 0 && ni < width && nj >= 0 && nj < height)
                                    {
                                        Color pixel = img1.GetPixel(ni, nj);
                                        int intensity = (pixel.R + pixel.G + pixel.B) / 3;
                                        pixelValues.Add(intensity);
                                    }
                                }
                            }

                            pixelValues.Sort();

                            int medianIndex = pixelValues.Count / 2;

                            int medianValue = pixelValues[medianIndex];

                            medianImage.SetPixel(i, j, Color.FromArgb(medianValue, medianValue, medianValue));
                        }
                    }

                    pictureBox3.Image = medianImage;
                }


            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    int width = img1.Width;
                    int height = img1.Height;
                    int windowSize = 3;
                    int order;

                    if (!int.TryParse(textBox6.Text, out order))
                    {
                        order = 1;
                    }

                    Bitmap orderedImage = new Bitmap(width, height);

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            List<int> pixelValues = new List<int>();

                            for (int ni = i - windowSize / 2; ni <= i + windowSize / 2; ni++)
                            {
                                for (int nj = j - windowSize / 2; nj <= j + windowSize / 2; nj++)
                                {
                                    if (ni >= 0 && ni < width && nj >= 0 && nj < height)
                                    {
                                        Color pixel = img1.GetPixel(ni, nj);
                                        int intensity = (pixel.R + pixel.G + pixel.B) / 3;
                                        pixelValues.Add(intensity);
                                    }
                                }
                            }

                            pixelValues.Sort();
                            int selectedValue = pixelValues[order - 1];
                            orderedImage.SetPixel(i, j, Color.FromArgb(selectedValue, selectedValue, selectedValue));
                        }
                    }

                    pictureBox3.Image = orderedImage;
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    int width = img1.Width;
                    int height = img1.Height;
                    int windowSize = 3;
                    int threshold = 20;

                    Bitmap smoothedImg = new Bitmap(width, height);

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            List<int> pixelValues = new List<int>();

                            for (int ni = i - windowSize / 2; ni <= i + windowSize / 2; ni++)
                            {
                                for (int nj = j - windowSize / 2; nj <= j + windowSize / 2; nj++)
                                {
                                    if (ni >= 0 && ni < width && nj >= 0 && nj < height)
                                    {
                                        Color pixel = img1.GetPixel(ni, nj);
                                        int intensity = (pixel.R + pixel.G + pixel.B) / 3;
                                        pixelValues.Add(intensity);
                                    }
                                }
                            }

                            pixelValues.Sort();

                            int centralValue = pixelValues[pixelValues.Count / 2];
                            int sum = 0;
                            int count = 0;

                            foreach (int value in pixelValues)
                            {
                                if (Math.Abs(value - centralValue) <= threshold)
                                {
                                    sum += value;
                                    count++;
                                }
                            }

                            int smoothedValue = count > 0 ? sum / count : centralValue;
                            smoothedImg.SetPixel(i, j, Color.FromArgb(smoothedValue, smoothedValue, smoothedValue));
                        }
                    }

                    pictureBox3.Image = smoothedImg;
                }


            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null)
                {
                    int width = img1.Width;
                    int height = img1.Height;

                    Bitmap filteredImg = new Bitmap(width, height);
                    double sigma;

                    if (!double.TryParse(textBox6.Text, out sigma))
                    {
                        sigma = 0.2f;
                    }

                    int kernelSize = 5;
                    int kernelHalfSize = kernelSize / 2;

                    double[,] kernel = new double[kernelSize, kernelSize];
                    double kernelSum = 0;

                    for (int i = -kernelHalfSize; i <= kernelHalfSize; i++)
                    {
                        for (int j = -kernelHalfSize; j <= kernelHalfSize; j++)
                        {
                            double exponent = -(i * i + j * j) / (2 * sigma * sigma);
                            kernel[i + kernelHalfSize, j + kernelHalfSize] = Math.Exp(exponent);
                            kernelSum += kernel[i + kernelHalfSize, j + kernelHalfSize];
                        }
                    }

                    for (int i = 0; i < kernelSize; i++)
                    {
                        for (int j = 0; j < kernelSize; j++)
                        {
                            kernel[i, j] /= kernelSum;
                        }
                    }

                    for (int i = kernelHalfSize; i < width - kernelHalfSize; i++)
                    {
                        for (int j = kernelHalfSize; j < height - kernelHalfSize; j++)
                        {
                            double r = 0, g = 0, b = 0;

                            for (int k = -kernelHalfSize; k <= kernelHalfSize; k++)
                            {
                                for (int l = -kernelHalfSize; l <= kernelHalfSize; l++)
                                {
                                    Color pixel = img1.GetPixel(i + k, j + l);
                                    double kernelValue = kernel[k + kernelHalfSize, l + kernelHalfSize];

                                    r += pixel.R * kernelValue;
                                    g += pixel.G * kernelValue;
                                    b += pixel.B * kernelValue;
                                }
                            }

                            int filteredR = (int)Math.Round(r);
                            int filteredG = (int)Math.Round(g);
                            int filteredB = (int)Math.Round(b);

                            filteredImg.SetPixel(i, j, Color.FromArgb(filteredR, filteredG, filteredB));
                        }
                    }

                    pictureBox2.Image = filteredImg;
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro ao adicionar um valor à imagem", "Verifique o tamanho da imagem...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
