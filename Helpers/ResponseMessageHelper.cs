using TaskManagement.Constants;

namespace TaskManagement.Helpers
{
    public static class ResponseMessageHelper
    {
        public static string GetMessage(ResponseMessage message)
        {
            return message switch
            {
                ResponseMessage.Success => "Request was successful.",
                ResponseMessage.Created => "Tasks created successfully.",
                ResponseMessage.Updated => "Tasks updated successfully.",
                ResponseMessage.Deleted => "Tasks deleted successfully.",
                ResponseMessage.NotFound => "Tasks not found.",
                ResponseMessage.ValidationError => "Invalid input data.",
                ResponseMessage.ServerError => "An internal server error occurred.",
                ResponseMessage.Unauthorized => "Unauthorized access.",
                ResponseMessage.Forbidden => "Access forbidden.",
                _ => "Unknown status."
            };
        }
    }
}
