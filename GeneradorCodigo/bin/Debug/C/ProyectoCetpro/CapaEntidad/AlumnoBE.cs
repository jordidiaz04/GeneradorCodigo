using System;

namespace CapaEntidad
{
	public class AlumnoBE
	{
		public int IdAlumno { get; set; }
		public String Codigo { get; set; }
		public String TipoDocIdentidad { get; set; }
		public String DocIdentidad { get; set; }
		public String Nombres { get; set; }
		public String ApellidoPaterno { get; set; }
		public String ApellidoMaterno { get; set; }
		public String IdCondicion { get; set; }
		public String Sexo { get; set; }
		public String IdUbigeoNacimiento { get; set; }
		public String FechaNacimiento { get; set; }
		public String IdUbigeo { get; set; }
		public String Domicilio { get; set; }
		public String EstadoCivil { get; set; }
		public String GradoEstudio { get; set; }
		public String EstadoGradoEstudio { get; set; }
		public String Email { get; set; }
		public String Telefono { get; set; }
		public Boolean Trabaja { get; set; }
		public String Ocupacion { get; set; }
		public String Clave { get; set; }
		public String Imagen { get; set; }
		public Boolean Estado { get; set; }
	}
}
