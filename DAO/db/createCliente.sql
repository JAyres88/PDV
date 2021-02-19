CREATE TABLE `cliente` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` char(150) COLLATE utf8_bin NOT NULL,
  `complemento` char(150) COLLATE utf8_bin DEFAULT NULL,
  `nascimento` datetime DEFAULT NULL,
  `telefone` char(10) COLLATE utf8_bin NOT NULL,
  `celular` char(11) COLLATE utf8_bin DEFAULT NULL,
  `email` char(150) COLLATE utf8_bin NOT NULL,
  `email2` char(150) COLLATE utf8_bin DEFAULT NULL,
  `cpf` char(15) COLLATE utf8_bin DEFAULT NULL,
  `cnpj` char(15) COLLATE utf8_bin DEFAULT NULL,
  `inscricao` char(15) COLLATE utf8_bin DEFAULT NULL,
  `logAlteracao` datetime DEFAULT NULL,
  `logCadastro` datetime DEFAULT NULL,
  `anotacoes` text COLLATE utf8_bin,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nome_UNIQUE` (`nome`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
