using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public interface IPerson
    {
        string Name { get; set; }
        string EmailAddress { get; set; }
    }
}
