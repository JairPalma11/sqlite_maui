using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
        collectionView.ItemsSource = ContactService.GetContacts(10);
    }

    async void OnAddContact(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ContactDetailPage());
    }
}
