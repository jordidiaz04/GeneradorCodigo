using System;

namespace CapaEntidad
{
	public class ProfesorBE
	{
		public int IdProfesor { get; set; }
		public String TipoDocIdentidad { get; set; }
		public String DocIdentidad { get; set; }
		public String Nombres { get; set; }
		public String ApellidoPaterno { get; set; }
		public String ApellidoMaterno { get; set; }
		public String Sexo { get; set; }
		public String FechaNacimiento { get; set; }
		public String IdUbigeo { get; set; }
		public String Domicilio { get; set; }
		public String EstadoCivil { get; set; }
		public String Email { get; set; }
		public String Telefono { get; set; }
		public int IdProfesion { get; set; }
		public String Clave { get; set; }
		public Boolean Estado { get; set; }
	}
}
