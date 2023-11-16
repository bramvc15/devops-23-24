using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    DoctorService _service;
    
    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getDoctors")]
    public IEnumerable<Doctor> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("id")]
    [Route("getDoctorById")]
    public Doctor GetDoctorbyId(int id){
        return _service.GetDoctorById(id);
    }

    // [HttpGet("{id}")]
    // public ActionResult<Pizza> GetById(int id)
    // {
    //     var pizza = _service.GetById(id);

    //     if(pizza is not null)
    //     {
    //         return pizza;
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }
    // }


    // [HttpPost]
    // public IActionResult Create(Pizza newPizza)
    // {
    //     var pizza = _service.Create(newPizza);
    //     return CreatedAtAction(nameof(GetById), new { id = pizza!.Id }, pizza);
    // }

    // [HttpPut("{id}/addtopping")]
    // public IActionResult AddTopping(int id, int toppingId)
    // {
    //     var pizzaToUpdate = _service.GetById(id);

    //     if(pizzaToUpdate is not null)
    //     {
    //         _service.AddTopping(id, toppingId);
    //         return NoContent();    
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }
    // }

    // [HttpPut("{id}/updatesauce")]
    // public IActionResult UpdateSauce(int id, int sauceId)
    // {
    //     var pizzaToUpdate = _service.GetById(id);

    //     if(pizzaToUpdate is not null)
    //     {
    //         _service.UpdateSauce(id, sauceId);
    //         return NoContent();    
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }
    // }

    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     var pizza = _service.GetById(id);

    //     if(pizza is not null)
    //     {
    //         _service.DeleteById(id);
    //         return Ok();
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }
    // }
}