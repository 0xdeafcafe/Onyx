using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.ViewModels.Project
{
    public class CreateProject
    {
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectDescription { get; set; }
    }
}