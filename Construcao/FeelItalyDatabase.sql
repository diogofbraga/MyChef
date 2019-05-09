CREATE DATABASE FeelItaly;
GO

USE FeelItaly;
GO

CREATE TABLE Utilizador(
    Username NVARCHAR(32) NOT NULL PRIMARY KEY,
    Passwd  NVARCHAR(16) NOT NULL,
    Email NVARCHAR(225) NOT NULL,
    Nome NVARCHAR(225) NOT NULL
);

CREATE TABLE Categoria(
    IdCategoria INT NOT NULL PRIMARY KEY,
    Descricao NVARCHAR(32) NOT NULL
);

CREATE TABLE Receita(
    IdReceita INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Nutricional FLOAT NOT NULL,
    TempoTotal INT NOT NULL,
    Avaliacao FLOAT NOT NULL
);

CREATE TABLE CategoriaReceita(
	Id INT NOT NULL PRIMARY KEY,
    IdCategoria INT NOT NULL,
    IdReceita INT NOT NULL
);

CREATE TABLE ConfiguracaoInicial(
	IdReceita INT NOT NULL PRIMARY KEY,
	Username NVARCHAR(32) NOT NULL
);

CREATE TABLE Passo(
	IdPasso INT NOT NULL PRIMARY KEY,
	TempoParcial FLOAT NOT NULL,
	Unidade NVARCHAR(32),
	Quantidade NVARCHAR(10) NOT NULL,
	Extra NVARCHAR(255),
	IdReceita INT,
	IdIngrediente INT NOT NULL,
	IdAcao INT NOT NULL
);

CREATE TABLE Historico(
	IdReceita INT NOT NULL PRIMARY KEY,
	Username NVARCHAR(32) NOT NULL,
	IdPasso INT NOT NULL,
	TempoPasso FLOAT NOT NULL,
	Dataa DATETIME NOT NULL,
	NrPasso INT NOT NULL
);

CREATE TABLE Ingrediente(
	IdIngrediente INT NOT NULL PRIMARY KEY,
	Nome NVARCHAR(100) NOT NULL
);

CREATE TABLE Acao(
	IdAcao INT NOT NULL PRIMARY KEY,
	Descricao NVARCHAR(32) NOT NULL
);

CREATE TABLE ReceitaPasso(
	Id INT NOT NULL PRIMARY KEY,
	IdReceita INT NOT NULL,
	IdPasso INT NOT NULL,
	Numero NVARCHAR(10) NOT NULL
);

CREATE TABLE Tutorial(
	IdPasso INT NOT NULL PRIMARY KEY,
	Link NVARCHAR(255) NOT NULL
);

CREATE TABLE Utensilio(
	IdUtensilio INT NOT NULL PRIMARY KEY,
	Descricao NVARCHAR(32) NOT NULL
);

CREATE TABLE UtensilioPasso(
	Id INT NOT NULL PRIMARY KEY,
	IdUtensilio INT NOT NULL,
	IdPasso INT NOT NULL
);

CREATE TABLE Comentario(
	IdComentario INT NOT NULL PRIMARY KEY,
	Descricao NVARCHAR(100) NOT NULL,
	Dataa DATETIME NOT NULL,
	IdReceita INT NOT NULL
);

-- Utilizadores
-- Username NVARCHAR(32), Passwd  NVARCHAR(16), Email NVARCHAR(225), Nome NVARCHAR(225)

INSERT INTO Utilizador
VALUES('diogofbraga','dfb','diogofiliperfbraga@gmail.com','Diogo Braga')

INSERT INTO Utilizador
VALUES('ricardomilhazes','rm10','rmilhazesveloso@gmail.com','Ricardo Milhazes')

INSERT INTO Utilizador
VALUES('joaopedro','joaop21','jpsilva9898@gmail.com','João Silva')

INSERT INTO Utilizador
VALUES('ricardofsc10','rc10','ricardofsc10@gmail.com','Ricardo Caçador')

INSERT INTO Utilizador
VALUES('rjsf','rj','rjsf@gmail.com','Ricardo Ferreira')


-- Categorias
-- IdCategoria INT, Descricao NVARCHAR(32)

INSERT INTO Categoria
VALUES(1,'Massas')

INSERT INTO Categoria
VALUES(2,'Pizzas')

INSERT INTO Categoria
VALUES(3,'Tartes')

INSERT INTO Categoria
VALUES(4,'Carne')

INSERT INTO Categoria
VALUES(5,'Peixe')

INSERT INTO Categoria
VALUES(6,'Entradas')

INSERT INTO Categoria
VALUES(7,'Sobremesa')


-- Receitas
-- IdReceita INT, Nome NVARCHAR(100), Nutricional FLOAT, TempoTotal INT, Avaliacao FLOAT

INSERT INTO Receita
VALUES(1,'Carbonara',655.0,20,4.3)

INSERT INTO Receita
VALUES(2,'Pizza Marguerita',204.0,60,4.7)

INSERT INTO Receita
VALUES(3,'Molho Tomate',80.0,5,4.0)

-- CategoriasReceitas
-- Id INT, IdCategoria INT, IdReceita INT

INSERT INTO CategoriaReceita
VALUES(1,1,1)

INSERT INTO CategoriaReceita
VALUES(2,2,2)

INSERT INTO CategoriaReceita
VALUES(3,2,3)

-- ConfiguraçõesIniciais
-- IdReceita INT, Username NVARCHAR(32)

INSERT INTO ConfiguracaoInicial
VALUES(1,'diogofbraga')

INSERT INTO ConfiguracaoInicial
VALUES(2,'ricardofsc10')


-- Passos
-- IdPasso INT, TempoParcial FLOAT, Unidade NVARCHAR(32), Quantidade INT,
-- Extra NVARCHAR(255), IdReceita INT, IdIngrediente INT, IdAcao INT

INSERT INTO Passo VALUES(14,4.0,'','','',3,'','')

INSERT INTO Passo VALUES(1,4.0,'c. sopa','2','numa frigideira',-1,1,1)

INSERT INTO Passo VALUES(2,4.0,'g','200','na frigideira',-1,2,2)

INSERT INTO Passo VALUES(3,4.0,'','2','',-1,3,3)

INSERT INTO Passo VALUES(4,4.0,'ml','80','',-1,4,4)

INSERT INTO Passo VALUES(5,4.0,'c. chá','1','',-1,5,5)

INSERT INTO Passo VALUES(6,4.0,'','','e as natas ao bacon', -1,3,6)

INSERT INTO Passo VALUES(7,4.0,'','','tudo durante 3 minutos em lume brando',-1,'',7)

INSERT INTO Passo VALUES(8,4.0,'g','300','num tacho',-1,6,1)

INSERT INTO Passo VALUES(9,4.0,'pitada','1','ao tacho',-1,5,4)

INSERT INTO Passo VALUES(10,4.0,'','','durante 8 minutos',-1,6,8)

INSERT INTO Passo VALUES(11,4.0,'','','para a frigideira',-1,6,9)

INSERT INTO Passo VALUES(12,4.0,'g','50','',-1,7,1)

INSERT INTO Passo VALUES(13,4.0,'','','a gosto',-1,8,1)

-- Ingredientes
-- IdIngrediente INT, Nome NVARCHAR(100)

INSERT INTO Ingrediente VALUES(1,'azeite')

INSERT INTO Ingrediente VALUES(2,'bacon')

INSERT INTO Ingrediente VALUES(3,'ovos')

INSERT INTO Ingrediente VALUES(4,'natas')

INSERT INTO Ingrediente VALUES(5,'sal')

INSERT INTO Ingrediente VALUES(6,'esparguete')

INSERT INTO Ingrediente VALUES(7,'queijo parmesão ralado')

INSERT INTO Ingrediente VALUES(8,'pimenta preta')

-- Ações
-- IdAcao INT, Descricao NVARCHAR(32)

INSERT INTO Acao VALUES(1,'Colocar')

INSERT INTO Acao VALUES(2,'Fritar')

INSERT INTO Acao VALUES(3,'Bater')

INSERT INTO Acao VALUES(4,'Acrescentar')

INSERT INTO Acao VALUES(5,'Temperar')

INSERT INTO Acao VALUES(6,'Juntar')

INSERT INTO Acao VALUES(7,'Cozinhar')

INSERT INTO Acao VALUES(8,'Cozer')

INSERT INTO Acao VALUES(9,'Escorrer')

-- ReceitasPassos
-- Id INT, IdReceita INT, IdPasso INT, Numero NVARCHAR(10)

INSERT INTO ReceitaPasso VALUES(1,1,1,'1')

INSERT INTO ReceitaPasso VALUES(2,1,2,'2')

INSERT INTO ReceitaPasso VALUES(3,1,3,'3')

INSERT INTO ReceitaPasso VALUES(4,1,4,'4')

INSERT INTO ReceitaPasso VALUES(5,1,5,'5')

INSERT INTO ReceitaPasso VALUES(6,1,6,'6')

INSERT INTO ReceitaPasso VALUES(7,1,7,'7')

INSERT INTO ReceitaPasso VALUES(8,1,8,'8')

INSERT INTO ReceitaPasso VALUES(9,1,9,'9')

INSERT INTO ReceitaPasso VALUES(10,1,10,'10')

INSERT INTO ReceitaPasso VALUES(11,1,11,'11')

INSERT INTO ReceitaPasso VALUES(12,1,12,'12')

INSERT INTO ReceitaPasso VALUES(13,1,13,'13')

INSERT INTO ReceitaPasso VALUES(14,2,14,'1')

-- Históricos

INSERT INTO Historico
VALUES(1,'diogofbraga',1,45.0,'2018-05-04 00:35:00',3)


-- Tutoriais
-- IdPasso INT, Link NVARCHAR(255)

INSERT INTO Tutorial
VALUES(1,'https://www.youtube.com/watch?v=i7AZjzVx7os')


-- Utensílios
-- IdUtensilio INT, Descricao NVARCHAR(32)

INSERT INTO Utensilio
VALUES(1,'Faca')

INSERT INTO Utensilio
VALUES(2,'Frigideira')

INSERT INTO Utensilio
VALUES(3,'Tacho')

INSERT INTO Utensilio
VALUES(4,'Colher')


-- UtensíliosPassos
-- IdUtensilio INT, IdPasso INT

INSERT INTO UtensilioPasso
VALUES(1,1,1)

INSERT INTO UtensilioPasso
VALUES(2,2,1)


-- Comentarios
-- IdComentario INT, Descricao NVARCHAR(100), Dataa DATETIME, IdReceita INT

INSERT INTO Comentario
VALUES(1,'Excelente massa! Aconselho vivamente!','2018-05-04 00:35:00',1)

SELECT * FROM Utilizador

SELECT * FROM Receita

SELECT * FROM Categoria

SELECT * FROM CategoriaReceita

SELECT * FROM ConfiguracaoInicial;

SELECT * FROM Passo;

SELECT * FROM Historico;

SELECT * FROM Ingrediente;

SELECT * FROM Acao;

SELECT * FROM ReceitaPasso;

SELECT * FROM Tutorial;

SELECT * FROM Utensilio;

SELECT * FROM UtensilioPasso;

SELECT * FROM Comentario;
