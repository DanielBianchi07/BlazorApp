-- Inser��es para PESSOAS
INSERT INTO PESSOAS (ID_PESSOA, NOME, EMAIL) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'Jo�o Silva', 'joao@example.com'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'Maria Souza', 'maria@example.com'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'Pedro Santos', 'pedro@example.com');

-- Inser��es para EMPRESAS
INSERT INTO EMPRESAS (ID_EMPRESA, CNPJ, RAZAO_SOCIAL, EMAIL, STATUS) VALUES
('84A92D79-4BB2-4CA0-BC29-63D63F28D291', '12345678901234', 'Empresa A', 'empresaA@example.com', 1),
('41B5A87E-64C5-4297-B5F9-8D27B4A27F88', '98765432109876', 'Empresa B', 'empresaB@example.com', 1),
('2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', '56789012345678', 'Empresa C', 'empresaC@example.com', 1);

-- Inser��es para TELEFONES_PESSOAS
INSERT INTO TELEFONES_PESSOAS (ID_TELEFONE_PES, PESSOA_ID, NRO_TELEFONE) VALUES
('5D8A7C32-1535-41F4-A0D7-0ECACBCD92A9', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '111-1111'),
('872CD3B1-3D3E-458E-9B8F-786D738DA9C0', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '222-2222'),
('D5F0A905-7317-4B12-991A-E10E2178718F', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '333-3333');

-- Inser��es para TELEFONES_EMPRESAS
INSERT INTO TELEFONES_EMPRESAS (ID_TELEFONE_EMP, EMPRESA_ID, NRO_TELEFONE) VALUES
('69C5870B-9DC4-4CF3-8C86-665D9C0EF7A8', '84A92D79-4BB2-4CA0-BC29-63D63F28D291', '444-4444'),
('1B348A0E-66E1-4412-BE5D-FFAD54D7F0F5', '41B5A87E-64C5-4297-B5F9-8D27B4A27F88', '555-5555'),
('E2750F9F-CA0A-48C6-B1DF-5A3F8EB0E874', '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', '666-6666');

-- Inser��es para ESTADOS
INSERT INTO ESTADOS (ID_ESTADO, NOME_ESTADO, UF) VALUES
('09D7D4FE-377E-4D8B-BFD7-6E60EEEDFA17', 'S�o Paulo', 'SP'),
('A9C5B36E-9DB4-4C83-9B4F-5260D87FBA11', 'Rio de Janeiro', 'RJ'),
('D86FFD1C-16A3-4F8E-8E1A-B27FAAE69F67', 'Minas Gerais', 'MG');

-- Inser��es para CIDADES
INSERT INTO CIDADES (ID_CIDADE, NOME_CIDADE, ESTADO_ID) VALUES
('DC5C63AB-4D5E-44A0-A5C9-75F689C62E76', 'S�o Paulo', '09D7D4FE-377E-4D8B-BFD7-6E60EEEDFA17'),
('C677F650-67E5-462A-836C-3A50FF7AB25A', 'Rio de Janeiro', 'A9C5B36E-9DB4-4C83-9B4F-5260D87FBA11'),
('7A3836A2-57A5-4E77-8CF7-07E0767A35CD', 'Belo Horizonte', 'D86FFD1C-16A3-4F8E-8E1A-B27FAAE69F67');

-- Inser��es para ENDERECOS_EMPRESAS
INSERT INTO ENDERECOS_EMPRESAS (ID_ENDERECO, CEP, NOME_RUA, NUMERO, BAIRRO, CIDADE_ID, EMPRESA_ID) VALUES
('5E2859B8-0E46-4C70-B6F7-51089938D00E', '01234-567', 'Rua A', 123, 'Centro', 'DC5C63AB-4D5E-44A0-A5C9-75F689C62E76', '84A92D79-4BB2-4CA0-BC29-63D63F28D291'),
('7BDAE5F8-80F8-4424-94F4-2FA916EAA28E', '56789-012', 'Rua B', 456, 'Centro', 'C677F650-67E5-462A-836C-3A50FF7AB25A', '41B5A87E-64C5-4297-B5F9-8D27B4A27F88'),
('0A4F9AF9-02E4-4E6C-8A00-52F94ECAEA1C', '89012-345', 'Rua C', 789, 'Centro', '7A3836A2-57A5-4E77-8CF7-07E0767A35CD', '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E');

-- Inser��es para USUARIOS
INSERT INTO USUARIOS (PESSOA_ID, NOME_USUARIO, SENHA, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'joaosilva', 'senha123', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'mariasouza', 'senha456', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'pedrosantos', 'senha789', 1);

-- Inser��es para ALUNOS
INSERT INTO ALUNOS (PESSOA_ID, CPF, RG, ASSINATURA, USUARIO_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '123.456.789-01', '123456789', 'assinatura1', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '987.654.321-09', '987654321', 'assinatura2', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '555.444.333-02', '555444333', 'assinatura3', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');

-- Inser��es para PROVAS
INSERT INTO PROVAS (ID_PROVA, DATA_PROVA, PESSOA_ID) VALUES
('7A1B5364-F827-453D-A8CF-E0A5D82F588A', '2024-04-25', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('CD8A30BD-5C54-4934-95C7-8BEBB250A303', '2024-04-25', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('ACB2D31E-108B-45E7-8547-3D5A92293F3D', '2024-04-25', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');

-- Inser��es para QUESTOES
INSERT INTO QUESTOES (ID_QUESTAO, PERGUNTA) VALUES
('B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC', 'Qual � a capital do Brasil?'),
('19EF88F4-C208-439E-8622-8830AF0C9ABE', 'Quanto � 2 + 2?'),
('E6A02434-7E22-4C8E-A799-2A7C39679FAE', 'Quem escreveu Dom Quixote?');

-- Inser��es para ALTERNATIVAS
INSERT INTO ALTERNATIVAS (ID_ALTERNATIVA, CONTEUDO, STATUS, QUESTAO_ID) VALUES
('1ABF5E13-BA69-4A48-B16C-64A0583A0543', 'Bras�lia', 1, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC'),
('4C1314B3-496B-48F2-9DE4-62E30A8A4B88', 'Rio de Janeiro', 0, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC'),
('18A9F96C-6EF5-4A15-989E-C2C42FF0B63D', 'S�o Paulo', 0, 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC');

-- Inser��es para CONTEUDOS_PROGRAMATICOS
INSERT INTO CONTEUDOS_PROGRAMATICOS (ID_CONTEUDO, ASSUNTO, CARGA_HORARIA) VALUES
('98A55797-741F-4F60-BDB0-614D6506AA42', 'Matem�tica', 40),
('1ACD4E2F-8D82-4AF7-883F-94F34F755BC7', 'Portugu�s', 30),
('A3E1D4F8-31BB-4A02-89C0-254A343F0E6C', 'Hist�ria', 20);

-- Inser��es para CURSOS
INSERT INTO CURSOS (ID_CURSO, NOME_CURSO, LOGO, CARGA_HORARARIA_PER, CARGA_HORARIA_INI, VALIDADE, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', 'Curso de Matem�tica', 'logo_matematica.jpg', 80, 40, 12, 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', 'Curso de Portugu�s', 'logo_portugues.jpg', 60, 30, 12, 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'Curso de Hist�ria', 'logo_historia.jpg', 40, 20, 12, 1);

-- Inser��es para CURSOS_CONTEUDOS
INSERT INTO CURSOS_CONTEUDOS (CURSO_ID, CONTEUDO_ID, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', '98A55797-741F-4F60-BDB0-614D6506AA42', 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', '1ACD4E2F-8D82-4AF7-883F-94F34F755BC7', 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'A3E1D4F8-31BB-4A02-89C0-254A343F0E6C', 1);

-- Inser��es para CURSOS_QUESTOES
INSERT INTO CURSOS_QUESTOES (CURSO_ID, QUESTAO_ID, STATUS) VALUES
('A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', '19EF88F4-C208-439E-8622-8830AF0C9ABE', 1),
('D9F189E1-224C-4B0F-90B1-C4B8A38CC155', 'E6A02434-7E22-4C8E-A799-2A7C39679FAE', 1),
('A246823D-9FE4-44E8-982D-C71ACAF014A8', 'B98E5245-0DBA-4B92-A7D2-4E2546F1A1AC', 1);

-- Inser��es para TREINAMENTOS
INSERT INTO TREINAMENTOS (ID_TREINAMENTO, TIPO, CURSO_ID, STATUS) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 1, 'A58224B8-BA19-4BB5-9B45-18C7BEC9CA2C', 1),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 2, 'D9F189E1-224C-4B0F-90B1-C4B8A38CC155', 1),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 1, 'A246823D-9FE4-44E8-982D-C71ACAF014A8', 1);

-- Inser��es para LISTAS_PRESENCAS
INSERT INTO LISTAS_PRESENCAS (ID_TREINAMENTO, CODIGO, DATA) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 'ABCD1234', '2024-04-25'),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 'EFGH5678', '2024-04-25'),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 'IJKL9101', '2024-04-25');

-- Inser��es para INSTRUTORES
INSERT INTO INSTRUTORES (PESSOA_ID, ESPECIALIZACAO, ASSINATURA, REGISTRO, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 'Matem�tica', 'assinatura1', '12345', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 'Portugu�s', 'assinatura2', '67890', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 'Hist�ria', 'assinatura3', '54321', 1);

-- Inser��es para INSTRUTORES_TREINAMENTOS
INSERT INTO INSTRUTORES_TREINAMENTOS (PESSOA_ID, TREINAMENTO_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '1D64A57A-0D79-42A5-99C1-79F0C5C3A80E'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '0A11E2F2-09B0-46B4-B727-77D105DCC4A1');

-- Inser��es para CERTIFICADOS
INSERT INTO CERTIFICADOS (TREINAMENTO_ID, CODIGO, DATA_EMISSAO, STATUS) VALUES
('3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', 'ABCD1234', '2024-04-26', 1),
('1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', 'EFGH5678', '2024-04-26', 1),
('0A11E2F2-09B0-46B4-B727-77D105DCC4A1', 'IJKL9101', '2024-04-26', 1);

-- Inser��es para ALUNOS_TREINAMENTOS
INSERT INTO ALUNOS_TREINAMENTOS (PESSOA_ID, TREINAMENTO_ID, DATA_TREINAMENTO, DATA_INICIO_CERTIFICADO, RESULTADO) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '3C6A2B38-F6C2-42EA-A9D1-EC9DFE2B3351', '2024-04-25', '2024-04-26', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '1D64A57A-0D79-42A5-99C1-79F0C5C3A80E', '2024-04-25', '2024-04-26', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '0A11E2F2-09B0-46B4-B727-77D105DCC4A1', '2024-04-25', '2024-04-26', 1);

-- Inser��es para ALUNOS_EMPRESAS
INSERT INTO ALUNOS_EMPRESAS (ALUNO_ID, EMPRESA_ID, STATUS) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', '84A92D79-4BB2-4CA0-BC29-63D63F28D291', 1),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', '41B5A87E-64C5-4297-B5F9-8D27B4A27F88', 1),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', '2F0D6986-3E6A-4B6A-8EEA-3C700C2BCB1E', 1);

-- Inser��es para CADERNOS_RESPOSTAS
INSERT INTO CADERNOS_RESPOSTAS (CADERNO_ID, NRO_PERGUNTA, ALT_SELECIONADA, PESSOA_ID) VALUES
('E655F9D4-3E86-46A2-98C3-4F84A3D53A27', 1, 'A', 'E655F9D4-3E86-46A2-98C3-4F84A3D53A27'),
('B9D82E45-4E19-4F5C-95C7-94DDB5A41D38', 1, 'B', 'B9D82E45-4E19-4F5C-95C7-94DDB5A41D38'),
('D2255F33-2EDC-4A15-BEC7-09182ED2A19F', 1, 'C', 'D2255F33-2EDC-4A15-BEC7-09182ED2A19F');
