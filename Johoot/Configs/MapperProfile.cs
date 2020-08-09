using AutoMapper;
using Johoot.Data;
using Johoot.QuizeCrm.ViewModels;

namespace Johoot.Configs
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<Quize, QuizeViewModel>().ReverseMap();
      //CreateMap<Question,QuestionViewModel>
    }
  }
}
