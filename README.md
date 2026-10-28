# Ikaru CastDesk v1.1.0 — All-in-One

Satu aplikasi untuk **Sender** dan **Receiver**. Saat dibuka, pilih mode.

## Fitur baru (v1.1)

- **Night mode** diperbaiki: kontras teks lebih tinggi, warna preview & consent mengikuti tema.
- **Multi-receiver**: di Sender, Ctrl+klik beberapa receiver di list, lalu **Cast ke receiver terpilih**. Encode sekali, fan-out ke semua.
- **Receiver request cast**: tombol **Minta Cast** di Receiver mengirim broadcast; Sender otomatis mengisi IP & menampilkan notifikasi, tinggal klik Cast.

## Alur

1. Install / jalankan `IkaruCastDesk.exe`
2. Pilih **Sender** atau **Receiver**
3. Opsional: centang **Ingat pilihan ini**
4. Tombol **⇄** di sidebar untuk kembali ke pemilihan mode

### Multi-cast
- Receiver harus sudah running (beacon aktif).
- Di Sender: Scan → pilih satu atau lebih (Ctrl+klik) → Cast ke receiver terpilih.
- Bisa campur dengan IP manual.

### Request cast
- Di Receiver: klik **Minta Cast**.
- Di Sender muncul pesan “Receiver X meminta cast” dan IP terisi → klik Cast.

## Optimasi delay (WiFi 5 GHz / LAN cepat)

- Pilih preset **Seimbang** atau naikkan FPS / Quality.
- H.264 (butuh `ffmpeg.exe`) lebih efisien bandwidth daripada JPEG pada resolusi tinggi.
- `NoDelay = true` sudah aktif di TCP.

## Publish EXE tunggal

```powershell
cd KantorCast-AIO
.\scripts\publish.ps1
```

Hasil: `dist\Ikaru CastDesk\IkaruCastDesk.exe` (self-contained).

### H.264 (opsional)

Salin `ffmpeg.exe` dari Gyan full build ke folder app.

## Installer

1. Install [Inno Setup 6](https://jrsoftware.org/isinfo.php)
2. `.\scripts\publish.ps1`
3. Compile `installer\KantorCast.iss`
