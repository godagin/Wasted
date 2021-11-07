using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//added "add" methods that take food objects as parameters
//renamed userName->Name to make the project code more consistent

namespace WebWasted
{
	public class User
	{
		[Key]
		public int ID { get; set; }
		public String UserName { get; set; }
		public String Name { get; set; }
		public String Surname { get; set; }
		public String ContactEmail { get; set; }
		public String Password { get; set; }
		
		
		//it is bad to save password directly in the database, this is only temporary solution 
		public User(String username, String name, String surname, String email, String password)
		{
			this.UserName = username;
			this.Name = name;
			this.Surname = surname;
			this.ContactEmail = email;
			this.Password = password;
		}

		protected User()
        {

        }

	}
}