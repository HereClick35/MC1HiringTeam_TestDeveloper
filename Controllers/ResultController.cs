using Microsoft.AspNetCore.Mvc;
using TestDeveloper.Class;

namespace TestDeveloper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : Controller
    {
        [HttpGet(Name = "bodyTemperature")]
        public List<int> bodyTemperature(string doctorName, int diagnosisId)
        {

            var response = FistClass.bodyTemperature(doctorName, diagnosisId);
            return response;
        }
    }
}
