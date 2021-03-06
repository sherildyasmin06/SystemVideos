
create database SISTEMAVIDEOS
GO
USE SISTEMAVIDEOS
GO

-- TABLA FORMATO
CREATE TABLE FORMATO (COD_FORMATO CHAR(7) NOT NULL PRIMARY KEY , NOM_FORMATO VARCHAR(40))
GO

--- TABLA GENERO
CREATE TABLE GENERO (COD_GENERO CHAR(7) NOT NULL PRIMARY KEY , NOM_GENERO VARCHAR(30))
GO

--- TABLA IDIOMA
CREATE TABLE IDIOMA (COD_IDIOMA CHAR(7) NOT NULL PRIMARY KEY , NOM_IDIOMA VARCHAR(40))
GO

--- TABLA PAIS
CREATE TABLE  PAIS (COD_PAIS CHAR (7) NOT NULL PRIMARY KEY , NOM_PAIS VARCHAR(40))
GO

--- TABLA VIDEOS
CREATE TABLE  VIDEOS (COD_VIDEO CHAR(7) NOT NULL, 
NOM_VIDEO VARCHAR(40), PREC_VIDEO DECIMAL(8,2),
HORASVIDEOS VARCHAR(20),STOCK_VIDEO INT, 
COD_FORMATO CHAR (7) CONSTRAINT
FORMATOVIDEO_FK FOREIGN KEY
REFERENCES FORMATO(COD_FORMATO),
COD_GENERO CHAR(7) CONSTRAINT GENEROVIDEO_FK FOREIGN KEY
REFERENCES GENERO(COD_GENERO),
COD_IDIOMA CHAR(7) CONSTRAINT IDIOMAVIDEO_FK FOREIGN KEY
REFERENCES IDIOMA(COD_IDIOMA),
COD_PAIS CHAR(7) CONSTRAINT PAISVIDEO_FK FOREIGN KEY
REFERENCES PAIS(COD_PAIS))
GO

--REGISTROS DE LA TABLA FORMATO

INSERT INTO FORMATO VALUES ('FOR-001','MP4 HD')
GO
INSERT INTO FORMATO VALUES ('FOR-002','DVD')
GO
INSERT INTO FORMATO VALUES ('FOR-003','VCD')
GO
INSERT INTO FORMATO VALUES ('FOR-004','MKV HD')
GO
INSERT INTO FORMATO VALUES ('FOR-005','MKV 4K')
GO
INSERT INTO FORMATO VALUES ('FOR-006','HD 1080')
GO
INSERT INTO FORMATO VALUES ('FOR-007','BLU RAY')
GO
INSERT INTO FORMATO VALUES ('FOR-008','4K')
GO
INSERT INTO FORMATO VALUES ('FOR-009','8K')
GO
INSERT INTO FORMATO VALUES ('FOR-010','3D')
GO

--REGISTROS DE LA TABLA GENERO

INSERT INTO GENERO VALUES ('GEN-001','ACCION')
GO
INSERT INTO GENERO VALUES ('GEN-002','TERROR')
GO
INSERT INTO GENERO VALUES ('GEN-003','DRAMA')
GO
INSERT INTO GENERO VALUES ('GEN-004','COMEDIA')
GO
INSERT INTO GENERO VALUES ('GEN-005','HINDU')
GO
INSERT INTO GENERO VALUES ('GEN-006','SUSPENSO')
GO
INSERT INTO GENERO VALUES ('GEN-007','XXX')
GO
INSERT INTO GENERO VALUES ('GEN-008','DIBUJOS')
GO
INSERT INTO GENERO VALUES ('GEN-009','ANIME')
GO
INSERT INTO GENERO VALUES ('GEN-010','DOCUMENTALES')
GO

--REGISTRO DE LA TABLA IDIOMA
INSERT INTO IDIOMA VALUES ('IDI-001','ESPA�OL CATALAN')
GO
INSERT INTO IDIOMA VALUES ('IDI-002','ESPA�OL LATINO')
GO
INSERT INTO IDIOMA VALUES ('IDI-003','PORTUGUES ')
GO
INSERT INTO IDIOMA VALUES ('IDI-004','INGLES')
GO
INSERT INTO IDIOMA VALUES ('IDI-005','JAPONES')
GO
INSERT INTO IDIOMA VALUES ('IDI-006',' CHINO MANDARIN')
GO
INSERT INTO IDIOMA VALUES ('IDI-007','ITALIANO')
GO
INSERT INTO IDIOMA VALUES ('IDI-008','ALEMAN')
GO
INSERT INTO IDIOMA VALUES ('IDI-009','FRANCES')
GO
INSERT INTO IDIOMA VALUES ('IDI-010','RUSO')
GO

--REGISTRO DE LA TABLA PAIS
INSERT INTO PAIS VALUES ('PAI-001','ESPA�A')
GO
INSERT INTO PAIS VALUES ('PAI-002','EEUU')
GO
INSERT INTO PAIS VALUES ('PAI-003','PERU')
GO
INSERT INTO PAIS VALUES ('PAI-004','JAPON')
GO
INSERT INTO PAIS VALUES ('PAI-005','CHINO')
GO
INSERT INTO PAIS VALUES ('PAI-006','RUSIA')
GO
INSERT INTO PAIS VALUES ('PAI-007','ITALIA')
GO
INSERT INTO PAIS VALUES ('PAI-008','ALEMANIA')
GO
INSERT INTO PAIS VALUES ('PAI-009','FRANCIA')
GO
INSERT INTO PAIS VALUES ('PAI-010','COLOMBIANA')
GO

--PROC ALMANCENADO DE LA TABALA FORMATO
CREATE PROCEDURE SP_LISTA_FORMATO
AS
SELECT * FROM FORMATO
GO
EXEC SP_LISTA_FORMATO

--PROC ALMANCENADO DE LA TABALA GENERO
CREATE PROCEDURE SP_LISTA_GENERO
AS
SELECT * FROM GENERO
GO
EXEC SP_LISTA_GENERO

--PROC ALMANCENADO DE LA TABALA IDIOMA
CREATE PROCEDURE SP_LISTA_IDIOMA
AS
SELECT * FROM IDIOMA
GO
EXEC SP_LISTA_IDIOMA

--PROC ALMANCENADO DE LA TABALA PAIS
CREATE PROCEDURE SP_LISTA_PAIS
AS
SELECT * FROM  PAIS
GO
EXEC SP_LISTA_PAIS

--PROC ALMANCENADO DE INGRESO DE LA TABLA VIDEOS

CREATE PROCEDURE SP_INGRESO_VIDEOS
@XCODVIDEO CHAR(7),
@XNOMVIDEO VARCHAR(40),
@XPRECVIDEO DECIMAL(8,2),
@XHORASVIDEO VARCHAR(20),
@XSTOCKVIDEO INT,
@XCODFORMATO CHAR(7),
@XCODGENERO CHAR(7),
@XCODIDIOMA CHAR(7),
@XCODPAIS CHAR(7)
AS
 INSERT INTO VIDEOS VALUES ( @XCODVIDEO,@XNOMVIDEO,
@XPRECVIDEO,@XHORASVIDEO,@XSTOCKVIDEO,
@XCODFORMATO,@XCODGENERO,@XCODIDIOMA,
@XCODPAIS)
GO

--PROC ALMANCENADO DE ACTUALIZAR DE LA TABLA VIDEOS
CREATE PROCEDURE SP_ACTUALIZAR_VIDEOS
@XCODVIDEO CHAR(7),
@XNOMVIDEO VARCHAR(40),
@XPRECVIDEO DECIMAL(8,2),
@XHORASVIDEO VARCHAR(20),
@XSTOCKVIDEO INT,
@XCODFORMATO CHAR(7),
@XCODGENERO CHAR(7),
@XCODIDIOMA CHAR(7),
@XCODPAIS CHAR(7)
AS
UPDATE VIDEOS SET NOM_VIDEO=@XNOMVIDEO,
                                  PREC_VIDEO=@XPRECVIDEO,
								  HORASVIDEOS=@XHORASVIDEO,
								  STOCK_VIDEO=@XSTOCKVIDEO,
								  COD_FORMATO=@XCODFORMATO,
								  COD_GENERO=@XCODGENERO,
								  COD_IDIOMA=@XCODIDIOMA,
								  COD_PAIS=@XCODPAIS WHERE COD_VIDEO=@XCODVIDEO 
GO

--PROC ALMACENADO DE LISTADO DE VIDEOS
CREATE PROCEDURE SP_LISTA_VIDEOS
AS
     SELECT A.COD_VIDEO AS CODIGO,A.NOM_VIDEO AS VIDEO,
	 A.PREC_VIDEO AS PRECIO,A.HORASVIDEOS AS DURACION,
	 A.STOCK_VIDEO AS STOCK,B.NOM_FORMATO AS FORMATO,
	 C.NOM_GENERO AS GENERO,D.NOM_IDIOMA AS IDIOMA,
	 E.NOM_PAIS AS PAIS FROM VIDEOS A INNER JOIN
	 FORMATO B ON (B.COD_FORMATO=A.COD_FORMATO)
	 INNER JOIN GENERO C ON (C.COD_GENERO=A.COD_GENERO)
	 INNER JOIN IDIOMA D ON (D.COD_IDIOMA=A.COD_IDIOMA)
	 INNER JOIN PAIS E ON (E.COD_PAIS=A.COD_PAIS)
	 GO

EXEC SP_LISTA_VIDEOS

--PROC ALMACENADO DE BUSQUEDA DE VIDEOS
CREATE PROCEDURE SP_BUSQUEDA_VIDEOS
@XCODVIDEO CHAR(7)
AS
     SELECT A.COD_VIDEO AS CODIGO,A.NOM_VIDEO AS VIDEO,
	 A.PREC_VIDEO AS PRECIO,A.HORASVIDEOS AS DURACION,
	 A.STOCK_VIDEO AS STOCK,B.NOM_FORMATO AS FORMATO,
	 C.NOM_GENERO AS GENERO,D.NOM_IDIOMA AS IDIOMA,
	 E.NOM_PAIS AS PAIS FROM VIDEOS A INNER JOIN
	 FORMATO B ON (B.COD_FORMATO=A.COD_FORMATO)
	 INNER JOIN GENERO C ON (C.COD_GENERO=A.COD_GENERO)
	 INNER JOIN IDIOMA D ON (D.COD_IDIOMA=A.COD_IDIOMA)
	 INNER JOIN PAIS E ON (E.COD_PAIS=A.COD_PAIS)
	 WHERE A.COD_VIDEO=@XCODVIDEO 
GO

EXEC SP_BUSQUEDA_VIDEOS 'VID-001'

--PROC ALMACENADO DE MOSTAR CODIGO DEL VIDEOS
CREATE PROCEDURE SP_MOSTRARCODIGOVIDEO
@XCODVIDEO CHAR(7)
AS
     SELECT COD_VIDEO FROM VIDEOS 
	 WHERE COD_VIDEO=@XCODVIDEO 
GO
SELECT * FROM VIDEOS

EXEC SP_MOSTRARCODIGOVIDEO 'VID-002'
select * from videos
