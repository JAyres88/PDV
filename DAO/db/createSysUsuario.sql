CREATE TABLE `sysusuario` (
  `idsysUsuario` int NOT NULL,
  `sysUsuario` char(50) COLLATE utf8_bin DEFAULT NULL,
  `sysSenha` char(50) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idsysUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='tabela de usuários		';
