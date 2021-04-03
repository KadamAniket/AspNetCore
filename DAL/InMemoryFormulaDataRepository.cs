using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class InMemoryFormulaDataRepository : IFormulaDataRepository
    {
        List<Team> _teams;
        public InMemoryFormulaDataRepository()
        {
            _teams = new List<Team>
            {
                new Team{ Id = 1, Name="Ferrari",Location="Italy",ConstructorChampionships = 12, DriverChampionships = 9},
                new Team{ Id = 2, Name="Mclaren",Location="Uk",ConstructorChampionships = 2, DriverChampionships = 3},
                new Team{ Id = 3, Name="Mercedes",Location="Germany",ConstructorChampionships = 6, DriverChampionships = 6},
                new Team{ Id = 4, Name="Renault",Location="Enstone",ConstructorChampionships = 2, DriverChampionships = 2}
            };
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }

        public Team GetTeamById(int id)
        {
            return _teams.FirstOrDefault(m => m.Id == id);
        }
    }
}
