﻿using SQliteMAUI.Models;
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

    async void OnAddContact(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ContactDetailPage());
    }

    async void OnContactSelected(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var contact = e.CurrentSelection.FirstOrDefault() as MyContact;
        var contactDetailPage = new ContactDetailPage();
        contactDetailPage.SetContact(contact);
        await Navigation.PushAsync(contactDetailPage);
    }
}
