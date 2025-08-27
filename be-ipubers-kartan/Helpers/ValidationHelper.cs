using FluentValidation.Results;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Constants;

namespace be_ipubers_kartan.Helpers
{
    public static class ValidationHelper
    {
        public static ModelResultDtos HandleValidationErrors(ValidationResult validationResult, string statusDescHeading)
        {
            var state = validationResult.Errors.FirstOrDefault();
            var customState = state?.CustomState as int?;

            var statusCode = customState ?? ResponseCodeMapping.ErrorValidation;
            var statusDesc = validationResult.Errors
                .Select(e => e.ErrorMessage)
                .Where(msg => !msg.StartsWith("'", StringComparison.Ordinal))
                .FirstOrDefault() ?? "Terjadi kesalahan validasi";

            return new ModelResultDtos
            {
                StatusCode = statusCode,
                StatusDesc = statusDesc,
                StatusDescHeading = statusDescHeading,
            };
        }
    }
}