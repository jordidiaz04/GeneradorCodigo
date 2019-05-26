use CETPRO
go
create procedure sp_Multitabla_Listar
as
select IdMultitabla,
	Codigo,
	Descripcion,
	Longitud,
	Detalle
from Multitabla
go
create procedure sp_Multitabla_Obtener
@idmultitabla int
as
select IdMultitabla,
	Codigo,
	Descripcion,
	Longitud,
	Detalle
from Multitabla
where IdMultitabla = @idmultitabla
go
create procedure sp_Multitabla_Insertar
@codigo varchar(5),
@descripcion varchar(100),
@longitud int,
@detalle varchar(100)
as
insert into Multitabla(Codigo,Descripcion,Longitud,Detalle)
values(@codigo,@descripcion,@longitud,@detalle)
go
create procedure sp_Multitabla_Actualizar
@idmultitabla int,
@codigo varchar(5),
@descripcion varchar(100),
@longitud int,
@detalle varchar(100)
as
update Multitabla
set Codigo = @Codigo,
	Descripcion = @descripcion,
	Longitud = @longitud,
	Detalle = @detalle
where IdMultitabla = @idmultitabla
go
create procedure sp_Multitabla_Eliminar
@idmultitabla int
as
delete from Multitabla where IdMultitabla = @idmultitabla
go
