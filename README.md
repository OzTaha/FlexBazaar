# FlexBazaar

## ❗ Hatalar ve Çözümleri

- **İstemci tarafında `http` isteği atarken aldığım 500 Internal Server Error hatası:**

  - `Categories` API'sine istek atarken, `Catalog` projesi içindeki `Properties/launchSettings.json` dosyasında yer alan `applicationUrl` değeri `https` olarak ayarlıydı.  
  - Ancak istemci tarafındaki istek `http` protokolü ile yapılıyordu. Bu uyumsuzluk 500 hatasına neden oldu.  
  - `applicationUrl`'i `http` olarak güncellediğimde sorun çözüldü. Meğer ne basit bir problemmiş. 😄

> 💡 **Not:** API ile istemci arasındaki protokol (http/https) uyumsuzlukları SSL hatalarına veya beklenmeyen sunucu hatalarına neden olabilir. Geliştirme ortamında http, canlı ortamda https kullanılması önerilir.
