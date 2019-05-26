use CETPRO
go
create procedure sp_Alumno_Listar
as
select IdAlumno,
	Codigo,
	TipoDocIdentidad,
	DocIdentidad,
	Nombres,
	ApellidoPaterno,
	ApellidoMaterno,
	IdCondicion,
	Sexo,
	IdUbigeoNacimiento,
	FechaNacimiento,
	IdUbigeo,
	Domicilio,
	EstadoCivil,
	GradoEstudio,
	EstadoGradoEstudio,
	Email,
	Telefono,
	Trabaja,
	Ocupacion,
	Clave,
	Imagen,
	Estado
from Alumno
go
create procedure sp_Alumno_Obtener
@idalumno int
as
select IdAlumno,
	Codigo,
	TipoDocIdentidad,
	DocIdentidad,
	Nombres,
	ApellidoPaterno,
	ApellidoMaterno,
	IdCondicion,
	Sexo,
	IdUbigeoNacimiento,
	FechaNacimiento,
	IdUbigeo,
	Domicilio,
	EstadoCivil,
	GradoEstudio,
	EstadoGradoEstudio,
	Email,
	Telefono,
	Trabaja,
	Ocupacion,
	Clave,
	Imagen,
	Estado
from Alumno
where IdAlumno = @idalumno
go
create procedure sp_Alumno_Insertar
@codigo varchar(15),
@tipodocidentidad varchar(2),
@docidentidad varchar(15),
@nombres varchar(60),
@apellidopaterno varchar(60),
@apellidomaterno varchar(60),
@idcondicion varchar(2),
@sexo varchar(1),
@idubigeonacimiento varchar(6),
@fechanacimiento date,
@idubigeo varchar(6),
@domicilio varchar(500),
@estadocivil varchar(2),
@gradoestudio varchar(2),
@estadogradoestudio varchar(2),
@email varchar(150),
@telefono varchar(15),
@trabaja bit,
@ocupacion varchar(2),
@clave varchar(16),
@imagen varchar(max),
@estado bit
as
insert into Alumno(Codigo,TipoDocIdentidad,DocIdentidad,Nombres,ApellidoPaterno,ApellidoMaterno,IdCondicion,Sexo,IdUbigeoNacimiento,FechaNacimiento,IdUbigeo,Domicilio,EstadoCivil,GradoEstudio,EstadoGradoEstudio,Email,Telefono,Trabaja,Ocupacion,Clave,Imagen,Estado)
values(@codigo,@tipodocidentidad,@docidentidad,@nombres,@apellidopaterno,@apellidomaterno,@idcondicion,@sexo,@idubigeonacimiento,@fechanacimiento,@idubigeo,@domicilio,@estadocivil,@gradoestudio,@estadogradoestudio,@email,@telefono,@trabaja,@ocupacion,@clave,@imagen,@estado)
go
create procedure sp_Alumno_Actualizar
@idalumno int,
@codigo varchar(15),
@tipodocidentidad varchar(2),
@docidentidad varchar(15),
@nombres varchar(60),
@apellidopaterno varchar(60),
@apellidomaterno varchar(60),
@idcondicion varchar(2),
@sexo varchar(1),
@idubigeonacimiento varchar(6),
@fechanacimiento date,
@idubigeo varchar(6),
@domicilio varchar(500),
@estadocivil varchar(2),
@gradoestudio varchar(2),
@estadogradoestudio varchar(2),
@email varchar(150),
@telefono varchar(15),
@trabaja bit,
@ocupacion varchar(2),
@clave varchar(16),
@imagen varchar(max),
@estado bit
as
update Alumno
set Codigo = @Codigo,
	TipoDocIdentidad = @tipodocidentidad,
	DocIdentidad = @docidentidad,
	Nombres = @nombres,
	ApellidoPaterno = @apellidopaterno,
	ApellidoMaterno = @apellidomaterno,
	IdCondicion = @idcondicion,
	Sexo = @sexo,
	IdUbigeoNacimiento = @idubigeonacimiento,
	FechaNacimiento = @fechanacimiento,
	IdUbigeo = @idubigeo,
	Domicilio = @domicilio,
	EstadoCivil = @estadocivil,
	GradoEstudio = @gradoestudio,
	EstadoGradoEstudio = @estadogradoestudio,
	Email = @email,
	Telefono = @telefono,
	Trabaja = @trabaja,
	Ocupacion = @ocupacion,
	Clave = @clave,
	Imagen = @imagen,
	Estado = @estado
where IdAlumno = @idalumno
go
create procedure sp_Alumno_Eliminar
@idalumno int
as
delete from Alumno where IdAlumno = @idalumno
go
