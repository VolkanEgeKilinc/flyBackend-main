namespace BilethubApi.Core.Extensions;

public static class IFormFileExtension
{
    public static async Task<string> SaveFile(this IFormFile file, string folderPath)
    {
        folderPath = Path.GetTempPath() + folderPath;

        if (!Directory.Exists(folderPath))
        {
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
        }

        var filePath = Guid.NewGuid().ToString() + "_" + file.FileName;

        using (var stream = System.IO.File.Create(folderPath + filePath))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }
}