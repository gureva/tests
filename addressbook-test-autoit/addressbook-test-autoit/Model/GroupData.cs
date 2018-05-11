﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return this.Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name;
        }
    }
}
