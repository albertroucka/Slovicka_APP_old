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
    public partial class WordsGroup : ContentPage
    {

        public WordsGroup()
        {
            InitializeComponent();
        }     

        private void GoToQRCreatePage_Clicked(object sender, EventArgs e)
        {
            //Provizorní řešení
            Navigation.PushAsync(new WordsEdit());
        }
    }
}