/*
SQLyog Community v8.81 
MySQL - 5.7.3-m13-log : Database - agenda
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`agenda` /*!40100 DEFAULT CHARACTER SET utf8 */;

/*Table structure for table `pessoa` */

DROP TABLE IF EXISTS `pessoa`;

CREATE TABLE `pessoa` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOME` varchar(255) DEFAULT NULL,
  `SOBRE_NOME` varchar(255) DEFAULT NULL,
  `DATA_NASCIMENTO` datetime DEFAULT NULL,
  `DATA_CADASTRO` datetime DEFAULT NULL,
  `GENERO` char(1) DEFAULT NULL,
  `RELACIONAMENTO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Data for the table `pessoa` */

insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (1,'Flávio ','da Maia Junior','1989-11-20 00:00:00','1989-11-20 00:00:00','M',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (3,'Megan','Fox','1986-05-16 00:00:00','1986-05-16 00:00:00','F',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (4,'Eduardo','Saverin','1982-03-19 00:00:00',NULL,'M',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (5,'Patricia','Peota','1976-10-19 00:00:00',NULL,'F',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (6,'Bruna','Marquezine','1995-08-04 00:00:00',NULL,'F',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (7,'John','Mayer','1977-10-08 00:00:00',NULL,'M',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (8,'Rosie','Huntington-Whiteley','1987-04-18 00:00:00',NULL,'F',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (9,'Camilla','Luddington','1983-11-15 00:00:00',NULL,'F',1);
insert  into `pessoa`(`ID`,`NOME`,`SOBRE_NOME`,`DATA_NASCIMENTO`,`DATA_CADASTRO`,`GENERO`,`RELACIONAMENTO`) values (10,'Kelly','Slater','1972-02-11 00:00:00',NULL,'M',1);

/*Table structure for table `pessoacontato` */

DROP TABLE IF EXISTS `pessoacontato`;

CREATE TABLE `pessoacontato` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TELEFONE` varchar(255) DEFAULT NULL,
  `TIPO_TELEFONE` int(11) DEFAULT NULL,
  `EMAIL` varchar(255) DEFAULT NULL,
  `TIPO_EMAIL` int(11) DEFAULT NULL,
  `PESSOA_ID` int(11) DEFAULT NULL,
  `PscTipoEmail2` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PESSOA_ID` (`PESSOA_ID`),
  CONSTRAINT `FK916446353BE7574B` FOREIGN KEY (`PESSOA_ID`) REFERENCES `pessoa` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Data for the table `pessoacontato` */

insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (1,'(47) 8846-0102',1,NULL,1,1,0);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (3,'(47) 8846-0104',0,NULL,0,3,0);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (4,'(47) 8846-0104',NULL,NULL,NULL,4,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (5,'(47) 8846-0105',NULL,NULL,NULL,5,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (6,'(47) 8846-0106',NULL,NULL,NULL,6,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (7,'(47) 8846-0107',NULL,NULL,NULL,7,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (8,'(47) 8846-0108',NULL,NULL,NULL,8,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (9,'(47) 8846-0109',NULL,NULL,NULL,9,NULL);
insert  into `pessoacontato`(`ID`,`TELEFONE`,`TIPO_TELEFONE`,`EMAIL`,`TIPO_EMAIL`,`PESSOA_ID`,`PscTipoEmail2`) values (10,'(47) 8846-0110',NULL,NULL,NULL,10,NULL);

/*Table structure for table `pessoaendereco` */

DROP TABLE IF EXISTS `pessoaendereco`;

CREATE TABLE `pessoaendereco` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ENDERECO` varchar(255) DEFAULT NULL,
  `TIPO_ENDERECO` int(11) DEFAULT NULL,
  `CEP` varchar(255) DEFAULT NULL,
  `CIDADE` varchar(255) DEFAULT NULL,
  `BAIRRO` varchar(255) DEFAULT NULL,
  `ESTADO` varchar(255) DEFAULT NULL,
  `PAIS` varchar(255) DEFAULT NULL,
  `PESSOA_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PESSOA_ID` (`PESSOA_ID`),
  CONSTRAINT `FKFA4EB57C3BE7574B` FOREIGN KEY (`PESSOA_ID`) REFERENCES `pessoa` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `pessoaendereco` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
