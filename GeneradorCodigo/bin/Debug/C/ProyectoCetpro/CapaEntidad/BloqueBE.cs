using System;

namespace CapaEntidad
{
	public class BloqueBE
	{
		public int IdBloque { get; set; }
		public int IdSede { get; set; }
		public int IdCurso { get; set; }
		public int IdProfesor { get; set; }
		public int IdAula { get; set; }
		public String Turno { get; set; }
		public String FechaInicio { get; set; }
		public String FechaFin { get; set; }
		public String HoraInicio { get; set; }
		public String HoraFin { get; set; }
		public String CodigoCreacion { get; set; }
		public String CodigoConversion { get; set; }
		public Boolean Estado { get; set; }
	}
}
