using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int ConstructorChampionships { get; set; }

        public int DriverChampionships { get; set; }
    }
}
