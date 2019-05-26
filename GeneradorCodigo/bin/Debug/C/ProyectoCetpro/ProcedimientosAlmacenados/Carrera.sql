use CETPRO
go
create procedure sp_Carrera_Listar
as
select IdCarrera,
	Descripcion,
	Estado
from Carrera
go
create procedure sp_Carrera_Obtener
@idcarrera int
as
select IdCarrera,
	Descripcion,
	Estado
from Carrera
where IdCarrera = @idcarrera
go
create procedure sp_Carrera_Insertar
@descripcion varchar(60),
@estado bit
as
insert into Carrera(Descripcion,Estado)
values(@descripcion,@estado)
go
create procedure sp_Carrera_Actualizar
@idcarrera int,
@descripcion varchar(60),
@estado bit
as
update Carrera
set Descripcion = @Descripcion,
	Estado = @estado
where IdCarrera = @idcarrera
go
create procedure sp_Carrera_Eliminar
@idcarrera int
as
delete from Carrera where IdCarrera = @idcarrera
go
