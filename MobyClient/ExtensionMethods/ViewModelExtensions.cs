#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	ViewModelExtensions.cs
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

namespace MobyClient.ExtensionMethods;

public static class ViewModelExtensions {

    public static MauiAppBuilder ConfigureViewModels (this MauiAppBuilder builder) {

		_ = builder.Services.AddSingleton<CalendarViewModel> ();
		_ = builder.Services.AddSingleton<ContactsViewModel> ();
		_ = builder.Services.AddSingleton<DashboardViewModel> ();
		_ = builder.Services.AddSingleton<EmailsViewModel> ();
		_ = builder.Services.AddTransient<LoginViewModel> ();
		_ = builder.Services.AddSingleton<MessagesViewModel> ();
		_ = builder.Services.AddSingleton<SharedContentViewModel> ();

		return builder;
    }
}