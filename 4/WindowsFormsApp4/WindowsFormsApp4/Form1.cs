using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public bool enemy1= false;
        public bool enemy2=false;
        public bool enemy3=false;
        public bool enemy4=false;
        public DateTime n;
        public DateTime d;
        public double popitki;
        public string otvet;
        public string[] a;
        public string slovo;
        public double schet; // kol-vo ochkov
        //public double ochki=0;
        public int errors;
        public int i;
        //a=new string[]={};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            d = n.AddMinutes(2);
            label5.Visible = true;
            label5.Text ="Осталось"+2;
            a = new string[] { "жираф", "лев", "собака", "попугай" };
            button1.Visible = false;
            //pictureBox1.Visible = false;
            label1.Visible = false;
            textBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            Random ra = new Random();
           // int i;
            i = ra.Next(0, 3);
           // MessageBox.Show("i=" + i);
            if (i==0)
            {
                pictureBox1.Visible = true;
            }
            if (i == 1)
            {
                pictureBox2.Visible = true;
            }
            if (i == 2)
            {
                pictureBox3.Visible = true;
            }
            if (i == 3)
            {
                pictureBox4.Visible = true;
            }
            otvet = a[i];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("D:\\1mages\\1.1.jpg");//жираф
            pictureBox2.Image = Image.FromFile("D:\\1mages\\1.2.jpg");//лев
            pictureBox3.Image = Image.FromFile("D:\\1mages\\1.3.jpg");//собака
            pictureBox4.Image = Image.FromFile("D:\\1mages\\1.4.jpg");//попугай
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if()
            //MessageBox.Show("Сигнал с текстбокса"+textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           // MessageBox.Show("Сигнал с текстбокса " + textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("Сигнал с текстбокса " + textBox1.Text);
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Random r = new Random();
            if (e.KeyChar == (char)Keys.Enter)
            {
                    slovo = textBox1.Text;
                popitki+=1;
                if (slovo==otvet)
                {
                    if (popitki!=0)
                    {
                        //MessageBox.Show("i=" + i);
                        if (i==0)
                        { enemy1 = true; }
                        if (i == 1)
                        { enemy2 = true; }
                        if (i == 2)
                        { enemy3 = true; }
                        if (i == 3)
                        { enemy4 = true; }
                        else {// MessageBox.Show("Ошибка 27");
                           // MessageBox.Show(enemy1+""+enemy2+""+enemy3+enemy4);
                        }
                    }
                    // MessageBox.Show("Сигнал с текстбокса " + textBox1.Text);
                    MessageBox.Show("Правильно");
                    Random ra = new Random();
                   // int i;
                    i = ra.Next(0, 4);
                    schet += 1;
                   // MessageBox.Show("i=" + i);
                    if (i == 0)
                    {
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = false;
                    }
                    if (i == 1)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = false;
                    }
                    if (i == 2)
                    {
                        pictureBox3.Visible = true;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox4.Visible = false;
                    }
                    if (i >= 3)
                    {
                        pictureBox4.Visible = true;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        pictureBox1.Visible = false;
                    }
                    otvet = a[i];

                }
                else
                {
                    MessageBox.Show("Неправильно, попробуй ещё раз");
                    errors++;
                }
                   
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text="Осталось"+(d-n);
            label7.Text = d.ToLongTimeString()+" "+schet;
            label6.Text = n.ToLongTimeString()+" "+popitki;
            n = DateTime.Now;
            if(n.Second==d.Second && n.Minute==d.Minute)
            {
                double procent;
                // был равен бесконечности
                if (enemy1 && enemy2 && enemy3 && enemy4)
                { procent = ((schet * 100) / popitki); }
                else
                { procent = schet * 25; }//*100/4=*25
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                textBox1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label4.Visible = true;
                label4.Text="Тобою отгаданно "+schet+" Ты ошибся "+errors+
                    "правильных ответов"+procent+"%";
                button1.Visible = true;
                button1.Text = "ещё раз";
            }

        }
    }
}
