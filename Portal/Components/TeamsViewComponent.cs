using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Components;

public class TeamsViewComponent : ViewComponent
{
    private readonly ITeamRepository _teamRepository;

    public TeamsViewComponent(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
    }
    
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedTeam = RouteData?.Values["team"];
        var teams = _teamRepository.GetTeams()
            .Select(team => team.Name)
            .Distinct()
            .OrderBy(x => x).AsEnumerable();

        return View(teams);
    }
}