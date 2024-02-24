using Newtonsoft.Json;

namespace Infrastructure.Services;

public static class FileIO
{
    public static async ValueTask<List<T>> ReadAsync<T>(string path)
    {
        //var content = await CloudIO.GetAsync(path);
        var content = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(content))
            return new List<T>();

        return JsonConvert.DeserializeObject<List<T>>(content)!;
    }

    public static async ValueTask WriteAsync<T>(string path, List<T> values)
    {
        var json = JsonConvert.SerializeObject(values, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
        //await CloudIO.UploadAsync(path);
    }
}