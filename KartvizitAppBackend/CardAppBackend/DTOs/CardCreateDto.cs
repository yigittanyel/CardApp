namespace CardAppBackend.DTOs
{
    public record CardCreateDto(string title,string name,string? address,string? phone)
    {
    }
}
