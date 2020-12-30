using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProje
{
    public partial class CarDealer : Form
    {
        public CarDealer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SifirModel s = new SifirModel();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            model m = new model();
            m.Show();
        }
    }
}
