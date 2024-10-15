using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLDT;
using GUI_QLDT;

namespace GUI_QLDT
{
    class Program
    {
        //public static void testDeTaiList()
        //{
        //    DeTaiGUI dtGUI = new DeTaiGUI();
        //    dtGUI.showDeTaiList();
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    testDeTaiList();
        //}
        public static void testDeTaiList()
        {
            try
            {
                DeTaiGUI dtGUI = new DeTaiGUI();
                dtGUI.showDeTaiList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }

    }
}