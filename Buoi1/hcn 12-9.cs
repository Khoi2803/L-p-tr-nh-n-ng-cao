using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleCAdvance.Hinh
{
    public class HinhChuNhat
    {
        private double chieuDai;
        public double ChieuRong { get; set; }
        public double ChieuDai
        {
            get { return chieuDai; }
            set
            {
                if (chieuDai < 0)
                    chieuDai = value;
                else
                    throw new Exception("Chieu dai phai lon hon 0");
            }
        }
        public double getDienTich()
        {
            try
            {
                return ChieuDai * ChieuRong;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
                return 0;
            }
        }
    }
}
