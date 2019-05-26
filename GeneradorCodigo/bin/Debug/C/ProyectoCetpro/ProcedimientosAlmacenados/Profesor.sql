use CETPRO
go
create procedure sp_Profesor_Listar
as
select IdProfesor,
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
	IdProfesion,
	Clave,
	Estado
from Profesor
go
create procedure sp_Profesor_Obtener
@idprofesor int
as
select IdProfesor,
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
	IdProfesion,
	Clave,
	Estado
from Profesor
where IdProfesor = @idprofesor
go
create procedure sp_Profesor_Insertar
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
@idprofesion int,
@clave varchar(16),
@estado bit
as
insert into Profesor(TipoDocIdentidad,DocIdentidad,Nombres,ApellidoPaterno,ApellidoMaterno,Sexo,FechaNacimiento,IdUbigeo,Domicilio,EstadoCivil,Email,Telefono,IdProfesion,Clave,Estado)
values(@tipodocidentidad,@docidentidad,@nombres,@apellidopaterno,@apellidomaterno,@sexo,@fechanacimiento,@idubigeo,@domicilio,@estadocivil,@email,@telefono,@idprofesion,@clave,@estado)
go
create procedure sp_Profesor_Actualizar
@idprofesor int,
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
@idprofesion int,
@clave varchar(16),
@estado bit
as
update Profesor
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
	IdProfesion = @idprofesion,
	Clave = @clave,
	Estado = @estado
where IdProfesor = @idprofesor
go
create procedure sp_Profesor_Eliminar
@idprofesor int
as
delete from Profesor where IdProfesor = @idprofesor
go
