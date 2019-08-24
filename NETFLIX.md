![Netflix Error Playback](https://www.ghacks.net/wp-content/uploads/2016/02/netflix-error-unblocker.jpg)

Cara untuk menembus blokiran Netflix oleh Internet Positif Dengan menggunakan UNBLOCKHOSTID + GoodbyeDPI.

Setelah menginstall UNBLOCKHOSTID, kamu akan bisa membuka Netflix, tetapi saat masuk playback mode akan ada tulisan:

    ======================

    Oops, something when wrong....

    Internet Connection Problem

    An Internet or home network connection problem is preventing playback. Please check your Internet connection and try again.

    If the problem persists, please visit the Netflix Help Center.

    ======================

Kurang lebih seperti itu, karena akses kecepatan Netflix dilimit oleh Internet Positif jadi harus memakai GoodbyeDPI juga.

Kamu bisa download GoodbyeDPI disini.

[Original](https://github.com/ValdikSS/GoodbyeDPI)

[Modified](https://files.catbox.moe/54sx6d.zip) / [Mirror](https://filebin.ca/4jivtUll4uI3/goodbyedpi-0.1.5rc1.zip) / [Mirror2](https://bin.jvnv.net/file/YuJJa/goodbyedpi-0.1.5rc1.zip) / [Mirror3](https://upload.vinahost.vn/YHIyh/goodbyedpi-0.1.5rc1.zip) (Thanks to punkofthedeath)

Saya sarankan untuk menggunakan versi modified karena menginstallnya mudah. Tetapi jika kalian mengerti cara menggunakan aplikasi tersebut, silahkan pakai yang original.

Selesai, silahkan coba untuk memutar film di Netflix.


# Linux

Sebelumnya, install dahulu UNBLOCKHOSTID - [INSTALL.md](https://github.com/gvoze32/unblockhostid/blob/master/INSTALL.md#linux--bsd--macos)

Selanjutnya, kamu bisa menggunakan [Green Tunnel](https://github.com/SadeghHayeri/GreenTunnel) yang sudah dilengkapi dengan GUI, instalasinya mudah, tinggal install seperti package biasa, lalu jalankan dan tekan tombol menjadi on.

Alternatifnya, kamu bisa menggunakan [zapret](https://github.com/bol-van/zapret) dengan cara download, kemudian jalankan, install_easy.sh dan jawab pertanyaan yang tersedia.

# MacOS

Sebelumnya, install dahulu UNBLOCKHOSTID - [INSTALL.md](https://github.com/gvoze32/unblockhostid/blob/master/INSTALL.md#linux--bsd--macos)

Selanjutnya, kamu bisa menggunakan [Green Tunnel](https://github.com/SadeghHayeri/GreenTunnel) juga, instalasinya kurang lebih sama dengan Linux.

# Android

Sebelumnya, install dahulu UNBLOCKHOSTID - [INSTALL.md](https://github.com/gvoze32/unblockhostid/blob/master/INSTALL.md#android)

Untuk android silahkan gunakan aplikasi [Dawn](https://play.google.com/store/apps/details?id=com.wktkf.dawn). Tinggal aktifkan saja.

# VPN (Alternatif)

Kalau cara di atas masih tidak bisa digunakan, kamu bisa menggunakan cara ini.

### Bahan:
- UNBLOCKHOSTID
- [OpenVPN GUI](https://openvpn.net/community-downloads)
- Config Server [Indonesia TCPVPN](https://www.tcpvpn.com/vpn-server-indonesia)

### Langkah:
1. Buat SSH Indonesia di TCPVPN
2. Isi Username dan Password

```
Account has been successfully created !

Username :
Password :
IP :
```

3. Scroll ke bawah nanti ada pilihan download premium VPN config langsung download saja tidak perlu isi SSH
4. Ekstrak file di folder anda
5. Download OpenVPN GUI di PC/HP
6. Buka OpenVPN GUI lalu import file hasil ekstrak tadi (yang ada 443)
7. Isi Username dan Password sesuai dengan langkah kedua (sesuai dengan SSH anda)
8. Sambungkan koneksi dan pilih 443
9. Selesai, silahkan mencoba 

### Rekomendasi Server:
- TCP VPN ID1
- TCP VPN ID2

Note: Hanya aktif selama 5 hari saja. (kalau mati, tinggal create ulang).
