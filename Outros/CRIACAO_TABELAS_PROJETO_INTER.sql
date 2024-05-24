DROP DATABASE IF EXISTS BD_CERTIFICADOS
GO
CREATE DATABASE BD_CERTIFICADOS
GO

USE BD_CERTIFICADOS
GO

DROP TABLE IF EXISTS PESSOAS
GO
CREATE TABLE PESSOAS
(
	ID_PESSOA			UNIQUEIDENTIFIER	PRIMARY KEY,
	NOME				VARCHAR(128)		NOT NULL,
	EMAIL				VARCHAR(320)			NULL		UNIQUE, --� NECESS�RIO FALAR QUE � UM VALOR �NICO?
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVA, 1 = ATIVA
)
GO

DROP TABLE IF EXISTS EMPRESAS
GO
CREATE TABLE EMPRESAS
(
	ID_EMPRESA			UNIQUEIDENTIFIER	PRIMARY KEY,
	CNPJ				VARCHAR(18)			NOT NULL		UNIQUE,
	RAZAO_SOCIAL		VARCHAR(128)		NOT NULL,
	EMAIL				VARCHAR(320)		NOT NULL		UNIQUE,
	STATUS				INT					NOT	NULL		CHECK(STATUS IN (0,1)),-- 1 = ATIVO, 0 = INATIVO
)
GO

DROP TABLE IF EXISTS TELEFONES_PESSOAS
GO
CREATE TABLE TELEFONES_PESSOAS
(
	ID_TELEFONE_PES		UNIQUEIDENTIFIER,
	PESSOA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES PESSOAS,
	NRO_TELEFONE		VARCHAR(15)				NULL,
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
	PRIMARY KEY(ID_TELEFONE_PES, PESSOA_ID)
)
GO

DROP TABLE IF EXISTS TELEFONES_EMPRESAS
GO
CREATE TABLE TELEFONES_EMPRESAS
(
	ID_TELEFONE_EMP		UNIQUEIDENTIFIER	NOT NULL,
	EMPRESA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES EMPRESAS,
	NRO_TELEFONE		VARCHAR(15)			NOT NULL		UNIQUE,
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
	PRIMARY KEY(ID_TELEFONE_EMP, EMPRESA_ID)
)
GO

DROP TABLE IF EXISTS ENDERECOS_EMPRESAS
GO
CREATE TABLE ENDERECOS_EMPRESAS
(
	ID_ENDERECO			UNIQUEIDENTIFIER	NOT NULL,
	CEP					VARCHAR(16)			NOT NULL,
	ESTADO				VARCHAR(20)			NOT NULL,
	CIDADE				VARCHAR(32)			NOT NULL,
	BAIRRO				VARCHAR(128)		NOT NULL,
	NOME_RUA			VARCHAR(128)		NOT NULL,
	NUMERO				INT					NOT NULL,
	COMPLEMENTO			VARCHAR(128)			NULL,
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
	EMPRESA_ID			UNIQUEIDENTIFIER	NOT	NULL,
	PRIMARY KEY(ID_ENDERECO, EMPRESA_ID)
)
GO

DROP TABLE IF EXISTS USUARIOS
GO
CREATE TABLE USUARIOS
(
	PESSOA_ID			UNIQUEIDENTIFIER	PRIMARY KEY		REFERENCES PESSOAS,
	NOME_USUARIO		VARCHAR(32)			NOT NULL,
	SENHA				VARCHAR(128)		NOT NULL, -- FAZER VERIFICA��O DO TAMANHO AQUI?
	STATUS				INT					NOT	NULL		CHECK(STATUS IN (0,1)), -- 0 = INATIVO, 1 = ATIVO
)
GO

DROP TABLE IF EXISTS ALUNOS
GO
CREATE TABLE ALUNOS
(
	PESSOA_ID			UNIQUEIDENTIFIER	PRIMARY KEY		REFERENCES PESSOAS,
	CPF					VARCHAR(14)				NULL		UNIQUE,
	RG					VARCHAR(14)				NULL		UNIQUE,
	ASSINATURA			VARCHAR(32)				NULL,
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
	USUARIO_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES USUARIOS,
)
GO

DROP TABLE IF EXISTS PROVAS
GO
CREATE TABLE PROVAS
(
	ID_PROVA			UNIQUEIDENTIFIER	PRIMARY KEY,
	DATA_PROVA			DATE				NOT NULL,
	PESSOA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES ALUNOS,
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
)
GO

DROP TABLE IF EXISTS QUESTOES
GO
CREATE TABLE QUESTOES
(
	ID_QUESTAO			UNIQUEIDENTIFIER	PRIMARY KEY,
	PERGUNTA			VARCHAR(500)		NOT NULL,
	STATUS				INT					NOT	NULL	CHECK(STATUS IN (0,1)), -- 0 = INATIVO, 1 = ATIVO
)
GO
	
DROP TABLE IF EXISTS PROVAS_QUESTOES
GO
CREATE TABLE PROVAS_QUESTOES
(
	PROVA_ID		UNIQUEIDENTIFIER	NOT NULL	REFERENCES PROVAS,
	QUESTAO_ID		UNIQUEIDENTIFIER	NOT NULL	REFERENCES QUESTOES,
	PRIMARY KEY(PROVA_ID, QUESTAO_ID)
)
GO

DROP TABLE IF EXISTS ALTERNATIVAS
GO
CREATE TABLE ALTERNATIVAS
(
	ID_ALTERNATIVA		UNIQUEIDENTIFIER	PRIMARY KEY,
	CONTEUDO			VARCHAR(400)		NOT NULL,
	RESPOSTA			INT					NOT NULL		CHECK(RESPOSTA IN (0,1)), -- 1 = RESPOSTA CERTA, 0 = RESPOSTA ERRADA
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- O = INATIVA, 1 = ATIVA
	QUESTAO_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES QUESTOES
)
GO

DROP TABLE IF EXISTS CONTEUDOS_PROGRAMATICOS
GO
CREATE TABLE CONTEUDOS_PROGRAMATICOS
(
	ID_CONTEUDO			UNIQUEIDENTIFIER	PRIMARY KEY,
	ASSUNTO				VARCHAR(200)		NOT NULL,
	CARGA_HORARIA		INT						NULL,
	STATUS				INT					NOT	NULL, --	O = INATIVA, 1 = ATIVA
)
GO

DROP TABLE IF EXISTS CURSOS
GO
CREATE TABLE CURSOS
(
	ID_CURSO			UNIQUEIDENTIFIER	PRIMARY KEY,
	NOME_CURSO			VARCHAR(100)		NOT NULL,
	LOGO				VARCHAR(100)		NOT NULL,
	CARGA_HORARARIA_PER	INT					NOT NULL,
	CARGA_HORARIA_INI	INT					NOT NULL,
	VALIDADE			INT					NOT NULL, -- VALIDADE � DADA EM MESES
	STATUS				INT					NOT	NULL -- 0 = INATIVO, 1 = ATIVO
)
GO

DROP TABLE IF EXISTS CURSOS_CONTEUDOS
GO
CREATE TABLE CURSOS_CONTEUDOS
(
	CURSO_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES CURSOS,
	CONTEUDO_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES CONTEUDOS_PROGRAMATICOS,
	STATUS			INT					NOT NULL, -- 0 = INATIVO, 1 = ATIVO
	PRIMARY KEY(CURSO_ID, CONTEUDO_ID)
)
GO

DROP TABLE IF EXISTS CURSOS_QUESTOES
GO
CREATE TABLE CURSOS_QUESTOES
(
	CURSO_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES CURSOS,
	QUESTAO_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES QUESTOES,
	STATUS			INT			NOT NULL, -- 0 = INATIVO, 1 = ATIVO
	PRIMARY KEY(CURSO_ID, QUESTAO_ID)
)
GO

DROP TABLE IF EXISTS TREINAMENTOS
GO
CREATE TABLE TREINAMENTOS
(
	ID_TREINAMENTO		UNIQUEIDENTIFIER	PRIMARY KEY,
	TIPO				INT					NOT NULL		CHECK(TIPO IN (1, 2)), -- 1 = INICIAL, 2 = PERIODICA
	SITUACAO			INT									CHECK(SITUACAO IN (0, 1, 2, 3, 4)), -- 0 = CANCELADO, 1 = EM ANDAMENTO, 2 - NAO COMPARECEU, 3 = CONCLUIDO,
	CURSO_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES CURSOS,
	STATUS				INT					NOT NULL		CHECK(TIPO IN (0, 1))	--- 0 = INATIVO, 1 = ATIVO
)
GO

DROP TABLE IF EXISTS LISTAS_PRESENCAS
GO
CREATE TABLE LISTAS_PRESENCAS
(
	ID_TREINAMENTO		UNIQUEIDENTIFIER	PRIMARY KEY		REFERENCES TREINAMENTOS,
	CODIGO				VARCHAR(40)			NOT NULL,
	DATA				DATE				NOT NULL
)
GO

DROP TABLE IF EXISTS INSTRUTORES
GO
CREATE TABLE INSTRUTORES
(
	PESSOA_ID			UNIQUEIDENTIFIER	PRIMARY KEY		REFERENCES PESSOAS,
	ESPECIALIZACAO		VARCHAR(50)			NOT NULL,
	ASSINATURA			VARCHAR(100)		NOT NULL,
	REGISTRO			VARCHAR(50)			NOT NULL,
	STATUS				INT					NOT NULL		-- 0 = INATIVO, 1 = ATIVO
)
GO

DROP TABLE IF EXISTS INSTRUTORES_TREINAMENTOS
GO
CREATE TABLE INSTRUTORES_TREINAMENTOS
(
	PESSOA_ID		UNIQUEIDENTIFIER		NOT NULL		REFERENCES INSTRUTORES,
	TREINAMENTO_ID	UNIQUEIDENTIFIER		NOT NULL		REFERENCES TREINAMENTOS,
	PRIMARY KEY(PESSOA_ID, TREINAMENTO_ID)
)
GO

DROP TABLE IF EXISTS CERTIFICADOS
GO
CREATE TABLE CERTIFICADOS
(
	TREINAMENTO_ID		UNIQUEIDENTIFIER	PRIMARY KEY		REFERENCES TREINAMENTOS,
	CODIGO				VARCHAR(40)			NOT NULL,
	DATA_EMISSAO		DATE				NOT NULL,
	SITUACAO			INT						NULL	-- 1 = ENVIADO, 2 = AGUARDANDO RETIRADA, 0 = CANCELADO/INVALIDO
)
GO

DROP TABLE IF EXISTS ALUNOS_TREINAMENTOS
GO
CREATE TABLE ALUNOS_TREINAMENTOS
(
	PESSOA_ID					UNIQUEIDENTIFIER	NOT NULL		REFERENCES ALUNOS,
	TREINAMENTO_ID				UNIQUEIDENTIFIER	NOT NULL		REFERENCES TREINAMENTOS,
	DATA_TREINAMENTO			DATE				NOT NULL,
	DATA_INICIO_CERTIFICADO		DATE				NOT	NULL,
	RESULTADO					INT						NULL, -- 0 = REPROVADO, 1 = APROVADO, 2 = NAO COMPARECEU
	PRIMARY KEY(PESSOA_ID, TREINAMENTO_ID)
)
GO

DROP TABLE IF EXISTS ALUNOS_EMPRESAS
GO
CREATE TABLE ALUNOS_EMPRESAS
(
	ALUNO_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES ALUNOS,
	EMPRESA_ID		UNIQUEIDENTIFIER	NOT NULL		REFERENCES EMPRESAS,
	STATUS					INT			NOT NULL,		-- 0 = INATIVO, 1 = ATIVO
	PRIMARY KEY(ALUNO_ID, EMPRESA_ID)
)
GO

DROP TABLE IF EXISTS CADERNOS_RESPOSTAS
GO
CREATE TABLE CADERNOS_RESPOSTAS
(
	CADERNO_ID			UNIQUEIDENTIFIER	PRIMARY KEY,
	NRO_PERGUNTA		INT					NOT NULL,
	ALT_SELECIONADA		VARCHAR(1)				NULL,
	PESSOA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES ALUNOS
)
GO


----------------------------------------------------------------------------
--CRIAÇÃO DAS VIEWS DO SISTEMA
----------------------------------------------------------------------------

-- VIEW EMPRESAS ATIVAS
CREATE VIEW V_EMPRESAS_ATI AS
	SELECT 
		EMP.RAZAO_SOCIAL, 
		EMP.CNPJ,
		EMP.EMAIL, 
		TELEMP.NRO_TELEFONE, 
		ENDEMP.NOME_RUA + ', ' + convert(varchar,ENDEMP.NUMERO) AS ENDERECO, 
		CID.NOME_CIDADE + '-' + EST.UF AS CIDADE
	FROM EMPRESAS EMP
	INNER JOIN TELEFONES_EMPRESAS TELEMP ON TELEMP.EMPRESA_ID = EMP.ID_EMPRESA
	INNER JOIN ENDERECOS_EMPRESAS ENDEMP ON ENDEMP.EMPRESA_ID = EMP.ID_EMPRESA
	INNER JOIN CIDADES CID ON CID.ID_CIDADE = ENDEMP.CIDADE_ID
	INNER JOIN ESTADOS EST ON EST.ID_ESTADO = CID.ESTADO_ID
	WHERE EMP.STATUS = 1
GO

SELECT* FROM V_EMPRESAS_ATI

-- VIEW EMPRESAS INATIVAS
CREATE VIEW V_EMPRESAS_INA AS
	SELECT 
		EMP.RAZAO_SOCIAL, 
		EMP.CNPJ,
		EMP.EMAIL, 
		TELEMP.NRO_TELEFONE, 
		ENDEMP.NOME_RUA + ', ' + convert(varchar,ENDEMP.NUMERO) AS ENDERECO, 
		CID.NOME_CIDADE + '-' + EST.UF AS CIDADE
	FROM EMPRESAS EMP
	INNER JOIN TELEFONES_EMPRESAS TELEMP ON TELEMP.EMPRESA_ID = EMP.ID_EMPRESA
	INNER JOIN ENDERECOS_EMPRESAS ENDEMP ON ENDEMP.EMPRESA_ID = EMP.ID_EMPRESA
	INNER JOIN CIDADES CID ON CID.ID_CIDADE = ENDEMP.CIDADE_ID
	INNER JOIN ESTADOS EST ON EST.ID_ESTADO = CID.ESTADO_ID
	WHERE EMP.STATUS = 0
GO

SELECT* FROM V_EMPRESAS_INA

-- VIEW ALUNOS GERAL
CREATE VIEW V_ALUNOS_GER AS
	SELECT PE.NOME, AL.CPF, AL.RG, PE.EMAIL, TELPE.NRO_TELEFONE, AL.ASSINATURA
	FROM PESSOAS PE
	INNER JOIN ALUNOS AL ON AL.PESSOA_ID = PE.ID_PESSOA
	INNER JOIN TELEFONES_PESSOAS TELPE ON TELPE.PESSOA_ID = PE.ID_PESSOA
GO

SELECT* FROM V_ALUNOS_GER

-- VIEW ALUNOS Por EMPRESA
-- ISSO DEVE SER FEITO EM CODIGO C#
-- ESSA É APENAS UMA DEMOSTRAÇÃO
DROP PROCEDURE IF EXISTS retornaAlunoPorEmpresa;

CREATE PROCEDURE retornaAlunoPorEmpresa
    @nomeEmpresa varchar(255) -- ou ID da empresa
	AS
	BEGIN
		BEGIN TRY
			SELECT PE.NOME, AL.CPF, AL.RG, PE.EMAIL, TELPE.NRO_TELEFONE, AL.ASSINATURA
			FROM PESSOAS PE
			INNER JOIN ALUNOS AL ON AL.PESSOA_ID = PE.ID_PESSOA
			INNER JOIN TELEFONES_PESSOAS TELPE ON TELPE.PESSOA_ID = PE.ID_PESSOA
			INNER JOIN ALUNOS_EMPRESAS ALEMP ON ALEMP.ALUNO_ID = AL.PESSOA_ID
			INNER JOIN EMPRESAS EMP ON EMP.ID_EMPRESA = ALEMP.EMPRESA_ID
			WHERE EMP.RAZAO_SOCIAL = @nomeEmpresa;
		END TRY
		BEGIN CATCH
        -- Tratamento de erro
			PRINT 'Ocorreu um erro ao executar o procedimento armazenado retornaAlunoPorEmpresa.';
        -- Você pode adicionar instruções adicionais para lidar com o erro, como registrar em um log de erro ou retornar uma mensagem personalizada.
		END CATCH
	END;

EXEC retornaAlunoPorEmpresa @nomeEmpresa = 'Empresa A';

-- VIEW CURSOS ATIVOS TELA PRINCIPAL

CREATE VIEW V_CURSOS_ATI AS
	SELECT C.NOME_CURSO, C.CARGA_HORARARIA_PER, C.CARGA_HORARIA_INI, C.VALIDADE
	FROM CURSOS C
	WHERE C.STATUS = 1
GO

SELECT* FROM V_CURSOS_ATI

-- VIEW CURSOS INATIVOS TELA PRINCIPAL

CREATE VIEW V_CURSOS_INA AS
	SELECT C.NOME_CURSO, C.CARGA_HORARARIA_PER, C.CARGA_HORARIA_INI, C.VALIDADE
	FROM CURSOS C
	WHERE C.STATUS = 0
GO

SELECT* FROM V_CURSOS_INA

-- VIEW TODOS CURSOS ATIVOS E INATIVOS

CREATE VIEW V_CURSOS AS
	SELECT C.NOME_CURSO, C.CARGA_HORARARIA_PER, C.CARGA_HORARIA_INI, C.VALIDADE
	FROM CURSOS C
GO

SELECT* FROM V_CURSOS

-- VIEW CURSO COM MAIS INFORMAÇÕES-- TELA POP UP?

SELECT 
	C.NOME_CURSO,  
	C.CARGA_HORARARIA_PER, 
	C.CARGA_HORARIA_INI, 
	C.VALIDADE, 
	C. STATUS, 
	C.LOGO,
	CP.ASSUNTO + ' - ' + CONVERT(VARCHAR, CP.CARGA_HORARIA) + ' Horas' AS CONTEUDO_PROGRAMATICO
FROM CURSOS	C
INNER JOIN CURSOS_CONTEUDOS CURCON ON CURCON.CURSO_ID = C.ID_CURSO
INNER JOIN CONTEUDOS_PROGRAMATICOS CP ON CP.ID_CONTEUDO = CURCON.CONTEUDO_ID

SELECT*
FROM CONTEUDOS_PROGRAMATICOS


-- CRIAR UMA PROCEDURE PARA MOSTRAR AS QUESTOES DE ACORDO COM O ID DO CURSO
-- NA TELA COM MAIS INFORMAÇÕES DO CURSO DEVE APARECER UM BOTAO PARA VISUALIZAR AS QUESTOES REFERENTES AO CURSO SELECIONADO
-- TRAZER AS ALTERNATIVAS DE CADA QUESTAO TAMBEM

CREATE PROCEDURE mostrarPergunta
	@IdCurso uniqueidentifier
	AS
	BEGIN
		SELECT Q.PERGUNTA
		FROM CURSOS_QUESTOES CQ
		INNER JOIN QUESTOES Q ON Q.ID_QUESTAO = CQ.QUESTAO_ID
		WHERE CQ.CURSO_ID = @IdCurso
	END;

CREATE PROCEDURE trazerAlternativas
	@IdQuestao uniqueidentifier
	AS
	BEGIN
		SELECT A.CONTEUDO
		FROM CURSOS_QUESTOES CQ
		INNER JOIN QUESTOES Q ON Q.ID_QUESTAO = CQ.QUESTAO_ID
		INNER JOIN ALTERNATIVAS A ON A.QUESTAO_ID = Q.ID_QUESTAO
		WHERE Q.ID_QUESTAO = @IdQuestao
	END;

EXECUTE mostrarPergunta @IdCurso = 'A246823D-9FE4-44E8-982D-C71ACAF014A8';

EXECUTE trazerAlternativas @IdQuestao = 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC';

-- VIEW INSTRUTORES ATIVOS

CREATE VIEW V_INSTRUTORES_ATIVO AS
	SELECT 
		P.NOME,
		I.ESPECIALIZACAO,
		I.REGISTRO,
		P.EMAIL,
		TP.NRO_TELEFONE
	FROM PESSOAS P
	INNER JOIN INSTRUTORES I ON I.PESSOA_ID = P.ID_PESSOA
	INNER JOIN	TELEFONES_PESSOAS TP ON TP.PESSOA_ID = P.ID_PESSOA
	WHERE I.STATUS = 1
GO

SELECT* FROM V_INSTRUTORES_ATIVO

-- VIEW INSTRUTORES INATIVOS

CREATE VIEW V_INSTRUTORES_INATIVO AS
	SELECT 
		P.NOME,
		I.ESPECIALIZACAO,
		I.REGISTRO,
		P.EMAIL,
		TP.NRO_TELEFONE
	FROM PESSOAS P
	INNER JOIN INSTRUTORES I ON I.PESSOA_ID = P.ID_PESSOA
	INNER JOIN	TELEFONES_PESSOAS TP ON TP.PESSOA_ID = P.ID_PESSOA
	WHERE I.STATUS = 0
GO

-- VIEW INSTRUTORES

CREATE VIEW V_INSTRUTORES AS
	SELECT 
		P.NOME,
		I.ESPECIALIZACAO,
		I.REGISTRO,
		P.EMAIL,
		TP.NRO_TELEFONE
	FROM PESSOAS P
	INNER JOIN INSTRUTORES I ON I.PESSOA_ID = P.ID_PESSOA
	INNER JOIN	TELEFONES_PESSOAS TP ON TP.PESSOA_ID = P.ID_PESSOA
GO

SELECT* FROM V_INSTRUTORES

-- VIEW TREINAMENTOS

DROP VIEW IF EXISTS V_TREINAMENTOS
GO
CREATE VIEW V_TREINAMENTOS AS
	SELECT
		C.NOME_CURSO, 
		CASE 
			WHEN T.TIPO = 1 THEN C.CARGA_HORARIA_INI 
			ELSE C.CARGA_HORARARIA_PER 
		END AS CARGA_HORARIA,
		ALTRE.DATA_INICIO_CERTIFICADO,
		ALTRE.DATA_TREINAMENTO,
		P.NOME,
		CASE
			WHEN AL.CPF IS NULL THEN AL.RG
			ELSE AL.CPF
		END AS DOCUMENTO,
		P.EMAIL,
		TP.NRO_TELEFONE
	FROM TREINAMENTOS T
	INNER JOIN CURSOS C ON C.ID_CURSO = T.CURSO_ID
	INNER JOIN ALUNOS_TREINAMENTOS ALTRE ON ALTRE.TREINAMENTO_ID = T.ID_TREINAMENTO
	INNER JOIN ALUNOS AL ON AL.PESSOA_ID = ALTRE.PESSOA_ID
	INNER JOIN PESSOAS P ON P.ID_PESSOA = AL.PESSOA_ID
	INNER JOIN TELEFONES_PESSOAS TP ON TP.PESSOA_ID = P.ID_PESSOA
GO

SELECT* FROM V_TREINAMENTOS

-- VIEW CERTIFICADOS
DROP VIEW IF EXISTS V_CERTIFICADOS
GO
CREATE VIEW V_CERTIFICADOS AS
	SELECT
		P.NOME,
		CASE
			WHEN AL.CPF IS NULL THEN AL.RG
			ELSE AL.CPF
		END AS DOCUMENTO,
		CUR.NOME_CURSO,
		CASE 
			WHEN T.TIPO = 1 THEN CUR.CARGA_HORARIA_INI 
			ELSE CUR.CARGA_HORARARIA_PER 
		END AS CARGA_HORARIA,
		CE.DATA_EMISSAO
	FROM CERTIFICADOS CE
	INNER JOIN TREINAMENTOS T ON T.ID_TREINAMENTO = CE.TREINAMENTO_ID
	INNER JOIN CURSOS CUR ON CUR.ID_CURSO = T.CURSO_ID
	INNER JOIN ALUNOS_TREINAMENTOS ALTR ON ALTR.TREINAMENTO_ID = T.ID_TREINAMENTO
	INNER JOIN ALUNOS AL ON AL.PESSOA_ID = ALTR.PESSOA_ID
	INNER JOIN PESSOAS P ON P.ID_PESSOA = ALTR.PESSOA_ID
GO

SELECT* FROM V_CERTIFICADOS;