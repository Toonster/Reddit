namespace RedditPoC.Application.Common;

public class Result<TData> : Result
{
    private Result(IEnumerable<Error> errors) : base(errors)
    {
    }

    private Result(TData? data)
    {
        Data = data;
    }

    public TData? Data { get; init; }

    public static Result<TData> Success(TData? data)
    {
        return new Result<TData>(data);
    }

    public new static Result<TData> Error(IEnumerable<Error> errors)
    {
        return new Result<TData>(errors);
    }

    public TResult Match<TResult>(Func<TData, TResult> onSuccess, Func<IEnumerable<Error>, TResult> onFailure)
    {
        return IsSuccess ? onSuccess(Data!) : onFailure(Errors);
    }
}

public class Result
{
    protected Result(IEnumerable<Error> errors)
    {
        Errors = errors;
    }

    protected Result()
    {
    }

    public IEnumerable<Error> Errors { get; init; } = [];
    public bool IsSuccess => Errors.Any();

    public TResult Match<TResult>(Func<TResult> onSuccess, Func<IEnumerable<Error>, TResult> onFailure)
    {
        return IsSuccess ? onSuccess() : onFailure(Errors);
    }

    public static Result Success()
    {
        return new Result();
    }

    public static Result Error(IEnumerable<Error> errors)
    {
        return new Result(errors);
    }
}