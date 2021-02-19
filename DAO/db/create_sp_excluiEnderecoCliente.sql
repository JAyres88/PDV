DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_exclui_enderecoCliente`(in idendereco int, idcliente int )
BEGIN

delete endereco.* from endereco where endereco.idendereco=idendereco and endereco.idcliente=idcliente;

END$$
DELIMITER ;
