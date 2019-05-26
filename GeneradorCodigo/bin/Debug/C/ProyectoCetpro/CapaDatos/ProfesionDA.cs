using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class ProfesionDA
	{
		public List<ProfesionBE> listar()
		{
			List<ProfesionBE> lstProfesionBE = new List<ProfesionBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesion_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						ProfesionBE oProfesionBE = new ProfesionBE();
						oProfesionBE.IdProfesion = String.IsNullOrEmpty(dr["IdProfesion"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesion"].ToString());
						oProfesionBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
						oProfesionBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstProfesionBE.Add(oProfesionBE);
					}
				}
				catch (Exception ex)
				{
					lstProfesionBE = null;
					throw ex;
				}
			}
			return lstProfesionBE;
		}

		public ProfesionBE obtener(ProfesionBE oProfesionBE)
		{
			ProfesionBE objProfesionBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Profesion_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idprofesion", oProfesionBE.IdProfesion);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objProfesionBE = new ProfesionBE();
							oProfesionBE.IdProfesion = String.IsNullOrEmpty(dr["IdProfesion"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesion"].ToString());
							oProfesionBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
							oProfesionBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objProfesionBE = null;
					throw ex;
				}
				return objProfesionBE;
			}
		}

		public int insertar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesion_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oProfesionBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oProfesionBE.Estado);
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

		public int actualizar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesion_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idprofesion", oProfesionBE.IdProfesion);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oProfesionBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oProfesionBE.Estado);
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

		public int eliminar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesion_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idprofesion", oProfesionBE.IdProfesion);
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
