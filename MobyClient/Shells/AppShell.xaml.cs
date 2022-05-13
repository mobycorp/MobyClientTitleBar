namespace MobyClient.Shells;

public partial class AppShell : Shell {

	public AppShell () {

		InitializeComponent ();

		BindingContext = new ShellViewModel ();
	}
}