using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels;

namespace E_Commerce.Domain.ControlAccess.Users.Services
{
    internal class UserService(IUserRepository repository, IMapper mapper, IInfoService infoService) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IInfoService _infoService = infoService;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> Create(UserCreateViewModel body)
        {
            var createdAddress = new Address
            {
                City = body.Address.City,
                Number = body.Address.Number,
                State = body.Address.State,
                Street = body.Address.Street,
                ZipCode = body.Address.ZipCode
            };

            var createdInfo = await _infoService.Create(body.Info, createdAddress);

            var createdUser = new User
            {
                Name = body.Name,
                Password = body.Password,
                Info = createdInfo,
            };

            await _repository.Add(createdUser);

            await _repository.Save();

            var userDto = _mapper.Map<UserDto>(createdUser);

            return userDto;
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _repository.GetAll();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public Task<UserDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
