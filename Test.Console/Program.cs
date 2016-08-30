
using System.Linq;
using System.Collections.Generic;
using System;
using Entity;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {


            using (EvdekiHesapContext _repo = new EvdekiHesapContext())
            {
                User user = null;
                try
                {
                    user = _repo.Users.Where(x=>x.UserName == "ilhan" && x.PassWord == "123").FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw;
                }


                
            }


            System.Console.ReadLine();

        }
    }
}
