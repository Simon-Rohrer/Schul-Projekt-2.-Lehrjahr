CREATE DATABASE IF NOT EXISTS `Restaurant`;

USE `Restaurant`;

CREATE TABLE IF NOT EXISTS `Speisekarte` (
    speiseid INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    preis DECIMAL(6, 2) NOT NULL,
    vegetarisch BOOLEAN NOT NULL
);

CREATE TABLE IF NOT EXISTS `Tisch` (
    tischid INT AUTO_INCREMENT PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS `Bestellung` (
    bestellid INT AUTO_INCREMENT PRIMARY KEY,
    tischid INT NOT NULL,
    FOREIGN KEY (tischid) REFERENCES `Tisch` (tischid)
);

CREATE TABLE IF NOT EXISTS `Bestellposition` (
    positionsid INT AUTO_INCREMENT PRIMARY KEY,
    bestellid INT NOT NULL,
    speiseid INT NOT NULL,
    menge INT NOT NULL,
    FOREIGN KEY (bestellid) REFERENCES `Bestellung` (bestellid),
    FOREIGN KEY (speiseid) REFERENCES `Speisekarte` (speiseid)
);