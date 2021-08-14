using MudBlazor;

namespace News.Helpers
{
	public static class Design
	{
		public static Typography MultiTypography(string font = "Ubuntu")
		{
			Typography typography = new();
			// https://github.com/Garderoben/MudBlazor/blob/dev/src/MudBlazor/Themes/Models/Typography.cs
			// https://developers.google.com/fonts/docs/css2#axis_ranges
			typography.Default = new Default()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".875rem",
				FontWeight = 400,
				LineHeight = 1.43,
				LetterSpacing = ".01071em"
			};
			typography.H1 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "6rem",
				FontWeight = 300,
				LineHeight = 1.167,
				LetterSpacing = "-.01562em"
			};
			typography.H2 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "3.75rem",
				FontWeight = 300,
				LineHeight = 1.2,
				LetterSpacing = "-.00833em"
			};
			typography.H3 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "3rem",
				FontWeight = 300,
				LineHeight = 1.167,
				LetterSpacing = "0"
			};
			typography.H4 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "2.125rem",
				FontWeight = 300,
				LineHeight = 1.235,
				LetterSpacing = ".00735em"
			};
			typography.H5 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "1.5rem",
				FontWeight = 300,
				LineHeight = 1.334,
				LetterSpacing = "0"
			};
			typography.H6 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "1.25rem",
				FontWeight = 400,
				LineHeight = 1.6,
				LetterSpacing = ".0075em"
			};
			typography.Subtitle1 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "1rem",
				FontWeight = 400,
				LineHeight = 1.75,
				LetterSpacing = ".00938em"
			};
			typography.Subtitle2 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".875rem",
				FontWeight = 500,
				LineHeight = 1.57,
				LetterSpacing = ".00714em"
			};
			typography.Body1 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = "1rem",
				FontWeight = 400,
				LineHeight = 1.5,
				LetterSpacing = ".00938em"
			};
			typography.Body2 = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".875rem",
				FontWeight = 400,
				LineHeight = 1.43,
				LetterSpacing = ".01071em"
			};
			typography.Button = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".875rem",
				FontWeight = 500,
				LineHeight = 1.75,
				LetterSpacing = ".02857em"
			};
			typography.Caption = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".75rem",
				FontWeight = 400,
				LineHeight = 1.66,
				LetterSpacing = ".03333em"
			};
			typography.Overline = new()
			{
				FontFamily = new[] { font, "Helvetica", "Arial", "sans-serif" },
				FontSize = ".75rem",
				FontWeight = 400,
				LineHeight = 2.66,
				LetterSpacing = ".08333em"
			};
			return typography;
		}

		//, // #TODO
		//Shadows = new Shadow() // #TODO
		//{
		//    Elevation = new string[] {
		//        "none",
		//        "0px 2px 1px -1px rgba(13, 17, 23, 0.2),0px 1px 1px 0px rgba(13, 17, 23, 0.14),0px 1px 3px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 3px 1px -2px rgba(13, 17, 23, 0.2),0px 2px 2px 0px rgba(13, 17, 23, 0.14),0px 1px 5px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 3px 3px -2px rgba(13, 17, 23, 0.2),0px 3px 4px 0px rgba(13, 17, 23, 0.14),0px 1px 8px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 2px 4px -1px rgba(13, 17, 23, 0.2),0px 4px 5px 0px rgba(13, 17, 23, 0.14),0px 1px 10px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 3px 5px -1px rgba(13, 17, 23, 0.2),0px 5px 8px 0px rgba(13, 17, 23, 0.14),0px 1px 14px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 3px 5px -1px rgba(13, 17, 23, 0.2),0px 6px 10px 0px rgba(13, 17, 23, 0.14),0px 1px 18px 0px rgba(13, 17, 23, 0.12)",
		//        "0px 4px 5px -2px rgba(13, 17, 23, 0.2),0px 7px 10px 1px rgba(13, 17, 23, 0.14),0px 2px 16px 1px rgba(13, 17, 23, 0.12)",
		//        "0px 5px 5px -3px rgba(13, 17, 23, 0.2),0px 8px 10px 1px rgba(13, 17, 23, 0.14),0px 3px 14px 2px rgba(13, 17, 23, 0.12)",
		//        "0px 5px 6px -3px rgba(13, 17, 23, 0.2),0px 9px 12px 1px rgba(13, 17, 23, 0.14),0px 3px 16px 2px rgba(13, 17, 23, 0.12)",
		//        "0px 6px 6px -3px rgba(13, 17, 23, 0.2),0px 10px 14px 1px rgba(13, 17, 23, 0.14),0px 4px 18px 3px rgba(13, 17, 23, 0.12)",
		//        "0px 6px 7px -4px rgba(13, 17, 23, 0.2),0px 11px 15px 1px rgba(13, 17, 23, 0.14),0px 4px 20px 3px rgba(13, 17, 23, 0.12)",
		//        "0px 7px 8px -4px rgba(13, 17, 23, 0.2),0px 12px 17px 2px rgba(13, 17, 23, 0.14),0px 5px 22px 4px rgba(13, 17, 23, 0.12)",
		//        "0px 7px 8px -4px rgba(13, 17, 23, 0.2),0px 13px 19px 2px rgba(13, 17, 23, 0.14),0px 5px 24px 4px rgba(13, 17, 23, 0.12)",
		//        "0px 7px 9px -4px rgba(13, 17, 23, 0.2),0px 14px 21px 2px rgba(13, 17, 23, 0.14),0px 5px 26px 4px rgba(13, 17, 23, 0.12)",
		//        "0px 8px 9px -5px rgba(13, 17, 23, 0.2),0px 15px 22px 2px rgba(13, 17, 23, 0.14),0px 6px 28px 5px rgba(13, 17, 23, 0.12)",
		//        "0px 8px 10px -5px rgba(13, 17, 23, 0.2),0px 16px 24px 2px rgba(13, 17, 23, 0.14),0px 6px 30px 5px rgba(13, 17, 23, 0.12)",
		//        "0px 8px 11px -5px rgba(13, 17, 23, 0.2),0px 17px 26px 2px rgba(13, 17, 23, 0.14),0px 6px 32px 5px rgba(13, 17, 23, 0.12)",
		//        "0px 9px 11px -5px rgba(13, 17, 23, 0.2),0px 18px 28px 2px rgba(13, 17, 23, 0.14),0px 7px 34px 6px rgba(13, 17, 23, 0.12)",
		//        "0px 9px 12px -6px rgba(13, 17, 23, 0.2),0px 19px 29px 2px rgba(13, 17, 23, 0.14),0px 7px 36px 6px rgba(13, 17, 23, 0.12)",
		//        "0px 10px 13px -6px rgba(13, 17, 23, 0.2),0px 20px 31px 3px rgba(13, 17, 23, 0.14),0px 8px 38px 7px rgba(13, 17, 23, 0.12)",
		//        "0px 10px 13px -6px rgba(13, 17, 23, 0.2),0px 21px 33px 3px rgba(13, 17, 23, 0.14),0px 8px 40px 7px rgba(13, 17, 23, 0.12)",
		//        "0px 10px 14px -6px rgba(13, 17, 23, 0.2),0px 22px 35px 3px rgba(13, 17, 23, 0.14),0px 8px 42px 7px rgba(13, 17, 23, 0.12)",
		//        "0px 11px 14px -7px rgba(13, 17, 23, 0.2),0px 23px 36px 3px rgba(13, 17, 23, 0.14),0px 9px 44px 8px rgba(13, 17, 23, 0.12)",
		//        "0px 11px 15px -7px rgba(13, 17, 23, 0.2),0px 24px 38px 3px rgba(13, 17, 23, 0.14),0px 9px 46px 8px rgba(13, 17, 23, 0.12)",
		//        "0px 5px 5px -3px rgba(13, 17, 23, .06), 0 8px 10px 1px rgba(13, 17, 23, .042), 0 3px 14px 2px rgba(13, 17, 23, .036)"
		//    }
		//}
	}
}
