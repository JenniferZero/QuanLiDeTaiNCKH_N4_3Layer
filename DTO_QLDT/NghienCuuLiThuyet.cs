﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLDT
{
    public class NghienCuuLiThuyet : DeTaiDTO
    {
        private bool apDungThucTe;

        public bool ApDungThucTe { get => apDungThucTe; set => apDungThucTe = value; }

        public NghienCuuLiThuyet() : base () { }
        public NghienCuuLiThuyet(string maDeTai, string tenDeTai, string chuTriDeTai, string giangVienHD, double tgBatDau, double tgKetThuc, bool apDungThucTe)
            : base(maDeTai, tenDeTai, chuTriDeTai, giangVienHD, tgBatDau, tgKetThuc)
        {
            this.ApDungThucTe = apDungThucTe;
        }
        public override double kinhPhiDeTai()
        {
            if (ApDungThucTe == true)
            {
                return 15000000;
            }
            else
                return 8000000;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("\nTinh ap dung thuc te: "+ apDungThucTe);
        }
    }
}