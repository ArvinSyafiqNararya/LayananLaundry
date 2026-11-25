IF DB_ID('LayananLaundry') IS NULL
BEGIN
CREATE DATABASE LayananLaundry;
END
GO
USE LayananLaundry;
GO
IF OBJECT_ID('dbo.users','U') IS NULL
BEGIN
CREATE TABLE users
(
id_users INT PRIMARY KEY IDENTITY(1,1),
username NVARCHAR(100) NOT NULL,
password_hash NVARCHAR(255) NOT NULL,
role NVARCHAR(20) NOT NULL,
tanggal_pembuatan DATETIME DEFAULT GETDATE()
);
END
GO
IF OBJECT_ID('dbo.pelanggan','U') IS NULL
BEGIN
CREATE TABLE pelanggan
(
id_pelanggan INT PRIMARY KEY IDENTITY(1,1),
nama NVARCHAR(100) NOT NULL,
no_hp NVARCHAR(15) NOT NULL UNIQUE,
alamat NVARCHAR(255) NULL,
status_aktif BIT NOT NULL DEFAULT 1
);
END
GO
IF OBJECT_ID('dbo.layanan','U') IS NULL
BEGIN
CREATE TABLE layanan
(
id_layanan INT PRIMARY KEY IDENTITY(1,1),
jenis NVARCHAR(50) NOT NULL,
satuan NVARCHAR(20) NOT NULL,
harga DECIMAL(12,2) NOT NULL,
status_aktif BIT NOT NULL DEFAULT 1
);
END
GO
IF OBJECT_ID('dbo.transaksi','U') IS NULL
BEGIN
CREATE TABLE transaksi
(
id_transaksi INT PRIMARY KEY IDENTITY(1,1),
kode_transaksi VARCHAR(30) UNIQUE NOT NULL,
id_pelanggan INT NOT NULL,
id_users INT NOT NULL,
tanggal_Transaksi DATETIME DEFAULT GETDATE(),
total_harga DECIMAL(12,2) DEFAULT 0,
status NVARCHAR(30) DEFAULT 'Diterima',
FOREIGN KEY(id_pelanggan) REFERENCES dbo.pelanggan(id_pelanggan),
FOREIGN KEY (id_users) REFERENCES dbo.users(id_users)
);
END
GO
IF OBJECT_ID('detail_transaksi','U') IS NULL
BEGIN
CREATE TABLE detail_transaksi
(
id_detail_transaksi INT PRIMARY KEY IDENTITY(1,1),
id_transaksi INT NOT NULL,
id_layanan INT NOT NULL,
qty DECIMAL(10,2) NOT NULL,
harga_satuan DECIMAL(12,2) NOT NULL,
subtotal DECIMAL(12,2) NOT NULL,
FOREIGN KEY (id_transaksi) REFERENCES dbo.transaksi(id_transaksi),
FOREIGN KEY (id_layanan) REFERENCES dbo.layanan(id_layanan)
);
END

--INSERT INTO users (username,password_hash,role) VALUES('Aldi','$2a$12$W28X0dy/StkFQ0IwO4DZDeIMoFiDG9wC/eKa7LYyJy51DlRJVSHvO','kasir')
--INSERT INTO users (username,password_hash,role) VALUES('admin','$2a$12$6Y0h0vq8czvnrAgVtvJ7HOVicXALM3ot9zI6aNqxuAqoPYfnCocg2','admin')
SELECT * FROM transaksi;