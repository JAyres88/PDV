CREATE TABLE `documentosaida` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descricao` char(150) COLLATE utf8_bin DEFAULT 'Documento Saída Padrão',
  `geraFinanceiro` tinyint DEFAULT '0',
  `movimentaEstoque` tinyint DEFAULT '0',
  `aceitaVale` tinyint DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
