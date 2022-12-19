using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Slovicka_APP.Models
{
    public interface IFirestore
    {
        Task<bool> Insert(Group group);
        Task<bool> Update(Group group);
        Task<bool> Delete(Group group);
        Task<List<Group>> Read();
    }

    public class Firestore
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static async Task<bool> Insert(Group group) 
        {
            return await firestore.Insert(group);
        }

        public static async Task<bool> Update(Group group)
        {
            return await firestore.Update(group);
        }

        public static async Task<bool> Delete(Group group)
        {
            return await firestore.Delete(group);
        }

        public static async Task<List<Group>> Read(Group group)
        {
            return await firestore.Read();
        }
    }
}
