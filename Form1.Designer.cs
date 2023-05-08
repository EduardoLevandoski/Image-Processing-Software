
namespace WinFormsApp1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.umaImagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duasImagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.espelhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umaImagemToolStripMenuItem,
            this.duasImagensToolStripMenuItem,
            this.espelhoToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1461, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // umaImagemToolStripMenuItem
            // 
            this.umaImagemToolStripMenuItem.Name = "umaImagemToolStripMenuItem";
            this.umaImagemToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.umaImagemToolStripMenuItem.Text = "Uma Imagem";
            this.umaImagemToolStripMenuItem.Click += new System.EventHandler(this.umaImagemToolStripMenuItem_Click);
            // 
            // duasImagensToolStripMenuItem
            // 
            this.duasImagensToolStripMenuItem.Name = "duasImagensToolStripMenuItem";
            this.duasImagensToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.duasImagensToolStripMenuItem.Text = "Duas Imagens";
            this.duasImagensToolStripMenuItem.Click += new System.EventHandler(this.duasImagensToolStripMenuItem_Click);
            // 
            // espelhoToolStripMenuItem1
            // 
            this.espelhoToolStripMenuItem1.Name = "espelhoToolStripMenuItem1";
            this.espelhoToolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.espelhoToolStripMenuItem1.Text = "Espelho";
            this.espelhoToolStripMenuItem1.Click += new System.EventHandler(this.espelhoToolStripMenuItem1_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(752, 197);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(51, 23);
            this.textBox5.TabIndex = 27;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(671, 197);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 26;
            this.button7.Text = "Blending";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(671, 161);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "Divisão";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(671, 123);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "Multiplicação";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(671, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Subtração";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(671, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Adição";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(51, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 613);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 51);
            this.button1.TabIndex = 28;
            this.button1.Text = "Carregar Imagem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(868, 46);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(512, 512);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1011, 613);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 51);
            this.button2.TabIndex = 30;
            this.button2.Text = "Salvar Imagem";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(752, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 23);
            this.textBox1.TabIndex = 32;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(752, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 23);
            this.textBox2.TabIndex = 33;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(752, 124);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(51, 23);
            this.textBox3.TabIndex = 34;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(752, 162);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(51, 23);
            this.textBox4.TabIndex = 35;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(671, 239);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(115, 64);
            this.button8.TabIndex = 36;
            this.button8.Text = "Converter para Binária";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(671, 319);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(115, 64);
            this.button9.TabIndex = 37;
            this.button9.Text = "Converter para Escala de Cinza";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(671, 401);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(115, 25);
            this.button10.TabIndex = 38;
            this.button10.Text = "Negativo";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(671, 468);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(115, 23);
            this.button11.TabIndex = 39;
            this.button11.Text = "Máximo";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(671, 497);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(115, 23);
            this.button12.TabIndex = 40;
            this.button12.Text = "Mínimo";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(671, 526);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(115, 23);
            this.button13.TabIndex = 41;
            this.button13.Text = "Média";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(51, 695);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 277);
            this.panel1.TabIndex = 42;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(653, 751);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(150, 59);
            this.button14.TabIndex = 43;
            this.button14.Text = "Equalização do Histograma";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(853, 695);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 277);
            this.panel2.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 1068);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem umaImagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duasImagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem espelhoToolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Panel panel2;
    }
}