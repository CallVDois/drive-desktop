using DriveDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Gateways.Drive
{
    public interface IDriveApi
    {
        Task<Models.Folder> RetrieveRootFolder();

        Task<Models.Folder> RetrieveFolder(Guid folderId);

        Task<Models.File> RetrieveFile(Guid fileId);

    }
}
