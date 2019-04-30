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

CREATE TABLE Receita(
    IdReceita INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Nutricional FLOAT NOT NULL,
    TempoTotal INT NOT NULL,
    Avaliacao FLOAT NOT NULL,
    IdUtilizador INT NOT NULL
);

GO

INSERT INTO Utilizador
VALUES(1,'diogofbraga','dfb','diogo@gmail.com','Diogo Braga')

INSERT INTO Receita
VALUES(1,'Carbonara',400.0,45,4.3,1)

SELECT * FROM Utilizador

SELECT * FROM Receita
