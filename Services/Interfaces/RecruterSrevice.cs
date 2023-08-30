using System.Collections;
using RecruterWebApp.Controllers;
using RecruterWebApp.Models;

namespace RecruterWebApp.Services.Interfaces;

public interface RecruterSrevice
{
    public Recruter GetData();
    public List<Vacancy> GetAllVacancies();
    public Vacancy GetDataForVacancy();
    public Recruter UpdateData(UpdateRecruterDAO updateRecruterDao);
    public Recruter DeleteProfile(long id);
}