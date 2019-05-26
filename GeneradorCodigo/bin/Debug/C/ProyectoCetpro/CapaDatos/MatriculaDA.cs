using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class MatriculaDA
	{
		public List<MatriculaBE> listar()
		{
			List<MatriculaBE> lstMatriculaBE = new List<MatriculaBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Matricula_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						MatriculaBE oMatriculaBE = new MatriculaBE();
						oMatriculaBE.IdMatricula = String.IsNullOrEmpty(dr["IdMatricula"].ToString()) ? 0 : Convert.ToInt32(dr["IdMatricula"].ToString());
						oMatriculaBE.IdBloque = String.IsNullOrEmpty(dr["IdBloque"].ToString()) ? 0 : Convert.ToInt32(dr["IdBloque"].ToString());
						oMatriculaBE.IdAlumno = String.IsNullOrEmpty(dr["IdAlumno"].ToString()) ? 0 : Convert.ToInt32(dr["IdAlumno"].ToString());
						oMatriculaBE.IdPersonal = String.IsNullOrEmpty(dr["IdPersonal"].ToString()) ? 0 : Convert.ToInt32(dr["IdPersonal"].ToString());
						oMatriculaBE.Fecha = String.IsNullOrEmpty(dr["Fecha"].ToString()) ? "" : dr["Fecha"].ToString();
						lstMatriculaBE.Add(oMatriculaBE);
					}
				}
				catch (Exception ex)
				{
					lstMatriculaBE = null;
					throw ex;
				}
			}
			return lstMatriculaBE;
		}

		public MatriculaBE obtener(MatriculaBE oMatriculaBE)
		{
			MatriculaBE objMatriculaBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Matricula_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idmatricula", oMatriculaBE.IdMatricula);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objMatriculaBE = new MatriculaBE();
							oMatriculaBE.IdMatricula = String.IsNullOrEmpty(dr["IdMatricula"].ToString()) ? 0 : Convert.ToInt32(dr["IdMatricula"].ToString());
							oMatriculaBE.IdBloque = String.IsNullOrEmpty(dr["IdBloque"].ToString()) ? 0 : Convert.ToInt32(dr["IdBloque"].ToString());
							oMatriculaBE.IdAlumno = String.IsNullOrEmpty(dr["IdAlumno"].ToString()) ? 0 : Convert.ToInt32(dr["IdAlumno"].ToString());
							oMatriculaBE.IdPersonal = String.IsNullOrEmpty(dr["IdPersonal"].ToString()) ? 0 : Convert.ToInt32(dr["IdPersonal"].ToString());
							oMatriculaBE.Fecha = String.IsNullOrEmpty(dr["Fecha"].ToString()) ? "" : dr["Fecha"].ToString();
						}
				}
				catch (Exception ex)
				{
					objMatriculaBE = null;
					throw ex;
				}
				return objMatriculaBE;
			}
		}

		public int insertar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Matricula_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idbloque", oMatriculaBE.IdBloque);
					da.SelectCommand.Parameters.AddWithValue("@idalumno", oMatriculaBE.IdAlumno);
					da.SelectCommand.Parameters.AddWithValue("@idpersonal", oMatriculaBE.IdPersonal);
					da.SelectCommand.Parameters.AddWithValue("@fecha", oMatriculaBE.Fecha);
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

		public int actualizar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Matricula_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idmatricula", oMatriculaBE.IdMatricula);
					da.SelectCommand.Parameters.AddWithValue("@idbloque", oMatriculaBE.IdBloque);
					da.SelectCommand.Parameters.AddWithValue("@idalumno", oMatriculaBE.IdAlumno);
					da.SelectCommand.Parameters.AddWithValue("@idpersonal", oMatriculaBE.IdPersonal);
					da.SelectCommand.Parameters.AddWithValue("@fecha", oMatriculaBE.Fecha);
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

		public int eliminar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Matricula_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idmatricula", oMatriculaBE.IdMatricula);
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
