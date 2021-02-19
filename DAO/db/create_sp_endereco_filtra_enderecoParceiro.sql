DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_filtra_enderecoParceiro`(IN idparceiro int)
BEGIN

select endereco.idendereco as Id,
	   endereco.tipo as Tipo, 
       endereco.rua as Rua ,
       endereco.bairro as Bairro, 
       endereco.cep as Cep ,
       endereco.obs as Obs, 
       estado.uf as Uf ,
       cidade.nome as Cidade
					from endereco inner join cidade 
											on endereco.cidade=cidade.id
								  inner join estado 
											on estado.id = cidade.uf
                    where endereco.idparceiro= idparceiro;
END$$
DELIMITER ;
