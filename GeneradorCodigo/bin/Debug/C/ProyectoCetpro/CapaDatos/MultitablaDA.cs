using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class MultitablaDA
	{
		public List<MultitablaBE> listar()
		{
			List<MultitablaBE> lstMultitablaBE = new List<MultitablaBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Multitabla_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						MultitablaBE oMultitablaBE = new MultitablaBE();
						oMultitablaBE.IdMultitabla = String.IsNullOrEmpty(dr["IdMultitabla"].ToString()) ? 0 : Convert.ToInt32(dr["IdMultitabla"].ToString());
						oMultitablaBE.Codigo = String.IsNullOrEmpty(dr["Codigo"].ToString()) ? "" : dr["Codigo"].ToString();
						oMultitablaBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
						oMultitablaBE.Longitud = String.IsNullOrEmpty(dr["Longitud"].ToString()) ? 0 : Convert.ToInt32(dr["Longitud"].ToString());
						oMultitablaBE.Detalle = String.IsNullOrEmpty(dr["Detalle"].ToString()) ? "" : dr["Detalle"].ToString();
						lstMultitablaBE.Add(oMultitablaBE);
					}
				}
				catch (Exception ex)
				{
					lstMultitablaBE = null;
					throw ex;
				}
			}
			return lstMultitablaBE;
		}

		public MultitablaBE obtener(MultitablaBE oMultitablaBE)
		{
			MultitablaBE objMultitablaBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Multitabla_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idmultitabla", oMultitablaBE.IdMultitabla);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objMultitablaBE = new MultitablaBE();
							oMultitablaBE.IdMultitabla = String.IsNullOrEmpty(dr["IdMultitabla"].ToString()) ? 0 : Convert.ToInt32(dr["IdMultitabla"].ToString());
							oMultitablaBE.Codigo = String.IsNullOrEmpty(dr["Codigo"].ToString()) ? "" : dr["Codigo"].ToString();
							oMultitablaBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
							oMultitablaBE.Longitud = String.IsNullOrEmpty(dr["Longitud"].ToString()) ? 0 : Convert.ToInt32(dr["Longitud"].ToString());
							oMultitablaBE.Detalle = String.IsNullOrEmpty(dr["Detalle"].ToString()) ? "" : dr["Detalle"].ToString();
						}
				}
				catch (Exception ex)
				{
					objMultitablaBE = null;
					throw ex;
				}
				return objMultitablaBE;
			}
		}

		public int insertar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Multitabla_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@codigo", oMultitablaBE.Codigo);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oMultitablaBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@longitud", oMultitablaBE.Longitud);
					da.SelectCommand.Parameters.AddWithValue("@detalle", oMultitablaBE.Detalle);
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

		public int actualizar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Multitabla_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idmultitabla", oMultitablaBE.IdMultitabla);
					da.SelectCommand.Parameters.AddWithValue("@codigo", oMultitablaBE.Codigo);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oMultitablaBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@longitud", oMultitablaBE.Longitud);
					da.SelectCommand.Parameters.AddWithValue("@detalle", oMultitablaBE.Detalle);
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

		public int eliminar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Multitabla_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idmultitabla", oMultitablaBE.IdMultitabla);
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
