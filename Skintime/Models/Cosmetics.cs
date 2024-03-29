﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Skintime.Models
{
    public class Cosmetics
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("ingredient_list")]
        public List<string> ingredient_list { get; set; }
        
    } 

}
