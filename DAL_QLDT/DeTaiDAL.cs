using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO_QLDT;

namespace DAL_QLDT
{
    public class DeTaiDAL
    {
        List<DeTaiDTO> lstDeTai;
        internal List<DeTaiDTO> LstDeTai { get => lstDeTai; set => lstDeTai = value; }

        public DeTaiDAL()
        {
            lstDeTai = new List<DeTaiDTO>();
        }
        public DeTaiDAL(List<DeTaiDTO> lstDeTai)
        {
            this.lstDeTai = lstDeTai;
        }

        public List<DeTaiDTO> ReadFile(string filename)
        {
            Console.InputEncoding = UnicodeEncoding.Unicode;
            try
            {

                XmlDocument xmlRead = new XmlDocument();
                xmlRead.LoadXml(filename);

                XmlNodeList nodeList = xmlRead.SelectNodes("DanhSachDeTai/DeTai");
                foreach (XmlNode node in nodeList)
                {
                    DeTaiDTO dt;
                    int loai = int.Parse(node["Loai"].InnerText);
                    string MaDeTai = node["MaDeTai"].InnerText;
                    string TenDeTai = node["TenDeTai"].InnerText;
                    string ChuTriDeTai = node["ChuTriDeTai"].InnerText;
                    string GiangVienHD = node["GiangVienHD"].InnerText;
                    string ThoiGianBatDau = node["ThoiGianBatDau"].InnerText;
                    string ThoiGianKetThuc = node["ThoiGianKetThuc"].InnerText;
                    if (loai == 1)
                    {
                        bool ApDungThucTe = bool.Parse(node["ApDungThucTe"].InnerText);
                        dt = new NghienCuuLiThuyet(MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD, ThoiGianBatDau, ThoiGianKetThuc, ApDungThucTe);
                        lstDeTai.Add(dt);
                    }
                    if (loai == 2)
                    {
                        int CauHoiKhaoSat = int.Parse(node["cauHoiKhaoSat"].InnerText);
                        dt = new KinhTe(MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD, ThoiGianBatDau, ThoiGianKetThuc, CauHoiKhaoSat);
                        lstDeTai.Add(dt);
                    }
                    if (loai == 3)
                    {
                        string MoiTruong = node["MoiTruong"].InnerText;
                        dt = new CongNghe(MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD, ThoiGianBatDau, ThoiGianKetThuc, MoiTruong);
                        lstDeTai.Add(dt);
                    }
                }
                return lstDeTai;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<DeTaiDTO> TimKiemDeTai(string keyword)
        {
            List<DeTaiDTO> ketQuaTimKiem = new List<DeTaiDTO>();

            foreach (var dt in lstDeTai)
            {
                if (dt.MaDeTai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    dt.TenDeTai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    dt.ChuTriDeTai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    dt.GiangVienHD.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ketQuaTimKiem.Add(dt);
                }
            }
            return ketQuaTimKiem;
        }

        public List<DeTaiDTO> TimKiemTheoGiangVien(string tenGiangVien)
        {
            List<DeTaiDTO> ketQua = new List<DeTaiDTO>();

            foreach (var dt in lstDeTai)
            {
                if (dt.GiangVienHD.Equals(tenGiangVien, StringComparison.OrdinalIgnoreCase))
                {
                    ketQua.Add(dt);
                }
            }

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Không tìm thấy đề tài nào của giảng viên: " + tenGiangVien);
            }
            return ketQua;
        }

        public void CapNhatKinhPhi10()
        {
            foreach (var dt in lstDeTai)
            {
                double kinhPhiCu = dt.kinhPhiDeTai();
                double kinhPhiMoi = kinhPhiCu * 1.1;
                kinhPhiMoi = dt.kinhPhiDeTai();
            }
        }

        public void KinhPhiTren10Trieu()
        {
            Console.WriteLine("Danh sach de tai co kinh phi tren 10 trieu:");
            foreach (var dt in lstDeTai)
            {
                if (dt.kinhPhiDeTai() > 10000000) 
                {
                    Console.WriteLine(dt.ToString()); 
                }
            }
        }

        public List<KinhTe> SoCauHoiTren100()
        {
            List<KinhTe> danhSachKinhTe = new List<KinhTe>(); 
            foreach (var dt in lstDeTai)
            {
                if (dt is KinhTe kt && kt.CauHoiKhaoSat > 100)
                {
                    kt.toString();
                    danhSachKinhTe.Add(kt); 
                }
            }
            return danhSachKinhTe; 
        }

        public void ThoiGianTren4Thang()
        {
            Console.WriteLine("Danh sach de tai co thoi gian thuc hien tren 4 thang:");
            foreach (var dt in lstDeTai)
            {
                DateTime startDate = DateTime.Parse(dt.ThoiGianBatDau);
                DateTime endDate = DateTime.Parse(dt.ThoiGianKetThuc);

                int TinhThoiGian = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;

                if (TinhThoiGian > 4)
                {
                    Console.WriteLine(dt.ToString()); 
                }
            }
        }

        //public void XuatDanhSachDT()
        //{
        //    foreach (var dt in lstDeTai)
        //    {
        //        Console.WriteLine("Thong tin de tai so {0}: ", lstDeTai.IndexOf(dt) + 1);
        //        if (dt is NghienCuuLiThuyet lt)
        //        {
        //            //lt.Xuat();
        //            lt.toString();
        //        }
        //        if (dt is CongNghe cn)
        //        {
        //            //cn.Xuat();
        //            cn.toString();
        //        }
        //        if (dt is KinhTe kt)
        //        {
        //            //kt.Xuat();
        //            dt.toString();
        //        }
        //    }
        //    for (int i = 0; i < lstDeTai.Count; i++)
        //    {
        //        Console.WriteLine($"Thong tin de tai so {i + 1} co so cau hoi tren 100 : ");
        //        Console.WriteLine(lstDeTai[i].ToString());
        //    }
        //    SoCauHoiTren100();

        //    for (int i = 0; i < lstDeTai.Count; i++)
        //    {
        //        Console.WriteLine($"Thong tin de tai so {i + 1}: ");
        //        Console.WriteLine(lstDeTai[i].ToString());
        //    }
        //    ThoiGianTren4Thang();

        //    for (int i = 0; i < lstDeTai.Count; i++)
        //    {
        //        Console.WriteLine($"Thong tin de tai so {i + 1}: ");
        //        Console.WriteLine(lstDeTai[i].ToString());
        //    }
        //    KinhPhiTren10Trieu();

        //    for (int i = 0; i < lstDeTai.Count; i++)
        //    {
        //        Console.WriteLine($"Thong tin de tai so {i + 1}: ");
        //        Console.WriteLine(lstDeTai[i].ToString());

        //        double kinhPhi10 = lstDeTai[i].kinhPhiDeTai();
        //        Console.WriteLine($"Kinh phi de tai: {kinhPhi10}");
        //    }
        //    CapNhatKinhPhi10();

        public void XuatDanhSachDT()
        {
            Console.WriteLine("Danh sách đề tài:");

            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thông tin đề tài số {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString()); // Xuất thông tin đề tài

                double kinhPhiCu = lstDeTai[i].kinhPhiDeTai(); // Kinh phí trước khi cập nhật
                Console.WriteLine($"Kinh phí đề tài trước cập nhật: {kinhPhiCu}");
            }

            // Gọi hàm cập nhật kinh phí
            CapNhatKinhPhi10();

            Console.WriteLine("Sau khi cập nhật kinh phí:");
            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thông tin đề tài số {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString()); // Xuất thông tin đề tài sau khi cập nhật

                double kinhPhiMoi = lstDeTai[i].kinhPhiDeTai(); // Kinh phí sau khi cập nhật
                Console.WriteLine($"Kinh phí đề tài sau cập nhật: {kinhPhiMoi}");
            }

            // Xuất danh sách đề tài có số câu hỏi trên 100
            List<KinhTe> danhSachKinhTe = SoCauHoiTren100();
            Console.WriteLine("Danh sách đề tài Kinh tế có số câu hỏi trên 100:");
            foreach (var kt in danhSachKinhTe)
            {
                Console.WriteLine(kt.ToString());
            }

            // Xuất danh sách đề tài có thời gian thực hiện trên 4 tháng
            ThoiGianTren4Thang();

            // Xuất danh sách đề tài có kinh phí trên 10 triệu
            KinhPhiTren10Trieu();
        }

    }
}

