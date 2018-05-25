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
        public void AddProjectWithMantis()
        {
            Mantis.ProjectData project = new Mantis.ProjectData() { name = "new1111" };

            AccountData account = new AccountData()
            { Name = "administrator", Password = "root" };

            List<Mantis.ProjectData> oldProjects = app.API.GellAllProjects(account);

            foreach (Mantis.ProjectData old in oldProjects)
            {
                if (old.name == project.name)
                {
                    project.name = project.name + "changed";
                    return;
                }
            }

            app.API.CreateProject(account, project);

            List<Mantis.ProjectData> newProjects = app.API.GellAllProjects(account);
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
            AccountData account = new AccountData()
            { Name = "administrator", Password = "root" };

            if (app.Project.IsProjectListEmpty() || app.Project.IsIndex(index))
            {
                Mantis.ProjectData project = new Mantis.ProjectData() { name = "123" };
                app.API.CreateProject(account, project); index = 1;
            }
            List<Mantis.ProjectData> oldProjects = app.API.GellAllProjects(account);


            app.Project.DeleteProject(index);
			
			List<Mantis.ProjectData> newProjects = app.API.GellAllProjects(account);
            oldProjects.RemoveAt(0);
			oldProjects.Sort();
			newProjects.Sort();
			
			Assert.AreEqual(newProjects, oldProjects);
        }   
    }
}
