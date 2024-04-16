using MyContacts.Maui.Models;
using Contact = MyContacts.Maui.Models.Contact;

namespace MyContacts.Maui.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

	public String ContactId 
	{
		set
		{
			contact=ContactRepository.GetContactById(int.Parse(value));
		    if(contact != null )
			{
				contactCtrl.Name = contact.Name;
				contactCtrl.Email = contact.Email;
				contactCtrl.Address = contact.Address;
				contactCtrl.Phone = contact.Phone;
			}
		}
	
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

		contact.Name = contactCtrl.Name;
		contact.Email= contactCtrl.Email;
		contact.Address= contactCtrl.Address;
		contact.Phone= contactCtrl.Phone;
		
		ContactRepository.UpdateContact(contact.ContactId,contact);
		Shell.Current.GoToAsync("..");
    }

   

    private void contactCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "OK");
    }
}