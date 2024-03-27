using SQliteMAUI.Pages;
using SQliteMAUI.Services;

namespace SQliteMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new ContactsTabbedPage();
	}
}

