using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class BloqueDA
	{
		public List<BloqueBE> listar()
		{
			List<BloqueBE> lstBloqueBE = new List<BloqueBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Bloque_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						BloqueBE oBloqueBE = new BloqueBE();
						oBloqueBE.IdBloque = String.IsNullOrEmpty(dr["IdBloque"].ToString()) ? 0 : Convert.ToInt32(dr["IdBloque"].ToString());
						oBloqueBE.IdSede = String.IsNullOrEmpty(dr["IdSede"].ToString()) ? 0 : Convert.ToInt32(dr["IdSede"].ToString());
						oBloqueBE.IdCurso = String.IsNullOrEmpty(dr["IdCurso"].ToString()) ? 0 : Convert.ToInt32(dr["IdCurso"].ToString());
						oBloqueBE.IdProfesor = String.IsNullOrEmpty(dr["IdProfesor"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesor"].ToString());
						oBloqueBE.IdAula = String.IsNullOrEmpty(dr["IdAula"].ToString()) ? 0 : Convert.ToInt32(dr["IdAula"].ToString());
						oBloqueBE.Turno = String.IsNullOrEmpty(dr["Turno"].ToString()) ? "" : dr["Turno"].ToString();
						oBloqueBE.FechaInicio = String.IsNullOrEmpty(dr["FechaInicio"].ToString()) ? "" : dr["FechaInicio"].ToString();
						oBloqueBE.FechaFin = String.IsNullOrEmpty(dr["FechaFin"].ToString()) ? "" : dr["FechaFin"].ToString();
						oBloqueBE.HoraInicio = String.IsNullOrEmpty(dr["HoraInicio"].ToString()) ? "" : dr["HoraInicio"].ToString();
						oBloqueBE.HoraFin = String.IsNullOrEmpty(dr["HoraFin"].ToString()) ? "" : dr["HoraFin"].ToString();
						oBloqueBE.CodigoCreacion = String.IsNullOrEmpty(dr["CodigoCreacion"].ToString()) ? "" : dr["CodigoCreacion"].ToString();
						oBloqueBE.CodigoConversion = String.IsNullOrEmpty(dr["CodigoConversion"].ToString()) ? "" : dr["CodigoConversion"].ToString();
						oBloqueBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstBloqueBE.Add(oBloqueBE);
					}
				}
				catch (Exception ex)
				{
					lstBloqueBE = null;
					throw ex;
				}
			}
			return lstBloqueBE;
		}

		public BloqueBE obtener(BloqueBE oBloqueBE)
		{
			BloqueBE objBloqueBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Bloque_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idbloque", oBloqueBE.IdBloque);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objBloqueBE = new BloqueBE();
							oBloqueBE.IdBloque = String.IsNullOrEmpty(dr["IdBloque"].ToString()) ? 0 : Convert.ToInt32(dr["IdBloque"].ToString());
							oBloqueBE.IdSede = String.IsNullOrEmpty(dr["IdSede"].ToString()) ? 0 : Convert.ToInt32(dr["IdSede"].ToString());
							oBloqueBE.IdCurso = String.IsNullOrEmpty(dr["IdCurso"].ToString()) ? 0 : Convert.ToInt32(dr["IdCurso"].ToString());
							oBloqueBE.IdProfesor = String.IsNullOrEmpty(dr["IdProfesor"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesor"].ToString());
							oBloqueBE.IdAula = String.IsNullOrEmpty(dr["IdAula"].ToString()) ? 0 : Convert.ToInt32(dr["IdAula"].ToString());
							oBloqueBE.Turno = String.IsNullOrEmpty(dr["Turno"].ToString()) ? "" : dr["Turno"].ToString();
							oBloqueBE.FechaInicio = String.IsNullOrEmpty(dr["FechaInicio"].ToString()) ? "" : dr["FechaInicio"].ToString();
							oBloqueBE.FechaFin = String.IsNullOrEmpty(dr["FechaFin"].ToString()) ? "" : dr["FechaFin"].ToString();
							oBloqueBE.HoraInicio = String.IsNullOrEmpty(dr["HoraInicio"].ToString()) ? "" : dr["HoraInicio"].ToString();
							oBloqueBE.HoraFin = String.IsNullOrEmpty(dr["HoraFin"].ToString()) ? "" : dr["HoraFin"].ToString();
							oBloqueBE.CodigoCreacion = String.IsNullOrEmpty(dr["CodigoCreacion"].ToString()) ? "" : dr["CodigoCreacion"].ToString();
							oBloqueBE.CodigoConversion = String.IsNullOrEmpty(dr["CodigoConversion"].ToString()) ? "" : dr["CodigoConversion"].ToString();
							oBloqueBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objBloqueBE = null;
					throw ex;
				}
				return objBloqueBE;
			}
		}

		public int insertar(BloqueBE oBloqueBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Bloque_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idsede", oBloqueBE.IdSede);
					da.SelectCommand.Parameters.AddWithValue("@idcurso", oBloqueBE.IdCurso);
					da.SelectCommand.Parameters.AddWithValue("@idprofesor", oBloqueBE.IdProfesor);
					da.SelectCommand.Parameters.AddWithValue("@idaula", oBloqueBE.IdAula);
					da.SelectCommand.Parameters.AddWithValue("@turno", oBloqueBE.Turno);
					da.SelectCommand.Parameters.AddWithValue("@fechainicio", oBloqueBE.FechaInicio);
					da.SelectCommand.Parameters.AddWithValue("@fechafin", oBloqueBE.FechaFin);
					da.SelectCommand.Parameters.AddWithValue("@horainicio", oBloqueBE.HoraInicio);
					da.SelectCommand.Parameters.AddWithValue("@horafin", oBloqueBE.HoraFin);
					da.SelectCommand.Parameters.AddWithValue("@codigocreacion", oBloqueBE.CodigoCreacion);
					da.SelectCommand.Parameters.AddWithValue("@codigoconversion", oBloqueBE.CodigoConversion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oBloqueBE.Estado);
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

		public int actualizar(BloqueBE oBloqueBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Bloque_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idbloque", oBloqueBE.IdBloque);
					da.SelectCommand.Parameters.AddWithValue("@idsede", oBloqueBE.IdSede);
					da.SelectCommand.Parameters.AddWithValue("@idcurso", oBloqueBE.IdCurso);
					da.SelectCommand.Parameters.AddWithValue("@idprofesor", oBloqueBE.IdProfesor);
					da.SelectCommand.Parameters.AddWithValue("@idaula", oBloqueBE.IdAula);
					da.SelectCommand.Parameters.AddWithValue("@turno", oBloqueBE.Turno);
					da.SelectCommand.Parameters.AddWithValue("@fechainicio", oBloqueBE.FechaInicio);
					da.SelectCommand.Parameters.AddWithValue("@fechafin", oBloqueBE.FechaFin);
					da.SelectCommand.Parameters.AddWithValue("@horainicio", oBloqueBE.HoraInicio);
					da.SelectCommand.Parameters.AddWithValue("@horafin", oBloqueBE.HoraFin);
					da.SelectCommand.Parameters.AddWithValue("@codigocreacion", oBloqueBE.CodigoCreacion);
					da.SelectCommand.Parameters.AddWithValue("@codigoconversion", oBloqueBE.CodigoConversion);
					da.SelectCommand.Parameters.AddWithValue("@estado", oBloqueBE.Estado);
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

		public int eliminar(BloqueBE oBloqueBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Bloque_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idbloque", oBloqueBE.IdBloque);
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
