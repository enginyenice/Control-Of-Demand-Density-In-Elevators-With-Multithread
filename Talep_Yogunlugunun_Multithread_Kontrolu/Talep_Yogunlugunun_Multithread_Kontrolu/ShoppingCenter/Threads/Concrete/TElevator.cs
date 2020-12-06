namespace ShoppingCenter.Threads.Concrete
{
    public class TElevator
    {
        public void ElevetorThread(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, int capacity)
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

            // Asansöre Bindirme İşlemii
            if (elevator.IsActive)
            {
            // Asansör aktif mi?

            ElevetorControl:
                if (floors[elevator.Floor].GetFloorQueue().Count > 0)
                {
                    // Katta kuyruk var mı

                    var queueSplit = floors[elevator.Floor].GetFloorQueue().Peek().Split(','); // Kuyruk

                    var floor = int.Parse(queueSplit[0]); // Hedef kat
                    var count = int.Parse(queueSplit[1]); // Müşteri Sayısı

                    if (elevator.GetCount() + count > capacity)
                    {
                        // Kuyruktaki müşteri sayısı ile asansördeki müşteri sayısının toplamı kapasiteden büyük mü?

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
                    else
                    {
                        floors[elevator.Floor].GetFloorQueue().Dequeue();

                        elevator.SetFloorCount(floor, count); // Müşteriyi asansöre al
                        floors[elevator.Floor]
                            .RemoveQueueFloor(count); // Kat kuyruğundan müşteri sayısını çıkart.
                    }
                }

                if (elevator.GetCount() != capacity && floors[elevator.Floor].QueueCount > 0)
                    // Asansörde yer varsa ve kuyrukta bekleyen müşteri varsa
                    goto ElevetorControl;
            }

            if (elevator.GetCount() > 0 || elevator.IsActive || elevator.Floor > 0)
            {
                if (elevator.Direction)
                {
                    if (elevator.Floor < 3)
                    {
                        elevator.Floor += 1;
                        elevator.Destinational = elevator.Floor + 1;
                    }
                    else
                    {
                        elevator.Floor += 1;
                        elevator.Destinational = 3;
                        elevator.Direction = false;
                    }
                }
                else if (elevator.Direction == false)
                {
                    if (elevator.Floor > 1)
                    {
                        elevator.Floor -= 1;
                        elevator.Destinational = elevator.Floor - 1;
                    }
                    else
                    {
                        elevator.Floor -= 1;
                        elevator.Destinational = 1;
                        elevator.Direction = true;
                    }
                }
            }
        }
    }
}