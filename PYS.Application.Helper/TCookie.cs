using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Helper
{
    public static class TCookie
    {
        public static bool ValidCookie(string BrowserCookie, string SessionCookie)
        {
            return BrowserCookie == SessionCookie ? true : false;   
        }
    }
}
