using Newtonsoft.Json;
using SchoolingSystem.Models.Etudiants;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SchoolingSystem.Managers.ApiManagers
{
    public partial class ApiManager
    {
        private HttpClient httpClient;

        public ApiManager()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:31954")
            };
        }

        public List<Etudiant> GetEtudiants()
        {
            var response = httpClient.GetAsync("api/Etudiants").Result;
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Etudiant>>(apiResponse);
        }

        public Etudiant GetEtudiantById(string id)
        {
            var response = httpClient.GetAsync($"api/Etudiants/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Etudiant>(apiResponse);
            }
            else return null;
        }

        public async void CreateEtudiant(Etudiant etudiant)
        {
            var content = new StringContent(JsonConvert.SerializeObject(etudiant));
            await httpClient.PostAsync("/api/etudiants", content);
        }
    }
}