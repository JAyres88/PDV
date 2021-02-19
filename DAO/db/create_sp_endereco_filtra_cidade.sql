DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_filtra_cidade`(IN uf int)
BEGIN

select cidade.id, cidade.nome from cidade where cidade.uf=uf ;

END$$
DELIMITER ;
