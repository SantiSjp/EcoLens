namespace EcoLens.Common;

public class Result<T> : Result
{
    public T? Value { get; private set; }

    protected internal Result(T value, bool isSuccess, Error? error = null) : base(isSuccess, error)
    {
        Value = value;
    }

    protected internal Result(bool isSuccess, Error? error = null) : base(isSuccess, error)
    {
    }
}
