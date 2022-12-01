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
    public partial class GameTranslate : ContentPage
    {

        public GameTranslate()
        {
            InitializeComponent();          
        }

        private void btn_confirm_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Result());
        }
    }
}