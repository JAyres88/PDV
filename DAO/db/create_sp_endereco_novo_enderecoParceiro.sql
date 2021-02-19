DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_novo_enderecoParceiro`(IN tipo char(50), idparceiro int,  rua char(50), bairro char(50), cep char(8), obs text,  idcidade int)
BEGIN

INSERT INTO endereco ( tipo, idparceiro, rua, bairro, cep, obs, cidade) 
VALUES (tipo, idparceiro, rua, bairro, cep , obs, idcidade);

END$$
DELIMITER ;
