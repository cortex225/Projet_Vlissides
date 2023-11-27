using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile;

public class ProfileIndexVM
{
    [Display(Name = "Profile Modifier")] public ProfileModifierInformationVM ProfileModifierInformationVM { get; set; }

    public ProfileIndexVM(ProfileModifierInformationVM profileModifierInformationVM)
    {
        ProfileModifierInformationVM = profileModifierInformationVM;
    }
}