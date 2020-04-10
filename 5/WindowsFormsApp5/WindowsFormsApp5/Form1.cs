﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Color color1 = Color.Red;
        public Color color2 = Color.Red;
        public bool right = true;
        public bool down = false;
        public int clock2 = 100;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        int sec = 0;
        int w = 80, h = 80;
        int x = 1, y = 100;
        int dx = 5;
        enum STATUS { Left, Right, Up, Down };  //направления движения
        STATUS flag;		//флаг изменения направления движения
        //
        SolidBrush brush = new SolidBrush(Color.FromArgb(Properties.Settings.Default.r, Properties.Settings.Default.g, Properties.Settings.Default.b)); // кисть
        Rectangle rc; //прямоугольная область, в которой находиться фигура
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = clock2;
            sec++;  // секунды
            rc = new Rectangle(x, y, w, h); // размер прямоугольной области
            this.Invalidate(rc, true);      // вызываем прорисовку области
            if (flag == STATUS.Left) // движение влево
            {
                x -= dx;
            }
            if (flag == STATUS.Right)// движение вправо
            {
                x += dx;
            }
            //можно попробовать с помощью буллов, завтра этим займусь
            if (flag == STATUS.Up)
            {
                y -= dx;
            }
            if (flag == STATUS.Down)
            {
                y += dx;
            }
            //
            if (x >= (this.ClientSize.Width - w)) // если достигли правого края формы
            {
                flag = STATUS.Left; // меняем статус движения на левый
                                    // SolidBrush brush = new SolidBrush(color1);
            }
            else
            if ((x <= 1)) // если достигли левого края формы
            {
                flag = STATUS.Right;    // меняем статус движения на правый
                                        // SolidBrush brush = new SolidBrush(color2);
            }
            //
            if (y >= (this.ClientSize.Height - w)) // если достигли края формы
            {
                flag = STATUS.Up; // меняем статус движения
                h++;
                w++;
            }
            else if (y <= 1) // если достигли края формы
            {
                flag = STATUS.Down;    // меняем статус движения 
                h++;
                w++;
            }

            //
            rc = new Rectangle(x, y, w, h); // новая прямоугольная область
            this.Invalidate(rc, true);  // вызываем прорисовку этой области

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (right)
            {
                if (flag == STATUS.Right)
                    flag = STATUS.Left;
                else
                    flag = STATUS.Right;
            }
            if (down)
            {
                if (flag == STATUS.Up)
                    flag = STATUS.Down;
                else
                    flag = STATUS.Up;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //
            if (flag == STATUS.Right || flag == STATUS.Down)
            {
                brush.Color = color2;
            }
            if (flag == STATUS.Left || flag == STATUS.Up)
            {
                brush.Color = color1;
            }
            e.Graphics.FillEllipse(brush, rc);  // рисуем закрашенный эллипс
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form setting = new Form2();
            setting.Owner = this;
            setting.Top = this.Top;
            setting.ShowDialog();
            //setting.color = color1;
            //setting.color2 = color2;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //timer1.Interval = clock2;// hScrollBar1.Value;
        }

        public int MySpeed
        {
            get
            {
                return 100 - timer1.Interval;
            }
            set
            {
                timer1.Interval = 100 - value;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Form1 form = new Form1();
            if (e.KeyCode == Keys.Escape)
            {
                //form.Show();
                form.Close();
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {

        }

        private void Form1_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (right)
            {
                if (flag == STATUS.Right)
                    flag = STATUS.Left;
                else
                    flag = STATUS.Right;
            }
            if (down)
            {
                if (flag == STATUS.Up)
                    flag = STATUS.Down;
                else
                    flag = STATUS.Up;
            }
        }

        public Color MyColor
        {
            get
            {
                return brush.Color;
            }
            set
            {
                brush.Color = value;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            /* Form1 form = new Form1();
             if (e.KeyCode == Keys.Escape)
             {
                 //form.Show();
                 form.Close();
             }*/
        }
        public void xpenb(bool right, bool down)
        {
            if (right)
            {
                if (flag == STATUS.Right)
                    flag = STATUS.Left;
                else
                    flag = STATUS.Right;
            }
            if (down)
            {
                if (flag == STATUS.Up)
                    flag = STATUS.Down;
                else
                    flag = STATUS.Up;
            }
        }
    }

}
