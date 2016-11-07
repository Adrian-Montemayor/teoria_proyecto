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
using System.IO;

namespace Teorioa
{
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markeroverlay;
        double LatIn = 25.6667;
        double longIn = -100.3167;
        bool Stop2, Stop3, Stop4, Stop5, Stop6, Stop7, Stop8,stop9 = false;
    


        //marcador de rutas
        bool trazarRuta;
        int ContadorInicial = 0;
        PointLatLng inicio,PA,PB,PC,PD,PE,PF,PG,PH,final;
        Dictionary<double, double> DictionaryPointLTLn = new Dictionary<double, double>();

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next(19, 32);

            Random r2 = new Random();
            int nums = r.Next(89, 103);

            double latsec = num + .7188232818747;
            double longsec = -+nums + .30414581298828;

            const string input = "generando Bytes";
            byte[] array = Encoding.ASCII.GetBytes(input);
            //Siempre se muestra el marcador

            marker.ToolTipText = Convert.ToString("DFG$^%^UYHR@#D") + array.Length;
            gMapControl1.Overlays.Add(markeroverlay);


            List<PointLatLng> points = new List<PointLatLng>();
            foreach (var item in DictionaryPointLTLn)
            {
                points.Add(new PointLatLng(item.Key, item.Value));
                GMapRoute route = new GMapRoute(points, "A walk in the park");
                route.Stroke = new Pen(Color.Red, 3);
                markeroverlay.Routes.Add(route);
            }
            
            
            gMapControl1.Overlays.Add(markeroverlay);

        }

        string Colores;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatIn, longIn);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;

            markeroverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatIn, longIn), new Bitmap(@"C:\Users\jose_\OneDrive\Documentos\Visual Studio 2015\Projects\Teorioa\Teorioa\1477907324_vector_66_13.png"));
            markeroverlay.Markers.Add(marker); //Agregamos al marcador.

            marker.ToolTipMode = MarkerTooltipMode.Always; //Siempre se muestra el marcador
            marker.ToolTipText = "Servidor"; // agrego el texto

            //agregor el mapa y el marcador al map control
            gMapControl1.Overlays.Add(markeroverlay);
          

        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next(19, 32);

            Random r2 = new Random();
            int nums = r.Next(89, 103);

            double latsec = num + .7188232818747;
            double longsec = -+nums + .30414581298828;

            const string input = "generando Bytes";
            byte[] array = Encoding.ASCII.GetBytes(input);
             //Siempre se muestra el marcador
            
            marker.ToolTipText = Convert.ToString("DFG$^%^UYHR@#D") + array.Length;
            gMapControl1.Overlays.Add(markeroverlay);


            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(LatIn, longIn));
            points.Add(new PointLatLng(latsec, longsec));

            GMapRoute route = new GMapRoute(points, "A walk in the park");
            route.Stroke = new Pen(Color.Red, 3);
            markeroverlay.Routes.Add(route);
            gMapControl1.Overlays.Add(markeroverlay);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //obtener la latitud donde el usuario le da doble clic
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lon = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            //Paso los parametros segun sea el caso Maximo 10 clics
            TrazarDireccionRuta(lat, lon,4);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trazarRuta = true;

        }

        public void TrazarDireccionRuta(double lat, double lng, int NumberOfROutes)
        {
            BanderaStop();
            switch (ContadorInicial)
            {
                case 0:
                    ContadorInicial++;
                    marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green);
                    markeroverlay.Markers.Add(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    DictionaryPointLTLn.Add(lat, lng);
                    break;
                case 1:
                    ContadorInicial++;
                    marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                    markeroverlay.Markers.Add(marker);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    DictionaryPointLTLn.Add(lat, lng);
                    break;
                case 2:
                  
                  
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                        break;
                
                case 3:
                  
       
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    
                  
                    break;
                case 4:
                    if (Stop3 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    }
                      
                    
                    
                    break;
                case 5:
                    if (Stop4 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    }
                    ContadorInicial++;
                  
                    break;
                case 6:
                    if (Stop5 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    }
                    
                    break;
                case 7:
                    if (Stop6 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    }
                   
                    break;
                case 8:
                    if (Stop7 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);
                    }
                   
                    break;
                case 9:
                    if (Stop8 == true)
                    {
                        MessageBox.Show("Se llego al limite de Marcadores");
                    }
                    else
                    {
                        ContadorInicial++;
                        marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red);
                        markeroverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        DictionaryPointLTLn.Add(lat, lng);

                        MarcarLineal(DictionaryPointLTLn);
                    }
                  
                    break;
                   
            }
        }

        public void MarcarLineal(Dictionary<double,double> Points)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            foreach (var item in Points)
            {
                points.Add(new PointLatLng(item.Key, item.Value));
                GMapRoute route = new GMapRoute(points, "Maracador de Rutas");
                route.Stroke = new Pen(Color.Red, 3);
                markeroverlay.Routes.Add(route);
              
            }
            gMapControl1.Overlays.Add(markeroverlay);

        }

        public void BanderaStop()
        {
          
            if (Convert.ToInt32(CantidadCMB.Text) == 3)
            {
                Stop3 = true;
            }
            if (Convert.ToInt32(CantidadCMB.Text) == 4)
            {
                Stop4 = true;
            }
            if (Convert.ToInt32(CantidadCMB.Text) == 5)
            {
                Stop5 = true;
            }
            if (Convert.ToInt32(CantidadCMB.Text) == 6)
            {
                Stop6 = true;
            }
            if (Convert.ToInt32(CantidadCMB.Text) == 7)
            {
                Stop7 = true;
            }
            if (Convert.ToInt32(CantidadCMB.Text) == 8)
            {
                Stop8 = true;
            }
        }
    }
}
