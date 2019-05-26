use CETPRO
go
create procedure sp_Sede_Listar
as
select IdSede,
	CodigoModular,
	Cetpro,
	TipoGestion,
	Autorizacion,
	Conversion,
	IdUbigeo,
	Direccion,
	CodUgel,
	Telefono,
	Estado
from Sede
go
create procedure sp_Sede_Obtener
@idsede int
as
select IdSede,
	CodigoModular,
	Cetpro,
	TipoGestion,
	Autorizacion,
	Conversion,
	IdUbigeo,
	Direccion,
	CodUgel,
	Telefono,
	Estado
from Sede
where IdSede = @idsede
go
create procedure sp_Sede_Insertar
@codigomodular varchar(8),
@cetpro varchar(100),
@tipogestion varchar(2),
@autorizacion varchar(35),
@conversion varchar(35),
@idubigeo varchar(6),
@direccion varchar(200),
@codugel varchar(3),
@telefono varchar(15),
@estado bit
as
insert into Sede(CodigoModular,Cetpro,TipoGestion,Autorizacion,Conversion,IdUbigeo,Direccion,CodUgel,Telefono,Estado)
values(@codigomodular,@cetpro,@tipogestion,@autorizacion,@conversion,@idubigeo,@direccion,@codugel,@telefono,@estado)
go
create procedure sp_Sede_Actualizar
@idsede int,
@codigomodular varchar(8),
@cetpro varchar(100),
@tipogestion varchar(2),
@autorizacion varchar(35),
@conversion varchar(35),
@idubigeo varchar(6),
@direccion varchar(200),
@codugel varchar(3),
@telefono varchar(15),
@estado bit
as
update Sede
set CodigoModular = @CodigoModular,
	Cetpro = @cetpro,
	TipoGestion = @tipogestion,
	Autorizacion = @autorizacion,
	Conversion = @conversion,
	IdUbigeo = @idubigeo,
	Direccion = @direccion,
	CodUgel = @codugel,
	Telefono = @telefono,
	Estado = @estado
where IdSede = @idsede
go
create procedure sp_Sede_Eliminar
@idsede int
as
delete from Sede where IdSede = @idsede
go
