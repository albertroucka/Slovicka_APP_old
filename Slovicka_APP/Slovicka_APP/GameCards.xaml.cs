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
    public partial class GameCards : ContentPage
    {

        public GameCards()
        {
            InitializeComponent();
        }       

        private void btn_card_Clicked(object sender, EventArgs e)
        {
            if (btn_card.BackgroundColor == Color.FromHex("#2196F3"))
            {
                btn_card.BackgroundColor = Color.FromHex("#FFFFFF");
                btn_card.TextColor = Color.FromHex("#2196F3");
            }
            else
            {
                btn_card.BackgroundColor = Color.FromHex("#2196F3");
                btn_card.TextColor = Color.FromHex("#FFFFFF");
            }
        }

        private void btn_back_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btn_next_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}