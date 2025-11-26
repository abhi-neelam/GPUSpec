namespace GPUSpecServer.DTOs
{
    public class ApiLoginResultDTO
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? Token { get; set; }
    }
}
