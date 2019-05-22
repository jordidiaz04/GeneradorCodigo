namespace GeneradorCodigo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBaseDatos = new System.Windows.Forms.ComboBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnDeseleccionar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbNegocio = new System.Windows.Forms.CheckBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.chbDatos = new System.Windows.Forms.CheckBox();
            this.chbEntidad = new System.Windows.Forms.CheckBox();
            this.txtCapaNegocio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCapaDatos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCapaEntidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbMySQL = new System.Windows.Forms.RadioButton();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAndroid = new System.Windows.Forms.RadioButton();
            this.rbJava = new System.Windows.Forms.RadioButton();
            this.rbPHP = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBaseDatos);
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.btnDeseleccionar);
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Conexión";
            // 
            // cmbBaseDatos
            // 
            this.cmbBaseDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaseDatos.Enabled = false;
            this.cmbBaseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaseDatos.FormattingEnabled = true;
            this.cmbBaseDatos.Location = new System.Drawing.Point(105, 173);
            this.cmbBaseDatos.Name = "cmbBaseDatos";
            this.cmbBaseDatos.Size = new System.Drawing.Size(198, 21);
            this.cmbBaseDatos.TabIndex = 8;
            this.cmbBaseDatos.SelectionChangeCommitted += new System.EventHandler(this.cmbBaseDatos_SelectionChangeCommitted);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(21, 203);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(115, 23);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnDeseleccionar
            // 
            this.btnDeseleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeseleccionar.Location = new System.Drawing.Point(188, 203);
            this.btnDeseleccionar.Name = "btnDeseleccionar";
            this.btnDeseleccionar.Size = new System.Drawing.Size(115, 23);
            this.btnDeseleccionar.TabIndex = 6;
            this.btnDeseleccionar.Text = "Deseleccionar";
            this.btnDeseleccionar.UseVisualStyleBackColor = true;
            this.btnDeseleccionar.Click += new System.EventHandler(this.btnDeseleccionar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(228, 120);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(97, 84);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(206, 20);
            this.txtContraseña.TabIndex = 5;
            this.txtContraseña.Text = "sql";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(97, 58);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(206, 20);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Base de Datos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña:";
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(97, 32);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(206, 20);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // dgvTablas
            // 
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.Location = new System.Drawing.Point(338, 12);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.Size = new System.Drawing.Size(337, 605);
            this.dgvTablas.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbNegocio);
            this.groupBox2.Controls.Add(this.btnGenerar);
            this.groupBox2.Controls.Add(this.chbDatos);
            this.groupBox2.Controls.Add(this.chbEntidad);
            this.groupBox2.Controls.Add(this.txtCapaNegocio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCapaDatos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCapaEntidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSolucion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Proyecto";
            // 
            // chbNegocio
            // 
            this.chbNegocio.AutoSize = true;
            this.chbNegocio.Checked = true;
            this.chbNegocio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNegocio.Location = new System.Drawing.Point(288, 146);
            this.chbNegocio.Name = "chbNegocio";
            this.chbNegocio.Size = new System.Drawing.Size(15, 14);
            this.chbNegocio.TabIndex = 6;
            this.chbNegocio.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(228, 177);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // chbDatos
            // 
            this.chbDatos.AutoSize = true;
            this.chbDatos.Checked = true;
            this.chbDatos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDatos.Location = new System.Drawing.Point(288, 109);
            this.chbDatos.Name = "chbDatos";
            this.chbDatos.Size = new System.Drawing.Size(15, 14);
            this.chbDatos.TabIndex = 5;
            this.chbDatos.UseVisualStyleBackColor = true;
            // 
            // chbEntidad
            // 
            this.chbEntidad.AutoSize = true;
            this.chbEntidad.Checked = true;
            this.chbEntidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEntidad.Location = new System.Drawing.Point(288, 73);
            this.chbEntidad.Name = "chbEntidad";
            this.chbEntidad.Size = new System.Drawing.Size(15, 14);
            this.chbEntidad.TabIndex = 4;
            this.chbEntidad.UseVisualStyleBackColor = true;
            // 
            // txtCapaNegocio
            // 
            this.txtCapaNegocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapaNegocio.Location = new System.Drawing.Point(97, 143);
            this.txtCapaNegocio.Name = "txtCapaNegocio";
            this.txtCapaNegocio.Size = new System.Drawing.Size(177, 20);
            this.txtCapaNegocio.TabIndex = 3;
            this.txtCapaNegocio.Text = "CapaNegocio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Capa Negocio:";
            // 
            // txtCapaDatos
            // 
            this.txtCapaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapaDatos.Location = new System.Drawing.Point(97, 106);
            this.txtCapaDatos.Name = "txtCapaDatos";
            this.txtCapaDatos.Size = new System.Drawing.Size(177, 20);
            this.txtCapaDatos.TabIndex = 2;
            this.txtCapaDatos.Text = "CapaDatos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Capa Datos:";
            // 
            // txtCapaEntidad
            // 
            this.txtCapaEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapaEntidad.Location = new System.Drawing.Point(97, 70);
            this.txtCapaEntidad.Name = "txtCapaEntidad";
            this.txtCapaEntidad.Size = new System.Drawing.Size(177, 20);
            this.txtCapaEntidad.TabIndex = 1;
            this.txtCapaEntidad.Text = "CapaEntidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Capa Entidad:";
            // 
            // txtSolucion
            // 
            this.txtSolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolucion.Location = new System.Drawing.Point(97, 33);
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.Size = new System.Drawing.Size(177, 20);
            this.txtSolucion.TabIndex = 0;
            this.txtSolucion.Text = "Proyecto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Solución:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbMySQL);
            this.groupBox4.Controls.Add(this.rbSQL);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(213, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 135);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Motor Base de Datos";
            // 
            // rbMySQL
            // 
            this.rbMySQL.AutoSize = true;
            this.rbMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMySQL.Location = new System.Drawing.Point(22, 88);
            this.rbMySQL.Name = "rbMySQL";
            this.rbMySQL.Size = new System.Drawing.Size(60, 17);
            this.rbMySQL.TabIndex = 0;
            this.rbMySQL.Text = "MySQL";
            this.rbMySQL.UseVisualStyleBackColor = true;
            // 
            // rbSQL
            // 
            this.rbSQL.AutoSize = true;
            this.rbSQL.Checked = true;
            this.rbSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSQL.Location = new System.Drawing.Point(22, 53);
            this.rbSQL.Name = "rbSQL";
            this.rbSQL.Size = new System.Drawing.Size(80, 17);
            this.rbSQL.TabIndex = 0;
            this.rbSQL.TabStop = true;
            this.rbSQL.Text = "SQL Server";
            this.rbSQL.UseVisualStyleBackColor = true;
            this.rbSQL.CheckedChanged += new System.EventHandler(this.rbSQL_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAndroid);
            this.groupBox3.Controls.Add(this.rbJava);
            this.groupBox3.Controls.Add(this.rbPHP);
            this.groupBox3.Controls.Add(this.rbC);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 135);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lenguaje";
            // 
            // rbAndroid
            // 
            this.rbAndroid.AutoSize = true;
            this.rbAndroid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAndroid.Location = new System.Drawing.Point(90, 31);
            this.rbAndroid.Name = "rbAndroid";
            this.rbAndroid.Size = new System.Drawing.Size(94, 17);
            this.rbAndroid.TabIndex = 0;
            this.rbAndroid.Text = "Android Studio";
            this.rbAndroid.UseVisualStyleBackColor = true;
            this.rbAndroid.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // rbJava
            // 
            this.rbJava.AutoSize = true;
            this.rbJava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbJava.Location = new System.Drawing.Point(16, 98);
            this.rbJava.Name = "rbJava";
            this.rbJava.Size = new System.Drawing.Size(48, 17);
            this.rbJava.TabIndex = 0;
            this.rbJava.Text = "Java";
            this.rbJava.UseVisualStyleBackColor = true;
            this.rbJava.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // rbPHP
            // 
            this.rbPHP.AutoSize = true;
            this.rbPHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPHP.Location = new System.Drawing.Point(16, 65);
            this.rbPHP.Name = "rbPHP";
            this.rbPHP.Size = new System.Drawing.Size(47, 17);
            this.rbPHP.TabIndex = 0;
            this.rbPHP.Text = "PHP";
            this.rbPHP.UseVisualStyleBackColor = true;
            this.rbPHP.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Checked = true;
            this.rbC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbC.Location = new System.Drawing.Point(16, 31);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(39, 17);
            this.rbC.TabIndex = 0;
            this.rbC.TabStop = true;
            this.rbC.Text = "C#";
            this.rbC.UseVisualStyleBackColor = true;
            this.rbC.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(197, 625);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(282, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Desarrollado por Jordi Díaz - 22 de Mayo del 2019";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 645);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvTablas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Código C# y SQL";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaseDatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTablas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCapaNegocio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCapaDatos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCapaEntidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSolucion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbNegocio;
        private System.Windows.Forms.CheckBox chbDatos;
        private System.Windows.Forms.CheckBox chbEntidad;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnDeseleccionar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbMySQL;
        private System.Windows.Forms.RadioButton rbSQL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbJava;
        private System.Windows.Forms.RadioButton rbPHP;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbAndroid;
        private System.Windows.Forms.Label label9;
    }
}

