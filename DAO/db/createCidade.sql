CREATE TABLE `cidade` (
  `id` int NOT NULL,
  `nome` varchar(120) COLLATE utf8_bin DEFAULT NULL,
  `uf` int DEFAULT NULL,
  `ibge` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cidade_estado_idx` (`uf`),
  CONSTRAINT `fk_cidade_estado` FOREIGN KEY (`uf`) REFERENCES `estado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Municipios das Unidades Federativas';
