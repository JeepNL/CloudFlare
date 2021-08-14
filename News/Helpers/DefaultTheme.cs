using MudBlazor;

namespace News.Helpers
{
	public static class DefaultTheme
	{
		public static Palette DefaultPalette()
		{
			Palette defaultPalette = new()
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
				SecondaryContrastText = "1b1b1bff", // Eerie Black

				//TertiaryContrastText = "#",
				//TertiaryDarken = "#",
				//TertiaryLighten = "#",
				Tertiary = "#ba160cff",  // Red

				//DarkContrastText = "#",
				//DarkDarken = "#",
				//DarkLighten = "#",
				Dark = "#1b1b1bff", // Eerie Black

				//InfoLighten = "", // #TODO What/Where?
				Info = "#c0c0c0ff", // Gray Light
				InfoContrastText = "1b1b1bff", // Dark (Eerie Black)
				InfoDarken = "555555ff", // Gray Dark

				//SuccessContrastText = "#",
				//SuccessDarken = "#",
				//SuccessLighten = "#",
				Success = "#f94d00ff", // Primary

				//WarningLighten = "#",
				Warning = "#ffc40cff", // Secondary
				WarningContrastText = "1b1b1bff", // Dark (Eerie Black)
				WarningDarken = "555555ff", // Gray Dark

				//ErrorContrastText = "#",
				//ErrorDarken = "#",
				//ErrorLighten = "#",
				Error = "#ba160cff", // Tertiary - also form input error

				AppbarText = "#fffafaff", // Drawer
				AppbarBackground = "#f94d00ff", // Primary

				LinesDefault = "#555555ff", // Gray Dark
				LinesInputs = "#808080ff", // Gray
				Divider = "#c0c0c0ff", // Gray Light
				DividerLight = "#dcdcdcff", // Gray Lighter

				Background = "#f8f8ffff", // Ghost White
				BackgroundGrey = "#dcdcdcff", // Gray Lighter
				Surface = "#f5f5f5ff", // White Smoke - Background Tables + Background Modal + Background Paper - No ransparancyT
				DrawerBackground = "#fffafaff", // Snow White
				DrawerText = "#1b1b1bff", // Dark (Eerie Black)
				DrawerIcon = "#555555", // Davy's Gray
				OverlayDark = "rgba(27,27,27, 0.50)", // Dark (Eerie Black) - Transparant
				OverlayLight = "rgba(27,27,27, 0.25)", // Dark (Eerie Black) - Transparant

				TableHover = "rgba(249,77,0, 0.15)", // Primary - Transparant - Table Row Select - Also For Selected Row (GrpcBlogger.Razor)
				TableLines = "rgba(0,0,0, 0.15)", // Black - Transparant
				TableStriped = "rgba(249,77,0, 0.05)", // Primary - Transparant

				TextPrimary = "#1b1b1bff", // Dark (Eerie Black) - Default Text / Input Text
				TextSecondary = "#555555ff", // Gray Dark - Input Helper Text
				TextDisabled = "#c0c0c0ff", // Gray Light - Input Text Disabled
				ActionDefault = "#f94d00ff", // Primary Input Text Box Hover / MudIconButton default
				ActionDisabled = "#c0c0c0ff", // Gray
				ActionDisabledBackground = "#dcdcdcff", // Gray Lighter

				HoverOpacity = 0.08,  // selected drawer text - default 0.06

				// Shades of gray"
				GrayLighter = "#dcdcdcff",
				GrayLight = "#c0c0c0ff",
				GrayDefault = "#808080ff",
				GrayDark = "#555555ff",
				GrayDarker = "#555555ff" // Gray Dark - Not darker => for tooltip background

			};
			return defaultPalette;
		}
	}
}
