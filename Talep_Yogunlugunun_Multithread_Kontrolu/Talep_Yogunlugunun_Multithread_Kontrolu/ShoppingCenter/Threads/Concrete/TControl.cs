using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Concrete
{
    public class TControl : ITControl
    {
        private readonly object locked = new object();

        public bool ControlThread(Floor.Concrete.Floor[] floors, Elevator.Concrete.Elevator[] elevators, int capacity)
        {
            lock (locked)
            {
                var queueCount = floors[0].QueueCount + floors[1].QueueCount + floors[2].QueueCount +
                                 floors[3].QueueCount + floors[4].QueueCount;
                bool control = false;
                if (queueCount > (capacity * 2))
                    foreach (var elevator in elevators)
                        if (elevator.IsActive == false && elevator.GetCount() == 0)
                        {
                            elevator.IsActive = true;
                            control = true;
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
                            control = true;
                        }
                        i++;
                    }
                }
                return control;
            }
        }
    }
}