using SQliteMAUI.Models;
using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;
/// <summary>
/// Ejemplos de consultas
/// SELECT * FROM Contact
/// SELECT FirstName, Email FROM Contact
/// SELECT FirstName, Email FROM Contact WHERE Id = 1
/// </summary>
public partial class SQLQueryPage : ContentPage
{
	public SQLQueryPage()
	{
		InitializeComponent();

    }

    async void OnExecuted(System.Object sender, System.EventArgs e)
    {
        try
        {
            //ejecutamos la instruccion sql
            var query = entry.Text;

            //le pasamos el tipo de dato especifico pero podemos
            //crear nuestro propio mapping
            var contacts = MyDatabase.Instance.Database.Query<MyContact>(query);

            var rows = contacts.Count;
            //obtenemos los resultados
            result.Text = $"Total de registros {rows}";
            //mostramos la informacion en el collection view
            collectionView.ItemsSource = contacts;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
