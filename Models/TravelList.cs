﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CarTravel.Models
{
    public class TravelList
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Destination { get; set; }
    }
}
