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

namespace uyg_1
{
    public partial class sifredegistirme : Form
    {
        public sifredegistirme()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
        OleDbCommand komut;
        OleDbDataAdapter da;

        void olustur()
        {
            baglan.Open();
            da = new OleDbDataAdapter("Select * From Kütüphane", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglan.Close();
        
     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int yenisifre;
        int tekrarsifre;
        private void button1_Click(object sender, EventArgs e)
        {
            yenisifre = Convert.ToInt32(textBox2.Text);
            tekrarsifre = Convert.ToInt32(textBox3.Text);


           string sgln = ("Select * From klnc ");
           komut = new OleDbCommand(sgln, baglan);
           baglan.Open();
           OleDbDataReader okuyucu = komut.ExecuteReader();

           while (okuyucu.Read())
           {
               if (okuyucu.GetValue(1).ToString() == textBox1.Text && okuyucu.GetValue(2).ToString() == textBox2.Text)
               {
                   if (yenisifre == tekrarsifre)
                   {
                       string om = "UPTADE klnc set Sifre = '" + yenisifre + "' WHERE KullaniciAdi = '" + textBox1.Text + "'";
                       komut = new OleDbCommand(om, baglan);
                       komut.ExecuteNonQuery();

                   }

               }               

           }
           baglan.Close();
           Form1 arda = new Form1();
           arda.Show();
           this.Hide();

        
            
        }

        private void sifredegistirme_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
