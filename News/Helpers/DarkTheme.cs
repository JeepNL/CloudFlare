using MudBlazor;

namespace News.Helpers
{
	public static class DarkTheme
	{
		public static Palette DarkPalette()
		{
			Palette darkPalette = new()
			{
				Black = "#000000",
				White = "#ffffff",

				//PrimaryContrastText = "#",
				//PrimaryDarken = "#",
				//PrimaryLighten = "#",
				Primary = "#f94d00ff",  // Orange - Btn/Lnk

				//SecondaryDarken = "#",
				//SecondaryLighten = "#",
				Secondary = "#ffc40cff",  // Yellow
				SecondaryContrastText = "#343434ff", // Jet

				//TertiaryContrastText = "#",
				//TertiaryDarken = "#",
				//TertiaryLighten = "#",
				Tertiary = "#ba160cff",  // Red

				//DarkContrastText = "#",
				//DarkDarken = "#",
				//DarkLighten = "#",
				Dark = "#080808ff", // # Vampire black - Default Square

				//InfoLighten = "#", //
				//Info = "#", //
				Info = "#c0c0c0ff", //# Silver
				InfoContrastText = "#080808ff", // Vampire Black
				InfoDarken = "#f8f8ffff", // Ghost White

				//SuccessContrastText = "#",
				//SuccessDarken = "#",
				//SuccessLighten = "#",
				Success = "#f94d00ff", // Primary

				//WarningDarken = "#", //
				//WarningLighten = "#",
				Warning = "#ffc40cff", // Secondary
				WarningContrastText = "#1a1110ff", // Licorice

				//ErrorContrastText = "",
				//ErrorDarken = "",
				//ErrorLighten = "",
				Error = "#ba160cff", // Tertiary - also form input error

				AppbarText = "#f8f8ffff", // Ghost White
				AppbarBackground = "#f94d00ff", // Primary

				LinesDefault = "#555555ff", // Gray Dark
				LinesInputs = "#808080ff", // Gray
				Divider = "#c0c0c0ff", // Gray Light
				DividerLight = "#dcdcdcff", // Gray Lighter

				Background = "#242424ff", // Gray 242424 (36, 36, 36))
				BackgroundGrey = "#dcdcdcff", // Gray Lighter
				Surface = "#1b1b1bff", // Eerie Black - Background Tables + Background Modal + Background Paper - No Transparancy
				DrawerBackground = "#343434ff", // Jet
				DrawerText = "#f8f8ffff", // Ghost White
				DrawerIcon = "#808080ff", // Trolley Grey
				OverlayDark = "rgba(8,8,8, 0.50)", // Dark (Vampire Black) - Transparant
				OverlayLight = "rgba(8,8,8, 0.25)", // Dark (Vampire Black) - Transparant

				TableHover = "rgba(249,77,0, 0.30)", // Primary - Transparant - Table Row Select - Also For Selected Row (GrpcBlogger.Razor)
				TableLines = "rgba(255,255,255, 0.15)", // White Transparant
				TableStriped = "rgba(249,77,0, 0.05)", // Primary - Transparant

				TextPrimary = "#f8f8ffff", // Ghost White - Default Text / Input Text
				TextSecondary = "#c0c0c0ff", // Silver - Input Helper Text
				TextDisabled = "#808080ff", // Gray - Input Text Disabled
				ActionDefault = "#f94d00ff", // Primary - Input Text Box Hover / MudIconButton default
				ActionDisabled = "#555555ff", // Davy's Gray
				ActionDisabledBackground = "#343434ff", // Jet

				HoverOpacity = 0.08,  // selected drawer text - default 0.06

				// Shades of gray"
				GrayLighter = "#dcdcdcff",
				GrayLight = "#c0c0c0ff",
				GrayDefault = "#808080ff",
				GrayDark = "#555555ff",
				GrayDarker = "#414a4cff" // Outer Space - Not darker => for tooltip background
			};
			return darkPalette;
		}
	}
}
