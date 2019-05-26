use CETPRO
go
create procedure sp_Personal_Listar
as
select IdPersonal,
	TipoDocIdentidad,
	DocIdentidad,
	Nombres,
	ApellidoPaterno,
	ApellidoMaterno,
	Sexo,
	FechaNacimiento,
	IdUbigeo,
	Domicilio,
	EstadoCivil,
	Email,
	Telefono,
	IdCargo,
	Clave,
	Estado
from Personal
go
create procedure sp_Personal_Obtener
@idpersonal int
as
select IdPersonal,
	TipoDocIdentidad,
	DocIdentidad,
	Nombres,
	ApellidoPaterno,
	ApellidoMaterno,
	Sexo,
	FechaNacimiento,
	IdUbigeo,
	Domicilio,
	EstadoCivil,
	Email,
	Telefono,
	IdCargo,
	Clave,
	Estado
from Personal
where IdPersonal = @idpersonal
go
create procedure sp_Personal_Insertar
@tipodocidentidad varchar(2),
@docidentidad varchar(15),
@nombres varchar(60),
@apellidopaterno varchar(60),
@apellidomaterno varchar(60),
@sexo varchar(1),
@fechanacimiento date,
@idubigeo varchar(6),
@domicilio varchar(200),
@estadocivil varchar(2),
@email varchar(100),
@telefono varchar(15),
@idcargo int,
@clave varchar(16),
@estado bit
as
insert into Personal(TipoDocIdentidad,DocIdentidad,Nombres,ApellidoPaterno,ApellidoMaterno,Sexo,FechaNacimiento,IdUbigeo,Domicilio,EstadoCivil,Email,Telefono,IdCargo,Clave,Estado)
values(@tipodocidentidad,@docidentidad,@nombres,@apellidopaterno,@apellidomaterno,@sexo,@fechanacimiento,@idubigeo,@domicilio,@estadocivil,@email,@telefono,@idcargo,@clave,@estado)
go
create procedure sp_Personal_Actualizar
@idpersonal int,
@tipodocidentidad varchar(2),
@docidentidad varchar(15),
@nombres varchar(60),
@apellidopaterno varchar(60),
@apellidomaterno varchar(60),
@sexo varchar(1),
@fechanacimiento date,
@idubigeo varchar(6),
@domicilio varchar(200),
@estadocivil varchar(2),
@email varchar(100),
@telefono varchar(15),
@idcargo int,
@clave varchar(16),
@estado bit
as
update Personal
set TipoDocIdentidad = @TipoDocIdentidad,
	DocIdentidad = @docidentidad,
	Nombres = @nombres,
	ApellidoPaterno = @apellidopaterno,
	ApellidoMaterno = @apellidomaterno,
	Sexo = @sexo,
	FechaNacimiento = @fechanacimiento,
	IdUbigeo = @idubigeo,
	Domicilio = @domicilio,
	EstadoCivil = @estadocivil,
	Email = @email,
	Telefono = @telefono,
	IdCargo = @idcargo,
	Clave = @clave,
	Estado = @estado
where IdPersonal = @idpersonal
go
create procedure sp_Personal_Eliminar
@idpersonal int
as
delete from Personal where IdPersonal = @idpersonal
go
