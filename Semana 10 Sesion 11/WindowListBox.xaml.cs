using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Session11
{
    public partial class WindowListBox : Window
    {
        public WindowListBox()
        {
            InitializeComponent();
            CargarDatosPredefinidos();
        }

        private void CargarDatosPredefinidos()
        {
            List<Juego> juegos = new List<Juego>();
            juegos.Add(new Juego { Eq1 = "Barcelona", Eq2 = "Real Madrid", Puntaje1 = 2, Puntaje2 = 3, Progreso = 20 });
            juegos.Add(new Juego { Eq1 = "PSG", Eq2 = "Borusia Dortmund", Puntaje1 = 1, Puntaje2 = 3, Progreso = 50 });
            juegos.Add(new Juego { Eq1 = "Man United", Eq2 = "Man City", Puntaje1 = 2, Puntaje2 = 2, Progreso = 90 });
            lbJuego.ItemsSource = juegos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbJuego.SelectedItem != null)
            {
                MessageBox.Show($"Juego seleccionado: {(lbJuego.SelectedItem as Juego).Eq1} vs {(lbJuego.SelectedItem as Juego).Eq2} ");
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"; // Filtro solo para archivos de texto
            if (openFileDialog.ShowDialog() == true)
            {
                string rutaArchivo = openFileDialog.FileName;
                if (File.Exists(rutaArchivo))
                {
                    List<Juego> juegos = new List<Juego>();
                    string[] lineas = File.ReadAllLines(rutaArchivo);
                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length == 5)
                        {
                            int progreso;
                            if (int.TryParse(datos[4], out progreso))
                            {
                                juegos.Add(new Juego
                                {
                                    Eq1 = datos[0],
                                    Puntaje1 = int.Parse(datos[1]),
                                    Puntaje2 = int.Parse(datos[2]),
                                    Eq2 = datos[3],
                                    Progreso = progreso
                                });
                            }
                        }
                    }
                    lbJuego.ItemsSource = juegos;
                }
                else
                {
                    MessageBox.Show("El archivo especificado no existe.");
                }
            }
            else
            {
                MessageBox.Show("Error al seleccionar el archivo.");
            }
        }
    }
}
