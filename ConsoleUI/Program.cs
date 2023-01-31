// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

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

Car car1 = new Car()
{
    BrandId = 3,ColorId = 2,ModelYear = 2021,
    DailyPrice = 45000,Description = "Mercedes Komposer As3"
};
CarManager carManager = new CarManager(new EfCarDal());
carManager.Add(car1);

//GetCarsByColorId();

//GetCarsByBrandId();

//ColorGetAll();

//BrandGetAll();

//CarGetAll();