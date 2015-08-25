using System.Collections.Generic;

namespace ShipAnalsys.Models
{
    public class ShipList
    {
        public int Id { get; set; }
        public string name { get; set; }

        public List<ShipData> ShipDatas { get; set; }
    }
}