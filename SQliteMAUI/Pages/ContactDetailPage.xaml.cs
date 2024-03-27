using SQliteMAUI.Models;
using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;

public partial class ContactDetailPage : ContentPage
{
	public ContactDetailPage()
	{
		InitializeComponent();
	}

    async void OnSavedContact(System.Object sender, System.EventArgs e)
    {
        try
        {
            //creamos el modelo usando
            //los datos de la vista (XAML)
            var myContact = new MyContact
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                PhoneNumber = Phone.Text
            };

            //agregamos la informacion usando nuestro
            //servicio singleton
            MyDatabase.Instance.Database.Insert(myContact);


            await Navigation.PopAsync();
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }
}
