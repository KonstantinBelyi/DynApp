using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Dyna.Models.FileManager
{
    public class FileManager
    {
        HttpPostedFileBase _httpPostedFile;
        public string ServerPath { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string FileName { get; set; }
        public string FullPath
        {
            get
            {
                return Path.Combine(ServerPath, AreaName, ControllerName);
            }
        }
        public FileManager( string serverPath, string areaName, string controllerName, HttpPostedFileBase fileLoad)
        {
            _httpPostedFile = fileLoad;

            ServerPath = serverPath;
            AreaName = areaName;
            ControllerName = controllerName;
            FileName = fileLoad.FileName;
        }
        public void Save()
        {
            try
            {
                if (!Directory.Exists(FullPath))
                {
                    Directory.CreateDirectory(FullPath);
                }
                _httpPostedFile.SaveAs(Path.Combine(FullPath, FileName));
            }
            catch (Exception)
            {
                throw;
            }          
        }   
        
    }
}