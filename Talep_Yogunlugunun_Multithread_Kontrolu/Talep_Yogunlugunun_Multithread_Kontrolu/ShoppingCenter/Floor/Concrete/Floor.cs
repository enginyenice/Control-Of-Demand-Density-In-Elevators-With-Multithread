using System.Collections.Generic;
using System.Linq;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Abstract;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Concrete
{
    public class Floor :IFloor // Kat
    {
        public int Name { get; set; }
        public int FloorCount { get; set; }
        public int QueueCount { get; set; }
        private readonly Queue<string> floorQueue;


        public Floor(int name)
        {
            this.Name = name;
            this.FloorCount = 0;
            this.QueueCount = 0;
            this.floorQueue = new Queue<string>();
        }


        public void RetryQueue(int floor, int count)
        {
            if(floorQueue.Count != 0)
            {


                this.QueueCount = count; // // Kalan müşterisi güncelle
                var items = floorQueue.ToArray();
            floorQueue.Clear();

            floorQueue.Enqueue(floor+","+count);
            foreach (var item in items)
                floorQueue.Enqueue(item);
            }
        }

        public void RemoveQueueFloor(int count)
        {
            this.QueueCount -= count;
        }

        public void SetFloorQueue(int floor, int count)
        {
            QueueCount += count;
            FloorCount -= count;
            floorQueue.Enqueue(floor + "," + count);
        }

        public void CreateFloorQueue(int floor, int count)
        {
            QueueCount += count;
            floorQueue.Enqueue(floor + "," + count);
        }




        public string FloorQueueString()
        {
            if(floorQueue.Count > 0)
            {
                string queueList = "";
                foreach (string queue in GetFloorQueue())
            {
                queueList += "[" + queue + "] ";
            }
            return queueList;
            }
            else
            {
                return "";
            }
            
        }

        public Queue<string> GetFloorQueue()
        {

            return floorQueue;
        }

    }
}
