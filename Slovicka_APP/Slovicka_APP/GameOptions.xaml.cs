using Slovicka_APP.Models;
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
    public partial class GameOptions : ContentPage
    {

        public GameOptions(List<Translate> gameList, bool translate, string firstLang, string secondLang)
        {
            InitializeComponent();          
        }      
    }
}