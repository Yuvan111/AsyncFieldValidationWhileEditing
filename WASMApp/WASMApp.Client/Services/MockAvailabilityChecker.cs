namespace WASMApp.Client.Services;

public sealed class MockAvailabilityChecker : IAvailabilityChecker
{
    private static readonly HashSet<string> TakenUsernames = new(StringComparer.OrdinalIgnoreCase)
    {
        "admin",
        "guest",
        "sam",
        "takenuser",
    };

    private static readonly HashSet<string> TakenEmails = new(StringComparer.OrdinalIgnoreCase)
    {
        "admin@example.com",
        "taken@example.com",
        "sam@example.com",
    };

    public async Task<bool> IsUsernameAvailableAsync(string username, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1200), cancellationToken);
        return !TakenUsernames.Contains(username.Trim());
    }

    public async Task<bool> IsEmailAvailableAsync(string email, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
        return !TakenEmails.Contains(email.Trim());
    }
}
