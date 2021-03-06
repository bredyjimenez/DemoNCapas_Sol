USE master
GO

-- Creando la Base de Datos DemoNCapas
if(DB_ID('DemoNCapas')is not null)
	drop DataBase DemoNCapas
create DataBase DemoNCapas
go

USE DemoNCapas
GO

-- Creando tabla Alumno
CREATE TABLE Alumno(
	IdAlumno int identity(10,1) primary key,
	Dni char(8) NOT NULL,
	Apellidos varchar(30) NOT NULL,
	Nombres varchar(30) NOT NULL,
	Sexo char(1) check(Sexo in('M','F')) NOT NULL,
	FechaNac date NOT NULL,
	Direccion varchar(50) NOT NULL,
)
GO

-- Algunos insert
insert Alumno values('12345678', 'Rodriguez Ancajima', 'Pncho', 'M', '05/23/1998', 'Av. Los Inca  La Victoria')
insert Alumno values('87654321', 'Silva Ramos', 'Ana Esther', 'F', '09/21/1994', 'Urb. Los Ficus - Pimentel')
go

-- Crear procedimiento almacenado que permita Actualizar los Alumnos
Create proc [dbo].[ActualizarAlumnos]
@Dni char(8),
@Apellidos varchar(30),
@Nombres varchar(30),
@Sexo char(1),
@FechaNac date,
@Direccion varchar(50),
@Mensaje varchar(100) out
as begin
	if(not exists(select * from Alumno where Dni=@Dni))
	set @Mensaje='El Dni del Alumno no existe'
	else begin
		update Alumno set Apellidos=@Apellidos, Nombres=@Nombres, Sexo=@Sexo, FechaNac=@FechaNac, Direccion=@Direccion where Dni=@Dni
		set @Mensaje='Datos Actualizados Correctamente.'
	end
end
GO

-- Creando procedimiento almacenado que permite Buscar Alumnos
Create proc [dbo].[BuscarAlumnos]
@Dni char(8)
As begin
	select * from Alumno where Dni=@Dni
end
GO

-- Crear procedimiento almacenado que permita Eliminar Alumnos
Create proc [dbo].[EliminarAlumnos]
@Dni char(8),
@Mensaje varchar(100) out
as begin
	if(not exists(select * from Alumno where Dni=@Dni))
	set @Mensaje='Dni del Alumno no se Encuentra Disponible, o no Existe.'
	else begin
		delete from Alumno where Dni=@Dni
		set @Mensaje='Registro Eliminado Satisfactoriamente.'
	end
end
GO

-- Crear procedimiento almacenado que permitan realizar un Listado de Alumnos, con sus respectivas Edades
-- Nota: Este procedimiento cálcula la edad de un alumno sin tener un campo edad.
Create proc [dbo].[ListarAlumnos]
as begin
	select	*, Edad=DATEDIFF(yy,FechaNac, GETDATE())	from Alumno
end
GO

-- Crear un Procedimiento almacenado que permita Registar Alumnos
Create proc [dbo].[RegistrarAlumnos]
@Dni char(8),
@Apellidos varchar(30),
@Nombres varchar(30),
@Sexo char(1),
@FechaNac date,
@Direccion varchar(50),
@Mensaje varchar(100) out
as begin
	if(exists(select * from Alumno where Dni=@Dni))
	set @Mensaje = 'El Alumno ya está Registrado.'
	else begin
		insert Alumno values(@Dni, @Apellidos, @Nombres, @Sexo, @FechaNac, @Direccion)
		set @Mensaje = 'Registrado Correctamente.'
	end
end
GO