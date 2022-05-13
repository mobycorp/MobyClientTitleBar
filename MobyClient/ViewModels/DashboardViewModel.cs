#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	DashboardViewModel.cs
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

public class DashboardViewModel : ObservableObject {

	#region Constructors

	public DashboardViewModel (
		IMobyLogger logger,
		CalendarService calendarService,
		ContactsService contactsService,
		EmailService emailService,
		MessageService messageService,
		SharedContentService sharedContentService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (calendarService);
		Guard.IsNotNull (contactsService);
		Guard.IsNotNull (emailService);
		Guard.IsNotNull (messageService);
		Guard.IsNotNull (sharedContentService);

		_logger = logger;
		_calendarService = calendarService;
		_contactsService = contactsService;
		_emailService = emailService;
		_messageService = messageService;
		_sharedContentService = sharedContentService;

		InitializeViewModel ();
	}

	#endregion

	#region Properties

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if (_isInitialized) return;

		_logger.LogDebug ("Dashboard viewmodel is initialized.");

		_isInitialized = true;
	}

	#endregion

	#region Fields

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly CalendarService _calendarService;
	private readonly ContactsService _contactsService;
	private readonly EmailService _emailService;
	private readonly MessageService _messageService;
	private readonly SharedContentService _sharedContentService;

	#endregion
}