﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLDT
{
    public class KinhTe : DeTaiDTO, IPhiHoTro
    {
        private int cauHoiKhaoSat;
        public int CauHoiKhaoSat { get => cauHoiKhaoSat; set => cauHoiKhaoSat = value; }

        public KinhTe() : base() 
        {
            cauHoiKhaoSat = 0;
        }

        public KinhTe(string maDeTai, string tenDeTai, string chuTriDeTai, string giangVienHD, string tgBatDau, string tgKetThuc, int cauHoiKhaoSat) 
            : base(maDeTai, tenDeTai, chuTriDeTai, giangVienHD, tgBatDau, tgKetThuc)
        {
            CauHoiKhaoSat = cauHoiKhaoSat;
        }
        public override double kinhPhiDeTai()
        {
            if (CauHoiKhaoSat > 100)
                return 12000000;
            else
                return 7000000;
        }
        public double tinhPhiHoTro()
        {
            if (CauHoiKhaoSat > 100)
                return CauHoiKhaoSat * 550;
            else 
                return CauHoiKhaoSat * 450; 
        }
        public override string ToString()
        {
            string kq = base.ToString();
            kq += $"\t Số câu hỏi khảo sát: {CauHoiKhaoSat}";
            return kq;
        }
    }
}
