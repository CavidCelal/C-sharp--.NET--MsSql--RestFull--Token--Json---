using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class BaseFirmaIslemleri
    {
        private DbPYSEntities Db;

        public BaseFirmaIslemleri()
        {
            Db = new DbPYSEntities();
        }

        internal TResult DoAddFirm(TblFirmalar tblFirma)
        {
            TResult result = new TResult();
            try
            {
                Db.TblFirmalar.Add(tblFirma);
                Db.SaveChanges();
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoUpdateFirm(Guid FirmGuid, TblFirmalar tblFirma)
        {
            TResult result = new TResult();
            try
            {
                TblFirmalar Firm = (from data in Db.TblFirmalar where data.FirmaGuid == FirmGuid select data).FirstOrDefault();
                if (Firm == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    Firm = tblFirma;
                    Db.TblFirmalar.Add(tblFirma);
                    Db.SaveChanges();
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoDeleteFirm(Guid FirmGuid)
        {
            TResult result = new TResult();
            try
            {
                TblFirmalar Firm = (from data in Db.TblFirmalar where data.FirmaGuid == FirmGuid select data).FirstOrDefault();
                if (Firm == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    Db.Database.ExecuteSqlCommand("update tblFirma set Silik=1 where FirmaGuid='" + FirmGuid + "'");
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoFirmList()
        {
            TResult result = new TResult();
            try
            {
                List<VwFirmalar> FirmList = (from data in Db.VwFirmalar orderby data.FirmaUnvan select data).ToList();
                if (FirmList == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    result.Data.AddRange(FirmList);
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoFirmList(string FirmName)
        {
            TResult result = new TResult();
            try
            {
                List<VwFirmalar> FirmList = (from data in Db.VwFirmalar
                                             where
                                                data.FirmaUnvan.Contains(FirmName) ||
                                                data.FirmaKodu.Contains(FirmName)
                                             select data).ToList();
                if (FirmList == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    result.Data.AddRange(FirmList);
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoFirmDetail(Guid FirmGuid)
        {
            TResult result = new TResult();
            try
            {
                VwFirmalar FirmDetay = (from data in Db.VwFirmalar
                                        where data.FirmaGuid == FirmGuid
                                        select data).FirstOrDefault();
                if (FirmDetay == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    result.Data.Add(FirmDetay);
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

        internal TResult DoPassiveFirms()
        {
            TResult result = new TResult();
            try
            {
                List<VwFirmalar> FirmListesi = (from data in Db.VwFirmalar
                                        where data.Aktif != true
                                        select data).ToList();
                if (FirmListesi == null)
                {
                    result.Message = "Firma bulunamadı.";
                }
                else
                {
                    result.Data.AddRange(FirmListesi);
                    result.Success = true;
                    result.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = -1001;
                result.Message = ex.Message;
            }

            return result;
        }

    }
}
