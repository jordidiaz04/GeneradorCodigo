using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class CursoDA
	{
		public List<CursoBE> listar()
		{
			List<CursoBE> lstCursoBE = new List<CursoBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Curso_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						CursoBE oCursoBE = new CursoBE();
						oCursoBE.IdCurso = String.IsNullOrEmpty(dr["IdCurso"].ToString()) ? 0 : Convert.ToInt32(dr["IdCurso"].ToString());
						oCursoBE.IdCarrera = String.IsNullOrEmpty(dr["IdCarrera"].ToString()) ? 0 : Convert.ToInt32(dr["IdCarrera"].ToString());
						oCursoBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
						oCursoBE.Horas = String.IsNullOrEmpty(dr["Horas"].ToString()) ? "" : dr["Horas"].ToString();
						oCursoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstCursoBE.Add(oCursoBE);
					}
				}
				catch (Exception ex)
				{
					lstCursoBE = null;
					throw ex;
				}
			}
			return lstCursoBE;
		}

		public CursoBE obtener(CursoBE oCursoBE)
		{
			CursoBE objCursoBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Curso_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idcurso", oCursoBE.IdCurso);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objCursoBE = new CursoBE();
							oCursoBE.IdCurso = String.IsNullOrEmpty(dr["IdCurso"].ToString()) ? 0 : Convert.ToInt32(dr["IdCurso"].ToString());
							oCursoBE.IdCarrera = String.IsNullOrEmpty(dr["IdCarrera"].ToString()) ? 0 : Convert.ToInt32(dr["IdCarrera"].ToString());
							oCursoBE.Descripcion = String.IsNullOrEmpty(dr["Descripcion"].ToString()) ? "" : dr["Descripcion"].ToString();
							oCursoBE.Horas = String.IsNullOrEmpty(dr["Horas"].ToString()) ? "" : dr["Horas"].ToString();
							oCursoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objCursoBE = null;
					throw ex;
				}
				return objCursoBE;
			}
		}

		public int insertar(CursoBE oCursoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Curso_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcarrera", oCursoBE.IdCarrera);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCursoBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@horas", oCursoBE.Horas);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCursoBE.Estado);
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

		public int actualizar(CursoBE oCursoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Curso_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcurso", oCursoBE.IdCurso);
					da.SelectCommand.Parameters.AddWithValue("@idcarrera", oCursoBE.IdCarrera);
					da.SelectCommand.Parameters.AddWithValue("@descripcion", oCursoBE.Descripcion);
					da.SelectCommand.Parameters.AddWithValue("@horas", oCursoBE.Horas);
					da.SelectCommand.Parameters.AddWithValue("@estado", oCursoBE.Estado);
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

		public int eliminar(CursoBE oCursoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Curso_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idcurso", oCursoBE.IdCurso);
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
