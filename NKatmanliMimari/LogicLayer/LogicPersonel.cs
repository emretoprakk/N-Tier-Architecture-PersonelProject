using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntityPersonel p)
        {
            if (p.Ad != "" && p.Soyad != "" && p.Maas >= 17000 && p.Ad.Length >= 3) //nulldan farklıysa ve isim 3 ve 3'ten fazlaysa
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }
        }
        public static bool LLPersonelSil(int p)
        {
            if (p >= 1)
            {
                return DALPersonel.PersonelSil(p);
            }
            else
            {
                return false;
            }
        }
        public static bool LLPersonelGuncelle(EntityPersonel p)
        {
            if(p.Ad.Length>=3 && p.Ad!="" && p.Maas >= 20000)
            {
                return DALPersonel.PersonelGuncelle(p);
            }
            else
            {
                return false;
            }
        }
    }
}
