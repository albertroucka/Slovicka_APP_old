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
    public partial class Result : ContentPage
    {
        public Result(int points, List<Translate> wrongAnswers)
        {
            InitializeComponent();
            lb_score.Text = $"Skóre: {points}/10";
            double successRate = Convert.ToDouble(points) / 10 * 100;
            lb_successRate.Text = $"Úspěšnost: {successRate}%";
            SetTrophies(successRate);
            cv_answers.ItemsSource = wrongAnswers;
        }

        private void SetTrophies(double successRate)
        {
            int trophiesCount;

            if (successRate > 85)
            {
                trophiesCount = 3;
                img_trophy0.Source = "trophy.png";
                img_trophy1.Source = "trophy.png";
                img_trophy2.Source = "trophy.png";
            }
            else if (successRate > 55)
            {
                trophiesCount = 2;
                img_trophy0.Source = "trophy.png";
                img_trophy1.Source = "trophy.png";
                img_trophy2.Source = "trophy_gray.png";
            }
            else if (successRate > 25)
            {
                trophiesCount = 1;
                img_trophy0.Source = "trophy.png";
                img_trophy1.Source = "trophy_gray.png";
                img_trophy2.Source = "trophy_gray.png";
            }
            else
            {
                trophiesCount = 0;
                img_trophy0.Source = "trophy_gray.png";
                img_trophy1.Source = "trophy_gray.png";
                img_trophy2.Source = "trophy_gray.png";
            }

            //přidání trofejí do uživatelského účtu
            //trophiesCount
        }

        private void btn_PlayAgin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Options());
        }

        private async void btn_MainMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}