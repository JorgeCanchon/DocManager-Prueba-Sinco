using DocManager.Application._Resources;
using FluentValidation.Results;

namespace DocManager.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException() : base(ApplicationErrors.HasValidationError)
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = [.. failures.Select(f => f.ErrorMessage)];
    }
}
