using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;

namespace Quanlythuhocphi.BusinessLogic
{
    class LyDoThuBL
    {
        /// <summary>
        /// Phương thức thêm một lý do thu
        /// </summary>
        /// <param name="lop"></param>
        /// <returns></returns>
        public string Insert(LYDOTHU lydo)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.InsertLyDoThu(lydo.TenLyDo,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức cập nhật lý do thu
        /// </summary>
        /// <param name="lop"></param>
        /// <returns></returns>
        public string Update(LYDOTHU lydo)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.UpdateLyDothu(lydo.MaLyDo, lydo.TenLyDo,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức xóa lý do thu
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        public string Delete(int malydo)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.DeleteLyDoThu(malydo,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy danh sách các lý do thu
        /// </summary>
        /// <returns></returns>
        public List<GetLyDoThu_Result> GetAllLyDoThu()
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetLyDoThu().ToList<GetLyDoThu_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy lý do thu theo mã số
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        public GetLyDoThuById_Result GetLopById(int malydo)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetLyDoThuById(malydo).FirstOrDefault();
            }
        }
    }
}
