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
    public partial class GroupsEdit : ContentPage
    {
        List<string> Lang = new List<string>() { "Anglicky", "Česky", "Francouzsky", "Italsky", "Německy", "Polsky", "Slovensky", "Španělsky" };

        public GroupsEdit()
        {
            InitializeComponent();
            pk_firstLang.ItemsSource = Lang;
            pk_secondLang.ItemsSource = Lang;
        }

        private void btn_update_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {
            
        }

    }
}