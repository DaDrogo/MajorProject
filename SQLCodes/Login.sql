-- phpMyAdmin SQL Dump
-- version 4.9.5deb2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 24. Feb 2021 um 23:25
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
-- Datenbank: `Login`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `login`
--

CREATE TABLE `login` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(255) DEFAULT NULL,
  `Passport` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `login`
--

INSERT INTO `login` (`UserID`, `Username`, `Passport`) VALUES
(10, 'Nils', '123'),
(11, 'hallo', 'pip'),
(12, 'florian', 'stumm'),
(13, 'simon', 'stinkt'),
(14, 'ölk', '123'),
(15, '123123', '123'),
(16, 'Bruder Bernd', 'ujEMY5uz'),
(17, 'Jonatan der Weise', 'SuperJan98'),
(19, '123', '123'),
(20, '2', '2'),
(21, '3', '3'),
(22, '4', '4'),
(23, '5', '5'),
(24, '7', '7'),
(25, 'Chris', '123'),
(26, '', ''),
(27, '11', '111'),
(28, 'moin', 'meister'),
(29, 'qwew213', '123456'),
(30, 'sdfddffd', '213'),
(31, 'BaneSkillix', 'ujEMY5uz1'),
(32, 'Tester123', '1234'),
(33, 'kalawdwedq', '123'),
(34, 'uli', '123'),
(35, 'Sorry', 'brudermusslos'),
(36, 'Duhund', 'brudermusslos'),
(37, '12313213123123213213', '123'),
(38, 'dadrogo', '123'),
(39, 'Daddrogo', '123'),
(40, 'Alçin', '666');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `login`
--
ALTER TABLE `login`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
