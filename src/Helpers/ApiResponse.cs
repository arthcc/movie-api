namespace FilmeApi2.Helpers
{
    /// <summary>
    /// Classe de resposta da API.
    /// Essa é uma classe genérica que aceita qualquer tipo de objeto como parâmetro.
    /// Ela pode ser reutilizada por todas as chamadas da API.
    /// Padronizando a resposta que o front-end irá receber e facilitando o tratamento de erros.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        public static ApiResponse<T> Success(T data,  int statusCode = 200)
        {
            return new ApiResponse<T>(data, "Requisição feita com Sucesso", statusCode);
        }

        public static ApiResponse<T> Error(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(default(T), message, statusCode);
        }


    }
}
