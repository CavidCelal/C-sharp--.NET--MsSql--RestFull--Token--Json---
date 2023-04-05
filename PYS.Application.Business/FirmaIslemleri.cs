using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class FirmaIslemleri : BaseFirmaIslemleri
    {

        public TResult AddFirm(TblFirmalar tblFirma)
        {
            return base.DoAddFirm(tblFirma);
        }

        public TResult UpdateFirm(Guid FirmGuid, TblFirmalar tblFirma)
        {
            return base.DoUpdateFirm(FirmGuid, tblFirma);
        }

        public TResult DeleteFirm(Guid FirmGuid)
        {
            return base.DoDeleteFirm(FirmGuid); 
        }

        public TResult FirmList()
        {
            return base.DoFirmList();
        }

        public TResult FirmList(string FirmName)
        {
            return base.DoFirmList(FirmName);
        }

        public TResult FirmDetail(Guid FirmGuid)
        {
            return base.DoFirmDetail(FirmGuid);
        }

        public TResult PassiveFirms()
        {
            return base.DoPassiveFirms();
        }
    }
}
