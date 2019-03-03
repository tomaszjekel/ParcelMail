using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_GoogleAuth.Models
{
    public class Orders
    {
        [JsonIgnore]
        public string BasicInfo => $"{Name} {Surname} - {Age}";
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public long Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
    }

