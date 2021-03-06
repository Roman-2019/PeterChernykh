﻿using System;
using Homework12_BLL.Interfaces;
using Homework12_BLL.Models;
using Homework12_BLL.Services;
using Homework12_PL.Interfaces;
using Homework12_PL.Models;
using System.Collections.Generic;
using System.Linq;
using Homework12_Common;

namespace Homework12_PL.Controller
{
    public class CarController : ICarController
    {
        private readonly ICarService _dbCar;

        public CarController()
        {
            _dbCar = new CarService();
        }

        public void Add(CarViewModel carViewModel)
        {
            var car = new CarModel
            {
                Model = CheckNameSpaces("Toyota Toyota"),
                Details = new List<DetailModel>
                {
                    new DetailModel
                    {
                        Name = "Door",
                        Cost = 150,
                        Type = DetailTypeEnum.Wheel,
                        Manufacturer = new ManufacturerModel
                        {
                            Id = 8,
                            Name = "UNKNOWN"
                        }
                    },
                },
                Manufacturer = new ManufacturerModel
                {
                    Id = 12,
                    Name = "Volvo"
                }
            };


            _dbCar.Add(car);
        }

        public void Delete(int id)
        {
            _dbCar.Delete(id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {

            var carViewModels = from car in _dbCar.GetAll()
                                select new CarViewModel()
                                {
                                    Id = car.Id,
                                    Model = car.Model,
                                    Details = car.Details.Select(x => new DetailViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Cost = x.Cost,
                                        CarId = x.CarId,
                                        Type = (DetailTypeEnum)x.Type,
                                        Manufacturer = new ManufacturerViewModel
                                        {
                                            Id = x.Manufacturer.Id,
                                            Name = x.Manufacturer.Name
                                        }
                                    }),
                                    Manufacturer = new ManufacturerViewModel
                                    {
                                        Id = car.Manufacturer.Id,
                                        Name = car.Manufacturer.Name
                                    }
                                };

            return carViewModels;
        } 

        public void Update(CarViewModel carViewModel)
        {
            var carModel = new CarModel
            {
                Id = 1,
                Model = "Peugau"
            };

            _dbCar.Update(carModel);
        }

        public CarViewModel GetCarById(int id)
        {
            var carModel = _dbCar.GetById(id);

            var carViewModel = new CarViewModel
            {
                Id = carModel.Id,
                Model = carModel.Model,
                Details = carModel.Details.Select(x => new DetailViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    CarId = x.CarId,
                    Type = (DetailTypeEnum)x.Type,
                    Manufacturer = new ManufacturerViewModel
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name
                    }
                }),
                Manufacturer = new ManufacturerViewModel
                {
                    Id = carModel.Manufacturer.Id,
                    Name = carModel.Manufacturer.Name
                }
            };

            return carViewModel;
        }

        public string CheckNameSpaces(string name)
        {
            int spaceCount = 0;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    spaceCount++;
                }
                else if (spaceCount > 2)
                {
                    throw new ArgumentException("The chosen car name contains too many spaces");
                }
            }
            return name;
        }
    }
}