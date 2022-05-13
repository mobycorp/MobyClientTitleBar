#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	MessagesViewModel.cs
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

public class MessagesViewModel : ObservableObject {

	#region Constructors

	public MessagesViewModel (IMobyLogger logger, MessageService messageService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (messageService);

		_logger = logger;
		_messageService = messageService;

		InitializeViewModel ();
	}

	#endregion

	#region Properties

	public ObservableCollection<MessagesViewModel> SharedItems { get; private set; }

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if (_isInitialized) return;

		SharedItems = new ObservableCollection<MessagesViewModel> ();

		_logger.LogDebug ("Shared Items viewmodel is initialized.");

		_isInitialized = true;
	}

	#endregion

	#region Fields

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly MessageService _messageService;

	#endregion
}