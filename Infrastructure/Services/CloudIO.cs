using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Infrastructure.Configurations;
using System.Text;

namespace Infrastructure.Services;

public static class CloudIO
{
    public static async Task UploadAsync(string filePath)
    {
        var credentials = GoogleCredential.FromFile(Constants.CredentialsPath);

        var storage = await StorageClient.CreateAsync(credentials);

        byte[] jsonData = Encoding.UTF8.GetBytes(filePath);

        var (fileName, fileType) = GetFileInfo(filePath);
        await storage.UploadObjectAsync("job-harbor-bucket", fileName, fileType, new MemoryStream(jsonData));
    }

    public static async Task<string> GetAsync(string filePath)
    {
        var credentials = GoogleCredential.FromFile(Constants.CredentialsPath);

        var storage = await StorageClient.CreateAsync(credentials);

        var stream = new MemoryStream();

        await storage.DownloadObjectAsync("job-harbor-bucket", GetFileName(filePath), stream);
        using var reader = new StreamReader(stream);
        var jsonString = await reader.ReadToEndAsync();
        return jsonString;


    }

    private static (string fileName, string fileType) GetFileInfo(string filePath)
    {
        var path = filePath.Split("\\");
        var fileInfo = path.Last().Split(".");
        var fileName = fileInfo[0];
        var fileType = fileInfo[1];
        return (fileName, fileType);
    }

    private static string GetFileName(string filePath) => filePath.Split("\\").Last();
}