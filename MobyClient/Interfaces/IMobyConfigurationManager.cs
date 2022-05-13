#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Interface:		IMobyConfigurationManager.cs
//
// Modification History:
//	Date:			March 19, 2022
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

namespace MobyClient.Interfaces;

/// <summary>
///		Defines the configuration manager properties available in appsettings.json.
/// </summary>
public interface IMobyConfigurationManager {

	/// <summary>
	///		Gets the current client configuration version from appsettings.json.
	/// </summary>
	/// <returns>A current client configuration version.</returns>
	string ClientConfigurationVersion { get; }

	/// <summary>
	///		Gets the current transport subsystem configuration version from appsettings.json.
	/// </summary>
	/// <returns>A current transport subsystem configuration version.</returns>
	string LogisticsConfigurationVersion { get; }

	/// <summary>
	///		Gets the Moby Logistics Service port from appsettings.json.
	/// </summary>
	/// <returns>The Moby Operations Service port.</returns>
	string MobyLogisticsServicePort { get; }
}