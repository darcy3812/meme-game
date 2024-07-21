using Mapster;
using MemeGame.Domain.Games;
using MemeGame.Domain.Games.Dto;

namespace MemeGame.Application.Games.Dto
{
    public class GameListItemDto : IRegister
    {
        public string Name { get; set; }
        public int UsersCount { get; set; }
        public GameSettingsDto GameSettings { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Game, GameListItemDto>()
                .Map(g => g.UsersCount, g => g.Users.Count);
        }
    }
}