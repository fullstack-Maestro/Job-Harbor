using Domain.Entities.Applications;

namespace Domain.Interfaces;

public interface IApplicationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    Task<ApplicationViewModel> CreateAsync(ApplicationCreationModel application);
    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    Task<ApplicationViewModel> UpdateAsync(long id, ApplicationUpdateModel application);

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
    Task<ApplicationViewModel> GetByIdAsync(long id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<ApplicationViewModel>> GetAllAsync();
}