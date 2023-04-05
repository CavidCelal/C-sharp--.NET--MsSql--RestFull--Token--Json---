using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYS.Application.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace PYS.Application.Business
{
    public class BaseKullaniciIslemleri
    {
        private DbPYSEntities Db;

        public BaseKullaniciIslemleri()
        {
            Db = new DbPYSEntities();
        }

        internal bool DoLogin(string KullaniciBilgisi, string Sifre, string SecretKey, out VwKisiKullaniciIletisim KullaniciKisi, out string Mesaj)
        {
            bool result = false;
            KullaniciKisi = null;
            Mesaj = "";
            try
            {
                var KisiKaydi = (from data in Db.VwKisiKullaniciIletisim
                                 where (data.Iletisim == KullaniciBilgisi || data.KullaniciAdi == KullaniciBilgisi)
                                 select data).FirstOrDefault();
                if (KisiKaydi == null)
                    Mesaj = "Kullanıcı bilgileri hatalı";
                else
                {
                    if (PYSSecurity.StrToMd5(KisiKaydi.Sifre) != PYSSecurity.StrToMd5(Sifre))
                        Mesaj = "Kullanıcı bilgileri hatalı";
                    else
                    {
                        KullaniciKisi = KisiKaydi;
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Mesaj = ex.Message;
            }
            return result;
        }

        internal TResult DoRegister(TKullaniciKisiIletisim KisiBilgileri)
        {
            bool ExistsUser()
            {
                bool Exists = false;
                var Kisi = (from data in Db.TblKisi where data.Tc == KisiBilgileri.Kisi.Tc select data).FirstOrDefault();
                if (Kisi != null)
                    Exists = true;
                return Exists;
            }

            TResult result = new TResult();
            try
            {
                TblKisi Kisi = KisiBilgileri.Kisi;
                TblKullanicilar Kullanicilar = KisiBilgileri.Kullanici;
                TblKisiFirma KisiFirma = KisiBilgileri.KisiFirma;
                List<TblKisiIletisim> KisiIletisimler = KisiBilgileri.KisiIletisimler;

                if (!ExistsUser())
                {
                    Db.TblKisi.Add(Kisi);
                    Db.SaveChanges();
                    Kullanicilar.KisiId = Kisi.KisiId;

                    Kullanicilar.Sifre = PYSSecurity.StrToMd5(Kullanicilar.Sifre);
                    Db.TblKullanicilar.Add(Kullanicilar);
                    Db.SaveChanges();

                    KisiFirma.KisiId = Kisi.KisiId;
                    Db.TblKisiFirma.Add(KisiFirma);
                    Db.SaveChanges();

                    foreach (var Iletisim in KisiIletisimler)
                    {
                        Iletisim.KisiId = Kisi.KisiId;
                        Db.TblKisiIletisim.Add(Iletisim);
                        Db.SaveChanges();
                    }
                    Kullanicilar.Sifre = "";
                    result.StatusCode = 200;
                    result.Success = true;
                    result.Data.Add(Kisi);
                    result.Data.Add(Kullanicilar);
                    result.Data.Add(KisiFirma);
                    result.Data.Add(KisiIletisimler);
                }

            }
            catch (Exception ex)
            {
                result.Message = "Hata meydana geldi.";
                result.StatusCode = -1001;
            }
            return result;
        }

        internal bool DoGetPersonDetail(Guid PersonGuid, out VwKisiKullaniciIletisim KullaniciKisi, out string Mesaj)
        {
            bool result = false;
            KullaniciKisi = null;
            Mesaj = "";
            try
            {
                var KisiKaydi = (from data in Db.VwKisiKullaniciIletisim
                                 where data.Guid.Value == PersonGuid
                                 select data).FirstOrDefault();
                if (KisiKaydi == null)
                    Mesaj = "Kullanıcı bilgileri hatalı";
                else
                {
                    KullaniciKisi = KisiKaydi;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Mesaj = ex.Message;
            }
            return result;
        }

    }
}
