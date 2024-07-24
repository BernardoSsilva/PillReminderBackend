using AutoMapper;
using MD5Hash;
using PillReminder.Communication.users.Requests;
using PillReminder.Communication.users.Responses;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminder.Exception.exceptions.httpErrors;
using PillReminder.JWTAdmin;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.User.Post.Interfaces;

namespace PillReminderApplication.UseCases.User.Post
{
    public class AuthenticateUserUseCase : IAuthenticateUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AuthenticateUserUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserAuthenticationResponseJson> Execute(UserAuthenticationRequestJson request)
        {
            var user = await _repository.FindUserByEmail(request.UserEmail.ToString());
            if(user == null)
            {
                throw new NotFoundException("User not found");
            }

            if(user.Password != request.UserPassword.ToString().GetMD5())
            {
                throw new UnauthorizedException("Unauthorized");
            }

            var adminToken = new AdminToken();

            var newToken = adminToken.Generate(new TokenPayload
            {
                UserEmail = request.UserEmail,
                UserId = user.Id
            });

            return new UserAuthenticationResponseJson
            {
                Token = newToken
            };

        }
    }
}
