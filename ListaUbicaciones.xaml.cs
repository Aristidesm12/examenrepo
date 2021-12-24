using recuperacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace recuperacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUbicaciones : ContentPage
    {
        public ListaUbicaciones()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            int numero = await App.GetInstanceDB.GetCount();
            if(numero<=0)
            {
                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "Prueba 1",
                    DescripcionLarga = "Prueba 1",
                    Latitud = 15.545519,
                    Longitud = -88.001749
                });

                
            }
          
            UbicacionesLista.ItemsSource = await App.GetInstanceDB.GetAllUbications();
        }

        private async void OnDelete_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var ubicacionSeleccionada = mi.CommandParameter as Ubicacion;
            
            bool confirmacion = await DisplayAlert("", "DATOS SE BORRARAN", "ACEPTAR", "CANCELAR ");
            if (confirmacion)
            {
               await App.GetInstanceDB.DeleteUbication(ubicacionSeleccionada);
                await DisplayAlert("DATOS BORRADOS" ,"ACTUALICE PARA MIRAR LOS CAMBIOS", "ACEPTAR");
            }
  
        }

        private async void UbicacionesLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ubicacionSeleccionada = e.Item as Ubicacion;

            await Navigation.PushAsync(new MapPage(ubicacionSeleccionada));
        }

        private async void tbiNuevaUbicacion_Clicked(object sender, EventArgs e)
        {
            
            
               await Navigation.PopAsync();
            Navigation.PushAsync(new MainPage());
        }
    }
}