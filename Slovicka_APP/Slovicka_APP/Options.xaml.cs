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
    public partial class Options : ContentPage
    {
        List<string> Practise = new List<string>() { "Překlad slov", "Výběr z možností", "Kartičky" };

        public Options()
        {
            InitializeComponent();
            pk_exercise.ItemsSource = Practise;
        }

        private void btn_Start_Clicked(object sender, EventArgs e)
        {
            if (pk_exercise.SelectedItem != null)
            {
                int ind = pk_exercise.SelectedIndex;
                string exercise = pk_exercise.Items[ind];

                if (exercise == "Překlad slov")
                {
                    Navigation.PushAsync(new GameTranslate());
                }
                else if (exercise == "Výběr z možností")
                {
                    Navigation.PushAsync(new GameOptions());
                }
                else if(exercise == "Kartičky")
                {
                    Navigation.PushAsync(new GameCards());
                }
            }
            else
            {
                DisplayAlert("Chyba", "Musíte vybrat typ procvičení!", "Ok");
            }

        }
    }
}