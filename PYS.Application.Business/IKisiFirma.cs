using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public interface IKisiFirma
    {
        TResult DoAddPersonIntoFirm(TblKisiFirma KisiFirma);
        TResult DoDeletePersonIntoFirm(Guid PersonGuid, Guid FirmGuid);
        TResult DoGetPersonFirm(Guid FirmGuid);
        TResult DoGetAllPersonFirm();
    }
}
