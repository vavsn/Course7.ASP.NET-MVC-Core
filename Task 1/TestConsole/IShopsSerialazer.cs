using System.Text.Json;

namespace TestConsole;

internal interface IShopsSerializer
{
    void Serializer(Stream stream, List<Shops> Shops);

    List<Shops> Deserializer(Stream stream);
}

internal abstract class ShopsSerializer : IShopsSerializer
{
    public abstract void Serializer(Stream stream, List<Shops> Shops);

    public abstract List<Shops> Deserializer(Stream stream);
}

internal class Shop1Serializer : ShopsSerializer
{
    public override List<Shops> Deserializer(Stream stream)
    {
        return JsonSerializer.Deserialize<List<Shops>>(stream)
            ?? throw new InvalidOperationException("Не удалось получить данные из магазина");
    }

    public override void Serializer(Stream stream, List<Shops> Shops)
    {
        JsonSerializer.Serialize(stream, Shops);
    }
}
