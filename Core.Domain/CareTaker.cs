using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Domain
{
    public class CareTaker
    {
        public string Name { get; set; }

        public string EMailAddress { get; set; }

        public int PhoneNumber { get; set; }

        public bool HasCar { get; set; }

        public bool HasPassedTrainingScoringTable { get; set; }
    }
}
