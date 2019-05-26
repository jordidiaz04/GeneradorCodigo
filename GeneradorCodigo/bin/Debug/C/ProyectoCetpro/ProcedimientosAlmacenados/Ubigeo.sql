use CETPRO
go
create procedure sp_Ubigeo_Listar
as
select IdUbigeo,
	Departamento,
	Provincia,
	Distrito,
	Ubicacion
from Ubigeo
go
create procedure sp_Ubigeo_Obtener
@idubigeo varchar(6)
as
select IdUbigeo,
	Departamento,
	Provincia,
	Distrito,
	Ubicacion
from Ubigeo
where IdUbigeo = @idubigeo
go
create procedure sp_Ubigeo_Insertar
@departamento varchar(2),
@provincia varchar(2),
@distrito varchar(2),
@ubicacion varchar(100)
as
insert into Ubigeo(Departamento,Provincia,Distrito,Ubicacion)
values(@departamento,@provincia,@distrito,@ubicacion)
go
create procedure sp_Ubigeo_Actualizar
@idubigeo varchar(6),
@departamento varchar(2),
@provincia varchar(2),
@distrito varchar(2),
@ubicacion varchar(100)
as
update Ubigeo
set Departamento = @Departamento,
	Provincia = @provincia,
	Distrito = @distrito,
	Ubicacion = @ubicacion
where IdUbigeo = @idubigeo
go
create procedure sp_Ubigeo_Eliminar
@idubigeo varchar(6)
as
delete from Ubigeo where IdUbigeo = @idubigeo
go
