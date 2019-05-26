use CETPRO
go
create procedure sp_Cargo_Listar
as
select IdCargo,
	Descripcion,
	Estado
from Cargo
go
create procedure sp_Cargo_Obtener
@idcargo int
as
select IdCargo,
	Descripcion,
	Estado
from Cargo
where IdCargo = @idcargo
go
create procedure sp_Cargo_Insertar
@descripcion varchar(50),
@estado bit
as
insert into Cargo(Descripcion,Estado)
values(@descripcion,@estado)
go
create procedure sp_Cargo_Actualizar
@idcargo int,
@descripcion varchar(50),
@estado bit
as
update Cargo
set Descripcion = @Descripcion,
	Estado = @estado
where IdCargo = @idcargo
go
create procedure sp_Cargo_Eliminar
@idcargo int
as
delete from Cargo where IdCargo = @idcargo
go
