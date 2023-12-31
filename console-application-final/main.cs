using System;
using System.Linq;
using System.Collections.Generic;

class Contact
{
  public string FullName {get; set;}
  public string Nickname {get; set;}
  public string PhoneNumber {get; set;}
  public string Email {get; set;}
  public string Bdate {get; set;}
  public string Address { get; set; }
}
class Program
{
  static Dictionary <string, Contact>contacts = new Dictionary <string, Contact>();
  static int contactCounter = 0;
  
  static void Main()
  {
    Console.WriteLine("------------------------------Contact Book-------------------------------");
    Console.WriteLine("-------------------------------------------------------------------------");
    while (true)
      {
    
	Console.WriteLine("1. Add Contact");
	Console.WriteLine("2. View list of contacts");
	Console.WriteLine("3. Search Contact");
	Console.WriteLine("4. Delete Contact");
	Console.WriteLine("5. Exit");

	Console.Write("\nEnter your choice: ");
	string choice = Console.ReadLine();

	switch (choice)
	  {
       case "1":
	    AddContact();
	    break;
       case "2":
	    ListOfContact();
	    break;
	   case "3":
	    SearchContact();
	    break;
	   case "4":
	    DeleteContact();
	    break;
       case "5":
	    Console.WriteLine("\nEXITING THE CONTACT BOOK APP.");
	    Environment.Exit(0);
	    break;
       default:
	    Console.WriteLine("\nINVALID CHOICE. PLEASE TRY AGAIN.");
	    break;
	  }
	Console.WriteLine("\n-------------------------------------------------------------------------\n");
      }
  }

  static void AddContact()
  {
    Console.WriteLine ("\nContact Details.");

    Console.Write("Enter Full Name: ");
    string fname = Console.ReadLine();
    Console.Write("Enter Nickname: ");
    string nickName = Console.ReadLine();
    Console.Write("Enter Phone Number: ");
    string number = Console.ReadLine();
    Console.Write("Enter Email Address: ");
    string email = Console.ReadLine();
    Console.Write("Enter Birth Date: ");
    string bdate = Console.ReadLine();
    Console.Write("Enter Home Address: ");
    string homeAdd = Console.ReadLine();

    Contact newContact = new Contact { FullName = fname, Nickname = nickName, PhoneNumber = number, Email = email, Bdate = bdate, Address = homeAdd };
    contacts[fname] = newContact;
    contactCounter++;
    
    Console.WriteLine($"\n{fname} is successfully added to your contacts! Total Contact: {contactCounter}");
  }
  static void ListOfContact()
  {
    if (contacts.Count == 0) {
	Console.WriteLine ("\nNo contacts available.");
      }
    else
    {
	  Console.WriteLine("\nList of contacts: ");
	  int NumberOfContacts = 1;
	  foreach (var contact in contacts)
	    {
	      Console.WriteLine ($"{NumberOfContacts}. Full Name: {contact.Value.FullName}\n   Phone Number: {contact.Value.PhoneNumber}\n");
	      NumberOfContacts++;
	    }
	    	        Console.Write("Enter the number of the contact to View details: ");
	  if (int.TryParse(Console.ReadLine(), out int selectedContactNumber)
	      && selectedContactNumber >= 1 
	      && selectedContactNumber <= contacts.Count)
	  {
	  var selectedContact = contacts.ElementAt(selectedContactNumber - 1);
	      DisplayContactDetails(selectedContact.Value);
	    
	        Console.Write("Do you want to edit this contact? (Yes/No): ");
	        string editChoice = Console.ReadLine();
	   
	  if (editChoice.Equals("Yes", StringComparison.OrdinalIgnoreCase)) 
	  {
	      EditContact(selectedContact.Value.FullName); 
	  }
	  }
	  else {
	      Console.WriteLine("\nInvalid Contact number. Operation canceled.");
	  }
    }
  }
  static void SearchContact()
  {
    if (contacts.Count == 0) {
	Console.WriteLine("\nNo contacts available.");
      }
    else 
    {
      Console.Write("\nEnter Name, Nickname or Number to Search: ");
      string searchInput = Console.ReadLine();
                
    var foundContact = contacts.Where(kv => kv.Value.FullName.Contains(searchInput, StringComparison.OrdinalIgnoreCase)
        || kv.Value.Nickname.Contains(searchInput, StringComparison.OrdinalIgnoreCase)
        || kv.Value.PhoneNumber.Contains(searchInput, StringComparison.OrdinalIgnoreCase));
                
    if (foundContact.Any()) {
        Console.WriteLine("\nContact found: ");
            
        int contactNumber = 1;
        foreach(var contact in foundContact) {
        Console.Write($"\n{contactNumber}. Full Name: {contact.Value.FullName}
   Nickname: {contact.Value.Nickname}
   Phone Number: {contact.Value.PhoneNumber}
   Email: {contact.Value.Email}
   Birth Date: {contact.Value.Bdate}
   Home Address: {contact.Value.Address}\n");
        contactNumber++;
        }
        Console.Write("\nDo you want to edit any of this contact? (Yes/No): ");
        string editChoice = Console.ReadLine();
        
    if (editChoice.Equals("Yes", StringComparison.OrdinalIgnoreCase)) {
        Console.Write("\nEnter the number of the contact you want to edit: ");
    if (int.TryParse(Console.ReadLine(),out int selectedContactNumber) 
        && selectedContactNumber >= 1 
        && selectedContactNumber <= foundContact.Count())
     {
        var selectedContact = foundContact.ElementAt(selectedContactNumber - 1);
        EditContact(selectedContact.Value.FullName);
    }
    else
    {
        Console.WriteLine("Invalid contact number. Editing canceled.");
        }
      }
    }
    else {
        Console.WriteLine($"No Contacts found with '{searchInput}'");
         }
      }
  }
  static void EditContact(string fullName)
  {
    if (contacts.ContainsKey(fullName))
      {
	  Console.Write("\nEnter new Full Name (leave blank to keep current): ");
	  string newFullName = Console.ReadLine ();
	  Console.Write("Enter new Nickname (leave blank to keep current): ");
	  string newNickname = Console.ReadLine();
	  Console.Write("Enter new Phone Number (leave blank to keep current): ");
	  string newPhoneNumber = Console.ReadLine ();
	  Console.Write("Enter new Email Address (leave blank to keep current): ");
	  string newEmailAdd = Console.ReadLine ();
	  Console.Write("Enter new Birth Date (leave blank to keep current): ");
  	  string newBdate = Console.ReadLine ();
	  Console.Write("Enter new Home Address (leave blank to keep current): ");
	  string newHomeAdd = Console.ReadLine ();

	Contact existingContact = contacts[fullName];

	if (!string.IsNullOrEmpty(newFullName)) {
	    contacts.Remove(fullName);
	    existingContact.FullName = newFullName;
	    contacts[newFullName] = existingContact;
	  }
	if (!string.IsNullOrEmpty(newNickname)) {
	    existingContact.Nickname = newNickname;
	  }
	if (!string.IsNullOrEmpty(newPhoneNumber)) {
	    existingContact.PhoneNumber = newPhoneNumber;
	  }
	if (!string.IsNullOrEmpty(newEmailAdd)) {
	    existingContact.Email = newEmailAdd;
	  }
	if (!string.IsNullOrEmpty(newBdate)) {
	    existingContact.Bdate = newBdate;
	  }
	if (!string.IsNullOrEmpty(newHomeAdd)) {
	    existingContact.Address = newHomeAdd;
	  }
	Console.WriteLine ($"\nContact '{fullName}' updated successfully!\n");
	DisplayUpdatedContactDetails(existingContact);
      }
    else {
	Console.WriteLine ($"Contact with '{fullName}' not found\n");
      }
  }
  static void DeleteContact()
  {
    if (contacts.Count == 0) {
        Console.WriteLine("\nNo contacts available to delete.");
    }
    else {
        Console.Write("\nEnter Nickname or Full Name to delete: ");
        string deleteInput = Console.ReadLine();
    
    var foundContact = contacts.FirstOrDefault(kv => kv.Value.FullName.Contains(deleteInput, StringComparison.OrdinalIgnoreCase)
    || kv.Value.Nickname.Contains(deleteInput, StringComparison.OrdinalIgnoreCase));
    
    if (foundContact.Key != null) {
        Console.WriteLine($"\nContact found.\n\nFull Details: 
    Full Name: {foundContact.Value.FullName}
    Nickname: {foundContact.Value.Nickname}
    Phone Number: {foundContact.Value.PhoneNumber}
    Email Address: {foundContact.Value.Email}
    Birth Date: {foundContact.Value.Bdate}
    Home Address: {foundContact.Value.Address}\n");
        
        Console.Write("Are you sure you want to delete this contact? (Yes/No): ");
        string deleteChoice = Console.ReadLine();
        
    if (deleteChoice.Equals("Yes", StringComparison.OrdinalIgnoreCase)) {
        contacts.Remove(foundContact.Key);
        Console.WriteLine($"\nContact '{foundContact.Key}' deleted successfully!");
    }
    else {
        Console.WriteLine($"\nContact deletion canceled.");
    }
    }
    else {
        Console.WriteLine($"\nContact with name '{deleteInput}' not found.");
    }
    }
    }
  static void DisplayContactDetails(Contact contact)
  {
    Console.WriteLine($"\nContact Details: 
   Full Name: {contact.FullName}
   Nickname: {contact.Nickname}
   Phone Number: {contact.PhoneNumber}
   Email Address: {contact.Email}
   Birth Date: {contact.Bdate}
   Home Address: {contact.Address}\n");
  }
  static void DisplayUpdatedContactDetails(Contact updatedContact)
  {
    Console.WriteLine($"Updated Contact Details:
   Full Name: {updatedContact.FullName}
   Nickname: {updatedContact.Nickname}
   Phone Number: {updatedContact.PhoneNumber}
   Email Address: {updatedContact.Bdate}
   Home Address: {updatedContact.Address}");      
  }
  }



