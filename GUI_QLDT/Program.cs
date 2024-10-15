using DAL_QLDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QLDT;

namespace GUI_QLDT
{
    class Program
    {
        public static void testStudentList()
        {
            DeTaiGUI dtGUI = new DeTaiGUI();
            dtGUI.showStudentList();
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            testStudentList();

        }
    }
}
