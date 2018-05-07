﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {}

        public GroupData(string name)
        {
           Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            { return false;}
            if (object.ReferenceEquals(this, other))
            { return true; }
            if (Name == other.Name)
            {
                return true;
            }
            else return false;
        }

        public override int GetHashCode()
        {
             return Name.GetHashCode();
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public string Name { get; set; }       

        public string Header { get; set; }
        
        public string Footer { get; set; }

        public string Id { get; set; }

    }

}
