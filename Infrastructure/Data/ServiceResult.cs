public class ServiceResult<T>
{
    public bool Success { get; }
    public string Message { get; }
    public T? Data { get; }

    private ServiceResult(bool success, string message, T? data = default)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static ServiceResult<T> Ok(string message, T data) => new(true, message, data);
    public static ServiceResult<T> Fail(string message) => new(false, message, default);
}