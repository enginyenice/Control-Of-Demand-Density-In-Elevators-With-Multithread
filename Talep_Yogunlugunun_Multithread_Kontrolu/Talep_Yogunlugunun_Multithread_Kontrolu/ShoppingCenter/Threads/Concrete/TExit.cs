using System;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Concrete;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract;

namespace ShoppingCenter.Threads.Concrete
{
    public class TExit : ITExit
    {
        public void ExitThread(Floor[] floors, Settings settings)
        {
            var randomNumber = new Random();
            var exitCustomerCount = randomNumber.Next(1, 6);
            var floor = randomNumber.Next(1, 5);

            if (floors[floor].FloorCount > 0)
            {
                if (floors[floor].FloorCount > exitCustomerCount)
                {
                    settings.TotalExitCount = exitCustomerCount;
                    floors[floor].SetFloorQueue(0, exitCustomerCount);
                }
                else
                {
                    settings.TotalExitCount = floors[floor].FloorCount;
                    floors[floor].SetFloorQueue(0, floors[floor].FloorCount);
                }
            }
        }
    }
}