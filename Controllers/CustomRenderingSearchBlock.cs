using System.Web.Mvc;
using EPiServer.Find.Blocks;
using EPiServer.Find.Blocks.Controllers;
using EPiServer.Find.Blocks.Models.ContentTypes;

namespace CustomizedSearchBlock.Controllers
{
    using System.Web.Mvc;
    using EPiServer.Find.Blocks;
    using EPiServer.Find.Blocks.Controllers;
    using EPiServer.Find.Blocks.Models.ContentTypes;

    namespace CustomizedSearchBlock.Controllers
    {
        public class CustomRenderingSearchBlock : CustomizedSearchSettingsBlockController
        {
            public CustomRenderingSearchBlock(ICustomizedSearchBlockService customizedSearchBlockService, IContextHelper contextHelper)
                : base(customizedSearchBlockService, contextHelper)
            {
            }

            public override ActionResult Index(CustomizedSearchSettings currentBlock)
            {
                var model = CreateSearchResultsViewModel(currentBlock);
                return PartialView("Index", model);
            }
        }
    }
}