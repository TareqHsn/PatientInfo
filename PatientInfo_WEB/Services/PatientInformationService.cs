using Newtonsoft.Json;
using PatientInfo_WEB.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace PatientInfo_WEB.Services
{
    public class PatientInformationService : IPatientInformationService
    {
        private readonly HttpClient _httpClient;

        public PatientInformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Patient>> getAllPatientDetails()
        {
            var res = await _httpClient.GetAsync("/api/Patients");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<PatientDetails>(jsonString);
            
            return deserializedJson.PatientInformations;
        }
        public async Task<List<DiseaseInfo>> getAllDiseases()
        {
            var res = await _httpClient.GetAsync("/api/Diseases");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<Diseases>(jsonString);

            return deserializedJson.DiseaseInformation;
        }

        public async Task<List<NDC>> getAllNCDs()
        {
            var res = await _httpClient.GetAsync("/api/NDCs");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<NCDs>(jsonString);

            return deserializedJson.Ncd;
        }

        public async Task<List<Allergy>> getAllAllergies()
        {
            var res = await _httpClient.GetAsync("/api/Allergies");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<Allergies>(jsonString);

            return deserializedJson.Allergy;
        }

        public async Task<string> postPatientInformation(PatientInformationView patientInformation)
        {
            try
            {

                PatientInfo_WEB.Models.ViewModel.PatientInformationView patientInformationView = new PatientInfo_WEB.Models.ViewModel.PatientInformationView();
                patientInformationView.Epilepsy = patientInformation.Epilepsy;

                foreach (var item in patientInformation.SelectedNCDs)
                {
                    PatientInfo_WEB.Models.ViewModel.NcdView ncdView = new PatientInfo_WEB.Models.ViewModel.NcdView() { Id=item.Id,Details=item.Details };
                    patientInformationView.SelectedNCDs.Add(ncdView);
                }

                foreach (var item in patientInformation.SelectedAllergies)
                {
                    PatientInfo_WEB.Models.ViewModel.AllergyView allergyView = new PatientInfo_WEB.Models.ViewModel.AllergyView() { Id = item.Id, Details = item.Details };
                    patientInformationView.SelectedAllergies.Add(allergyView);
                }
                patientInformationView.DiseaseInformation.Id = patientInformation.DiseaseInformation.Id;
                patientInformationView.DiseaseInformation.Details = patientInformation.DiseaseInformation.Details;
                patientInformationView.Name=patientInformation.Name;


                HttpContent body = new StringContent(JsonConvert.SerializeObject(patientInformationView), Encoding.UTF8, "application/json");
                
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7020/api/PatientDetails/postPatientInformation";

                    string json = JsonConvert.SerializeObject(patientInformationView);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                    }
                }


                return "OK";
            }
            catch (TaskCanceledException)
            {

                throw;
            }
           
        }
    }
}
