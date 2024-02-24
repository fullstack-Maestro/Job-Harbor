using Domain.Configurations;
using Domain.Entities.Jobs;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services;

public class JobService : IJobService
{
    private List<Job> _jobs = null!;
    public async Task<JobViewModel> CreateAsync(JobCreationModel job)
    {
        _jobs = await FileIO.ReadAsync<Job>(Constants.JobsPath);
        var createdJob = _jobs.Create(job.MapTo<Job>());

        await FileIO.WriteAsync(Constants.JobsPath, _jobs);
        return createdJob.MapTo<JobViewModel>();
    }

    public async Task<JobViewModel> UpdateAsync(long id, JobUpdateModel job)
    {
        _jobs = await FileIO.ReadAsync<Job>(Constants.JobsPath);
        var existJob = this._jobs.FirstOrDefault(j => j.Id == id)
                       ?? throw new NotFoundException<Job>();

        existJob.Id = id;
        existJob.Title = job.Title;
        existJob.Description = job.Description;
        existJob.EmployerInfo = job.EmployerInfo;
        existJob.Location = job.Location;
        existJob.RequiredSkills = job.RequiredSkills;
        existJob.Salary = job.Salary;

        await FileIO.WriteAsync(Constants.JobsPath, _jobs);

        return existJob.MapTo<JobViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _jobs = await FileIO.ReadAsync<Job>(Constants.JobsPath);
        var existJob = this._jobs.FirstOrDefault(j=> j.Id == id)
            ?? throw new NotFoundException<Job>();

        existJob.IsDeleted = true;
        existJob.DeletedAt = DateTime.UtcNow;

        await FileIO.WriteAsync(Constants.JobsPath, _jobs);

        return true;
    }

    public async Task<JobViewModel> GetByIdAsync(long id)
    {
        _jobs = await FileIO.ReadAsync<Job>(Constants.JobsPath);
        var existJob = this._jobs.FirstOrDefault(j => j.Id == id)
            ?? throw new NotFoundException<Job>();

        return existJob.MapTo<JobViewModel>();
    }

    public async Task<List<JobViewModel>> GetAllAsync()
    {
        _jobs = await FileIO.ReadAsync<Job>(Constants.JobsPath);
        return _jobs.Where(job => !job.IsDeleted).MapTo<JobViewModel>();
    }
}