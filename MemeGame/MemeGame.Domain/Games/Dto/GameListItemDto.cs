using Mapster;

namespace MemeGame.Domain.Games.Dto
{
    public class GameListItemDto : IMapFrom<Game>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersCount { get; set; }
        public GameSettingsDto GameSettings { get; set; }

        public void ConfigureMapping(TypeAdapterConfig config)
        {
            config.NewConfig<Game, GameListItemDto>()
                            .Map(g => g.UsersCount, g => g.GameUsers.Count);
        }
    }
}