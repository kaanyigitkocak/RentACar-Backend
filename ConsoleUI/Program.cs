// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

void CarAddMet(string? desc,decimal price,int brandId,int colorId)
{
    Car car1 = new Car()
    {
        BrandId = brandId, ColorId = colorId, ModelYear = 2021,
        DailyPrice = price, Description = desc
    };
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Add(car1);
}

void GetCarsByColorId()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetCarsByColorId(3))
    {
        Console.WriteLine(car.Description);
    }
}

void GetCarsByBrandId()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarsByBrandId(1))
    {
        Console.WriteLine(car.Description);
    }
}

void ColorGetAll()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine(color.Name);
    }
}

void BrandGetAll()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.Name);
    }
}

void CarGetAll()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine(car.Description);
    }
}

CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetCarDetailDto())
{
    Console.WriteLine($"Araba Adı : {car.CarName}");
    Console.WriteLine($"Araba MarKası : {car.BrandName}");
    Console.WriteLine($"Araba Renk : {car.ColorName}");
    Console.WriteLine($"Araba Fiyatı : {car.DailyPrice} TL");
    Console.WriteLine("****************************************");
}

//CarAddMet("T",0,1,2);

//GetCarsByColorId();

//GetCarsByBrandId();

//ColorGetAll();

//BrandGetAll();

//CarGetAll();