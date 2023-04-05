using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PYS.Application.Security;
using PYS.Application.Business;
using PYS.Application.Data;
using Newtonsoft.Json;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtEncyriptText.Text = PYSSecurity.Encrypt(TxtCleanText.Text, "asdaeasd");
            //encryptedstring = cryptObj.Encrypt(username, "AGARAMUDHALA", "EZHUTHELLAM", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtDencyriptText.Text = PYSSecurity.Decrypt(TxtEncyriptText.Text, "asdasd");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
            string mesaj;
            dynamic result = kullaniciIslemleri.GetToken("adasd", "aasdasd");
            //kullaniciIslemleri.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TKullaniciKisiIletisim kullaniciKisi = new TKullaniciKisiIletisim();
            kullaniciKisi.Kisi = new TblKisi();
            kullaniciKisi.Kisi.Ad = "Kişi Adı";
            kullaniciKisi.Kisi.Soyad = "Soyad";
            kullaniciKisi.Kisi.DogumTarihi = DateTime.Now;
            kullaniciKisi.Kisi.Silik = false;
            kullaniciKisi.Kullanici = new TblKullanicilar();            
            kullaniciKisi.KisiIletisimler = new List<TblKisiIletisim>();
            kullaniciKisi.KisiIletisimler.Add(new TblKisiIletisim()
            {

            });
            kullaniciKisi.KisiFirma = new TblKisiFirma();
            string JsonText = JsonConvert.SerializeObject(kullaniciKisi, Formatting.Indented);
            textBox1.Text = JsonText;
        }
    }

}
