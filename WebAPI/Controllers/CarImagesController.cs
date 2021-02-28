using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =_carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetaAllByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagebyid")]
        public IActionResult GetImageById(int id)
        {
            var result = _carImageService.GetImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);       
        }
            
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile image , [FromForm] CarImage carImage)   //[FromForm] attributu from-data kullanıldığını belirtiyor(postman de)
        {
            var result = _carImageService.Add(image,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm]IFormFile image ,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(image,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
