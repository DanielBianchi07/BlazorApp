﻿-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- DELEÇÃO DO BANCO DE DADOS ANTIGO-------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
USE master;
ALTER DATABASE BD_CERTIFICADOS
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;

WAITFOR DELAY '00:00:05';

DROP DATABASE IF EXISTS BD_CERTIFICADOS
GO

WAITFOR DELAY '00:00:10';

-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- CRIAÇÃO DO NOVO BANCO DE DADOS-------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

CREATE DATABASE BD_CERTIFICADOS
GO

WAITFOR DELAY '00:00:10';

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
	ESTADO				VARCHAR(27)			NOT NULL,
	CIDADE				VARCHAR(32)			NOT NULL,
	BAIRRO				VARCHAR(128)		NOT NULL,
	NOME_RUA			VARCHAR(128)		NOT NULL,
	NUMERO				VARCHAR(5)			NOT NULL,
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
	STATUS				INT					NOT	NULL,		CHECK(STATUS IN (0,1)),-- 0 = INATIVO, 1 = ATIVO
	PESSOA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES ALUNOS,
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
	PROVA_ID			UNIQUEIDENTIFIER	NOT NULL		REFERENCES PROVAS,
	STATUS				INT					NOT NULL		CHECK(STATUS IN (0, 1))	--- 0 = INATIVO, 1 = ATIVO
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
	SITUACAO			INT						NULL		CHECK(SITUACAO IN (0, 1, 2))-- 1 = ENVIADO, 2 = AGUARDANDO RETIRADA, 0 = CANCELADO/INVALIDO
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

WAITFOR DELAY '00:00:10';

USE BD_CERTIFICADOS
GO

WAITFOR DELAY '00:00:10';

-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- INSERÇÕES TESTE NO BANCO DE DADOS-------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

-- Inserções para PESSOAS
INSERT INTO PESSOAS (ID_PESSOA, NOME, EMAIL, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'João Silva', 'joao@example.com', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'Maria Souza', 'maria@example.com', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'Pedro Santos', 'pedro@example.com', 1);

-- Inserções para EMPRESAS
INSERT INTO EMPRESAS (ID_EMPRESA, CNPJ, RAZAO_SOCIAL, EMAIL, STATUS) VALUES
('84A92D79-4BB2-4CA0-BC29-63D63F28D291', '12345678901234', 'Empresa A', 'empresaA@example.com', 1),
('41B5A87E-64C5-4297-B5F9-8D27B4A27F88', '98765432109876', 'Empresa B', 'empresaB@example.com', 1),
('2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', '56789012345678', 'Empresa C', 'empresaC@example.com', 1);

-- Inserções para TELEFONES_PESSOAS
INSERT INTO TELEFONES_PESSOAS (ID_TELEFONE_PES, PESSOA_ID, NRO_TELEFONE, STATUS) VALUES
('5D8A7C32-1535-41F4-A0D7-0ECACBCD92A9', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '111-1111', 1),
('872CD3B1-3D3E-458E-9B8F-786D738DA9C0', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '222-2222', 1),
('D5F0A905-7317-4B12-991A-E10E2178718F', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '333-3333', 1);

-- Inserções para TELEFONES_EMPRESAS
INSERT INTO TELEFONES_EMPRESAS (ID_TELEFONE_EMP, EMPRESA_ID, NRO_TELEFONE, STATUS) VALUES
('69C5870B-9DC4-4CF3-8C86-665D9C0EF7A8', '84A92D79-4BB2-4CA0-BC29-63D63F28D291', '444-4444', 1),
('1B348A0E-66E1-4412-BE5D-FFAD54D7F0F5', '41B5A87E-64C5-4297-B5F9-8D27B4A27F88', '555-5555', 1),
('E2750F9F-CA0A-48C6-B1DF-5A3F8EB0E874', '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', '666-6666', 1);

-- Inserções para ENDERECOS_EMPRESAS
INSERT INTO ENDERECOS_EMPRESAS (ID_ENDERECO, CEP, ESTADO, CIDADE, BAIRRO, NOME_RUA, NUMERO, COMPLEMENTO, STATUS, EMPRESA_ID) VALUES
('5E2859B8-0E46-4C70-B6F7-51089938D00E', '01234-567', 'SÃO PAULO','SÃO PAULO', 'Centro', 'Rua A', '123', NULL, 1, '84A92D79-4BB2-4CA0-BC29-63D63F28D291'),
('7BDAE5F8-80F8-4424-94F4-2FA916EAA28E', '56789-012','RIO DE JANEIRO','RIO DE JANEIRO', 'Centro', 'Rua B', '456', NULL, 1, '41B5A87E-64C5-4297-B5F9-8D27B4A27F88'),
('0A4F9AF9-02E4-4E6C-8A00-52F94ECAEA1C', '89012-345','MATO GROSSO', 'CUIABÁ', 'Centro', 'Rua C', '789', NULL, 1, '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E');

-- Inserções para USUARIOS
INSERT INTO USUARIOS (PESSOA_ID, NOME_USUARIO, SENHA, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'joaosilva', 'senha123', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'mariasouza', 'senha456', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'pedrosantos', 'senha789', 1);

-- Inserções para ALUNOS
INSERT INTO ALUNOS (PESSOA_ID, CPF, RG, ASSINATURA, STATUS, USUARIO_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '123.456.789-01', '123456789', 'assinatura1', 1, 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '987.654.321-09', '987654321', 'assinatura2', 1, 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '555.444.333-02', '555444333', 'assinatura3', 1, 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');

-- Inserções para PROVAS
INSERT INTO PROVAS (ID_PROVA, DATA_PROVA, STATUS, PESSOA_ID) VALUES
('7A1B5364-F827-453D-A8CF-E0A5D82F588A', '2024-04-25', 1, 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('CD8A30BD-5C54-4934-95C7-8BEBB250A303', '2024-04-25', 1, 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('ACB2D31E-108B-45E7-8547-3D5A92293F3D', '2024-04-25', 1, 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');

-- Inserções para QUESTOES
INSERT INTO QUESTOES (ID_QUESTAO, PERGUNTA, STATUS) VALUES
('B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC', 'Qual é a capital do Brasil?', 1),
('19EF88F4-C208-439E-8622-8830AF0C9ABE', 'Quanto é 2 + 2?', 1),
('E6A02434-7E22-4C8E-A799-2A7C39679FAE', 'Quem escreveu Dom Quixote?', 1);

-- Inserções para ALTERNATIVAS
INSERT INTO ALTERNATIVAS (ID_ALTERNATIVA, CONTEUDO, RESPOSTA, STATUS, QUESTAO_ID) VALUES
('1ABF5E13-BA69-4A48-B16C-64A0583A0543', 'Brasília', 1, 1, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC'),
('4C1314B3-496B-48F2-9DE4-62E30A8A4B88', 'Rio de Janeiro', 0, 0, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC'),
('18A9F96C-6EF5-4A15-989E-C2C42FF0B63D', 'São Paulo', 0, 0, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC');

-- Inserções para CONTEUDOS_PROGRAMATICOS
INSERT INTO CONTEUDOS_PROGRAMATICOS (ID_CONTEUDO, ASSUNTO, CARGA_HORARIA, STATUS) VALUES
('98A55797-741F-4F60-BDB0-614D6506AA42', 'Matemática', 40, 1),
('1ACD4E2F-8D82-4AF7-883F-94F34F755BC7', 'Português', 30, 1),
('A3E1D4F8-31BB-4A02-89C0-254A343F0E6C', 'História', 20, 1);

-- Inserções para CURSOS
INSERT INTO CURSOS (ID_CURSO, NOME_CURSO, LOGO, CARGA_HORARARIA_PER, CARGA_HORARIA_INI, VALIDADE, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', 'Curso de Matemática', 'logo_matematica.jpg', 80, 40, 12, 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', 'Curso de Português', 'logo_portugues.jpg', 60, 30, 12, 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'Curso de História', 'logo_historia.jpg', 40, 20, 12, 1);

-- Inserções para CURSOS_CONTEUDOS
INSERT INTO CURSOS_CONTEUDOS (CURSO_ID, CONTEUDO_ID, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', '98A55797-741F-4F60-BDB0-614D6506AA42', 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', '1ACD4E2F-8D82-4AF7-883F-94F34F755BC7', 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'A3E1D4F8-31BB-4A02-89C0-254A343F0E6C', 1);

-- Inserções para CURSOS_QUESTOES
INSERT INTO CURSOS_QUESTOES (CURSO_ID, QUESTAO_ID, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', '19EF88F4-C208-439E-8622-8830AF0C9ABE', 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', 'E6A02434-7E22-4C8E-A799-2A7C39679FAE', 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC', 1);

-- Inserções para TREINAMENTOS
INSERT INTO TREINAMENTOS (ID_TREINAMENTO, TIPO, CURSO_ID, PROVA_ID, STATUS) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 1, 'A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', '7A1B5364-F827-453D-A8CF-E0A5D82F588A', 1),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 2, 'D9F189E1-224C-4B0F-90B1-C4B8A38CC155', '7A1B5364-F827-453D-A8CF-E0A5D82F588A', 1),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 1, 'A246823D-9FE4-44E8-982D-C71ACAF014A8', '7A1B5364-F827-453D-A8CF-E0A5D82F588A', 1);

-- Inserções para LISTAS_PRESENCAS
INSERT INTO LISTAS_PRESENCAS (ID_TREINAMENTO, CODIGO, DATA) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 'ABCD1234', '2024-04-25'),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 'EFGH5678', '2024-04-25'),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 'IJKL9101', '2024-04-25');

-- Inserções para INSTRUTORES
INSERT INTO INSTRUTORES (PESSOA_ID, ESPECIALIZACAO, ASSINATURA, REGISTRO, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'Matemática', 'assinatura1', '12345', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'Português', 'assinatura2', '67890', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'História', 'assinatura3', '54321', 1);

-- Inserções para INSTRUTORES_TREINAMENTOS
INSERT INTO INSTRUTORES_TREINAMENTOS (PESSOA_ID, TREINAMENTO_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '1D64A57A-0D79-42A5-99C1-79F0C5C3A80E'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '0A11E2F2-09B0-46B4-B727-77D105DCC4A1');

-- Inserções para CERTIFICADOS
INSERT INTO CERTIFICADOS (TREINAMENTO_ID, CODIGO, DATA_EMISSAO, SITUACAO) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 'ABCD1234', '2024-04-26', 1),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 'EFGH5678', '2024-04-26', 1),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 'IJKL9101', '2024-04-26', 1);

-- Inserções para ALUNOS_TREINAMENTOS
INSERT INTO ALUNOS_TREINAMENTOS (PESSOA_ID, TREINAMENTO_ID, DATA_TREINAMENTO, DATA_INICIO_CERTIFICADO, RESULTADO) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', '2024-04-25', '2024-04-26', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', '2024-04-25', '2024-04-26', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '0A11E2F2-09B0-46B4-B727-77D105DCC4A1', '2024-04-25', '2024-04-26', 1);

-- Inserções para ALUNOS_EMPRESAS
INSERT INTO ALUNOS_EMPRESAS (ALUNO_ID, EMPRESA_ID, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '84A92D79-4BB2-4CA0-BC29-63D63F28D291', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '41B5A87E-64C5-4297-B5F9-8D27B4A27F88', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', 1);

-- Inserções para CADERNOS_RESPOSTAS
INSERT INTO CADERNOS_RESPOSTAS (CADERNO_ID, NRO_PERGUNTA, ALT_SELECIONADA, PESSOA_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 1, 'A', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 1, 'B', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 1, 'C', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');

WAITFOR DELAY '00:00:10';

SELECT * FROM EMPRESAS