using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using RabblyApi.Permissions.Models;

namespace RabblyApi.Permissions.Services
{
    public class PermissionsService
    {
    //     private readonly IMapper _mapper;
    //     private readonly DatabaseContext _context;

    //     public PermissionsService(DatabaseContext context, IMapper mapper)
    //     {
    //         _mapper = mapper;
    //         _context = context;
    //     }

    //     public async Task<bool> AddPermission(Permission permission)
    //     {
    //         var newPermission = await _context.Permissions.AddAsync(permission);
    //         if(newPermission != null)
    //         {
    //             return true;
    //         }
    //         return false;
    //     }

    //     public async Task<Permission> EditPermission(Permission permission)
    //     {
    //         var permissiontoEdit = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == permission.Id);
    //         permissiontoEdit = permission;
    //         _context.Update(permissiontoEdit);
    //         await _context.SaveChangesAsync();
    //         return permissiontoEdit;
    //     }
    }
}