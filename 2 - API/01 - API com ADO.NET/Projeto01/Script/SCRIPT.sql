CREATE DATABASE Projeto01;

GO

USE Projeto01;

GO

CREATE TABLE dbo.Usuarios(
	ID_Usuario            Int Identity(1,1)    Primary key
   ,NM_Usuario            NVarchar(100)        NOT NULL
   ,Email_Usuario         NVarchar(100)        NOT NULL   
   ,CD_Inscricao_Nacional NVarchar(14)         NOT NULL
);

GO

INSERT INTO dbo.Usuarios (NM_Usuario, Email_Usuario, CD_Inscricao_Nacional)
VALUES 
    ('Lucas Casarotti', 'lucas.casarotti@email.com', '123.456.789-01')
   ,('Maria Silva', 'maria.silva@email.com', '987.654.321-00')
   ,('João Pereira', 'joao.pereira@email.com', '321.654.987-00')
   ,('Ana Souza', 'ana.souza@email.com', '456.123.789-00')