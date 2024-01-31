using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    //static olusturunca yeniden nesne olusturmaya gerek kalmıyor
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * from TBL_BILGI", Baglanti.bgl); //static tanımlamasaydık baglantı adında nesne olusturmaya gerek kalmadı
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = (dr["AD"].ToString());
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas = int.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_BILGI (AD,SOYAD,SEHIR,GOREV,MAAS) values (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Ad);
            komut2.Parameters.AddWithValue("@P2", p.Soyad);
            komut2.Parameters.AddWithValue("@P3", p.Sehir);
            komut2.Parameters.AddWithValue("@P4", p.Gorev);
            komut2.Parameters.AddWithValue("@P5", p.Maas);
            return komut2.ExecuteNonQuery();
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("delete from TBL_BILGI where ID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0; //yani bool 1 ise yukardaki kodları dondur

        }

        public static bool PersonelGuncelle(EntityPersonel p)
        {
            SqlCommand komut4 = new SqlCommand("update TBL_BILGI set AD=@P2,SOYAD=@P3,SEHIR=@P4,GOREV=@P5,MAAS=@P6 where ID=@P1", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P2", p.Ad);
            komut4.Parameters.AddWithValue("@P3", p.Soyad);
            komut4.Parameters.AddWithValue("@P4", p.Sehir);
            komut4.Parameters.AddWithValue("@P5", p.Gorev);
            komut4.Parameters.AddWithValue("@P6", p.Maas);
            komut4.Parameters.AddWithValue("@P1", p.Id);
            return komut4.ExecuteNonQuery() > 0; //bool true ise
        }
    }
}
