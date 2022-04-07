namespace TestConsole;

internal class ShopManager
{
    private readonly IShopsSerializer _shopSerializer;
    private readonly ShopsTypes _type;
    private int _Id = 1;
    private List<Shops> _shops = new ();

    public ShopManager(ShopsTypes Type, IShopsSerializer ShopSerializer)
    {
        _shopSerializer = ShopSerializer;
    }

    public Shops Add(string _Name_Product, double _Price, int _Count_On_Storage)
    {
        var shop = new Shops
        {
            ID = _Id++,
            Type = _type,
            Name = _Name_Product,
            Price = _Price,
            Count = _Count_On_Storage
        };

        _shops.Add(shop);

        return shop;
    }

    public FileInfo SaveTo(string FileName)
    {
        var file = new FileInfo(FileName);

        using (var json = file.Create())
            _shopSerializer.Serializer(json, _shops);

        return file;
    }

    public void LoadFrom(string FileName)
    {
        using var json = File.OpenRead(FileName);

        _shops = _shopSerializer.Deserializer(json);
        if (_shops.Count == 0 ) return;

        _Id = _shops.Max(Shops1 => Shops1.ID) + 1;
    }

}

