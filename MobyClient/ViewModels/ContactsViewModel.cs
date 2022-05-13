#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	ContactsViewModel.cs
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

public class ContactsViewModel : ObservableObject {

	#region Constructors

	public ContactsViewModel (IMobyLogger logger, ContactsService contactsService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (contactsService);

		_logger = logger;
		_contactsService = contactsService;

		InitializeViewModel ();
	}

	#endregion

	#region Properties

	public ObservableCollection<ContactsViewModel> Contacts { get; private set; }

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if (_isInitialized) return;

		Contacts = new ObservableCollection<ContactsViewModel> ();

		_logger.LogDebug ("Contacts viewmodel is initialized.");

		_isInitialized = true;
	}

	#endregion

	#region Fields

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly ContactsService _contactsService;

	#endregion
}