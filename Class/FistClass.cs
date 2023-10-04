using Newtonsoft.Json;
using System.Net;

namespace TestDeveloper.Class
{
    public static class FistClass
    {
        public static List<int> bodyTemperature(string doctorName, int diagnosisId)
        {
            List<int> result = new List<int>();
            var page = 1;
            var total_pages = 0;

            while (true)
            {
                var uri = new Uri(string.Format("https://jsonmock.hackerrank.com/api/medical_records?page={0}", page));
                var request = WebRequest.Create(uri);
                request.Method = "GET";

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();

                var reader = new StreamReader(webStream);
                var response = JsonConvert.DeserializeObject<Estrutura>(reader.ReadToEnd());
                total_pages = response.total_pages;
                var data = response.Data.Where(c => c.diagnosis.id.Equals(diagnosisId)
                                    && c.doctor.name.ToUpper().StartsWith(doctorName.ToUpper())
                                   ).ToList();
                if (data.Count > 0)
                {
                    for (int i = 0; i < data.Count(); i++)
                    {
                        result.Add(Convert.ToInt32(data[i].vitals.bodyTemperature));                        
                    };
                    break;
                }
                page++;
                if (page > total_pages)
                { break; }
            };
            return result;
        }
    }
    public class EstruturaResult
    {
        public int id { get; set; }        
        public decimal bodyTemperature { get; set; }
    }
    public class Estrutura
    {
       public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<EstruturaData> Data { get; set; }
    }

    public class EstruturaData
    {
        public int id { get; set; }
        public string timestamp { get; set; }
        public EstruturaDiagnosis diagnosis { get; set; }
        public EstruturaVitals vitals { get; set; }
        public EstruturaDoctor doctor { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string userDob { get; set; }
        public EstruturaMeta meta { get; set; }
    }
    public class EstruturaDiagnosis
    {
        public int id { get; set; }
        public string name { get; set; }
        public int severity {get; set; }    
    }
    public class EstruturaVitals
    {
        public int bloodPressureDiastole { get; set; }
        public int bloodPressureSystole { get; set; }
        public int pulse { get; set; }
        public int breathingRate { get; set; }
        public decimal bodyTemperature { get; set; }
    }

    public class EstruturaDoctor
    {        
        public int id { get; set; }
        public string name { get; set; }
    }
    public class EstruturaMeta
    {
        public int height { get; set; }
        public int weight { get; set; }
    }
}
