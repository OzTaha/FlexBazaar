namespace FlexBazaar.RapidApiWebUI.Models
{
    public class WeatherViewModel
    {

        public class Rootobject
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string city { get; set; }
            public string current_weather { get; set; }
            public string temp { get; set; }
            public string expected_temp { get; set; }
            public string insight_heading { get; set; }
            public string insight_description { get; set; }
            public string wind { get; set; }
            public string humidity { get; set; }
            public string visibility { get; set; }
            public string uv_index { get; set; }
            public string aqi { get; set; }
            public string aqi_remark { get; set; }
            public string aqi_description { get; set; }
            public string last_update { get; set; }
            public string bg_image { get; set; }
        }

    }
}
