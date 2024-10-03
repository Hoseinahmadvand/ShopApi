using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;
using System.Data;

namespace Shop.Query.Roles.GetList;

public class GetListRolesQuaryHandler : IQueryHandler<GetListRolesQuary, List<RoleDto>>
{
    private readonly ShopContext _context;

    public GetListRolesQuaryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<RoleDto>> Handle(GetListRolesQuary request, CancellationToken cancellationToken)
    {
        return await _context.Roles
            .Select(r => new RoleDto {
                Id = r.Id,
                Permissions = r.Permissions.Select(r => r.Permission).ToList(),
                CreationDate = r.CreationDate,
                Title = r.Title,
            }).ToListAsync(cancellationToken);
    }
}