using BuildingBlocks.Domain;

namespace BuildingBlocks.Domain
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error)
        {
            // if (isSuccess && error != null)
            //     throw new InvalidOperationException("A successful result cannot have an error.");

            // if (!isSuccess && error == null)
            //     throw new InvalidOperationException("A failure result must have an error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);

    }

    public class Result<TValue> : Result
    {
        public TValue? Value { get; }

        private  Result(TValue value, bool isSuccess, Error error) 
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, Error.None);
        public static new Result<TValue> Failure(Error error) => new Result<TValue>(default(TValue), false, error);
    }
}