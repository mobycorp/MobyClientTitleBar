#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	MauiProgram.cs
//
// Modification History:
//	Date:			February 15, 2022
//	By:				Stephen S. Miller
//	Comment:		Creation
//
// Copyright (c) 2010-2022, Moby Corp.
//
// All Rights Reserved.  Reproduction or transmission in whole or in part, in any form or
// by any means, electronic, mechanical or otherwise, is prohibited without the prior
// written consent of Moby Corp.
//
// Licensed Material - Property of Moby Corp.
//
// Moby Corp.
// 392 Shirley Gordon Road
// Woodland, WA 98674-9644 USA
// 
// ***************************************************************************************

#endregion

using Microsoft.Maui.LifecycleEvents;

namespace MobyClient;

public static class MauiProgram {

	public static MauiApp CreateMauiApp () {

		Config.ExtendsContentIntoTitleBar = true;

        var builder = MauiApp.CreateBuilder ();

		_ = builder
			.UseMauiApp<App> ()
			.ConfigureFonts (fonts => {
				_ = fonts.AddFont ("Font Awesome 6 Brands-Regular-400.otf", "FaBrands");
				_ = fonts.AddFont ("Font Awesome 6 Duotone-Solid-900.otf", "FaDuotone");
				_ = fonts.AddFont ("Font Awesome 6 Pro-Light-300.otf", "FaLight");
				_ = fonts.AddFont ("Font Awesome 6 Pro-Regular-400.otf", "FaRegular");
				_ = fonts.AddFont ("Font Awesome 6 Pro-Solid-900.otf", "FaSolid");
				_ = fonts.AddFont ("Font Awesome 6 Pro-Thin-100.otf", "FaThin");
				_ = fonts.AddFont ("OpenSans-Regular.ttf", "OpenSansRegular");
				_ = fonts.AddFont ("OpenSans-Semibold.ttf", "OpenSansSemibold");
				_ = fonts.AddFont ("Segoe-Ui-Bold.ttf", "SegoeUiBold");
				_ = fonts.AddFont ("Segoe-Ui-Regular.ttf", "SegoeUiRegular");
				_ = fonts.AddFont ("Segoe-Ui-Semibold.ttf", "SegoeUiSemibold");
				_ = fonts.AddFont ("Segoe-Ui-Semilight.ttf", "SegoeUiSemilight");
			})
			.ConfigureLifecycleEvents (lifecycle => {
#if WINDOWS
				lifecycle
					.AddWindows (windows => windows.OnWindowCreated ((window) => window.ExtendsContentIntoTitleBar = Config.ExtendsContentIntoTitleBar));
#endif
            })
			.ConfigureServices ()
			.ConfigureViewModels ()
			.ConfigureViews ();

		// Get the application builder so we can add services to the mix...
		var app = builder.Build ();

		// Initialize the Moby client configuration manager.
		var mobyConfigurationManager = app.Services.GetService<IMobyConfigurationManager> ();

		return app;
	}
}