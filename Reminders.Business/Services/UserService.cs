using AutoMapper;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.User;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var entitys = await _userRepository.GetAllUserAsync();
            return _mapper.Map<List<UserResponse>>(entitys);
        }

        public async Task<long> AddAsync(UserRequest newUser)
        {
            var user = _mapper.Map<User>(newUser);
            return await _userRepository.SaveAsync(user);
        }

        public async Task<UserResponse> UpdateAsync(long id, UserRequest updateUser)
        {
            var user = _mapper.Map<User>(updateUser);
            user.Id = id;

            await _userRepository.UppdateAsync(user);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task DeleteAsync(long id)
        {
            var deletedUser = await _userRepository.FindByIdAsync(id);
            deletedUser.IsDeleted = true;

            await _userRepository.DeleteAsync(deletedUser);
        }
    }
}
