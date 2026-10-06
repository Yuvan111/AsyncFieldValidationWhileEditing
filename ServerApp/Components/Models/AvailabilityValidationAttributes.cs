using System.ComponentModel.DataAnnotations;
using ServerApp.Components.Services;

namespace ServerApp.Components.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class UsernameAvailableAttribute()
    : AsyncValidationAttribute("Username is already taken.")
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        => throw new InvalidOperationException(
            $"{nameof(UsernameAvailableAttribute)} requires asynchronous validation.");

    protected override async Task<ValidationResult?> IsValidAsync(
        object? value,
        ValidationContext validationContext,
        CancellationToken cancellationToken)
    {
        if (value is not string username || string.IsNullOrWhiteSpace(username))
        {
            return ValidationResult.Success;
        }

        var checker = (IAvailabilityChecker?)validationContext.GetService(typeof(IAvailabilityChecker))
            ?? throw new InvalidOperationException($"{nameof(IAvailabilityChecker)} is not registered.");

        return await checker.IsUsernameAvailableAsync(username, cancellationToken)
            ? ValidationResult.Success
            : CreateValidationResult(validationContext);
    }

    private ValidationResult CreateValidationResult(ValidationContext validationContext)
        => new(ErrorMessageString, GetMemberNames(validationContext));

    private static IEnumerable<string>? GetMemberNames(ValidationContext validationContext)
        => validationContext.MemberName is null ? null : [validationContext.MemberName];
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class EmailAvailableAttribute()
    : AsyncValidationAttribute("Email is already taken.")
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        => throw new InvalidOperationException(
            $"{nameof(EmailAvailableAttribute)} requires asynchronous validation.");

    protected override async Task<ValidationResult?> IsValidAsync(
        object? value,
        ValidationContext validationContext,
        CancellationToken cancellationToken)
    {
        if (value is not string email || string.IsNullOrWhiteSpace(email))
        {
            return ValidationResult.Success;
        }

        var checker = (IAvailabilityChecker?)validationContext.GetService(typeof(IAvailabilityChecker))
            ?? throw new InvalidOperationException($"{nameof(IAvailabilityChecker)} is not registered.");

        return await checker.IsEmailAvailableAsync(email, cancellationToken)
            ? ValidationResult.Success
            : CreateValidationResult(validationContext);
    }

    private ValidationResult CreateValidationResult(ValidationContext validationContext)
        => new(ErrorMessageString, GetMemberNames(validationContext));

    private static IEnumerable<string>? GetMemberNames(ValidationContext validationContext)
        => validationContext.MemberName is null ? null : [validationContext.MemberName];
}
