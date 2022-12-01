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
    public partial class GroupsAdd : ContentPage
    {
        List<string> Lang = new List<string>() { "Anglicky", "Česky", "Francouzsky", "Italsky", "Německy", "Polsky", "Slovensky", "Španělsky" };

        public GroupsAdd()
        {
            InitializeComponent();
            pk_firstLang.ItemsSource = Lang;
            pk_secondLang.ItemsSource = Lang;
        }

        private void btn_saveGroup_Clicked(object sender, EventArgs e)
        {
            //Provizorní odkaz
            Navigation.PushAsync(new GroupsEdit());
        }

        private void lv_groups_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void GoToQRScannerPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRCodeScanner());
        }
    }
}