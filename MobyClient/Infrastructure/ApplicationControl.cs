#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	ApplicationControl.cs
//
// Modification History:
//	Date:			March 2, 2022
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

/// <summary>
///		A class that performs application-level tasks.
/// </summary>
public static class ApplicationControl {

	/// <summary>
	///		Gets or sets the global logger.
	/// </summary>
	public static IMobyLogger Logger { get; set; }

	/// <summary>
	///		Gets or sets the global Maui Application.
	/// </summary>
	public static MauiApp MauiApp { get; set; }

	/// <summary>
	///		Logs the application closing event.
	/// </summary>
	public static void LogAppClose (string service) {

		Guard.IsNotNullOrEmpty (service);

		try {
			Logger.LogInformation ("-----------------------------------------");
			Logger.LogInformation ($"Moby {service} shutting down...");
			Logger.LogInformation ($"-----------------------------------------{Environment.NewLine}");
		} catch (Exception ex) {
			//Logger.LogError (string.Format (ExceptionResources.ExceptionMessageFormat, ex));
		}
	}

	/// <summary>
	///		Logs the startup properties of the application.
	/// </summary>
	public static void LogAppStart (string service) {

		Guard.IsNotNullOrEmpty (service);

		try {
			var commandline = Environment.CommandLine;
			var commandlineFormatted = commandline.ToLower ();
			var commandLineParts = commandline.Split (new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList ();
			var commandlineFormattedParts = commandlineFormatted.Split (new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList ();

			if (commandlineFormattedParts.Count == 5 && (commandlineFormattedParts.Contains ("-p") || commandlineFormattedParts.Contains ("--password"))) {
				var passwordFlagIndex = commandlineFormattedParts.IndexOf ("-p");

				if (passwordFlagIndex == -1) {
					passwordFlagIndex = commandlineFormattedParts.IndexOf ("--password");
				}

				if (passwordFlagIndex != -1) {
					var password = commandlineFormattedParts[passwordFlagIndex + 1];

					if (!string.IsNullOrEmpty (password)) {
						// This could be a misplaced flag...  Filter it out, if so...
						if (!password.StartsWith ("-")) {
							commandLineParts[passwordFlagIndex + 1] = "[***********]";
						}
					}
				}
			}

			var fileInfo = new FileInfo (commandLineParts[0]);

			commandLineParts[0] = fileInfo.Name;

			commandline = string.Join (" ", commandLineParts);

			Logger.LogInformation ("-----------------------------------------");
			Logger.LogInformation ($"Moby {service} starting...");
			Logger.LogInformation ($"-----------------------------------------{Environment.NewLine}{Environment.NewLine}Startup Environment:{Environment.NewLine}");

			Logger.LogInformation ($"    Command Line:                     {commandline}");
			Logger.LogInformation ($"    Current Directory:                {Environment.CurrentDirectory}");
			Logger.LogInformation ($"    Is64BitOperatingSystem:           {Environment.Is64BitOperatingSystem}");
			Logger.LogInformation ($"    Is64BitProcess:                   {Environment.Is64BitProcess}");
			Logger.LogInformation ($"    Node Name:                        {Environment.MachineName}");
			Logger.LogInformation ($"    OS Version:                       {Environment.OSVersion}");
			Logger.LogInformation ($"    Processor Count:                  {Environment.ProcessorCount}");
			Logger.LogInformation ($"    System Directory:                 {Environment.SystemDirectory}");
			Logger.LogInformation ($"    User Domain Name:                 {Environment.UserDomainName}");
			Logger.LogInformation ($"    User Name:                        {Environment.UserName}");
			Logger.LogInformation ($"    .NET Version:                     {Environment.Version}{Environment.NewLine}");
		} catch (Exception ex) {
			//Logger.LogError (string.Format (ExceptionResources.ExceptionMessageFormat, ex));
		}
	}
}