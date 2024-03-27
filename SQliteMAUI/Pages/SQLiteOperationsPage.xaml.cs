namespace SQliteMAUI.Pages;

public partial class SQLiteOperationsPage : ContentPage
{
	public SQLiteOperationsPage()
	{
		InitializeComponent();
	}

    async void OnQuerySelected(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new SQLQueryPage());
    }

    async void OnExecuteSQL(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SQLOperationPage());
    }
}
