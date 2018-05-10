using LinqToDB.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        private string allEmails;

        private string infoFormString;

        public ContactData() { }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            { return false; }
            if (object.ReferenceEquals(this, other))
            { return true; }
            if (LastName == other.LastName && FirstName == other.FirstName)
            {
                return true;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return LastName.CompareTo(other.LastName) + FirstName.CompareTo(other.FirstName);
        }

        public override string ToString()
        {
            return "Name: " + LastName + " " + FirstName;
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return null;
            }
            else
                return Regex.Replace(phone, "[-() ]", "") + "\r\n";
        }

        private string CleanUpE(string em)
        {
            if (em == null || em == "")
            {
                return null;
            }
            else
                return em + "\r\n";
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }

                else return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Fax)).Trim();
            }
            set
            {
                allPhones = value;
            }
        }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }

                else
                    return (CleanUpE(Email) + CleanUpE(Email2) + CleanUpE(Email3)).Trim();
            }
            set
            {
                allEmails = value;
            }
        }

        [Column(Name = "homepage")]
        public string HomePage { get; set; }

        [Column(Name = "address2")]
        public string AddressSec { get; set; }

        [Column(Name = "phone2")]
        public string HomeSec { get; set; }

        [Column(Name = "notes")]
        public string NoteSec { get; set; }

        private string iS(string st)
        {
            if (string.IsNullOrEmpty(st))
            {
                return null;
            }
             else return st;                                   
        }

        [XmlIgnore] [JsonIgnore]
        public string InfoFormString
        {
            get
            {
				if (infoFormString != null)
                {
                    return infoFormString;
                }
				
			    else
				{
                    infoFormString = FirstName + " ";
                    if (!string.IsNullOrEmpty(MiddleName))
                    {
                        infoFormString = infoFormString +  MiddleName + " ";
                    }

                    infoFormString = infoFormString + LastName
                     + iS(NickName)
                     + iS(Title)
                     + iS(Company)
                     + iS(Address);					 
					 
                    if (!string.IsNullOrEmpty(HomePhone)) 
					{
                        infoFormString = infoFormString + "H: " + HomePhone.Trim();
					}
                    if (!string.IsNullOrEmpty(MobilePhone)) 
					{
                        infoFormString = infoFormString + "M: " + MobilePhone.Trim();
					}
                    if (!string.IsNullOrEmpty(WorkPhone) ) 
					{
                        infoFormString = infoFormString + "W: " + WorkPhone.Trim();
					}
                    if (!string.IsNullOrEmpty(Fax)) 
					{
                        infoFormString = infoFormString + "F: " + Fax.Trim();
					}

                    infoFormString = infoFormString + iS(Email) + iS(Email2) + iS(Email3) + iS(AddressSec);

                    if (!string.IsNullOrEmpty(HomeSec)) 
					{
                        infoFormString = infoFormString + "P: " + HomeSec.Trim();
					}

                    infoFormString = infoFormString + iS(NoteSec);					 
				
                    return infoFormString;
				} 
			}	
			set		
			{
                infoFormString = value;
			}			
        }

        [Column (Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            //соединение и закрытие подключения автоматически  
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where (x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
