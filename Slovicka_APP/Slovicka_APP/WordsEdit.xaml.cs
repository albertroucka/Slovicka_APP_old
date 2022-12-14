﻿using Slovicka_APP.Models;
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
    public partial class WordsEdit : ContentPage
    {
        Group selectedGroup; Translate selectedTranslate;

        public WordsEdit(Group selectedGroup, Translate selectedTranslate)
        {
            InitializeComponent();
            this.selectedGroup = selectedGroup;
            this.selectedTranslate = selectedTranslate;
            ent_firstWord.Text = selectedTranslate.FirstWord;
            ent_secondWord.Text = selectedTranslate.SecondWord;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Group>();
                var groups = conn.Table<Group>().ToList();
                pk_group.ItemsSource = groups;
                pk_group.Title = selectedGroup.GroupName;
            }
        }

        private void btn_update_Clicked(object sender, EventArgs e)
        {
            selectedTranslate.FirstWord = ent_firstWord.Text;
            selectedTranslate.SecondWord = ent_secondWord.Text;
            if (pk_group.SelectedItem != null)
            {
                int index = pk_group.SelectedIndex;
                selectedTranslate.GroupName = pk_group.Items[index];
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Translate>();
                int rows = conn.Update(selectedTranslate);
                if (rows > 0)
                {
                    DisplayAlert("Úspěch", "Překlad byl úspěšně změněn!", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Chyba", "Překlad se nepovedlo změnit!", "Ok");
                }
            }
        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Translate>();
                int rows = conn.Delete(selectedTranslate);
                if (rows > 0)
                {
                    DisplayAlert("Úspěch", "Překlad byl úspěšně smazán!", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Chyba", "Překlad se nepovedlo smazat!", "Ok");
                }
            }
        }
    }
}