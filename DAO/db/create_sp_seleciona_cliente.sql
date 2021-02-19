DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_seleciona_cliente`()
BEGIN

select cliente.id as Id, 
		cliente.nome as Nome, 
		 cliente.complemento as Complemento, 
          cliente.nascimento as Nascimento,      
            cliente.telefone as Telefone, 
             cliente.celular as Celular, 
              cliente.email as Email, 
               cliente.email2 as Email2, 
                cliente.cpf as CPF, 
                 cliente.cnpj as CNPJ, 
                  cliente.inscricao as Inscricao, 
                   cliente.logAlteracao as logAlteracao, 
                    cliente.logCadastro as logCadastro, 
                     cliente.anotacoes as Anotacoes from cliente ;

END$$
DELIMITER ;
