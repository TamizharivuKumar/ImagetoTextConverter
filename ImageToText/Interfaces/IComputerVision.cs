namespace ImageToText.Interfaces
{
    public interface IComputerVision
    {
        Task<string> GenerateImageToTextAsync(Stream imageStream);
    }
}
