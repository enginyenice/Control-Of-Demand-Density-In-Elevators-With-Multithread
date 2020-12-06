namespace ShoppingCenter.Elevator.Abstract
{
    public interface IElevator
    {
        int Name { get; set; }
        //Asansörün ismi

        bool IsActive { get; set; }
        //Asansör aktif mi?

        int Destinational { get; set; }
        //Asansörün bir sonraki kat hedefi

        bool Direction { get; set; }
        // (Yukarı -> True ) | (Aşağı -> False)

        int Floor { get; set; }
        // Şuan bulundğu kat

        void SetFloorCount(int floor, int count);

        //Asansörde bulunan müşteri sayısını güncelle

        string FloorCountString();

        //Asansör içerisinde bulunan müşterilerin metin olarak dönüştürülmüş hali

        int GetFloorCount(int floor);

        //Parametre olarak gelen katta inecek müşteri sayısı

        void FloorCountClear();

        //Katlardaki müşteri sayısını sıfırla

        int GetCount();

        //Asansör içerisinde bulunan müşteri sayısı
    }
}