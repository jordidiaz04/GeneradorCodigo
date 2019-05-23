using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace GeneradorCodigo
{
    public partial class Form1 : Form
    {
        string lenguaje = String.Empty;
        string motordb = String.Empty;
        string ip = String.Empty;
        string user = String.Empty;
        string pass = String.Empty;
        string db = String.Empty;

        SqlConnection cn = null;
        SqlDataAdapter da = null;
        SqlDataReader dr = null;
        MySqlConnection cnMySql = null;
        MySqlDataAdapter daMySql = null;
        MySqlDataReader drMySql = null;

        List<BaseDatos> lstBaseDatos = new List<BaseDatos>();
        List<Tabla> lstTabla = new List<Tabla>();
        List<Columna> lstColumna = new List<Columna>();

        public Form1()
        {
            InitializeComponent();
        }

        private List<BaseDatos> listarBaseDatos()
        {
            lstBaseDatos.Clear();
            BaseDatos primerItem = new BaseDatos();
            primerItem.nombre = "Seleccione";
            lstBaseDatos.Add(primerItem);

            if (motordb == "sqlserver")
            {
                using (cn = new SqlConnection("server=" + ip + ";database=master;user=" + user + ";password=" + pass + ";"))
                {
                    try
                    {
                        cn.Open();
                        da = new SqlDataAdapter("SELECT name FROM sys.databases WHERE name NOT IN ('master','tempdb','model','msdb') ORDER BY name", cn);
                        dr = da.SelectCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            BaseDatos oBaseDatos = new BaseDatos();
                            oBaseDatos.nombre = dr["name"].ToString();
                            lstBaseDatos.Add(oBaseDatos);
                        }

                        cmbBaseDatos.Enabled = true;
                        groupBox2.Enabled = true;
                        MessageBox.Show("Conectado al servidor SQL.", "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();
                        da = null;
                        dr = null;
                    }
                }
            }
            else
            {
                using (cnMySql = new MySqlConnection("server=" + ip + ";uid=" + user + ";pwd=" + pass + ";"))
                {
                    try
                    {
                        cnMySql.Open();
                        daMySql = new MySqlDataAdapter("SHOW DATABASES", cnMySql);
                        drMySql = daMySql.SelectCommand.ExecuteReader();
                        while (drMySql.Read())
                        {
                            BaseDatos oBaseDatos = new BaseDatos();
                            oBaseDatos.nombre = drMySql["Database"].ToString();
                            lstBaseDatos.Add(oBaseDatos);
                        }

                        cmbBaseDatos.Enabled = true;
                        groupBox2.Enabled = true;
                        MessageBox.Show("Conectado al servidor MySQL.", "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnMySql.Close();
                        daMySql = null;
                        drMySql = null;
                    }
                }
            }

            return lstBaseDatos;
        }

        private List<Tabla> listarTablas()
        {
            lstTabla.Clear();

            if (motordb == "sqlserver")
            {
                using (cn = new SqlConnection("server=" + ip + ";database=" + db + ";user=" + user + ";password=" + pass + ";"))
                {
                    try
                    {
                        cn.Open();
                        da = new SqlDataAdapter("SELECT table_name FROM information_schema.tables ORDER BY table_name", cn);
                        dr = da.SelectCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            Tabla oTabla = new Tabla();
                            oTabla.nombre = dr["table_name"].ToString();
                            lstTabla.Add(oTabla);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();
                        da = null;
                        dr = null;
                    }
                }
            }
            else
            {
                using (cnMySql = new MySqlConnection("server=" + ip + ";database=" + db + ";uid=" + user + ";pwd=" + pass + ";"))
                {
                    try
                    {
                        cnMySql.Open();
                        daMySql = new MySqlDataAdapter("SHOW TABLES", cnMySql);
                        drMySql = daMySql.SelectCommand.ExecuteReader();
                        while (drMySql.Read())
                        {
                            Tabla oTabla = new Tabla();
                            oTabla.nombre = drMySql["Tables_in_" + db].ToString();
                            lstTabla.Add(oTabla);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnMySql.Close();
                        daMySql = null;
                        drMySql = null;
                    }
                }
            }

            return lstTabla;
        }

        private List<Columna> listarColumnas(string tabla)
        {
            lstColumna.Clear();

            if (motordb == "sqlserver")
            {
                using (cn = new SqlConnection("server=" + ip + ";database=" + db + ";user=" + user + ";password=" + pass + ";"))
                {
                    try
                    {
                        cn.Open();
                        da = new SqlDataAdapter("SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tabla + "' ORDER BY ORDINAL_POSITION", cn);
                        dr = da.SelectCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            Columna oColumna = new Columna();
                            oColumna.nombre = dr["COLUMN_NAME"].ToString();
                            oColumna.tipo = dr["DATA_TYPE"].ToString();
                            oColumna.tamaño = String.IsNullOrEmpty(dr["CHARACTER_MAXIMUM_LENGTH"].ToString()) ? "" : dr["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            lstColumna.Add(oColumna);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();
                        da = null;
                        dr = null;
                    }
                }
            }
            else
            {
                using (cnMySql = new MySqlConnection("server=" + ip + ";database=" + db + ";uid=" + user + ";pwd=" + pass + ";"))
                {
                    try
                    {
                        cnMySql.Open();
                        daMySql = new MySqlDataAdapter("SHOW COLUMNS FROM " + tabla, cnMySql);
                        drMySql = daMySql.SelectCommand.ExecuteReader();
                        while (drMySql.Read())
                        {
                            Columna oColumna = new Columna();
                            oColumna.nombre = drMySql["Field"].ToString();
                            oColumna.tipo = !drMySql["Type"].ToString().Contains("(") ? drMySql["Type"].ToString() : drMySql["Type"].ToString().Substring(0, drMySql["Type"].ToString().IndexOf("("));
                            oColumna.tamaño = !drMySql["Type"].ToString().Contains("(") ? "" : drMySql["Type"].ToString().Substring(drMySql["Type"].ToString().IndexOf("(") + 1, (drMySql["Type"].ToString().IndexOf(")") - drMySql["Type"].ToString().IndexOf("(")) - 1);
                            lstColumna.Add(oColumna);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cnMySql.Close();
                        daMySql = null;
                        drMySql = null;
                    }
                }
            }

            return lstColumna;
        }

        private string convertirTipoDato(string tipo)
        {
            string result = "string";
            switch (tipo)
            {
                case "varchar":
                case "char":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                case "date":
                case "datetime":
                    result = "String";
                    break;
                case "int":
                case "bigint":
                case "smallint":
                case "tinyint":
                    result = "int";
                    break;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                case "float":
                case "real":
                    result = rbAndroid.Checked || rbJava.Checked ? "double" : "decimal";
                    break;
                case "bit":
                    result = "Boolean";
                    break;
            }

            return result;
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            chbDatos.Checked = true;

            if (rbPHP.Checked)
            {
                chbEntidad.Checked = false;
                chbNegocio.Checked = false;
            }
            else if (rbC.Checked)
            {
                chbEntidad.Checked = true;
                chbNegocio.Checked = true;
            }
            else
            {
                chbEntidad.Checked = true;
                chbNegocio.Checked = false;
            }
        }

        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSQL.Checked)
            {
                txtIp.Text = ".";
                txtUsuario.Text = "sa";
                txtContraseña.Text = "sql";
            }
            else
            {
                txtIp.Text = "localhost";
                txtUsuario.Text = "root";
                txtContraseña.Text = "";
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            cmbBaseDatos.DataSource = null;
            dgvTablas.DataSource = null;
            cmbBaseDatos.Enabled = false;

            lenguaje = rbC.Checked ? "c" : rbPHP.Checked ? "php" : rbJava.Checked ? "java" : "android";
            motordb = rbSQL.Checked ? "sqlserver" : "mysql";
            ip = txtIp.Text.Trim();
            user = txtUsuario.Text.Trim();
            pass = txtContraseña.Text.Trim();

            cmbBaseDatos.DataSource = listarBaseDatos();
            cmbBaseDatos.DisplayMember = "nombre";
            cmbBaseDatos.ValueMember = "nombre";
        }

        private void cmbBaseDatos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBaseDatos.SelectedValue.ToString() != "Seleccione")
            {
                db = cmbBaseDatos.SelectedValue.ToString();
                dgvTablas.DataSource = null;
                dgvTablas.DataSource = listarTablas();
            }
            else
                dgvTablas.DataSource = null;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                dgvTablas.Rows[fila].Cells[0].Value = true;
            }
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                dgvTablas.Rows[fila].Cells[0].Value = false;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int contadorFilas = 0;
            string rutaProyecto = Path.GetDirectoryName(Application.ExecutablePath);
            rutaProyecto += lenguaje == "c" ? @"\C" : lenguaje == "php" ? @"\PHP" : lenguaje == "java" ? @"\Java" : @"\Android";
            string rutaSolucion = rutaProyecto + @"\" + txtSolucion.Text.Trim();
            string rutaCapaEntidad = rutaProyecto + @"\" + txtSolucion.Text.Trim() + @"\" + txtCapaEntidad.Text.Trim();
            string rutaCapaDatos = rutaProyecto + @"\" + txtSolucion.Text.Trim() + @"\" + txtCapaDatos.Text.Trim();
            string rutaCapaNegocio = rutaProyecto + @"\" + txtSolucion.Text.Trim() + @"\" + txtCapaNegocio.Text.Trim();

            try
            {
                for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
                    if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                        contadorFilas++;

                if (contadorFilas > 0)
                {
                    if (!Directory.Exists(rutaSolucion)) Directory.CreateDirectory(rutaSolucion);

                    if (chbEntidad.Checked)
                    {
                        if (!Directory.Exists(rutaCapaEntidad)) Directory.CreateDirectory(rutaCapaEntidad);

                        if (lenguaje == "c")
                        {
                            generarArchivoEntidad(rutaCapaEntidad, txtCapaEntidad.Text.Trim());
                        }
                        else if (lenguaje == "java" || lenguaje == "android")
                        {
                            if (motordb == "sqlserver")
                                generarArchivoEntidadJava(rutaCapaEntidad, txtSolucion.Text.Trim(), txtCapaEntidad.Text.Trim());
                        }
                    }

                    if (chbDatos.Checked)
                    {
                        if (!Directory.Exists(rutaCapaDatos)) Directory.CreateDirectory(rutaCapaDatos);

                        if (lenguaje == "c")
                        {
                            generarArchivoConexion(rutaCapaDatos, txtCapaDatos.Text.Trim(), cmbBaseDatos.SelectedValue.ToString());
                            generarProcedimientosAlmacenados(rutaProyecto, txtSolucion.Text.Trim(), cmbBaseDatos.SelectedValue.ToString());

                            if (motordb == "sqlserver")
                                generarArchivoDatos(rutaCapaDatos, txtCapaDatos.Text.Trim(), txtCapaEntidad.Text.Trim());
                            else
                                generarArchivoDatosCMySQL(rutaCapaDatos, txtCapaDatos.Text.Trim(), txtCapaEntidad.Text.Trim());
                        }
                        else if (lenguaje == "php")
                        {
                            if (motordb != "sqlserver")
                            {
                                generarArchivoConexionPHP(rutaCapaDatos, txtCapaDatos.Text.Trim(), cmbBaseDatos.SelectedValue.ToString());
                                generarArchivoDatosPHP(rutaCapaDatos);
                            }
                        }
                        else if (lenguaje == "java")
                        {
                            if (motordb == "sqlserver")
                            {
                                generarArchivoConexionJava(rutaCapaDatos, txtSolucion.Text.Trim(), txtCapaDatos.Text.Trim(), txtIp.Text.Trim(), cmbBaseDatos.SelectedValue.ToString(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                                generarArchivoDatosJava(rutaCapaDatos, txtSolucion.Text.Trim(), txtCapaDatos.Text.Trim(), txtCapaEntidad.Text.Trim());
                                generarProcedimientosAlmacenados(rutaProyecto, txtSolucion.Text.Trim(), cmbBaseDatos.SelectedValue.ToString());
                            }
                            else
                            {
                                
                            }
                        }
                        else if (lenguaje == "android")
                        {
                            if (motordb == "sqlserver")
                            {
                                generarArchivoConexionAndroid(rutaCapaDatos, txtSolucion.Text.Trim(), txtCapaDatos.Text.Trim(), txtIp.Text.Trim(), cmbBaseDatos.SelectedValue.ToString(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                                generarArchivoInterfaceAndroid(rutaCapaDatos, txtSolucion.Text.Trim(), txtCapaDatos.Text.Trim(), txtIp.Text.Trim(), cmbBaseDatos.SelectedValue.ToString(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                                generarArchivoDatosAndroid(rutaCapaDatos, txtSolucion.Text.Trim(), txtCapaDatos.Text.Trim(), txtCapaEntidad.Text.Trim());
                            }
                            else
                            {

                            }
                        }
                    }

                    if (chbNegocio.Checked)
                    {
                        if (!Directory.Exists(rutaCapaNegocio)) Directory.CreateDirectory(rutaCapaNegocio);

                        if (lenguaje == "c")
                        {
                            generarArchivoNegocio(rutaCapaNegocio, txtCapaNegocio.Text.Trim(), txtCapaEntidad.Text.Trim(), txtCapaDatos.Text.Trim());

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (contadorFilas == 0)
                MessageBox.Show("Debe seleccionar al menos una tabla de la base de datos.", "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (rbPHP.Checked && rbSQL.Checked)
                    MessageBox.Show("No se puede generar archivos PHP con SQL.", "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Código generado correctamente", "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region SQL Server
        #region Generador de código C#
        private void generarArchivoConexion(string rutaCarpeta, string capaDatos, string BaseDatos)
        {
            string rutaArchivo = rutaCarpeta + @"\Conexion.cs";

            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

            using (StreamWriter sw = File.CreateText(rutaArchivo))
            {
                string cadena = "";
                cadena += "using System.Configuration;" + "\n";
                cadena += "\n";
                cadena += "namespace " + capaDatos + "\n";
                cadena += "{" + "\n";
                cadena += "\t" + "public class Conexion" + "\n";
                cadena += "\t" + "{" + "\n";
                cadena += "\t\t" + "public string getConnectionString()" + "\n";
                cadena += "\t\t" + "{" + "\n";
                cadena += "\t\t\t" + "string strConexion = ConfigurationManager.ConnectionStrings[\"" + BaseDatos + "\"].ConnectionString;" + "\n";
                cadena += "\t\t\t" + "if (object.ReferenceEquals(strConexion, string.Empty)) return string.Empty;" + "\n";
                cadena += "\t\t\t" + "else return strConexion;" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "}" + "\n";

                sw.Write(cadena);
            }
        }

        private void generarArchivoEntidad(string rutaCarpeta, string capa)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "BE";
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".cs";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "namespace " + capa + "\n";
                        cadena += "{" + "\n";
                        cadena += "\t" + "public class " + clase + "\n";
                        cadena += "\t" + "{" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                            cadena += "\t\t" + "public " + convertirTipoDato(lstColumna[i].tipo) + " " + lstColumna[i].nombre + " { get; set; }" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }

        private void generarArchivoDatos(string rutaCarpeta, string capa, string capaEntidad)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "DA";
                    string claseEntidad = tabla + "BE";
                    string objeto = "o" + claseEntidad;
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".cs";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "using System;" + "\n";
                        cadena += "using System.Collections.Generic;" + "\n";
                        cadena += "using System.Data;" + "\n";
                        cadena += "using System.Data.SqlClient;" + "\n";
                        cadena += "using " + capaEntidad + ";" + "\n";
                        cadena += "\n";
                        cadena += "namespace " + capa + "\n";
                        cadena += "{" + "\n";
                        cadena += "\t" + "public class " + clase + "\n";
                        cadena += "\t" + "{" + "\n";
                        //Función listar
                        cadena += "\t\t" + "public List<" + claseEntidad + "> listar()" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "List<" + claseEntidad + "> lst" + claseEntidad + " = new List<" + claseEntidad + ">();" + "\n";
                        cadena += "\t\t\t" + "using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "SqlDataAdapter da = new SqlDataAdapter(\"Sp_" + tabla + "_Listar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t" + "SqlDataReader dr = da.SelectCommand.ExecuteReader();" + "\n";
                        cadena += "\t\t\t\t\t" + "while (dr.Read())" + "\n";
                        cadena += "\t\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t" + claseEntidad + " " + objeto + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t\t" + objeto + "." + lstColumna[i].nombre + " = String.IsNullOrEmpty(dr[\"" + lstColumna[i].nombre + "\"].ToString()) ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : dr[\"" + lstColumna[i].nombre + "\"].ToString();";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : Convert.ToInt32(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "decimal")
                                cadena += "0 : Convert.ToDecimal(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else
                                cadena += "false : Convert.ToBoolean(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t\t\t\t" + "lst" + claseEntidad + ".Add(" + objeto + ");" + "\n";
                        cadena += "\t\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "lst" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "return lst" + claseEntidad + ";" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función obtener
                        cadena += "\t\t" + "public " + claseEntidad + " obtener(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + claseEntidad + " obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t" + "using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t\t" + "SqlDataAdapter da = new SqlDataAdapter(\"Sp_" + tabla + "_Obtener\", cn);" + "\n";
                        cadena += "\t\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[0].nombre.ToLower() + "\", " + objeto + "." + lstColumna[0].nombre + ");" + "\n";
                        cadena += "\t\t\t\t\t\t" + "SqlDataReader dr = da.SelectCommand.ExecuteReader();" + "\n";
                        cadena += "\t\t\t\t\t\t" + "while (dr.Read())" + "\n";
                        cadena += "\t\t\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t\t" + "obj" + claseEntidad + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t\t" + objeto + "." + lstColumna[i].nombre + " = String.IsNullOrEmpty(dr[\"" + lstColumna[i].nombre + "\"].ToString()) ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : dr[\"" + lstColumna[i].nombre + "\"].ToString();";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : Convert.ToInt32(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "decimal")
                                cadena += "0 : Convert.ToDecimal(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else
                                cadena += "false : Convert.ToBoolean(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return obj" + claseEntidad + ";" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función insertar
                        cadena += "\t\t" + "public int insertar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "SqlDataAdapter da = new SqlDataAdapter(\"Sp_" + tabla + "_Insertar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[i].nombre.ToLower() + "\", " + objeto + "." + lstColumna[i].nombre + ");" + "\n";
                        }
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función actualizar
                        cadena += "\t\t" + "public int actualizar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "SqlDataAdapter da = new SqlDataAdapter(\"Sp_" + tabla + "_Actualizar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[i].nombre.ToLower() + "\", " + objeto + "." + lstColumna[i].nombre + ");" + "\n";
                        }
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función eliminar
                        cadena += "\t\t" + "public int eliminar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (SqlConnection cn = new SqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "SqlDataAdapter da = new SqlDataAdapter(\"Sp_" + tabla + "_Eliminar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[0].nombre.ToLower() + "\", " + objeto + "." + lstColumna[0].nombre + ");" + "\n";
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }

        private void generarArchivoNegocio(string rutaCarpeta, string capa, string capaEntidad, string capaDatos)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "BL";
                    string claseEntidad = tabla + "BE";
                    string claseDatos = tabla + "DA";
                    string objeto = "o" + claseEntidad;
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".cs";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "using System;" + "\n";
                        cadena += "using System.Collections.Generic;" + "\n";
                        cadena += "using System.Data;" + "\n";
                        cadena += "using System.Transactions;" + "\n";
                        cadena += "using " + capaDatos + "\n";
                        cadena += "using " + capaEntidad + "\n";
                        cadena += "\n";
                        cadena += "namespace " + capa + "\n";
                        cadena += "{" + "\n";
                        cadena += "\t" + "public class " + clase + "\n";
                        cadena += "\t" + "{" + "\n";
                        //Funcion listar
                        cadena += "\t\t" + "public List<" + claseEntidad + "> listar()" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "return new " + claseDatos + "().listar();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion obtener
                        cadena += "\t\t" + "public " + claseEntidad + " obtener(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "return new " + claseDatos + "().obtener(" + objeto + ");" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion insertar
                        cadena += "\t\t" + "public int insertar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "var option = new TransactionOptions" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted," + "\n";
                        cadena += "\t\t\t\t" + "Timeout = TimeSpan.FromSeconds(60)," + "\n";
                        cadena += "\t\t\t" + "};" + "\n";
                        cadena += "\t\t\t" + "using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "result = new " + claseDatos + "().insertar(" + objeto + ");" + "\n";
                        cadena += "\t\t\t\t" + "if(result != 0) transactionScope.Complete();" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion actualizar
                        cadena += "\t\t" + "public int actualizar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "var option = new TransactionOptions" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted," + "\n";
                        cadena += "\t\t\t\t" + "Timeout = TimeSpan.FromSeconds(60)," + "\n";
                        cadena += "\t\t\t" + "};" + "\n";
                        cadena += "\t\t\t" + "using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "result = new " + claseDatos + "().actualizar(" + objeto + ");" + "\n";
                        cadena += "\t\t\t\t" + "if(result != 0) transactionScope.Complete();" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion eliminar
                        cadena += "\t\t" + "public int eliminar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "var option = new TransactionOptions" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted," + "\n";
                        cadena += "\t\t\t\t" + "Timeout = TimeSpan.FromSeconds(60)," + "\n";
                        cadena += "\t\t\t" + "};" + "\n";
                        cadena += "\t\t\t" + "using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "result = new " + claseDatos + "().eliminar(" + objeto + ");" + "\n";
                        cadena += "\t\t\t\t" + "if(result != 0) transactionScope.Complete();" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }

        private void generarProcedimientosAlmacenados(string rutaProyecto, string carpeta, string baseDatos)
        {
            string rutaProcedimientos = rutaProyecto + @"\" + carpeta + @"\ProcedimientosAlmacenados";
            if (!Directory.Exists(rutaProcedimientos)) Directory.CreateDirectory(rutaProcedimientos);

            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string storeprocedure = "sp_" + tabla + "_";
                    string rutaArchivo = rutaProcedimientos + @"\" + tabla + ".sql";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "use " + baseDatos + "\n";
                        cadena += "go" + "\n";
                        //Funcion listar
                        cadena += "create procedure " + storeprocedure + "Listar" + "\n";
                        cadena += "as" + "\n";
                        cadena += "select " + lstColumna[0].nombre + "," + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t" + lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += "from " + tabla + "\n";
                        cadena += "go" + "\n";
                        //Funcion obtener
                        cadena += "create procedure " + storeprocedure + "Obtener" + "\n";
                        cadena += "@" + lstColumna[0].nombre.ToLower() + " " + lstColumna[0].tipo;
                        if (lstColumna[0].tipo != "")
                            cadena += "(" + lstColumna[0].tamaño + ")";
                        cadena += "\n";
                        cadena += "as" + "\n";
                        cadena += "select " + lstColumna[0].nombre + "," + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t" + lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += "from " + tabla + "\n";
                        cadena += "where " + lstColumna[0].nombre + " = " + "@" + lstColumna[0].nombre.ToLower() + "\n";
                        cadena += "go" + "\n";
                        //Funcion insertar
                        cadena += "create procedure " + storeprocedure + "Insertar" + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "@" + lstColumna[i].nombre.ToLower() + " " + lstColumna[i].tipo;
                            if (lstColumna[i].tipo != "")
                                cadena += "(" + lstColumna[i].tamaño + ")";
                            if (i < lstColumna.Count - 1) cadena += ",";
                            cadena += "\n";
                        }
                        cadena += "as" + "\n";
                        cadena += "insert into " + tabla + "(";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")" + "\n";
                        cadena += "values(";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "@" + lstColumna[i].nombre.ToLower();
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")" + "\n";
                        cadena += "go" + "\n";
                        //Funcion actualizar
                        cadena += "create procedure " + storeprocedure + "Actualizar" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "@" + lstColumna[i].nombre.ToLower() + " " + lstColumna[i].tipo;
                            if (lstColumna[i].tipo != "")
                                cadena += "(" + lstColumna[i].tamaño + ")";
                            if (i < lstColumna.Count - 1) cadena += ",";
                            cadena += "\n";
                        }
                        cadena += "as" + "\n";
                        cadena += "update " + tabla + "\n";
                        cadena += "set " + lstColumna[1].nombre + " = @" + lstColumna[1].nombre + "," + "\n";
                        for (int i = 2; i < lstColumna.Count; i++)
                        {
                            cadena += "\t" + lstColumna[i].nombre + " = @" + lstColumna[i].nombre.ToLower();
                            if (i < lstColumna.Count - 1) cadena += ",";
                            cadena += "\n";
                        }
                        cadena += "where " + lstColumna[0].nombre + " = @" + lstColumna[0].nombre.ToLower() + "\n";
                        cadena += "go" + "\n";
                        //Funcion eliminar
                        cadena += "create procedure " + storeprocedure + "Eliminar" + "\n";
                        cadena += "@" + lstColumna[0].nombre.ToLower() + " " + lstColumna[0].tipo;
                        if (lstColumna[0].tipo != "")
                            cadena += "(" + lstColumna[0].tamaño + ")";
                        cadena += "\n";
                        cadena += "as" + "\n";
                        cadena += "delete from " + tabla + " where " + lstColumna[0].nombre + " = @" + lstColumna[0].nombre.ToLower();
                        cadena += "go" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }
        #endregion

        #region Generador de código Java
        private void generarArchivoConexionJava(string rutaCarpeta, string solucion, string capaDatos, string ip, string BaseDatos, string user, string pass)
        {
            string rutaArchivo = rutaCarpeta + @"\Conexion.java";

            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

            using (StreamWriter sw = File.CreateText(rutaArchivo))
            {
                string cadena = "";
                cadena += "package " + solucion + "." + capaDatos + ";" + "\n";
                cadena += "\n";
                cadena += "import com.microsoft.sqlserver.jdbc.SQLServerDriver;" + "\n";
                cadena += "import java.sql.Connection;" + "\n";
                cadena += "import java.sql.DriverManager;" + "\n";
                cadena += "\n";
                cadena += "public class Conexion {" + "\n";
                cadena += "\t" + "private static Conexion instance = null;" + "\n";
                cadena += "\t" + "private static final String url = \"jdbc:sqlserver://" + ip + ":1433;databaseName=" + BaseDatos + "\";" + "\n";
                cadena += "\t" + "private static final String driver = \"com.microsoft.sqlserver.jdbc.SQLServerDriver\";" + "\n";
                cadena += "\t" + "private static final String user = \"" + user + "\";" + "\n";
                cadena += "\t" + "private static final String pass = \"" + pass + "\";" + "\n";
                cadena += "\t" + "private static Connection cn = null;" + "\n";
                cadena += "\n";
                cadena += "\t" + "private Conexion() {" + "\n";
                cadena += "\t\t" + "try{" + "\n";
                cadena += "\t\t\t" + "Class.forName(driver).newInstance();" + "\n";
                cadena += "\t\t\t" + "cn = DriverManager.getConnection(url, user, pass);" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t\t" + "catch(Exception ex){" + "\n";
                cadena += "\t\t\t" + "System.out.println(\"Error de conexión: \" + ex.getMessage());" + "\n";
                cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\n";
                cadena += "\t" + "public synchronized static Conexion instanciar(){" + "\n";
                cadena += "\t\t" + "if(instance == null){" + "\n";
                cadena += "\t\t\t" + "instance = new Conexion();" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t\t" + "return instance;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\n";
                cadena += "\t" + "public Connection conectar(){" + "\n";
                cadena += "\t\t" + "return cn;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\t" + "public void desconectar(){" + "\n";
                cadena += "\t\t" + "instance = null;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "}" + "\n";

                sw.Write(cadena);
            }
        }

        private void generarArchivoEntidadJava(string rutaCarpeta, string solucion, string capa)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "BE";
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".java";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "package " + solucion + "." + capa + ";" + "\n";
                        cadena += "\n";
                        cadena += "public class " + clase + " {" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                            cadena += "\t" + "private " + convertirTipoDato(lstColumna[i].tipo) + " " + lstColumna[i].nombre + ";" + "\n";
                        cadena += "\n";
                        cadena += "\t" + "public " + clase + "() { }" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\n";
                            cadena += "\t" + "public " + convertirTipoDato(lstColumna[i].tipo) + " get" + lstColumna[i].nombre + "() {" + "\n";
                            cadena += "\t\t" + "return " + lstColumna[i].nombre + ";" + "\n";
                            cadena += "\t" + "}" + "\n";
                            cadena += "\n";
                            cadena += "\t" + "public void set" + lstColumna[i].nombre + "(" + convertirTipoDato(lstColumna[i].tipo) + " " + lstColumna[i].nombre + ") {" + "\n";
                            cadena += "\t\t" + "this." + lstColumna[i].nombre + " = " + lstColumna[i].nombre + ";" + "\n";
                            cadena += "\t" + "}" + "\n";
                        }
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }

        private void generarArchivoDatosJava(string rutaCarpeta, string solucion, string capa, string capaEntidad)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "DA";
                    string claseEntidad = tabla + "BE";
                    string objeto = "o" + claseEntidad;
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".java";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "package " + solucion + "." + capa + ";" + "\n";
                        cadena += "\n";
                        cadena += "import " + solucion + "." + capa + ".Conexion;" + "\n";
                        cadena += "import " + solucion + "." + capaEntidad + "." + claseEntidad + ";" + "\n";
                        cadena += "import java.sql.CallableStatement;" + "\n";
                        cadena += "import java.sql.ResultSet;" + "\n";
                        cadena += "import java.util.ArrayList;" + "\n";
                        cadena += "\n";
                        cadena += "public class " + clase + " {" + "\n";
                        cadena += "\t" + "private static CallableStatement cstm = null;" + "\n";
                        cadena += "\t" + "private static ResultSet rs = null;" + "\n";
                        cadena += "\t" + "private static Conexion cn;" + "\n";
                        cadena += "\n";
                        //Funcion listar
                        cadena += "\t" + "public ArrayList<" + claseEntidad + "> listar() {" + "\n";
                        cadena += "\t\t" + "ArrayList<" + claseEntidad + "> lst" + claseEntidad + " = new ArrayList<>();" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cn = Conexion.instanciar();" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Listar()}\");" + "\n";
                        cadena += "\t\t\t" + "rs = cstm.executeQuery();" + "\n";
                        cadena += "\t\t\t" + "while(rs.next()){" + "\n";
                        cadena += "\t\t\t\t" + claseEntidad + " " + objeto + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t" + objeto + ".set" + lstColumna[i].nombre + "(rs.getString(\"" + lstColumna[i].nombre + "\").isEmpty() ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : rs.getString(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : rs.getInt(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "double")
                                cadena += "0 : rs.getDouble(\"" + lstColumna[i].nombre + "\"));";
                            else
                                cadena += "false : rs.getBoolean(\"" + lstColumna[i].nombre + "\"));";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "throw new Exception(\"Error función listar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "try{" + "\n";
                        cadena += "\t\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return lst" + claseEntidad + ";" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion obtener
                        cadena += "\t" + "public " + claseEntidad + " obtener(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + claseEntidad + " obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cn = Conexion.instanciar();" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Obtener(?)}\");" + "\n";
                        cadena += "\t\t\t" + "cstm.set";
                        cadena += convertirTipoDato(lstColumna[0].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[0].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[0].tipo) == "double" ? "Double" : "Boolean";
                        cadena += "(1, obj" + claseEntidad + ".get" + lstColumna[0].nombre + "());" + "\n";
                        cadena += "\t\t\t" + "rs = cstm.executeQuery();" + "\n";
                        cadena += "\t\t\t" + "if(rs.next()){" + "\n";
                        cadena += "\t\t\t\t" + "obj" + claseEntidad + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t" + objeto + ".set" + lstColumna[i].nombre + "(rs.getString(\"" + lstColumna[i].nombre + "\").isEmpty() ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : rs.getString(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : rs.getInt(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "double")
                                cadena += "0 : rs.getDouble(\"" + lstColumna[i].nombre + "\"));";
                            else
                                cadena += "false : rs.getBoolean(\"" + lstColumna[i].nombre + "\"));";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "throw new Exception(\"Error función obtener: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "try{" + "\n";
                        cadena += "\t\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return obj" + claseEntidad + ";" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion insertar
                        cadena += "\t" + "public boolean insertar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cn = Conexion.instanciar();" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Insertar(";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "?";
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")}\");" + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t" + "cstm.set";
                            cadena += convertirTipoDato(lstColumna[i].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[i].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[i].tipo) == "double" ? "Double" : "Boolean";
                            cadena += "(" + (i + 1) + ", obj" + claseEntidad + ".get" + lstColumna[i].nombre + "());" + "\n";
                        }
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "throw new Exception(\"Error función insertar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "try{" + "\n";
                        cadena += "\t\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion actualizar
                        cadena += "\t" + "public boolean actualizar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cn = Conexion.instanciar();" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Actualizar(";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "?";
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")}\");" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t" + "cstm.set";
                            cadena += convertirTipoDato(lstColumna[i].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[i].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[i].tipo) == "double" ? "Double" : "Boolean";
                            cadena += "(" + (i + 1) + ", obj" + claseEntidad + ".get" + lstColumna[i].nombre + "());" + "\n";
                        }
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "throw new Exception(\"Error función actualizar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "try{" + "\n";
                        cadena += "\t\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion eliminar
                        cadena += "\t" + "public boolean eliminar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cn = Conexion.instanciar();" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Eliminar(?)}\");" + "\n";
                        cadena += "\t\t\t" + "cstm.set";
                        cadena += convertirTipoDato(lstColumna[0].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[0].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[0].tipo) == "double" ? "Double" : "Boolean";
                        cadena += "(1, obj" + claseEntidad + ".get" + lstColumna[0].nombre + "());" + "\n";
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "throw new Exception(\"Error función actualizar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "try{" + "\n";
                        cadena += "\t\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";
                    }
                }
            }
        }
        #endregion

        #region Generador de código Android
        private void generarArchivoConexionAndroid(string rutaCarpeta, string solucion, string capaDatos, string ip, string BaseDatos, string user, string pass)
        {
            string rutaArchivo = rutaCarpeta + @"\Conexion.java";

            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

            using (StreamWriter sw = File.CreateText(rutaArchivo))
            {
                string cadena = "";
                cadena += "package " + solucion + "." + capaDatos + ";" + "\n";
                cadena += "\n";
                cadena += "import android.os.StrictMode;" + "\n";
                cadena += "import java.sql.Connection;" + "\n";
                cadena += "import java.sql.DriverManager;" + "\n";
                cadena += "\n";
                cadena += "public class Conexion {" + "\n";
                cadena += "\t" + "private static Conexion instance = null;" + "\n";
                cadena += "\t" + "private static final String url = \"jdbc:jtds:sqlserver://" + ip + ":1433;databaseName=" + BaseDatos + ";user=" + user + ";password=" + pass + ";\";" + "\n";
                cadena += "\t" + "private static final String driver = \"net.sourceforge.jtds.jdbc.Driver\";" + "\n";
                cadena += "\t" + "private static Connection cn = null;" + "\n";
                cadena += "\n";
                cadena += "\t" + "private Conexion() {" + "\n";
                cadena += "\t\t" + "try{" + "\n";
                cadena += "\t\t\t" + "StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();" + "\n";
                cadena += "\t\t\t" + "StrictMode.setThreadPolicy(policy);" + "\n";
                cadena += "\t\t\t" + "Class.forName(driver).newInstance();" + "\n";
                cadena += "\t\t\t" + "cn = DriverManager.getConnection(url);" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t\t" + "catch(Exception ex){" + "\n";
                cadena += "\t\t\t" + "System.out.println(\"Error de conexión: \" + ex.getMessage());" + "\n";
                cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\n";
                cadena += "\t" + "public static Conexion instanciar(){" + "\n";
                cadena += "\t\t" + "if(instance == null){" + "\n";
                cadena += "\t\t\t" + "instance = new Conexion();" + "\n";
                cadena += "\t\t" + "}" + "\n";
                cadena += "\t\t" + "return instance;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\n";
                cadena += "\t" + "public Connection conectar(){" + "\n";
                cadena += "\t\t" + "return cn;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "\t" + "public void desconectar(){" + "\n";
                cadena += "\t\t" + "instance = null;" + "\n";
                cadena += "\t" + "}" + "\n";
                cadena += "}" + "\n";

                sw.Write(cadena);
            }
        }

        private void generarArchivoInterfaceAndroid(string rutaCarpeta, string solucion, string capaDatos, string ip, string BaseDatos, string user, string pass)
        {
            string rutaArchivo = rutaCarpeta + @"\OperacionesBD.java";

            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

            using (StreamWriter sw = File.CreateText(rutaArchivo))
            {
                string cadena = "";
                cadena += "package " + solucion + "." + capaDatos + ";" + "\n";
                cadena += "\n";
                cadena += "import java.util.ArrayList;" + "\n";
                cadena += "\n";
                cadena += "public interface OperacionesBD<T> {" + "\n";
                cadena += "\t" + "ArrayList<T> listar();" + "\n";
                cadena += "\t" + "T obtener(T t);" + "\n";
                cadena += "\t" + "boolean insertar(T  t);" + "\n";
                cadena += "\t" + "boolean actualizar(T t);" + "\n";
                cadena += "\t" + "boolean eliminar(T t);" + "\n";
                cadena += "\t" + "void cerrarConexion();" + "\n";
                cadena += "}" + "\n";

                sw.Write(cadena);
            }
        }

        private void generarArchivoDatosAndroid(string rutaCarpeta, string solucion, string capa, string capaEntidad)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "DA";
                    string claseEntidad = tabla + "BE";
                    string objeto = "o" + claseEntidad;
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".java";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "package " + solucion + "." + capa + ";" + "\n";
                        cadena += "\n";
                        cadena += "import " + solucion + "." + capaEntidad + "." + claseEntidad + ";" + "\n";
                        cadena += "import java.sql.CallableStatement;" + "\n";
                        cadena += "import java.sql.ResultSet;" + "\n";
                        cadena += "import java.util.ArrayList;" + "\n";
                        cadena += "\n";
                        cadena += "public class " + clase + " implements OperacionesBD<" + claseEntidad + "> {" + "\n";
                        cadena += "\t" + "private static CallableStatement cstm = null;" + "\n";
                        cadena += "\t" + "private static ResultSet rs = null;" + "\n";
                        cadena += "\t" + "private static Conexion cn = Conexion.instanciar();" + "\n";
                        cadena += "\n";
                        //Funcion listar
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public ArrayList<" + claseEntidad + "> listar() {" + "\n";
                        cadena += "\t\t" + "ArrayList<" + claseEntidad + "> lst" + claseEntidad + " = new ArrayList<>();" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Listar()}\");" + "\n";
                        cadena += "\t\t\t" + "rs = cstm.executeQuery();" + "\n";
                        cadena += "\t\t\t" + "while(rs.next()){" + "\n";
                        cadena += "\t\t\t\t" + claseEntidad + " " + objeto + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t" + objeto + ".set" + lstColumna[i].nombre + "(rs.getObject(\"" + lstColumna[i].nombre + "\") == null ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : rs.getString(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : rs.getInt(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "double")
                                cadena += "0 : rs.getDouble(\"" + lstColumna[i].nombre + "\"));";
                            else
                                cadena += "false : rs.getBoolean(\"" + lstColumna[i].nombre + "\"));";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "System.out.println(\"Error listar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "cerrarConexion();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return lst" + claseEntidad + ";" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion obtener
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public " + claseEntidad + " obtener(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + claseEntidad + " obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Obtener(?)}\");" + "\n";
                        cadena += "\t\t\t" + "cstm.set";
                        cadena += convertirTipoDato(lstColumna[0].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[0].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[0].tipo) == "double" ? "Double" : "Boolean";
                        cadena += "(1, obj" + claseEntidad + ".get" + lstColumna[0].nombre + "());" + "\n";
                        cadena += "\t\t\t" + "rs = cstm.executeQuery();" + "\n";
                        cadena += "\t\t\t" + "if(rs.next()){" + "\n";
                        cadena += "\t\t\t\t" + "obj" + claseEntidad + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t" + objeto + ".set" + lstColumna[i].nombre + "(rs.getString(\"" + lstColumna[i].nombre + "\").isEmpty() ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : rs.getString(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : rs.getInt(\"" + lstColumna[i].nombre + "\"));";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "double")
                                cadena += "0 : rs.getDouble(\"" + lstColumna[i].nombre + "\"));";
                            else
                                cadena += "false : rs.getBoolean(\"" + lstColumna[i].nombre + "\"));";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "System.out.println(\"Error obtener: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "cerrarConexion();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return obj" + claseEntidad + ";" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion insertar
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public boolean insertar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Insertar(";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "?";
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")}\");" + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t" + "cstm.set";
                            cadena += convertirTipoDato(lstColumna[i].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[i].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[i].tipo) == "double" ? "Double" : "Boolean";
                            cadena += "(" + (i + 1) + ", " + objeto + ".get" + lstColumna[i].nombre + "());" + "\n";
                        }
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "System.out.println(\"Error insertar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "cerrarConexion();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion actualizar
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public boolean actualizar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Actualizar(";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "?";
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        cadena += ")}\");" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t" + "cstm.set";
                            cadena += convertirTipoDato(lstColumna[i].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[i].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[i].tipo) == "double" ? "Double" : "Boolean";
                            cadena += "(" + (i + 1) + ", " + objeto + ".get" + lstColumna[i].nombre + "());" + "\n";
                        }
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "System.out.println(\"Error actualizar: \" + ex.getMessage());" + "\n";
                        cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "cerrarConexion();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "\n";
                        //Funcion eliminar
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public boolean eliminar(" + claseEntidad + " " + objeto + ") {" + "\n";
                        cadena += "\t\t" + "boolean result = false;" + "\n";
                        cadena += "\t\t" + "try{" + "\n";
                        cadena += "\t\t\t" + "cstm = cn.conectar().prepareCall(\"{call sp_" + tabla + "_Eliminar(?)}\");" + "\n";
                        cadena += "\t\t\t" + "cstm.set";
                        cadena += convertirTipoDato(lstColumna[0].tipo) == "String" ? "String" : convertirTipoDato(lstColumna[0].tipo) == "int" ? "Int" : convertirTipoDato(lstColumna[0].tipo) == "double" ? "Double" : "Boolean";
                        cadena += "(1, " + objeto + ".get" + lstColumna[0].nombre + "());" + "\n";
                        cadena += "\t\t\t" + "if(cstm.executeUpdate() > 0) result = true;" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch(Exception ex){" + "\n";
                        cadena += "\t\t\t" + "System.out.println(\"Error eliminar \" + ex.getMessage());" + "\n";
                        cadena += "\t\t\t" + "ex.printStackTrace();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "finally{" + "\n";
                        cadena += "\t\t\t" + "cerrarConexion();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "return result;" + "\n";
                        cadena += "\t" + "}" + "\n";
                        //Funcion cerrarConexion
                        cadena += "\t" + "@Override" + "\n";
                        cadena += "\t" + "public void cerrarConexion() {" + "\n";
                        cadena += "\t\t" + "try {" + "\n";
                        cadena += "\t\t\t" + "if(rs != null) rs.close();" + "\n";
                        cadena += "\t\t\t" + "if(cstm != null) cstm.close();" + "\n";
                        cadena += "\t\t\t" + "if(cn != null) cn.desconectar();" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t\t" + "catch (Exception ex){" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }
        #endregion
        #endregion

        #region MySQL
        #region Generador de código C#
        private void generarArchivoDatosCMySQL(string rutaCarpeta, string capa, string capaEntidad)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string clase = tabla + "DA";
                    string claseEntidad = tabla + "BE";
                    string objeto = "o" + claseEntidad;
                    string rutaArchivo = rutaCarpeta + @"\" + clase + ".cs";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        cadena += "using System;" + "\n";
                        cadena += "using System.Collections.Generic;" + "\n";
                        cadena += "using System.Data;" + "\n";
                        cadena += "using MySql.Data.MySqlClient;" + "\n";
                        cadena += "using " + capaEntidad + ";" + "\n";
                        cadena += "\n";
                        cadena += "namespace " + capa + "\n";
                        cadena += "{" + "\n";
                        cadena += "\t" + "public class " + clase + "\n";
                        cadena += "\t" + "{" + "\n";
                        //Función listar
                        cadena += "\t\t" + "public List<" + claseEntidad + "> listar()" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "List<" + claseEntidad + "> lst" + claseEntidad + " = new List<" + claseEntidad + ">();" + "\n";
                        cadena += "\t\t\t" + "using (MySqlConnection cn = new MySqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "MySqlDataAdapter da = new MySqlDataAdapter(\"Sp_" + tabla + "_Listar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t" + "MySqlDataReader dr = da.SelectCommand.ExecuteReader();" + "\n";
                        cadena += "\t\t\t\t\t" + "while (dr.Read())" + "\n";
                        cadena += "\t\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t" + claseEntidad + " " + objeto + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t\t" + objeto + "." + lstColumna[i].nombre + " = String.IsNullOrEmpty(dr[\"" + lstColumna[i].nombre + "\"].ToString()) ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : dr[\"" + lstColumna[i].nombre + "\"].ToString();";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : Convert.ToInt32(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "decimal")
                                cadena += "0 : Convert.ToDecimal(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else
                                cadena += "false : Convert.ToBoolean(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t\t\t\t" + "lst" + claseEntidad + ".Add(" + objeto + ")" + "\n";
                        cadena += "\t\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "lst" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t" + "return lst" + claseEntidad + ";" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función obtener
                        cadena += "\t\t" + "public " + claseEntidad + " obtener(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + claseEntidad + " obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t" + "using (MySqlConnection cn = new MySqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t\t" + "MySqlDataAdapter da = new MySqlDataAdapter(\"Sp_" + tabla + "_Obtener\", cn);" + "\n";
                        cadena += "\t\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[0].nombre.ToLower() + "\", " + objeto + "." + lstColumna[0].nombre + ");" + "\n";
                        cadena += "\t\t\t\t\t\t" + "MySqlDataReader dr = da.SelectCommand.ExecuteReader();" + "\n";
                        cadena += "\t\t\t\t\t\t" + "while (dr.Read())" + "\n";
                        cadena += "\t\t\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t\t\t" + "obj" + claseEntidad + " = new " + claseEntidad + "();" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t\t" + objeto + "." + lstColumna[i].nombre + " = String.IsNullOrEmpty(dr[\"" + lstColumna[i].nombre + "\"].ToString()) ? ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String")
                                cadena += "\"\" : dr[\"" + lstColumna[i].nombre + "\"].ToString();";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "int")
                                cadena += "0 : Convert.ToInt32(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else if (convertirTipoDato(lstColumna[i].tipo) == "decimal")
                                cadena += "0 : Convert.ToDecimal(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            else
                                cadena += "false : Convert.ToBoolean(dr[\"" + lstColumna[i].nombre + "\"].ToString());";
                            cadena += "\n";
                        }
                        cadena += "\t\t\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "obj" + claseEntidad + " = null;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return obj" + claseEntidad + ";" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función insertar
                        cadena += "\t\t" + "public int insertar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (MySqlConnection cn = new MySqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "MySqlDataAdapter da = new MySqlDataAdapter(\"Sp_" + tabla + "_Insertar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[i].nombre.ToLower() + "\", " + objeto + "." + lstColumna[i].nombre + ");" + "\n";
                        }
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función actualizar
                        cadena += "\t\t" + "public int actualizar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (MySqlConnection cn = new MySqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "MySqlDataAdapter da = new MySqlDataAdapter(\"Sp_" + tabla + "_Actualizar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        for (int i = 0; i < lstColumna.Count; i++)
                        {
                            cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[i].nombre.ToLower() + "\", " + objeto + "." + lstColumna[i].nombre + ");" + "\n";
                        }
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\n";
                        //Función eliminar
                        cadena += "\t\t" + "public int eliminar(" + claseEntidad + " " + objeto + ")" + "\n";
                        cadena += "\t\t" + "{" + "\n";
                        cadena += "\t\t\t" + "int result = 0;" + "\n";
                        cadena += "\t\t\t" + "using (MySqlConnection cn = new MySqlConnection(new Conexion().getConnectionString()))" + "\n";
                        cadena += "\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t" + "try" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "cn.Open();" + "\n";
                        cadena += "\t\t\t\t\t" + "MySqlDataAdapter da = new MySqlDataAdapter(\"Sp_" + tabla + "_Eliminar\", cn);" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.CommandType = CommandType.StoredProcedure;" + "\n";
                        cadena += "\t\t\t\t\t" + "da.SelectCommand.Parameters.AddWithValue(\"@" + lstColumna[0].nombre.ToLower() + "\", " + objeto + "." + lstColumna[0].nombre + ");" + "\n";
                        cadena += "\t\t\t\t\t" + "result = da.SelectCommand.ExecuteNonQuery();" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "catch (Exception ex)" + "\n";
                        cadena += "\t\t\t\t" + "{" + "\n";
                        cadena += "\t\t\t\t\t" + "result = 0;" + "\n";
                        cadena += "\t\t\t\t\t" + "throw ex;" + "\n";
                        cadena += "\t\t\t\t" + "}" + "\n";
                        cadena += "\t\t\t\t" + "return result;" + "\n";
                        cadena += "\t\t\t" + "}" + "\n";
                        cadena += "\t\t" + "}" + "\n";
                        cadena += "\t" + "}" + "\n";
                        cadena += "}" + "\n";

                        sw.Write(cadena);
                    }
                }
            }
        }
        #endregion

        #region Generador de código PHP
        private void generarArchivoConexionPHP(string rutaCarpeta, string capaDatos, string BaseDatos)
        {
            string rutaArchivo = rutaCarpeta + @"\Conexion.php";

            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

            using (StreamWriter sw = File.CreateText(rutaArchivo))
            {
                sw.WriteLine("<?php");
                sw.WriteLine("header(\"Access-Control-Allow-Origin: *\");");
                sw.WriteLine("$cn = mysqli_connect(\"localhost\", \"root\", \"\", \"sistema\");");
                sw.WriteLine("?>");
            }
        }
        private void generarArchivoDatosPHP(string rutaCarpeta)
        {
            for (int fila = 0; fila < dgvTablas.Rows.Count; fila++)
            {
                if (Convert.ToBoolean(dgvTablas.Rows[fila].Cells[0].Value.ToString()))
                {
                    string tabla = dgvTablas.Rows[fila].Cells[1].Value.ToString();
                    listarColumnas(tabla);
                    string rutaArchivo = rutaCarpeta + @"\" + tabla + ".php";

                    if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo);

                    using (StreamWriter sw = File.CreateText(rutaArchivo))
                    {
                        string cadena = "";
                        string campos = "";
                        string values = "";

                        sw.WriteLine("<?php");
                        sw.WriteLine("require_once(\"Conexion.php\");");
                        sw.WriteLine("mysqli_set_charset($cn, \"utf8\");");
                        sw.WriteLine("");
                        //Función listar
                        sw.WriteLine("function listar(){");
                        sw.WriteLine("\t" + "try {");
                        sw.WriteLine("\t\t" + "$lista = null;");
                        sw.WriteLine("\t\t" + "$query = mysqli_query($cn, \"SELECT * FROM " + tabla + "\");");
                        sw.WriteLine("\t\t" + "while($row = mysqli_fetch_assoc($query)){");
                        sw.WriteLine("\t\t\t" + "$lista[] = array_map(\"utf8_encode\", $row);");
                        sw.WriteLine("\t\t" + "}");
                        sw.WriteLine("\t\t" + "");
                        sw.WriteLine("\t\t" + "return json_encode($lista);");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("\t" + "catch(ErrorException ex) {");
                        sw.WriteLine("\t\t" + "throw new Exception(ex->getMessage());");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("}");
                        //Función obtener por id
                        sw.WriteLine("function obtener($" + lstColumna[0].nombre + "){");
                        sw.WriteLine("\t" + "try {");
                        sw.WriteLine("\t\t" + "$query = mysqli_query($cn, \"SELECT * FROM " + tabla + " WHERE " + lstColumna[0].nombre + " = $" + lstColumna[0].nombre + "\");");
                        sw.WriteLine("\t\t" + "$objeto = mysqli_num_rows($query) == 0 ? null : mysqli_fetch_assoc($query);");
                        sw.WriteLine("\t\t" + "return json_encode($objeto);");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("\t" + "catch(ErrorException ex) {");
                        sw.WriteLine("\t\t" + "throw new Exception(ex->getMessage());");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("}");
                        //Función insertar
                        cadena = "";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "$" + lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        values = "";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            if (convertirTipoDato(lstColumna[i].tipo) == "String") values += "'";
                            values += "$" + lstColumna[i].nombre;
                            if (convertirTipoDato(lstColumna[i].tipo) == "String") values += "'";
                            if (i < lstColumna.Count - 1) values += ",";
                        }
                        campos = "";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            campos += lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) campos += ",";
                        }
                        sw.WriteLine("function insertar(" + cadena + "){");
                        sw.WriteLine("\t" + "try {");
                        sw.WriteLine("\t\t" + "$query = mysqli_query($cn, \"INSERT INTO " + tabla + "(" + campos + ") VALUES(" + values + ")\");");
                        sw.WriteLine("\t\t" + "return $query;");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("\t" + "catch(ErrorException ex) {");
                        sw.WriteLine("\t\t" + "throw new Exception(ex->getMessage());");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("}");
                        //Función actualizar
                        cadena = "";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            cadena += "$" + lstColumna[i].nombre;
                            if (i < lstColumna.Count - 1) cadena += ",";
                        }
                        values = "";
                        for (int i = 1; i < lstColumna.Count; i++)
                        {
                            values += lstColumna[i].nombre + " = ";
                            if (convertirTipoDato(lstColumna[i].tipo) == "String") values += "'";
                            values += "$" + lstColumna[i].nombre;
                            if (convertirTipoDato(lstColumna[i].tipo) == "String") values += "'";
                            if (i < lstColumna.Count - 1) values += ",";
                        }
                        sw.WriteLine("function actualizar($" + lstColumna[0].nombre + ", " + cadena + "){");
                        sw.WriteLine("\t" + "try {");
                        sw.WriteLine("\t\t" + "$query = mysqli_query($cn, \"UPDATE " + tabla + " SET " + values + " WHERE " + lstColumna[0].nombre + " = $" + lstColumna[0].nombre + "\");");
                        sw.WriteLine("\t\t" + "return $query;");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("\t" + "catch(ErrorException ex) {");
                        sw.WriteLine("\t\t" + "throw new Exception(ex->getMessage());");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("}");
                        //Función eliminar
                        sw.WriteLine("function actualizar($" + lstColumna[0].nombre + "){");
                        sw.WriteLine("\t" + "try {");
                        sw.WriteLine("\t\t" + "$query = mysqli_query($cn, \"DELETE FROM " + tabla + " WHERE " + lstColumna[0].nombre + " = $" + lstColumna[0].nombre + "\");");
                        sw.WriteLine("\t\t" + "return $query;");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("\t" + "catch(ErrorException ex) {");
                        sw.WriteLine("\t\t" + "throw new Exception(ex->getMessage());");
                        sw.WriteLine("\t" + "}");
                        sw.WriteLine("}");
                        sw.WriteLine("?>");
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}