using Slovicka_APP.Models;
using SQLite;
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
    public partial class WordsGroup : ContentPage
    {
        Group selectedGroup;

        public WordsGroup(Group selectedGroup)
        {
            InitializeComponent();
            this.selectedGroup = selectedGroup;
            lb_groupName.Text = selectedGroup.GroupName;
            lb_numberOfExercises.Text = selectedGroup.NumberOfExercises.ToString();
            lb_numberOfSuccessRate.Text = selectedGroup.SuccessRate.ToString() + "%";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Translate> translatesList = new List<Translate>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Translate>(); int i = 0;
                var posts = conn.Table<Translate>().ToList();

                while (i < posts.Count)
                {
                    var quest = posts[i];
                    if (quest.GroupName == selectedGroup.GroupName)
                    {
                        translatesList.Add(posts[i]);
                    }
                    i++;
                }

                cv_words.ItemsSource = translatesList;
                lb_numberOfTranslates.Text = translatesList.Count().ToString();
            }
        }

        private void cv_words_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPost = cv_words.SelectedItem as Translate;
            if (selectedPost != null)
            {
                Navigation.PushAsync(new WordsEdit(selectedGroup, selectedPost));
            }
        }

        private void GoToQRCreatePage_Clicked(object sender, EventArgs e)
        {

        }
    }
}