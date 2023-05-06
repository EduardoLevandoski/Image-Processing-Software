using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            openFileDialog1.FilterIndex = 2;
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
            int addValue;

            try
            {

                if (!int.TryParse(textBox1.Text, out addValue))
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

                            int R = pixelP.R + addValue;
                            int G = pixelP.G + addValue;
                            int B = pixelP.B + addValue;
                            int A = pixelP.A + addValue;

                            R = Math.Min(R, 255);
                            G = Math.Min(G, 255);
                            B = Math.Min(B, 255);

                            img3.SetPixel(i, j, Color.FromArgb(R, G, B));
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
            int subValue;

            try
            {

                if (!int.TryParse(textBox2.Text, out subValue))
                {
                    subValue = 1;
                }

                if (img1 != null)
                {
                    Bitmap img4 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img4.Width; i++)
                    {
                        for (int j = 0; j < img4.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            int R = Math.Max(0, pixelP.R - subValue);
                            int G = Math.Max(0, pixelP.G - subValue);
                            int B = Math.Max(0, pixelP.B - subValue);
                            int A = Math.Max(0, pixelP.A - subValue);

                            img4.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img4;
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

        private void button5_Click(object sender, EventArgs e)
        {
            int value;

            try
            {

                if (!int.TryParse(textBox3.Text, out value))
                {
                    value = 1;
                }

                if (img1 != null)
                {
                    Bitmap img5 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img5.Width; i++)
                    {
                        for (int j = 0; j < img5.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);

                            int R = pixelP.R * value / 255;
                            int G = pixelP.G * value / 255;
                            int B = pixelP.B * value / 255;
                            int A = pixelP.A * value / 255;

                            img5.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img5;
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

        private void button6_Click(object sender, EventArgs e)
        {
            int value;

            try
            {

                if (!int.TryParse(textBox4.Text, out value))
                {
                    value = 1;
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

                            if (value != 0)
                            {
                                R = pixelP.R / value;
                                G = pixelP.G / value;
                                B = pixelP.B / value;
                                A = pixelP.A / value;
                            }
                                

                            img6.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img6;
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
    }
}
