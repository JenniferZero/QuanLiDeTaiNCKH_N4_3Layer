﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLDT
{
    public abstract class DeTaiDTO
    {
        protected string maDeTai;
        protected string tenDeTai;
        protected string chuTriDeTai;
        protected string giangVienHD;
        private string thoiGianBatDau;
        private string thoiGianKetThuc;

        public string MaDeTai { get => maDeTai; set => maDeTai = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public string ChuTriDeTai { get => chuTriDeTai; set => chuTriDeTai = value; }
        public string GiangVienHD { get => giangVienHD; set => giangVienHD = value; }
        public string ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public string ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }

        public DeTaiDTO() 
        {
            MaDeTai = "";
            TenDeTai = "";
            ChuTriDeTai = "";
            GiangVienHD = "";
            ThoiGianBatDau = "";
            ThoiGianKetThuc = "";
        }
        public DeTaiDTO(string maDeTai, string tenDeTai, string chuTriDeTai, string giangVienHD, string tgBatDau, string tgKetThuc)
        {
            MaDeTai = maDeTai;
            TenDeTai = tenDeTai;
            ChuTriDeTai = chuTriDeTai;
            GiangVienHD = giangVienHD;
            ThoiGianBatDau = tgBatDau;
            ThoiGianKetThuc = tgKetThuc;

        }
        public abstract double kinhPhiDeTai();

        public virtual string toString()
        {
            string kq = $"| {MaDeTai,-14}| {TenDeTai, -71}";
            kq += $"| {ThoiGianBatDau,-31}| {ThoiGianKetThuc, -20}";
            kq += $"\tKinh phí đề tài: {kinhPhiDeTai()}\n";

            return kq;
        
        }
    }
}
