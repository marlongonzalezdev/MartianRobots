namespace MartianRobots.API.Models;

public class ApiResponse
{
    public bool IsSuccessful { get; set; }
    public int ResponseCode { get; set; }
    public string ErrorMessage { get; set; }

}

public class ApiResponse<T> : ApiResponse
{
    public ApiResponse()
    {
    }

    public ApiResponse(T result, bool isSuccessful, int responseCode, string errorMessage = null)
    {
        Result = result;
        IsSuccessful = isSuccessful;
        ErrorMessage = errorMessage;
        ResponseCode = responseCode;
    }

    public T Result { get; set; }
}