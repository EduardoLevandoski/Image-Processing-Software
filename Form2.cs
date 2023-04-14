using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        Bitmap img1;
        Bitmap img2;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
                    img2 = new Bitmap(img1.Width * 2, img1.Height);
                    bLoadImgOK = true;

                    if (bLoadImgOK == true)
                    {
                        pictureBox2.Image = img1;
                        for (int j = 0; j < img1.Height; j++)
                        {
                            for (int i = 0; i < img1.Width; i++)
                            {
                                Color pixel = img1.GetPixel(i, j);
                                img2.SetPixel(i, j, pixel);
                            }
                        }

                        for (int j = 0; j < img1.Height; j++)
                        {
                            for (int i = 0; i < img1.Width; i++)
                            {

                                Color pixel = img1.GetPixel(img1.Width - i - 1, j);
                                img2.SetPixel(img1.Width + i, j, pixel);
                            }
                        }

                        pictureBox3.Image = img2;
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
    }
}
