using DriveDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Gateways.Drive
{
    public class RestDriveApi : IDriveApi
    {
        public Task<Models.File> RetrieveFile(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public Task<Folder> RetrieveFolder(Guid folderId)
        {
            throw new NotImplementedException();
        }

        public Task<Folder> RetrieveRootFolder()
        {
            throw new NotImplementedException();
        }
    }
}
