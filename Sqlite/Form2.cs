using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sqlite
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox3.Visible = false;
            pictureBox2.Visible = false;
            // ye olta chlana ha
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // agr ak ha visible ha braket ma whe false r agla true 

            if (pictureBox1.Visible == true) // equal ki ye ilamat lgani ha == 
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if(pictureBox2.Visible== true) // else k sath krna ha yad sy
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if(pictureBox3.Visible== true)
            {
                pictureBox3.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
