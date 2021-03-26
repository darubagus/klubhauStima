# Tugas Besar II IF2211 Strategi Algoritma
Pengaplikasian Algoritma BFS dan DFS dalam Fitur People You May Know Jejaring Sosial Facebook

## Deskripsi Singkat
Program ini berbentuk aplikasi GUI yang dapat memodelkan beberapa fitur seperti *People You May Know* di media sosial. Algoritma *Breadth First Search* (BFS) dan *Depth First Search* (DFS) digunakan untuk mendapatkan rekomendasi teman untuk sebuah akun dan program juga memiliki fitur mencari jalur pertemanan untuk dua akun yang belum berteman.

Misal input seperti:
```
13
A B
A C
A D
B C
B E
B F
C F
C G
D G
D F
E H
E F
F H
```
Hasil friend recommendation untuk akun A adalah:
```
Nama akun: F
3 mutual friends:
B
C
D

Nama akun: G
2 mutual friends:
C
D

Nama akun: E
1 mutual friend:
B
```

Dan explore friends antara A dan H dengan BFS adalah:
```
Nama akun: A dan H
2nd-degree connection
A → B → E → H
```

## Cara Kerja
### *Breadth First Search*
Breadth First Search dilakukan dengan melakukan traversal secara konsentris. Hal ini dilakukan dengan menelusuri semua simpul yang bertetanggaan dengan simpul awal, lalu semua simpul yang belum dikunjungi yang berjarak dua sisi dari simpul awal, dan seterusnya hingga semua simpul yang dapat terhubung dengan simpul awal dikunjungi.<br/>

Breadth First Search lebih mudah dilakukan dengan menggunakan queue. Queue diinisialisasi dengan simpul awal yang ditandai sudah dikunjungi. Pada setiap iterasi, algoritma mengidentifikasi semua simpul yang belum dikunjungi dan bertetanggaan dengan simpul pada antrian pertama pada queue, mengidentifikasi simpul-simpul tersebut dengan status sudah dikunjungi, dan melakukan enqueue. Lalu simpul pada antrian pertama di-dequeue.<br/>

### *Depth First Search*
Depth First Search dilakukan dengan melakukan traversal yang bermulai di simpul awal. Pada setiap iterasi, algoritma mengunjungi sebuah simpul yang bertetanggaan dengan simpul awal (jika terdapat beberapa simpul, pemilihan simpul disesuaikan dengan struktur data dari graph). Lalu penelusuran dilanjutkan pada simpul yang bertetanggaan dengan simpul tersebut hingga mencapai dead end. Pada saat tersebut, algoritma melakukan backtracking sebanyak satu edge ke simpul sebelumnya dan menelusuri kembali simpul yang belum dikunjungi.<br/>


## Requirements
* .NET Framework 3.1 or higher
* Windows powered machine
* [Microsoft Automatic Graph Layout (MSAGL) library](https://github.com/microsoft/automatic-graph-layout)
* (Recommended) Windows 10 operating system
* (Recommended) Visual Studio IDE


## Instalasi & Cara Penggunaan
* Clone repository:
```
git clone https://github.com/darubagus/klubhauStima.git
```
* Buka folder bin
* Jalankan setres.exe

Pastikan file test case dalam bentuk .txt dan penulisan isinya sesuai dengan spesifikasi.

## Author
* Rayhan Alghifari Fauzta (13519039)
* Aisyah Farras Aqila (13519054)
* Daru Bagus Dananjaya (13519080)
