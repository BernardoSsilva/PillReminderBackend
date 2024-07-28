using AutoMapper;
using PillReminder.Comunication.users.Responses;
using PillReminder.Domain.Repositories;
using PillReminder.Infrastructure.DataAccsess.Repositories;
using PillReminderApplication.UseCases.User.Get.Interfaces;

namespace PillReminderApplication.UseCases.User.Get
{
    public class ListUsersUseCase : IListUsersUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public ListUsersUseCase(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultipleUserJsonResposne> Execute()
        {
            var usersList =await _repository.FindAllUsers();
            var response = new MultipleUserJsonResposne {

                UsersList = _mapper.Map<List<UserShortJsonResponse>>(usersList)
            };
            return response;
        }
    }
}
