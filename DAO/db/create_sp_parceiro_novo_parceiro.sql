DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_parceiro_novo_parceiro`(IN nome char(150) , complemento char(150), telefone char(10), celular char(11), email char(150), email2 char(150), cnpj char(15)
								  ,anotacoes text,inscricao char(15), logCadastro datetime, 
                                   tipoEndereco char(50),  rua char(50), bairro char(50), cep char(10) ,obs text, idCidade int, OUT msg int)
BEGIN
    IF tipoEndereco<>"" and rua<>"" and bairro<>"" and cep<>"" and obs<>"" and idCidade<>"" THEN     
		START TRANSACTION;	
        INSERT INTO parceiro (nome, complemento, telefone, celular, email, email2, cnpj, inscricao, anotacoes, logCadastro)
	VALUES (nome, complemento, telefone, celular, email, email2, cnpj, inscricao, anotacoes, logCadastro);
    	SET MSG = LAST_INSERT_ID() ;
        INSERT INTO endereco ( tipo, rua, bairro, cep, obs, idparceiro,cidade) 
	VALUES (tipoEndereco, rua, bairro, cep ,obs, last_insert_id(), idCidade);
		SELECT MSG; 
		COMMIT;
	ELSE  
		START TRANSACTION; 
			INSERT INTO parceiro ( nome, complemento, telefone, celular, email, email2, cnpj, inscricao, logCadastro)
		VALUES ( nome, complemento, telefone, celular, email, email2, cnpj, inscricao, logCadastro);  
        SET MSG = LAST_INSERT_ID() ;
        SELECT MSG;
		COMMIT;
	END IF; 
END$$
DELIMITER ;
