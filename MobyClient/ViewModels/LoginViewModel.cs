#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	LoginViewModel.cs
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

using Google.Protobuf.WellKnownTypes;

namespace MobyClient.ViewModels;

public partial class LoginViewModel : ObservableObject {

	#region Constructors

	public LoginViewModel (
		IMobyLogger logger,
		LoginService loginService) {

		Guard.IsNotNull (logger);
		Guard.IsNotNull (loginService);

		_logger = logger;
		_loginService = loginService;

		InitializeViewModel ();
	}

	~LoginViewModel () {

		_logger.LogDebug ("Login viewmodel has been destroyed.");
	}

	#endregion

	#region Properties

	[ObservableProperty]
	private string _password;

	[ObservableProperty]
	private string _username;

	#endregion

	#region Methods

	private void InitializeViewModel () {

		if (_isInitialized) return;

		_logger.LogDebug ("Login viewmodel is initialized.");

		_isInitialized = true;
	}

	[ICommand]
	private async Task Login () {

		// Verify non-empty username.
		//if (string.IsNullOrEmpty (Username)) {
		//	await Application.Current.MainPage.DisplayAlert (AppResources.ErrorLoginInvalidUsernameTitle, AppResources.ErrorLogInMissingUsernameMsg, AppResources.LoginOK);

		//	return;
		//}

		// Verify non-empty password.
		//if (string.IsNullOrEmpty (Password)) {
		//	await Application.Current.MainPage.DisplayAlert (AppResources.ErrorLoginInvalidPasswordTitle, AppResources.ErrorLogInMissingPasswordMsg, AppResources.LoginOK);

		//	return;
		//}

		// 1) Check to see if the username/password is in the local database.
		//var userProfile = _loginService.GetUserProfile (GeneralStringFunctions.Munge (Username));

		// 2) If the username/password is not in the local database, have the agent check with the Moby Operations Service.
		//if (userProfile == null) {
		//	// Ensure we are connected to the network...
		//	if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) {
		//		await Application.Current.MainPage.DisplayAlert (AppResources.ErrorConnectivityTitle, AppResources.ErrorConnectivityMsg, AppResources.LoginOK);

		//		return;
		//	}

		//	using var logisticsChannel = GrpcChannel.ForAddress (logisticsAddress);

		//	var logisticsClient = new TransportService.TransportServiceClient (logisticsChannel);

		//	ActionReply getHeartbeatReply = null;

		//	try {
		//		getHeartbeatReply = logisticsClient.GetHeartbeat (new Empty (), _headers, deadline: DateTime.UtcNow.AddSeconds (10));
		//	} catch (RpcException ex) when (ex.StatusCode is StatusCode.Aborted or StatusCode.DeadlineExceeded or StatusCode.Unavailable) {
		//		await Application.Current.MainPage.DisplayAlert (AppResources.ErrorNoLogisticsServiceTitle, AppResources.ErrorNoLogisticsServiceMsg, AppResources.LoginOK);

		//		return;
		//	} catch (Exception ex) {
		//		_logger.LogError (string.Format (ExceptionResources.ExceptionMessageFormat, ex));

		//		throw;
		//	}

		//	if (!getHeartbeatReply.Message.Equals (MessageResources.AllSystemsOperational)) {
		//		await Application.Current.MainPage.DisplayAlert (AppResources.ErrorNoLogisticsServiceTitle, AppResources.ErrorNoLogisticsServiceMsg, AppResources.LoginOK);

		//		return;
		//	}
		//}

		// 3) Ensure the password on file matches the password used.
		//if (!userProfile.Password.Equals (GeneralStringFunctions.Munge (Password))) {
		//	await Application.Current.MainPage.DisplayAlert (AppResources.ErrorLogInUsernamePasswordNotFoundTitle, AppResources.ErrorLogInUsernamePasswordNotFoundMsg, AppResources.LoginOK);

		//	Username = string.Empty;
		//	Password = string.Empty;

		//	return;
		//}

		// 4) If the user is in the Moby Operations Service, but not validated, display alert.
		// 5) If the user is not in the Moby Operations Service, instruct them to go to the Moby Website and register.

		Application.Current.MainPage = new AppShell ();
	}

	#endregion

	#region Fields

	const string logisticsAddress = $"https://localhost:30053";

	private bool _isInitialized;

	private readonly IMobyLogger _logger;

	private readonly LoginService _loginService;

	#endregion
}