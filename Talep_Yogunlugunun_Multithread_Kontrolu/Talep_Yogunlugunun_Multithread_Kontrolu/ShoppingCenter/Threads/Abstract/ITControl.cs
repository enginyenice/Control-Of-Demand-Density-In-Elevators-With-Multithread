namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract
{
    internal interface ITControl
    {
        /// <summary>
        /// Katlardaki kuyrukları kontrol eder.
        /// Kuyrukta bekleyen kişilerin toplam sayısı asansörün kapasitesinin
        /// 2 katını aştığı durumda (20) yeni asansörü aktif hale getirir.
        /// Kuyrukta bekleyen kişilerin toplam sayısı asansör kapasitenin altına indiğinde
        /// asansörlerden biri pasif hale gelir. Bu işlem tek asansörün çalıştığı durumda geçerli değildir.
        /// </summary>
        /// <returns>
        /// True: Asansör aktif edildi. False: Asansör aktif edilmedi.
        /// </returns>
        /// <param name="floors">
        /// Alışveris merkezinde bulunan tüm katların dizi hali
        /// </param>
        /// <param name="elevators">
        /// Alışveris merkezinde bulunan tüm asansörlerin dizi hali
        /// </param>
        /// <param name="capacity">
        /// Alışveriş merkezinde bulunan tüm asansörlerin maksimum müşteri kapasitesi
        /// </param>
        bool ControlThread(Floor.Concrete.Floor[] floors, Elevator.Concrete.Elevator[] elevators, int capacity);
    }
}