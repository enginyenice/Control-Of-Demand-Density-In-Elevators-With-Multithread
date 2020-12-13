using System;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Concrete
{
    public class TElevator : ITElevator
    {
        public void ElevatorThread(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, int capacity, Settings settings)
        {
            lock (elevator)
            {
                if (elevator.IsActive)
                {
                    PassengerLowering(elevator, floors, settings);
                    PassengerBoarding(elevator, floors, capacity);
                }
                else if (elevator.IsActive == false && elevator.GetCount() > 0)
                {
                    PassengerLowering(elevator, floors, settings);
                }
            }

            lock (elevator)
            {
                if (elevator.Destination == elevator.Floor)
                {
                    if (elevator.GetFirstDestination() != -1) elevator.Destination = elevator.GetFirstDestination();
                    else if (CheckTopFloor(floors, elevator.Floor) > 0 && elevator.Direction == true)
                        elevator.Destination = CheckTopFloor(floors, elevator.Floor);
                    else if (CheckButtomFloor(floors, elevator.Floor) > 0 && elevator.Direction == false)
                        elevator.Destination = CheckButtomFloor(floors, elevator.Floor);
                    else elevator.Destination = 0;

                    if (elevator.Floor < elevator.Destination) elevator.Direction = true;
                    else elevator.Direction = false;
                }
            }

            lock (elevator)
            {
                if (elevator.GetCount() > 0 || elevator.IsActive == true)
                    FloorChange(elevator);
            }
        }

        /// <summary>
        /// Asansörün kat arttırma ve azaltma işlemi
        /// </summary>
        /// <param name="elevator">Asansör</param>
        private void FloorChange(Elevator.Concrete.Elevator elevator)
        {
            lock (elevator)
            {
                if (elevator.Direction == true)
                {
                    elevator.Floor++;
                }

                if (elevator.Direction == false)
                {
                    elevator.Floor--;
                }

                if (elevator.Floor < 0)
                {
                    elevator.Floor = 0;
                    elevator.Direction = false;
                }
            }
        }

        /// <summary>
        /// Bulunduğu katın üstündeki katları kontrol eder. Zemin kata inecek müşteri varsa hedef olarak onu belirler
        /// </summary>
        /// <param name="floors">AVM içerisinde bulunan tüm katlar</param>
        /// <param name="maxDestinationalFloor">Asansörün şuan bulunduğu kat</param>
        /// <returns>-1 Hedef yok. 0+ durumda hedef olarak belirler </returns>
        private int CheckTopFloor(Floor.Concrete.Floor[] floors, int maxDestinationalFloor)
        {
            int isThere = -1; // Üst katta müşteri var mı
            for (int i = maxDestinationalFloor; i < floors.Length; i++)
            {
                if (floors[i].QueueCount > 0)
                {
                    isThere = i;
                    break;
                }
            }

            return isThere;
        }

        /// <summary>
        /// Bulunduğu katın altındaki katları kontrol eder. Zemin kata inecek Müşteri varsa hedef olarak onu belirler
        /// </summary>
        /// <param name="floors">AVM içerisinde bulunan tüm katlar</param>
        /// <param name="elevatorFloor">Asansörün şuan bulunduğu kat</param>
        /// <returns>-1 Hedef yok. 0+ durumda hedef olarak belirler </returns>
        private int CheckButtomFloor(Floor.Concrete.Floor[] floors, int elevatorFloor)
        {
            int isThere = -1; // Alt katta müşteri var mı
            for (int i = elevatorFloor; i > 0; i--)
            {
                if (floors[i].QueueCount > 0)
                {
                    isThere = i;
                    break;
                }
            }

            return isThere;
        }


        /// <summary>
        /// Asansör içerisindeki müşterileri bulundukları katlara geldiğinde indirme işlemini yapar
        /// </summary>
        /// <param name="elevator">Asansör</param>
        /// <param name="floors">AVM içerisinde bulunan tüm katlar</param>
        /// <param name="settings">Genel ayarlar</param>
        private void PassengerLowering(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, Settings settings)
        {
            if (elevator.GetCount() > 0)
                //İndirme işlemi
                if (elevator.GetFloorCount(elevator.Floor) > 0)
                {
                    if (elevator.Floor > 0)
                        floors[elevator.Floor].FloorCount = floors[elevator.Floor].FloorCount +
                                                            elevator.GetFloorCount(elevator
                                                                .Floor); // Kat Müşteri Arttır.
                    if (elevator.Floor == 0)
                    {
                        settings.TotalLogoutCount = elevator.GetFloorCount(elevator.Floor);
                    }

                    elevator.SetFloorCount(elevator.Floor,
                        -1 * elevator.GetFloorCount(elevator.Floor)); // Asansör Azaldı
                }
        }

        /// <summary>
        ///  Bulunduğu katın kuyruğunda müşteri varsa müşteriyi asansörün kapasitesine uygun olacak şekilde asansöre alır.
        /// </summary>
        /// <param name="elevator">Asansör</param>
        /// <param name="floors">AVM içerisinde bulunan tüm katlar</param>
        /// <param name="capacity">Asansörün maksimum taşıyacağı müşteri sayısı</param>
        private void PassengerBoarding(Elevator.Concrete.Elevator elevator,Floor.Concrete.Floor[] floors, int capacity)
        {
            if (elevator.IsActive)
            {
            // Asansör aktif mi?

            ElevetorControl:
                lock (floors[elevator.Floor].GetFloorQueue())
                {
                    if (floors[elevator.Floor].GetFloorQueue().Count > 0)
                    {
                        string[] queueSplit;
                        // Katta kuyruk var mı
                        lock (floors[elevator.Floor].GetFloorQueue())
                        {
                            queueSplit = floors[elevator.Floor].GetFloorQueue().Peek().Split(','); // Kuyruk
                        }
                        var floor = int.Parse(queueSplit[0]); // Hedef kat
                        var count = int.Parse(queueSplit[1]); // Müşteri Sayısı

                        if (elevator.GetCount() + count > capacity)
                        {
                            // Kuyruktaki müşteri sayısı ile asansördeki müşteri sayısının toplamı kapasiteden büyük mü?

                            try
                            {
                                floors[elevator.Floor].GetFloorQueue().Dequeue(); //Müşteriyi kuyruktan sil.

                                var maxCustomer = capacity - elevator.GetCount(); // Maksimum alacağı kişi sayısı
                                var remainingCustomer = count - maxCustomer; // Katta kalan müşteri sayısı
                                elevator.SetFloorCount(floor, maxCustomer); // Müşteriyi asansöre al
                                floors[elevator.Floor]
                                    .RemoveQueueFloor(maxCustomer); // Kat kuyruğundan müşteri sayısını çıkart.
                                floors[elevator.Floor]
                                    .RetryQueue(floor,
                                        remainingCustomer); // Kalan müşteriyi sıranın başına koyacak şekilde kuyruğu güncelle
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            try
                            {
                                floors[elevator.Floor].GetFloorQueue().Dequeue();
                                elevator.SetFloorCount(floor, count); // Müşteriyi asansöre al
                                floors[elevator.Floor]
                                    .RemoveQueueFloor(count); // Kat kuyruğundan müşteri sayısını çıkart.
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                    }

                    if (elevator.GetCount() != capacity && floors[elevator.Floor].QueueCount > 0)
                        // Asansörde yer varsa ve kuyrukta bekleyen müşteri varsa
                        goto ElevetorControl;
                }
            }
        }
    }
}