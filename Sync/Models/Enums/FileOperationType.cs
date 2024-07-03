using System.ComponentModel.DataAnnotations;

namespace Sync.Models.Enums
{
    internal enum FileOperationType
    {
        [Display(Name = "Delete File")]
        DeleteFile = 1,

        [Display(Name = "Copy File")]
        CopyFile = 2,

        [Display(Name = "Create Directory")]
        CrateDirectory = 3,

        [Display(Name = "Delete Directory")]
        DeleteDirectory = 4
    }
}
