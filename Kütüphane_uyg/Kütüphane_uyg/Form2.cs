using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Kütüphane_uyg
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection bağlanti = new OleDbConnection("Provider=Microsoft.Jet.OLeDB.4.0;Data Source=Kütüphane.mdb;");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM kullanici";
            OleDbCommand komut = new OleDbCommand(sql, bağlanti);
            bağlanti.Open();
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            if (oku.GetValue(0).ToString() == textBox1.Text && oku.GetValue(1).ToString() == textBox2.Text)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
                
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya parola yanlış");
            }
            bağlanti.Close();
        }
    }
}
