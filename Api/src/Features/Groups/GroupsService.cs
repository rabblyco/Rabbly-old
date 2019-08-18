using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using RabblyApi.Groups.Dtos;
using RabblyApi.Groups.Models;
using RabblyApi.Permissions.Models;
using RabblyApi.Ranks.Models;

namespace RabblyApi.Groups.Services
{
    public class GroupService
    {
        // private readonly DatabaseContext _context;

        // public GroupService(DatabaseContext context)
        // {
        //     _context = context;
        // }

        // public async Task<Group> GetGroup(string id)
        // {
        //     var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        //     if (group == null)
        //     {
        //         return null;
        //     }
        //     return group;
        // }

        // public async Task<List<Group>> GetAllGroups()
        // {
        //     return await _context.Groups.OrderByDescending(g => g.Users.Count()).ToListAsync();
        // }


        // public async Task<bool> CreateGroup(GroupCreateRequestDto group)
        // {
        //     var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == group.Creator.Id);
        //     var groupExists = await _context.Groups.AnyAsync(g => g.Name == group.Name);
        //     // If a user doesn't exist, they already belong to a group, or the group already exists
        //     if (user == null || user.Group != null || groupExists)
        //     {
        //         return false;
        //     }

        //     var newGroup = new Group();
        //     newGroup.Bio = group.Bio;
        //     newGroup.LogoUrl = group.LogoUrl;
        //     newGroup.Name = group.Name;
        //     newGroup.Owner = group.Creator;

        //     try
        //     {
        //         await _context.Groups.AddAsync(newGroup);
        //         var ranks = await CreateDefaultRanks(newGroup);
        //         // Add this data to the creating user
        //         user.Group = newGroup;
        //         user.Rank = ranks.Find(r => r.Level == 1);
        //         _context.Users.Update(user);
        //         await _context.SaveChangesAsync();
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.Write(ex);
        //         return false;
        //     }
        //     return true;
        // }

        // public async Task<Group> EditGroup(string id, GroupCreateRequestDto group)
        // {
        //     var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == group.Creator.Id);
        //     var groupToEdit = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        //     if (user == null || groupToEdit == null || !user.Rank.Permissions.CanEditGroup)
        //     {
        //         return null;
        //     }
        //     groupToEdit.LogoUrl = group.LogoUrl;
        //     groupToEdit.Name = group.Name;
        //     groupToEdit.Bio = group.Bio;

        //     try
        //     {
        //         _context.Groups.Update(groupToEdit);
        //         await _context.SaveChangesAsync();
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.Write(ex);
        //         return null;
        //     }
        //     return groupToEdit;
        // }

        // public async Task<bool> DeleteGroup(string id)
        // {
        //     var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        //     try
        //     {
        //         _context.Groups.Remove(group);
        //         await _context.SaveChangesAsync();
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.Write(ex);
        //         return false;
        //     }
        //     return true;
        // }

        // private async Task<List<Rank>> CreateDefaultRanks(Group group)
        // {
        //     var adminPermissions = new Permission() {
        //         CanAddMember = true,
        //         CanAddRank = true,
        //         CanCreateDiscussion = true,
        //         CanCreateRole = true,
        //         CanEditMemberRank = true,
        //         CanEditRankPermissions = true,
        //         CanParticipateInGroupDiscussion = true,
        //         CanRemoveMember = true,
        //         CanRemoveRank = true,
        //         CanRepresentGroup = true
        //     };
        //     var memberPermissions = new Permission();
        //     List<Rank> newRanks = new List<Rank>(2);
        //     try
        //     {
        //         await _context.Permissions.AddRangeAsync(adminPermissions, memberPermissions);
        //         newRanks.Add(new Rank() { Group = group, Title = "Admin", Level = 1, Permissions = adminPermissions });
        //         newRanks.Add(new Rank() { Group = group, Title = "Member", Level = 2, Permissions = memberPermissions });
        //         await _context.Ranks.AddRangeAsync(newRanks);
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.Write(ex);
        //         return null;
        //     }

        //     return newRanks;
        // }
    }
}