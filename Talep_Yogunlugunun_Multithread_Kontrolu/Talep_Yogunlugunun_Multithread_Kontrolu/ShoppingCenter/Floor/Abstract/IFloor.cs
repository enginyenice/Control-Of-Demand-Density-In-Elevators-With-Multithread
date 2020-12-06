using System.Collections.Generic;

namespace ShoppingCenter.Floor.Abstract
{
    public interface IFloor
    {
        int Name { get; set; }

        //Kat ismi 0-> Zemin kat
        int FloorCount { get; set; }

        //Kattaki müşteri sayısı
        int QueueCount { get; set; }

        //Kuyruktaki müşteri sayısı

        void RetryQueue(int floor, int count);

        // Kuyruğun tekrar oluşturulması

        void RemoveQueueFloor(int count);

        //Kuyruktan müşteri sayısını çıkart
        void SetFloorQueue(int floor, int count);

        // Kuyruğa yeni bir veri ekle

        void CreateFloorQueue(int floor, int count);

        //Kuyruğa veri ekle ve kuyruktaki müşteri sayısını arttır.

        string FloorQueueString();

        //Kuyruğu metine dönüştür.

        Queue<string> GetFloorQueue();

        //Kuyruğu döndür.
    }
}