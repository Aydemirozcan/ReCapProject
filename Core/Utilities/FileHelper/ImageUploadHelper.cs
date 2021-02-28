using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Core.Utilities.FileHelper
{
    public class ImageUploadHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file)
        {
            try
            {
                var fileExists = CheckFileExists(file);
                if (fileExists.Message != null)
                {
                    return fileExists;
                }

                var type = Path.GetExtension(file.FileName);
                var typeValid = CheckFileTypeValid(type);
                var randomName = Guid.NewGuid().ToString();
                if (typeValid.Message != null)
                {
                    return typeValid;
                }
                CheckDirectoryExists(_currentDirectory + _folderName);
                CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
                return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));         //windows (\\) kabul eder web ise (/)
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }

        }
        public static IResult Update(IFormFile file,string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message!=null)
            {
                return fileExists;
            }

            var type = Path.GetExtension(file.FileName);                 //GetExtension uzantıları noktayla birlikte alır.
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message!=null)
            {
                return typeValid;
            }

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }
    
        private static IResult CheckFileExists(IFormFile file)
        {
            if (file!=null && file.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't Exists");
        }
        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("The File Type Is Invalid");
            }
            return new SuccessResult();
        }
        private static void CreateImageFile(string directory,IFormFile file)
        {
            using (FileStream filestream = File.Create(directory))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }
        }
       private static void CheckDirectoryExists(string directory)
       {
            if (!Directory.Exists(directory))                     
            {
                Directory.CreateDirectory(directory);         //Dizin geçersizse yeni bir dizin oluşturur.
            }
       }
       private static void DeleteOldImageFile(string directory)
       {
            if (File.Exists(directory.Replace("/","\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
       }
    
    
    
    }
}
