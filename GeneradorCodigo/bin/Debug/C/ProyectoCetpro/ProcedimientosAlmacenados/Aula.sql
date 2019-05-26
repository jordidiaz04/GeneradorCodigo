use CETPRO
go
create procedure sp_Aula_Listar
as
select IdAula,
	Pabellon,
	Numero,
	Capacidad,
	Estado
from Aula
go
create procedure sp_Aula_Obtener
@idaula int
as
select IdAula,
	Pabellon,
	Numero,
	Capacidad,
	Estado
from Aula
where IdAula = @idaula
go
create procedure sp_Aula_Insertar
@pabellon varchar(2),
@numero varchar(4),
@capacidad int,
@estado bit
as
insert into Aula(Pabellon,Numero,Capacidad,Estado)
values(@pabellon,@numero,@capacidad,@estado)
go
create procedure sp_Aula_Actualizar
@idaula int,
@pabellon varchar(2),
@numero varchar(4),
@capacidad int,
@estado bit
as
update Aula
set Pabellon = @Pabellon,
	Numero = @numero,
	Capacidad = @capacidad,
	Estado = @estado
where IdAula = @idaula
go
create procedure sp_Aula_Eliminar
@idaula int
as
delete from Aula where IdAula = @idaula
go
