using Microsoft.AspNetCore.Mvc;
using Onyxshop.Data;
using Onyxshop.Data.Repositories;
using Onyxshop.Models;

namespace Onyxshop.components
{
    public class ProductGroupsComponent:ViewComponent
    {
        //OnyxContext _context;

        //public ProductGroupsComponent( OnyxContext context)
        //{
        //    _context = context;
        //}

        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository GroupRepository)
        {
            _groupRepository = GroupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/components/ProductGroupsComponentView.cshtml", _groupRepository.getallcategories());
            //"/Views/components/ProductGroupsComponent.cshtml"

        }
        
    }
}
