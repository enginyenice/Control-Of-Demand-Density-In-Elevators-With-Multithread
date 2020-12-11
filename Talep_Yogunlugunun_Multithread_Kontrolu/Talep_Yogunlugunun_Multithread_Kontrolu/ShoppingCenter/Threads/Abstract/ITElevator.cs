namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract
{
    public interface ITElevator
    {
        /// <summary>
        /// Katlardaki kuyrukları kontrol eder.
        /// Maksimum kapasiteyi aşmayacak şekilde kuyruktaki müşterilerin talep ettikleri katlarda
        /// taşınabilmesini sağlar. Bu thread asansör sayısı kadar (5 adet) olmalıdır.
        /// NOT: Zemin kattan diğer katlara (AVM’ye) giriş yapmak isteyenler,
        /// ya da diğer katlardan (AVM’den) çıkış yapmak isteyenler kuyruk oluştururlar.
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