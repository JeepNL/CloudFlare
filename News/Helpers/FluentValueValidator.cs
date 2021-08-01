using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Helpers
{
	/// <summary>
	/// A glue class to make it easy to define validation rules for single values using FluentValidation
	/// You can reuse this class for all your fields, like for the credit card rules above.
	/// See code "Using Fluent Validation" https://mudblazor.com/wasm/components/form
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class FluentValueValidator<T> : AbstractValidator<T>
	{
		public FluentValueValidator(Action<IRuleBuilderInitial<T, T>> rule)
		{
			rule(RuleFor(x => x));
		}

		private IEnumerable<string> ValidateValue(T arg)
		{
			if (arg is not null)
			{
				var result = Validate(arg);
				if (result.IsValid)
					return Array.Empty<string>();
				return result.Errors.Select(e => e.ErrorMessage);
			}
			else
			{
				// NULL ERROR, must not happen, fields need to be initialized with String.Empty;
				List<string> error = new() { "Error: Field Is Null" };
				return error;
			}
		}

		public Func<T, IEnumerable<string>> Validation => ValidateValue;
	}
}
