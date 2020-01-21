using System;

namespace db
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");            
            
            using (MyContext db = new MyContext())
            {
                db.Database.EnsureCreated();                
                Console.WriteLine("Hello World 2!");            
            }
        }
    }
}