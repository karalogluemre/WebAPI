using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        public IUserDAL _userDAL;
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                UserName = userAddDto.UserName,
                SurName = userAddDto.SurName,
                Gender = userAddDto.Gender,
                FirstName = userAddDto.FirstName,
                Address = userAddDto.Address,
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                Password = userAddDto.Password,
            };
            var userAdd = await _userDAL.AddAsync(user);
            UserDto userDtos = new UserDto()
            {
                UserName = userAdd.UserName,
                SurName = userAdd.SurName,
                Gender = userAdd.Gender,
                FirstName = userAdd.FirstName,
                Address = userAdd.Address,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                Password = userAdd.Password,
                Id = userAdd.Id,
            };
            return userDtos;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDAL.DeleteAsync(id);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var result = await _userDAL.GetAsync(p => p.Id == id);
            UserDto userDto = new UserDto()
            {
                Id = result.Id,
                Address = result.Address,
                DateOfBirth = result.DateOfBirth,
                Email = result.Email,
                FirstName = result.FirstName,
                Gender = result.Gender,
                SurName = result.SurName,
                UserName = result.UserName,
            };
            return userDto;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDto = new List<UserDetailDto>();
            var result = await _userDAL.GetListAsync();
            foreach (var item in result.ToList())
            {
                userDto.Add(new UserDetailDto
                {
                    FirstName = item.FirstName,
                    Address = item.Address,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Gender = item.Gender ? "Erkek" : "Kadın",
                    SurName = item.SurName,
                    UserName = item.UserName,
                });
            }
            return userDto;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDAL.GetAsync(x => x.Id == userUpdateDto.Id);
            User user = new User()
            {
                FirstName = userUpdateDto.FirstName,
                SurName = userUpdateDto.SurName,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                Id = userUpdateDto.Id,
                Password = userUpdateDto.Password,
                CreatedUserId = getUser.CreatedUserId,
                CreatedDate = getUser.CreatedDate,
                Gender = userUpdateDto.Gender,
                UserName = userUpdateDto.UserName,
                UpdateUserId = 1,
            };
            var userUpdate = await _userDAL.UpdateAsync(user);
            UserUpdateDto newUserUpdateDto = new UserUpdateDto()
            {
                FirstName = userUpdateDto.FirstName,
                SurName = userUpdateDto.SurName,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                Id = userUpdateDto.Id,
                Password = userUpdateDto.Password,
                Gender = userUpdateDto.Gender,
                UserName = userUpdateDto.UserName,
            };
            return newUserUpdateDto;
        }

    }
}
