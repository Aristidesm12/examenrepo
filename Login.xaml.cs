using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recuperacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text=="Admin" && txtPassword.Text == "111")
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("", "", "Ok");
            }
        }
    }
}