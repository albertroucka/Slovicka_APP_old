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
    public partial class WordsAdd : ContentPage
    {
        public WordsAdd()
        {
            InitializeComponent();
        }

        private void btn_save_Clicked(object sender, EventArgs e)
        {
            //Pouze provizorní umístění, jinak bude fungovat při kliku na ListView Item
            Navigation.PushAsync(new WordsGroup());
        }

    }
}