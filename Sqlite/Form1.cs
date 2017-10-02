using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sqlite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
           
            if (IsValid())
            {


                SQLiteConnection conn = new SQLiteConnection("Data Source=test.db;Version=3;");


          string commandstring = "insert into Contacts([Name],[Email],[Mobile]) values(@name,@email,@mobile)";
                SQLiteCommand cmd = new SQLiteCommand(commandstring, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@name", nametextBox.Text);
                cmd.Parameters.AddWithValue("@email", emailtextBox.Text);
                cmd.Parameters.AddWithValue("@mobile", mobiletextBox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Save Data Successfully", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridViewMaDataDekhna();


                nametextBox.Clear();
                emailtextBox.Clear();
                mobiletextBox.Clear();
                nametextBox.Focus();
                
            }

        }

        private bool IsValid()
        {
            if (nametextBox.Text.Trim() == string.Empty)
            {

                int i;

                progressBar1.Minimum = 0;
                progressBar1.Maximum = 200;

                for (i = 0; i <= 200; i++)
                {
                    progressBar1.Value = i;
                }
                MessageBox.Show("Name text box is not fill", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextBox.Clear();
                nametextBox.Focus();
                return false;
            }
            if(emailtextBox.Text.Trim()== string.Empty)
            {
         
                MessageBox.Show("Email text box is not fill", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextBox.Focus();
                return false;
            }
            if (mobiletextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mobile text box is not fill", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mobiletextBox.Focus();
                return false;
            }
            return true;
        }






        private void IfDatabaseExists()
        {
            ///agr database ni ha to ye database bnayga khudi r table b\
            ///
            if(!File.Exists("test.db")){
                SQLiteConnection.CreateFile("test.db");

                //SQL bra likhna ha jsy SQLiteConnection likha ha asy likhna ha
                //agr database file ni ha to ye bnady ga r name ak jsa hona chaia uper r nechy





                SQLiteConnection conn = new SQLiteConnection("Data Source=test.db;Version=3;");
    string commandstring = "CREATE TABLE Contacts(Name NVARCHAR(50), Email NVARCHAR(50), Mobile NVARCHAR(50))";
                 SQLiteCommand cmd = new SQLiteCommand(commandstring, conn);

                conn.Open();

                cmd.ExecuteNonQuery();

            }
            else //agr database phly he mojod ha to ye kam ho
            {
                DataGridViewMaDataDekhna();
            }



        }

        private void DataGridViewMaDataDekhna()
        {
            dataGridView1.DataSource = GetData();
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            //class bna k database ko accesskrna ha
            SQLiteConnection conn = new SQLiteConnection("Data Source=test.db;Version=3;");


            string commandstring = " select * from Contacts";
            SQLiteCommand cmd = new SQLiteCommand(commandstring, conn);

            conn.Open();

            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);


            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IfDatabaseExists();
            
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //// MethodBandiaSbkyLye("Name", nametextBox);
            //DataTable dt = new DataTable();
            //DataView dv = dt.DefaultView;

            //dv.RowFilter = "[Name] Like '%" + nametextBox.Text + "%'";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=test.db;Version=3;");
                string command = "Update Contacts set [Email]=@email,[Mobile]=@mobile where [Name]=@name ";
                SQLiteCommand cmd = new SQLiteCommand(command, conn);

                conn.Open();
                cmd.Parameters.AddWithValue("@email", emailtextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@mobile", mobiletextBox.Text);
                cmd.Parameters.AddWithValue("@name", nametextBox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Data Successfully", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridViewMaDataDekhna();


                nametextBox.Clear();
                emailtextBox.Clear();
                mobiletextBox.Clear();
                nametextBox.Focus();
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please sure that you enter correct Name and Mobile \n Otherwise data will not deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (IsValid())
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=test.db;Version=3;");
                string command = "delete from Contacts where [Mobile]=@mobile and [Name]=@name ";
                SQLiteCommand cmd = new SQLiteCommand(command, conn);
               

                conn.Open();
                cmd.Parameters.AddWithValue("@email", emailtextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@mobile", mobiletextBox.Text);
                cmd.Parameters.AddWithValue("@name", nametextBox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Data Successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridViewMaDataDekhna();


                nametextBox.Clear();
                emailtextBox.Clear();
                mobiletextBox.Clear();
                nametextBox.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = pictureBox2.Visible == true ? false : true;
        }
    }
}
