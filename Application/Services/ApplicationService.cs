using Domain.Configurations;
using Domain.Entities.Applications;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services;

public class ApplicationService : IApplicationService
{
    private List<Application> _applications= null!;
    public async Task<ApplicationViewModel> CreateAsync(ApplicationCreationModel application)
    {
        _applications = await FileIO.ReadAsync<Application>(Constants.ApplicationsPath);
        var createdApplication = _applications.Create(application.MapTo<Application>());

        await FileIO.WriteAsync(Constants.ApplicationsPath, _applications);
        return createdApplication.MapTo<ApplicationViewModel>();
    }

    public async Task<ApplicationViewModel> UpdateAsync(long id, ApplicationUpdateModel application)
    {
        _applications = await FileIO.ReadAsync<Application>(Constants.ApplicationsPath);
        var existApplication = this._applications.FirstOrDefault(j => j.Id == id)
                       ?? throw new NotFoundException<Application>();

        existApplication.Id = id;
        existApplication.ApplicantsInfo = application.ApplicantsInfo;
        existApplication.AccountLinks = application.AccountLinks;

        await FileIO.WriteAsync(Constants.ApplicationsPath, _applications);

        return existApplication.MapTo<ApplicationViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _applications = await FileIO.ReadAsync<Application>(Constants.ApplicationsPath);
        var existApplication = this._applications.FirstOrDefault(j => j.Id == id)
                       ?? throw new NotFoundException<Application>();

        existApplication.IsDeleted = true;
        existApplication.DeletedAt = DateTime.UtcNow;

        await FileIO.WriteAsync(Constants.ApplicationsPath, _applications);

        return true;
    }

    public async Task<ApplicationViewModel> GetByIdAsync(long id)
    {
        _applications = await FileIO.ReadAsync<Application>(Constants.ApplicationsPath);
        var existApplication = this._applications.FirstOrDefault(j => j.Id == id)
                       ?? throw new NotFoundException<Application>();

        return existApplication.MapTo<ApplicationViewModel>();
    }

    public async Task<List<ApplicationViewModel>> GetAllAsync()
    {
        _applications = await FileIO.ReadAsync<Application>(Constants.ApplicationsPath);
        return _applications.Where(application => !application.IsDeleted).MapTo<ApplicationViewModel>();
    }
}