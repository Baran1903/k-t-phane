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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLeDB.4.0;Data Source=Kütüphane.mdb;");
        OleDbCommand komut;
        OleDbDataAdapter da;
        


        void göster()
        {
            baglanti.Open();

            da = new OleDbDataAdapter("Select * From Öğrenciler", baglanti);
            DataTable arabalar = new DataTable();

            da.Fill(arabalar);
            dataGridView1.DataSource = arabalar;
            baglanti.Close();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Öğrenciler (AdıSoyadı , Sınıfı , OkulNo ) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            göster();

            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            göster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Öğrenciler SET Sınıfı = '" + textBox2.Text + "', OkulNo = '" + textBox3.Text + "' WHERE AdıSoyadı = '" + textBox1.Text + "'";

            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            göster();
        }
    }
}
