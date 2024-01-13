using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CarTravel.Models
{
    public class ListPlace
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        [ForeignKey(typeof(TravelList))]
        public int TravelListID { get; set; }
        public int PlaceID { get; set; }
    }
}
