CREATE DATABASE INFO_104_PARCIAL3
GO

/* INFO-104 WILTON BENEDICT UH PARCIAL 3 12/15/23*/
USE INFO_104_PARCIAL3


CREATE TABLE partido
(
	partidoId int identity (5,5) PRIMARY KEY,
	nombre nvarchar(100) NOT NULL
)
GO

CREATE TABLE encuesta
(
	encuestaId int identity (1,1) PRIMARY KEY,
	nombre nvarchar(100) NOT NULL,
	correo nvarchar(100) NOT NULL,
	edad int NOT NULL,
	partidoId int,
	CONSTRAINT fk_partidoId FOREIGN KEY (partidoId) REFERENCES partido(partidoId)
)
GO

CREATE PROCEDURE agregarPartido
@nombre nvarchar(100)
	AS
		BEGIN
			INSERT INTO partido (nombre) VALUES (@nombre)
		END
GO

CREATE PROCEDURE agregarEncuesta
@nombre nvarchar(100),
@correo nvarchar(100),
@edad int,
@partidoId int
	AS
		BEGIN 
			INSERT INTO encuesta (nombre,correo,edad,partidoId) VALUES (@nombre,@correo,@edad,@partidoId)
		END
GO

CREATE PROCEDURE confirmarPartido
@nombre nvarchar(100)
	AS
		BEGIN
			select partidoId FROM partido WHERE nombre = @nombre
		END
GO

CREATE PROCEDURE reporteGeneral
	AS
		BEGIN 
			SELECT *  FROM encuesta
		END
GO