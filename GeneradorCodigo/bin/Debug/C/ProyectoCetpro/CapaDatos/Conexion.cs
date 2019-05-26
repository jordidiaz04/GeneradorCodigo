using System.Configuration;

namespace CapaDatos
{
	public class Conexion
	{
		public string getConnectionString()
		{
			string strConexion = ConfigurationManager.ConnectionStrings["CETPRO"].ConnectionString;
			if (object.ReferenceEquals(strConexion, string.Empty)) return string.Empty;
			else return strConexion;
		}
	}
}
