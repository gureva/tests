using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MantisTests.Mantis;

namespace MantisTests
{
    public class MantisProjectData : IComparer<Mantis.ProjectData>
    {
        public int Compare(Mantis.ProjectData x, Mantis.ProjectData y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return 1;
            }
            return x.name.CompareTo(y.name);
        }
    }
}
