using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYS.Application.Data;


namespace PYS.Application.Data
{
    public class TKullaniciKisiIletisim
    {
        public TblKisi Kisi { get; set; }
        public TblKullanicilar Kullanici { get; set; }  
        public TblKisiFirma KisiFirma { get; set; }
        public List<TblKisiIletisim> KisiIletisimler { get; set; }
        public TKullaniciKisiIletisim()
        {
            KisiIletisimler = new List<TblKisiIletisim>();
        }

    }
}
