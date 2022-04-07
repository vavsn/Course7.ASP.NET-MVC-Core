// See https://aka.ms/new-console-template for more information
using TestConsole;

Console.WriteLine("Начинаем работать");

var shop_serializer = new Shop1Serializer();

var shop_manager =  new ShopManager(ShopsTypes.Shop3, shop_serializer);

shop_manager.Add("Магнитофон отечественный", 112, 4);

var file_name = $"{ShopsTypes.Shop3}.json";

shop_manager.SaveTo(file_name);

shop_manager.LoadFrom(file_name);

Console.WriteLine("Закончили работать");
