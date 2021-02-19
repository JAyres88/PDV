DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_parceiro_seleciona_parceiro`()
BEGIN

select parceiro.id, 
		parceiro.nome, 
         parceiro.complemento, 
          parceiro.telefone, 
           parceiro.celular,  
            parceiro.email, 
             parceiro.email2, 
             parceiro.cpf,
              parceiro.cnpj, 
               parceiro.inscricao,                
                parceiro.anotacoes,
                 parceiro.logAlteracao, 
                  parceiro.logCadastro
		from parceiro ;

END$$
DELIMITER ;
