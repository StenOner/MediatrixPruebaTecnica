namespace MediatrixPruebaTexnica.UseCasesPorts.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> Errors { get; set; } = [];

        public static Result<T> SuccessResult(T data)
        {
            return new Result<T>
            {
                Success = true,
                Data = data
            };
        }

        public static Result<T> FailureResult(string errorMessage)
        {
            return new Result<T>
            {
                Success = false,
                ErrorMessage = errorMessage,
                Errors = [errorMessage]
            };
        }

        public static Result<T> FailureResult(List<string> errors)
        {
            return new Result<T>
            {
                Success = false,
                ErrorMessage = string.Join(", ", errors),
                Errors = errors
            };
        }
    }
}
