namespace Test.Application.Models;

public static class Result
{
    public static Result<T> Success<T>(T? value) where T : class 
        => value == null 
        ? new Result<T>(null, true, Error.None) 
        : new Result<T>(value, true, Error.None);

    public static Result<T> Success<T>() 
        => new(default, true, Error.None);

    public static Result<T> Failure<T>(Error error) 
        => new(default, false, error);

    public static Result<T> Failure<T>(Error error, T? value) where T : class 
        => value == null 
        ? new Result<T>(null, false, error) 
        : new Result<T>(value, false, error);
}

public sealed class Result<T>
{
    public Result(T? value, bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public T? Value { get; }
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
}