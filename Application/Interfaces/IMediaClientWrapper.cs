namespace Application.Interfaces
{
    public class IMediaClientWrapper
    {
        Task<ResultList> GetMediaByTitle(string title);
        Task<MediaInfo> GetMediaById(string id);
    }
}
