using CRUDtest.DTO;
using CRUDtest.Models;

namespace CRUDtest.Services.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetAllCar();
    Task<Car> AddCar(Car car);
    Task<Car> GetCarById(int carId);
    Task<Car> UpdateCar(int carDto, Car car);
    Task<bool> DeleteCar(int carId);

}