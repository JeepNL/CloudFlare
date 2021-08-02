using FluentValidation;
using System;

namespace News.Helpers
{
	public static class Utils
	{
		public static DateTime UtcTicks2Local(long ticks)
		{
			DateTime dt = new DateTime(ticks).ToLocalTime();
			return dt;
		}

		public static FluentValueValidator<string> FluentValidate(int maxLength = 20, bool required = default, string label = default, int minLength = default)
		{
			if (required && minLength == default)
				minLength = 1;

			string errorMessage = $"in: {minLength}, max: {maxLength} chars."; // 'm' (or 'M') for 'min' is added next
			errorMessage = (label == default) ? $"M{errorMessage}" : $"{label} m{errorMessage}";

			string requiredMessage = string.Empty;
			if (required)
				requiredMessage = (label == default) ? "Required" : $"{label} required";

			if (!required)
			{
				FluentValueValidator<string> validate = new FluentValueValidator<string>(x =>
					x.Length(minLength, maxLength).WithMessage(errorMessage));
				return validate;
			}

			FluentValueValidator<string> validateRequired = new FluentValueValidator<string>(x =>
				x.NotEmpty().WithMessage(requiredMessage).Length(minLength, maxLength).WithMessage(errorMessage));
			return validateRequired;
		}
	}
}
