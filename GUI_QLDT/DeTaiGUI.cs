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

        public void showDeTaiList()
        {
            Console.OutputEncoding = UnicodeEncoding.Unicode;
            try
            {
                List<DeTaiDTO> lstDeTai = dtBLL.getDeTaiList();
                Console.WriteLine("\nDANH SÁCH ĐỀ TÀI NGHIÊN CỨU KHOA HỌC\n ");
                Console.WriteLine(new string('-', 193));
                Console.WriteLine("| {0,-30} | {1,-70} | {2,-40} | {3, -40} |", "Mã Đề Tài", "Tên Đề Tài", "Chủ Trì Đề Tài", "Giảng Viên Hướng Dẫn");
                Console.WriteLine(new string('-', 193));

                foreach (var deTai in lstDeTai)
                {
                    string MaDeTai = deTai.MaDeTai ?? "N/A";
                    string TenDeTai = deTai.TenDeTai ?? "N/A";
                    string ChuTriDeTai = deTai.ChuTriDeTai ?? "N/A";
                    string GiangVienHD = deTai.GiangVienHD ?? "N/A";

                    Console.WriteLine("| {0,-30} | {1,-70} | {2,-40} | {3, -40} |", MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD);
                }
                Console.WriteLine(new string('-', 193));
                Console.WriteLine($"Tổng số đề tài nghiên cứu khoa học: {lstDeTai.Count}\n\n");

                Console.WriteLine(new string('-', 193));
                string kq = $"| {"Mã đề tài",-13} | {"Tên đề tài",-70} | {"Thời gian bắt đầu",-30} | {"Thời gian kết thúc",-30}";
                Console.WriteLine(kq);

                Console.WriteLine(new string('-', 193));


                if (lstDeTai != null && lstDeTai.Count > 0)
                {
                    foreach (DeTaiDTO dt in lstDeTai)
                    {
                        Console.WriteLine(dt.toString());
                    }
                }
                else
                {
                    Console.WriteLine("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex) { }
        }

    }
}