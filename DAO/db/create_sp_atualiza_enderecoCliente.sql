DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_atualiza_enderecoCliente`(IN idcliente int, 
											idendereco int, 
                                            tipo char(50), 
                                            rua char(100), 
                                            bairro char(50), 
                                            obs text, 
                                            idcidade int,                                        
                                            cep char(8) )
BEGIN

update endereco set tipo = tipo, 
                    rua = rua, 
                    bairro = bairro, 
                    obs = obs , 
                    cidade = idcidade, 
                    cep = cep                                      
                    where endereco.idcliente=idcliente 
						  and endereco.idendereco=idendereco;
END$$
DELIMITER ;
