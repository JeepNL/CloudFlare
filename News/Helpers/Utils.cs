using FluentValidation;
using System.Text;

namespace News.Helpers
{
	public static class Utils
	{
		public static DateTime UtcTicks2Local(long ticks)
		{
			DateTime dt = new DateTime(ticks).ToLocalTime();
			return dt;
		}

		// auth 0, name 1, first 2, id  3, screen 4
		public static Array FillUserStateArray(string auth = "false", string name = "", string first = "", string id = "", string screen = "")
		{
			Array tmpArr = Array.CreateInstance(typeof(String), 5);
			tmpArr.SetValue(auth, 0);
			tmpArr.SetValue(name, 1);
			tmpArr.SetValue(first, 2);
			tmpArr.SetValue(id, 3);
			tmpArr.SetValue(screen, 4);
			return tmpArr;
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

		public static FluentValueValidator<string> FluentValidate(int maxLength = 20, bool required = default, string label = "", int minLength = default)
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
			if (string.IsNullOrEmpty(input))
				return string.Empty;
			else if (input.Length >= maxLength)
				input = input.Substring(0, maxLength - 3) + "...";
			return input;
		}

		public static string FromB64(string b64str)
		{
			string b64;
			try
			{
				byte[] outputBytes = Convert.FromBase64String(b64str);
				b64 = Encoding.ASCII.GetString(outputBytes);
			}
			catch (FormatException fe)
			{
				b64 = fe.Message;
			}
			return b64;
		}

		public static string ToB64(string input)
		{
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			return Convert.ToBase64String(inputBytes);
		}
	}
}
