using ShoppingCenter.Core;
using ShoppingCenter.Threads.Abstract;
using System;

namespace ShoppingCenter.Threads.Concrete
{
    public class TExit : ITExit
    {
        public void ExitThread(Floor.Concrete.Floor[] floors, Settings settings)
        {
            var randomNumber = new Random();
            var exitCustomerCount = randomNumber.Next(1, 5);
            var floor = randomNumber.Next(1, 5);
            while (floors[floor].FloorCount == 0)
            {
                floor = randomNumber.Next(1, 5);
            }

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