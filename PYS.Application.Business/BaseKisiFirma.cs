using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class BaseKisiFirma : IKisiFirma
    {
        public TResult DoAddPersonIntoFirm(TblKisiFirma KisiFirma)
        {
            TResult result = new TResult();
            return result;
        }

        public TResult DoDeletePersonIntoFirm(Guid PersonGuid, Guid FirmGuid)
        {
            TResult result = new TResult();
            return result;
        }

        public TResult DoGetAllPersonFirm()
        {
            TResult result = new TResult();
            return result;
        }

        public TResult DoGetPersonFirm(Guid FirmGuid)
        {
            TResult result = new TResult();
            return result;
        }
    }
}
