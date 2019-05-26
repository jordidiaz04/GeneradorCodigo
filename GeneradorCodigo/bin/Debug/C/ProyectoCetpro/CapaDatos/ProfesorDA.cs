using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class ProfesorDA
	{
		public List<ProfesorBE> listar()
		{
			List<ProfesorBE> lstProfesorBE = new List<ProfesorBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesor_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						ProfesorBE oProfesorBE = new ProfesorBE();
						oProfesorBE.IdProfesor = String.IsNullOrEmpty(dr["IdProfesor"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesor"].ToString());
						oProfesorBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
						oProfesorBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
						oProfesorBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
						oProfesorBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
						oProfesorBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
						oProfesorBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
						oProfesorBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
						oProfesorBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
						oProfesorBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
						oProfesorBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
						oProfesorBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
						oProfesorBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
						oProfesorBE.IdProfesion = String.IsNullOrEmpty(dr["IdProfesion"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesion"].ToString());
						oProfesorBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
						oProfesorBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstProfesorBE.Add(oProfesorBE);
					}
				}
				catch (Exception ex)
				{
					lstProfesorBE = null;
					throw ex;
				}
			}
			return lstProfesorBE;
		}

		public ProfesorBE obtener(ProfesorBE oProfesorBE)
		{
			ProfesorBE objProfesorBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Profesor_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idprofesor", oProfesorBE.IdProfesor);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objProfesorBE = new ProfesorBE();
							oProfesorBE.IdProfesor = String.IsNullOrEmpty(dr["IdProfesor"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesor"].ToString());
							oProfesorBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
							oProfesorBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
							oProfesorBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
							oProfesorBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
							oProfesorBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
							oProfesorBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
							oProfesorBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
							oProfesorBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
							oProfesorBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
							oProfesorBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
							oProfesorBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
							oProfesorBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
							oProfesorBE.IdProfesion = String.IsNullOrEmpty(dr["IdProfesion"].ToString()) ? 0 : Convert.ToInt32(dr["IdProfesion"].ToString());
							oProfesorBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
							oProfesorBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objProfesorBE = null;
					throw ex;
				}
				return objProfesorBE;
			}
		}

		public int insertar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesor_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oProfesorBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oProfesorBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oProfesorBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oProfesorBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oProfesorBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oProfesorBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oProfesorBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oProfesorBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oProfesorBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oProfesorBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@email", oProfesorBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oProfesorBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@idprofesion", oProfesorBE.IdProfesion);
					da.SelectCommand.Parameters.AddWithValue("@clave", oProfesorBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@estado", oProfesorBE.Estado);
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

		public int actualizar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesor_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idprofesor", oProfesorBE.IdProfesor);
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oProfesorBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oProfesorBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oProfesorBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oProfesorBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oProfesorBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oProfesorBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oProfesorBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oProfesorBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oProfesorBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oProfesorBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@email", oProfesorBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oProfesorBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@idprofesion", oProfesorBE.IdProfesion);
					da.SelectCommand.Parameters.AddWithValue("@clave", oProfesorBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@estado", oProfesorBE.Estado);
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

		public int eliminar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Profesor_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idprofesor", oProfesorBE.IdProfesor);
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
