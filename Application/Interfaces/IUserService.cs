using Domain.Entities.Users;

namespace Domain.Interfaces;

public interface IUserService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UserViewModel> CreateAsync(UserCreationModel user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <param name="isUsedDeleted"></param>
    /// <returns></returns>
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool isUsedDeleted = false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserViewModel> GetByIdAsync(long id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<UserViewModel> GetByEmailAsync(string email);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<UserViewModel>> GetAllAsync();
}