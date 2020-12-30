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
    public partial class ModelİkinciElİlan : Form
    {
        public ModelİkinciElİlan()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=CarDealer; user ID=postgres; password=1234");

        private void silBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM musteri WHERE modelId = @p1", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(modelIdTxt.Text));
            NpgsqlCommand command2 = new NpgsqlCommand("DELETE FROM musteri WHERE ilanId = @p2", connect);
            command1.Parameters.AddWithValue("@p2", int.Parse(ilanId.Text));
            NpgsqlCommand command3 = new NpgsqlCommand("DELETE FROM musteri WHERE aracId = @p3", connect);
            command1.Parameters.AddWithValue("@p3", int.Parse(aracIdTxt.Text));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void ModelİkinciElİlan_Load(object sender, EventArgs e)
        {

        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE model set modelAd = @p2, versiyon = @p3, kasaTipi = @4, vites = @p5 where modelId = @p1 ", connect);
            NpgsqlCommand command1 = new NpgsqlCommand("UPDATE ilan set ilanTarihi = @p2, kategoriId = @p3 where ilanId = @p1", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE ikinciEl set  yakitTipi= @p2, satisId = @p3, renk = @p4, saseNo = @p5, plaka = @p6, km = @p7, modelId = @p8, yil = @p9, marka = @10, fiyat = @11, resim = @p13, kategoriId =@p12 where aracId = @p1", connect);
            command1.Parameters.AddWithValue("@p1", ilanId.Text);
            command1.Parameters.AddWithValue("@p2", ilanTarihiTxt.Text);
            command1.Parameters.AddWithValue("@p3", kategoriIdTxt.Text); /////
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p3", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p1", aracIdTxt.Text);
            command2.Parameters.AddWithValue("@p4", renkTxt.Text);
            command2.Parameters.AddWithValue("@p5", saseNoTxt.Text);
            command2.Parameters.AddWithValue("@p6", plakaTxt.Text);
            command2.Parameters.AddWithValue("@p7", kmTxt.Text);
            command2.Parameters.AddWithValue("@p8", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p9", yilTxt.Text);
            command2.Parameters.AddWithValue("@p10", markaTxt.Text);
            command2.Parameters.AddWithValue("@p11", fiyatTxt.Text);
            command2.Parameters.AddWithValue("@p12", kategoriIdTxt.Text);
            command2.Parameters.AddWithValue("@p13", resimTxt.Text);
            command3.Parameters.AddWithValue("@p1", modelIdTxt.Text);
            command3.Parameters.AddWithValue("@p2", versiyonTxt.Text);
            command3.Parameters.AddWithValue("@p3", versiyonTxt.Text);
            command3.Parameters.AddWithValue("@p4", kasaTipiTxt.Text);
            command3.Parameters.AddWithValue("@p5", vitesTxt.Text);
            command1.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connect.Close();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select * from \"ModelIkinciElIlan\"", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void versiyonTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void kasaTipiTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void renkTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO ilan(ilanId, ilanTarihi, kategoriId)  VALUES(@p1, @p2, @p3)");
            NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO model(modelId, versiyon, modelAd, kasaTipi, vites) VALUES(@p1,@p2 @p3, @p4, @p4, @p5)", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO sifir(aracId, yakitTipi, satisId, kategoriId, renk, modelId, yil, marka, fiyat, resim) VALUES(@p1, @p2, @p3, @p4, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", connect);
            command1.Parameters.AddWithValue("@p1", modelIdTxt.Text);
            command1.Parameters.AddWithValue("@p2", versiyonTxt.Text);
            command1.Parameters.AddWithValue("@p3", modelAdTxt.Text);
            command1.Parameters.AddWithValue("@p4", kasaTipiTxt.Text);
            command1.Parameters.AddWithValue("@p5", vitesTxt.Text);
            command2.Parameters.AddWithValue("@p1", aracIdTxt.Text);
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p3", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p4", kategoriIdTxt.Text);
            command2.Parameters.AddWithValue("@p5", renkTxt.Text);
            command2.Parameters.AddWithValue("@p6", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p7", yilTxt.Text);
            command2.Parameters.AddWithValue("@p8", markaTxt.Text);
            command2.Parameters.AddWithValue("@p9", fiyatTxt.Text);
            command2.Parameters.AddWithValue("@p10", resimBtn); ////////!!!!!!!!!!!!!!!!!!!!!
            command3.Parameters.AddWithValue("@p1", ilanId.Text);
            command3.Parameters.AddWithValue("@p2", ilanTarihiTxt.Text);
            command3.Parameters.AddWithValue("@p3", kategoriIdTxt.Text);
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void ilanTarihiTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void resim_Click(object sender, EventArgs e)
        {

        }
            private void resimBtn_Click(object sender, EventArgs e)
        {
                openFileDialog1.ShowDialog();
                resimPB.ImageLocation = openFileDialog1.FileName;
                resimTxt.Text = openFileDialog1.FileName;
            }
    }

    }
