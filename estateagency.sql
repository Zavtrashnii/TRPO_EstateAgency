-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: estateagency
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `advertisement`
--

DROP TABLE IF EXISTS `advertisement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `advertisement` (
  `id_advert` int NOT NULL,
  `City` text NOT NULL,
  `District` text NOT NULL,
  `Street` text NOT NULL,
  `House` text NOT NULL,
  `Floor` int NOT NULL,
  `Square` double NOT NULL,
  `Price` int NOT NULL,
  `TypeOfAd` text NOT NULL,
  `Info` text,
  `Frofile` text NOT NULL,
  PRIMARY KEY (`id_advert`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advertisement`
--

LOCK TABLES `advertisement` WRITE;
/*!40000 ALTER TABLE `advertisement` DISABLE KEYS */;
INSERT INTO `advertisement` VALUES (0,'admin','admin','admin','1',1,1,1,'Аренда','1admin','admin'),(1,'admin','admin','admin','admin',1,1,11,'Продажа','admin','admin'),(2,'admin','admin','admin','admin',1,1,11,'Продажа','adminadmin','admin'),(3,'adminadmin','adminadmin','adminadmin','adminadmin',1,1,11,'Продажа','adminadminadminadmin','admin'),(4,'Красноярск','Октябрьский','Вильского','16',9,35,10000,'Аренда','','admin'),(5,'Красноярск','Октябрьский','Вильского','16',9,35,40000,'Продажа','В хорошем состоянии','admin'),(6,'Красноярск','Ленинский','Горького','16',9,35,40000,'Продажа','В хорошем состоянии','admin');
/*!40000 ALTER TABLE `advertisement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `application`
--

DROP TABLE IF EXISTS `application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `application` (
  `id_application` int NOT NULL,
  `id_user` int NOT NULL,
  `info` text NOT NULL,
  PRIMARY KEY (`id_application`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (0,0,'Id объявления: 6\r\nId покупателя: 1\r\nТелефон: 79509831935\r\nПочта: Ger@mail.ru\r\nИнфо: Сбросите цену? '),(1,0,'Id объявления: 5\r\nId покупателя: 1\r\nТелефон: 79509831935\r\nПочта: Ger@mail.ru\r\nИнфо: Через сколько сможете сдать?');
/*!40000 ALTER TABLE `application` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history`
--

DROP TABLE IF EXISTS `history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `history` (
  `id_history` int NOT NULL,
  `data` text NOT NULL,
  `nickname_Saller` text NOT NULL,
  `nickname_buyer` text,
  `ad_info` text NOT NULL,
  `reason` text NOT NULL,
  PRIMARY KEY (`id_history`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history`
--

LOCK TABLES `history` WRITE;
/*!40000 ALTER TABLE `history` DISABLE KEYS */;
INSERT INTO `history` VALUES (0,'06.05.2020 0:50:30','admin','','Город: admin\nРайон: admin\nУлица: admin\nДом: 1\nЭтаж: 1\nПлощадь: 1\nЦена: 1\nТип покупки: Аренда\nИнфо: 1admin\n','Продал'),(1,'06.05.2020 0:52:11','admin','','Город: admin\nРайон: admin\nУлица: admin\nДом: 1\nЭтаж: 1\nПлощадь: 1\nЦена: 1\nТип покупки: Аренда\nИнфо: 1admin\n','Продал'),(2,'06.05.2020 0:56:37','admin','','Город: admin\nРайон: admin\nУлица: admin\nДом: 1\nЭтаж: 1\nПлощадь: 1\nЦена: 1\nТип покупки: Аренда\nИнфо: 1admin\n','Продал'),(3,'06.05.2020 0:58:17','admin','','Город: admin\nРайон: Кировский\nУлица: Вузовский\nДом: 16\nЭтаж: 9\nПлощадь: 35\nЦена: 40000\nТип покупки: Продажа\nИнфо: В хорошем состоянии\n','Продал');
/*!40000 ALTER TABLE `history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profile`
--

DROP TABLE IF EXISTS `profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profile` (
  `id_profile` int NOT NULL,
  `login` text NOT NULL,
  `password` text NOT NULL,
  `phoneNumber` text NOT NULL,
  `email` text NOT NULL,
  `nickname` text NOT NULL,
  PRIMARY KEY (`id_profile`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profile`
--

LOCK TABLES `profile` WRITE;
/*!40000 ALTER TABLE `profile` DISABLE KEYS */;
INSERT INTO `profile` VALUES (0,'admin','admin','+admin','admin@mail.ru','admin'),(1,'Tomorrow','Tomorrow','79509831935','Ger@mail.ru','Tomorrow'),(2,'ryrio','ryrio','8902123142','mail@mail.ru','ryrio');
/*!40000 ALTER TABLE `profile` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-06 15:27:25
