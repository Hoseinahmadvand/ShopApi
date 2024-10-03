using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById;

public class GetRoleByIdQueryHandler:IQueryHandler<GetRoleByIdQuery,RoleDto>
{
    private readonly ShopContext _context;

    public GetRoleByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
       var role =await _context.Roles.FirstOrDefaultAsync(r=>r.Id==request.RoleId,cancellationToken);
        if (role == null)
            return null;
        return new RoleDto()
        {
            Id = role.Id,
            Permissions = role.Permissions.Select(r=>r.Permission).ToList(),
            CreationDate = role.CreationDate,
            Title = role.Title,
        };
    }
}