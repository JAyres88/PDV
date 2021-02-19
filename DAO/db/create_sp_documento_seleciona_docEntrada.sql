DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_documento_seleciona_docEntrada`()
BEGIN
 select documentoentrada.id as 'Id',
			documentoentrada.descricao as 'Descrição', 
				documentoentrada.geraFinanceiro as 'Gera Financeiro', 
					documentoentrada.movimentaEstoque as 'Movimenta Estoque', 
						documentoentrada.aceitaVale as 'Permite Vale' from documentoentrada;
 
END$$
DELIMITER ;
