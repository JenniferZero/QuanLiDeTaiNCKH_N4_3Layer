using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        #region Thêm đề tài mới
        public void NhapDeTaiMoiVaLuu(string filename)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Nhập loại đề tài (1: Nghiên cứu lý thuyết, 2: Kinh tế, 3: Công nghệ): ");
            int loai = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập mã đề tài: ");
            string MaDeTai = Console.ReadLine();

            Console.WriteLine("Nhập tên đề tài: ");
            string TenDeTai = Console.ReadLine();

            Console.WriteLine("Nhập tên chủ trì đề tài: ");
            string ChuTriDeTai = Console.ReadLine();

            Console.WriteLine("Nhập tên giảng viên hướng dẫn: ");
            string GiangVienHD = Console.ReadLine();

            Console.WriteLine("Nhập thời gian bắt đầu (dd/MM/yyyy): ");
            string ThoiGianBatDau = Console.ReadLine();

            Console.WriteLine("Nhập thời gian kết thúc (dd/MM/yyyy): ");
            string ThoiGianKetThuc = Console.ReadLine();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename); 

            XmlNode root = xmlDoc.DocumentElement;

            XmlElement newDeTai = xmlDoc.CreateElement("DeTai");


            XmlElement loaiNode = xmlDoc.CreateElement("Loai");
            loaiNode.InnerText = loai.ToString();
            newDeTai.AppendChild(loaiNode);

            XmlElement maDeTaiNode = xmlDoc.CreateElement("MaDeTai");
            maDeTaiNode.InnerText = MaDeTai;
            newDeTai.AppendChild(maDeTaiNode);

            XmlElement tenDeTaiNode = xmlDoc.CreateElement("TenDeTai");
            tenDeTaiNode.InnerText = TenDeTai;
            newDeTai.AppendChild(tenDeTaiNode);

            XmlElement chuTriNode = xmlDoc.CreateElement("ChuTriDeTai");
            chuTriNode.InnerText = ChuTriDeTai;
            newDeTai.AppendChild(chuTriNode);

            XmlElement giangVienNode = xmlDoc.CreateElement("GiangVienHD");
            giangVienNode.InnerText = GiangVienHD;
            newDeTai.AppendChild(giangVienNode);

            XmlElement thoiGianBDNode = xmlDoc.CreateElement("ThoiGianBatDau");
            thoiGianBDNode.InnerText = ThoiGianBatDau;
            newDeTai.AppendChild(thoiGianBDNode);

            XmlElement thoiGianKTNode = xmlDoc.CreateElement("ThoiGianKetThuc");
            thoiGianKTNode.InnerText = ThoiGianKetThuc;
            newDeTai.AppendChild(thoiGianKTNode);

            if (loai == 1)
            {
                Console.WriteLine("Đề tài áp dụng thực tế (true/false): ");
                bool ApDungThucTe = bool.Parse(Console.ReadLine());

                XmlElement apDungThucTeNode = xmlDoc.CreateElement("ApDungThucTe");
                apDungThucTeNode.InnerText = ApDungThucTe.ToString();
                newDeTai.AppendChild(apDungThucTeNode);
            }
            else if (loai == 2)
            {
                Console.WriteLine("Nhập số câu hỏi khảo sát: ");
                int CauHoiKhaoSat = int.Parse(Console.ReadLine());

                XmlElement cauHoiKhaoSatNode = xmlDoc.CreateElement("CauHoiKhaoSat");
                cauHoiKhaoSatNode.InnerText = CauHoiKhaoSat.ToString();
                newDeTai.AppendChild(cauHoiKhaoSatNode);
            }
            else if (loai == 3)
            {
                Console.WriteLine("Nhập môi trường công nghệ: ");
                string MoiTruong = Console.ReadLine();

                XmlElement moiTruongNode = xmlDoc.CreateElement("MoiTruong");
                moiTruongNode.InnerText = MoiTruong;
                newDeTai.AppendChild(moiTruongNode);
            }

            root.AppendChild(newDeTai);
            xmlDoc.Save(filename);

            Console.WriteLine("Đề tài mới đã được lưu vào file XML thành công!");
        
        }
        #endregion

        #region Đọc file xml
        public List<DeTaiDTO> ReadFile(string filename)
        {

            Console.InputEncoding = UnicodeEncoding.Unicode;
            try
            {

                XmlDocument xmlRead = new XmlDocument();
                xmlRead.Load(filename);

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
                        string boolAsString = ApDungThucTe ? "true" : "false";
                        dt = new NghienCuuLiThuyet(MaDeTai, TenDeTai, ChuTriDeTai, GiangVienHD, ThoiGianBatDau, ThoiGianKetThuc, ApDungThucTe);
                        lstDeTai.Add(dt);
                    }
                    if (loai == 2)
                    {
                        int CauHoiKhaoSat = int.Parse(node["CauHoiKhaoSat"].InnerText);
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
                return (List<DeTaiDTO>)lstDeTai;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region Thuật toán

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
            Console.WriteLine("Danh sách đề tài có kinh phí trên 10 triệu:");
            foreach (var dt in lstDeTai)
            {
                if (dt.kinhPhiDeTai() > 10000000)
                {
                    Console.WriteLine($"Mã đề tài: {dt.MaDeTai,-14}, Tên đề tài: {dt.TenDeTai,-122}, Kinh phí: {dt.kinhPhiDeTai()}");
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
                    Console.WriteLine($"Mã đề tài: {dt.MaDeTai}, Tên đề tài: {dt.TenDeTai}, Số câu hỏi: {kt.CauHoiKhaoSat}");
                    danhSachKinhTe.Add(kt);
                }
            }
            return danhSachKinhTe;
        }

        public void ThoiGianTren4Thang()
        {
            Console.WriteLine("Danh sách đề tài có thời gian thực hiện trên 4 tháng:");
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

        #endregion

        public void XuatDanhSachDT()
        {

            Console.InputEncoding = UnicodeEncoding.Unicode;
            //foreach (DeTaiDTO dt in lstDeTai)
            //{
            //    Console.WriteLine("\nThông Tin đề tài thứ {0}:", lstDeTai.IndexOf(dt) + 1);

            //    if (dt is NghienCuuLiThuyet nclt)
            //    {
            //        nclt.ToString();
            //    }
            //    if (dt is KinhTe kt)
            //    {
            //        kt.ToString();
            //    }
            //    if (dt is CongNghe cn)
            //    {
            //        cn.ToString();
            //    }
            //}
            Console.WriteLine("Danh sách đề tài:");

            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thông tin đề tài số {i + 1}: ");
                foreach (DeTaiDTO dt in lstDeTai)
                {
                    if (dt is NghienCuuLiThuyet nclt)
                    {
                        Console.WriteLine(lstDeTai[i].ToString());
                        nclt.ToString();
                    }
                }

                double kinhPhiCu = lstDeTai[i].kinhPhiDeTai();
                Console.WriteLine($"Kinh phí đề tài trước cập nhật: {kinhPhiCu}");
            }
            // Gọi hàm cập nhật kinh phí
            CapNhatKinhPhi10();

            Console.WriteLine("Sau khi cập nhật kinh phí:");
            for (int i = 0; i < lstDeTai.Count; i++)
            {
                Console.WriteLine($"Thông tin đề tài số {i + 1}: ");
                Console.WriteLine(lstDeTai[i].ToString());

                double kinhPhiMoi = lstDeTai[i].kinhPhiDeTai();
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


