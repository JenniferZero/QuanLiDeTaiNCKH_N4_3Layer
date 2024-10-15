using DAL_QLDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_QLDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeTaiDAL dal= new DeTaiDAL();
            string filename = "https://github.com/JenniferZero/QuanLiDeTaiNCKH_N4_3Layer/blob/master/ListDeTai.xml";
            dal.ReadFile(filename);
            dal.XuatDanhSachDT();


        }
    }
}
