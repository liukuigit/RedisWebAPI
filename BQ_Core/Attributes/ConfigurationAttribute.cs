using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BQ.Core.Attributes
{
   public  class ConfigurationAttribute:Attribute
    {
       public string Key { get; set; }
    }
}
