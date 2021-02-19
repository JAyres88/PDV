DELIMITER $$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_sys_auth`(IN sysusuario char(50), syssenha char(50), OUT sts tinyint)
BEGIN

SET sts = (select count(sysusuario.sysusuario) from sysusuario where sysusuario.sysusuario=sysusuario and sysusuario.syssenha=syssenha);
SELECT sts;

END$$
DELIMITER ;
