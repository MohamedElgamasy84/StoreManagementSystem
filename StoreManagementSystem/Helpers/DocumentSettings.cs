namespace StoreManagementSystem.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",FolderName);
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            string FilePath = Path.Combine(FolderPath,FileName);
            using var Fs = new FileStream(FilePath, FileMode.CreateNew);
            file.CopyTo(Fs);
            return FileName;
        }
    }
}
