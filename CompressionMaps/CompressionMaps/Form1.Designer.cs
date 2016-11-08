namespace CompressionMaps
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.txt_des = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_lat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_lon = new System.Windows.Forms.TextBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_poligono = new System.Windows.Forms.Button();
            this.btn_Ruta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(13, 13);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(603, 453);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
            this.gMapControl1.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapControl1_OnPolygonClick);
            this.gMapControl1.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gMapControl1_OnRouteClick);
            this.gMapControl1.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl1_OnMarkerEnter);
            this.gMapControl1.OnPolygonEnter += new GMap.NET.WindowsForms.PolygonEnter(this.gMapControl1_OnPolygonEnter);
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // txt_des
            // 
            this.txt_des.Location = new System.Drawing.Point(622, 33);
            this.txt_des.Name = "txt_des";
            this.txt_des.Size = new System.Drawing.Size(265, 20);
            this.txt_des.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitud";
            // 
            // txt_lat
            // 
            this.txt_lat.Location = new System.Drawing.Point(622, 80);
            this.txt_lat.Name = "txt_lat";
            this.txt_lat.Size = new System.Drawing.Size(265, 20);
            this.txt_lat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(619, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Longitud";
            // 
            // txt_lon
            // 
            this.txt_lon.Location = new System.Drawing.Point(622, 128);
            this.txt_lon.Name = "txt_lon";
            this.txt_lon.Size = new System.Drawing.Size(265, 20);
            this.txt_lon.TabIndex = 5;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(625, 154);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(60, 23);
            this.btn_Agregar.TabIndex = 7;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(691, 154);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(60, 23);
            this.btn_Eliminar.TabIndex = 8;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(622, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(265, 282);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SeleccionarRegistro);
            // 
            // btn_poligono
            // 
            this.btn_poligono.Location = new System.Drawing.Point(757, 154);
            this.btn_poligono.Name = "btn_poligono";
            this.btn_poligono.Size = new System.Drawing.Size(59, 23);
            this.btn_poligono.TabIndex = 10;
            this.btn_poligono.Text = "Polígono";
            this.btn_poligono.UseVisualStyleBackColor = true;
            this.btn_poligono.Click += new System.EventHandler(this.btn_poligono_Click);
            // 
            // btn_Ruta
            // 
            this.btn_Ruta.Location = new System.Drawing.Point(822, 154);
            this.btn_Ruta.Name = "btn_Ruta";
            this.btn_Ruta.Size = new System.Drawing.Size(60, 23);
            this.btn_Ruta.TabIndex = 11;
            this.btn_Ruta.Text = "Ruta";
            this.btn_Ruta.UseVisualStyleBackColor = true;
            this.btn_Ruta.Click += new System.EventHandler(this.btn_Ruta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 492);
            this.Controls.Add(this.btn_Ruta);
            this.Controls.Add(this.btn_poligono);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_lon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_lat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_des);
            this.Controls.Add(this.gMapControl1);
            this.Name = "Form1";
            this.Text = "Rutas de usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox txt_des;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_lon;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_poligono;
        private System.Windows.Forms.Button btn_Ruta;
    }
}

