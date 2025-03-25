using Contacts.App.Models;

namespace Contacts.App.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void OnCancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactControl.Name,
            Email = contactControl.Email,
            Phone = contactControl.Phone,
            Address = contactControl.Address
        });

        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}