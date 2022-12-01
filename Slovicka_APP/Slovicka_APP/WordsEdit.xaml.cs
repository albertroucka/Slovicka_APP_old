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
    public partial class WordsEdit : ContentPage
    {

        public WordsEdit()
        {
            InitializeComponent();
        }       

        private void btn_update_Clicked(object sender, EventArgs e)
        {
            //Provorní odkaz
            Navigation.PushAsync(new QRCodeGenerator());
        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}