use CETPRO
go
create procedure sp_Bloque_Listar
as
select IdBloque,
	IdSede,
	IdCurso,
	IdProfesor,
	IdAula,
	Turno,
	FechaInicio,
	FechaFin,
	HoraInicio,
	HoraFin,
	CodigoCreacion,
	CodigoConversion,
	Estado
from Bloque
go
create procedure sp_Bloque_Obtener
@idbloque int
as
select IdBloque,
	IdSede,
	IdCurso,
	IdProfesor,
	IdAula,
	Turno,
	FechaInicio,
	FechaFin,
	HoraInicio,
	HoraFin,
	CodigoCreacion,
	CodigoConversion,
	Estado
from Bloque
where IdBloque = @idbloque
go
create procedure sp_Bloque_Insertar
@idsede int,
@idcurso int,
@idprofesor int,
@idaula int,
@turno varchar(2),
@fechainicio date,
@fechafin date,
@horainicio varchar(8),
@horafin varchar(8),
@codigocreacion varchar(30),
@codigoconversion varchar(30),
@estado bit
as
insert into Bloque(IdSede,IdCurso,IdProfesor,IdAula,Turno,FechaInicio,FechaFin,HoraInicio,HoraFin,CodigoCreacion,CodigoConversion,Estado)
values(@idsede,@idcurso,@idprofesor,@idaula,@turno,@fechainicio,@fechafin,@horainicio,@horafin,@codigocreacion,@codigoconversion,@estado)
go
create procedure sp_Bloque_Actualizar
@idbloque int,
@idsede int,
@idcurso int,
@idprofesor int,
@idaula int,
@turno varchar(2),
@fechainicio date,
@fechafin date,
@horainicio varchar(8),
@horafin varchar(8),
@codigocreacion varchar(30),
@codigoconversion varchar(30),
@estado bit
as
update Bloque
set IdSede = @IdSede,
	IdCurso = @idcurso,
	IdProfesor = @idprofesor,
	IdAula = @idaula,
	Turno = @turno,
	FechaInicio = @fechainicio,
	FechaFin = @fechafin,
	HoraInicio = @horainicio,
	HoraFin = @horafin,
	CodigoCreacion = @codigocreacion,
	CodigoConversion = @codigoconversion,
	Estado = @estado
where IdBloque = @idbloque
go
create procedure sp_Bloque_Eliminar
@idbloque int
as
delete from Bloque where IdBloque = @idbloque
go
