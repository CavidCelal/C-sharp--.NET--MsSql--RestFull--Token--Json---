using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Data
{
    public class TToken
    {
        public string FirmaKodu { get; set; }
        public int KisiId { get; set; } 
        public ulong TC { get; set; }
        public int KullaniciId { get; set; }
        public DateTime ExpireMinute { get; set; }
        public Guid Guid { get; set; }  
    }
}
