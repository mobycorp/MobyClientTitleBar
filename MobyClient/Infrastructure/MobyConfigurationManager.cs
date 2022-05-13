#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	var.cs
//
// Modification History:
//	Date:			var
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

namespace MobyClient.Infrastructure;

public class MobyConfigurationManager : IMobyConfigurationManager {

	#region Constructors

	/// <summary>
	///		The main constructor.
	/// </summary>
	/// <param name="logger">Defines the Moby Logger interface.</param>
	public MobyConfigurationManager (
		IMobyLogger logger) {

		// This object is defined as a singleton and should only be executed once.
		// This test simply guarantees it will only be executed once.
		if (_isInitialized) return;

		Guard.IsNotNull (logger);

		_logger = logger;

		InitializeClient ();

		_isInitialized = true;
	}

	#endregion

	#region Properties

	/// <summary>
	///		Gets the current client configuration version from appsettings.json.
	/// </summary>
	/// <returns>A current client configuration version.</returns>
	public string ClientConfigurationVersion => _configuration["AppSettings:ClientConfigurationVersion"];

	/// <summary>
	///		Gets the current transport subsystem configuration version from appsettings.json.
	/// </summary>
	/// <returns>A current transport subsystem configuration version.</returns>
	public string LogisticsConfigurationVersion => _configuration["AppSettings:LogisticsConfigurationVersion"];

	/// <summary>
	///		Gets the Moby Logistics Service port from appsettings.json.
	/// </summary>
	/// <returns>The Moby Operations Service port.</returns>
	public string MobyLogisticsServicePort => _configuration["AppSettings:MobyLogisticsServicePort"];

	#endregion

	#region Methods

	/// <summary>
	///		Perform all of the necessary configuration for the Moby Logistics Service.
	/// </summary>
	internal void InitializeClient () {

		try {
			_configuration = new ConfigurationBuilder ()
				.SetBasePath (AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile ("appsettings.json").Build ();

			// Set the global logger for static classes.
			ApplicationControl.Logger = _logger;

			// Log the App Start preamble in the log file.
			ApplicationControl.LogAppStart ("Client");

			_logger.LogDebug ("Configuring Logistics Services...");

			_logger.LogInformation ($"Client configuration version: {ClientConfigurationVersion}");
			_logger.LogInformation ($"Logistics Service configuration version: {LogisticsConfigurationVersion}");
			_logger.LogInformation ($"Logistics Service port: {MobyLogisticsServicePort}");

			// Make sure access to the Logistics Database is avaliable.
			_logger.LogDebug ("Configuring access to the database...");

			//MobyDatabaseService.CreateDatabase (
			//	LogisticsDatabaseConstants.DatabaseName,
			//	LogisticsConfigurationVersion,
			//	LogisticsDatabaseConstants.LogisticsDataTables);
		} catch (Exception ex) {
			//_logger?.LogError (string.Format (ExceptionResources.ExceptionMessageFormat, ex));
		}
	}

	#endregion

	#region Fields

	private readonly bool _isInitialized;

	private IConfiguration _configuration;

	private readonly IMobyLogger _logger;

	#endregion
}