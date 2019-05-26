using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
	public class PersonalDA
	{
		public List<PersonalBE> listar()
		{
			List<PersonalBE> lstPersonalBE = new List<PersonalBE>();
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Personal_Listar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = da.SelectCommand.ExecuteReader();
					while (dr.Read())
					{
						PersonalBE oPersonalBE = new PersonalBE();
						oPersonalBE.IdPersonal = String.IsNullOrEmpty(dr["IdPersonal"].ToString()) ? 0 : Convert.ToInt32(dr["IdPersonal"].ToString());
						oPersonalBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
						oPersonalBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
						oPersonalBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
						oPersonalBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
						oPersonalBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
						oPersonalBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
						oPersonalBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
						oPersonalBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
						oPersonalBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
						oPersonalBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
						oPersonalBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
						oPersonalBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
						oPersonalBE.IdCargo = String.IsNullOrEmpty(dr["IdCargo"].ToString()) ? 0 : Convert.ToInt32(dr["IdCargo"].ToString());
						oPersonalBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
						oPersonalBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						lstPersonalBE.Add(oPersonalBE);
					}
				}
				catch (Exception ex)
				{
					lstPersonalBE = null;
					throw ex;
				}
			}
			return lstPersonalBE;
		}

		public PersonalBE obtener(PersonalBE oPersonalBE)
		{
			PersonalBE objPersonalBE = null;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
						cn.Open();
						SqlDataAdapter da = new SqlDataAdapter("Sp_Personal_Obtener", cn);
						da.SelectCommand.CommandType = CommandType.StoredProcedure;
						da.SelectCommand.Parameters.AddWithValue("@idpersonal", oPersonalBE.IdPersonal);
						SqlDataReader dr = da.SelectCommand.ExecuteReader();
						while (dr.Read())
						{
							objPersonalBE = new PersonalBE();
							oPersonalBE.IdPersonal = String.IsNullOrEmpty(dr["IdPersonal"].ToString()) ? 0 : Convert.ToInt32(dr["IdPersonal"].ToString());
							oPersonalBE.TipoDocIdentidad = String.IsNullOrEmpty(dr["TipoDocIdentidad"].ToString()) ? "" : dr["TipoDocIdentidad"].ToString();
							oPersonalBE.DocIdentidad = String.IsNullOrEmpty(dr["DocIdentidad"].ToString()) ? "" : dr["DocIdentidad"].ToString();
							oPersonalBE.Nombres = String.IsNullOrEmpty(dr["Nombres"].ToString()) ? "" : dr["Nombres"].ToString();
							oPersonalBE.ApellidoPaterno = String.IsNullOrEmpty(dr["ApellidoPaterno"].ToString()) ? "" : dr["ApellidoPaterno"].ToString();
							oPersonalBE.ApellidoMaterno = String.IsNullOrEmpty(dr["ApellidoMaterno"].ToString()) ? "" : dr["ApellidoMaterno"].ToString();
							oPersonalBE.Sexo = String.IsNullOrEmpty(dr["Sexo"].ToString()) ? "" : dr["Sexo"].ToString();
							oPersonalBE.FechaNacimiento = String.IsNullOrEmpty(dr["FechaNacimiento"].ToString()) ? "" : dr["FechaNacimiento"].ToString();
							oPersonalBE.IdUbigeo = String.IsNullOrEmpty(dr["IdUbigeo"].ToString()) ? "" : dr["IdUbigeo"].ToString();
							oPersonalBE.Domicilio = String.IsNullOrEmpty(dr["Domicilio"].ToString()) ? "" : dr["Domicilio"].ToString();
							oPersonalBE.EstadoCivil = String.IsNullOrEmpty(dr["EstadoCivil"].ToString()) ? "" : dr["EstadoCivil"].ToString();
							oPersonalBE.Email = String.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
							oPersonalBE.Telefono = String.IsNullOrEmpty(dr["Telefono"].ToString()) ? "" : dr["Telefono"].ToString();
							oPersonalBE.IdCargo = String.IsNullOrEmpty(dr["IdCargo"].ToString()) ? 0 : Convert.ToInt32(dr["IdCargo"].ToString());
							oPersonalBE.Clave = String.IsNullOrEmpty(dr["Clave"].ToString()) ? "" : dr["Clave"].ToString();
							oPersonalBE.Estado = String.IsNullOrEmpty(dr["Estado"].ToString()) ? false : Convert.ToBoolean(dr["Estado"].ToString());
						}
				}
				catch (Exception ex)
				{
					objPersonalBE = null;
					throw ex;
				}
				return objPersonalBE;
			}
		}

		public int insertar(PersonalBE oPersonalBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Personal_Insertar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oPersonalBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oPersonalBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oPersonalBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oPersonalBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oPersonalBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oPersonalBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oPersonalBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oPersonalBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oPersonalBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oPersonalBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@email", oPersonalBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oPersonalBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@idcargo", oPersonalBE.IdCargo);
					da.SelectCommand.Parameters.AddWithValue("@clave", oPersonalBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@estado", oPersonalBE.Estado);
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

		public int actualizar(PersonalBE oPersonalBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Personal_Actualizar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idpersonal", oPersonalBE.IdPersonal);
					da.SelectCommand.Parameters.AddWithValue("@tipodocidentidad", oPersonalBE.TipoDocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@docidentidad", oPersonalBE.DocIdentidad);
					da.SelectCommand.Parameters.AddWithValue("@nombres", oPersonalBE.Nombres);
					da.SelectCommand.Parameters.AddWithValue("@apellidopaterno", oPersonalBE.ApellidoPaterno);
					da.SelectCommand.Parameters.AddWithValue("@apellidomaterno", oPersonalBE.ApellidoMaterno);
					da.SelectCommand.Parameters.AddWithValue("@sexo", oPersonalBE.Sexo);
					da.SelectCommand.Parameters.AddWithValue("@fechanacimiento", oPersonalBE.FechaNacimiento);
					da.SelectCommand.Parameters.AddWithValue("@idubigeo", oPersonalBE.IdUbigeo);
					da.SelectCommand.Parameters.AddWithValue("@domicilio", oPersonalBE.Domicilio);
					da.SelectCommand.Parameters.AddWithValue("@estadocivil", oPersonalBE.EstadoCivil);
					da.SelectCommand.Parameters.AddWithValue("@email", oPersonalBE.Email);
					da.SelectCommand.Parameters.AddWithValue("@telefono", oPersonalBE.Telefono);
					da.SelectCommand.Parameters.AddWithValue("@idcargo", oPersonalBE.IdCargo);
					da.SelectCommand.Parameters.AddWithValue("@clave", oPersonalBE.Clave);
					da.SelectCommand.Parameters.AddWithValue("@estado", oPersonalBE.Estado);
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

		public int eliminar(PersonalBE oPersonalBE)
		{
			int result = 0;
			using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))
			{
				try
				{
					cn.Open();
					SqlDataAdapter da = new SqlDataAdapter("Sp_Personal_Eliminar", cn);
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.Parameters.AddWithValue("@idpersonal", oPersonalBE.IdPersonal);
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
