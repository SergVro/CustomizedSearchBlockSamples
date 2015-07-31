using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomizedSearchBlock.Models.ViewModels;
using EPiServer.Find;
using EPiServer.Find.Blocks;
using EPiServer.Find.Blocks.Controllers;
using EPiServer.Find.Blocks.Models.ContentTypes;
using EPiServer.Web.Mvc;

namespace SearchBlockSample.Controllers
{
    public class SearchBlockWithImages : CustomizedSearchSettingsBlockController
    {
        private readonly ICustomizedSearchBlockService _searchBlockService;

        public SearchBlockWithImages(ICustomizedSearchBlockService searchBlockService, IContextHelper contextHelper) : base(searchBlockService, contextHelper)
        {
            _searchBlockService = searchBlockService;
        }

        public override ActionResult Index(CustomizedSearchSettings currentBlock)
        {
            var customizedSearchBlock = GetParentCustomizedSearchBlock(currentBlock);

            var search = _searchBlockService.CreateSearchQuery(customizedSearchBlock);
            var results = search.StaticallyCacheFor(TimeSpan.FromMinutes(5)).GetResult(); // cache search results for 5 minutes
            var items = results.Select(h => new LinkWithImage {Title = h.Title, ImageUri = h.ImageUri, Url = h.Url}).ToList();
            var model = new SearchBlockWithImagesModel {Items = items};

            return PartialView("Index", model);
        }
    }
}