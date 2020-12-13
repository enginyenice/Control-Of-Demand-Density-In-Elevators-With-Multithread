namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Elevator.Abstract
{
    public interface IElevator
    {
        /// <summary>
        /// Asansörün isminin güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// Asansörün ismi
        /// </returns>
        /// <param name="value">
        /// Asansörün ismi
        /// </param>
        int Name { get; set; }

        /// <summary>
        /// Asansörün çalışıp çalışmadığının bilgisinin güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// True: Asansör aktif. False: Asansör pasif
        /// </returns>
        /// <param name="value">
        /// Asansörün o anlık durumu
        /// </param>
        bool IsActive { get; set; }

        /// <summary>
        /// Asansörün gitmek için hedeflediği katın bilgisinin güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// 0-> Zemin Kat, 1-2-3-4 Diğer katlar.
        /// </returns>
        /// <param name="value">
        /// Asansörün hedeflediği kat
        /// </param>
        int Destination { get; set; }

        /// <summary>
        /// Asansörün gidece yönü belirtir ve  güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// True: Yukarı, False: Aşağı
        /// </returns>
        /// <param name="value">
        /// Asansörün gideceği yön: True: Yukarı, False: Aşağı
        /// </param>
        bool Direction { get; set; }

        /// <summary>
        /// Asansörün bulunduğu katı belirtir ve  güncellenmesi ve getirilmesi işlemini yapar.
        /// </summary>
        /// <returns>
        /// 0-> Zemin Kat, 1-2-3-4 Diğer katlar.
        /// </returns>
        /// <param name="value">
        /// Bulunduğu kat
        /// </param>
        int Floor { get; set; }

        /// <summary>
        /// Asansörde bulunan müşteri sayısını günceller.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="floor">
        /// Gidilecek kat
        /// </param>
        /// <param name="count">
        /// Gidecek müşteri sayısı
        /// </param>
        void SetFloorCount(int floor, int count);

        /// <summary>
        /// Asansörde bulunan müşterileri belirli bir formatta string olarak geri döndürür
        /// </summary>
        /// <returns>
        /// [Gidilecek kat, Gidecek müşteri sayısı] ->[0,2] [1,2] [2,0] [3,0] [4,0]
        /// </returns>
        string FloorCountString();

        /// <summary>
        /// Parametre olarak gönderilen katta inecek kişi sayısını geriye döndürür.
        /// </summary>
        /// <returns>
        /// İnecek kişi sayısı
        /// </returns>
        /// <param name="floor">
        /// Hangi katta inilecek müşteri sayısı getirilsin.
        /// </param>
        int GetFloorCount(int floor);

        /// <summary>
        /// Asansörde bulunan tüm müşterileri temizler.
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        void FloorCountClear();

        /// <summary>
        /// Asansör içerisinde kaç adet müşteri olduğunu döndürür.
        /// </summary>
        /// <returns>
        /// Asansör içerisinde bulunan müşteri sayısı
        /// </returns>
        int GetCount();

        /// <summary>
        /// Bulunduğu kata en yakın hedefi belirler.
        /// </summary>
        /// <returns>
        /// Hedeflenen kat
        /// </returns>
        int GetFirstDestination();
    }
}