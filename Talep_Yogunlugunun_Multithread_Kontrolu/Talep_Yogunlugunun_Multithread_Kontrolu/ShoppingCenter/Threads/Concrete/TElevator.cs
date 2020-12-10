using System;
using ShoppingCenter.Threads.Abstract;

namespace ShoppingCenter.Threads.Concrete
{
    public class TElevator : ITElevator
    {
        public void ElevetorThread(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, int capacity)
        {

            if (elevator.Floor == 0 && elevator.Direction == false)
            {
                elevator.Direction = true;
                PassengerLowering(elevator, floors);
            } // Yolcuları indir ve yönü değiştir.

            if (elevator.Floor == 0 && elevator.Direction == true)
            {
                PassengerBoarding(elevator, floors, capacity);
                elevator.Destinational =
                    (elevator.GetFirstDestinational() == -1) ? 0 : elevator.GetFirstDestinational();
            } // Zemin katta bulunan yolduları asansöre bindir. Ve bir hedef belirlet.

            if (elevator.Floor == 4 && elevator.Direction == true)
            {
                PassengerLowering(elevator, floors);
                PassengerBoarding(elevator, floors, capacity);
                elevator.Direction = false;
                elevator.Destinational = CheckButtomFloor(floors, 4);


            }
            if (elevator.Floor > 0 && elevator.Floor < 4 &&  elevator.Direction == true)
            {
                if (elevator.Floor == elevator.Destinational)
                { // Başka hedef belirle
                    if (elevator.GetFirstDestinational() == -1)
                    {
                        if (CheckTopFloor(floors, elevator.Floor) == -1)
                        {
                            elevator.Direction = false;
                        }
                        else
                        {
                            elevator.Destinational = CheckTopFloor(floors, elevator.Floor);
                        }
                        
                    }
                    else
                    {
                        elevator.Destinational = elevator.GetFirstDestinational();
                    }
                    //Yolcuları indir
                    PassengerLowering(elevator, floors);
                }


                if (elevator.Floor > elevator.Destinational)
                {
                    elevator.Direction = false;
                }
            }
            if (elevator.Floor > 0 && elevator.Floor < 4 && elevator.Direction == false)
            {
                PassengerBoarding(elevator, floors, capacity); // Yolcuları al
                elevator.Destinational = CheckButtomFloor(floors, elevator.Floor); // Yeni hedef belirle
            }
           
            if(elevator.GetCount() > 0 || elevator.IsActive == true)
                FloorChange(elevator);

            //    /////////////////////////////////////////////
            //// Asansörden yolcu indirme işlemi
            //PassengerLowering(elevator, floors);
            //// Asansöre yolcu bindirme İşlemi
            //PassengerBoarding(elevator, floors, capacity);
            //// Asansör kat değiştirme işlemi
            //FloorChange(elevator);
        }

        private void FloorChange(Elevator.Concrete.Elevator elevator)
        {
            
            if (elevator.Direction == true)
            {
                elevator.Floor++;
            }

            if (elevator.Direction == false)
            {
                elevator.Floor--;
            }

        }

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

        private int CheckButtomFloor(Floor.Concrete.Floor[] floors, int elevatorFloor)
        {
            int isThere = 0; // Alt katta müşteri var mı
            for (int i = elevatorFloor; i >0; i--)
            {
                if (floors[i].QueueCount > 0)
                {
                    isThere = i;
                    break;
                }

            }

            return isThere;
        }

        private void PassengerLowering(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors)
        {
            if (elevator.GetCount() > 0)
                //İndirme işlemi
                if (elevator.GetFloorCount(elevator.Floor) > 0)
                {
                    if (elevator.Floor > 0)
                        floors[elevator.Floor].FloorCount = floors[elevator.Floor].FloorCount +
                                                            elevator.GetFloorCount(elevator
                                                                .Floor); // Kat Müşteri Arttır.

                    elevator.SetFloorCount(elevator.Floor,
                        -1 * elevator.GetFloorCount(elevator.Floor)); // Asansör Azaldı

                    if (elevator.IsActive == false && elevator.GetCount() == 0)
                    {
                        elevator.FloorCountClear();
                    }
                }
        }

        private void PassengerBoarding(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, int capacity)
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