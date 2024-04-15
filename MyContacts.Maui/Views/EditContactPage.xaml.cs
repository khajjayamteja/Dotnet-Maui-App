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
				entryName.Text = contact.Name;
				entryEmail.Text = contact.Email;
				entryAddress.Text = contact.Address;
				entryPhone.Text = contact.Phone;
			}
		}
	
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		if(nameValidator.IsNotValid)
		{
			DisplayAlert("Error", "Name is Required", "OK");
			return;
		}

		if(emailValidator.IsNotValid)
		{
			foreach(var error in  emailValidator.Errors)
			{
				DisplayAlert("Error", error.ToString(), "OK");
			}
			return;
		}
		contact.Name= entryName.Text;
		contact.Email= entryEmail.Text;
		contact.Address= entryAddress.Text;
		contact.Phone= entryPhone.Text;
		
		ContactRepository.UpdateContact(contact.ContactId,contact);
		Shell.Current.GoToAsync("..");
    }
}