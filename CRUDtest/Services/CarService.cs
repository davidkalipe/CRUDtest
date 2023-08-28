using CRUDtest.Data;
using CRUDtest.DTO;
using CRUDtest.Models;
using CRUDtest.Services.Interfaces;

namespace CRUDtest.Services;

public class CarService : ICarService
{
    private readonly CarDbContext _dbContext;

    public CarService(CarDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<List<Car>> GetAllCar()
    {
        var cars = _dbContext.Cars.ToList();
        return cars;
    }

    public async Task<Car> AddCar(Car car)
    {
        _dbContext.Cars.Add(car);
        await _dbContext.SaveChangesAsync();
        return car;

    }

    public async Task<Car> GetCarById(int carId)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.CarId == carId);
        if (car is not null)
        {
            return car;
        }

        return null;
    }

    public async Task<Car> UpdateCar(int cardId, Car car)
    {
        var existingCar = await _dbContext.Cars.FindAsync(cardId);
        if (existingCar is null)
        {
            return null;
        }

        existingCar.Name = car.Name;
        existingCar.Mark = car.Mark;
        existingCar.Color = car.Color;
        await _dbContext.SaveChangesAsync();
        return existingCar;
    }

    public async Task<bool> DeleteCar(int carId)
    {
        var car = _dbContext.Cars.FirstOrDefault(c=>c.CarId == carId);
        if (car is null)
        {
            return false;
        }

        _dbContext.Remove(car);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}