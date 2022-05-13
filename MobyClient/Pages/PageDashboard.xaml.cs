#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	PageDashboard.cs
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

namespace MobyClient.Pages;

public partial class PageDashboard : ContentPage {

	#region Constructors

	public PageDashboard (DashboardViewModel dashboardViewModel) {

		Guard.IsNotNull (dashboardViewModel);

		InitializeComponent ();

		BindingContext = dashboardViewModel;
	}

	#endregion

	#region Properties

	#endregion

	#region Methods

	#endregion

	#region Fields

	#endregion
}