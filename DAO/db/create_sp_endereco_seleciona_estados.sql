DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_seleciona_estados`()
BEGIN

select estado.id, 
		estado.uf from estado; 

END$$
DELIMITER ;
