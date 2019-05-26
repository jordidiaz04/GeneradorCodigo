use CETPRO
go
create procedure sp_Profesion_Listar
as
select IdProfesion,
	Descripcion,
	Estado
from Profesion
go
create procedure sp_Profesion_Obtener
@idprofesion int
as
select IdProfesion,
	Descripcion,
	Estado
from Profesion
where IdProfesion = @idprofesion
go
create procedure sp_Profesion_Insertar
@descripcion varchar(100),
@estado bit
as
insert into Profesion(Descripcion,Estado)
values(@descripcion,@estado)
go
create procedure sp_Profesion_Actualizar
@idprofesion int,
@descripcion varchar(100),
@estado bit
as
update Profesion
set Descripcion = @Descripcion,
	Estado = @estado
where IdProfesion = @idprofesion
go
create procedure sp_Profesion_Eliminar
@idprofesion int
as
delete from Profesion where IdProfesion = @idprofesion
go
