using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:EntityRepositoryBase<Car,RentACarContext>,ICarDal
{
    public List<CarDetailDto> GetCarDetailDto()
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from car in context.Cars
                join brand in context.Brands on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                select new CarDetailDto()
                {
                    CarName = car.Description,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice
                };
            return result.ToList();
        }
    }
}