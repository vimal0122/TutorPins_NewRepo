﻿using DataAccess.Data;
using Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class TutorService : ITutorService
    {
        private readonly HttpClient _client;
        public TutorService(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> CreateTutor(TutorDto tutorDto)
        {
            try
            {
                //string rootpath = AppContext.BaseDirectory.Replace("bin\\Debug\\net6.0\\", "");
                //string path = System.IO.Path.Combine(rootpath, Guid.NewGuid().ToString() + "_" + tutorDto.TutorImage);
                //FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                //await tutorDto.TutorImageStream.CopyToAsync(filestream);
                //filestream.Close();
                var dataString = JsonConvert.SerializeObject(tutorDto);
                var content = new StringContent(dataString);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _client.PostAsync($"api/tutor/AddTutor", content);
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {

            }
            return true;
        }

        public async Task<IEnumerable<TutorDto>> GetAllTutors()
        {
            var response = await _client.GetAsync($"api/tutor/GetTutors");
            var content = await response.Content.ReadAsStringAsync();
            var tutors = JsonConvert.DeserializeObject<IEnumerable<TutorDto>>(content);
            return tutors;
        }

        public async Task<TutorDto> GetTutor(string tutorId)
        {
            var response = await _client.GetAsync($"api/tutor/" + tutorId);
            var content = await response.Content.ReadAsStringAsync();
            var tutor = JsonConvert.DeserializeObject<TutorDto>(content);
            return tutor;
        }

        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status)
        {
            throw new NotImplementedException();
        }

       

        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto tutorDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsBySubject(string Id)
        {
            var response = await _client.GetAsync($"api/tutor/GetTutorsBySubject/" + Id);
            var content = await response.Content.ReadAsStringAsync();
            var tutors = JsonConvert.DeserializeObject<IEnumerable<spGetMatchedTutorDto>>(content);
            return tutors;
        }
        public async Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsByFilters(FilterTutorRequest request)
        {
            var dataString = JsonConvert.SerializeObject(request);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/tutor/GetTutorsByFilters", content);

            var dataContent = await response.Content.ReadAsStringAsync();
            var tutors = JsonConvert.DeserializeObject<IEnumerable<spGetMatchedTutorDto>>(dataContent);
            return tutors;
        }

        public async Task<bool> SaveMatchedTutor(string studentSubjectId, string tutorId,string matchStatusId,string adminRemarks)
        {
            var request = new SaveMatchedTutorRequest { StudentSubjectId=Convert.ToInt32(studentSubjectId), TutorId=Convert.ToInt32(tutorId), MatchStatusId= Convert.ToInt32(matchStatusId), AdminRemarks=adminRemarks };
            var response = await _client.PostAsJsonAsync<SaveMatchedTutorRequest>($"api/tutor/SaveMatchedTutor/", request);
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            return true;
        }
    }
}
