using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class ProjectTests : AuthTestBase
    {
        [Test]
        public void AddProject()
        {
            ProjectData project = new ProjectData() { Name = "new1111" };
			
			List<ProjectData> oldProjects = app.Project.GetProjectList();

            foreach(ProjectData old in oldProjects)
            {
                if (old.Name == project.Name)
                {
                    project.Name = project.Name + "changed";
                    return;
                }
            }

            app.Project.CreateProject(project);
			
			List<ProjectData> newProjects = app.Project.GetProjectList();
			oldProjects.Add(project);
			oldProjects.Sort();
			newProjects.Sort();
			
			Assert.AreEqual(newProjects, oldProjects);
        }   

		[Test]
        public void DeleteProject()
        {
            // Номер проекта для удаления
            int index = 2;

            if (app.Project.IsProjectListEmpty() || app.Project.IsIndex(index))
            {
                ProjectData project = new ProjectData() { Name = "123" };
                 app.Project.CreateProject(project);
                index = 1;
            }
            List<ProjectData> oldProjects = app.Project.GetProjectList();

            
            app.Project.DeleteProject(index);
			
			List<ProjectData> newProjects = app.Project.GetProjectList();
			oldProjects.RemoveAt(0);
			oldProjects.Sort();
			newProjects.Sort();
			
			Assert.AreEqual(newProjects, oldProjects);
        }   
    }
}
