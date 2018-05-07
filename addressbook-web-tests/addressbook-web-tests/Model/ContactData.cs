using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        private string allEmails;

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string NickName { get; set; }

        public string Id { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return null;
            }
            else
                return Regex.Replace(phone, "[ -()]", "") + "\r\n";
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

        public string Email { get; set; }

        public string Email2 { get; set; }

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

        public string HomePage { get; set; }

        public string AddressSec { get; set; }

        public string HomeSec { get; set; }

        public string NoteSec { get; set; }

        private string iS(string st)
        {
            if (st == null || st == "")
            {
                return null;
            }
            else
                return st.Trim();
        }        
        
        public string InfoFormString
        {
            get
            {
                return
                    iS(FirstName) + iS(MiddleName) + iS(LastName)
                     + iS(NickName)
                     + iS(Title)
                     + iS(Company)
                     + iS(Address)
                     + iS(HomePhone)
                     + iS(MobilePhone)
                     + iS(WorkPhone)
                     + iS(Fax)
                     + iS(Email) 
                     + iS(AddressSec)
                     + iS(HomeSec)
                     + iS(NoteSec) ;
            }
            set
            {
                InfoFormString = value;
            }
        }
    }
}
