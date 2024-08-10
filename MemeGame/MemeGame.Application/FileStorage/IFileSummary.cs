namespace MemeGame.Application.FileStorage
{
    public interface IFileSummary
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public Stream Stream { get; set; }
    }
}
