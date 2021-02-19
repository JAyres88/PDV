DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_novo_enderecoCliente`(IN tipo char(50), idcliente int,  rua char(50), bairro char(50), cep char(8), obs text,  idcidade int)
BEGIN

INSERT INTO endereco ( tipo, idcliente, rua, bairro, cep, obs, cidade) 
VALUES (tipo, idcliente, rua, bairro, cep , obs, idcidade);

END$$
DELIMITER ;
