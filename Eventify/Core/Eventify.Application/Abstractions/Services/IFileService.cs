namespace Eventify.Application.Abstractions.Services;

public interface IFileService
{
    Task SaveTextAsync(string text, string path);
}
