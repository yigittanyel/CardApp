namespace CardAppBackend.Models;
public sealed class Card
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;


    public Card()
    {
        
    }
    public Card(int id,string title, string name, string? address, string? phone)
    {
        Id = id;
        Title = title;
        Name = name;
        Address = address;
        Phone = phone;
    }

    public Card(string title, string name, string? address, string? phone)
    {
        Title = title;
        Name = name;
        Address = address;
        Phone = phone;
    }
}
