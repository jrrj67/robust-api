namespace Robust.API.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; } = default!;
        public bool Success { get; set; } = default!;
        public dynamic Data { get; set; } = default!;
    }
}
