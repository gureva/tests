using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
            return "Name: "  + LastName + " " + FirstName;
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Id { get; set; }
    }
}
