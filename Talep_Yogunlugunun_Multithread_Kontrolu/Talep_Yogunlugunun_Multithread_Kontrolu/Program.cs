using System;
using System.Windows.Forms;
using UI;

namespace Talep_Yogunlugunun_Multithread_Kontrolu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShoppingMallInformationDisplay());
        }
    }
}
