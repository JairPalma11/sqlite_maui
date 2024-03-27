using Microsoft.Maui.Controls;
using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;

/// <summary>
/// Algunos ejemplos de SQL
/// INSERT INTO Contact values (0, 'Jair', 'Palma', '2222222222', 'jair@domain.com')
/// UPDATE Contact SET FirstName = 'Jose' WHERE Id = 0
/// DELETE FROM Contact WHERE Id = 0
/// </summary>
public partial class SQLOperationPage : ContentPage
{
	public SQLOperationPage()
	{
		InitializeComponent();
	}

    async void OnExecuted(System.Object sender, System.EventArgs e)
    {
        try
        {
            //ejecutamos la instruccion sql
            var query = entry.Text;

            //ExecuteScalar = para un solo resultado, por ejemplo SELECT * Contact WHERE Id = 1;
            //Execute es para cuando la instruccion SQL no regresa resultados, INSERT, UPDATE, DELETE
            //ejecutamos la instruccion y nos indica si hubo
            //registros afectados
            var rowsAffected = MyDatabase.Instance.Database.Execute(query);
            //obtenemos los resultados
            result.Text = $"Total de registros afectados: {rowsAffected}";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

}
