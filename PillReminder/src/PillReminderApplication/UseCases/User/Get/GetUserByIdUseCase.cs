using AutoMapper;
using PillReminder.Comunication.users.Responses;
using PillReminder.Domain.Repositories;
using PillReminderApplication.UseCases.User.Get.Interfaces;

namespace PillReminderApplication.UseCases.User.Get
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public GetUserByIdUseCase(IMapper mapper, IUserRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DetailedUserJsonResponse> Execute(string userId)
        {
            var response = await _repository.FindUserById(userId);
            return _mapper.Map<DetailedUserJsonResponse>(response);
        }
    }
}
