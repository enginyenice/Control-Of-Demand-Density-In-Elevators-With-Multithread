## T.C.
## KOCAELİ ÜNİVERSİTESİ
## BİLGİSAYAR MÜHENDİSLİĞİ
## YAZILIM LABORATUVARI-1 PROJE -2
## ASANSÖRLERDEKİ TALEP YOĞUNLUĞUNUN MULTITHREAD İLE KONTROLÜ
## ENGİN YENİCE - 190201133

|Dosya Adı| İçerik  |
|--|--|
|  190201133-Rapor.pdf  | [Projenin raporu](https://github.com/enginyenice/Talep_Yogunlugunun_Multithread_Kontrolu-YazLab-1-Proje-2/blob/master/D%C3%B6k%C3%BCmanlar/Teslim%20Dosyalar%C4%B1/190201133-Rapor.pdf) |
|  190201133-Kaba-Kod.pdf  | [Proje içerisinde yazıların kodların kaba kod çıktıları](https://github.com/enginyenice/Talep_Yogunlugunun_Multithread_Kontrolu-YazLab-1-Proje-2/blob/master/D%C3%B6k%C3%BCmanlar/Teslim%20Dosyalar%C4%B1/190201133-Kaba-Kod.pdf) |
|  190201133-Proje.zip  | [Proje dosyalarının bulunduğu zip dosyası](https://github.com/enginyenice/Talep_Yogunlugunun_Multithread_Kontrolu-YazLab-1-Proje-2/blob/master/D%C3%B6k%C3%BCmanlar/Teslim%20Dosyalar%C4%B1/190201133-Proje.zip) |
|  Alışveriş-Merkezi-Bilgi-Ekranı  | Projenin exe olarak çalıştırılabilir hali bulunmaktadır. |
|  190201133.txt | [Projenin tüm kodlarının kopyalandığı metin belgesi](https://github.com/enginyenice/Talep_Yogunlugunun_Multithread_Kontrolu-YazLab-1-Proje-2/blob/master/D%C3%B6k%C3%BCmanlar/Teslim%20Dosyalar%C4%B1/190201133.txt) |
|  readme.txt  | [Projenin nasıl çalıştırılacağı ve önemli notların bulunduğu metin belgesi](https://github.com/enginyenice/Talep_Yogunlugunun_Multithread_Kontrolu-YazLab-1-Proje-2/blob/master/D%C3%B6k%C3%BCmanlar/Teslim%20Dosyalar%C4%B1/readme.txt)			 |

	

## PROJE NASIL ÇALIŞTIRILIR													
																
Projeyi çalıştırmak için 3 farklı yol izleyebilirsiniz.									
																
1. Alışveriş-Merkezi-Bilgi-Ekranı klasörü içerisindeki Alışveriş Merkezi Bilgi Ekranı.exe uygulaması ile çalıştırabilirsiniz.	
2.  Talep_Yogunlugunun_Multithread_Kontrolu\bin\Debug klasörü altında bulunan Alışveriş Merkezi Bilgi Ekranı.exe uygulaması	
ile çalıştırabilirsiniz.													
3. Proje dizini içerisindeki Talep_Yogunlugunun_Multithread_Kontrolu.sln proje dosyasını açarak visual studio programından 	
projeyi başlatabilirsiniz.													

## (!!)ÖNEMLİ NOT (!!)
**Hareket Bilgileri bölümü içerisinde bulanan**:											
**Giriş Yapan Toplam Müşteri Sayısı** : Alışveriş merkezi içerisine giren toplam müşteri sayısını belirtmektedir.			
**Çıkış Yapan Toplam Müşteri Sayısı** : Alışveriş merkezinden ayrılmış toplam müşteri sayısını belirtmektedir.			
																
**İşaret ve Semboller**:														
**Pasif**       : Asansör pasif durumda ise bu durum gösterilir.									
**Aktif**       : Asansör aktif durumda ise bu durum gösterilir.									
**Durduruluyor**: Asansör içerisinde bulunan yolcuları gitmek istedikleri katlara bıraktıktan sonra pasif konuma geçiriliyor.	


## PROJE NASIL KULLANILIR														
Program başlatıldığında Alışveriş merkezi bilgi ekranı sizi karşılayacaktır. Bu ekran üzerinde bulunan Başlat butonuna 	
tıklayarak programı başlatabilirsiniz.												
Başlat butonuna basılması durumunda proje kapatılıncaya kadar aktif olarak çalışmaktadır.		

## KLASÖR YAPISI
```plaintext
Talep_Yogunlugunun_Multithread_Kontrolu
├── UI/
│   └── ShoppingMallInformationDisplay.cs
└── ShoppingCenter/
	├── Core/
	│	└── Settings.cs
	├── Elevator/
	│	├── Abstract/
	│	│	└── IElevator.cs
	│	└── Concrete/
	│		└── Elevator.cs
	├── Floor/
	│	├── Abstract/
	│	│	└── IFloor.cs
	│	└── Concrete/
	│		└── Floor.cs
	└── Threads/
		├── Abstract/
		│	├── ITControl.cs
		│	├── ITElevator.cs
		│	├── ITExit.cs
		│	└── ITLogin.cs
		└── Concrete/
			├── TControl.cs
			├── TElevator.cs
			├── TExit.cs
			└── TLogin.cs
```		
 
 ## FORM EKRANI GÖRSELİ
 ![Genel Ekran](https://raw.githubusercontent.com/enginyenice/Asansorlerdeki-Talep-Yogunlugunun-Multithreadler-Ile-Kontrolu-Yazlab-1-Proje-1/master/D%C3%B6k%C3%BCmanlar/D%C3%B6k%C3%BCmanlar/Proje%20Resimleri/GenelForm.png?token=AKJEJQM5GGSZNNJQ2U3M43K7374NE)	
| Değerlendirme Ölçütleri | Puan |
| --| -- |
| Giriş Çıkış Threadlerinin Çalışması | 25 |
| Asansör Threadinin Çalışması | 25 |
| Threadlerin çalışmasının arayüz üzerinden gösterilmesi | 20 |
| Rapor | 10
