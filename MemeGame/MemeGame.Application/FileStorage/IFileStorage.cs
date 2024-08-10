namespace MemeGame.Application.FileStorage
{
    public interface IFileStorage
    {
        Task<IFileSummary> SaveAsync(IFileSummary fileSummary, Stream stream);

        Task<IFileSummary> GetContentsAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}
