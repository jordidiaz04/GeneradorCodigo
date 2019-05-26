use CETPRO
go
create procedure sp_Matricula_Listar
as
select IdMatricula,
	IdBloque,
	IdAlumno,
	IdPersonal,
	Fecha
from Matricula
go
create procedure sp_Matricula_Obtener
@idmatricula int
as
select IdMatricula,
	IdBloque,
	IdAlumno,
	IdPersonal,
	Fecha
from Matricula
where IdMatricula = @idmatricula
go
create procedure sp_Matricula_Insertar
@idbloque int,
@idalumno int,
@idpersonal int,
@fecha date
as
insert into Matricula(IdBloque,IdAlumno,IdPersonal,Fecha)
values(@idbloque,@idalumno,@idpersonal,@fecha)
go
create procedure sp_Matricula_Actualizar
@idmatricula int,
@idbloque int,
@idalumno int,
@idpersonal int,
@fecha date
as
update Matricula
set IdBloque = @IdBloque,
	IdAlumno = @idalumno,
	IdPersonal = @idpersonal,
	Fecha = @fecha
where IdMatricula = @idmatricula
go
create procedure sp_Matricula_Eliminar
@idmatricula int
as
delete from Matricula where IdMatricula = @idmatricula
go
