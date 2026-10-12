using Onyxshop.Models;

namespace Onyxshop.Data.Repositories;

public interface IGroupRepository
{
    //برای این که همه گروه هامو بکشم بیرون
    IEnumerable<Category> getallcategories();
}

public class GroupRepository : IGroupRepository
{
    private OnyxContext _context;
    public GroupRepository(OnyxContext context)
    {
        _context = context;
    }
    public IEnumerable<Category> getallcategories()
    {
        return _context.categories;
    }
}


