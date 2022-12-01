using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Slovicka_APP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_practise_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Options());
        }

        private void btn_wordsAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WordsAdd());
        }

        private void btn_groupsAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GroupsAdd());
        }
    }
}
