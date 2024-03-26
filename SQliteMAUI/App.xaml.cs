using SQliteMAUI.Pages;
using SQliteMAUI.Services;

namespace SQliteMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ContactsPage());
	}


    protected async override void OnStart()
    {
        base.OnStart();
        //inicializamos nuestra base de datos
        //una sola vez para poder utilizarla
        await MyDatabase.GetInstance().Initialize();
    }
}

