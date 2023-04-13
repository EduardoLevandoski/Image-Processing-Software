using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap img1;
            byte[,] vImg1Gray;
            byte[,] vImg1R;
            byte[,] vImg1G;
            byte[,] vImg1B;
            byte[,] vImg1A;


            // Configurações iniciais da OpenFileDialogBox
            var filePath = string.Empty;
            openFileDialog1.InitialDirectory = "C:\\Matlab";
            openFileDialog1.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // Se um arquivo foi localizado com sucesso...
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Armnazena o path do arquivo de imagem
                filePath = openFileDialog1.FileName;


                bool bLoadImgOK = false;
                try
                {
                    img1 = new Bitmap(filePath);
                    bLoadImgOK = true;

                    // Se a imagem carregou perfeitamente...
                    if (bLoadImgOK == true)
                    {
                        // Adiciona imagem na PictureBox
                        pictureBox1.Image = img1;
                        vImg1Gray = new byte[img1.Width, img1.Height];
                        vImg1R = new byte[img1.Width, img1.Height];
                        vImg1G = new byte[img1.Width, img1.Height];
                        vImg1B = new byte[img1.Width, img1.Height];
                        vImg1A = new byte[img1.Width, img1.Height];

                        // Percorre todos os pixels da imagem...
                        for (int i = 0; i < img1.Width; i++)
                        {
                            for (int j = 0; j < img1.Height; j++)
                            {
                                Color pixel = img1.GetPixel(i, j);

                                // Para imagens em escala de cinza, extrair o valor do pixel com...
                                //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);
                                byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);
                                vImg1Gray[i, j] = pixelIntensity;

                                // Para imagens RGB, extrair o valor do pixel com...
                                byte R = pixel.R;
                                byte G = pixel.G;
                                byte B = pixel.B;
                                byte A = pixel.A;

                                vImg1R[i, j] = R;
                                vImg1G[i, j] = G;
                                vImg1B[i, j] = B;
                                vImg1A[i, j] = A;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bLoadImgOK = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap img2;
            byte[,] vImg1Gray;
            byte[,] vImg1R;
            byte[,] vImg1G;
            byte[,] vImg1B;
            byte[,] vImg1A;


            // Configurações iniciais da OpenFileDialogBox
            var filePath = string.Empty;
            openFileDialog2.InitialDirectory = "C:\\Matlab";
            openFileDialog2.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            // Se um arquivo foi localizado com sucesso...
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // Armnazena o path do arquivo de imagem
                filePath = openFileDialog2.FileName;


                bool bLoadImgOK = false;
                try
                {
                    img2 = new Bitmap(filePath);
                    bLoadImgOK = true;

                    // Se a imagem carregou perfeitamente...
                    if (bLoadImgOK == true)
                    {
                        // Adiciona imagem na PictureBox
                        pictureBox2.Image = img2;
                        vImg1Gray = new byte[img2.Width, img2.Height];
                        vImg1R = new byte[img2.Width, img2.Height];
                        vImg1G = new byte[img2.Width, img2.Height];
                        vImg1B = new byte[img2.Width, img2.Height];
                        vImg1A = new byte[img2.Width, img2.Height];

                        // Percorre todos os pixels da imagem...
                        for (int i = 0; i < img2.Width; i++)
                        {
                            for (int j = 0; j < img2.Height; j++)
                            {
                                Color pixel = img2.GetPixel(i, j);

                                // Para imagens em escala de cinza, extrair o valor do pixel com...
                                //byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);
                                byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);
                                vImg1Gray[i, j] = pixelIntensity;

                                // Para imagens RGB, extrair o valor do pixel com...
                                byte R = pixel.R;
                                byte G = pixel.G;
                                byte B = pixel.B;
                                byte A = pixel.A;

                                vImg1R[i, j] = R;
                                vImg1G[i, j] = G;
                                vImg1B[i, j] = B;
                                vImg1A[i, j] = A;

                            }
                        }
                    }
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
