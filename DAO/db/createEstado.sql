CREATE TABLE `estado` (
  `id` int NOT NULL,
  `nome` varchar(75) COLLATE utf8_bin DEFAULT NULL,
  `uf` varchar(2) COLLATE utf8_bin DEFAULT NULL,
  `ibge` int DEFAULT NULL,
  `pais` int DEFAULT NULL,
  `ddd` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Unidades Federativas';
