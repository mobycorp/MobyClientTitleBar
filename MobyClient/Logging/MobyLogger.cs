#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	MobyLogger.cs
//
// Modification History:
//	Date:			March 18, 2022
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

namespace MobyClient.Logging;

public class MobyLogger : IMobyLogger {

	#region Constructors

	public MobyLogger () {

		ConfigureLogger ();
	}

	#endregion

	#region Properties

	#endregion

	#region Methods

	public void ConfigureLogger () {

		var archiveFileName = string.Empty;
		var fileName = string.Empty;

		// We need to programmatically set the log file folder location
		// based on the operating system.
		if (RuntimeInformation.IsOSPlatform (OSPlatform.Windows)) {
			archiveFileName = @"C:\Users\Public\Documents\Moby\Logs\MobyClient.{#}.log";
			fileName = @"C:\Users\Public\Documents\Moby\Logs\MobyClient.log";
		} else if (RuntimeInformation.IsOSPlatform (OSPlatform.OSX) || RuntimeInformation.IsOSPlatform (OSPlatform.Linux)) {
			archiveFileName = "/opt/moby/logs/MobyClient.{#}.log";
			fileName = "/opt/moby/logs/MobyClient.log";
		}

		var config = new NLog.Config.LoggingConfiguration ();
		var fileTarget = new NLog.Targets.FileTarget {
			ArchiveDateFormat = "yyyyMMdd",
			ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
			ArchiveFileName = archiveFileName,
			ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date,
			FileName = fileName,
			Layout = "${longdate} ${level:uppercase=true:padding=-8} ${message}",
			Name = "file"
		};

		config.AddRule (LogLevel.Debug, LogLevel.Fatal, fileTarget, "*");

		// Get the logger.
		LogManager.Configuration = config;

		_logger = LogManager.GetCurrentClassLogger ();
	}

	public void LogTrace (string message) { Log (message, LogLevel.Trace); }

	public void LogDebug (string message) { Log (message, LogLevel.Debug); }

	public void LogInformation (string message) { Log (message, LogLevel.Info); }

	public void LogWarn (string message) { Log (message, LogLevel.Warn); }

	public void LogError (string message) { Log (message, LogLevel.Error); }

	public void LogFatal (string message) { Log (message, LogLevel.Fatal); }

	/// <summary>
	/// Log a message to the Sk Reports Portal log file.
	/// </summary>
	/// <param name="message">The message to log.</param>
	/// <param name="logLevel">The log entry category.</param>
	public void Log (string message, LogLevel logLevel) {

		Guard.IsNotNullOrEmpty (message);
		Guard.IsNotNull (logLevel);

		var stackTrace = new StackTrace ();
		var stackFrame = stackTrace.GetFrame (1);

		Guard.IsNotNull (stackFrame);

		var methodBase = stackFrame.GetMethod ();

		Guard.IsNotNull (methodBase);
		Guard.IsNotNull (methodBase.ReflectedType);

		var typeNameParts = methodBase.ReflectedType
			.ToString ()
			.Split (new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

		var formattedMessage = $@"	Category: {logLevel}	Class: {typeNameParts.Last ()}	Method: {methodBase.Name} - {message}";

		var counter = 0;

		// Sometimes, the system is attempting to write to the log at the
		// precise time it is doing a log rollover.  If the message can't
		// be written, wait 2 seconds and try again.
		while (true) {
			try {
				if (logLevel == LogLevel.Debug) {
					_logger.Debug (formattedMessage);
				} else if (logLevel == LogLevel.Error) {
					_logger.Error (formattedMessage);
				} else if (logLevel == LogLevel.Fatal) {
					_logger.Fatal (formattedMessage);
				} else if (logLevel == LogLevel.Info) {
					_logger.Info (formattedMessage);
				} else if (logLevel == LogLevel.Trace) {
					_logger.Trace (formattedMessage);
				} else if (logLevel == LogLevel.Warn) {
					_logger.Warn (formattedMessage);
				}

				break;
			} catch (ObjectDisposedException) {
				Thread.Sleep (2000);

				counter++;

				if (counter > 10) {
					throw;
				}
			}
		}
	}

	/// <summary>
	///     Returns the name of the class as a default string.
	/// </summary>
	/// <returns>System.String</returns>
	public override string ToString () { return "MobyLogger"; }

	#endregion

	#region Fields

	protected Logger _logger;

	#endregion
}