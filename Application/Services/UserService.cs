using Domain.Configurations;
using Domain.Entities.Users;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services;

public class UserService : IUserService
{
    private List<User> _users = null!;
    public async Task<UserViewModel> CreateAsync(UserCreationModel user)
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        var existUser = _users.FirstOrDefault(u => u.Email.Equals(user.Email));

        if (existUser != null && existUser.IsDeleted)
        {
            return await UpdateAsync(existUser.Id, user.MapTo<UserUpdateModel>(), true);
        }

        if (existUser is not null)
            throw new AlreadyExistException<User>();

        var createdUser = _users.Create(user.MapTo<User>());
        await FileIO.WriteAsync(Constants.UsersPath, _users);

        return createdUser.MapTo<UserViewModel>();
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool isUsedDeleted = false)
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        var existUser = new User();

        if (isUsedDeleted)
        {
            existUser = _users.FirstOrDefault(u => u.Id == id);
            existUser!.IsDeleted = false;
        }
        else
        {
            existUser = _users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
                        ?? throw new NotFoundException<User>();
        }

        existUser.Id = id;
        existUser.Name = user.Name;
        existUser.Email = user.Email;
        existUser.Role = user.Role;
        existUser.Hash = user.Hash;
        existUser.Salt = user.Salt;

        await FileIO.WriteAsync(Constants.UsersPath, _users);

        return existUser.MapTo<UserViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        var existUser = _users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
                            ?? throw new NotFoundException<User>();

        existUser.IsDeleted = true;
        existUser.DeletedAt = DateTime.UtcNow;
        await FileIO.WriteAsync(Constants.UsersPath, _users);

        return true;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        var existUser = _users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
                            ?? throw new NotFoundException<User>();

        return existUser.MapTo<UserViewModel>();
    }

    public async Task<UserViewModel> GetByEmailAsync(string email)
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        var existUser = _users.FirstOrDefault(u => u.Email == email && !u.IsDeleted)
                        ?? throw new NotFoundException<User>();

        return existUser.MapTo<UserViewModel>();
    }

    public async Task<List<UserViewModel>> GetAllAsync()
    {
        _users = await FileIO.ReadAsync<User>(Constants.UsersPath);
        return _users.Where(user => !user.IsDeleted).MapTo<UserViewModel>();
    }
}