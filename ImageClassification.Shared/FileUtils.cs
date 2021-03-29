using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ImageClassification.DataModels;
// using ImageClassification.Shared.Service;

namespace ImageClassification
{
    public class FileUtils
    {
        public static IEnumerable<(string imagePath, string label)> LoadImagesFromDirectory(
            string folder,
            bool useFolderNameasLabel)
        {
            Console.WriteLine("Running LoadImagesFromDirectory");
            // SharedService service = new SharedService();
            // var q = service.GetImagesAndCategories();
            // List<ImageCategoryTempDto> ImagePath = new List<ImageCategoryTempDto>();
            // foreach(var item in q.ImagesLabel)
            // {
            //     ImageCategoryTempDto tempData = new ImageCategoryTempDto();
            //     var imagePath = Path.Combine("/var/www/dotnet/AutomobileClassification/WebApi/wwwroot",
            //     "Uploads",item.ImageName);
                
            //     tempData.imagePath = imagePath;
            //     tempData.label = item.Label;
            //     ImagePath.Add(tempData);
            // }

            // return ImagePath.Select(x => (x.imagePath, x.label));
            var imagesPath = Directory
                .GetFiles(folder, "*", searchOption: SearchOption.AllDirectories)
                .Where(x => Path.GetExtension(x) == ".jpg" || Path.GetExtension(x) == ".png");
            return useFolderNameasLabel
                ? imagesPath.Select(imagePath => (imagePath, Directory.GetParent(imagePath).Name))
                : imagesPath.Select(imagePath =>
                {
                    var label = Path.GetFileName(imagePath);
                    for (var index = 0; index < label.Length; index++)
                    {
                        if (!char.IsLetter(label[index]))
                        {
                            label = label.Substring(0, index);
                            break;
                        }
                    }
                    return (imagePath, label);
                });
        }

        public static IEnumerable<InMemoryImageData> LoadInMemoryImagesFromDirectory(
            string folder,
            bool useFolderNameAsLabel = true)
        { 
            Console.WriteLine("Running LoadInMemoryImagesFromDirectory");
            return LoadImagesFromDirectory(folder, useFolderNameAsLabel)
                .Select(x => new InMemoryImageData(
                    image: File.ReadAllBytes(x.imagePath),
                    label: x.label,
                    imageFileName: Path.GetFileName(x.imagePath)));
        }

        public static string GetAbsolutePath(Assembly assembly, string relativePath)
        {
           
            var assemblyFolderPath = new FileInfo(assembly.Location).Directory.FullName;
            Console.WriteLine(Path.Combine(assemblyFolderPath, relativePath));
            return Path.Combine(assemblyFolderPath, relativePath);
        }
    }

    public class ImageCategoryTempDto
    {
        public string imagePath;
        public string label;
    }
}
