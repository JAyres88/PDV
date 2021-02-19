CREATE TABLE `produto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `produto` char(150) COLLATE utf8_bin DEFAULT 'Produto Padrao',
  `nomeVenda` char(150) COLLATE utf8_bin DEFAULT 'Descricao Alternativa Padrão',
  `categoria` char(150) COLLATE utf8_bin DEFAULT 'Categoria Padrao Alternativa',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
