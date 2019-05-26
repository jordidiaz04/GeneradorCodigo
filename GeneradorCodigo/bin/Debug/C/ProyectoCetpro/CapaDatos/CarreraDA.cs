using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class CarreraDA
	{
		public List<CarreraBE> listar()
		{
			List<CarreraBE> lstCarreraBE = new List<CarreraBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Carrera_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						CarreraBE oCarreraBE = new CarreraBE();
						oCarreraBE.IdCarrera = String.IsNullOrEmpty(dr["IdCarrera"].ToString()) ? 0 : Convert.ToInt32(dr["IdCarrera"].ToString());
						oCarreraBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
						oCarreraBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstCarreraBE.Add(oCarreraBE);
					}
				}
				catch (Exception ex)
				{
					lstCarreraBE = null;
					throw ex;
				}
			}
			return lstCarreraBE;
		}

		public CarreraBE obtener(CarreraBE oCarreraBE)
		{
			CarreraBE objCarreraBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Carrera_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idcarrera", oCarreraBE.IdCarrera);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objCarreraBE = new CarreraBE();
							oCarreraBE.IdCarrera = String.IsNullOrEmpty(dr["IdCarrera"].ToString()) ? 0 : Convert.ToInt32(dr["IdCarrera"].ToString());
							oCarreraBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
							oCarreraBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objCarreraBE = null;
					throw ex;
				}
				return objCarreraBE;
			}
		}

		public int insertar(CarreraBE oCarreraBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Carrera_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCarreraBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCarreraBE.Estado);
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

		public int actualizar(CarreraBE oCarreraBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Carrera_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcarrera", oCarreraBE.IdCarrera);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCarreraBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCarreraBE.Estado);
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

		public int eliminar(CarreraBE oCarreraBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Carrera_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcarrera", oCarreraBE.IdCarrera);
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
