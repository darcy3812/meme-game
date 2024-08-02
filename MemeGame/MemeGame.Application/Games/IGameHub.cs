using MemeGame.Application.Games.Dto;

namespace MemeGame.Application.Games
{
    public interface IGameHub
    {
        Task NotifyGameCreated(GameListItemDto gameDto);
    }
}
