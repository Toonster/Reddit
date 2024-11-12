namespace RedditPoC.Application.Common;

public struct Result<TData>
{
    public TData? Data { get; init; }
    public List<Error> Errors { get; init; } = [];
    public bool IsSuccess => Errors.Count == 0;
    
    public static Result<TData> Success(TData? data) => new() { Data = data };
    public static Result<TData> Error(List<Error> errors) => new() { Errors = errors };

    private Result(TData? data)
    {
        Data = data;
    }

    private Result(List<Error> errors)
    {
        Errors = errors;
    }
}
