CREATE DATABASE IF NOT EXISTS bdinterfaces;

USE bdinterfaces;

CREATE TABLE IF NOT EXISTS `Categories`(
    `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
    `CategoryName` varchar(15) NOT NULL,
    `Description` longtext,
    PRIMARY KEY (`CategoryID`),
    KEY `Categories_CategoryName` (`CategoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;


CREATE TABLE IF NOT EXISTS `Products` (
    `ProductID` int(11) NOT NULL AUTO_INCREMENT,
    `ProductName` varchar(40) NOT NULL,
    `SupplierID` int(11) DEFAULT NULL,
    `CategoryID` int(11) DEFAULT NULL,
    `QuantityPerUnit` varchar(20) DEFAULT NULL,
    `UnitPrice` double DEFAULT '0',
    `UnitsInStock` smallint(6) DEFAULT '0',
    `UnitsOnOrder` smallint(6) DEFAULT '0',
    `ReorderLevel` smallint(6) DEFAULT '0',
    `Discontinued` tinyint(1) NOT NULL DEFAULT '0',
    PRIMARY KEY (`ProductID`),
    KEY `Products_CategoriesProducts` (`CategoryID`),
    KEY `Products_CategoryID` (`CategoryID`),
    KEY `Products_ProductName` (`ProductName`),
    KEY `Products_SupplierID` (`SupplierID`),
    KEY `Products_SuppliersProducts` (`SupplierID`),
    CONSTRAINT `FK_Products_Categories` FOREIGN KEY (`CategoryID`) REFERENCES `Categories` (`CategoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `Users`(
   `User` varchar(15) NOT NULL,
   `Password` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


