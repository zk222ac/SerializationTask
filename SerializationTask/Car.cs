using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    [Serializable]
   public class Car
    {
        public string Model { get; set; }
        public string RegNo { get; set; }

        public Owner Owner { get; set; }

        public Car(string model, string regNo, Owner owner)
        {
            Model = model;
            RegNo = regNo;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Model no : {Model}- Reg No: {RegNo} - Owner --> Id : {Owner.Id} , Name --> {Owner.Name} -->";
        }
    }
}
