CREATE TABLE `parceiro` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` char(150) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `complemento` char(150) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `telefone` char(10) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `celular` char(11) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` char(150) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `email2` char(150) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cpf` char(11) COLLATE utf8_bin DEFAULT NULL,
  `cnpj` char(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inscricao` char(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `logAlteracao` datetime DEFAULT NULL,
  `logCadastro` datetime DEFAULT NULL,
  `anotacoes` text CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nome_UNIQUE` (`nome`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
