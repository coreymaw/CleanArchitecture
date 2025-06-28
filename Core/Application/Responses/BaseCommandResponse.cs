namespace Application.Responses;

public class BaseCommandResponse
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    
    public int CreatedEntityId { get; set; }
    
}

public class BaseCommandResponse<T> where T : class
{
    public bool IsSuccess { get; set; } = true;
    public int CreatedEntityId { get; set; }
    public string Message { get; set; }
    public T? Date { get; set; }
    public List<string> Errors { get; set; }
    
}