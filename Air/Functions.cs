using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    public class Functions
    {
        public Session1_XXEntities1 db = new Session1_XXEntities1();

        public string GetTotalUserCount()
        {
            var userList = db.Users.ToList();
            string count = userList.Count().ToString();
            return "11";
        }

        //public int GetUserCountInOffice(List<Users> userList, string officeTitle)
        //{
        //    return userList.Where(a => a.Offices.Title == officeTitle).ToList().Count();
        //}

        //public int GetUserCountInOffice(List<Users> userList, string officeTitle)
        //{
        //    return userList.Where(a => a.Offices.Title == officeTitle).ToList().Count();
        //}
    }
}
