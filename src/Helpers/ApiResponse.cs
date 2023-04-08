namespace FilmeApi2.Helpers
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse(T data, string message, int statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        public static ApiResponse<T> Success(T data, int statusCode = 200)
        {
            return new ApiResponse<T>(data, null, statusCode);
        }

        public static ApiResponse<T> Error(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(default(T), message, statusCode);
        }
    }
}
