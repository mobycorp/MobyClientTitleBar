#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	FlyoutHeaderTemplate.cs
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

namespace MobyClient.ContentTemplates;

public partial class FlyoutHeaderTemplate : Grid {

	public FlyoutHeaderTemplate () {

		InitializeComponent ();

        Margin = Config.ExtendsContentIntoTitleBar ? new Thickness (0,-30,0,2) : new Thickness (0, -16, 0, 2);
    }

    private void Switch_Toggled (object sender, ToggledEventArgs e) {

		if (sender is Microsoft.Maui.Controls.Switch toggle && toggle.Parent != null && toggle.Parent.Parent != null) {
			if (toggle.Parent.Parent is AppShell) {
				var shell = toggle.Parent.Parent as AppShell;

				shell.FlyoutBehavior = toggle.IsToggled ? FlyoutBehavior.Locked : FlyoutBehavior.Flyout;
			}
		}
	}
}