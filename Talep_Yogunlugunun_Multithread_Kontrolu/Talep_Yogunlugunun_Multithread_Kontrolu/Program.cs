﻿using System;
using System.Windows.Forms;
using Talep_Yogunlugunun_Multithread_Kontrolu.UI;

namespace Talep_Yogunlugunun_Multithread_Kontrolu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShoppingMallInformationDisplay());
        }
    }
}