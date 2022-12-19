using Firebase.Auth;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slovicka_APP.Models
{
    class MainClass
    {

        public string GetUserName()
        {
            //FirebaseSignIn();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();

                if (users.Count > 0)
                {
                    return users[0].UserName;
                }
                else
                {
                    return "Nepřihlášen";
                }
            }
        }

        public string GetUserTrophiesCount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();

                if (users.Count > 0)
                {
                    return users[0].NumberOfTrophies.ToString();
                }
                else
                {
                    return "123";
                }
            }
        }

        public User GetUser()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();

                if (users.Count > 0)
                {
                    return users[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool UpdateUserStats(int trophiesCount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                User user = GetUser();

                if (user != null)
                {
                    user.NumberOfTrophies = user.NumberOfTrophies + trophiesCount;
                    conn.CreateTable<User>();
                    int rows = conn.Update(user);
                    if (rows > 0)
                    {
                        return false;
                    }
                    else
                    {
                        
                    }
                }
                return true;
            }
        }

        public List<string> GetAllExerciseTypes()
        {
            List<string> allExercises = new List<string>() { "Překlad slov", "Výběr z možností", "Kartičky" };
            return allExercises;
        }

        public List<string> GetAllLanguages()
        {
            List<string> Lang = new List<string>() { "Anglicky", "Česky", "Německy" };
            return Lang;
        }


        public async void FirebaseSingUp()
        {
            string WebAPIkey = "AIzaSyDcNoIRjoK7vdlwK5_hJcCTjwon27x4nK8";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync("admin@slovicka.cz", "Admin123");
                string getToken = auth.FirebaseToken;

            }
            catch (FirebaseAuthException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void FirebaseSignIn()
        {
            string WebAPIkey = "AIzaSyDcNoIRjoK7vdlwK5_hJcCTjwon27x4nK8";
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync("admin@slovicka.cz", "Admi123");
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
