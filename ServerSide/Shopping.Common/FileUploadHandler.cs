using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration _config;
        public MultiFileUpload(IConfiguration configuration)
        {
            _config = configuration;
        }


        public async Task<List<KeyValuePair<string, bool>>> OnPostUploadAsync(List<IFormFile> files)
        {
            try
            {
                long size = files.Sum(f => f.Length);
                List<KeyValuePair<string,bool>> filestatus = new List<KeyValuePair<string, bool>>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var path = Path.Combine(_config["StoredFilesPath"],
                            Path.GetRandomFileName());
                        filestatus.Add(new KeyValuePair<string, bool>(path, true));
                        using (var stream = System.IO.File.Create(path))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return filestatus;
            }
            catch(Exception e) {
                return null;
            }
            
        }
    }
}
