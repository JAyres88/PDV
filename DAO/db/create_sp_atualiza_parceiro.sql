DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_parceiro_atualiza_parceiro`(IN idparceiro int, nome char(150) , complemento char(150), telefone char(10), celular char(11), email char(150), email2 char(150), cnpj char(15),
									inscricao char(15), anotacoes text,
                                   tipoEndereco char(50),  rua char(50), bairro char(50), cep char(10) ,obs text, idcidade int, idendereco int )
BEGIN
	START TRANSACTION;
    UPDATE parceiro SET nome=nome,                   
                      complemento=complemento,
                      telefone=telefone, 
                      celular=celular, 
                      email=email, 
                      email2=email2,                
                      cnpj=cnpj, 
                      inscricao=inscricao, 
                      logAlteracao = Now(),
                      anotacoes=anotacoes
                      where parceiro.id = idparceiro;	
	UPDATE endereco SET tipo=tipoEndereco, 
						rua=rua, 
                        bairro=bairro, 
                        cep=cep, 
                        obs=obs,
                        cidade=idcidade
						where endereco.idparceiro = idparceiro 
								and endereco.idendereco = idendereco ;
	COMMIT;
END$$
DELIMITER ;
