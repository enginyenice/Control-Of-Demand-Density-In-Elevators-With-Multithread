using ShoppingCenter.Core;
using ShoppingCenter.Elevator.Concrete;
using ShoppingCenter.Floor.Concrete;
using ShoppingCenter.Threads.Concrete;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace UI
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
            }
        }
        private void ElevatorThread(Elevator elevator)
        {
            TElevator tElevator = new TElevator();
            while (true)
            {
                tElevator.ElevetorThread(elevator, floors, settings.Capacity);
                ElevatorInformation(elevator);

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
                label89.Text = "Çıkış Kuyruğu: " + settings.TotalExitCount;
                Thread.Sleep(settings.Ms1000);
            }
        }
        private void LoginThread()
        {
            TLogin tLogin = new TLogin();
            while (true)
            {
                tLogin.LoginThread(floors, settings);
                label88.Text = "Giriş Kuyruğu: " + settings.TotalLoginCount;
                Thread.Sleep(settings.Ms500);
            }
        }
        private void GeneralInformation()
        {
            label6.Text = (floors[0].FloorCount + floors[0].QueueCount).ToString();
            label7.Text = (floors[1].FloorCount + floors[1].QueueCount).ToString();
            label8.Text = (floors[2].FloorCount + floors[2].QueueCount).ToString();
            label9.Text = (floors[3].FloorCount + floors[3].QueueCount).ToString();
            label10.Text = (floors[4].FloorCount + floors[4].QueueCount).ToString();

            label11.Text = floors[0].QueueCount.ToString();
            label12.Text = floors[1].QueueCount.ToString();
            label13.Text = floors[2].QueueCount.ToString();
            label14.Text = floors[3].QueueCount.ToString();
            label15.Text = floors[4].QueueCount.ToString();

            label76.Text = floors[0].FloorQueueString();
            label78.Text = floors[1].FloorQueueString();
            label80.Text = floors[2].FloorQueueString();
            label82.Text = floors[3].FloorQueueString();
            label83.Text = floors[4].FloorQueueString();
        }
        private void LabelColor(bool status,int count, Label label)
        {

            label.Text = (status == true) ? "Aktif" : "Pasif";

            if (status == true)
            {
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
                label.BackColor = Color.FromArgb(210, 66, 106);
                label.ForeColor = Color.White;
            }
        }
        private void ElevatorInformation(Elevator elevator)
        {
            string capacity = settings.Capacity.ToString();
            label34.Text = capacity;
            label43.Text = capacity;
            label52.Text = capacity;
            label61.Text = capacity;
            label70.Text = capacity;

            if (elevator.Name == 0)
            {
                label28.Text = elevator.Name.ToString();
                LabelColor(elevator.IsActive, elevator.GetCount(), label30);
                label31.Text = elevator.Floor.ToString();
                label32.Text = elevator.Destinational.ToString();
                label33.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label35.Text = elevator.GetCount().ToString();
                label27.Text = elevator.FloorCountString();
            }
            else if (elevator.Name == 1)
            {
                label37.Text = elevator.Name.ToString();
                LabelColor(elevator.IsActive, elevator.GetCount(), label39);
                label40.Text = elevator.Floor.ToString();
                label41.Text = elevator.Destinational.ToString();
                label42.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label44.Text = elevator.GetCount().ToString();
                label29.Text = elevator.FloorCountString();
            }
            else if (elevator.Name == 2)
            {
                label46.Text = elevator.Name.ToString();
                LabelColor(elevator.IsActive, elevator.GetCount(), label47);
                label49.Text = elevator.Floor.ToString();
                label50.Text = elevator.Destinational.ToString();
                label51.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label53.Text = elevator.GetCount().ToString();
                label36.Text = elevator.FloorCountString();
            }
            else if (elevator.Name == 3)
            {
                label55.Text = elevator.Name.ToString();
                LabelColor(elevator.IsActive, elevator.GetCount(), label48);
                label58.Text = elevator.Floor.ToString();
                label59.Text = elevator.Destinational.ToString();
                label60.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label62.Text = elevator.GetCount().ToString();
                label38.Text = elevator.FloorCountString();
            }
            else
            {
                label64.Text = elevator.Name.ToString();
                LabelColor(elevator.IsActive, elevator.GetCount(), label54);
                label67.Text = elevator.Floor.ToString();
                label68.Text = elevator.Destinational.ToString();
                label69.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label71.Text = elevator.GetCount().ToString();
                label45.Text = elevator.FloorCountString();
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
        private void ShoppingMallInformationDisplay_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
                button1.BackColor = Color.FromArgb(210, 66, 106);
                button1.Text = "Çalışıyor...";
                button1.Enabled = false;
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
    }
}