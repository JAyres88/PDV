-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema db_vendas
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema db_vendas
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `db_vendas`;
CREATE SCHEMA IF NOT EXISTS `db_vendas` DEFAULT CHARACTER SET UTF8MB4 COLLATE UTF8MB4_bin ;
USE `db_vendas` ;

-- -----------------------------------------------------
-- Table `db_vendas`.`banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`banco` (
  `id` INT NOT NULL,
  `descricaoBanco` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`categoria_produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`categoria_produto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`estado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`estado` (
  `id` INT NOT NULL,
  `nome` VARCHAR(75) NULL DEFAULT NULL,
  `uf` VARCHAR(2) NULL DEFAULT NULL,
  `ibge` INT NULL DEFAULT NULL,
  `pais` INT NULL DEFAULT NULL,
  `ddd` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin
COMMENT = 'Unidades Federativas';


-- -----------------------------------------------------
-- Table `db_vendas`.`cidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`cidade` (
  `id` INT NOT NULL,
  `nome` VARCHAR(120) NULL DEFAULT NULL,
  `uf` INT NULL DEFAULT NULL,
  `ibge` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cidade_estado_idx` (`uf` ASC) VISIBLE,
  CONSTRAINT `fk_cidade_estado`
    FOREIGN KEY (`uf`)
    REFERENCES `db_vendas`.`estado` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin
COMMENT = 'Municipios das Unidades Federativas';


-- -----------------------------------------------------
-- Table `db_vendas`.`documento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`documento` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` CHAR(150) NULL DEFAULT 'Documento Saída Padrão',
  `geraFinanceiro` TINYINT NULL DEFAULT '0',
  `movimentaEstoque` TINYINT NOT NULL DEFAULT '0',
  `aceitaVale` TINYINT NULL DEFAULT '0',
  `tipo` INT NULL DEFAULT '0' COMMENT '0 para entrada \\\\n1 para saída',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`tipo_pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`tipo_pessoa` (
  `id` INT NOT NULL,
  `descricao` CHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`pessoa` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `tipoPessoa` INT NULL DEFAULT NULL COMMENT '1- Cliente\\\\\\\\\\\\\\\\n2 - Fornecedor\\\\\\\\\\\\\\\\n3 - Ambos',
  `nome` CHAR(150) NULL DEFAULT NULL,
  `complemento` CHAR(150) NULL DEFAULT NULL,
  `nascimento` DATETIME NULL DEFAULT NULL,
  `telefone` CHAR(10) NULL DEFAULT NULL,
  `celular` CHAR(11) NULL DEFAULT NULL,
  `email` CHAR(150) NULL DEFAULT NULL,
  `email2` CHAR(150) NULL DEFAULT NULL,
  `cpf` CHAR(15) NULL DEFAULT NULL,
  `cnpj` CHAR(15) NULL DEFAULT NULL,
  `logAlteracao` DATETIME NULL DEFAULT NULL,
  `logCadastro` DATETIME NULL DEFAULT NULL,
  `anotacoes` TEXT NULL DEFAULT NULL,
  `usuario` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `tipoPessoa_fk_idx` (`tipoPessoa` ASC) VISIBLE,
  CONSTRAINT `tipoPessoa_fk`
    FOREIGN KEY (`tipoPessoa`)
    REFERENCES `db_vendas`.`tipo_pessoa` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 31
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`endereco` (
  `idendereco` INT NOT NULL AUTO_INCREMENT,
  `cidade` INT NULL DEFAULT NULL,
  `pessoa` INT NULL DEFAULT NULL,
  `tipo` CHAR(50) NULL DEFAULT NULL,
  `rua` CHAR(100) NULL DEFAULT NULL,
  `bairro` CHAR(50) NULL DEFAULT NULL,
  `obs` TEXT NULL DEFAULT NULL,
  `cep` CHAR(8) NULL DEFAULT NULL,
  `logAlteracao` DATETIME NULL DEFAULT NULL,
  `logCadastro` DATETIME NULL DEFAULT NULL,
  `usuario` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`idendereco`),
  INDEX `fk_cidade_idx` (`cidade` ASC) VISIBLE,
  INDEX `fk_pessoa_idx` (`pessoa` ASC) VISIBLE,
  CONSTRAINT `fk_cidade`
    FOREIGN KEY (`cidade`)
    REFERENCES `db_vendas`.`cidade` (`id`),
  CONSTRAINT `fk_pessoa`
    FOREIGN KEY (`pessoa`)
    REFERENCES `db_vendas`.`pessoa` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 109
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`produto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `produto` CHAR(150) NULL DEFAULT 'Produto Padrao',
  `nomeVenda` CHAR(150) NULL DEFAULT 'Descricao Alternativa Padrão',
  `id_categoria` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `id_categoria_idx` (`id_categoria` ASC) VISIBLE,
  CONSTRAINT `id_categoria`
    FOREIGN KEY (`id_categoria`)
    REFERENCES `db_vendas`.`categoria_produto` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`reg_cabecalho`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`reg_cabecalho` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `iddocumento` INT NULL DEFAULT NULL,
  `pessoa_id` INT NULL,
  `idpessoa` INT NULL DEFAULT NULL,
  `dtEntrada` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `statusCab` TINYINT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `pessoa_fk_idx` (`idpessoa` ASC) VISIBLE,
  INDEX `docsaida_fl_idx` (`iddocumento` ASC, `idpessoa` ASC) VISIBLE,
  INDEX `fk_reg_cabecalho_pessoa1_idx` (`pessoa_id` ASC) VISIBLE,
  CONSTRAINT `id_documento`
    FOREIGN KEY (`iddocumento`)
    REFERENCES `db_vendas`.`documento` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_reg_cabecalho_pessoa1`
    FOREIGN KEY (`pessoa_id`)
    REFERENCES `db_vendas`.`pessoa` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin
COMMENT = 'Nesta tabela são registrados os documentos tanto de entrada quanto de saída.';


-- -----------------------------------------------------
-- Table `db_vendas`.`reg_detalhe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`reg_detalhe` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idregcabecalho` INT NULL DEFAULT NULL,
  `idproduto` INT NULL DEFAULT NULL,
  `quantidade` DOUBLE NULL DEFAULT NULL,
  `valor` DOUBLE NULL DEFAULT NULL,
  `desconto` DOUBLE NULL DEFAULT NULL,
  `nosso` TINYINT NULL DEFAULT NULL,
  `reservar` TINYINT NULL DEFAULT NULL,
  `parceiro` TINYINT NULL DEFAULT NULL,
  `usuario` CHAR(50) NULL DEFAULT NULL,
  `dtReg` DATETIME NULL DEFAULT NULL,
  `nome` CHAR(150) NULL DEFAULT NULL,
  `observacao` CHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idregcabecalho_fk_idx` (`idregcabecalho` ASC) VISIBLE,
  INDEX `idproduto_fk_idx` (`idproduto` ASC) VISIBLE,
  CONSTRAINT `idproduto_fk`
    FOREIGN KEY (`idproduto`)
    REFERENCES `db_vendas`.`produto` (`id`),
  CONSTRAINT `idregcabecalho_fk`
    FOREIGN KEY (`idregcabecalho`)
    REFERENCES `db_vendas`.`reg_cabecalho` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin
COMMENT = 'nesta tabela são relacionados os produtos pertencentes a um cabeçalho de documento';


-- -----------------------------------------------------
-- Table `db_vendas`.`reg_financeiro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`reg_financeiro` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `id_regcabecalho` INT NULL DEFAULT NULL,
  `dtorigem` DATETIME NULL DEFAULT NULL,
  `dtvencto` DATETIME NULL DEFAULT NULL,
  `dtRenegociacao` DATETIME NULL DEFAULT NULL,
  `dtvencto2` DATETIME NULL DEFAULT NULL,
  `valor` DOUBLE NULL DEFAULT NULL,
  `saldo` DOUBLE NULL DEFAULT NULL,
  `logCadastro` CHAR(60) NULL DEFAULT NULL,
  `usuario` CHAR(100) NULL DEFAULT NULL,
  `descontoPercent` DOUBLE NULL DEFAULT NULL,
  `descontoUnit` DOUBLE NULL DEFAULT NULL,
  `acrescimo` DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `idreg_cabecalho_fk_idx` (`id_regcabecalho` ASC) VISIBLE,
  CONSTRAINT `id_regcabecalho`
    FOREIGN KEY (`id_regcabecalho`)
    REFERENCES `db_vendas`.`reg_cabecalho` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`tipo_pagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`tipo_pagamento` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`tipo_financeiro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`tipo_financeiro` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT 'Campo tipo define se é crédito ou débito: 0 - crédito e 1 - débito.',
  `desc_financeiro` CHAR(50) NULL DEFAULT NULL,
  `tipo` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`reg_financeiro_pagto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`reg_financeiro_pagto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `id_tipopagamento` INT NULL DEFAULT NULL,
  `id_regfinanceiro` INT NULL DEFAULT NULL,
  `tipo_financeiro_id` INT NULL,
  `dtpagto` DATETIME NULL DEFAULT NULL,
  `diasatraso` DOUBLE NULL DEFAULT NULL,
  `valorpagto` DOUBLE NULL DEFAULT NULL,
  `observacao` CHAR(150) NULL DEFAULT NULL,
  `terceiro` TINYINT NULL DEFAULT '0' COMMENT '0 para falso \\\\n1 para true; \\\\nparâmetro destinado ao controle de cheques.',
  `usuario` CHAR(80) NULL DEFAULT NULL,
  `logCadastro` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `id_formapagto_idx` (`id_tipopagamento` ASC) VISIBLE,
  INDEX `id_regfinanceiro_idx` (`id_regfinanceiro` ASC) VISIBLE,
  INDEX `fk_reg_financeiro_pagto_tipo_financeiro1_idx` (`tipo_financeiro_id` ASC) VISIBLE,
  CONSTRAINT `id_regfinanceiro`
    FOREIGN KEY (`id_regfinanceiro`)
    REFERENCES `db_vendas`.`reg_financeiro` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `id_tipopagto`
    FOREIGN KEY (`id_tipopagamento`)
    REFERENCES `db_vendas`.`tipo_pagamento` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_reg_financeiro_pagto_tipo_financeiro1`
    FOREIGN KEY (`tipo_financeiro_id`)
    REFERENCES `db_vendas`.`tipo_financeiro` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`saldo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`saldo` (
  `id` INT NOT NULL,
  `descricao` CHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`saldo_produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`saldo_produto` (
  `id` INT NOT NULL,
  `idproduto` INT NULL DEFAULT NULL,
  `idsaldo` INT NULL DEFAULT NULL,
  `quantidade` DOUBLE NULL DEFAULT NULL,
  `dataSaldo` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idproduto_idx` (`idproduto` ASC) VISIBLE,
  INDEX `idsaldo_idx` (`idsaldo` ASC) VISIBLE,
  CONSTRAINT `idproduto`
    FOREIGN KEY (`idproduto`)
    REFERENCES `db_vendas`.`produto` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `idsaldo`
    FOREIGN KEY (`idsaldo`)
    REFERENCES `db_vendas`.`saldo` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;


-- -----------------------------------------------------
-- Table `db_vendas`.`sysusuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`sysusuario` (
  `idsysUsuario` INT NOT NULL,
  `sysUsuario` CHAR(50) NULL DEFAULT NULL,
  `sysSenha` CHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`idsysUsuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin
COMMENT = 'tabela de usuários		';


-- -----------------------------------------------------
-- Table `db_vendas`.`sysvendas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_vendas`.`sysvendas` (
  `idsysVendas` INT NOT NULL,
  `descricao` CHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`idsysVendas`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = UTF8MB4
COLLATE = UTF8MB4_bin;

USE `db_vendas` ;

-- -----------------------------------------------------
-- procedure sp_banco_seleciona_banco
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_banco_seleciona_banco`()
BEGIN

select * from banco;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_categoria_produto_seleciona_categorias
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_categoria_produto_seleciona_categorias`()
BEGIN

select descricao as "Descricao" from categoria_produto;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_documento_seleciona_docEntrada
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_documento_seleciona_docEntrada`()
BEGIN
 select documento.id as 'Id',
			documento.descricao as 'Descricao', 
				documento.geraFinanceiro as 'Gera Financeiro', 
					documento.movimentaEstoque as 'Movimenta Estoque', 
						documento.aceitaVale as 'Permite Vale' from documento
							where documento.tipo=0;
 
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_documento_seleciona_docSaida
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_documento_seleciona_docSaida`()
BEGIN
select documento.id as 'Id',
		documento.descricao as 'Descricao', 
         documento.geraFinanceiro as 'Gera Financeiro', 
          documento.movimentaEstoque as 'Movimenta Estoque', 
           documento.aceitaVale as 'Permite Vale' from documento where documento.tipo=1;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_atualiza_endereco
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_atualiza_endereco`(IN idpessoa int, 
											idendereco int, 
                                            tipo char(50), 
                                            rua char(100), 
                                            bairro char(50), 
                                            obs text, 
                                            idcidade int,                                        
                                            cep char(8),
                                            usuario char(50),
                                            OUT MSG CHAR(100))
BEGIN

update endereco set tipo = tipo, 
                    rua = rua, 
                    bairro = bairro, 
                    obs = obs , 
                    cidade = idcidade, 
                    cep = cep, 
                    logAlteracao = now(),
					usuario = usuario
                    where endereco.pessoa=idpessoa 
						  and endereco.idendereco=idendereco;
                          SET MSG ="Endereço Atualizado";
                          SELECT MSG;                          
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_exclui_endereco
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_exclui_endereco`(in idendereco int, idpessoa int )
BEGIN

delete endereco.* from endereco where endereco.idendereco=idendereco and endereco.pessoa=idpessoa;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_novo_endereco
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_novo_endereco`(IN tipo char(50), 
																			idpessoa int,  
                                                                            rua char(100), 
                                                                            bairro char(100), 
                                                                            cep char(8), 
                                                                            obs text,  
                                                                            idcidade int, 
																			usuario char(100),
										OUT msg char(100))
BEGIN

INSERT INTO endereco ( cidade, pessoa, tipo, rua, bairro, cep, obs, logCadastro, usuario) 
VALUES (idcidade, idpessoa, tipo ,rua, bairro, cep, obs,  now(), usuario);
set msg = "Novo Endereço Cadastrado";
select msg;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_seleciona_cidade
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_seleciona_cidade`(IN uf int)
BEGIN

select cidade.id, cidade.nome from cidade where cidade.uf=uf ;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_seleciona_endereco
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_seleciona_endereco`(IN idpessoa int)
BEGIN

select endereco.idendereco as Id,
	   endereco.tipo as Tipo, 
       endereco.rua as Rua ,
       endereco.bairro as Bairro, 
       endereco.cep as Cep ,
       endereco.obs as Obs, 
       estado.uf as Uf ,
       cidade.nome as Cidade,
	   endereco.logAlteracao, 
       endereco.logCadastro,
       endereco.usuario
					from endereco inner join cidade 
											on endereco.cidade=cidade.id
								  inner join estado 
											on estado.id = cidade.uf
                    where endereco.pessoa= idpessoa;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_seleciona_estados
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_endereco_seleciona_estados`()
BEGIN

select estado.id, 
		estado.uf from estado; 

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_financeiro_exclui_financeiro
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_financeiro_exclui_financeiro`(in id_regcabecalho int)
BEGIN
START TRANSACTION;

delete from reg_financeiro where reg_financeiro.id_regcabecalho=id_regcabecalho;

COMMIT;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_financeiro_novo_financeiro
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_financeiro_novo_financeiro`( in id_regcabecalho int, 														
																				 valor double, 
																				 descontoPercent double,
                                                                                 descontoUnit double, 
                                                                                 acrescimo double,
																				 usuario char(60), 
                                                                               out id int )
BEGIN
START TRANSACTION;
INSERT INTO reg_financeiro ( id_regcabecalho, dtorigem , valor, saldo, logCadastro ,usuario, descontoPercent, descontoUnit, acrescimo) 
VALUES (id_regcabecalho, now(), valor, valor, now(), usuario, descontoPercent, descontoUnit, acrescimo);
COMMIT;
set id=last_insert_id();
select id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_financeiro_seleciona_financeiroPessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_financeiro_seleciona_financeiroPessoa`(in id int)
BEGIN
	
select reg_financeiro.id_regcabecalho as "Nº Documento", 
		reg_financeiro.id as "Registro Financeiro",	
		case when reg_financeiro.saldo>0 
			then "em Aberto" else "Fechado" end as "Status",			
			 reg_financeiro.dtorigem as "Origem", 
              reg_financeiro.dtvencto as "Vencimento", 
               reg_financeiro.dtRenegociacao as "Renegociação", 
                reg_financeiro.dtvencto2 as "Vencimento 2", 
                 reg_financeiro.valor as "Valor", 
                  reg_financeiro.saldo as "Saldo" from reg_financeiro 
													inner join reg_cabecalho 
														on reg_financeiro.id_regcabecalho = reg_cabecalho.id 																
														where  reg_cabecalho.idpessoa=id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pagamento_novo_pagamento
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pagamento_novo_pagamento`( in id_regfinanceiro int, 																							
																			   id_tipopagamento int,
																			   valor double, 
                                                                               observacao char(150), 
                                                                               terceiro bool,
																			   usuario char(60))
BEGIN
START TRANSACTION;
INSERT INTO reg_financeiro_pagto ( id_regfinanceiro, id_tipopagamento, dtpagto, valorpagto, observacao, terceiro, usuario,logCadastro) 
VALUES (id_regfinanceiro, id_tipopagamento, now() ,valor, observacao, terceiro, usuario, logCadastro);
COMMIT;
START TRANSACTION; 
UPDATE reg_financeiro SET reg_financeiro.saldo=reg_financeiro.saldo-valor where reg_financeiro.id=id_regfinanceiro;
COMMIT;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_atualiza_pessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_atualiza_pessoa`(IN idpessoa int, 
																			tipoPessoa int , 
                                                                            nome char(150) ,
                                                                            nascimento datetime, 
                                                                            complemento char(150), 
																			telefone char(10), 
																			celular char(11), 
																			email char(150), 
																			email2 char(150), 
																			cpf char(15), 
																			cnpj char(15),
																			anotacoes text,
																			usuario char(100))
BEGIN
START TRANSACTION;
    UPDATE pessoa SET nome=nome, 
					  tipoPessoa = tipoPessoa,
					  nascimento=nascimento, 
					  complemento=complemento,                
					  telefone=telefone, 
					  celular=celular, 
					  email=email, 
					  email2=email2, 
					  cpf=cpf, 
					  cnpj=cnpj,                   
					  logAlteracao = Now(), 
                      anotacoes=anotacoes,
                      usuario=usuario
						  where pessoa.id = idpessoa;
COMMIT;
             
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_filtra_pessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_filtra_pessoa`(IN id int)
BEGIN

	select pessoa.tipoPessoa, 
			pessoa.id,			
             pessoa.nome, 
			  pessoa.complemento, 
			   pessoa.nascimento, 
                pessoa.telefone, 
                 pessoa.celular, 
                  pessoa.email, 
                   pessoa.email2, 
					pessoa.cpf, 
					 pessoa.cnpj, 
					  pessoa.logAlteracao, 
					   pessoa.logCadastro, 
						pessoa.anotacoes, 
						 pessoa.usuario from pessoa where pessoa.id=id ;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_filtra_pessoaVenda
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_filtra_pessoaVenda`()
BEGIN
 select pessoa.id,
		pessoa.nome,
        pessoa.cpf
				from pessoa;  

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_filtra_umaPessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_filtra_umaPessoa`(in id int)
BEGIN
select pessoa.id,			
		pessoa.tipoPessoa, 
         pessoa.nome, 
		  pessoa.complemento, 
		   pessoa.nascimento, 
            pessoa.telefone, 
             pessoa.celular, 
              pessoa.email, 
               pessoa.email2, 
		     	pessoa.cpf, 
			     pessoa.cnpj, 
				  pessoa.logAlteracao, 
				   pessoa.logCadastro, 
					pessoa.anotacoes, 
					 pessoa.usuario from pessoa where pessoa.id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_nova_pessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_nova_pessoa`(IN nome char(150), 
																		tipoPessoa int, 
                                                                        nascimento datetime, 
                                                                        complemento char(150),
                                                                        telefone char(10), 
																		celular char(11), 
                                                                        email char(150), 
                                                                        email2 char(150), 
                                                                        cpf char(15), 
                                                                        cnpj char(15), 
                                                                        usuario char(100),
                                                                        OUT msg char(25))
BEGIN     
		START TRANSACTION;	
             
        
        INSERT INTO pessoa ( nome, tipoPessoa ,nascimento, complemento,  telefone, celular, email, email2, cpf, cnpj,anotacoes , logCadastro, usuario)
				 	VALUES (nome, tipopessoa ,nascimento, complemento, telefone, celular, email, email2, cpf, cnpj, anotacoes ,now(), usuario);    	    
        SET MSG=last_insert_id();        			
        COMMIT;     		
        select msg;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_seleciona_cliente
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_seleciona_cliente`(IN tipoPessoa char(20))
BEGIN
	
  select * from  pessoa where pessoa.tipo=tipoPessoa;  

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_seleciona_fornecedor
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_seleciona_fornecedor`(IN tipoPessoa char(20))
BEGIN
	
  select * from  pessoa where pessoa.tipo=tipoPessoa;  

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_seleciona_pessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_seleciona_pessoa`()
BEGIN

select pessoa.id as Id, 
		tipo_pessoa.descricao as 'Tipo_Pessoa',
	     pessoa.nome as Nome, 
		  pessoa.complemento as Complemento,      
           pessoa.telefone as Telefone, 
            pessoa.celular as Celular, 
             pessoa.email as Email, 
              pessoa.email2 as Email2, 
               pessoa.cpf as CPF, 
                 pessoa.cnpj as CNPJ, 
                  pessoa.logAlteracao as logAlteracao, 
                   pessoa.logCadastro as logCadastro, 
                    pessoa.anotacoes as Anotacoes, 
                     pessoa.nascimento as nascimento,
                      pessoa.usuario as usuario
						from pessoa inner join tipo_pessoa on pessoa.tipoPessoa=tipo_pessoa.id order by pessoa.id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pessoa_seleciona_tipoPessoa
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_pessoa_seleciona_tipoPessoa`()
BEGIN

select tipo_pessoa.id, 
		tipo_pessoa.descricao from tipo_pessoa;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_atualiza_produto
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_atualiza_produto`(in id int, 
													produto char(100), 
													nomeVenda char(100), 
                                                    idCategoria int,
                                                 out msg char(100))
BEGIN

update produto set produto.produto=produto,
					produto.nomeVenda = nomeVenda,
                     produto.id_categoria = idCategoria 
                     where produto.id = id;
         
         set msg = "Produto Atualizado"; 
         select msg;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_novo_produto
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_novo_produto`(  produto char(100),
																		  nomeVenda char(100), 
																		  idCategoria int, 
                                                                          out msg int)
BEGIN

insert into produto (produto, nomeVenda, id_categoria) values (produto,	nomeVenda, idCategoria);  
                         set msg=last_insert_id();           
select msg;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_seleciona_produto
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_seleciona_produto`(in id int)
BEGIN

select produto.id, 
		produto.produto as "Item" , 
         produto.nomeVenda as "Nome",  
          categoria_produto.descricao as "Categoria" from produto inner join categoria_produto on produto.id_categoria=categoria_produto.id
          where produto.id=id;
				
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_seleciona_produtos
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_seleciona_produtos`()
BEGIN

select produto.id, 
		produto.produto as "Item" , 
         produto.nomeVenda as "Nome",  
          categoria_produto.descricao as "Categoria" from produto inner join categoria_produto on produto.id_categoria=categoria_produto.id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_seleciona_produtos_com_saldo
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_produto_seleciona_produtos_com_saldo`()
BEGIN

select a.id as 'Id', 
		a.produto as 'Produto' ,  
        a.quantidade as 'Saldo', 
          '25' as 'Preço' from (        
select distinct produto.id, 
		produto.produto, 
         saldo_produto.quantidade, 
          max(saldo_produto.datasaldo) as ultima_versao
		   from produto inner join saldo_produto on produto.id = saldo_produto.idproduto 
							inner join saldo on saldo_produto.idsaldo = saldo.id 
                             where saldo.id=1 
                             group by produto.id) as a;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regcab_exclui
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regcab_exclui`(in _idregcabecalho int)
BEGIN

delete from  reg_cabecalho where reg_cabecalho.id=_idregcabecalho;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regcab_novo
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regcab_novo`( IN _iddocumento int,
																  _pessoa int,                
																  OUT regcab INT)
BEGIN
 start transaction;
		insert into reg_cabecalho (iddocumento, idpessoa, dtentrada) values (_iddocumento, _pessoa, now());
        SET regcab = last_insert_id();
commit;
        SELECT regcab;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regdet_atualiza_saida
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regdet_atualiza_saida`(IN _idregcabecalho int, 
																 _idproduto int, 
																 _iddocumento int,
																 _quantidade double, 
																 _valor double,    							
																 _parceiro bool, 
																 _nosso bool, 
																 _reservar bool,
																 _usuario char(50))
BEGIN
DECLARE oldqtd INT;

if((select idproduto from reg_detalhe where idproduto=_idproduto and idregcabecalho=_idregcabecalho)=_idproduto)
then 
	set oldqtd = (select quantidade from reg_detalhe where idproduto=_idproduto and idregcabecalho=_idregcabecalho);
    
    update saldo_produto set quantidade=(quantidade+oldqtd), dataSaldo=now()  where idproduto=_idproduto; 
	
    delete from reg_detalhe where reg_detalhe.idproduto = _idprodututo and reg_detalhe.idregcabecalho = _idregcabecalho;
                            
    else 
    call sp_regdet_novo(_idregcabecalho, _idproduto, _iddocumento, _quantidade, _valor, _parceiro, _nosso, _reservar, _usuario);
   
end if;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regdet_exclui
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regdet_exclui`(IN _idregcabecalho int, 
										_idproduto int )
BEGIN
DECLARE oldqtd INT;
	set oldqtd = (select quantidade from reg_detalhe where idproduto=_idproduto and reg_detalhe.idregcabecalho=_idregcabecalho);    
    update saldo_produto set saldo_produto.quantidade=(saldo_produto.quantidade+oldqtd), dataSaldo=now()  where saldo_produto.idproduto=_idproduto; 	
    delete from reg_detalhe where reg_detalhe.idproduto=_idproduto and reg_detalhe.idregcabecalho=_idregcabecalho;	
    delete from reg_financeiro where reg_financeiro.id_regcabecalho=_idregcabecalho;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regdet_inativa_saida
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regdet_inativa_saida`(IN _idregcabecalho int, 
																		  _idproduto int)
BEGIN
DECLARE oldqtd INT;	
START TRANSACTION;    
    set oldqtd = (select quantidade from reg_detalhe where idproduto=_idproduto and idregcabecalho=_idregcabecalho);    
    update saldo_produto set quantidade=(quantidade+oldqtd), dataSaldo=now()  where idproduto=_idproduto; 	
    update reg_cabecalho set reg_cabecalho.statusCab=1 where reg_cabecalho.id=_idregcabecalho;
    delete from reg_detalhe where reg_detalhe.idproduto=_idproduto and reg_detalhe.idregcabecalho=_idregcabecalho;
COMMIT;    
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_regdet_novo
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_regdet_novo`(IN _idregcabecalho int, 
																 _idproduto int, 
																 _iddocumento int,
																 _quantidade double, 
																 _valor double,    							/* parametros de dados vindos do sistema*/
																 _parceiro bool, 
																 _nosso bool, 
																 _reservar bool,
																 _usuario char(50))
BEGIN
	   IF	((select tipo from documento where documento.id=_iddocumento)=1)	/* 1 é documento de saída.*/		
       THEN	
			 insert into reg_detalhe (idregcabecalho, idproduto, quantidade, valor, parceiro, nosso, reservar, usuario, dtReg)/* insiro item valor e quantidades em detalhes de produto*/
			 value (_idregcabecalho,_idproduto,_quantidade,_valor,_parceiro,_nosso,_reservar, _usuario, now());            
			
             update saldo_produto set quantidade=(quantidade-_quantidade), dataSaldo=now()  where idproduto=_idproduto; 
		
        ELSEIF ((select tipo from documento where documento.id=_iddocumento)=0)/*0 documento de entrada*/
        THEN  
             insert into reg_detalhe (idregcabecalho, idproduto, quantidade, valor, parceiro, nosso, reservar, usuario, dtReg)/* insiro item valor e quantidades em detalhes de produto*/
			 value (_idregcabecalho,_idproduto,_quantidade,_valor,_parceiro,_nosso,_reservar, _usuario, now());            
                
             /* subtraio quantidade da tabela de estoque. */ 
             update saldo_produto set quantidade=(quantidade+_quantidade), dataSaldo=now()  where idproduto=_idproduto; 
		END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_saldo_seleciona_saldo
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_saldo_seleciona_saldo`()
BEGIN
select saldo.id as IdSaldo,
		saldo.descricao as DescSaldo from saldo;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_sys_auth
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_sys_auth`(IN sysusuario char(50), syssenha char(50), OUT sts tinyint)
BEGIN

SET sts = (select count(sysusuario.sysusuario) from sysusuario where sysusuario.sysusuario=sysusuario and sysusuario.syssenha=syssenha);
SELECT sts;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_venda_seleciona_cabecalhovenda
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_venda_seleciona_cabecalhovenda`(in id int)
BEGIN
select reg_cabecalho.id as "NroDoc", 	
		pessoa.nome as "Cliente", 
		 reg_cabecalho.dtEntrada as "Data",
			b.total as "Total", 
			case when reg_financeiro.descontoPercent is null then 0 else reg_financeiro.descontoPercent end as descontoPercent, 
              case when reg_financeiro.descontoUnit is null then 0 else reg_financeiro.descontoUnit end as descontoUnit, 
               case when reg_financeiro.descontoUnit is null then 0 else reg_financeiro.acrescimo end as acrescimo          
				 from reg_cabecalho 
					  inner join pessoa 
							on reg_cabecalho.idpessoa = pessoa.id
					  left join reg_financeiro 
							on reg_cabecalho.id = reg_financeiro.id_regcabecalho
                      	left join (select reg_detalhe.idregcabecalho, sum(reg_detalhe.valor*reg_detalhe.quantidade) as total from reg_detalhe where reg_detalhe.idregcabecalho=id ) as b
							on b.idregcabecalho=reg_cabecalho.id
							where reg_cabecalho.id=id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_venda_seleciona_financeirovenda
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_venda_seleciona_financeirovenda`(in id int)
BEGIN

select reg_financeiro_pagto.id, 
		reg_financeiro_pagto.id_tipopagamento,
		reg_financeiro_pagto.valorpagto 
			from reg_financeiro_pagto 
					inner join reg_financeiro 
						on reg_financeiro_pagto.id_regfinanceiro=reg_financeiro.id
                        inner join reg_cabecalho 
                        on reg_financeiro.id_regcabecalho=reg_cabecalho.id				    
                        where reg_cabecalho.id=id ;
                
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_venda_seleciona_itensvenda
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_venda_seleciona_itensvenda`(in id int)
BEGIN

select produto.id as "Id",
			produto.produto as "Item",
			 reg_detalhe.nome as "Nome", 
			  reg_detalhe.parceiro as "Parceiro", 
			   reg_detalhe.nosso as "Nosso", 
				reg_detalhe.reservar as "Reservar", 
				 reg_detalhe.observacao as "Obs",
				  reg_detalhe.quantidade as "Qtd", 
				   reg_detalhe.valor as "Valor", 
                    reg_detalhe.valor*reg_detalhe.quantidade as "Total"
			   from reg_detalhe inner join produto
										on reg_detalhe.idproduto = produto.id			
					where reg_detalhe.idregcabecalho=id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_venda_seleciona_venda
-- -----------------------------------------------------

DELIMITER $$
USE `db_vendas`$$
CREATE DEFINER=`admin`@`localhost` PROCEDURE `sp_venda_seleciona_venda`()
BEGIN
/*procedure de agregação dos pedidos de venda realizados.*/
select  reg_cabecalho.id as "Id Venda", 
		case when reg_financeiro_pagto.id_regfinanceiro is null then  "Orçamento"
			 when reg_financeiro_pagto.id_regfinanceiro is not null then "Finalizada"
             when reg_cabecalho.statusCab=1 then "Cancelada" end as "Status",
		documento.descricao as "Tipo Doc", 
		pessoa.nome "Pessoa",        
        reg_cabecalho.dtEntrada as "Data Venda",
        case when reg_financeiro.valor>reg_financeiro_pagto.vlrpagamento or reg_financeiro_pagto.vlrpagamento is null
        then "Aberto" 
        when reg_financeiro.valor>=reg_financeiro_pagto.vlrpagamento 
        then "Pago" end as "Status Financeiro",
        case when reg_financeiro.id is null then reg_detalhe.total
        when reg_financeiro.id is not null then reg_financeiro.valor end as "Valor Venda", 
		case when reg_financeiro_pagto.vlrpagamento is null then 0 
        when reg_financeiro_pagto.vlrpagamento>0 then reg_financeiro_pagto.vlrpagamento end as  "Valor Pagamento"
		from reg_cabecalho 						
						inner join documento 
							on documento.id = reg_cabecalho.iddocumento				
						inner join pessoa 
							on pessoa.id = reg_cabecalho.idpessoa
                        left join reg_financeiro 
							on reg_cabecalho.id=reg_financeiro.id_regcabecalho 
                        left join 
                         (select id_regfinanceiro ,sum(valorpagto) as vlrpagamento 
										from reg_financeiro_pagto 
                                        group by id_regfinanceiro) as reg_financeiro_pagto
						on reg_financeiro_pagto.id_regfinanceiro=reg_financeiro.id  
                        left join 
                        (select reg_detalhe.idregcabecalho, sum(reg_detalhe.valor*reg_detalhe.quantidade) as total 
															from reg_detalhe where reg_detalhe.idregcabecalho=id 
															 group by reg_detalhe.idregcabecalho ) as reg_detalhe
						on reg_detalhe.idregcabecalho=reg_cabecalho.id
                        
                        order by reg_cabecalho.id, reg_cabecalho.dtEntrada;


END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
