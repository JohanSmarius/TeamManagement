using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Domain
{
    public class CareTaker : IPerson
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }

        public bool HasCar { get; set; }

        public bool HasPassedTrainingScoringTable { get; set; }
    }
}
