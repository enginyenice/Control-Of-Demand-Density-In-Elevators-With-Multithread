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
        /// 200ms degerini tutar
        /// </summary>
        /// <returns>
        /// Varsayılan: 200
        /// </returns>
        public int Ms200 { get; }

        /// <summary>
        /// 500ms degerini tutar
        /// </summary>
        /// <returns>
        /// Varsayılan: 500
        /// </returns>
        public int Ms500 { get; }

        /// <summary>
        /// 1000ms degerini tutar
        /// </summary>
        /// <returns>
        /// Varsayılan: 1000
        /// </returns>
        public int Ms1000 { get; }

        private int totalLoginCount;
        private int totalExitCount;

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
        /// Alışveriş merkezinden çıkan toplam müşteri sayısını günceller ve döndürür
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
        /// Alışveriş merkezinin genel ayarlarının tutulduğu yapıcı metot.
        /// </summary>

        public Settings()
        {
            totalLoginCount = 0;
            totalExitCount = 0;
            Capacity = 10;
            Ms200 = 200;
            Ms500 = 500;
            Ms1000 = 1000;
        }
    }
}