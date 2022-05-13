namespace MobyClient.Interfaces;

public interface IMobyLogger {

	void Log (string message, LogLevel logLevel);

	void LogTrace (string message);

	void LogDebug (string message);

	void LogInformation (string message);

	void LogWarn (string message);

	void LogError (string message);

	void LogFatal (string message);

	string ToString ();
}