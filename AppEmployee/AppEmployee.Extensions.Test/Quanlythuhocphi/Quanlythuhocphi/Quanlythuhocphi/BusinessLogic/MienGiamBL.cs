using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;

namespace Quanlythuhocphi.BusinessLogic
{
    class MienGiamBL
    {
        /// <summary>
        /// Phương thức thêm miễn giảm mới
        /// </summary>
        /// <param name="mg"></param>
        /// <returns></returns>
        public string Insert(MIENGIAM mg)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.InsertMIENGIAM(mg.TenMienGiam, mg.PhanTram,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức cập nhật một miễn giảm
        /// </summary>
        /// <param name="mg"></param>
        /// <returns></returns>
        public string Update(MIENGIAM mg)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.UpdateMIENGIAM(mg.MaMienGiam, mg.TenMienGiam, mg.PhanTram,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức xóa một miễn giảm
        /// </summary>
        /// <param name="mamiengiam"></param>
        /// <returns></returns>
        public string Delete(int mamiengiam)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.DeleteMIENGIAM(mamiengiam,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy tất cả các miễn giảm
        /// </summary>
        /// <returns></returns>
        public List<GetMIENGIAM_Result> GetAllMienGiam()
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetMIENGIAM().ToList<GetMIENGIAM_Result>();
            }
        }
    }
}
