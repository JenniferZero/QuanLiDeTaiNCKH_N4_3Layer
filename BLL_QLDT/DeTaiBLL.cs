using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL_QLDT;
using DTO_QLDT;
using static BLL_QLDT.DeTaiBLL;

namespace BLL_QLDT
{
    public class DeTaiBLL
    {
       
        DeTaiDAL dtDAL = new DeTaiDAL();
        public DeTaiBLL() { }
        public List<DeTaiDTO> getStudentList()
        {
            return dtDAL.ReadFile("D:\\Users\\WIN 10\\source\\Repos\\New folder\\QuanLiDeTaiNCKH_N4_3Layer\\ListDeTai.xml");
        }
    }
}
