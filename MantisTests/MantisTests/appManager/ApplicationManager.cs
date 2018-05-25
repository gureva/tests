using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MantisTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        /* 
         * Объект для установлени соответствия 
         * между текущим потоком и объектом типа ApplicationManager
        */
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            options.AddArguments("--headless");
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-2.14.0";

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginHelper(this);
            Project = new ProjectHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
        }

        //деструктор
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        //готов для параллельных запусков
        public static ApplicationManager GetInstance()
        {

            if (!app.IsValueCreated )
            {
                ApplicationManager newInstance = new ApplicationManager();

                app.Value = newInstance;
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get;  set; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get; set; }
        public LoginHelper Login { get; set; }
        public ProjectHelper Project { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }
    }
}
