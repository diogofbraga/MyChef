CREATE DATABASE FeelItaly;
GO

USE FeelItaly;
GO

CREATE TABLE Utilizador(
    IdUtilizador INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(32) NOT NULL,
    Passwd  NVARCHAR(16) NOT NULL,
    Email NVARCHAR(225) NOT NULL,
    Nome NVARCHAR(225) NOT NULL
);

GO


CREATE TABLE Categoria(
    IdCategoria INT NOT NULL PRIMARY KEY,
    Descricao NVARCHAR(32) NOT NULL
);

GO

CREATE TABLE Receita(
    IdReceita INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Nutricional FLOAT NOT NULL,
    TempoTotal INT NOT NULL,
    Avaliacao FLOAT NOT NULL,
    IdUtilizador INT NOT NULL
);

GO

CREATE TABLE CategoriaReceita(
    IdCategoria INT NOT NULL PRIMARY KEY,
    IdReceita INT NOT NULL
);

INSERT INTO Utilizador
VALUES(1,'diogofbraga','dfb','diogo@gmail.com','Diogo Braga')

INSERT INTO Utilizador
VALUES(2,'ricardomilhas','rm10','ricardinhomilas10@gmail.com','Ricardo Milhenzel')

INSERT INTO Utilizador
VALUES(3,'johnnyboy','jb10','johnnyboy@gmail.com','Johnny Boy')

INSERT INTO Utilizador
VALUES(4,'cacenzel','cac10','cacenzel@gmail.com','Caceeeeeenzel')

INSERT INTO Utilizador
VALUES(5,'denzel','d10','denzel@gmail.com','Denzel')

INSERT INTO Categoria
VALUES(1,'Massas')

INSERT INTO Categoria
VALUES(2,'Pizzas')

INSERT INTO Receita
VALUES(1,'Carbonara',400.0,45,4.3,1)

INSERT INTO Receita
VALUES(2,'Pizza Margarita',600.0,35,4.5,1)

INSERT INTO CategoriaReceita
VALUES(1,1)

INSERT INTO CategoriaReceita
VALUES(2,2)


SELECT * FROM Utilizador

SELECT * FROM Receita

SELECT * FROM Categoria

SELECT * FROM CategoriaReceita
