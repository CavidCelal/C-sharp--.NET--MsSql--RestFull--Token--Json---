using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class KisiFirmaIslemleri : BaseKisiFirma
    {
        public TResult AddPersonIntoFirm(TblKisiFirma KisiFirma)
        {
            return base.DoAddPersonIntoFirm(KisiFirma);
        }

        public TResult DeletePersonIntoFirm(Guid PersonGuid, Guid FirmGuid)
        {
            return base.DoDeletePersonIntoFirm(PersonGuid, FirmGuid);
        }

        public TResult GetAllPersonFirm()
        {
            return base.DoGetAllPersonFirm();
        }

        public TResult GetPersonFirm(Guid FirmGuid)
        {
            return base.DoGetPersonFirm(FirmGuid);
        }
    }
}
