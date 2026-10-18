using Quanlysinhvien.Views;

namespace Quanlysinhvien.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQuanlysv());
        }
    }
}
