using AutoMapper;
using CRUDtest.DTO;
using CRUDtest.Models;
using CRUDtest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUDtest.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CarController(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAllCars()
    {
        var cars = await _carService.GetAllCar();
        return Ok(cars);
    }

    [HttpGet]
    public async Task<ActionResult<Car>> GetCarById(int cardId)
    {
        var car = await _carService.GetCarById(cardId);
        if (car is null)
        {
            return NotFound();
        }

        return Ok(car);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> AddCar(Car car)
    {
        var lecar = await _carService.AddCar(car);
        return Ok(lecar);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> UpdateCar(int id, CarDTO carDto)
    {
        var updateCar = await _carService.UpdateCar(id, new Car
        {
            Name = carDto.Name,
            Mark = carDto.Mark,
            Color = carDto.Color
        });

        if (updateCar is null)
            return NotFound();
        
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeleteCar(CarIdDTO carIdDto)
    {
        var car = await _carService.DeleteCar(carIdDto.CarId);
        if (!car)
        {
            return NotFound();
        }

        return NoContent();
    }
}