using Microsoft.AspNetCore.Mvc;

namespace z_1_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("�������� ������");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("������ ��������!!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string Get(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "�������� ������!";
            }

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int Get(string name)
        {
            int result = 0;

            foreach (var item in Summaries)
            {
                if (item == name)
                    result++;
            }

            return result;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            var forsort = new List<string>();
            foreach (var item in Summaries)
                forsort.Add(item);

            switch (sortStrategy)
            {
                case null:
                    return Ok(Summaries);
                case 1:
                    forsort.Sort();
                    return Ok(forsort);
                case -1:
                    forsort.Sort();
                    forsort.Reverse();
                    return Ok(forsort);
                default:
                    return BadRequest("������������ �������� ���������");
            }
        }

        
    }
}