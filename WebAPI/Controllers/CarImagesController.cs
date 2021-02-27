using Business.Abstract;
using Core.Utilities.FileOperation;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesByCarId(int id)
        {
            var result = _carImageService.GetCarImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] FileOperation objectFile)
        {
            CarImage _carImage = JsonConvert.DeserializeObject<CarImage>(objectFile.carImages);
            if (objectFile.files.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                var result = _carImageService.Add(objectFile,path,_carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {                    
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                var result = _carImageService.Delete(path, carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] FileOperation objectFile)
        {
            CarImage _carImage = JsonConvert.DeserializeObject<CarImage>(objectFile.carImages);
            if (objectFile.files.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                var result = _carImageService.Update(objectFile, path, _carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }
    }
}
