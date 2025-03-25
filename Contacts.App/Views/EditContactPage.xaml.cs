using Contacts.App.Models;

namespace Contacts.App.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public int ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(value);
            if (contact != null)
            {
                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.Phone = contact.Phone;
                contactControl.Address = contact.Address;
            }
        }
    }

    private void OnUpdateClicked(object sender, EventArgs e)
    {
        ContactRepository.UpdateContact(contact.ContactId, new Models.Contact
        {
            ContactId = contact.ContactId,
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