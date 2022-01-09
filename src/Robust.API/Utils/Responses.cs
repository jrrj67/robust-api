using Robust.API.ViewModels;

namespace Robust.API.Utils
{
    public static class Responses
    {
        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel()
            {
                Message = message,
                Success = false,
                Data = errors,
            };
        }

        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel()
            {
                Message = "An internal error has occurred.",
                Success = false,
            };
        }
    }
}
