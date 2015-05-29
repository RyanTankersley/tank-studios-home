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
                    path = "http://i1068.photobucket.com/albums/u458/Ryan_Tankersley/aqws_zpszpg7nkn2.png";
                    break;
                case ImageType.Life:
                    path = "http://i1068.photobucket.com/albums/u458/Ryan_Tankersley/qwsa_zpskqgidov6.png";
                    break;
                case ImageType.Dev:
                    path = "http://i1068.photobucket.com/albums/u458/Ryan_Tankersley/wsaq_zps93gqfqao.png";
                    break;
                default:
                    throw new NotImplementedException(type.ToString() + " is not supported.");
            }
            return path;
        }

    }
}