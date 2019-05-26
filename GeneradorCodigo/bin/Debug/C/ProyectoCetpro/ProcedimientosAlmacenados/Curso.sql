use CETPRO
go
create procedure sp_Curso_Listar
as
select IdCurso,
	IdCarrera,
	Descripcion,
	Horas,
	Estado
from Curso
go
create procedure sp_Curso_Obtener
@idcurso int
as
select IdCurso,
	IdCarrera,
	Descripcion,
	Horas,
	Estado
from Curso
where IdCurso = @idcurso
go
create procedure sp_Curso_Insertar
@idcarrera int,
@descripcion varchar(100),
@horas varchar(3),
@estado bit
as
insert into Curso(IdCarrera,Descripcion,Horas,Estado)
values(@idcarrera,@descripcion,@horas,@estado)
go
create procedure sp_Curso_Actualizar
@idcurso int,
@idcarrera int,
@descripcion varchar(100),
@horas varchar(3),
@estado bit
as
update Curso
set IdCarrera = @IdCarrera,
	Descripcion = @descripcion,
	Horas = @horas,
	Estado = @estado
where IdCurso = @idcurso
go
create procedure sp_Curso_Eliminar
@idcurso int
as
delete from Curso where IdCurso = @idcurso
go
