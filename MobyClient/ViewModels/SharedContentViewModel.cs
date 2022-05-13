#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	SharedContentViewModel.cs
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

public class SharedContentViewModel : ObservableObject {

	#region Constructors

	public SharedContentViewModel (IMobyLogger logger, SharedContentService sharedContentService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (sharedContentService);

		_logger = logger;
		_sharedContentService = sharedContentService;

		InitializeViewModel ();
	}

	#endregion

	#region Properties

	public ObservableCollection<SharedContentViewModel> SharedItems { get; private set; }

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if ( _isInitialized ) return;

		SharedItems = new ObservableCollection<SharedContentViewModel> ();

		_logger.LogDebug ("Shared Items viewmodel is initialized.");

		_isInitialized = true;
	}

	#endregion

	#region Fields

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly SharedContentService _sharedContentService;

	#endregion
}