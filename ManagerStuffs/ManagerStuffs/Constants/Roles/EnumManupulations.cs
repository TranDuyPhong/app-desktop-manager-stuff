using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants
{
    public enum EnumRoles
    {
        [Description("Tất cả quyền")]
        [RoleControlName(Name = "All Roles")]
        AllRoles,
        [Description("Xem danh mục vật tư")]
        [RoleControlName(Name = "mCategories")]
        ShowCategories,
        [Description("Thêm danh mục vật tư")]
        [RoleControlName(Name = "btnInsertCategories")]
        InsertCategories,
        [Description("Sửa danh mục vật tư")]
        [RoleControlName(Name = "btnEditCategories")]
        EditCategories,
        [Description("Xóa danh mục vật tư")]
        [RoleControlName(Name = "btnDeleteCategories")]
        DeleteCategories,
        [Description("Xem vật tư")]
        [RoleControlName(Name = "mStuffs")]
        ShowStuffs,
        [Description("Thêm vật tư")]
        [RoleControlName(Name = "btnInsertStuffs")]
        InsertStuffs,
        [Description("Sửa vật tư")]
        [RoleControlName(Name = "btnEditStuffs")]
        EditStuffs,
        [Description("Xóa vật tư")]
        [RoleControlName(Name = "btnDeleteStuffs")]
        DeleteStuffs,
        [Description("Xem nơi")]
        [RoleControlName(Name = "mPlaceStuffs")]
        ShowPlaceStuffs,
        [Description("Thêm nơi")]
        [RoleControlName(Name = "btnInsertPlaceStuffs")]
        InsertPlaceStuffs,
        [Description("Sửa nơi")]
        [RoleControlName(Name = "btnEditPlaceStuffs")]
        EditPlaceStuffs,
        [Description("Xóa nơi")]
        [RoleControlName(Name = "btnDeletePlaceStuffs")]
        DeletePlaceStuffs,
        [Description("Xem nơi cho vật tư")]
        [RoleControlName(Name = "mStuffsPlaceStuffs")]
        ShowStuffsPlaceStuffs,
        [Description("Thêm nơi cho vật tư")]
        [RoleControlName(Name = "btnInsertStuffsPlaceStuffs")]
        InsertStuffsPlaceStuffs,
        [Description("Sửa nơi cho vật tư")]
        [RoleControlName(Name = "btnEditStuffsPlaceStuffs")]
        EditStuffsPlaceStuffs,
        [Description("Xóa nơi cho vật tư")]
        [RoleControlName(Name = "btnDeleteStuffsPlaceStuffs")]
        DeleteStuffsPlaceStuffs,
        [Description("Xem tài khoản")]
        [RoleControlName(Name = "mUsers")]
        ShowUsers,
        [Description("Thêm nơi cho vật tư")]
        [RoleControlName(Name = "btnInsertUsers")]
        InsertUsers,
        [Description("Sửa nơi cho vật tư")]
        [RoleControlName(Name = "btnEditUsers")]
        EditUsers,
        [Description("Xóa nơi cho vật tư")]
        [RoleControlName(Name = "btnDeleteUsers")]
        DeleteUsers,
        [Description("Xem log")]
        [RoleControlName(Name = "gvLogs")]
        ShowLogs,
        [Description("Xuất Excel")]
        [RoleControlName(Name = "mExportExcels")]
        ExportExcels
    }
}
