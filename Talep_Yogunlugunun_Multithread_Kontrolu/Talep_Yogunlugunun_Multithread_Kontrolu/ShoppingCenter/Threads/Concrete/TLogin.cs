﻿using System;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;
using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Concrete
{
    public class TLogin : ITLogin
    {
        public void LoginThread(Floor.Concrete.Floor[] floors, Settings settings)
        {
            var randomNumber = new Random();
            var count = randomNumber.Next(1, 10);
            floors[0].CreateFloorQueue(randomNumber.Next(1, 5), count);
            settings.TotalLoginCount = count;
        }
    }
}