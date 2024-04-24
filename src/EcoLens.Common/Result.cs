namespace EcoLens.Common;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; private set; }

    protected internal Result(bool isSuccess, Error? error = null)
    {
        if (isSuccess && error != null)
            throw new InvalidOperationException();

        if (!isSuccess && error == null)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Ok()
    {
        return new Result(true);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true);
    }

    public static Result Fail(Error error)
    {
        return new Result(false, error);
    }

    public static Result<T> Fail<T>(Error error)
    {
        return new Result<T>(false, error);
    }
}
