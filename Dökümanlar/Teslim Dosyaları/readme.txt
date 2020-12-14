					 _______________________________________
					|		  T.C.			|
					|	   KOCAELİ ÜNİVERSİTESİ 	|
					|	  MÜHENDİSLİK FAKÜLTESİ 	|
					|        BİLGİSAYAR MÜHENDİSLİĞİ	|
					|_______________________________________|
					|    YAZILIM LABORATUVARI-1 PROJE -2	|
					|   ASANSÖRLERDEKİ TALEP YOĞUNLUĞUNUN   |
					|	MULTITHREAD İLE KONTROLÜ 	|
					|_______________________________________|
					|	ENGİN YENİCE - 190201133	|
					|_______________________________________|



 _______________________________________________________________________________________________________________________________
|PROJE HAKKINDA															|
|																|
|Proje C# Programlama dili kullanılarak nesne tabanlı programlama mantığı ile geliştirildi. Projenin amacı bir AVM’deki 	|
|asansörlere gelen isteklerde ki yoğunluğu, multithread kullanarak diğer asansörlerle birlikte azaltmaktır. AVM’nin kendisine 	|
|ait belirli özellikleri vardır.												|
|																|
|	-> AVM’deki kat sayısı 5’tir. (Zemin kat, birinci kat, ikinci kat, üçüncü kat ve dördüncü kat)				|
|	-> Toplamda 5 adet asansör bulunmaktadır.										|
|	-> Asansörlerin biri sürekli çalışmaktadır. Geriye kalanlar, yoğunluk durumuna göre aktif veya pasif durumdadır.	|
|	-> Asansörlerin maksimum kapasitesi 10’dur.										|
|	-> Asansörlerdeki kat arası geçiş 200 ms’dir.										|
|																|
|Ayrıca AVM giriş, çıkış, asansör ve kontrol işlemlerin belirli şartlara göre yapılmaktadır. Bu şartlar:			|
|																|
|AVM Giriş (Login) Thread: 													|
|500 ms zaman aralıklarıyla [1-10] arasında rastgele sayıda müşterinin AVM’ye giriş yapmasını sağlamaktadır (Zemin Kat). 	|
|Giren müşterileri rastgele bir kata (1-4) gitmek için asansör kuyruğuna alır.							|
|																|
|AVM Çıkış (Exit) Thread: 													|
|1000 ms zaman aralıklarıyla [1-5] arasında rastgele sayıda müşterinin AVM’den çıkış yapmasını sağlamaktadır (Zemin Kat). 	|
|Çıkmak isteyen müşterileri rastgele bir kattan (1-4), zemin kata gitmek için asansör kuyruğuna alır.				|
|																|
|Asansör Thread: 														|
|Katlardaki kuyrukları kontrol eder. Maksimum kapasiteyi aşmayacak şekilde kuyruktaki müşterilerin talep ettikleri katlarda 	|
|taşınabilmesini sağlar. Bu thread asansör sayısı kadar (5 adet) olmalıdır.							|
|																|
|NOT:																|
|Zemin kattan diğer katlara (AVM’ye) giriş yapmak isteyenler, ya da diğer katlardan (AVM’den) çıkış yapmak isteyenler kuyruk 	|
|oluştururlar.															|
|																|
|Kontrol Thread: 														|
|Katlardaki kuyrukları kontrol eder. Kuyrukta bekleyen kişilerin toplam sayısı asansörün kapasitesinin 2 katını 		|
|aştığı durumda (20) yeni asansörü aktif hale getirir. Kuyrukta bekleyen kişilerin toplam sayısı asansör kapasitenin altına 	|
|indiğinde asansörlerden biri pasif hale gelir. Bu işlem tek asansörün çalıştığı durumda geçerli değildir. 			|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|TESLİM EDİLEN DOSYALAR VE İÇERİKLERİ												|
|																|
|190201133-Rapor.pdf      	: Projenin raporu										|
|190201133-Kaba-Kod.pdf   	: Proje içerisinde yazıların kodların kaba kod çıktıları					|
|190201133-Proje.zip	  	: Proje dosyalarının bulunduğu zip dosyası							|
|Alışveriş-Merkezi-Bilgi-Ekranı : Projenin exe olarak çalıştırılabilir hali bulunmaktadır.					|
|190201133.txt 	    	  	: Projenin tüm kodlarının kopyalandığı metin belgesi						|		
|readme.txt	    	  	: Projenin nasıl çalıştırılacağı ve önemli notların bulunduğu metin belgesi			|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|PROJE NASIL ÇALIŞTIRILIR													|
|																|
|Projeyi çalıştırmak için 3 farklı yol izleyebilirsiniz.									|
|																|
|1-)Alışveriş-Merkezi-Bilgi-Ekranı klasörü içerisindeki Alışveriş Merkezi Bilgi Ekranı.exe uygulaması ile çalıştırabilirsiniz.	|
|2-)Talep_Yogunlugunun_Multithread_Kontrolu\bin\Debug klasörü altında bulunan Alışveriş Merkezi Bilgi Ekranı.exe uygulaması	|
|ile çalıştırabilirsiniz.													|
|3-)Proje dizini içerisindeki Talep_Yogunlugunun_Multithread_Kontrolu.sln proje dosyasını açarak visual studio programından 	|
|projeyi başlatabilirsiniz.													|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|(!!)ÖNEMLİ NOT:													    (!!)|
|Hareket Bilgileri bölümü içerisinde bulanan:											|
|Giriş Yapan Toplam Müşteri Sayısı : Alışveriş merkezi içerisine giren toplam müşteri sayısını belirtmektedir.			|
|Çıkış Yapan Toplam Müşteri Sayısı : Alışveriş merkezinden ayrılmış toplam müşteri sayısını belirtmektedir.			|
|																|
|İşaret ve Semboller:														|
|Pasif       : Asansör pasif durumda ise bu durum gösterilir.									|
|Aktif       : Asansör aktif durumda ise bu durum gösterilir.									|
|Durduruluyor: Asansör içerisinde bulunan yolcuları gitmek istedikleri katlara bıraktıktan sonra pasif konuma geçiriliyor.	|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|PROJE NASIL KULLANILIR														|
|Program başlatıldığında Alışveriş merkezi bilgi ekranı sizi karşılayacaktır. Bu ekran üzerinde bulunan Başlat butonuna 	|
|tıklayarak programı başlatabilirsiniz.												|
|Başlat butonuna basılması durumunda proje kapatılıncaya kadar aktif olarak çalışmaktadır.					|
|_______________________________________________________________________________________________________________________________|