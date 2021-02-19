DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_saldo_seleciona_saldo`()
BEGIN
select saldo.idsaldo as IdSaldo,
		saldo.descricao as DescSaldo from saldo;

END$$
DELIMITER ;
