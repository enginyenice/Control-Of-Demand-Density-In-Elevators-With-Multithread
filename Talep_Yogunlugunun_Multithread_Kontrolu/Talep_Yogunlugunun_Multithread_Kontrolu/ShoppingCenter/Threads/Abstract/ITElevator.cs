namespace ShoppingCenter.Threads.Abstract
{
    public interface ITElevator
    {
        /// <summary>
        /// Asansörün genel işlevlerinin yerine getirildiği genel metot.
        /// Alışveriş merkezi içerisinde bulunan müşterilerin taşınmasını sağlar.
        /// </summary>
        /// <param name="elevator">Asansör nesnesi</param>
        /// <param name="floors">Alışveriş merkezinde bulunan tüm katların bilgilerinin dizi olarak belirtildiği parametre</param>
        /// <param name="capacity">Asansörün içerisinde bulunacak maksimum kişi sayısı</param>
        /// <returns>
        /// Dönüş Yok
        /// </returns>
        void ElevatorThread(Elevator.Concrete.Elevator elevator, Floor.Concrete.Floor[] floors, int capacity);
    }
}