﻿using System;
using System.Threading;
using System.Windows.Forms;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Elevator.Concrete;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Concrete;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.UI
{
    public partial class ShoppingMallInformationDisplay : Form
    {
        private readonly int capacity = 10;
        private int ms200 = 200;
        private int ms500 = 500;
        private int ms1000 = 1000;
        private readonly Elevator[] elevators = new Elevator[5];
        private readonly Floor[] floors = new Floor[5];


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
            elevators[0].IsActive = true; // 1. Asansör aktif edildi.
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();


        }

        private void ShoppingMallInformationDisplay_Load(object sender, EventArgs e)
        {
            var loginThread = new Thread(LoginThread);
            var controlThread = new Thread(ControlThread);
            var exitThread = new Thread(ExitThread);
            var elevatorThread0 = new Thread(() => ElevatorThread(elevators[0]));
            var elevatorThread1 = new Thread(() => ElevatorThread(elevators[1]));
            var elevatorThread2 = new Thread(() => ElevatorThread(elevators[2]));
            var elevatorThread3 = new Thread(() => ElevatorThread(elevators[3]));
            var elevatorThread4 = new Thread(() => ElevatorThread(elevators[4]));
           
            
            loginThread.Start();
            exitThread.Start();
            controlThread.Start();



            elevatorThread0.Start();
            elevatorThread1.Start();
            elevatorThread2.Start();
            elevatorThread3.Start();
            elevatorThread4.Start();

            // floors[1].SetFloorQueue(1,5);
            // floors[1].SetFloorQueue(2,5);
            // floors[1].SetFloorQueue(3,5);
            // floors[1].SetFloorQueue(4,5);

            //floors[2].SetFloorQueue(1, 5);
            //floors[2].SetFloorQueue(2, 5);
            //floors[2].SetFloorQueue(3, 5);
            //floors[2].SetFloorQueue(4, 5);

            //floors[3].SetFloorQueue(1, 5);
            //floors[3].SetFloorQueue(2, 5);
            //floors[3].SetFloorQueue(3, 5);
            //floors[3].SetFloorQueue(4, 5);

            //floors[4].SetFloorQueue(1, 5);
            //floors[4].SetFloorQueue(2, 5);
            //floors[4].SetFloorQueue(3, 5);
            //floors[4].SetFloorQueue(4, 5);




            //floors[0].FloorCount = 0;
            //floors[1].FloorCount = 25;
            //floors[2].FloorCount = 25;
            //floors[3].FloorCount = 25;
            //floors[4].FloorCount = 25;


        }

        private void ElevatorThread(Elevator elevator)
        {
            while (true)
            {

                if (elevator.GetCount() != 0)
                {
                    //İndirme işlemi
                    if (elevator.GetFloorCount(elevator.Floor) > 0)
                    {

                        if (elevator.Floor > 0)
                            floors[elevator.Floor].FloorCount += elevator.GetFloorCount(elevator.Floor); // Kat Müşteri Arttı.

                        elevator.SetFloorCount(elevator.Floor, (-1) * elevator.GetFloorCount(elevator.Floor)); // Asansör Azaldı


                        if (elevator.IsActive == false && elevator.GetCount() == 0)
                        {
                            elevator.Floor = 0;
                            elevator.Direction = true;
                            elevator.floorCountClear();
                            
                        }
                    }
                }





















                if (elevator.IsActive == true) // Asansör Aktif Mi ?
                {
                    ControlGoTo:
                    if (elevator.GetCount() <= capacity) // Asansörde Yer Var Mı ? 
                    {
                        if (floors[elevator.Floor].QueueCount > 0) // Bulunduğu katta kuyruk var mı ? 
                        {
                            string[] queueSplit = floors[elevator.Floor].GetFloorQueue().Peek().Split(',');

                            int floor = Int32.Parse(queueSplit[0]);
                            int count = Int32.Parse(queueSplit[1]);

                            // Asansördeki müşteriler ile kattaki müşteriler eklendiğinde asansöre sığmıyorsa
                            if (elevator.GetCount() + count > capacity)
                            {
                                int maxCustomer = capacity - elevator.GetCount(); // Maksimum alacağı kişi sayısı
                                int remainingCustomer = count - elevator.GetCount(); // Katta kalan müşteri sayısı
                               
                                elevator.SetFloorCount(0, maxCustomer);  // 0'a inecek müşterileri ekle.
                                floors[elevator.Floor].RetryQueue(0,maxCustomer);
                                floors[elevator.Floor].GetFloorQueue().Dequeue(); // Kuyruktan müşteriyi sil.
                                floors[elevator.Floor].RemoveQueueFloor(remainingCustomer); // Kat kuyruğundan müşteri sayısını çıkart.
                            }
                            // Asansördeki müşteriler ile kattaki müşteriler eklendiğinde asansöre sığıyorsa
                            else
                            {
                                elevator.SetFloorCount(0,count); // 0'a inecek müşterileri ekle.
                                floors[elevator.Floor].GetFloorQueue().Dequeue(); // Kuyruktan müşteriyi sil.
                                floors[elevator.Floor].RemoveQueueFloor(count); // Kat kuyruğundan müşteri sayısını çıkart.
                            }

                            goto ControlGoTo;

                        }
                    }
                    else
                    {
                        break;
                    }
                }












                
                   if (elevator.GetCount() > 0 || elevator.IsActive == true)
                     Console.WriteLine("Name: {0} Direction: {1} Status: {2} Count: {3} FloorCount: {4} Floor: {5}", elevator.Name, elevator.Direction, elevator.IsActive, elevator.GetCount(), elevator.FloorCountString(), elevator.Floor);

                


                if (elevator.GetCount() > 0 || elevator.IsActive == true)
                {
                   


                if (elevator.Direction == true)
                {
                    if (elevator.Floor < 4)
                    {
                        ++elevator.Floor;
                        elevator.Destinational = elevator.Floor + 1;
                    }
                    else
                    {
                        --elevator.Floor;
                        elevator.Destinational = elevator.Floor - 1;
                        elevator.Direction = false;

                    }
                }

                if (elevator.Direction == false)
                {
                    if (elevator.Floor != 0)
                    {
                        --elevator.Floor;
                        elevator.Destinational = elevator.Floor - 1;
                    }
                    else
                    {
                        ++elevator.Floor;
                        elevator.Destinational = elevator.Floor + 1;
                        elevator.Direction = true;
                    }
                }

                AsansorVeBilgileri(elevator);

                }




                SistemBilgileri();
                Thread.Sleep(ms200);
            }
        }
        private void SistemBilgileri()
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

            /*
            label76.Text = floors[0].FloorQueueString();
            label78.Text = floors[1].FloorQueueString();
            label80.Text = floors[2].FloorQueueString();
            label82.Text = floors[3].FloorQueueString();
            label83.Text = floors[4].FloorQueueString();
            */
        }
        private void AsansorVeBilgileri(Elevator elevator)
        {
            if (elevator.Name == 0)
            {
                label28.Text = elevator.Name.ToString();
                label30.Text = (elevator.IsActive == true) ? "Çalışıyor" : "Beklemede";
                label31.Text = elevator.Floor.ToString();
                label32.Text = Destination(elevator.Floor,elevator.Direction).ToString();
                label33.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label35.Text = elevator.GetCount().ToString();
                label27.Text = elevator.FloorCountString();
            } else if (elevator.Name == 1)
            {
                label37.Text = elevator.Name.ToString();
                label39.Text = (elevator.IsActive == true) ? "Çalışıyor" : "Beklemede";
                label40.Text = elevator.Floor.ToString();
                label41.Text = Destination(elevator.Floor, elevator.Direction).ToString();
                label42.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label44.Text = elevator.GetCount().ToString();
                label29.Text = elevator.FloorCountString();

            } else if (elevator.Name == 2)
            {
                label46.Text = elevator.Name.ToString();
                label47.Text = (elevator.IsActive == true) ? "Çalışıyor" : "Beklemede";
                label49.Text = elevator.Floor.ToString();
                label50.Text = Destination(elevator.Floor, elevator.Direction).ToString();
                label51.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label53.Text = elevator.GetCount().ToString();
                label36.Text = elevator.FloorCountString();
            }
            else if (elevator.Name == 3)
            {
                label55.Text = elevator.Name.ToString();
                label48.Text = (elevator.IsActive == true) ? "Çalışıyor" : "Beklemede";
                label58.Text = elevator.Floor.ToString();
                label59.Text = Destination(elevator.Floor, elevator.Direction).ToString();
                label60.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label62.Text = elevator.GetCount().ToString();
                label38.Text = elevator.FloorCountString();
            }
            else
            {
                label64.Text = elevator.Name.ToString();
                label54.Text = (elevator.IsActive == true) ? "Çalışıyor" : "Beklemede";
                label67.Text = elevator.Floor.ToString();
                label68.Text = Destination(elevator.Floor, elevator.Direction).ToString();
                label69.Text = (elevator.Direction == true) ? "Yukarı" : "Aşağı";
                label71.Text = elevator.GetCount().ToString();
                label45.Text = elevator.FloorCountString();
            }

        }
        private int Destination(int floor, bool direction)
        {
            if (floor == 4)
                return 3;
            if (floor == 0)
                return 1;

            if (direction == true)
                return floor + 1;
            else
                return floor - 1;


        }
        private void ControlThread()
        {
            while (true)
            {
                var queueCount = floors[0].QueueCount + floors[1].QueueCount + floors[2].QueueCount +
                                 floors[3].QueueCount + floors[4].QueueCount;

                if (queueCount > capacity * 2)
                    foreach (var elevator in elevators)
                        if (elevator.IsActive == false)
                        {
                            //Console.WriteLine("Asansör Aktif Edildi");
                            elevator.IsActive = true;
                            break;
                        }

                if (queueCount < capacity)
                {
                    var i = 0;
                    foreach (var elevator in elevators)
                    {
                        if (elevator.IsActive && i != 0)
                        {
                            //   Console.WriteLine("Asansör Pasif Edildi");
                            
                            elevator.IsActive = false;
                        }

                        i++;
                    }
                }


                Thread.Sleep(ms500);
            }
        }
        private void ExitThread()
        {
            var randomNumber = new Random();
            while (true)
            {
                NoExit:
                var exitCustomerCount = randomNumber.Next(1, 5);
                var floor = randomNumber.Next(1, 5);

                if (floors[floor].FloorCount > 0)
                {
                    if (floors[floor].FloorCount > exitCustomerCount)
                    {
                        floors[floor].SetFloorQueue(0, exitCustomerCount);
                    }

                    else
                    {
                        floors[floor].SetFloorQueue(0, floors[floor].FloorCount);
                    }
                }
                else
                {
                    goto NoExit;
                }
                SistemBilgileri();
                Thread.Sleep(ms1000);
            }
        }
        private void LoginThread()
        {
            
            var randomNumber = new Random();
            while (true)
            {
                
                var count = randomNumber.Next(1, 10);
                floors[0].CreateFloorQueue(randomNumber.Next(1, 4), count);
                SistemBilgileri();
                Thread.Sleep(ms500);
            }

            // ReSharper disable once FunctionNeverReturns
        }
    }
}