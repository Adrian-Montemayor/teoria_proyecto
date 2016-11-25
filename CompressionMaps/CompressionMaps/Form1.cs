using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace CompressionMaps
{
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        int filaSeleccionada = 0;
        double LatInicial = 25.6866142;
        double LngInicial = -100.3161126;

        int contador = 1;
        //Contador de puntos 
        int contadorPunto = 0;

        int u = 2;
        //ContadorDeClicks
        static int ContadorDeClik;
        static int ContadorRuta = 0;
        static int ContadorDouglas = 0;

        static int c = 1;
        static int[] BanderaNumero = new int[100];
        static double[] arreglo = new double[100];


        Dictionary<double, double> Diccionario_Cordenadas = new Dictionary<double, double>();
        //Diccionario  De puntos
        Dictionary<int, Dictionary<double, double>> Diccionario_Puntos = new Dictionary<int, Dictionary<double, double>>();   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            // Insertando datos al dt para mostrar en la lista
            //dt.Rows.Add("Ubicación 1", LatInicial, LngInicial);
            //dataGridView1.DataSource = dt;

            // Desactivar las columnas de lat y long
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[2].Visible = false;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = false;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;

            //// Marcador
            //markerOverlay = new GMapOverlay("Marcador");
            //marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.green);
            //markerOverlay.Markers.Add(marker);

            //// Agregamos un tooltip de texto a los marcadores
            ////marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud {1}", LatInicial, LngInicial);

            //// Ahora agregamos el mapa y el marcador al map control
            //gMapControl1.Overlays.Add(markerOverlay);

            // Actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

            // Deshabilitar el botón Ruta
            habRuta();
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex; // Fila seleccionada

            // Recuperamos los datos de grid y los asignamos a los textbox
            txt_des.Text = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            txt_lat.Text = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            txt_lon.Text = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();

            // Se asignan los valores del grid al marcador
            GMarkerGoogle marker2;
            marker2 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
            marker2.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
            //marker2.ToolTipMode = MarkerTooltipMode.Always;
            marker2.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

            // Se posiciona el foco del mapa en ese punto
            gMapControl1.Position = marker2.Position;

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(ContadorRuta == 1) {
                if(btn_Ruta.Enabled == false) {
                    MessageBox.Show("No se puede agregar más puntos");
                    return;
                }
            }

            if (ContadorDouglas == 1)
            {
                if (btn_Douglas.Enabled == false)
                {
                    MessageBox.Show("No se puede agregar más puntos");
                    return;
                }
            }

            habRuta();
          

            // Se obtiene los datos de lat y lng del mapa donde el usuario presionó
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            ContadorDeClik++;


            //Agrego la latitud y longitud al diccionario
            Diccionario_Cordenadas.Add(lat, lng);

            
            if(ContadorDeClik <= 10) {
                //*****************************************************************************************
                if (contador == 1)
                {
                    // Marcador
                    markerOverlay = new GMapOverlay("Marcador");
                    marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green);
                    markerOverlay.Markers.Add(marker);

                    // Agregamos un tooltip de texto a los marcadores
                    //marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud {1}", lat, lng);

                    // Ahora agregamos el mapa y el marcador al map control
                    gMapControl1.Overlays.Add(markerOverlay);

                    // Insertando datos al dt para mostrar en la lista
                    dt.Rows.Add("Ubicación 1", lat, lng);
                    dataGridView1.DataSource = dt;

                    // Desactivar las columnas de lat y long
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;

                    // Actualizar el mapa
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;
                }

                //*****************************************************************************************

                if (contador >= 2)
                {
                    // Se posicionan en el txt de la latitud y longitud
                    //txt_lat.Text = lat.ToString();
                    //txt_lon.Text = lng.ToString();

                    // Dejamos agregado el marcador
                    marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                    markerOverlay.Markers.Add(marker);
                    //marker.ToolTipMode = MarkerTooltipMode.Always;

                    // Creamos el marcador para moverlo al lugar indicado
                    //marker.Position = new PointLatLng(lat, lng);

                    // Agregamos datos al DataGrid
                    // Si no tiene algo escrito
                    if (txt_des.Text.Equals(""))
                    {
                        dt.Rows.Add("Ubicación " + u, lat.ToString(), lng.ToString());
                        u++;
                        //habRuta();
                    }
                    // Si tiene algo escrito
                    else
                    {
                        dt.Rows.Add(txt_des.Text, lat.ToString(), lng.ToString());
                        txt_des.Text = "";
                        u++;
                        //habRuta();
                    }

                    // También se agrega el mensaje al marcador(tooltip)
                    marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", lat, lng);
                }
                contador++;
            }
            else {
                MessageBox.Show("El máximo de marcadores es 10");
                ContadorDeClik--;
                return;
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(txt_des.Text, txt_lat.Text, txt_lon.Text);
            contador++;
            habRuta();
            desRuta();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(filaSeleccionada); // Remover de la tabla
            // Procedimiento para eliminar de una base de datos

            contador--;
        }

        private void btn_poligono_Click(object sender, EventArgs e)
        {
            GMapOverlay Poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();

            // Variables para almacenar los datos. 
            double lng, lat;

            // Agarramos los datos del grid
            for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Polígono");
            Poligono.Polygons.Add(poligonoPuntos);
            gMapControl1.Overlays.Add(Poligono);

            // Actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void btn_Ruta_Click(object sender, EventArgs e)
        {
            // Recuperamos los datos de grid y los asignamos a los textbox
            txt_des.Text = dataGridView1.Rows[contador - 2].Cells[0].Value.ToString();
            txt_lat.Text = dataGridView1.Rows[contador - 2].Cells[1].Value.ToString();
            txt_lon.Text = dataGridView1.Rows[contador - 2].Cells[2].Value.ToString();

            double lat = Convert.ToDouble(txt_lat.Text);
            double lng = Convert.ToDouble(txt_lon.Text);
            GMarkerGoogle marker3;
            marker3 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker3);
            marker3.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
            //marker3.ToolTipMode = MarkerTooltipMode.Always;
            marker3.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

            // Se asignan los valores del grid al marcador
            marker.Position = new PointLatLng(lat, lng);

            // Se posiciona el foco del mapa en ese punto
            //gMapControl1.Position = marker.Position;

            GMapOverlay Ruta = new GMapOverlay("Rutas");
            List<PointLatLng> puntos = new List<PointLatLng>();

            // Variables para almacenar los datos. 
            //double lng, lat;

            // Agarramos los datos del grid
            for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }
            GMapRoute rutaPuntos = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(rutaPuntos);
            gMapControl1.Overlays.Add(Ruta);

            // Actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

            DistanciaEuclideana(Diccionario_Cordenadas);
            btn_Ruta.Enabled = false;
            btn_Douglas.Enabled = true;
            ContadorRuta++;
        }

        private void habRuta() {
            if (contador >= 4) {
                btn_poligono.Enabled = true;
                btn_Ruta.Enabled = true;
            }
            else {
                btn_poligono.Enabled = false;
                btn_Ruta.Enabled = false;
                btn_Douglas.Enabled = false;
            }
        }

        private void desRuta()
        {
        
        }

        private void gMapControl1_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            MessageBox.Show("Ruta");
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            MessageBox.Show("Marcador");
        }

        private void gMapControl1_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            MessageBox.Show("Polígono");
        }

        private void gMapControl1_OnPolygonEnter(GMapPolygon item)
        {
            MessageBox.Show("Polígono");
        }

        private void gMapControl1_OnMarkerEnter(GMapMarker item)
        {

        }

        public void DistanciaEuclideana(Dictionary<double,double> Distancias)
        {
            Double LatIn;
            Double LonIn;
            Double R1;
            Double R2;
            Double R1P;
            Double R2P;
            Double DistanciaEuclideana;
            Double KM;
            string[] txt = new string[ContadorDeClik];
           
            int count = 0;
            foreach (var item in Distancias)
            {
                contadorPunto++;
                LatIn = item.Key;
                LonIn = item.Value;

                TreeNode newNode = new TreeNode("Punto " + contadorPunto);


                foreach (var item2 in Distancias)
                {

                    count++;
                    if (count > ContadorDeClik)
                    {
                        count = 1;
                    }

                        R1 = LatIn - item2.Key;
                        R2 = LonIn - item2.Value;
                        R1P = R1*R1;
                        R2P = R2*R2; 
                        DistanciaEuclideana = Math.Pow(R1, 2) + Math.Pow(R2, 2);
                        KM = (Math.Sqrt(DistanciaEuclideana / 2)) * 157.4;
                        //MessageBox.Show("Distancia Euclideana: "+ Math.Round(KM, 2) + "km");
                       dataGridView2.Rows.Add("Punto " + contadorPunto, "Punto " + count, Math.Round(KM, 2));
                    arreglo[c] = KM;
                    //if (ContadorDeClik > c) {
                    //    if (c > 1)
                    //    {
                    //        if (arreglo[c] < arreglo[c - 1])
                    //        {
                    //            // Recuperamos los datos de grid y los asignamos a los textbox
                    //            txt_des.Text = dataGridView1.Rows[c - 1].Cells[0].Value.ToString();
                    //            txt_lat.Text = dataGridView1.Rows[c - 1].Cells[1].Value.ToString();
                    //            txt_lon.Text = dataGridView1.Rows[c - 1].Cells[2].Value.ToString();

                    //            double lat = Convert.ToDouble(txt_lat.Text);
                    //            double lng = Convert.ToDouble(txt_lon.Text);
                    //            GMarkerGoogle marker4;
                    //            marker4 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.yellow);
                    //            markerOverlay.Markers.Add(marker4);
                    //            marker4.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
                    //            //marker3.ToolTipMode = MarkerTooltipMode.Always;
                    //            marker4.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

                    //            // Se asignan los valores del grid al marcador
                    //            marker.Position = new PointLatLng(lat, lng);
                    //        }
                    //        else
                    //        {
                    //            // Recuperamos los datos de grid y los asignamos a los textbox
                    //            txt_des.Text = dataGridView1.Rows[c].Cells[0].Value.ToString();
                    //            txt_lat.Text = dataGridView1.Rows[c].Cells[1].Value.ToString();
                    //            txt_lon.Text = dataGridView1.Rows[c].Cells[2].Value.ToString();

                    //            double lat = Convert.ToDouble(txt_lat.Text);
                    //            double lng = Convert.ToDouble(txt_lon.Text);
                    //            GMarkerGoogle marker4;
                    //            marker4 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.yellow);
                    //            markerOverlay.Markers.Add(marker4);
                    //            marker4.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
                    //            //marker3.ToolTipMode = MarkerTooltipMode.Always;
                    //            marker4.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

                    //            // Se asignan los valores del grid al marcador
                    //            marker.Position = new PointLatLng(lat, lng);
                    //        }
                    //        //double resta = arreglo[c] - arreglo[c-1];
                    //        //MessageBox.Show("Resta: " + resta);
                    //    }
                    //    c++;
                    //}
                    

                }
               

            }

          

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //DistanciaEnKm(Diccionario_Cordenadas);
           
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i <= ContadorDeClik; i++)
            {
                BanderaNumero[i] = i;
            }
            GMapOverlay Ruta = new GMapOverlay("Rutas");
            List<PointLatLng> puntos = new List<PointLatLng>();
            foreach (var item in BanderaNumero)
            {
                if ((item % 2) != 0)
                {
                    int NumerosImpares = item;
                    txt_des.Text = dataGridView1.Rows[item-1].Cells[0].Value.ToString();
                    txt_lat.Text = dataGridView1.Rows[item-1].Cells[1].Value.ToString();
                    txt_lon.Text = dataGridView1.Rows[item-1].Cells[2].Value.ToString();

                    double lat = Convert.ToDouble(txt_lat.Text);
                    double lng = Convert.ToDouble(txt_lon.Text);
                    GMarkerGoogle marker3;
                    marker3 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
                    //markerOverlay.Markers.Add(marker3);
                    //marker3.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
                    ////marker3.ToolTipMode = MarkerTooltipMode.Always;
                    //marker3.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

                    //// Se asignan los valores del grid al marcador
                    //marker.Position = new PointLatLng(lat, lng);

                    // Se posiciona el foco del mapa en ese punto
                    //gMapControl1.Position = marker.Position;

                   

                    // Variables para almacenar los datos. 
                    //double lng, lat;

                    // Agarramos los datos del grid
            
                    puntos.Add(new PointLatLng(lat, lng));
                }

                if (item == ContadorDeClik)
                {
                    int NumerosImpares = item;
                    txt_des.Text = dataGridView1.Rows[item - 1].Cells[0].Value.ToString();
                    txt_lat.Text = dataGridView1.Rows[item - 1].Cells[1].Value.ToString();
                    txt_lon.Text = dataGridView1.Rows[item - 1].Cells[2].Value.ToString();

                    double lat = Convert.ToDouble(txt_lat.Text);
                    double lng = Convert.ToDouble(txt_lon.Text);
                    GMarkerGoogle marker3;
                    marker3 = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
                    //markerOverlay.Markers.Add(marker3);
                    //marker3.Position = new PointLatLng(Convert.ToDouble(txt_lat.Text), Convert.ToDouble(txt_lon.Text));
                    ////marker3.ToolTipMode = MarkerTooltipMode.Always;
                    //marker3.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", txt_lat.Text, txt_lon.Text);

                    //// Se asignan los valores del grid al marcador
                    //marker.Position = new PointLatLng(lat, lng);

                    // Se posiciona el foco del mapa en ese punto
                    //gMapControl1.Position = marker.Position;



                    // Variables para almacenar los datos. 
                    //double lng, lat;

                    // Agarramos los datos del grid

                    puntos.Add(new PointLatLng(lat, lng));
                }

                GMapRoute rutaPuntos = new GMapRoute(puntos, "Ruta");
                Ruta.Routes.Add(rutaPuntos);
                rutaPuntos.Stroke = new Pen(Color.Green,3);
                gMapControl1.Overlays.Add(Ruta);

                // Actualizar el mapa

                ContadorDouglas++;
                btn_Douglas.Enabled = false;
            }
        }
    }
}
