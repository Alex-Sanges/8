﻿using System;
using Microsoft.Win32;
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
    public partial class Form2 : Form
    {
        public ColorDialog clr = new ColorDialog();
        //Color color = Color.Red;
       public Color color;
        public ColorDialog clr2 = new ColorDialog();
       // public Color lor;
        //Color color2 = Color.Red;
        public Color color2;
        public int clock=1000;
        public bool left;
        public bool up;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 Glavnuk = (Form1)this.Owner;
            color = Color.FromArgb(Properties.Settings.Default.r, Properties.Settings.Default.g, Properties.Settings.Default.b);
            // color=Glavnuk.color1;
            color2 = Color.FromArgb(Properties.Settings.Default.r2, Properties.Settings.Default.g2, Properties.Settings.Default.b2);
            hScrollBar1.Value = Properties.Settings.Default.clock;
            label3.BackColor = color2;
            label1.BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSet(color,color2,clock);
            // Form Glavnuk = Application.OpenForms[0];
            Form1 Glavnuk = (Form1)this.Owner;
            Glavnuk.Top = this.Top;
           // Glavnuk.StartPosition = FormStartPosition.Manual;
            Glavnuk.Show();
            Glavnuk.clock2= clock;
            Glavnuk.color1 = color;
            Glavnuk.color2 = color2;
            left = radioButton1.Checked;
            up = radioButton2.Checked;
            //Glavnuk.right = left;
            //Glavnuk.down = up;
            Glavnuk.xpenb(left,up);
            this.Hide();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //Form1.
            //Timer1.
               clock = hScrollBar1.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (clr.ShowDialog()==DialogResult.OK)
            {
                color = clr.Color;
                label1.BackColor = clr.Color;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (clr2.ShowDialog() == DialogResult.OK)
            {
                color2 = clr2.Color;
                label3.BackColor = clr2.Color;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
        public void SaveSet(Color clr,Color clr2,int clock)
        {
            //Save color
            int r = clr.R;
            int g = clr.G;
            int b = clr.B;
            int r2 = clr2.R;
            int g2 = clr2.G;
            int b2 = clr2.B;
            //save this in C:\\Users...
            Properties.Settings.Default.r = r;
            Properties.Settings.Default.g = g;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.r2 = r2;
            Properties.Settings.Default.g2= g2;
            Properties.Settings.Default.b2 = b2;
            Properties.Settings.Default.clock =clock;
            Properties.Settings.Default.Save();
            /* RegistryKey currentUserKey = Registry.CurrentUser;
             RegistryKey Key = currentUserKey.CreateSubKey("Key");
             //Save color
             int r = clr.R;
             int g = clr.G;
             int b = clr.B;
             int r2 = clr2.R;
             int g2 = clr2.G;
             int b2 = clr2.B;
             //Key.SetValue("tr", tr);
             //Save in pc
             Key.SetValue("r", r);
             Key.SetValue("g", g);
             Key.SetValue("b", b);
             Key.SetValue("r2", r2);
             Key.SetValue("g2", g2);
             Key.SetValue("b2", b2);
             Key.Close();*/
        }
    }
}