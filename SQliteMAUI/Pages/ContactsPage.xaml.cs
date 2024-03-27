using SQliteMAUI.Models;
using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
        //collectionView.ItemsSource = ContactService.GetContacts(10);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //obtenemos todos los contactos de la BD
        var contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
        collectionView.ItemsSource = contacts;
    }
    /// <summary>
    /// este metodo es para llenar
    /// y almacenar multiples contactos
    /// a la vez
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnTest(System.Object sender, System.EventArgs e)
    {
        var contacts = ContactService.GetContacts(10);
        //guardamos todos los contactos
        MyDatabase.Instance.Database.InsertAll(contacts);

        //refrescamos la lista
        //con los nuevos contactos
        contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
        collectionView.ItemsSource = contacts;
    }

    /// <summary>
    /// navega hacia la pagina de nuevo
    /// contacto
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void OnAddContact(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ContactDetailPage());
    }

    /// <summary>
    /// elimina el contacto seleccionado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnDeleted(System.Object sender, System.EventArgs e)
    {
        var swipeView = sender as SwipeItem;
        var contact = swipeView?.CommandParameter as MyContact;
        MyDatabase.Instance.Database.Delete(contact);

        //refrescamos la lista
        var contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
        collectionView.ItemsSource = contacts;
    }

    /// <summary>
    /// nos permite actualizar los datos del contacto
    /// seleccionado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void OnSelectContact(System.Object sender, System.EventArgs e)
    {
        var swipeView = sender as SwipeItem;
        var contact = swipeView?.CommandParameter as MyContact;
        var contactDetailPage = new ContactDetailPage();
        contactDetailPage.SetContact(contact);
        await Navigation.PushAsync(contactDetailPage);
    }
}
