using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract
{
    public interface ITExit
    {
        /// <summary>
        /// [1-5] arasında rastgele sayıda müşterinin
        /// AVM’den çıkış yapmasını sağlamaktadır (Zemin Kat). Çıkmak isteyen müşterileri
        /// rastgele bir kattan (1-4), zemin kata gitmek için asansör kuyruğuna alır.
        /// </summary>
        /// <param name="floors">Alışveriş merkezinde bulunan tüm katların bilgilerinin dizi olarak belirtildiği parametre</param>
        /// <param name="settings">Alışveriş merkezinin genel ayarlarının bulunduğu sınıf</param>
        /// <returns>
        /// Dönüş Yok
        /// </returns>
        void ExitThread(Floor.Concrete.Floor[] floors, Settings settings);
    }
}