# Test Case

Backend
Oyuncular oyuna girerken Guest olarak login olmalıdır. Oyunda 6 adet farklı renklerde,
büyüklüklerde ve ağırlıklarda top çeşidi bulunmaktadır. Bu toplar PlayFab üzerinden Item olarak
eklenmelidir. Her oyunda topladigimiz coin basina 10 adet altin verilmektedir. Bu altin ile de
mağazada bulunan toplari satin alınabilmektedir. Bu fiyatlar PlayFab üzerinden dinamik olarak
kontrol edilir. Topların fiziksel özellikleri Renk, Yarıçap ve Ağırlık PlayFab üzerinden dinamik
olarak kontrol edilebilmelidir.

GamePlay
Oyunda sağda ve solda bulunan kontrol çubukları ile top yukari yönde ilerletilir.
Kontrol çubuklarının hareket alanı ekranın sınırlarını geçmemelidir.
Çubuk hızlı hareket ettirildiğinde topa uyguladığı kuvvet de aynı oranda artması gerekir.
Top aşağı düştüğünde oyun sonlanır. Kontrol çubukları hareket ettirilemez ve elde edilen Puan
ve toplanan Coin PlayFab üzerinden kaydedilmelidir.
Yeni HighScore elde edilirken eski HighScore çizgisi oyuncuya gösterilmelidir.
