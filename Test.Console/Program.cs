using Entity;
using System.Linq;
using System.Collections.Generic;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new Model1())
            {

                var results = new List<ExpenseIncome>();
        results = (from ex in db.ExpenseIncomes orderby ex.ID descending select ex).ToList();
            //    var resultsOfUserGroup = new List<User>();
            //    resultsOfUserGroup = (from ex in db.Users orderby ex.ID descending select ex).Take(10).ToList();

            //    //var myusers = new List<User>();
            //    //myusers = (from ex in db.Users orderby ex.ID descending select ex).ToList();
            //    //var group = myusers[0].UserGroup;




            }


            System.Console.ReadLine();

        }
    }
}
