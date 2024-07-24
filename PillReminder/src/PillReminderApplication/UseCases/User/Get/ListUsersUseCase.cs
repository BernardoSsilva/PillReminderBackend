using AutoMapper;
using PillReminder.Comunication.users.Responses;
using PillReminder.Infrastructure.DataAccsess.Repositories;
using PillReminderApplication.UseCases.User.Get.Interfaces;

namespace PillReminderApplication.UseCases.User.Get
{
    internal class ListUsersUseCase : IListUsersUseCase
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _repository;

        public ListUsersUseCase(UserRepository repository, IMapper mapper)
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
