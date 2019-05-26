using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class CargoDA
	{
		public List<CargoBE> listar()
		{
			List<CargoBE> lstCargoBE = new List<CargoBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Cargo_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						CargoBE oCargoBE = new CargoBE();
						oCargoBE.IdCargo = String.IsNullOrEmpty(dr["IdCargo"].ToString()) ? 0 : Convert.ToInt32(dr["IdCargo"].ToString());
						oCargoBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
						oCargoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstCargoBE.Add(oCargoBE);
					}
				}
				catch (Exception ex)
				{
					lstCargoBE = null;
					throw ex;
				}
			}
			return lstCargoBE;
		}

		public CargoBE obtener(CargoBE oCargoBE)
		{
			CargoBE objCargoBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Cargo_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idcargo", oCargoBE.IdCargo);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objCargoBE = new CargoBE();
							oCargoBE.IdCargo = String.IsNullOrEmpty(dr["IdCargo"].ToString()) ? 0 : Convert.ToInt32(dr["IdCargo"].ToString());
							oCargoBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
							oCargoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objCargoBE = null;
					throw ex;
				}
				return objCargoBE;
			}
		}

		public int insertar(CargoBE oCargoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Cargo_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCargoBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCargoBE.Estado);
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

		public int actualizar(CargoBE oCargoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Cargo_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcargo", oCargoBE.IdCargo);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCargoBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCargoBE.Estado);
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

		public int eliminar(CargoBE oCargoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Cargo_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcargo", oCargoBE.IdCargo);
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
