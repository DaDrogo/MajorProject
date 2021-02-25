-- phpMyAdmin SQL Dump
-- version 4.9.5deb2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 25. Feb 2021 um 00:25
-- Server-Version: 10.3.25-MariaDB-0ubuntu0.20.04.1
-- PHP-Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `charsheet`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `abilitys`
--

CREATE TABLE `abilitys` (
  `UserID` int(11) DEFAULT NULL,
  `SheetNr` int(11) DEFAULT NULL,
  `AbiNr` varchar(255) DEFAULT NULL,
  `AbiName` varchar(255) DEFAULT NULL,
  `AbiType` varchar(255) DEFAULT NULL,
  `AbiSchool` varchar(255) DEFAULT NULL,
  `AbiRange` varchar(255) DEFAULT NULL,
  `AbiCost` varchar(255) DEFAULT NULL,
  `AbiLength` varchar(255) DEFAULT NULL,
  `AbiEffect` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `basevalues`
--

CREATE TABLE `basevalues` (
  `UserID` int(11) DEFAULT NULL,
  `SheetNr` int(11) DEFAULT NULL,
  `AG` int(11) DEFAULT NULL,
  `AGplus` int(11) DEFAULT NULL,
  `AGminus` int(11) DEFAULT NULL,
  `KR` int(11) DEFAULT NULL,
  `KRplus` int(11) DEFAULT NULL,
  `KRminus` int(11) DEFAULT NULL,
  `AU` int(11) DEFAULT NULL,
  `AUplus` int(11) DEFAULT NULL,
  `AUminus` int(11) DEFAULT NULL,
  `RE` int(11) DEFAULT NULL,
  `REplus` int(11) DEFAULT NULL,
  `REminus` int(11) DEFAULT NULL,
  `GE` int(11) DEFAULT NULL,
  `GEplus` int(11) DEFAULT NULL,
  `GEminus` int(11) DEFAULT NULL,
  `VE` int(11) DEFAULT NULL,
  `VEplus` int(11) DEFAULT NULL,
  `VEminus` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `charcreated`
--

CREATE TABLE `charcreated` (
  `UserID` int(11) DEFAULT NULL,
  `SheetNr` int(11) DEFAULT NULL,
  `CharRace` varchar(255) DEFAULT NULL,
  `CharRaceAbility` varchar(255) DEFAULT NULL,
  `CharName` varchar(255) DEFAULT NULL,
  `CharWeight` varchar(255) DEFAULT NULL,
  `CharHeight` varchar(255) DEFAULT NULL,
  `CharAge` varchar(255) DEFAULT NULL,
  `CharHairColor` varchar(255) DEFAULT NULL,
  `CharSkinColor` varchar(255) DEFAULT NULL,
  `CharGender` varchar(255) DEFAULT NULL,
  `CharLanguage` varchar(255) DEFAULT NULL,
  `CharReligion` varchar(255) DEFAULT NULL,
  `CharDestiny` varchar(255) DEFAULT NULL,
  `CharDestinyLevel` int(11) DEFAULT NULL,
  `CharAmbition` varchar(255) DEFAULT NULL,
  `ModiAmount` int(11) DEFAULT NULL,
  `AbilityAmount` int(11) DEFAULT NULL,
  `ItemAmount` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `item`
--

CREATE TABLE `item` (
  `UserID` int(11) DEFAULT NULL,
  `SheetNr` int(11) DEFAULT NULL,
  `ItemNr` int(11) DEFAULT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `ItemType` varchar(255) DEFAULT NULL,
  `ItemWeight` varchar(255) DEFAULT NULL,
  `ItemDescription` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `modifications`
--

CREATE TABLE `modifications` (
  `UserID` int(11) DEFAULT NULL,
  `SheetNr` int(11) DEFAULT NULL,
  `ModiNr` int(11) DEFAULT NULL,
  `ModiName` varchar(255) DEFAULT NULL,
  `ModiPotenz` int(11) DEFAULT NULL,
  `ModiLvl` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `userinfo`
--

CREATE TABLE `userinfo` (
  `UserID` int(11) DEFAULT NULL,
  `UserCharSheets` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `userinfo`
--

INSERT INTO `userinfo` (`UserID`, `UserCharSheets`) VALUES
(41, 0);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
