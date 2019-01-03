using System;
using Challenge.Core.Functions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Challenge.Models;

namespace Challenge.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task<List<GroupedPets>> callTask = Task.Run(() => new PeoplePetsFunctions().GetGroupedPetsAsync("cat", "name"));
                callTask.Wait();

                foreach (var records in callTask.Result)
                {
                    Console.WriteLine(records.Heading);
                    foreach (var pet in records.Records)
                    {
                        Console.WriteLine(String.Format("- {0} ({1})", pet.Name, pet.Type));
                    }
                }
            }
            catch (Exception ex)  //Exceptions here or in the function will be caught here
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
