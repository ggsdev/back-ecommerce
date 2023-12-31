﻿using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Shared;

namespace E_Commerce.Domain.ControlAccess.Users.Services
{
    public class UserService(IUserRepository repository, IMapper mapper, IInfoService infoService, IUserFactory factory) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IUserFactory _factory = factory;
        private readonly IInfoService _infoService = infoService;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> CreateUser(CreateUserViewModel body)
        {
            var createdInfo = await _infoService
                .CreateInfo(body.Info, body.Address);

            var createdUser = _factory.Create(body, createdInfo);

            await _repository.Add(createdUser);

            await _repository.Save();

            var userDto = _mapper.Map<UserDto>(createdUser);

            return userDto;
        }

        public async Task DeleteUser(int id, User loggedUser)
        {
            if (loggedUser.IsAdmin is false)
                throw new Exception(DomainMessages.UserNotAdmin);

            var userToBeDeleted = await _repository.GetByIdClean(id)
                ?? throw new Exception(DomainMessages.UserNotFound);

            _repository.Delete(userToBeDeleted);

            await _repository.Save();

            return;
        }

        public async Task<PaginatedDataDTO<UserDto>> GetAllUsers(FilterQuery queryParams, string requestUrl, User loggedUser)
        {
            if (loggedUser.IsAdmin is false)
                throw new Exception(DomainMessages.UserNotFound);

            var totalCount = await _repository.Count();

            var users = await _repository.GetAll(queryParams);

            var usersDto = _mapper.Map<List<UserDto>>(users);

            var paginatedData = APIGetReturn.Paginate(usersDto, queryParams.PageNumber, queryParams.PageSize, totalCount, requestUrl);

            return paginatedData;
        }

        public async Task<UserDto> GetUserById(int id, User loggedUser)
        {
            if (loggedUser.IsAdmin is false && loggedUser.Id != id)
                throw new Exception(DomainMessages.UserNotAdmin);

            var user = await _repository.GetById(id)
                ?? throw new Exception(DomainMessages.UserNotFound);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UserDto> UpdateUser(UpdateUserViewModel body, int id, User loggedUser)
        {
            if (loggedUser.IsAdmin is false && loggedUser.Id != id)
                throw new Exception(DomainMessages.UserNotAdmin);

            var user = await _repository.GetById(id)
               ?? throw new Exception(DomainMessages.UserNotFound);

            var updatedUser = _factory.Update(user, body);

            await _infoService
                .UpdateInfo(body.Info, user.Info);

            _repository.Update(updatedUser);

            await _repository.Save();

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
