using System;
using System.Collections.Generic;
using System.Linq;
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
        private double thoiGianBatDau;
        private double thoiGianKetThuc;

        public string MaDeTai { get => maDeTai; set => maDeTai = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public string ChuTriDeTai { get => chuTriDeTai; set => chuTriDeTai = value; }
        public string GiangVienHD { get => giangVienHD; set => giangVienHD = value; }
        public double ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public double ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }

        public DeTaiDTO() { }
        public DeTaiDTO(string maDeTai, string tenDeTai, string chuTriDeTai, string giangVienHD, double tgBatDau, double tgKetThuc)
        {
            this.MaDeTai = maDeTai;
            this.TenDeTai = tenDeTai;
            this.ChuTriDeTai= chuTriDeTai;
            this.GiangVienHD= giangVienHD;
            this.ThoiGianBatDau = tgBatDau;
            this.ThoiGianKetThuc = tgKetThuc;

        }
        public abstract double kinhPhiDeTai();
        public virtual void Xuat()
        {
            Console.WriteLine("{0}/t {1}/t {2}/t {3}/ {4} {5}", MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD, ThoiGianBatDau, ThoiGianKetThuc);
        }

    }
}
