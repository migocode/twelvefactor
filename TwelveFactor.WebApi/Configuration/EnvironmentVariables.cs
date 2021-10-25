using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwelveFactor.WebApi.Configuration
{
    public class EnvironmentVariables
    {
        public string DbConnectionString { get; set; }
        public string DbName { get; set; }
    }
}
