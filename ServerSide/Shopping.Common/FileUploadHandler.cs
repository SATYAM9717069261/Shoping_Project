using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shopping.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Common
{
    public class FileUploadHandler { }

    public class MultiFileUpload{

        private readonly string _config;
        public MultiFileUpload(string configuration)
        {
            _config = configuration;
        }


        public async Task<List<KeyValuePair<string, bool>>> filesupload(List<IFormFile> files)
        {
            try
            {
                long size = files.Sum(f => f.Length);
                List<KeyValuePair<string, bool>> filestatus = new List<KeyValuePair<string, bool>>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var path = Path.Combine(_config, Path.GetRandomFileName());
                        filestatus.Add(new KeyValuePair<string, bool>(path, true));
                        using (var stream = System.IO.File.Create(path))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return filestatus;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public async Task<KeyValuePair<string, bool>> fileUpload(IFormFile file)
        {
            try
            {
                KeyValuePair<string, bool> filestatus = new KeyValuePair<string, bool>();
                if (file.Length > 0){
                    var path = Path.Combine(_config, Path.GetRandomFileName());
                    filestatus = new KeyValuePair<string, bool>(path, true);
                    using (var stream = System.IO.File.Create(path)){
                        await file.CopyToAsync(stream);
                    }
                 }
                
                return filestatus;
            }
            catch (Exception e)
            {
                return (new KeyValuePair<string,bool>(e.Message,false));
            }

        }



    }
}
