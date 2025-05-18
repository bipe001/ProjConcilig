# ProjConcilig

Criação de tabela Clientes

CREATE TABLE Clientes(
	id int IDENTITY(1,1) NOT NULL,
	Nome nvarchar(255) NULL,
	CPF varchar(255) NULL,
	Contrato varchar(255) NULL,
	Produto varchar(255) NULL,
	Vencimento varchar(255) NULL,
	Valor money NULL,
	[Nome Arquivo] varchar(255) NULL,
	[Usuario Importacao] varchar(255) NULL
)

Criação da tabela Usuários

CREATE TABLE Usuarios(
	Id int IDENTITY(1,1) NOT NULL,
	Nome varchar(255) NULL,
	Username varchar(255) NULL,
	Password varchar(255) NULL
)

