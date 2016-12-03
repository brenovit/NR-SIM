/* Disable foreign keys */
PRAGMA foreign_keys = 'off';

/* Begin transaction */
BEGIN;

/* Database properties */
PRAGMA auto_vacuum = 0;
PRAGMA encoding = 'UTF-8';
PRAGMA page_size = 4096;

/* Drop table [item] */
DROP TABLE IF EXISTS [main].[item];

/* Table structure [item] */
CREATE TABLE [main].[item](
    [id] INTEGER PRIMARY KEY AUTOINCREMENT, 
    [nome] VARCHAR(30) UNIQUE);

/* Drop table [pergunta] */
DROP TABLE IF EXISTS [main].[pergunta];

/* Table structure [pergunta] */
CREATE TABLE [main].[pergunta](
    [id] INTEGER PRIMARY KEY AUTOINCREMENT, 
    [descricao] VARCHAR(100), 
    [explicacao] VARCHAR(150), 
    [nbr] VARCHAR(15), 
    [titulo] VARCHAR(100));

/* Drop table [quiz] */
DROP TABLE IF EXISTS [main].[quiz];

/* Table structure [quiz] */
CREATE TABLE [main].[quiz](
    [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    [id_pergunta] INTEGER REFERENCES pergunta([id]) ON DELETE RESTRICT ON UPDATE NO ACTION, 
    [id_item] INTEGER REFERENCES item([id]) ON DELETE CASCADE ON UPDATE CASCADE, 
    [imagem] VARCHAR(30), 
    [resposta] BOOL);

/* Table data [item] Record count: 17 */
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
INSERT INTO [item]([rowid], [id], [nome]) VALUES(13, 13, 'porta-sin-cor-err');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(14, 14, 'extintor-ok');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(15, 15, 'porta-sin-cor-ok');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(16, 16, 'porta-sin-ok');
INSERT INTO [item]([rowid], [id], [nome]) VALUES(17, 17, 'vazio');

/* Table data [pergunta] Record count: 8 */
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(1, 1, 'Esta sinalização de piso está correta?', 'A sinalização de piso correta é vermelha com bordas amarelas.', '12693', 'Sistemas de proteção por extintores de incêndio');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(2, 2, 'A cor desta sinalização de parede está correta?', 'A cor correta da sinalização de parede (placa) é vermelha.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(3, 3, 'A altura desta sinalização de parede está correta?', 'A altura correta da sinalização de parede do extintor é de 1,80m.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(4, 4, 'A altura do extintor está correta?', 'A altura do extintor não deve exceder 1,60m. A parte inferior deve ter no mínimo, 0,20m de distância do piso.', '12693 ', 'Sistemas de proteção por extintores de incêndio');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(5, 5, 'Esta sinalização está correta?', 'A sinalização correta para porta com barras antipânico é verde, escrito “Aperte e empurre”, anexada na própria porta com altura de 1,20m.', '13434-1 ', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(6, 6, 'A sinalização acima dela está correta?', 'A sinalização correta, a seta aponta para cima(frente), acima da porta com barras antipânico.', '13434-1 ', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(7, 7, 'No céario atual, a luminária de emergência está correta?', 'A luminária de emergência tem de estar conectada na tomada e apagada.', '10898 ', 'Sistema de iluminação de emergência');
INSERT INTO [pergunta]([rowid], [id], [descricao], [explicacao], [nbr], [titulo]) VALUES(8, 8, 'Está sinalização está correta?', 'A placa correta deve estar anexada ao lado do elevador a 1,80m do piso, escrito “Em caso de incêndio', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');

/* Table data [quiz] Record count: 18 */
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(1, 1, 1, 14, 'extintor_sin_chao_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(2, 2, 1, 1, 'extintor_sin_chao_2', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(3, 3, 2, 2, 'extintor_sin_cor_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(4, 4, 2, 2, 'extintor_sin_cor_2', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(5, 5, 5, 13, 'porta_sin_cor_2', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(6, 6, 5, 12, 'porta_sin_cor_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(7, 7, 4, 5, 'extintor_alt_4', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(8, 8, 4, 3, 'extintor_alt_1', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(9, 9, 4, 14, 'extintor_alt_2', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(10, 10, 4, 6, 'extintor_alt_3', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(11, 11, 3, 14, 'extintor_sin_alt_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(12, 12, 3, 7, 'extintor_sin_alt_2', 0);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(13, 13, 3, 8, 'extintor_sin_alt_3', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(14, 14, 7, 17, 'lumn_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(15, 15, 7, 17, 'lumn_2', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(16, 16, 7, 17, 'lumn_3', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(17, 17, 6, 16, 'porta_sin_top_1', 1);
INSERT INTO [quiz]([rowid], [id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(18, 18, 6, 12, 'porta_sin_top_2', 0);

/* Commit transaction */
COMMIT;

/* Enable foreign keys */
PRAGMA foreign_keys = 'on';
