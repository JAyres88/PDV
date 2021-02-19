DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_novo_cliente`(IN nome char(150) ,nascimento datetime, complemento char(150),telefone char(10), celular char(11), email char(150), email2 char(150), cpf char(15), cnpj char(15),
									inscricao char(15), logCadastro datetime, 
                                   tipoEndereco char(50),  rua char(50), bairro char(50), cep char(10),obs text ,anotacoes text, idCidade int, OUT msg int)
BEGIN
    IF tipoEndereco<>"" and rua<>"" and bairro<>"" and cep<>"" and obs<>"" and idCidade<>"" THEN     
		START TRANSACTION;	
        INSERT INTO cliente (nome, nascimento, complemento,  telefone, celular, email, email2, cpf, cnpj,anotacoes, inscricao, logCadastro)
	VALUES (nome, nascimento, complemento, telefone, celular, email, email2, cpf, cnpj, inscricao,anotacoes ,logCadastro);    	    
         SET MSG = LAST_INSERT_ID();           
        INSERT INTO endereco ( tipo, rua, bairro, cep, obs, idcliente ,cidade) 
	VALUES (tipoEndereco, rua, bairro, cep ,obs, last_insert_id(), idCidade);		
		SELECT MSG;
        COMMIT;     	
	ELSE  
		START TRANSACTION; 
			INSERT INTO cliente ( nome, nascimento, complemento,  telefone, celular, email, email2, cpf, cnpj, anotacoes,inscricao, logCadastro)
		VALUES ( nome, nascimento, complemento,  telefone, celular, email, email2, cpf, cnpj, anotacoes, inscricao, logCadastro); 
        SET MSG = LAST_INSERT_ID();
        SELECT MSG;
		COMMIT;
	END IF; 	
END$$
DELIMITER ;
