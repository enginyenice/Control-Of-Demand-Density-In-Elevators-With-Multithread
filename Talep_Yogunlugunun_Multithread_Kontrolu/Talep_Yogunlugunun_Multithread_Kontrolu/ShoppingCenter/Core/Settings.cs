namespace Talep_Yogunlugunun_Multithread_Kontrolu.ShoppingCenter.Core
{
    /// <summary>
    /// Genel ayarların yapıldığı sınıf
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Tüm asansörlerin kapasitesini belirtir.
        /// </summary>
        /// <returns>
        /// Varsayılan: 10
        /// </returns>
        public int Capacity { get; }

        /// <summary>
        /// Asansör(Elevator) thread hızını belirler.
        /// </summary>
        /// <returns>
        /// Varsayılan: 200
        /// </returns>
        public int ElevatorSpeed { get; }

        /// <summary>
        /// Giriş(Login) threadının hızını belirler.
        /// </summary>
        /// <returns>
        /// Varsayılan: 500
        /// </returns>
        public int LoginSpeed { get; }

        /// <summary>
        /// Çıkış(Exit) threadının hızını belirler.
        /// </summary>
        /// <returns>
        /// Varsayılan: 1000
        /// </returns>
        public int ExitSpeed { get; }

        private int totalLoginCount;
        private int totalExitCount;
        private int totalLogoutCount;

        /// <summary>
        /// Alışveriş merkezine giren toplam müşteri sayısını günceller ve döndürür
        /// </summary>
        /// <returns>
        /// Alışveriş merkezine giren müşteri sayısı
        /// </returns>
        /// <param name="value">
        /// Alışveriş merkezine anlık olarak giren toplam müşteri sayısı
        /// </param>
        public int TotalLoginCount
        {
            get { return totalLoginCount; }
            set { totalLoginCount += value; }
        }

        /// <summary>
        /// Alışveriş merkezinden çıkan ve çıkmak için kuyruğa giren toplam müşteri sayısını günceller ve döndürür
        /// </summary>
        /// <returns>
        /// Alışveriş merkezinden çıkan toplam müşteri sayısı
        /// </returns>
        /// <param name="value">
        /// Alışveriş merkezinden anlık olarak çıkan müşteri sayısı
        /// </param>
        public int TotalExitCount
        {
            get { return totalExitCount; }
            set { totalExitCount += value; }
        }

        /// <summary>
        /// Alışveriş merkezinden çıkan toplam müşteri sayısını günceller ve döndürür
        /// </summary>
        /// <returns>
        /// Alışveriş merkezinden çıkan toplam müşteri sayısı
        /// </returns>
        /// <param name="value">
        /// Alışveriş merkezinden anlık olarak çıkan müşteri sayısı
        /// </param>
        public int TotalLogoutCount
        {
            get { return totalLogoutCount; }
            set { totalLogoutCount += value; }
        }

        /// <summary>
        /// Alışveriş merkezinin genel ayarlarının tutulduğu yapıcı metot.
        /// </summary>
        public Settings()
        {
            totalLoginCount = 0;
            totalExitCount = 0;
            Capacity = 10;
            ElevatorSpeed = 200 * 1;
            LoginSpeed = 500 * 1;
            ExitSpeed = 1000 * 1;
        }
    }
}