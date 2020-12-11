using System.Collections.Generic;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Floor.Abstract
{
    /// <summary>
    /// Alışveriş merkezinin katlarının bilgilerinin tutulduğu ve güncellendiği sınıf.
    /// </summary>
    public interface IFloor
    {
        /// <summary>
        /// Alışveriş merkezinde bulunan katın isminin güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// 0-> Zemin kat,1-2-3-4
        /// </returns>
        /// <param name="value">
        /// Katın ismi
        /// </param>
        int Name { get; set; }

        /// <summary>
        /// Katta bulunan müşteri sayısının güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// Katta bulunan müşteri sayısı
        /// </returns>
        /// <param name="value">
        /// Katta bulunan müşteri sayısı
        /// </param>
        int FloorCount { get; set; }

        /// <summary>
        /// Katın kuyruğunda bulunan müşteri sayısının güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// Katın kuyruğunda bulunan müşteri sayısı
        /// </returns>
        /// <param name="value">
        /// Katın kuyruğunda bulunan müşteri sayısı
        /// </param>
        int QueueCount { get; set; }

        /// <summary>
        /// Kuyruğun başındaki değerin güncellenmesi için kullanılan metot.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="floor">
        /// Gideceği kat
        /// </param>
        /// <param name="count">
        /// Gidecek müşteri sayısı
        /// </param>
        void RetryQueue(int floor, int count);

        /// <summary>
        /// Kat kuyruğunun toplam değerinden (QueueCount) parametre olarak gelen müşteri sayısını çıkart.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="count">
        /// Kat kuyruğunun toplam değerinden (QueueCount) çıkarılacak müşteri sayısı
        /// </param>
        void RemoveQueueFloor(int count);

        /// <summary>
        /// Kat kuyruğuna yeni eleman ekleme metodu.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="floor">
        /// Hedeflenen kat
        /// </param>
        /// <param name="count">
        /// Hedeflenen kata gidecek müşteri sayısı
        /// </param>
        void SetFloorQueue(int floor, int count);

        /// <summary>
        /// Kat kuyruğuna yeni eleman ekleme ve kuyruktaki toplam müşteri sayısını arttırma metodu.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="floor">
        /// Hedeflenen kat
        /// </param>
        /// <param name="count">
        /// Hedeflenen kata gidecek müşteri sayısı
        /// </param>
        void CreateFloorQueue(int floor, int count);

        /// <summary>
        /// Katta bulunan müşterileri belirli bir formatta string olarak geri döndürür
        /// </summary>
        /// <returns>
        /// [Gidilecek kat, Gidecek müşteri sayısı] ->[0,2] [1,2] [2,0] [3,0] [4,0]
        /// </returns>
        string FloorQueueString();

        /// <summary>
        /// Kuyruğu geriye döndürür.
        /// </summary>
        /// <returns>
        /// Katta bulunan kuyruğu geriye döndürür.
        /// </returns>
        Queue<string> GetFloorQueue();
    }
}