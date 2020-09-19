﻿using AutoMapper;
using Johoot.Data;
using Johoot.QuestionCrm.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Johoot.Services
{
  public class QuestionService : IQuestionService
  {
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public QuestionService(HttpClient httpClient, IMapper mapper)
    {
      _httpClient = httpClient;
      _mapper = mapper;
    }

    public async Task<IList<QuestionViewModel>> GetAll(bool includeAll = true)
    {
      string relativeUri = $"{nameof(Question)}?includeAll={includeAll}";
      return await JsonSerializer.DeserializeAsync<IList<QuestionViewModel>>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IList<QuestionViewModel>> FilterByQuize(
      long quizeId,
      bool includeAll = true)
    {
      string relativeUri = $"{nameof(Question)}/find/{quizeId}?includeAll={includeAll}";
      return await JsonSerializer.DeserializeAsync<IList<QuestionViewModel>>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuestionViewModel> GetById(long id)
    {
      string relativeUri = $"{nameof(Question)}/{id}?includeAll=true";
      return await JsonSerializer.DeserializeAsync<QuestionViewModel>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuestionViewModel> Create(QuestionViewModel item)
    {
      string relativeUri = $"{nameof(Question)}";
      var bodyJson =
             new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(relativeUri, bodyJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<QuestionViewModel>(
          await response.Content.ReadAsStreamAsync(),
          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
      }

      return null;
    }

    public async Task Update(QuestionViewModel item)
    {
      string relativeUri = $"{nameof(Question)}/{item.Id}";
      var bodyJson =
                 new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      await _httpClient.PutAsync(relativeUri, bodyJson);
    }

    public async Task<QuestionViewModel> GetVmById(long id)
    {
      return _mapper.Map<QuestionViewModel>(await GetById(id));
    }

    //public async Task<QuestionViewModel> Create(QuestionViewModel item)
    //{
    //  return _mapper.Map<QuestionViewModel>(await Create(_mapper.Map<QuestionViewModel>(item)));
    //}
  }
}
