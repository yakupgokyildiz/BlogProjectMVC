using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace YakupMyBlog.App_Classes
{
    public class Settings
    {
        public static Size ImageSmallSize {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["swh"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["swh"]);
                return result;
            }
        }

        public static Size ImageMediumSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mwh"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mwh"]);
                return result;
            }
        }

        public static Size ImageBigSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return result;
            }
        }
    }
}