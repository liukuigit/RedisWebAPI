using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BQ.Core.Configurations
{
    public static class KinaConfigurationExtensions
    {
        public static KinaConfiguration CreateKina(this Configuration configuration)
        {
            return KinaConfiguration.CreateKina();
        }
    }
}
