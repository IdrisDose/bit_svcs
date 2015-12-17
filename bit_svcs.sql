-- phpMyAdmin SQL Dump
-- version 4.5.0.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 26, 2015 at 12:22 AM
-- Server version: 10.0.17-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bit_svcs`
--
CREATE DATABASE IF NOT EXISTS `bit_svcs` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `bit_svcs`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--
-- Creation: Nov 24, 2015 at 07:15 PM
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `client_id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(4) DEFAULT 'NIL',
  `name` varchar(250) DEFAULT NULL,
  `street_address` varchar(250) DEFAULT 'Not Set',
  `city` varchar(250) DEFAULT 'Not Set',
  `postcode` int(4) DEFAULT '0',
  `email` varchar(250) DEFAULT NULL,
  `phone` varchar(250) DEFAULT 'Not Set',
  `mobile` varchar(250) DEFAULT 'Not Set',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`client_id`),
  UNIQUE KEY `client_id` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `clients`:
--

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`client_id`, `title`, `name`, `street_address`, `city`, `postcode`, `email`, `phone`, `mobile`, `active`) VALUES
(1, 'Mr', 'Idris Dose', '123 Madeup St', 'Hornsby', 2157, 'idris@bitservices.com', '04123123321', '02123123321', 1),
(2, 'Mr', 'Adam Steve', '123 Something St', 'Sydney', 2157, 'test@test.com', '02 1234 5678', '04 1234 5678', 1);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--
-- Creation: Nov 24, 2015 at 11:37 AM
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(4) DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `phone` varchar(250) DEFAULT NULL,
  `role` varchar(250) DEFAULT NULL,
  `isSupervising` tinyint(1) NOT NULL DEFAULT '0',
  `isActive` tinyint(1) NOT NULL DEFAULT '1',
  `isAdmin` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`employee_id`),
  UNIQUE KEY `employee_id` (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `employees`:
--

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`employee_id`, `title`, `name`, `email`, `phone`, `role`, `isSupervising`, `isActive`, `isAdmin`) VALUES
(1, 'Snr', 'Admin Idris', 'idris@idris.com', '0412564545', 'Head of IT Department', 1, 1, 1),
(2, 'Mr', 'Coord Idris', 'iddy@coordtest.com', '0412345678', 'Head of Maintenance', 1, 1, 0),
(3, 'Mr', 'Contractor Idris', 'idris@contrtest.com', '0412345678', 'Norm Contractor', 0, 1, 0),
(4, 'Mr', 'Test Employee', 'test@test.com', '0415478543', 'Head of Something', 0, 1, 1),
(6, 'Test', 'Testing Two', 'testing@two.com', '0312313441', 'None', 0, 0, 0);

--
-- Triggers `employees`
--
DROP TRIGGER IF EXISTS `insert_new_skills`;
DELIMITER $$
CREATE TRIGGER `insert_new_skills` AFTER INSERT ON `employees` FOR EACH ROW insert into skills (employee_id) values (new.employee_id)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `invoices`
--
-- Creation: Nov 23, 2015 at 03:03 AM
--

DROP TABLE IF EXISTS `invoices`;
CREATE TABLE IF NOT EXISTS `invoices` (
  `invoice_id` int(11) NOT NULL AUTO_INCREMENT,
  `invoice_details` varchar(250) DEFAULT NULL,
  `invoice_status` enum('PAID','UNPAID','PENDING') DEFAULT 'UNPAID',
  `invoice_amount` decimal(10,2) NOT NULL DEFAULT '0.00',
  `job_id` int(11) DEFAULT NULL,
  `client_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`invoice_id`),
  UNIQUE KEY `invoice_id` (`invoice_id`),
  KEY `job_invoice_fk` (`job_id`),
  KEY `client_invoice_fk` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `invoices`:
--   `client_id`
--       `clients` -> `client_id`
--   `job_id`
--       `jobs` -> `job_id`
--

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--
-- Creation: Nov 25, 2015 at 05:21 AM
--

DROP TABLE IF EXISTS `jobs`;
CREATE TABLE IF NOT EXISTS `jobs` (
  `job_id` int(11) NOT NULL AUTO_INCREMENT,
  `job_name` varchar(255) NOT NULL,
  `job_details` varchar(250) DEFAULT '"Not Inserted"',
  `client_id` int(11) DEFAULT '1',
  `employee_id` int(11) DEFAULT '1',
  `supervisor_id` int(11) DEFAULT '1',
  `priority` enum('LOW','MEDIUM','HIGH') NOT NULL DEFAULT 'LOW',
  `job_location` varchar(255) DEFAULT 'None',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`job_id`),
  UNIQUE KEY `job_id` (`job_id`),
  KEY `client_job_fk` (`client_id`),
  KEY `employee_job_fk` (`employee_id`),
  KEY `supervisor_job_fk` (`supervisor_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `jobs`:
--   `client_id`
--       `clients` -> `client_id`
--   `employee_id`
--       `employees` -> `employee_id`
--   `supervisor_id`
--       `employees` -> `employee_id`
--

-- --------------------------------------------------------

--
-- Table structure for table `logins`
--
-- Creation: Nov 25, 2015 at 09:43 AM
--

DROP TABLE IF EXISTS `logins`;
CREATE TABLE IF NOT EXISTS `logins` (
  `login_id` int(11) NOT NULL AUTO_INCREMENT,
  `login_type` enum('CLIENT','EMPLOYEE','SUPERVISOR','CONTRACTOR') NOT NULL DEFAULT 'CLIENT',
  `uname` varchar(255) NOT NULL,
  `email` varchar(250) DEFAULT NULL,
  `pass` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`login_id`),
  UNIQUE KEY `login_id` (`login_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `logins`:
--

--
-- Dumping data for table `logins`
--

INSERT INTO `logins` (`login_id`, `login_type`, `uname`, `email`, `pass`) VALUES
(1, 'CLIENT', 'client', 'idris@bitservices.com', 'password'),
(2, 'SUPERVISOR', 'admin', 'idris@idris.com', 'password'),
(3, 'EMPLOYEE', 'employee', 'iddy@coordtest.com', 'password');

-- --------------------------------------------------------

--
-- Table structure for table `skills`
--
-- Creation: Nov 24, 2015 at 10:46 AM
--

DROP TABLE IF EXISTS `skills`;
CREATE TABLE IF NOT EXISTS `skills` (
  `skill_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) DEFAULT NULL,
  `developer` tinyint(1) NOT NULL DEFAULT '0',
  `analyst` tinyint(1) NOT NULL DEFAULT '0',
  `itsupport` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`skill_id`),
  KEY `skills_employee_fk` (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

--
-- RELATIONS FOR TABLE `skills`:
--   `employee_id`
--       `employees` -> `employee_id`
--

--
-- Dumping data for table `skills`
--

INSERT INTO `skills` (`skill_id`, `employee_id`, `developer`, `analyst`, `itsupport`) VALUES
(21, 1, 1, 1, 1),
(22, 2, 1, 1, 1),
(23, 3, 1, 1, 1),
(24, 4, 0, 1, 0),
(25, 6, 1, 0, 1);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `invoices`
--
ALTER TABLE `invoices`
  ADD CONSTRAINT `client_invoice_fk` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`),
  ADD CONSTRAINT `job_invoice_fk` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`job_id`);

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `client_job_fk` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`),
  ADD CONSTRAINT `employee_job_fk` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`employee_id`),
  ADD CONSTRAINT `supervisor_job_fk` FOREIGN KEY (`supervisor_id`) REFERENCES `employees` (`employee_id`);

--
-- Constraints for table `skills`
--
ALTER TABLE `skills`
  ADD CONSTRAINT `skills_employee_fk` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`employee_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
