DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_exclui_enderecoParceiro`(in idendereco int, idparceiro int )
BEGIN

delete endereco.* from endereco where endereco.idendereco=idendereco and endereco.idcliente=idcliente;

END$$
DELIMITER ;
