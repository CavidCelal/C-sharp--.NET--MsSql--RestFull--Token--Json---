using PYS.Application.Data;
using PYS.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class KullaniciIslemleri : BaseKullaniciIslemleri
    {
        static int ExpireMinute = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TokenExpireMinute"].ToString());

        public TResult GetToken(string KullaniciBilgisi, string Sifre, string SecretKey)
        {
            TResult result = new TResult();
            result.StatusCode = -1000;
            string Mesaj, Token = "";
            VwKisiKullaniciIletisim KullaniciKisi;
            bool Success = base.DoLogin(KullaniciBilgisi, Sifre, SecretKey, out KullaniciKisi, out Mesaj);
            if (Success)
            {
                if (KullaniciKisi != null)
                    Token = DoCreateToken(KullaniciKisi, SecretKey, ExpireMinute);

                result.Success = Success;
                result.StatusCode = 200;
                result.Data.Add(Token);

            }
            return result;
        }

        public TResult GetPersonDetail(string Token, string SecretKey, Guid PersonGuid)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;
            TToken OpenToken;
            result = ValidToken(Token, SecretKey, out OpenToken);
            if (result.Success)
            {
                string Mesaj;
                VwKisiKullaniciIletisim KullaniciKisi;
                bool Success = base.DoGetPersonDetail(PersonGuid, out KullaniciKisi, out Mesaj);
                result.Message = Mesaj;
                if (Success)
                {
                    if (KullaniciKisi != null)
                    {
                        result.Success = Success;
                        result.StatusCode = 200;
                        result.Data.Add(KullaniciKisi);
                    }
                }
            }
            return result;
        }

        public TResult GetPersonDetail(string Token, string SecretKey)
        {
            TResult result = new TResult();
            TToken OpenToken;
            result.StatusCode = -1001;
            result = ValidToken(Token, SecretKey, out OpenToken);
            if (result.Success && OpenToken != null)
            {
                Guid PersonGuid = OpenToken.Guid;
                string Mesaj;
                VwKisiKullaniciIletisim KullaniciKisi;
                bool Success = base.DoGetPersonDetail(PersonGuid, out KullaniciKisi, out Mesaj);
                result.Message = Mesaj;
                if (Success)
                {
                    if (KullaniciKisi != null)
                    {
                        result.Success = Success;
                        result.StatusCode = 200;
                        result.Data.Add(KullaniciKisi);
                    }
                }
            }
            return result;
        }

        public TResult ValidToken(string Token, string SecretKey, out TToken OpenToken)
        {
            TResult result = new TResult();
            result.StatusCode = -1000;
            bool IsValid = DoValidToken(Token, SecretKey, out OpenToken);
            result.Success = IsValid;
            result.StatusCode = 200;            
            return result;
        }

        public TResult Register(TKullaniciKisiIletisim KisiBilgileri)
        {
            return DoRegister(KisiBilgileri);
        }




        private string DoCreateToken(VwKisiKullaniciIletisim KullaniciKisi, string SecretKey, int ExpireMinute)
        {
            string result = KullaniciKisi.FirmaKodu + "|" +
                                KullaniciKisi.KisiId.ToString() + "|" +
                                KullaniciKisi.Tc.ToString() + "|" +
                                KullaniciKisi.KullaniciId + "|" +
                                DateTime.Now.AddMinutes(ExpireMinute) + "|" +
                                KullaniciKisi.Guid.Value;
            result = result.Replace(" ", "+").Replace("-", "_");
            result = PYSSecurity.Encrypt(result, SecretKey);
            return result;
        }

        private bool DoValidToken(string Token, string SecretKey, out TToken OpenToken)
        {
            bool result = true;
            var DecryptText = PYSSecurity.Decrypt(Token, SecretKey);
            string LToken = DecryptText.Replace("+", " ").Replace("_", "");
            string[] Values = LToken.Split('|');
            OpenToken = new TToken()
            {
                FirmaKodu = Values[0],
                KisiId = Convert.ToInt32(Values[1]),
                TC = Convert.ToUInt32(Values[2]),
                KullaniciId = Convert.ToInt32(Values[3]),
                ExpireMinute = Convert.ToDateTime(Values[4]),
                Guid = Guid.Parse(Values[5])
            };
            if (OpenToken != null)
            {
                if (DateTime.Now > OpenToken.ExpireMinute)
                    result = false;
            }
            return result;
        }

    }
}
