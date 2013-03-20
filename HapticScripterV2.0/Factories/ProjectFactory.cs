using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Factories
{
    using System.IO;
    using System.Threading.Tasks;

    using HapticScripterV2._0.ViewModels;

    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;

    public static class ProjectFactory
    {
        public static Task OpenProject(string projectFilePath)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var fs = File.OpenRead(projectFilePath);
                    var zf = new ZipFile(fs);
                    foreach (ZipEntry ze in zf)
                    {
                        var buffer = new byte[4096]; // 4K is optimum
                        var zipStream = zf.GetInputStream(ze);

                        var randomFileName = Path.GetRandomFileName();

                        var fullZipToPath = Path.Combine(Path.GetTempPath(), randomFileName + Path.GetExtension(ze.Name));

                        using (var streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }

                        switch (ze.Name)
                        {
                            case "script.txt":
                                AppViewModel.DataViewModel.ScriptFilePath = fullZipToPath;

                                //new Task(this.parseScript).Start();
                                break;
                            case "video.wmv":
                                AppViewModel.DataViewModel.VideoFilePath = fullZipToPath;
                                break;
                            case "ImageCache.zip":
                                //ImageCacheFile = fullZipToPath;
                                //new Task(() => this.buildImageListIndex(this.ImageCacheFile)).Start();
                                break;
                            case "info.txt":
                                AppViewModel.DataViewModel.InfoFilePath = fullZipToPath;
                                break;
                        }
                    }

                    zf.Close();

                    string[] lines = File.ReadAllLines(AppViewModel.DataViewModel.InfoFilePath);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("Duration:"))
                        {
                            AppViewModel.DataViewModel.VideoDuration = Convert.ToDouble(line.Split(':')[1]);
                        }
                    }

                    //Logger.Log("Video File:" + VideoFile);
                    //Logger.Log("ImageCache File:" + ImageCacheFile);
                    //Logger.Log("Script File:" + ScriptFile);

                    var fileName = Path.GetFileName(projectFilePath);
                    if (fileName != null)
                    {
                        AppViewModel.DataViewModel.ProjectName = fileName.Split('.')[0];
                    }

                    AppViewModel.DataViewModel.IsDirty = false;
                });
        }
    }
}
