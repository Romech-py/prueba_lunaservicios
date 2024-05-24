using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENTS_API.Models
{
    public class Client
    {
        public int id { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string mail { get; set; }
    }
}