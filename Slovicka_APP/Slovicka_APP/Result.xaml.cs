using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slovicka_APP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        public Result()
        {
            InitializeComponent();
        }

        private void btn_PlayAgin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Options());
        }

        private async void btn_MainMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}