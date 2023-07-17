using CardAppBackend.DTOs;
using CardAppBackend.Models;
using Mapster;

namespace CardAppBackend.MapperProfile;

public class CardMapperProfile
{
    public CardMapperProfile()
    {
        TypeAdapterConfig<CardCreateDto, Card>.NewConfig()
           .Map(dest => dest.Title, src => src.title)
           .Map(dest => dest.Name, src => src.name)
           .Map(dest => dest.Address, src => src.address)
           .Map(dest => dest.Phone, src => src.phone);
    }

    public Card Map(CardCreateDto cardDto)
    {
        return cardDto.Adapt<Card>();
    }
}
