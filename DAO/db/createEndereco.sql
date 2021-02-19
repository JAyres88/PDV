CREATE TABLE `endereco` (
  `idendereco` int NOT NULL AUTO_INCREMENT,
  `idcliente` int DEFAULT NULL,
  `idparceiro` int DEFAULT NULL,
  `tipo` char(50) COLLATE utf8_bin DEFAULT NULL,
  `rua` char(100) COLLATE utf8_bin DEFAULT NULL,
  `bairro` char(50) COLLATE utf8_bin DEFAULT NULL,
  `obs` text COLLATE utf8_bin,
  `cidade` int DEFAULT NULL,
  `cep` char(8) COLLATE utf8_bin DEFAULT NULL,
  `logAlteracao` datetime DEFAULT NULL,
  PRIMARY KEY (`idendereco`),
  KEY `fk_pessoa_idx` (`idcliente`),
  KEY `fk_cidade_idx` (`cidade`),
  KEY `fk_parceiro_idx` (`idparceiro`),
  CONSTRAINT `fk_cidade` FOREIGN KEY (`cidade`) REFERENCES `cidade` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_cliente` FOREIGN KEY (`idcliente`) REFERENCES `cliente` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_parceiro` FOREIGN KEY (`idparceiro`) REFERENCES `parceiro` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
