
using Contacts.App.Models;

namespace Contacts.App.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
    }

    override protected void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private void OnAddContactClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Models.Contact)listContacts.SelectedItem).ContactId}");
            return;
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var contact = (Models.Contact)menuItem.CommandParameter;
        ContactRepository.DeleteContact(contact.ContactId);

        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new System.Collections.ObjectModel.ObservableCollection<Models.Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts; 
    }

    private void SearchContact_Changed(object sender, TextChangedEventArgs e)
    {
        var contacts = new System.Collections.ObjectModel.ObservableCollection<Models.Contact>(ContactRepository.SearchContact(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}