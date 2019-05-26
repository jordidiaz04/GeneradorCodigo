using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class AulaDA
	{
		public List<AulaBE> listar()
		{
			List<AulaBE> lstAulaBE = new List<AulaBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Aula_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						AulaBE oAulaBE = new AulaBE();
						oAulaBE.IdAula = String.IsNullOrEmpty(dr["IdAula"].ToString()) ? 0 : Convert.ToInt32(dr["IdAula"].ToString());
						oAulaBE.Pabellon = String.IsNullOrEmpty(dr["Pabellon"].ToString()) ? "" : dr["Pabellon"].ToString();
						oAulaBE.Numero = String.IsNullOrEmpty(dr["Numero"].ToString()) ? "" : dr["Numero"].ToString();
						oAulaBE.Capacidad = String.IsNullOrEmpty(dr["Capacidad"].ToString()) ? 0 : Convert.ToInt32(dr["Capacidad"].ToString());
						oAulaBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstAulaBE.Add(oAulaBE);
					}
				}
				catch (Exception ex)
				{
					lstAulaBE = null;
					throw ex;
				}
			}
			return lstAulaBE;
		}

		public AulaBE obtener(AulaBE oAulaBE)
		{
			AulaBE objAulaBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Aula_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idaula", oAulaBE.IdAula);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objAulaBE = new AulaBE();
							oAulaBE.IdAula = String.IsNullOrEmpty(dr["IdAula"].ToString()) ? 0 : Convert.ToInt32(dr["IdAula"].ToString());
							oAulaBE.Pabellon = String.IsNullOrEmpty(dr["Pabellon"].ToString()) ? "" : dr["Pabellon"].ToString();
							oAulaBE.Numero = String.IsNullOrEmpty(dr["Numero"].ToString()) ? "" : dr["Numero"].ToString();
							oAulaBE.Capacidad = String.IsNullOrEmpty(dr["Capacidad"].ToString()) ? 0 : Convert.ToInt32(dr["Capacidad"].ToString());
							oAulaBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objAulaBE = null;
					throw ex;
				}
				return objAulaBE;
			}
		}

		public int insertar(AulaBE oAulaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Aula_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@pabellon", oAulaBE.Pabellon);
					da.SelectCommand.Parameters.AddWithValue("@numero", oAulaBE.Numero);
					da.SelectCommand.Parameters.AddWithValue("@capacidad", oAulaBE.Capacidad);
					da.SelectCommand.Parameters.AddWithValue("@estado", oAulaBE.Estado);
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

		public int actualizar(AulaBE oAulaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Aula_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idaula", oAulaBE.IdAula);
					da.SelectCommand.Parameters.AddWithValue("@pabellon", oAulaBE.Pabellon);
					da.SelectCommand.Parameters.AddWithValue("@numero", oAulaBE.Numero);
					da.SelectCommand.Parameters.AddWithValue("@capacidad", oAulaBE.Capacidad);
					da.SelectCommand.Parameters.AddWithValue("@estado", oAulaBE.Estado);
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

		public int eliminar(AulaBE oAulaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Aula_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idaula", oAulaBE.IdAula);
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
