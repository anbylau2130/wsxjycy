using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace USP.Controllers
{
    public class KindEditController : Controller
    {
        public JsonResult Upload()
        {
            HttpPostedFileBase fileUpload = Request.Files[0];
            ControllerContext.HttpContext.Request.ContentEncoding = Encoding.GetEncoding("UTF-8");
            ControllerContext.HttpContext.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            ControllerContext.HttpContext.Response.Charset = "UTF-8";
            String aspxUrl = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1);

            //文件保存目录路径
            String savePath = "~/Upload/";

            //文件保存目录URL
            String saveUrl = "/Upload/";

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb,mp4");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2,mp4");

            //最大文件大小
            int maxSize =200*1024*1024;

            HttpPostedFileBase imgFile = Request.Files["imgFile"];
            if (imgFile == null)
            {
                return Json(showError("请选择文件。"));
            }

            String dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                return Json(showError("上传目录不存在。"));
            }

            String dirName = Request.QueryString["dir"];
            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return Json(showError("目录名不正确。"));
            }

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                return Json(showError("上传文件大小超过限制。"));
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
               return Json(showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。"));
            }

            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + newFileName;

            imgFile.SaveAs(filePath);
            String fileUrl = saveUrl + newFileName;
            return Json(new
            {
                error = 0,
                url = fileUrl
            });
        }
       
        public JsonResult FileManager()
        {
            String aspxUrl = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = "~/Upload/";
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            String rootUrl ="/Upload/";
            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            String dirPath = Server.MapPath(rootPath);
            String dirName = Request.QueryString["dir"];
            if (!String.IsNullOrEmpty(dirName))
            {
                if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
                {
                    Response.Write("Invalid Directory name.");
                    Response.End();
                }
                dirPath += dirName + "/";
                rootUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            //根据path参数，设置各路径和URL
            String path = Request.QueryString["path"];
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = Request.QueryString["order"];
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                Response.Write("Access is not allowed.");
                Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                Response.Write("Parameter is not valid.");
                Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                Response.Write("Directory does not exist.");
                Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        private object showError(string msg)
        {
            return new { error = 1, message = msg };
        }

        //视频截图
        public string CatchImg(string vFileName)
        {
            //取得ffmpeg.exe的路径,路径配置在Web.Config中,如:<add key="ffmpeg" value="E:/ffmpeg/ffmpeg.exe" />
            string ffmpeg = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ffmpeg"]);
            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(vFileName)))
            {
                return "";
            }
            //获得图片相对路径/最后存储到数据库的路径,如:/Web/FlvFile/User1/00001.jpg
            string flv_img = System.IO.Path.ChangeExtension(vFileName, ".jpg");
            //图片绝对路径,如:D:/Video/Web/FlvFile/User1/0001.jpg
            string flv_img_p =Server.MapPath(flv_img);
            //截图的尺寸大小,配置在Web.Config中,如:<add key="CatchFlvImgSize" value="240x180" />
            string FlvImgSize = System.Configuration.ConfigurationManager.AppSettings["CatchFlvImgSize"];
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //此处组合成ffmpeg.exe文件需要的参数即可,此处命令在ffmpeg 0.4.9调试通过
            startInfo.Arguments = " -i " + vFileName + " -y -f image2 -t 0.001 -s " + FlvImgSize + "" + flv_img_p;
            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch
            {
                return "";
            }
            ///注意:图片截取成功后,数据由内存缓存写到磁盘需要时间较长,大概在3,4秒甚至更长;
            ///这儿需要延时后再检测,我服务器延时8秒,即如果超过8秒图片仍不存在,认为截图失败;
            ///此处略去延时代码.如有那位知道如何捕捉ffmpeg.exe截图失败消息,请告知,先谢过!
            if (System.IO.File.Exists(flv_img_p))
            {
                return flv_img;
            }
            return "";
        }
    }
    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.FullName.CompareTo(yInfo.FullName);
        }
    }
    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }
    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Extension.CompareTo(yInfo.Extension);
        }
    }
}