using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap img1;
        Bitmap img2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            openFileDialog2.InitialDirectory = "C:\\Matlab";
            openFileDialog2.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog2.FileName;


                bool bLoadImgOK = false;
                try
                {
                    img2 = new Bitmap(filePath);
                    bLoadImgOK = true;

                    if (bLoadImgOK == true)
                    {
                        pictureBox2.Image = img2;
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
            try
            {

                if (img1 != null && img2 != null)
                {
                    Bitmap img3 = new Bitmap(img1.Height, img1.Width);


                    for (int i = 0; i < img3.Width; i++)
                    {
                        for (int j = 0; j < img3.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = pixelP.R + pixelQ.R;
                            int G = pixelP.G + pixelQ.G;
                            int B = pixelP.B + pixelQ.B;
                            int A = pixelP.A + pixelQ.A;

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
                MessageBox.Show("Não foi possivel adicionar as imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (img1 != null && img2 != null)
                {
                    Bitmap img4 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img4.Width; i++)
                    {
                        for (int j = 0; j < img4.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = Math.Max(0, pixelP.R - pixelQ.R);
                            int G = Math.Max(0, pixelP.G - pixelQ.G);
                            int B = Math.Max(0, pixelP.B - pixelQ.B);
                            int A = Math.Max(0, pixelP.A - pixelQ.A);

                            img4.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img4;
                        }
                    }
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel subtrair as imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img5 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img5.Width; i++)
                    {
                        for (int j = 0; j < img5.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = pixelP.R * pixelQ.R / 255;
                            int G = pixelP.G * pixelQ.G / 255;
                            int B = pixelP.B * pixelQ.B / 255;
                            int A = pixelP.A * pixelQ.A / 255;

                            img5.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img5;
                        }
                    }
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel multiplicar as imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img6 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img6.Width; i++)
                    {
                        for (int j = 0; j < img6.Height; j++)
                        {
                            int R = 0, G = 0, B = 0, A = 0;
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);


                            if (pixelQ.R != 0)
                                R = pixelP.R / pixelQ.R;
                            if (pixelQ.G != 0)
                                G = pixelP.G / pixelQ.G;
                            if (pixelQ.B != 0)
                                B = pixelP.B / pixelQ.B;
                            if (pixelQ.A != 0)
                                A = pixelP.A / pixelQ.A;

                            img6.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img6;
                        }
                    }
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel dividir as imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img7 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img7.Width; i++)
                    {
                        for (int j = 0; j < img7.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = (pixelP.R + pixelQ.R) / 2;
                            int G = (pixelP.G + pixelQ.G) / 2;
                            int B = (pixelP.B + pixelQ.B) / 2;
                            int A = (pixelP.A + pixelQ.A) / 2;

                            img7.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img7;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel achar a média as imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double blendValue;

            try
            {

                if (!double.TryParse(textBox1.Text, out blendValue))
                {
                    blendValue = 0.5f;
                }

                if (img1 != null && img2 != null)
                {
                    Bitmap img8 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img8.Width; i++)
                    {
                        for (int j = 0; j < img8.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = (int)((pixelP.R * blendValue) + ((1 - blendValue) * pixelQ.R));
                            int G = (int)((pixelP.G * blendValue) + ((1 - blendValue) * pixelQ.G));
                            int B = (int)((pixelP.B * blendValue) + ((1 - blendValue) * pixelQ.B));
                            int A = (int)((pixelP.A * blendValue) + ((1 - blendValue) * pixelQ.A));

                            img8.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img8;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel fazer o blending das imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (img1 != null && img2 != null)
                {
                    Bitmap img8 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img8.Width; i++)
                    {
                        for (int j = 0; j < img8.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = pixelP.R & pixelQ.R;
                            int G = pixelP.G & pixelQ.G;
                            int B = pixelP.B & pixelQ.B;
                            int A = pixelP.A & pixelQ.A;

                            img8.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img8;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel fazer o AND das imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img9 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img9.Width; i++)
                    {
                        for (int j = 0; j < img9.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = pixelP.R | pixelQ.R;
                            int G = pixelP.G | pixelQ.G;
                            int B = pixelP.B | pixelQ.B;
                            int A = pixelP.A | pixelQ.A;

                            img9.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img9;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel fazer o OR das imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img9 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img9.Width; i++)
                    {
                        for (int j = 0; j < img9.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = pixelP.R ^ pixelQ.R;
                            int G = pixelP.G ^ pixelQ.G;
                            int B = pixelP.B ^ pixelQ.B;
                            int A = pixelP.A ^ pixelQ.A;

                            img9.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img9;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel fazer o XOR das imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (img1 != null && img2 != null)
                {
                    Bitmap img9 = new Bitmap(img1.Height, img1.Width);

                    for (int i = 0; i < img9.Width; i++)
                    {
                        for (int j = 0; j < img9.Height; j++)
                        {
                            Color pixelP = img1.GetPixel(i, j);
                            Color pixelQ = img2.GetPixel(i, j);

                            int R = ~(~pixelP.R & ~pixelQ.R);
                            int G = ~(~pixelP.B & ~pixelQ.B);
                            int B = ~(~pixelP.G & ~pixelQ.G);

                            img9.SetPixel(i, j, Color.FromArgb(R, G, B));
                            pictureBox3.Image = img9;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não foi possivel fazer o NOT das imagens", "As imagens devem ser do mesmo tamanho...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void espelhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
