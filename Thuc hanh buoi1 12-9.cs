using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    interface IHinh
    {
        double GetDienTich();
        double GetChuVi();
        void Nhap();
        void HienThi();
    }

    class HinhTron : IHinh
    {
        private double _banKinh;
        public double BanKinh
        {
            get => _banKinh;
            set
            {
                if (value <= 0) throw new ArgumentException("Bán kính phải lớn hơn 0.");
                _banKinh = value;
            }
        }

        public HinhTron() { }
        public HinhTron(double r) { BanKinh = r; }

        public double GetDienTich() => Math.PI * BanKinh * BanKinh;
        public double GetChuVi() => 2 * Math.PI * BanKinh;

        public void Nhap()
        {
            while (true)
            {
                Console.Write("Nhập bán kính hình tròn: ");
                var s = Console.ReadLine();
                if (double.TryParse(s, out double r) && r > 0)
                {
                    BanKinh = r;
                    break;
                }
                Console.WriteLine("Giá trị không hợp lệ. Thử lại.");
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"Hình tròn: R = {BanKinh}, Chu vi = {GetChuVi():F2}, Diện tích = {GetDienTich():F2}");
        }
    }

    class HinhChuNhat : IHinh
    {
        private double _chieuDai;
        private double _chieuRong;

        public double ChieuDai
        {
            get => _chieuDai;
            set
            {
                if (value <= 0) throw new ArgumentException("Chiều dài phải lớn hơn 0.");
                _chieuDai = value;
            }
        }
        public double ChieuRong
        {
            get => _chieuRong;
            set
            {
                if (value <= 0) throw new ArgumentException("Chiều rộng phải lớn hơn 0.");
                _chieuRong = value;
            }
        }

        public HinhChuNhat() { }
        public HinhChuNhat(double dai, double rong) { ChieuDai = dai; ChieuRong = rong; }

        public double GetDienTich() => ChieuDai * ChieuRong;
        public double GetChuVi() => 2 * (ChieuDai + ChieuRong);

        public void Nhap()
        {
            while (true)
            {
                Console.Write("Nhập chiều dài: ");
                var a = Console.ReadLine();
                Console.Write("Nhập chiều rộng: ");
                var b = Console.ReadLine();
                if (double.TryParse(a, out double dai) && double.TryParse(b, out double rong) && dai > 0 && rong > 0)
                {
                    ChieuDai = dai; ChieuRong = rong;
                    break;
                }
                Console.WriteLine("Giá trị không hợp lệ. Thử lại.");
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"Hình chữ nhật: Dài = {ChieuDai}, Rộng = {ChieuRong}, Chu vi = {GetChuVi():F2}, Diện tích = {GetDienTich():F2}");
        }
    }

    class HinhTamGiac : IHinh
    {
        private double _a;
        private double _b;
        private double _c;

        public double A
        {
            get => _a;
            set
            {
                if (value <= 0) throw new ArgumentException("Cạnh phải lớn hơn 0.");
                _a = value;
            }
        }
        public double B
        {
            get => _b;
            set
            {
                if (value <= 0) throw new ArgumentException("Cạnh phải lớn hơn 0.");
                _b = value;
            }
        }
        public double C
        {
            get => _c;
            set
            {
                if (value <= 0) throw new ArgumentException("Cạnh phải lớn hơn 0.");
                _c = value;
            }
        }

        public HinhTamGiac() { }
        public HinhTamGiac(double a, double b, double c) { A = a; B = b; C = c; }

        public bool IsTamGiac()
        {
            return A + B > C && A + C > B && B + C > A;
        }

        public double GetChuVi() => A + B + C;

        public double GetDienTich()
        {
            double p = GetChuVi() / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public void Nhap()
        {
            while (true)
            {
                Console.Write("Nhập cạnh a: ");
                var sa = Console.ReadLine();
                Console.Write("Nhập cạnh b: ");
                var sb = Console.ReadLine();
                Console.Write("Nhập cạnh c: ");
                var sc = Console.ReadLine();
                if (double.TryParse(sa, out double a) && double.TryParse(sb, out double b) && double.TryParse(sc, out double c)
                    && a > 0 && b > 0 && c > 0)
                {
                    A = a; B = b; C = c;
                    if (!IsTamGiac())
                    {
                        Console.WriteLine("Ba cạnh không tạo thành tam giác. Thử lại.");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Giá trị không hợp lệ. Thử lại.");
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"Hình tam giác: a={A}, b={B}, c={C}, Chu vi = {GetChuVi():F2}, Diện tích = {GetDienTich():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IHinh> ds = new List<IHinh>();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("--- Quản lý Hình ---");
                Console.WriteLine("1. Thêm Hình Tròn");
                Console.WriteLine("2. Thêm Hình Chữ Nhật");
                Console.WriteLine("3. Thêm Hình Tam Giác");
                Console.WriteLine("4. Hiển thị tất cả");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn (1-5): ");
                var c = Console.ReadLine();
                if (c == "5") break;
                try
                {
                    switch (c)
                    {
                        case "1":
                            var tron = new HinhTron();
                            tron.Nhap();
                            ds.Add(tron);
                            break;
                        case "2":
                            var cn = new HinhChuNhat();
                            cn.Nhap();
                            ds.Add(cn);
                            break;
                        case "3":
                            var tg = new HinhTamGiac();
                            tg.Nhap();
                            ds.Add(tg);
                            break;
                        case "4":
                            if (ds.Count == 0) Console.WriteLine("Chưa có hình nào.");
                            else
                            {
                                Console.WriteLine("Danh sách hình:");
                                foreach (var h in ds)
                                {
                                    h.HienThi();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
