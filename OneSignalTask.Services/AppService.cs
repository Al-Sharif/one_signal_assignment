using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OneSignalTask.Core;
using OneSignalTask.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace OneSignalTask.Services
{
    public class AppService : IAppService
    {
        private readonly HttpClient _client;
        private readonly OneSignalConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppService(HttpClient client, IOptions<OneSignalConfiguration> options, ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = options.Value;
            _client = client;
            _client.BaseAddress = new Uri(_configuration.BaseUrl);
            _client.DefaultRequestHeaders.Add("Authorization", @$"Basic {_configuration.UserAuthKey}");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<App> GetAll()
        {
            return default;
        }
        public App Create(AppViewModel input)
        {
            if (input != null)
            {
                var mappedApp = _mapper.Map<App>(input);
                _dbContext.Set<App>().Add(mappedApp);
                _dbContext.SaveChanges();
                return mappedApp;
            }
            else
            {
                return default;
            }
        }
        public List<AppViewModel> GetAllApi()
        {
            var response = _client.GetAsync(_configuration.AppRoutes.GetAll).Result;
            if (response.IsSuccessStatusCode)
            {

                var model = JsonConvert.DeserializeObject<List<AppViewModel>>(response.Content.ReadAsStringAsync().Result);
                return model;
            }
            else
            {
                return default;
            }
        }

        public bool Delete(App app)
        {
            throw new NotImplementedException();
        }

        public App Get(Expression<Func<App, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public AppViewModel GetByIdApi(string id)
        {
            var response = _client.GetAsync($@"{_configuration.AppRoutes.GetById}{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                var model = JsonConvert.DeserializeObject<AppViewModel>(response.Content.ReadAsStringAsync().Result);
                return model;
            }
            else
            {
                return default;
            }
        }

        public bool Update(AppViewModel input)
        {
            if (input == null)
            {
                return false;
            }
            else
            {
                var mappedApp = _mapper.Map<App>(input);
                var entityToUpdate = _dbContext.Set<App>().AsNoTracking().FirstOrDefault(x => x.Id == input.Id);
                if (entityToUpdate != null)
                {
                    entityToUpdate = mappedApp;
                    _dbContext.Set<App>().Update(entityToUpdate);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public AppViewModel UpdateApi(AppInputModel input)
        {
            var json = JsonConvert.SerializeObject(input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PutAsync(@$"{_configuration.AppRoutes.Update}{input.Id}", data).Result;
            if (response.IsSuccessStatusCode)
            {
                var model = JsonConvert.DeserializeObject<AppViewModel>(response.Content.ReadAsStringAsync().Result);
                return model;
            }
            else
            {
                return default;
            }
        }
        public AppViewModel CreateApi(AppInputModel input)
        {
            var json = JsonConvert.SerializeObject(input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_configuration.AppRoutes.Create, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var model = JsonConvert.DeserializeObject<AppViewModel>(response.Content.ReadAsStringAsync().Result);
                return model;
            }
            else
            {
                return default;
            }
        }
        public bool IsExist(string id)
        {
            return _dbContext.Set<App>().Any(x => x.Id == id);
        }
    }
}
