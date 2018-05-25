using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantisTests
{
   public class APIHelper : HelperBase
    {       
        public APIHelper(ApplicationManager manager) : base(manager){}

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
        private List<Mantis.ProjectData> projectCache = null;

        public List<Mantis.ProjectData> GellAllProjects(AccountData account)
        {

            if (projectCache == null)
            {
                projectCache = new List<Mantis.ProjectData>();

                Mantis.MantisConnectPortTypeClient mantis = new Mantis.MantisConnectPortTypeClient();
                manager.Project.OpenManageProjects();
                projectCache = mantis.mc_projects_get_user_accessible(account.Name, account.Password).ToList();
            }
            return projectCache;
        }

        public void CreateProject(AccountData account, Mantis.ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            manager.Project.OpenManageProjects();
            client.mc_project_add(account.Name, account.Password, project);

        }
    }
}
