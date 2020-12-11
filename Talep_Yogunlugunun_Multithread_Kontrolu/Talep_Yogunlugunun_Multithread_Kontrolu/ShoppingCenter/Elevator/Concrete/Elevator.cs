using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Elevator.Abstract;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Elevator.Concrete
{
    public class Elevator : IElevator // Asansör
    {
        public int Name { get; set; }
        private int Count;
        public bool IsActive { get; set; }
        public int Destination { get; set; }

        public bool Direction { get; set; } // (+) True (-) False
        public int Floor { get; set; } // 0-1-2-3-4
        private static readonly object Kontrol = new object();
        private readonly int[] floorCount; // Katlarda inecek kişi sayısı

        public Elevator(int name)
        {
            this.Destination = 1;
            this.Floor = 0;
            this.Count = 0;
            this.Direction = true;
            this.Name = name;
            this.IsActive = false;
            this.floorCount = new int[5];
            floorCount[0] = 0;
            floorCount[1] = 0;
            floorCount[2] = 0;
            floorCount[3] = 0;
            floorCount[4] = 0;
        }

        public void SetFloorCount(int floor, int count)
        {
            lock (Kontrol)
            {
                this.floorCount[floor] += count;
                this.Count += count;
            }
        }

        public string FloorCountString()
        {
            lock (Kontrol)
            {
                string queueList = "";
                for (int i = 0; i < floorCount.Length; i++)
                {
                    queueList += "[" + i + "," + floorCount[i] + "]";
                }
                return queueList;
            }
        }

        public int GetFloorCount(int floor)
        {
            return this.floorCount[floor];
        }

        public void FloorCountClear()
        {
            lock (Kontrol)
            {
                floorCount[0] = 0;
                floorCount[1] = 0;
                floorCount[2] = 0;
                floorCount[3] = 0;
                floorCount[4] = 0;
                Count = 0;
            }
        }

        public int GetCount()
        {
            lock (Kontrol)
            {
                int count = 0;
                foreach (var t in floorCount)
                    count += t;

                this.Count = count;
                return Count;
            }
        }

        public int GetFirstDestination()
        {
            int firstDestinationalFloor = -1;
            for (int i = Floor; i < floorCount.Length; i++)
            {
                if (floorCount[i] > 0 && Floor != i)
                {
                    firstDestinationalFloor = i;
                    break;
                }
            }

            return firstDestinationalFloor;
        }
    }
}