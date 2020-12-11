using Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core;

namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Threads.Abstract
{
    public interface ITLogin
    {
        /// <summary>
        /// [1-10] arasında rastgele sayıda müşterinin AVM' ye giriş yapmasını sağlamaktadır (Zemin Kat).
        /// Giren müşterileri rastgele bir kata (1-4) gitmek için asansör kuyruğuna alır.
        /// </summary>
        /// <param name="floors">Alışveriş merkezinde bulunan tüm katların bilgilerinin dizi olarak belirtildiği parametre</param>
        /// <param name="settings">Alışveriş merkezinin genel ayarlarının bulunduğu sınıf</param>
        /// <returns>
        /// Dönüş Yok
        /// </returns>
        void LoginThread(Floor.Concrete.Floor[] floors, Settings settings);

        //Login Thread Function
    }
}