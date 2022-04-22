using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomisSamochodowy
{
    public partial class JazdyProbne : Form
    {
        public Form1 win { get; set; }

        public JazdyProbne(Form1 win)
        {
            InitializeComponent();

            this.win = win;

            Read();
        }

        public void Read()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = win.jazdy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UmowJazde uw = new UmowJazde(this);
            this.Enabled = false;
            uw.Show();

        }

        private void JazdyProbne_FormClosed(object sender, FormClosedEventArgs e)
        {
            win.Enabled = true;
        }
    }
}
