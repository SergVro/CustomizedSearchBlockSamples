using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;

namespace CustomizedSearchBlock.Models.ViewModels
{
    public class SearchBlockWithImagesModel
    {
        public List<LinkWithImage> Items { get; set; }
    }
    public class LinkWithImage
    {
        public String Title { get; set; }
        public Url Url { get; set; }
        public Uri ImageUri { get; set; }
    }
}