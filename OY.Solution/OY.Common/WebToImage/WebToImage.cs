using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace OY.Common.WebToImage
{
    /// <summary>
    /// 图片生产过程
    /// </summary>
    class GetSnap
    {
        /// <summary>
        /// 网站信息
        /// </summary>
        private string MyURL;

        /// <summary>
        /// 网站信息
        /// </summary>
        public string WebSite
        {
            get { return MyURL; }
            set { MyURL = value; }
        }

        /// <summary>
        /// 网站信息是否为url
        /// </summary>
        protected bool isUrl;

        /// <summary>
        /// 实例化对象并赋值
        /// </summary>
        /// <param name="WebSite"></param>
        /// <param name="isUrl"></param>
        public GetSnap(string WebSite, bool isUrl/*, int ScreenWidth, int ScreenHeight, int ImageWidth, int ImageHeight*/)
        {
            this.WebSite = WebSite;
            this.isUrl = isUrl;
        }

        /// <summary>
        /// 开始作图
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap()
        {
            WebPageBitmap Shot = new WebPageBitmap(this.WebSite, isUrl/*, this.ScreenWidth, this.ScreenHeight*/);
            Shot.GetIt();
            //Bitmap Pic = Shot.DrawBitmap(this.ImageHeight, this.ImageWidth);
            Bitmap Pic = Shot.DrawBitmap();
            return Pic;
        }
    }

    /// <summary>
    /// 线程中转
    /// </summary>
    class WebPageBitmap
    {
        WebBrowser MyBrowser;
        string URL;
        int Height;
        int Width;
        bool isUrl;

        /// <summary>
        /// 初始化对象 并 初始化 浏览器插件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isUrl"></param>
        public WebPageBitmap(string url, bool isUrl/*, int width, int height*/)
        {
            this.URL = url;
            this.isUrl = isUrl;
            MyBrowser = new WebBrowser();
            MyBrowser.ScrollBarsEnabled = false;
        }

        /// <summary>
        /// 填充浏览器插件信息
        /// </summary>
        public void GetIt()
        {
            if (this.isUrl)
            {
                MyBrowser.Navigate(this.URL);
            }
            else
            {
                MyBrowser.DocumentText = this.URL;
            }

            //判断内容是否加载完成
            while (MyBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            this.Height = int.Parse(MyBrowser.Document.Body.GetAttribute("scrollHeight"));
            this.Width = int.Parse(MyBrowser.Document.Body.GetAttribute("scrollwidth"));
            MyBrowser.Size = new Size(this.Width, this.Height);
        }

        /// <summary>
        /// 图片作业
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawBitmap(/*int theight, int twidth*/)
        {
            int theight = this.Height;
            int twidth = this.Width;
            Bitmap myBitmap = new Bitmap(Width, Height);
            Rectangle DrawRect = new Rectangle(0, 0, Width, Height);
            MyBrowser.DrawToBitmap(myBitmap, DrawRect);
            System.Drawing.Image imgOutput = myBitmap;
            System.Drawing.Image oThumbNail = new Bitmap(twidth, theight, imgOutput.PixelFormat);
            Graphics g = Graphics.FromImage(oThumbNail);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle oRectangle = new Rectangle(0, 0, twidth, theight);
            g.DrawImage(imgOutput, oRectangle);
            try
            {
                return (Bitmap)oThumbNail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                imgOutput.Dispose();
                imgOutput = null;
                MyBrowser.Dispose();
                MyBrowser = null;
            }
        }
    }

    /// <summary>
    /// 线程开始
    /// </summary>
    public class WebToThumbnail
    {
        /// <summary>
        /// 图片保存地址
        /// </summary>
        private string imagePath;

        /// <summary>
        /// 图片保存地址
        /// </summary>
        public string ImagePath
        {
            get
            {
                return imagePath;
            }

            set
            {
                string pathRegex = @"^[a-zA-Z]\:[\\a-zA-Z0-9_\\]+[\.]?[a-zA-Z0-9_]+.+$";
                if (!Regex.IsMatch(value, pathRegex))
                {
                    throw new Exception("图片地址错误");
                }
                imagePath = value;
            }
        }

        /// <summary>
        /// 网站信息 可以为 网站 或 网页内容
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("请填写网站信息或网址信息");
                }
                //网址正则
                string urlRegex = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$";
                if (Regex.IsMatch(value, urlRegex))
                {
                    isUrl = true;
                    url = value;
                }
                else
                {
                    string htmlStr = string.Empty;
                    htmlStr += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
                    htmlStr += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
                    htmlStr += "<head>";
                    htmlStr += "<title></title>";
                    htmlStr += "<style  type=\"text/css\"> body{ width:100%; height:100%; margin:0px;padding:0px;} </style>";
                    htmlStr += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
                    htmlStr += "</head><body>";
                    htmlStr += value;
                    htmlStr += "</body></head></html>";
                    url = htmlStr;
                    isUrl = false;
                }
            }
        }

        /// <summary>
        /// 网站信息 可以为 网站 或 网页内容
        /// </summary>
        private string url;

        /// <summary>
        /// 线程对象
        /// </summary>
        protected Thread NewTh;

        protected bool isUrl;

        /// <summary>
        /// 构造函数
        /// </summary>
        public WebToThumbnail()
        {
            if (NewTh != null)
            {
                NewTh.Abort();
            }
            NewTh = new Thread(CaptureImage);
            NewTh.SetApartmentState(ApartmentState.STA);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="imagePath">图片地址</param>
        /// <param name="url">网站信息</param>
        public WebToThumbnail(string imagePath, string url)
        {
            this.ImagePath = imagePath;
            this.Url = url;
            if (NewTh != null)
            {
                NewTh.Abort();
            }
            NewTh = new Thread(CaptureImage);
            NewTh.SetApartmentState(ApartmentState.STA);
        }

        /// <summary>
        /// 捕获屏幕
        /// </summary>
        private void CaptureImage()
        {
            try
            {
                GetSnap thumb = new GetSnap(url, isUrl);
                System.Drawing.Bitmap x = thumb.GetBitmap();//获取截图
                //保存截图到SnapPic目录下
                x.Save(ImagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                NewTh.Abort();
            }
        }

        /// <summary>
        /// 开始生产图片
        /// </summary>
        public void Start()
        {
            //开始线程
            NewTh.Start();
            //等待线程结束
            NewTh.Join();
        }
    }
}
