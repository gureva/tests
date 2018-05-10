using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        private AutoItX3 aux;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
            aux = new AutoItX3();
            aux.Run(@"C:\Users\i.gurieva\source\repos\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux { get { return aux; } }

        public GroupHelper Groups
        { get { return groupHelper; }
        
        }
    }
}
