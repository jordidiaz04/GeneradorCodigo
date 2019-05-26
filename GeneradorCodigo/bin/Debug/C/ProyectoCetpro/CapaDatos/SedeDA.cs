using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class SedeDA
	{
		public List<SedeBE> listar()
		{
			List<SedeBE> lstSedeBE = new List<SedeBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Sede_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						SedeBE oSedeBE = new SedeBE();
						oSedeBE.IdSede = String.IsNullOrEmpty(dr["IdSede"].ToString()) ? 0 : Convert.ToInt32(dr["IdSede"].ToString());
						oSedeBE.CodigoModular = String.IsNullOrEmpty(dr["CodigoModular"].ToString()) ? "" : dr["CodigoModular"].ToString();
						oSedeBE.Cetpro = String.IsNullOrEmpty(dr["Cetpro"].ToString()) ? "" : dr["Cetpro"].ToString();
						oSedeBE.TipoGestion = String.IsNullOrEmpty(dr["TipoGestion"].ToString()) ? "" : dr["TipoGestion"].ToString();
						oSedeBE.Autorizacion = String.IsNullOrEmpty(dr["Autorizacion"].ToString()) ? "" : dr["Autorizacion"].ToString();
						oSedeBE.Conversion = String.IsNullOrEmpty(dr["Conversion"].ToString()) ? "" : dr["Conversion"].ToString();
						oSedeBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
						oSedeBE.Direccion = String.IsNullOrEmpty(dr["Direccion"].ToString()) ? "" : dr["Direccion"].ToString();
						oSedeBE.CodUgel = String.IsNullOrEmpty(dr["CodUgel"].ToString()) ? "" : dr["CodUgel"].ToString();
						oSedeBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
						oSedeBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstSedeBE.Add(oSedeBE);
					}
				}
				catch (Exception ex)
				{
					lstSedeBE = null;
					throw ex;
				}
			}
			return lstSedeBE;
		}

		public SedeBE obtener(SedeBE oSedeBE)
		{
			SedeBE objSedeBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Sede_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idsede", oSedeBE.IdSede);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objSedeBE = new SedeBE();
							oSedeBE.IdSede = String.IsNullOrEmpty(dr["IdSede"].ToString()) ? 0 : Convert.ToInt32(dr["IdSede"].ToString());
							oSedeBE.CodigoModular = String.IsNullOrEmpty(dr["CodigoModular"].ToString()) ? "" : dr["CodigoModular"].ToString();
							oSedeBE.Cetpro = String.IsNullOrEmpty(dr["Cetpro"].ToString()) ? "" : dr["Cetpro"].ToString();
							oSedeBE.TipoGestion = String.IsNullOrEmpty(dr["TipoGestion"].ToString()) ? "" : dr["TipoGestion"].ToString();
							oSedeBE.Autorizacion = String.IsNullOrEmpty(dr["Autorizacion"].ToString()) ? "" : dr["Autorizacion"].ToString();
							oSedeBE.Conversion = String.IsNullOrEmpty(dr["Conversion"].ToString()) ? "" : dr["Conversion"].ToString();
							oSedeBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
							oSedeBE.Direccion = String.IsNullOrEmpty(dr["Direccion"].ToString()) ? "" : dr["Direccion"].ToString();
							oSedeBE.CodUgel = String.IsNullOrEmpty(dr["CodUgel"].ToString()) ? "" : dr["CodUgel"].ToString();
							oSedeBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
							oSedeBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objSedeBE = null;
					throw ex;
				}
				return objSedeBE;
			}
		}

		public int insertar(SedeBE oSedeBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Sede_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@codigomodular", oSedeBE.CodigoModular);
					da.SelectCommand.Parameters.AddWithValue("@cetpro", oSedeBE.Cetpro);
					da.SelectCommand.Parameters.AddWithValue("@tipogestion", oSedeBE.TipoGestion);
					da.SelectCommand.Parameters.AddWithValue("@autorizacion", oSedeBE.Autorizacion);
					da.SelectCommand.Parameters.AddWithValue("@conversion", oSedeBE.Conversion);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oSedeBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@direccion", oSedeBE.Direccion);
					da.SelectCommand.Parameters.AddWithValue("@codugel", oSedeBE.CodUgel);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oSedeBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@estado", oSedeBE.Estado);
					result = da.SelectCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					result = 0;
					throw ex;
				}
				return result;
			}
		}

		public int actualizar(SedeBE oSedeBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Sede_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idsede", oSedeBE.IdSede);
					da.SelectCommand.Parameters.AddWithValue("@codigomodular", oSedeBE.CodigoModular);
					da.SelectCommand.Parameters.AddWithValue("@cetpro", oSedeBE.Cetpro);
					da.SelectCommand.Parameters.AddWithValue("@tipogestion", oSedeBE.TipoGestion);
					da.SelectCommand.Parameters.AddWithValue("@autorizacion", oSedeBE.Autorizacion);
					da.SelectCommand.Parameters.AddWithValue("@conversion", oSedeBE.Conversion);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oSedeBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@direccion", oSedeBE.Direccion);
					da.SelectCommand.Parameters.AddWithValue("@codugel", oSedeBE.CodUgel);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oSedeBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@estado", oSedeBE.Estado);
					result = da.SelectCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					result = 0;
					throw ex;
				}
				return result;
			}
		}

		public int eliminar(SedeBE oSedeBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Sede_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idsede", oSedeBE.IdSede);
					result = da.SelectCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					result = 0;
					throw ex;
				}
				return result;
			}
		}
	}
}
