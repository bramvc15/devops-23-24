using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Shared;
using BlazorApp.Services.Core;

namespace BlazorApp.Controllers.core;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _service;

    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<DoctorDTO>> GetAll()
    {
        return await _service.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<DoctorDTO> GetDoctorbyId(int id)
    {
        return await _service.GetDoctorById(id);
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