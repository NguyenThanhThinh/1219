using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;

namespace Quanlythuhocphi.BusinessLogic
{
    class LopBL
    {
        /// <summary>
        /// Phương thức thêm một lớp mới
        /// </summary>
        /// <param name="lop"></param>
        /// <returns></returns>
        public string Insert(LOP lop)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.InsertLOP(lop.TenLop,err);
                return err.Value.ToString();
            }
        }
        /// <summary>
        /// Phương thức cập nhật một lớp học mới
        /// </summary>
        /// <param name="lop"></param>
        /// <returns></returns>
        public string Update(LOP lop)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.UpdateLOP(lop.MaLop,lop.TenLop, err);
                return err.Value.ToString();
            }

        }
        /// <summary>
        /// Phương thức xóa lớp học
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        public string Delete(int malop)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.DeleteLOP(malop,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy danh sách các lớp học
        /// </summary>
        /// <returns></returns>
        public List<GetLOP_Result> GetAllLop()
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetLOP().ToList<GetLOP_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy lớp theo mã số
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        public GetLOPID_Result GetLopById(int malop)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetLOPID(malop).FirstOrDefault();
            }
        }
    }
}
