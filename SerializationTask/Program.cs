using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTask
{
    class Program
    {
        private static readonly IFormatter _bf = new BinaryFormatter();
        private static Stream _stream;
        public static string PathOwner = @"C://Ser/owner.txt";
        public static List<Owner> ListOwners = new List<Owner>()
        {
            new Owner("123" , "Hairy"),
            new Owner("345", "Henri")
        };
        public static List<Car> ListCars = new List<Car>()
        {
            new Car("Audi" , "AEDT123" , ListOwners[0] ),
            new Car("Citron", "SJDH3546" , ListOwners[1])
        };
        static void Main(string[] args)
        {
            
            // List of owners ............................................................
           
            // Serialization
            // call file stream derived class through Base class Stream object : Polymorphic behaviour 
            using (_stream = new FileStream(PathOwner, FileMode.Create, FileAccess.Write))
            {
                _bf.Serialize(_stream, ListOwners);
            }
            // Deserialization 
            using (_stream = new FileStream(PathOwner, FileMode.Open, FileAccess.Read))
            {
               ListOwners  =  _bf.Deserialize(_stream) as List<Owner>;
            }

            // Display 
            if (ListOwners != null)
                foreach (var owner in ListOwners)
                {
                    Console.WriteLine(owner);
                }


            // List of Cars .......................................................

            // Serialization
            // call file stream derived class through Base class Stream object : Polymorphic behaviour 
            using (_stream = new FileStream(PathOwner, FileMode.Create, FileAccess.Write))
            {
                _bf.Serialize(_stream, ListCars);
            }
            // Deserialization 
            using (_stream = new FileStream(PathOwner, FileMode.Open, FileAccess.Read))
            {
                ListCars = _bf.Deserialize(_stream) as List<Car>;
            }

            // Display 
            if (ListCars != null)
                foreach (var car in ListCars)
                {
                    Console.WriteLine(car);
                }

            List<object> obj = new List<object> {ListCars, ListOwners};

            using (_stream = new FileStream(PathOwner, FileMode.Create, FileAccess.Write))
            {
                _bf.Serialize(_stream, obj);
            }

            // Deserialization 
            using (_stream = new FileStream(PathOwner, FileMode.Open, FileAccess.Read))
            {
                obj = _bf.Deserialize(_stream) as List<object>;
            }

            if (obj != null)
                

            Console.ReadKey();

          
        }

       
    }
}
