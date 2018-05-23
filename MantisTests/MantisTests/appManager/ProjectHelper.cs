using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantisTests
{
   public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            OpenManageProjects();
            CreateNewProject();
            FillProjectForm(project);
            SubmitCreatingProject();
        }

        public void DeleteProject(int index)
        {
           OpenManageProjects();
            SelectProject(index);
            SubmitDeleteProject();
        }
        
        private void CreateNewProject()
        {
           driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            if (project.Description != null)
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        private void SubmitCreatingProject()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
        }

        private void SelectProject(int index)
        {
            driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
				.FindElements(By.TagName("tr"))[index]
				.FindElements(By.TagName("td"))[0]
				.FindElement(By.TagName("a")).Click();
        }

        private void SubmitDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
			  new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => driver.FindElements(By.ClassName("bigger-110")).Count > 0);		
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;

        }
        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                OpenManageProjects();
                projectCache = new List<ProjectData>();

                ICollection<IWebElement> elements = driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover")).FindElements(By.TagName("tr"));

                foreach (IWebElement element in elements.Skip(1))
                {
                    IList<IWebElement> items = element.FindElements(By.CssSelector("td"));

                    projectCache.Add(new ProjectData()
                    {
                        Name = items[0].Text
                    });
                }
            }
            return new List<ProjectData>(projectCache);
        }

        public bool IsProjectListEmpty()
        {            
           OpenManageProjects();
            if (driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
             .FindElements(By.TagName("tr")).Count < 2)
            
                return true;
            
            else return false;
        }

        public bool IsIndex(int index)
        {
            OpenManageProjects();
            if (driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
             .FindElements(By.TagName("tr")).Count <= index)

                return true;

            else return false;
        }

            public void OpenManageProjects()
        {
            driver.FindElement(By.CssSelector(@"a[href*='manage_overview_page']")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(@"a[href*='manage_proj_page']")).Click();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
