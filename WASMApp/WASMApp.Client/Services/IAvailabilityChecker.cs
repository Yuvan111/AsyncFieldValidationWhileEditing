namespace WASMApp.Client.Services;

public interface IAvailabilityChecker
{
    Task<bool> IsUsernameAvailableAsync(string username, CancellationToken cancellationToken);

    Task<bool> IsEmailAvailableAsync(string email, CancellationToken cancellationToken);
}
