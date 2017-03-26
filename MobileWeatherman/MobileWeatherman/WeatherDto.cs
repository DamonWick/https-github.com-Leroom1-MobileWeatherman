using System.Collections.Generic;

namespace MobileWeatherman
{
    public class WeatherDto
    {
        public Coordinates coord { get; set; }
        public List<Clouds> weather { get; set; }
        public Wind wind { get; set; }
        public Main main { get; set; }
        public CloudCoverage clouds { get; set; }
        public Sun sys { get; set; }
        public long dt { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public double cod { get; set; }
        
        public WeatherDto()
        {
            coord = new Coordinates();
            weather = new List<Clouds>();
            wind = new Wind();
            main = new Main();
            clouds = new CloudCoverage();
            sys = new Sun();
        }
    }

    public class Coordinates
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Clouds
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class CloudCoverage
    {
        public int all { get; set; }
    }

    public class Sun
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }
}
