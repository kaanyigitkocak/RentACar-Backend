using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<Car> Get(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
    }

    public IResult Add(Car car)
    {
        if (IsValid(car.Description,car.DailyPrice))
        {
            _carDal.Add(car);
            Console.WriteLine("Eklendi");
            return new SuccessResult();
        }

        return new ErrorResult();

    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult();
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult();
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(brand => brand.BrandId == brandId));
    }

    public IDataResult<List<Car>> GetCarsByColorId(int colorId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(color => color.ColorId == colorId));
    }

    public IDataResult<List<CarDetailDto>> GetCarDetailDto()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDto());
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