﻿using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal:ICarDal
{
    private List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear = 2019,DailyPrice = 250,Description = "Audi"},
            new Car{Id = 2,BrandId = 2,ColorId = 2,ModelYear = 2020,DailyPrice = 350,Description = "Mercedes-Benz"},
            new Car{Id = 3,BrandId = 3,ColorId = 3,ModelYear = 2021,DailyPrice = 450,Description = "BMW"}
        };
    }
    public List<Car> GetAll()
    {
        return _cars;
    }

    public Car Get(int id)
    {
        return _cars.SingleOrDefault(c => c.Id == id)!;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        var updateTo = _cars.SingleOrDefault(c => c.Id == car.Id)!;
        updateTo.BrandId = car.BrandId;
        updateTo.ColorId = car.ColorId;
        updateTo.ModelYear = car.ModelYear;
        updateTo.DailyPrice = car.DailyPrice;
        updateTo.Description = car.Description;
    }

    public void Delete(Car car)
    {
        var deleteTo = _cars.SingleOrDefault(c => c.Id == car.Id)!;
        _cars.Remove(deleteTo);
    }
}