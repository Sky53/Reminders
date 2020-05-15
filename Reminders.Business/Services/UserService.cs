using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.User;
using Reminders.Business.Config;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<JwtConfig> jwtConfig )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value ?? throw new ArgumentNullException(nameof(jwtConfig.Value)); ;
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

        public async Task<string> Authorization(UserAuthorization request)
        {
            var findUser = await _userRepository.FindByLogginAndPasswordAsync(request.Login, request.Password);
            if(findUser == null)
            {
                return null;
            }

            var identity = GetIdentity(findUser);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _jwtConfig.Issuer,
                    audience: _jwtConfig.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(_jwtConfig.Expires)),
                    signingCredentials: new SigningCredentials(_jwtConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(User userModel)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Login),
                    new Claim("Id", userModel.Id.ToString()),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

    }
}
