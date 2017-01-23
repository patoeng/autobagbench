using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xs156AutoBagPLC.Helper
{
    public class PlcErrorMessage
    {
        public static string Message(int a)
        {
            string i;
            switch (a)
            {
                case 0:
                    i = "No Error";
                    break;
                case 1:
                    i = "Emergency Switch";
                    break;
                case 2:
                    i = "Product tidak boleh masuk ke Bag";
                    break;
                case 3:
                    i = "Plastic Bag tidak boleh masuk Big Box";
                    break;
                case 4:
                    i = "Plastic Bag tidak boleh masuk Reject Bin";
                    break;
                case 5:
                    i = "Accessories Auto Gate #1 Tidak Terbuka.";
                    break;
                case 6:
                    i = "Accessories Auto Gate #1 Tidak Boleh Terbuka.";
                    break;
                case 7:
                    i = "Accessories Auto Gate #2 Tidak Terbuka.";
                    break;
                case 8:
                    i = "Accessories Auto Gate #2 Tidak Boleh Terbuka.";
                    break;
                case 9:
                    i = "Accessories Auto Gate #3 Tidak Terbuka.";
                    break;
                case 10:
                    i = "Accessories Auto Gate #3 Tidak Boleh Terbuka.";
                    break;
                case 11:
                    i = "Accessories Auto Gate #4 Tidak Terbuka.";
                    break;
                case 12:
                    i = "Accessories Auto Gate #4 Tidak Boleh Terbuka.";
                    break;
                case 13:
                    i = "Tidak Boleh ambil Accessories  M8.";
                    break;
                case 14:
                    i = "Tidak Boleh ambil Accessories  #2.";
                    break;
                case 15:
                    i = "Tidak Boleh ambil Accessories  #3.";
                    break;
                case 16:
                    i = "Tidak Boleh ambil Accessories  #4.";
                    break;
                case 17:
                    i = "Accessories yang dimasukkan salah.";
                    break;
                case 18:
                    i = "Semua Accessories Gate harus tertutup.";
                    break;
                case 19:
                    i = "Belum Boleh ambil Accessories  M8.";
                    break;
                case 20:
                    i = "Belum Boleh ambil Accessories  M12.";
                    break;
                case 21:
                    i = "Belum Boleh ambil Accessories  M18.";
                    break;
                case 22:
                    i = "Belum Boleh ambil Accessories  M30";
                    break;
                case 23:
                    i = "Article Barcode Salah!";
                    break;
                default: i = "Undefined Error.";
                    break;
            }
            return i;
        }
    }
}
