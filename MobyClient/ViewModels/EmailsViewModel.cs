#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	EmailsViewModel.cs
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

public class EmailsViewModel : ObservableObject {

	#region Constructors

	public EmailsViewModel (IMobyLogger logger, EmailService emailService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (emailService);

		_logger = logger;
		_emailService = emailService;

		InitializeViewModel ();
	}

	#endregion

	#region Properties

	public ObservableCollection<EmailsViewModel> Emails { get; private set; }

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if (_isInitialized) return;

		Emails = new ObservableCollection<EmailsViewModel> ();

		_logger.LogDebug ("Emails viewmodel is initialized.");

		_isInitialized = true;
	}

	#endregion

	#region Fields

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly EmailService _emailService;

	#endregion
}