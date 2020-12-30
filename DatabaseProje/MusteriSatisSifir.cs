using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;


namespace DatabaseProje
{
    public partial class MusteriSatisSifir : Form
    {
        public MusteriSatisSifir()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=CarDealer; user ID=postgres; password=1234");

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM musteri WHERE musteriId = @p1", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(kullaniciIdTxt.Text));
            NpgsqlCommand command2 = new NpgsqlCommand("DELETE FROM musteri WHERE satisId = @p2", connect);
            command1.Parameters.AddWithValue("@p2", int.Parse(satisIdTxt.Text));
            NpgsqlCommand command3 = new NpgsqlCommand("DELETE FROM musteri WHERE aracId = @p3", connect);
            command1.Parameters.AddWithValue("@p3", int.Parse(aracIdTxt.Text));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select * from \"MusteriSatisSifirView\"", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO musteri(kullaniciId, name, lastname, username, password, infoId) VALUES(@p1, @p2, @p3, @p4, @p5, @p6", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO sifir(aracId, yakitTipi, satisId, kategoriId, renk, modelId, yil, marka, fiyat, resim) VALUES(@p1, @p2, @p3, @p4, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", connect);
            NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO satis(odemeTarih, kdv, indirim, alisFiyati, satisFiyati) VALUES(@p1, @p2, @p3, @p4, @p5");
            command3.Parameters.AddWithValue("@p1", kullaniciIdTxt.Text);
            command3.Parameters.AddWithValue("@p2", isim.Text);
            command3.Parameters.AddWithValue("@p3", soyisimTxt.Text);
            command3.Parameters.AddWithValue("@p4", username.Text);
            command3.Parameters.AddWithValue("@p5", passwordTxt.Text);
            command3.Parameters.AddWithValue("@p6", infoIdTxt.Text);    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            command2.Parameters.AddWithValue("@p1", aracIdTxt.Text);
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p3", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p4", kategoriIdTxt.Text);
            command2.Parameters.AddWithValue("@p5", renkTxt.Text);
            command2.Parameters.AddWithValue("@p6", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p7", yilTxt.Text);
            command2.Parameters.AddWithValue("@p8", markaTxt.Text);
            command2.Parameters.AddWithValue("@p9", fiyatTxt.Text);
           // command2.Parameters.AddWithValue("@p10", resimBtn); ////////!!!!!!!!!!!!!!!!!!
            command1.Parameters.AddWithValue("@p1", infoIdTxt.Text);
            command1.Parameters.AddWithValue("@p2", kdvTxt.Text);
            command1.Parameters.AddWithValue("@p3", indirimTxt.Text);
            command1.Parameters.AddWithValue("@p4", satisFiyatTxt.Text); //////////////ALİS FİYAT
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE satis set odemeTarih = @p2, kdv = @p3, indirim = @p4, satisFiyat = @p5 where satisId=@p1", connect);
            NpgsqlCommand command1 = new NpgsqlCommand("UPDATE musteri set name = @p2, lastname = @3, username = @p4, password = @p5, satisId = @p6 where kullaniciId = @p1", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE sifir set  yakitTipi= @p2, renk = @p3, saseNo = @p4, modelId = @p5, yil = @p6, marka = @7, fiyat = @8, resim = @p9, kategoriId =@p10 where aracId = @p1", connect);
            command3.Parameters.AddWithValue("@p1", satisIdTxt.Text);
            command3.Parameters.AddWithValue("@p2", infoIdTxt.Text);
            command3.Parameters.AddWithValue("@p3", kdvTxt.Text);
            command3.Parameters.AddWithValue("@p4", indirimTxt.Text);
            command3.Parameters.AddWithValue("@p5", satisIdTxt.Text);
            command1.Parameters.AddWithValue("@p2", isim.Text);
            command1.Parameters.AddWithValue("@p3", soyisimTxt.Text);
            command1.Parameters.AddWithValue("@p4", username.Text);
            command1.Parameters.AddWithValue("@p5", passwordTxt.Text);
            command1.Parameters.AddWithValue("@p6", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p1", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p3", renkTxt.Text);
            command2.Parameters.AddWithValue("@p4", saseNoTxt.Text);
            command2.Parameters.AddWithValue("@p5", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p6", yilTxt.Text);
            command2.Parameters.AddWithValue("@p7", markaTxt.Text);
            command2.Parameters.AddWithValue("@p8", fiyatTxt.Text);
            command2.Parameters.AddWithValue("@p9", kategoriIdTxt.Text);
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command1.ExecuteNonQuery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
