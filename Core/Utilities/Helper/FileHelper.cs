using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        private static string _currentDirection = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDirection + _folderName);
            CreateFile(_currentDirection + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            
            File.Delete((_currentDirection + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (!fileExists.Success)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImage((_currentDirection + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirection + _folderName);
            CreateFile(_currentDirection + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));

        }

        public static void DeleteOldImage(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory);
            }
        }

        public static void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        public static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static IResult CheckFileExists(IFormFile file)
        {
            if (file != null || file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exist!");
        }

        public static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type!");
            }
            return new SuccessResult();
        }
    }
}
