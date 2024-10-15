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
                    //kt.Xuat();
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

        public void XuatDanhSachDT()
        {
            foreach (var dt in lstDeTai)
            {
                Console.WriteLine("Thong tin de tai so {0}: ", lstDeTai.IndexOf(dt) + 1);
                if (dt is NghienCuuLiThuyet lt)
                {
                    //lt.Xuat();
                    lt.toString();
                }
                if (dt is CongNghe cn)
                {
                    //cn.Xuat();
                    cn.toString();
                }
                if (dt is KinhTe kt)
                {
                    //kt.Xuat();
                    dt.toString();
                }
            }
            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thong tin de tai so {i + 1} co so cau hoi tren 100 : ");
                Console.WriteLine(lstDeTai[i].ToString());
            }
            SoCauHoiTren100();

            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thong tin de tai so {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString());
            }
            ThoiGianTren4Thang();

            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thong tin de tai so {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString());
            }
            KinhPhiTren10Trieu();

            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thong tin de tai so {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString());

                double kinhPhi10 = lstDeTai[i].kinhPhiDeTai();
                Console.WriteLine($"Kinh phi de tai: {kinhPhi10}");
            }
            CapNhatKinhPhi10();
            

        }
        
    }
}
