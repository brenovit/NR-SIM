/* Disable foreign keys */
PRAGMA foreign_keys = 'off';

/* Begin transaction */
BEGIN;

/* Database properties */
PRAGMA auto_vacuum = 0;
PRAGMA encoding = 'UTF-8';
PRAGMA page_size = 1024;

/* Drop table [item] */
DROP TABLE IF EXISTS [main].[item];

/* Table structure [item] */
CREATE TABLE [main].[item](
    [id] INTEGER PRIMARY KEY, 
    [nome] VARCHAR(30) UNIQUE);

/* Drop table [pergunta] */
DROP TABLE IF EXISTS [main].[pergunta];

/* Table structure [pergunta] */
CREATE TABLE [main].[pergunta](
    [id] INTEGER PRIMARY KEY, 
    [descricao] VARCHAR(100), 
    [explicacao] VARCHAR(100), 
    [nbr] VARCHAR(15), 
    [titulo] VARCHAR(100));

/* Drop table [quiz] */
DROP TABLE IF EXISTS [main].[quiz];

/* Table structure [quiz] */
CREATE TABLE [main].[quiz](
    [id] INTEGER PRIMARY KEY NOT NULL, 
    [id_pergunta] INTEGER, 
    [id_item] INTEGER, 
    [imagem] VARCHAR(30), 
    [resposta] BIT);

/* Table data [item] Record count: 11 */
INSERT INTO [item]([rowid], [id], [nome]) VALUES(1, 1, 'extintor-sin-chao-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(2, 2, 'extintor-sin-cor-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(3, 3, 'extintor-alto-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(4, 4, 'extintor-baixo-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(5, 5, 'extintor-chao-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(6, 6, 'extintor-chao-ok');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(7, 7, 'extintor-sin-alto-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(8, 8, 'extintor-sin-baixo-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(9, 9, 'elevador-sin-alt-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(10, 10, 'elevador-sin-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(11, 11, 'elevador-sin-ok');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(12, 12, 'porta-sin-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(13, 13, 'porta-sin-ok');

/* Table data [pergunta] Record count: 4 */
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(1, 1, 'Esta sinalização de piso está correta?', 'A sinalização de piso correta é vermelha com bordas amarelas.', '12693', 'Sistemas de proteção por extintores de incêndio');

INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(2, 2, 'A cor desta sinalização de parede está correta?', 'A cor correta da sinalização de parede (placa) é vermelha.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(3, 3, 'A altura desta sinalização de parede está correta?', 'A altura correta da sinalização de parede do extintor é de 1,80m.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(4, 4, 'A altura do extintor está correta?', 'A altura do extintor não deve exceder 1,60m. A parte inferior deve ter no mínimo, 0,20m de distância do piso.', '12693 ', 'Sistemas de proteção por extintores de incêndio');

/* Table data [quiz] Record count: 4 */
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(1, 1, 1, 1, 'extintor_sin_chao_1', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(2, 2, 1, 1, 'extintor_sin_chao_2', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(3, 3, 2, 2, 'extintor_sin_cor_1', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(4, 4, 2, 2, 'extintor_sin_cor_2', 1);

/* Commit transaction */
COMMIT;

/* Enable foreign keys */
PRAGMA foreign_keys = 'on';
