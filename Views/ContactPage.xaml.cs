using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
		
		List<Contact> contacts = ContactRepository.GetContacts();

		listContacts.ItemsSource = contacts;
	}



	private async void listContacts_ItemSelected(object sender, SelectionChangedEventArgs e)
	{
		if(listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"nameof(EditPage)?id={((Contact)listContacts.SelectedItem).ContactId}");
		}
		
	}

	private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		listContacts.SelectedItem = null;
	}

}