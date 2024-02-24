using Domain.Entities.Jobs;

namespace Domain.Interfaces;

public interface IJobService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="job"></param>
    /// <returns></returns>
    Task<JobViewModel> CreateAsync(JobCreationModel job);
    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <param name="job"></param>
    /// <returns></returns>
    Task<JobViewModel> UpdateAsync(long id, JobUpdateModel job);

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
    Task<JobViewModel> GetByIdAsync(long id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<JobViewModel>> GetAllAsync();
}