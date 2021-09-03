using FluentValidation;
using System.Text;
//using System.Globalization;
//using System.Text.RegularExpressions;

namespace News.Helpers
{

	public static class Utils
	{
		public static DateTime UtcTicks2Local(long ticks)
		{
			DateTime dt = new DateTime(ticks).ToLocalTime();
			return dt;
		}

		public static FluentValueValidator<string> FluentEmailValidate(bool val)
		{

			FluentValueValidator<string> validateEmail = default;
			if (val) // email panel open
				validateEmail = new(s => s
					.NotEmpty().WithMessage("Email address is required")
					.EmailAddress().WithMessage("A valid email is required")
					.MaximumLength(100).WithMessage("Max length 100 characters"));
			else // email panel closed
				validateEmail = new(s => s
					.MinimumLength(0)
					.MaximumLength(100).WithMessage("Max length 100 characters"));

			return validateEmail;
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
				FluentValueValidator<string> validate = new(x =>
					x.Length(minLength, maxLength).WithMessage(errorMessage));
				return validate;
			}

			FluentValueValidator<string> validateRequired = new(x =>
				x.NotEmpty().WithMessage(requiredMessage).Length(minLength, maxLength).WithMessage(errorMessage));
			return validateRequired;
		}

		public static string Abbreviate(string input, int maxLength)
		{
			if (input.Length >= maxLength)
				input = input.Substring(0, maxLength - 3) + "...";
			return input;
		}

		public static string FromB64(string b64str)
		{
			string decrypted;
			try
			{
				byte[] outputBytes = Convert.FromBase64String(b64str);
				decrypted = Encoding.ASCII.GetString(outputBytes);
			}
			catch (FormatException fe)
			{
				decrypted = fe.Message;
			}
			return decrypted;
		}

		public static string ToB64(string input)
		{
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			return Convert.ToBase64String(inputBytes);
		}

		//public static bool IsValidEmail(string email)
		//{
		//	// see: https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format

		//	if (string.IsNullOrWhiteSpace(email))
		//		return false;

		//	try
		//	{
		//		// Normalize the domain
		//		email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
		//							  RegexOptions.None, TimeSpan.FromMilliseconds(200));

		//		// Examines the domain part of the email and normalizes it.
		//		string DomainMapper(Match match)
		//		{
		//			// Use IdnMapping class to convert Unicode domain names.
		//			var idn = new IdnMapping();

		//			// Pull out and process domain name (throws ArgumentException on invalid)
		//			string domainName = idn.GetAscii(match.Groups[2].Value);

		//			return match.Groups[1].Value + domainName;
		//		}
		//	}
		//	catch (RegexMatchTimeoutException e)
		//	{
		//		return false;
		//	}
		//	catch (ArgumentException e)
		//	{
		//		return false;
		//	}

		//	try
		//	{
		//		return Regex.IsMatch(email,
		//			@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		//			RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
		//	}
		//	catch (RegexMatchTimeoutException)
		//	{
		//		return false;
		//	}
		//}
	}
}
