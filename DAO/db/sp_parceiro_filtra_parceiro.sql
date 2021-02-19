DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_parceiro_filtra_parceiro`(IN id int)
BEGIN
	
  select * from  parceiro where parceiro.id=id;  

END$$
DELIMITER ;
