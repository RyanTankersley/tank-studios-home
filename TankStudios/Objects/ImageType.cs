using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStudios.Objects
{
    public enum ImageType
    {
        Tech,
        Life,
        Dev
    }

    public static class ImageTypeHelper
    {
        public static string GetImageRelativePath(ImageType type)
        {
            var path = string.Empty;
            switch(type)
            {
                case ImageType.Tech:
                    path = "~/Content/freelancer/portfolio/satelliteSmall.png";
                    break;
                case ImageType.Life:
                    path = "~/Content/freelancer/portfolio/cabinSmall.png";
                    break;
                case ImageType.Dev:
                    path = "~/Content/freelancer/portfolio/gpsSmall.png";
                    break;
                default:
                    throw new NotImplementedException(type.ToString() + " is not supported.");
            }
            return path;
        }

    }
}