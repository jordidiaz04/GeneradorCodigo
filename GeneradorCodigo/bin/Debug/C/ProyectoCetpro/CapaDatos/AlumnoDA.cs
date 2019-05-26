using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class AlumnoDA
	{
		public List<AlumnoBE> listar()
		{
			List<AlumnoBE> lstAlumnoBE = new List<AlumnoBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Alumno_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						AlumnoBE oAlumnoBE = new AlumnoBE();
						oAlumnoBE.IdAlumno = String.IsNullOrEmpty(dr["IdAlumno"].ToString()) ? 0 : Convert.ToInt32(dr["IdAlumno"].ToString());
						oAlumnoBE.Codigo = String.IsNullOrEmpty(dr["Codigo"].ToString()) ? "" : dr["Codigo"].ToString();
						oAlumnoBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
						oAlumnoBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
						oAlumnoBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
						oAlumnoBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
						oAlumnoBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
						oAlumnoBE.IdCondicion = String.IsNullOrEmpty(dr["IdCondicion"].ToString()) ? "" : dr["IdCondicion"].ToString();
						oAlumnoBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
						oAlumnoBE.IdUbigeoNacimiento = String.IsNullOrEmpty(dr["IdUbigeoNacimiento"].ToString()) ? "" : dr["IdUbigeoNacimiento"].ToString();
						oAlumnoBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
						oAlumnoBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
						oAlumnoBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
						oAlumnoBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
						oAlumnoBE.GradoEstudio = String.IsNullOrEmpty(dr["GradoEstudio"].ToString()) ? "" : dr["GradoEstudio"].ToString();
						oAlumnoBE.EstadoGradoEstudio = String.IsNullOrEmpty(dr["EstadoGradoEstudio"].ToString()) ? "" : dr["EstadoGradoEstudio"].ToString();
						oAlumnoBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
						oAlumnoBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
						oAlumnoBE.Trabaja = String.IsNullOrEmpty(dr["Trabaja"].ToString()) ? false : Convert.ToBoolean(dr["Trabaja"].ToString());
						oAlumnoBE.Ocupacion = String.IsNullOrEmpty(dr["Ocupacion"].ToString()) ? "" : dr["Ocupacion"].ToString();
						oAlumnoBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
						oAlumnoBE.Imagen = String.IsNullOrEmpty(dr["Imagen"].ToString()) ? "" : dr["Imagen"].ToString();
						oAlumnoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstAlumnoBE.Add(oAlumnoBE);
					}
				}
				catch (Exception ex)
				{
					lstAlumnoBE = null;
					throw ex;
				}
			}
			return lstAlumnoBE;
		}

		public AlumnoBE obtener(AlumnoBE oAlumnoBE)
		{
			AlumnoBE objAlumnoBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Alumno_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idalumno", oAlumnoBE.IdAlumno);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objAlumnoBE = new AlumnoBE();
							oAlumnoBE.IdAlumno = String.IsNullOrEmpty(dr["IdAlumno"].ToString()) ? 0 : Convert.ToInt32(dr["IdAlumno"].ToString());
							oAlumnoBE.Codigo = String.IsNullOrEmpty(dr["Codigo"].ToString()) ? "" : dr["Codigo"].ToString();
							oAlumnoBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
							oAlumnoBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
							oAlumnoBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
							oAlumnoBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
							oAlumnoBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
							oAlumnoBE.IdCondicion = String.IsNullOrEmpty(dr["IdCondicion"].ToString()) ? "" : dr["IdCondicion"].ToString();
							oAlumnoBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
							oAlumnoBE.IdUbigeoNacimiento = String.IsNullOrEmpty(dr["IdUbigeoNacimiento"].ToString()) ? "" : dr["IdUbigeoNacimiento"].ToString();
							oAlumnoBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
							oAlumnoBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
							oAlumnoBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
							oAlumnoBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
							oAlumnoBE.GradoEstudio = String.IsNullOrEmpty(dr["GradoEstudio"].ToString()) ? "" : dr["GradoEstudio"].ToString();
							oAlumnoBE.EstadoGradoEstudio = String.IsNullOrEmpty(dr["EstadoGradoEstudio"].ToString()) ? "" : dr["EstadoGradoEstudio"].ToString();
							oAlumnoBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
							oAlumnoBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
							oAlumnoBE.Trabaja = String.IsNullOrEmpty(dr["Trabaja"].ToString()) ? false : Convert.ToBoolean(dr["Trabaja"].ToString());
							oAlumnoBE.Ocupacion = String.IsNullOrEmpty(dr["Ocupacion"].ToString()) ? "" : dr["Ocupacion"].ToString();
							oAlumnoBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
							oAlumnoBE.Imagen = String.IsNullOrEmpty(dr["Imagen"].ToString()) ? "" : dr["Imagen"].ToString();
							oAlumnoBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objAlumnoBE = null;
					throw ex;
				}
				return objAlumnoBE;
			}
		}

		public int insertar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Alumno_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@codigo", oAlumnoBE.Codigo);
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oAlumnoBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oAlumnoBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oAlumnoBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oAlumnoBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oAlumnoBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@idcondicion", oAlumnoBE.IdCondicion);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oAlumnoBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@idubigeonacimiento", oAlumnoBE.IdUbigeoNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oAlumnoBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oAlumnoBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oAlumnoBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oAlumnoBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@gradoestudio", oAlumnoBE.GradoEstudio);
					da.SelectCommand.Parameters.AddWithValue("@estadogradoestudio", oAlumnoBE.EstadoGradoEstudio);
					da.SelectCommand.Parameters.AddWithValue("@email", oAlumnoBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oAlumnoBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@trabaja", oAlumnoBE.Trabaja);
					da.SelectCommand.Parameters.AddWithValue("@ocupacion", oAlumnoBE.Ocupacion);
					da.SelectCommand.Parameters.AddWithValue("@clave", oAlumnoBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@imagen", oAlumnoBE.Imagen);
					da.SelectCommand.Parameters.AddWithValue("@estado", oAlumnoBE.Estado);
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

		public int actualizar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Alumno_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idalumno", oAlumnoBE.IdAlumno);
					da.SelectCommand.Parameters.AddWithValue("@codigo", oAlumnoBE.Codigo);
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oAlumnoBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oAlumnoBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oAlumnoBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oAlumnoBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oAlumnoBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@idcondicion", oAlumnoBE.IdCondicion);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oAlumnoBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@idubigeonacimiento", oAlumnoBE.IdUbigeoNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oAlumnoBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oAlumnoBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oAlumnoBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oAlumnoBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@gradoestudio", oAlumnoBE.GradoEstudio);
					da.SelectCommand.Parameters.AddWithValue("@estadogradoestudio", oAlumnoBE.EstadoGradoEstudio);
					da.SelectCommand.Parameters.AddWithValue("@email", oAlumnoBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oAlumnoBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@trabaja", oAlumnoBE.Trabaja);
					da.SelectCommand.Parameters.AddWithValue("@ocupacion", oAlumnoBE.Ocupacion);
					da.SelectCommand.Parameters.AddWithValue("@clave", oAlumnoBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@imagen", oAlumnoBE.Imagen);
					da.SelectCommand.Parameters.AddWithValue("@estado", oAlumnoBE.Estado);
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

		public int eliminar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Alumno_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idalumno", oAlumnoBE.IdAlumno);
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
