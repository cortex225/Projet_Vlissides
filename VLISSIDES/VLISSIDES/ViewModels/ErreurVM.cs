namespace VLISSIDES.ViewModels;

public class ErreurVM
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}