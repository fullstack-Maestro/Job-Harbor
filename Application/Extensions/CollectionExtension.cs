using Domain.Entities.Commons;

namespace Domain.Extensions;

public static class CollectionExtention
{
    public static T Create<T>(this List<T> values, T model) where T : Auditable
    {
        var lastId = values.Count == 0 ? 1 : values.Last().Id + 1;
        model.Id = lastId;
        values.Add(model);
        return values.Last();
    }

    public static List<T> BulkCreate<T>(this List<T> values, List<T> models) where T : Auditable
    {
        var lastId = values.Count == 0 ? 1 : values.Last().Id + 1;
        models.ForEach(t => t.Id = lastId++);
        values.AddRange(models);
        return values;
    }
}