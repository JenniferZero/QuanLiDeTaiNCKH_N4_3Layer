using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLDT;
using GUI_QLDT;

namespace GUI_QLDT
{
    class Program
    {

        public static void testDeTaiList()
        {
            try
            {
                DeTaiGUI dtGUI = new DeTaiGUI();
                dtGUI.showDeTaiList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
           
            testDeTaiList();
            DeTaiDAL dtDAL = new DeTaiDAL();
            //dtDAL.XuatDanhSachDT(); // Hàm xuất thêm thông tin các yêu cầu có trong DeTaiDAL #########################
            Console.WriteLine("Nhập thêm thông tin đề tài:");
            Console.ReadLine();
            //Console.ReadKey();
        }
    }
}
