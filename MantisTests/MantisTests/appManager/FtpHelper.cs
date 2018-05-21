using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace MantisTests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            //логин
            client.Credentials = new System.Net.NetworkCredential("Mantis", "");
            // установление соединения, прервётся само после окончания теста 
            client.Connect();
        }

        public void BackupFile(String path)
        {
            String backupPath = path + ".bak";
            //если файл существует , выходим
            if (client.FileExists(backupPath))
            {
                return;
            }

            client.Rename(path, backupPath);
        }

        public void RestoreBackupFile(String path)
        {
            String backupPath = path + ".bak";
            //если файл не существует , выходим
            if (!client.FileExists(backupPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path);
        }

        public void Upload(String path, Stream localFIle)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path))
            {
                //буфер чтения
                byte[] buffer = new byte[8 * 1024];
                //куда, сдвиг, размер буферра = кол-во байт для чтения
                // count - сколько было реально прочитано 
                int count = localFIle.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFIle.Read(buffer, 0, buffer.Length);
                }
            }

        }
    }
}
