using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : Controller
{
    private readonly IToDoService _service;
    private readonly IMapper _mapper;

    public ToDoController(IToDoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskToDoReadDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<TaskToDoReadDto>>(items));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskToDoReadDto>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();

        return Ok(_mapper.Map<TaskToDoReadDto>(item));
    }

    [HttpPost]
    public async Task<ActionResult<TaskToDoReadDto>> Create(TaskToDoCreateDto dto)
    {
        var item = _mapper.Map<TaskToDo>(dto);
        await _service.AddAsync(item);
        await _service.SaveChangesAsync();

        var readDto = _mapper.Map<TaskToDoReadDto>(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, readDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskToDoCreateDto dto)
    {
        var existingItem = await _service.GetByIdAsync(id);
        if (existingItem == null) return NotFound();

        _mapper.Map(dto, existingItem);
        _service.Update(existingItem);
        await _service.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingItem = await _service.GetByIdAsync(id);
        if (existingItem == null) return NotFound();

        _service.Delete(existingItem);
        await _service.SaveChangesAsync();

        return NoContent();
    }
}
