using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_QLDT;
using DTO_QLDT;

namespace GUI_QLDT
{
    public class DeTaiGUI
    {
        DeTaiBLL dtBLL = new DeTaiBLL();
        public void showStudentList()
        {
            Console.OutputEncoding = UnicodeEncoding.Unicode;
            try
            {
                Console.WriteLine("\t\t\t\t\t\t DANH SÁCH ĐỀ TÀI");
                string kq = "Mã đề tài\t Tên đề tài \t\t\t\t\t Chủ trì đề tài\t\t\t Giảng viên hướng dẫn\t\t Thời gian bắt đầu\t\t Thời gian kết thúc";
                Console.WriteLine(kq);

                List<DeTaiDTO> lstDeTai = new List<DeTaiDTO>();
                lstDeTai = dtBLL.getStudentList();
                foreach (DeTaiDTO dt in lstDeTai)
                {
                    Console.WriteLine(dt.toString());
                }
            }
            catch (Exception ex) { }
        }
    }
}
