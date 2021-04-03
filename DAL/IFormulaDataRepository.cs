using Domain;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IFormulaDataRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamById(int id);
    }
}
