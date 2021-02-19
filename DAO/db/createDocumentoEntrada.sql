CREATE TABLE `documentoentrada` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descricao` char(150) COLLATE utf8_bin DEFAULT 'Documento Padrão',
  `geraFinanceiro` tinyint DEFAULT '0',
  `movimentaEstoque` tinyint DEFAULT '0',
  `aceitaVale` tinyint DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Cadastro de Documentos de Entrada e Saída.';
