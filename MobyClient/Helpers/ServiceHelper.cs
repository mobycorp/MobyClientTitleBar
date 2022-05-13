#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	SettingsHelper.cs
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

namespace MobyClient.Helpers;

public static class ServiceHelper {

	public static TService GetService<TService> () => Current.GetService<TService> ();

	public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
		MauiWinUIApplication.Current.Services;
#elif ANDROID
		MauiApplication.Current.Services;
#elif IOS || MACCATALYST
		MauiUIApplicationDelegate.Current.Services;
#else
	null;
#endif
}