using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager:ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public Car Get(int id)
    {
        return _carDal.Get(c => c.Id == id);
    }

    public void Add(Car car)
    {
        if (IsValid(car.Description,car.DailyPrice))
        {
            _carDal.Add(car);
            Console.WriteLine("Eklendi");
        }
        
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetAll(brand => brand.BrandId == brandId);
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _carDal.GetAll(color => color.ColorId == colorId);
    }

    public List<CarDetailDto> GetCarDetailDto()
    {
        return _carDal.GetCarDetailDto();
    }

    private bool IsValid(string? desc, decimal price)
    {
        if (desc is { Length: >= 2 })
        {
            if (price>0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                return false;
            }

            return true;
        }
        else
        {
            Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
        }

        return false;
    }
}