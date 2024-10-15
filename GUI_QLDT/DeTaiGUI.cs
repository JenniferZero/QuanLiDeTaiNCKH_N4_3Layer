﻿using System;
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
                Console.WriteLine("\t\t\t\t\t\t DANH SÁCH ĐỀ TÀI\n");
                string kq = "Mã đề tài\t Tên đề tài \t\t\t Chủ trì đề tài\t\t\t Giảng viên hướng dẫn\t\t Thời gian bắt đầu\t\t Thời gian kết thúc";
                Console.WriteLine(kq);

                List<DeTaiDTO> lstDeTai = dtBLL.getDeTaiList();

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
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }

    }
}