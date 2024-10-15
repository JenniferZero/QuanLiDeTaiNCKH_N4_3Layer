using System;
using System.Collections.Generic;
using System.Linq;
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
                    double ThoiGianBatDau = double.Parse(node["ThoiGianBatDau"].InnerText);
                    double ThoiGianKetThuc = double.Parse(node["ThoiGianKetThuc"].InnerText);
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


        public List<KinhTe> inds100cau()
        {
            List<KinhTe> danhSachKinhTe = new List<KinhTe>(); 
            foreach (var dt in lstDeTai)
            {
                if (dt is KinhTe kt && kt.CauHoiKhaoSat > 100)
                {
                    kt.Xuat();
                    danhSachKinhTe.Add(kt); 
                }
            }
            return danhSachKinhTe; 
        }
        


        public void XuatDanhSachDT()
        {
            foreach (var dt in lstDeTai)
            {
                Console.WriteLine("Thong tin de tai so {0}: ", lstDeTai.IndexOf(dt) + 1);
                if (dt is NghienCuuLiThuyet lt)
                {
                    lt.Xuat();
                }
                if (dt is CongNghe cn)
                {
                    cn.Xuat();
                }
                if (dt is KinhTe kt)
                {
                    kt.Xuat();
                }
            }
            inds100cau();
        }
    }
}
