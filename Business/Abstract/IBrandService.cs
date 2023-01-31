﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    IDataResult<List<Brand>> GetAll();
    IDataResult<Brand> Get(int id);
    IResult Add(Brand brand);
    IResult Update(Brand brand);
    IResult Delete(Brand brand);
}