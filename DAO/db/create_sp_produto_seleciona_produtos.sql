DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_seleciona_produtos`()
BEGIN

select * from produto;

END$$
DELIMITER ;
