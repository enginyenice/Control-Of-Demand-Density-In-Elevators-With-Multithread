## AVM Özellikleri

 - AVM deki kat sayısı 5'tir.
 - Toplamda 5 adet asansör bulunmaktadır.
 - Asansörlerden biri sürekli çalışmaktadır. Geriye kalanlar, yoğunluk durumuna göre aktif veya pasif durumdadır
 - Asansörlerin maksimum kapasitesi 10'dur.
 - Asansörlerdeki kat arası geçiş 200ms'dir.
## Proje bileşenlerinin özellikleri
1.	**AVM Giriş (Login) Thread:** 500 ms zaman aralıklarıyla [1-10] arasında rastgele sayıda müşterinin AVM' ye  giriş yapmasını sağlamaktadır (Zemin Kat). Giren müşterileri rastgele bir kata (1-4) gitmek için asansör kuyruğuna alır.
2.	**AVM Çıkış (Exit) Thread:** 1000 ms zaman aralıklarıyla [1-5] arasında rastgele sayıda müşterinin AVM’den çıkış yapmasını sağlamaktadır (Zemin Kat). Çıkmak isteyen müşterileri rastgele bir kattan (1-4), zemin kata gitmek için asansör kuyruğuna alır.
3.	**Asansör Thread :** Katlardaki kuyrukları kontrol eder. Maksimum kapasiteyi aşmayacak şekilde kuyruktaki müşterilerin talep ettikleri katlarda taşınabilmesini sağlar. Bu thread asansör sayısı kadar (5 adet) olmalıdır.
**NOT:** Zemin kattan diğer katlara (AVM’ye) giriş yapmak isteyenler, ya da diğer katlardan (AVM’den) çıkış yapmak isteyenler kuyruk oluştururlar.
4. **Kontrol Thread:** Katlardaki kuyrukları kontrol eder. Kuyrukta bekleyen kişilerin toplam sayısı asansörün kapasitesinin 2 katını aştığı durumda (20) yeni asansörü aktif hale getirir. Kuyrukta bekleyen kişilerin toplam sayısı asansör kapasitenin altına indiğinde asansörlerden biri pasif hale gelir. Bu işlem tek asansörün çalıştığı durumda geçerli değildir.

| Değerlendirme Ölçütleri | Puan |
| --| -- |
| Giriş Çıkış Threadlerinin Çalışması | 25 |
| Asansör Threadinin Çalışması | 25 |
| Threadlerin çalışmasının arayüz üzerinden gösterilmesi | 20 |
| Rapor | 10


