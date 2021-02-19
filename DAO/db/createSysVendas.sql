CREATE TABLE `sysvendas` (
  `idsysVendas` int NOT NULL,
  `descricao` char(150) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idsysVendas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
