CREATE DATABASE IF NOT EXISTS `Restaurant`;
    

CREATE TABLE `Essensliste` (
    listenid INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    essensname VARCHAR(255) NOT NULL,
    preis DECIMAL(10, 2) NOT NULL,
    vegetarisch BOOLEAN NOT NULL
);

CREATE TABLE `Bestellungen` (
    bestellid INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    listenid INT NOT NULL,
    menge INT NOT NULL,
    FOREIGN KEY (listenid) REFERENCES Essensliste(listenid)
);