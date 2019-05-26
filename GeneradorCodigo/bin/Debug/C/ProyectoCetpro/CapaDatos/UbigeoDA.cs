using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class UbigeoDA
	{
		public List<UbigeoBE> listar()
		{
			List<UbigeoBE> lstUbigeoBE = new List<UbigeoBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Ubigeo_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						UbigeoBE oUbigeoBE = new UbigeoBE();
						oUbigeoBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
						oUbigeoBE.Departamento = String.IsNullOrEmpty(dr["Departamento"].ToString()) ? "" : dr["Departamento"].ToString();
						oUbigeoBE.Provincia = String.IsNullOrEmpty(dr["Provincia"].ToString()) ? "" : dr["Provincia"].ToString();
						oUbigeoBE.Distrito = String.IsNullOrEmpty(dr["Distrito"].ToString()) ? "" : dr["Distrito"].ToString();
						oUbigeoBE.Ubicacion = String.IsNullOrEmpty(dr["Ubicacion"].ToString()) ? "" : dr["Ubicacion"].ToString();
						lstUbigeoBE.Add(oUbigeoBE);
					}
				}
				catch (Exception ex)
				{
					lstUbigeoBE = null;
					throw ex;
				}
			}
			return lstUbigeoBE;
		}

		public UbigeoBE obtener(UbigeoBE oUbigeoBE)
		{
			UbigeoBE objUbigeoBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Ubigeo_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idubigeo", oUbigeoBE.IdUbigeo);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objUbigeoBE = new UbigeoBE();
							oUbigeoBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
							oUbigeoBE.Departamento = String.IsNullOrEmpty(dr["Departamento"].ToString()) ? "" : dr["Departamento"].ToString();
							oUbigeoBE.Provincia = String.IsNullOrEmpty(dr["Provincia"].ToString()) ? "" : dr["Provincia"].ToString();
							oUbigeoBE.Distrito = String.IsNullOrEmpty(dr["Distrito"].ToString()) ? "" : dr["Distrito"].ToString();
							oUbigeoBE.Ubicacion = String.IsNullOrEmpty(dr["Ubicacion"].ToString()) ? "" : dr["Ubicacion"].ToString();
						}
				}
				catch (Exception ex)
				{
					objUbigeoBE = null;
					throw ex;
				}
				return objUbigeoBE;
			}
		}

		public int insertar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Ubigeo_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@departamento", oUbigeoBE.Departamento);
					da.SelectCommand.Parameters.AddWithValue("@provincia", oUbigeoBE.Provincia);
					da.SelectCommand.Parameters.AddWithValue("@distrito", oUbigeoBE.Distrito);
					da.SelectCommand.Parameters.AddWithValue("@ubicacion", oUbigeoBE.Ubicacion);
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

		public int actualizar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Ubigeo_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oUbigeoBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@departamento", oUbigeoBE.Departamento);
					da.SelectCommand.Parameters.AddWithValue("@provincia", oUbigeoBE.Provincia);
					da.SelectCommand.Parameters.AddWithValue("@distrito", oUbigeoBE.Distrito);
					da.SelectCommand.Parameters.AddWithValue("@ubicacion", oUbigeoBE.Ubicacion);
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

		public int eliminar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Ubigeo_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oUbigeoBE.IdUbigeo);
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
