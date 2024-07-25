using AutoMapper;
using PillReminder.Communication.images.requests;
using PillReminder.Communication.images.responses;
using PillReminder.Communication.remedies.requests;
using PillReminder.Communication.remedies.responses;
using PillReminder.Comunication.users.Requests;
using PillReminder.Comunication.users.Responses;
using PillReminder.Domain.entities;

namespace PillReminderApplication.AutoMapper
{
    public class AutoMapping:Profile
    {

        public AutoMapping()
        {
            RequestToEntity();
            EntityToResposne();
        }
        private void RequestToEntity()
        {
            CreateMap<ImageRequestJson, ImageEntity>();
            CreateMap<RemedyJsonRequest, RemedyEntity>();
            CreateMap<UserJsonRequest, UserEntity>();
        }
        private void EntityToResposne()
        {
            CreateMap<UserEntity, DetailedUserJsonResponse>();
            CreateMap<UserEntity, UserShortJsonResponse>();
            CreateMap<RemedyEntity, RemedyDetailedJsonResponse>();
            CreateMap<RemedyEntity, RemedyShortJsonResponse>();
            CreateMap<ImageEntity, DetailedImageResponseJson>();
            CreateMap<ImageEntity, ShortImageResponseJson>();
        }
    }
}
