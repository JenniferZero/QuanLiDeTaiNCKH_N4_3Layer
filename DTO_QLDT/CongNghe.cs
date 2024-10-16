using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLDT
{
    public class CongNghe : DeTaiDTO, IPhiHoTro
    {
        
        private string moiTruong;

        public string MoiTruong { get => moiTruong; set => moiTruong = value; }

        public CongNghe() : base() 
        {
            moiTruong = "web";
        }
        public CongNghe(string maDeTai, string tenDeTai, string chuTriDeTai, string giangVienHD, string tgBatDau, string tgKetThuc, string moiTruong) 
            : base(maDeTai, tenDeTai, chuTriDeTai, giangVienHD, tgBatDau, tgKetThuc)
        {
            MoiTruong = moiTruong;
        }
        public override double kinhPhiDeTai()
        {
            if (MoiTruong == "web" || MoiTruong == "mobile")
            {
                return 15000000;
            }
            else if (MoiTruong == "window")
            {
                return 10000000;
            }
            else
                return 0;
        }
        public double tinhPhiHoTro()
        {
            if (MoiTruong == "mobile")
                return 1000000;
            else if (MoiTruong == "web")
                return 800000;
            else if (MoiTruong == "window")
                return 500000;
            else
                return 0;
        }

        public override string toString()
        {
            Console.WriteLine("\tMoi truong de tai :" + MoiTruong);
            return base.toString();
            
        }
    }
}
