namespace ServerApp.Components.Services;

public sealed class MockAvailabilityChecker : IAvailabilityChecker
{
    private const string FaultingUsername = "error";
    private const string FaultingEmail = "error@example.com";
    private const string SlowTakenUsername = "takenuser";
    private const string FastAvailableUsername = "newuser";

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
        var normalizedUsername = username.Trim();
        var delay = normalizedUsername switch
        {
            SlowTakenUsername => TimeSpan.FromSeconds(5),
            FastAvailableUsername => TimeSpan.FromSeconds(1),
            _ => TimeSpan.FromSeconds(3),
        };

        await Task.Delay(delay, cancellationToken);

        if (string.Equals(normalizedUsername, FaultingUsername, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("The username availability service is unavailable.");
        }

        return !TakenUsernames.Contains(normalizedUsername);
    }

    public async Task<bool> IsEmailAvailableAsync(string email, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        var normalizedEmail = email.Trim();
        if (string.Equals(normalizedEmail, FaultingEmail, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("The email availability service is unavailable.");
        }

        return !TakenEmails.Contains(normalizedEmail);
    }
}
