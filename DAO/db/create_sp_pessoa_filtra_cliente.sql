DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_filtra_cliente`(IN id int)
BEGIN
	
  select * from  cliente where cliente.id=id;  

END$$
DELIMITER ;
