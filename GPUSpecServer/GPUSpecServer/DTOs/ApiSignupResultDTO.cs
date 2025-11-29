namespace GPUSpecServer.DTOs
{
    public class ApiSignupResultDTO
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? Token { get; set; }
    }
}
