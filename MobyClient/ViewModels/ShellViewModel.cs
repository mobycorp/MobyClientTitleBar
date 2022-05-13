#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	ShellViewModel.cs
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

namespace MobyClient.ViewModels;

public partial class ShellViewModel : ObservableObject {

    #region Constructors

    public ShellViewModel () {

        Calendar = new AppSection {
            TargetType = typeof (PageCalendar),
            Title = AppResources.PageCalendar
        };

        Contacts = new AppSection {
            TargetType = typeof (PageContacts),
            Title = AppResources.PageContacts
        };

        Dashboard = new AppSection {
            TargetType = typeof (PageDashboard),
            Title = AppResources.PageDashboard
        };

        Emails = new AppSection {
            TargetType = typeof (PageEmails),
            Title = AppResources.PageEmails
        };

        Messages = new AppSection {
            TargetType = typeof (PageMessages),
            Title = AppResources.PageMessages
        };

        SharedContent = new AppSection {
            TargetType = typeof (PageSharedContent),
            Title = AppResources.PageSharedContent
        };

        FlyoutOpen = Config.IsDesktop;
    }

    #endregion

    #region Properties

    public AppSection Calendar { get; set; }

    public AppSection Contacts { get; set; }

    public AppSection Dashboard { get; set; }

    public AppSection Emails { get; set; }

    public AppSection Messages { get; set; }

    public AppSection SharedContent { get; set; }

    [ObservableProperty]
    private bool flyoutOpen;

    #endregion

    #region Methods

    #endregion

    #region Fields

    #endregion
}