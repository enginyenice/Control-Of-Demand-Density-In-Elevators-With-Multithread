using ShoppingCenter.Threads.Concrete;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Elevator.Concrete;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Concrete;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Concrete;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.UI
{
    public partial class ShoppingMallInformationDisplay : Form
    {
        private readonly Elevator[] elevators = new Elevator[5];
        private readonly Floor[] floors = new Floor[5];
        private readonly Settings settings = new Settings();
        private readonly Thread loginThread;
        private readonly Thread controlThread;
        private readonly Thread exitThread;
        private readonly Thread elevatorThread0;
        private readonly Thread elevatorThread1;
        private readonly Thread elevatorThread2;
        private readonly Thread elevatorThread3;
        private readonly Thread elevatorThread4;
        private readonly Thread screenThread;

        public ShoppingMallInformationDisplay()
        {
            // Asansörlerin oluşturulması
            elevators[0] = new Elevator(0);
            elevators[1] = new Elevator(1);
            elevators[2] = new Elevator(2);
            elevators[3] = new Elevator(3);
            elevators[4] = new Elevator(4);

            // Katların oluşturulması
            floors[0] = new Floor(0);
            floors[1] = new Floor(1);
            floors[2] = new Floor(2);
            floors[3] = new Floor(3);
            floors[4] = new Floor(4);

            // 1. Asansörün hareketini aktifleştirir.
            loginThread = new Thread(LoginThread);
            controlThread = new Thread(ControlThread);
            exitThread = new Thread(ExitThread);
            elevatorThread0 = new Thread(() => ElevatorThread(elevators[0]));
            elevatorThread1 = new Thread(() => ElevatorThread(elevators[1]));
            elevatorThread2 = new Thread(() => ElevatorThread(elevators[2]));
            elevatorThread3 = new Thread(() => ElevatorThread(elevators[3]));
            elevatorThread4 = new Thread(() => ElevatorThread(elevators[4]));
            screenThread = new Thread(ScreenThread);
            elevators[0].IsActive = true; // 1. Asansör aktif edildi.
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ScreenThread()
        {
            while (true)
            {
                

                    GeneralInformation();
                    ElevatorInformation(elevators[0]);
                    ElevatorInformation(elevators[1]);
                    ElevatorInformation(elevators[2]);
                    ElevatorInformation(elevators[3]);
                    ElevatorInformation(elevators[4]);

                    
            }
        }

        private void ElevatorThread(Elevator elevator)
        {
            TElevator tElevator = new TElevator();
            while (true)
            {
                tElevator.ElevatorThread(elevator, floors, settings.Capacity,settings);

                Thread.Sleep(settings.Ms200);
            }
        }

        private void ControlThread()
        {
            TControl tControl = new TControl();
            while (true)
            {
                bool sleep = tControl.ControlThread(floors, elevators, settings.Capacity);
                if (sleep)
                    Thread.Sleep(settings.Ms500);
            }
        }

        private void ExitThread()
        {
            TExit tExit = new TExit();
            while (true)
            {
                tExit.ExitThread(floors, settings);

                Thread.Sleep(settings.Ms1000);
            }
        }

        private void LoginThread()
        {
            TLogin tLogin = new TLogin();
            while (true)
            {
                tLogin.LoginThread(floors, settings);
                Thread.Sleep(settings.Ms500);
            }
        }

        private void GeneralInformation()
        {
            LogoutThreadCount.Text = "AVM Çıkan Kişi Sayısı : " + settings.TotalLogoutCount;
            LoginThreadCount.Text = "Giriş Kuyruğu: " + settings.TotalLoginCount;
            ExitThreadCount.Text = "Çıkış Kuyruğu: " + settings.TotalExitCount;
            label90.Text = "Giriş - Çıkış: " + (settings.TotalLoginCount - settings.TotalExitCount);
            tbl1KisiSayisiZemin.Text = (floors[0].FloorCount + floors[0].QueueCount).ToString();
            tbl1KisiSayisiBir.Text = (floors[1].FloorCount + floors[1].QueueCount).ToString();
            tbl1KisiSayisiIki.Text = (floors[2].FloorCount + floors[2].QueueCount).ToString();
            tbl1KisiSayisiUc.Text = (floors[3].FloorCount + floors[3].QueueCount).ToString();
            tbl1KisiSayisiDort.Text = (floors[4].FloorCount + floors[4].QueueCount).ToString();

            tbl1KuyrukZemin.Text = floors[0].QueueCount.ToString();
            tbl1KuyrukBir.Text = floors[1].QueueCount.ToString();
            tbl1KuyrukIki.Text = floors[2].QueueCount.ToString();
            tbl1KuyrukUc.Text = floors[3].QueueCount.ToString();
            tbl1KuyrukDort.Text = floors[4].QueueCount.ToString();

            tbl2KuyrukZemin.Text = floors[0].FloorQueueString();
            tbl2KuyrukBir.Text = floors[1].FloorQueueString();
            tbl2KuyrukIki.Text = floors[2].FloorQueueString();
            tbl2KuyrukUc.Text = floors[3].FloorQueueString();
            tbl2KuyrukDort.Text = floors[4].FloorQueueString();
        }

        private void LabelColor(bool status, int count, Label label)
        {
            if (status == true)
            {
                label.Text = "Aktif";
                label.BackColor = Color.FromArgb(48, 164, 4);
                label.ForeColor = Color.White;
            }
            else if (status == false && count > 0)
            {
                label.Text = "Durduruluyor";
                label.BackColor = Color.FromArgb(77, 146, 184);
                label.ForeColor = Color.White;
            }
            else
            {
                label.Text = "Pasif";
                label.BackColor = Color.FromArgb(210, 66, 106);
                label.ForeColor = Color.White;
            }
        }

        private void ElevatorInformation(Elevator elevator)
        {
            lock (elevator)
            {
                string capacity = settings.Capacity.ToString();
                tbl3KapasiteSifir.Text = capacity;
                tbl3KapasiteBir.Text = capacity;
                tbl3KapasiteIki.Text = capacity;
                tbl3KapasiteUc.Text = capacity;
                tbl3KapasiteDort.Text = capacity;

                if (elevator.Name == 0)
                {
                    tbl3AsansorSifir.Text = elevator.Name.ToString();
                    LabelColor(elevator.IsActive, elevator.GetCount(), tbl3ModSifir);
                    tbl3KatSifir.Text = elevator.Floor.ToString();
                    tbl3HedefSifir.Text = elevator.Destination.ToString();
                    tbl3YonSifir.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                    tbl3AnlikSifir.Text = elevator.GetCount().ToString();
                    tbl3KuyrukSifir.Text = elevator.FloorCountString();
                }
                else if (elevator.Name == 1)
                {
                    tbl3AsansorBir.Text = elevator.Name.ToString();
                    LabelColor(elevator.IsActive, elevator.GetCount(), tbl3ModBir);
                    tbl3KatBir.Text = elevator.Floor.ToString();
                    tbl3HedefBir.Text = elevator.Destination.ToString();
                    tbl3YonBir.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                    tbl3AnlikBir.Text = elevator.GetCount().ToString();
                    tbl3KuyrukBir.Text = elevator.FloorCountString();
                }
                else if (elevator.Name == 2)
                {
                    tbl3AsansorIki.Text = elevator.Name.ToString();
                    LabelColor(elevator.IsActive, elevator.GetCount(), tbl3ModIki);
                    tbl3KatIki.Text = elevator.Floor.ToString();
                    tbl3HedefIki.Text = elevator.Destination.ToString();
                    tbl3YonIki.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                    tbl3AnlikIki.Text = elevator.GetCount().ToString();
                    tbl3KuyrukIki.Text = elevator.FloorCountString();
                }
                else if (elevator.Name == 3)
                {
                    tbl3AsansorUc.Text = elevator.Name.ToString();
                    LabelColor(elevator.IsActive, elevator.GetCount(), tbl3ModUc);
                    tbl3KatUc.Text = elevator.Floor.ToString();
                    tbl3HedefUc.Text = elevator.Destination.ToString();
                    tbl3YonUc.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                    tbl3AnlikUc.Text = elevator.GetCount().ToString();
                    tbl3KuyrukUc.Text = elevator.FloorCountString();
                }
                else
                {
                    tbl3AsansorDort.Text = elevator.Name.ToString();
                    LabelColor(elevator.IsActive, elevator.GetCount(), tbl3ModDort);
                    tbl3KatDort.Text = elevator.Floor.ToString();
                    tbl3HedefDort.Text = elevator.Destination.ToString();
                    tbl3YonDort.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                    tbl3AnlikDort.Text = elevator.GetCount().ToString();
                    tbl3KuyrukDort.Text = elevator.FloorCountString();
                }
            }
        }

        private void ShoppingMallInformationDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginThread.Abort();
            exitThread.Abort();
            controlThread.Abort();
            elevatorThread0.Abort();
            elevatorThread1.Abort();
            elevatorThread2.Abort();
            elevatorThread3.Abort();
            elevatorThread4.Abort();
            screenThread.Abort();
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {

            StartBtn.BackColor = Color.FromArgb(210, 66, 106);
            StartBtn.Text = "Çalışıyor...";
            StartBtn.Enabled = false;
            loginThread.Start();
            exitThread.Start();
            controlThread.Start();
            elevatorThread0.Start();
            elevatorThread1.Start();
            elevatorThread2.Start();
            elevatorThread3.Start();
            elevatorThread4.Start();
            screenThread.Start();
          
        }
        private void ShoppingMallInformationDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}