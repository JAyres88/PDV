DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_documento_seleciona_docSaida`()
BEGIN
select documentosaida.id as 'Id',
		documentosaida.descricao as 'Descricao', 
         documentosaida.geraFinanceiro as 'Gera Financeiro', 
          documentosaida.movimentaEstoque as 'Movimenta Estoque', 
           documentosaida.aceitaVale as 'Permite Vale' from documentosaida;

END$$
DELIMITER ;
