﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
   public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }
        public string Description { get; set; }
		
		public int CompareTo(ProjectData other) 
		{
			if (Object.ReferenceEquals(other, null))
			{
				return 1;
			}
			return Name.CompareTo(other.Name);
		}
		
		 public override string ToString()
        {
            return "Project name= " + Name;
        }
		
		public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false;}
            if (Object.ReferenceEquals(this, other))
            { return true; }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}