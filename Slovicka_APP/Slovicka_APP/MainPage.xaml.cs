using Slovicka_APP.Models;
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
        MainClass mainClass = new MainClass();

        public MainPage()
        {
            InitializeComponent();
            btn_account.Text = mainClass.GetUserName();
            btn_trophies.Text = mainClass.GetUserTrophiesCount();
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
