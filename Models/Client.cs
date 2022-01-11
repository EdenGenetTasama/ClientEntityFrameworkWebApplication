using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string ClientName { get; set; }
        public string ClientNameLast { get; set; } 
        

    }
}