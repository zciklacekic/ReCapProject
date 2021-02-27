using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utilities.FileOperation
{
    public class FileOperation
    {
        public IFormFile files { get; set; }
        public string carImages { get; set; }

        //public static IDataResult<string> UploadFile(IFormFile file)
        //{

        //    var sourcePath = Path.GetTempFileName();
            
        //    if (!Directory.Exists(sourcePath))
        //    {
        //        Directory.CreateDirectory(sourcePath);
        //    }

        //    if (file.Length > 0)
        //        using (var stream = new FileStream(sourcePath, FileMode.Create))
        //            file.CopyTo(stream);

        //    var result = CreateGuid(file).Data;

        //    File.Move(sourcePath, result);

        //    return new SuccessDataResult<string>(result);
        //}

        //public static IDataResult<string> UpdateFile(string sourcePath, IFormFile file)
        //{
        //    var result = CreateGuid(file).Data;

        //    File.Copy(sourcePath, result);

        //    File.Delete(sourcePath);

        //    return new SuccessDataResult<string>(result);

        //}

        //public static IDataResult<string> CreateGuid(IFormFile file)
        //{
        //    string[] fileNameSplit = file.FileName.Split('.');
        //    var extensionOfFile = "." + fileNameSplit[fileNameSplit.Length - 1];
        //    var newImageFileName = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + "_"
        //        + Guid.NewGuid().ToString() + extensionOfFile;

        //    string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\uploads");

        //    string result = $@"{path}\{newImageFileName}";

        //    return new SuccessDataResult<string>(result);

        //}

    }
}

