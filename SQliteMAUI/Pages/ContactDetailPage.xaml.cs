using SQliteMAUI.Models;
using SQliteMAUI.Services;

namespace SQliteMAUI.Pages;

public partial class ContactDetailPage : ContentPage
{
    private MyContact? _contact;
    private bool _isNew = true;

    public ContactDetailPage()
	{
		InitializeComponent();
	}

    public void SetContact(MyContact? contact)
    {
        if (contact == null)
        {
            return;
        }

        _isNew = false;
        _contact = contact;
        //pasamos la informacion del modelo a
        //a la vista (XML)
        FirstName.Text = _contact.FirstName;
        LastName.Text = _contact.LastName;
        Email.Text = _contact.Email;
        Phone.Text = _contact.PhoneNumber;
    }

    async void OnSavedContact(System.Object sender, System.EventArgs e)
    {
        try
        {
            //verificamos si es nuevo
            //o hay que actualizar
            if (_isNew)
            {
                //creamos el modelo usando
                //los datos de la vista (XAML)
                _contact = new MyContact
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Email = Email.Text,
                    PhoneNumber = Phone.Text
                };

                //agregamos la informacion usando nuestro
                //servicio singleton
                MyDatabase.Instance.Database.Insert(_contact);
            }
            else
            {
                //actualizamos los datos del contacto
                _contact.FirstName = FirstName.Text;
                _contact.LastName = LastName.Text;
                _contact.Email = Email.Text;
                _contact.PhoneNumber = Phone.Text;
                //Actualizamos la informacion usando nuestro
                //servicio singleton
                MyDatabase.Instance.Database.Update(_contact);
            }

            await Navigation.PopAsync();
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }
}
