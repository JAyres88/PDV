DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_atualiza_cliente`(IN idcliente int, nome char(150) ,nascimento datetime, complemento char(150), telefone char(10), celular char(11), email char(150), email2 char(150), cpf char(15), cnpj char(15),
									inscricao char(15), 
                                   idendereco int,  tipoEndereco char(50),  rua char(50), bairro char(50), cep char(10) ,obs text, idcidade int )
BEGIN
	START TRANSACTION;
	IF (idendereco="" AND (tipoEndereco<>"" or (rua<>"" or (bairro<>"")))) THEN 
		INSERT INTO endereco ( tipo,  rua, bairro, cep, obs, cidade) 
								VALUES (tipo, rua, bairro, cep , obs, idcidade);
    ELSE 
    UPDATE cliente SET nome=nome, 
						  nascimento=nascimento, 
						  complemento=complemento,                
						  telefone=telefone, 
						  celular=celular, 
						  email=email, 
						  email2=email2, 
						  cpf=cpf, 
						  cnpj=cnpj, 
						  inscricao=inscricao, 
						  logAlteracao = Now()
						  where cliente.id = idcliente;
	
	UPDATE endereco SET tipo=tipoEndereco, 
							rua=rua, 
							bairro=bairro, 
							cep=cep, 
							obs=obs,
							cidade=idcidade
							where idcliente = idcliente 
									and endereco.idendereco = idendereco;                                    
	
	COMMIT;
	END IF;
END$$
DELIMITER ;
