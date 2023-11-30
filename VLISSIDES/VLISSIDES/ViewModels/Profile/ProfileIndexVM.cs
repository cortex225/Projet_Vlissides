using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile;

public class ProfileIndexVM
{
    [Display(Name = "Profile Modifier")] public ProfileModifierInformationVM ProfileModifierInformationVM { get; set; }

    public ProfileIndexVM(ProfileModifierInformationVM profileModifierInformationVM)
    {
        ProfileModifierInformationVM = profileModifierInformationVM;
    }
    public ProfileIndexVM(ApplicationUser user)
    {
        ProfileModifierInformationVM = new(user);
    }
}