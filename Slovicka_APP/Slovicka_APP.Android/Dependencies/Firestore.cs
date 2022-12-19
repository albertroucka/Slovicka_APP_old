using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using Slovicka_APP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//[assembly: Dependency(typeof(Slovicka_APP.Droid.Dependencies.Firestore))]
namespace Slovicka_APP.Droid.Dependencies
{
    public class Firestore : IFirestore, IOnCompleteListener
    {
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        List<Group> groups; bool hasReadGroups = false;

        public Firestore() 
        {
            groups= new List<Group>();
        }

        public async Task<bool> Insert(Group group)
        {
            try
            {
                var groupDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"userId", group.UserId },
                    {"groupName", group.GroupName },
                    {"firstLang", group.FirstLang },
                    {"secondLang", group.SecondLang },
                    {"numberOfExercises", group.NumberOfExercises },
                    {"successRate", group.SuccessRate },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("groups");
                collection.Add(new HashMap(groupDocument));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Group group)
        {
            try
            {
                var groupDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"userId", group.UserId },
                    {"groupName", group.GroupName },
                    {"firstLang", group.FirstLang },
                    {"secondLang", group.SecondLang },
                    {"numberOfExercises", group.NumberOfExercises },
                    {"successRate", group.SuccessRate },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("groups");
                collection.Document(group.Id).Update(groupDocument);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Group group)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("groups");
                collection.Document(group.Id).Delete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Group>> Read()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("groups");
                var query = collection.WhereEqualTo("userId", users[0].Id);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasReadGroups) { break; }
                }
                return groups;
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;
                groups.Clear();

                foreach (var item in documents.Documents)
                {
                    Group group = new Group()
                    {
                        UserId = item.Get("userId").ToString(),
                        GroupName = item.Get("groupName").ToString(),
                        FirstLang = item.Get("firstLang").ToString(),
                        SecondLang = item.Get("secondLang").ToString(),
                        NumberOfExercises = (int)item.Get("numberOfExercises"),
                        SuccessRate = (double)item.Get("successRate")
                    };
                    groups.Add(group);
                }
            }
            else
            {
                groups.Clear(); 
            }

            hasReadGroups = true;
        }

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromRuntime()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}