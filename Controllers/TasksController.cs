using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_context.Tasks.ToList());

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return Ok(task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem updated)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();

        task.Title = updated.Title;
        task.IsCompleted = updated.IsCompleted;
        _context.SaveChanges();

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return Ok();
    }
}