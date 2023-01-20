using MISAPI.DataModel.Models.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISAPI.DAL.Helpers
{
    public class StaticData
    {
        public static List<Menu> GetMenuList()
        {
            List<Menu> module = new List<Menu>();

            //main menu items
            module.AddRange(new List<Menu>
            {
                new Menu {Id = "Dashboard",  Name = "Dashboard", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id ="AdminTasks",  Name = "Admin Tasks", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id ="Consecreations",  Name = "Consecretions", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "JuniorCouncils",  Name = "Junior Councils", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "AdultCouncils",  Name = "Adult Councils", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "RegionalCouncils",  Name = "Regional Councils", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "StateCouncils",  Name = "State Councils", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "SupremeCouncil",  Name = "Supreme Council", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "Applications",  Name = "Applications", UserLogId = 1, CreatedOn = DateTime.Now},
                new Menu {Id = "Reports",  Name = "Reports", UserLogId = 1, CreatedOn = DateTime.Now},
             });

            return module;
        }

        public static List<Operation> GetOperationList()
        {
            List<Operation> operation = new List<Operation>();

            //form control allowed permissions
            operation.AddRange(new List<Operation>
            {
                new Operation {Id = "View",  Name = "View", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Create",  Name = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id ="Edit",  Name = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id ="Delete",  Name = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Approve",  Name = "Approve", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Query",  Name = "Query", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Reject",  Name = "Reject", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Verify",  Name = "Verify", UserLogId = 1, CreatedOn = DateTime.Now},
                new Operation {Id = "Transfer",  Name = "Transfer", UserLogId = 1, CreatedOn = DateTime.Now},
             });

            return operation;
        }

        public static List<MenuOperation> GetMenuOpertionList()
        {
            try
            {
                List<MenuOperation> moduleOperation = new List<MenuOperation>();

                //Permissions allowed for the main menu items
                moduleOperation.AddRange(new List<MenuOperation>
                {
                    new MenuOperation {MenuId = "Dashboard",  OperationId = "View", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId ="AdminTasks",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="AdminTasks",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="AdminTasks",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId ="Consecreations",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="Consecreations",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="Consecreations",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId ="Applications",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="Applications",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="Applications",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId ="Applications",  OperationId = "Approve", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "JuniorCouncils",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "JuniorCouncils",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "JuniorCouncils",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "AdultCouncils",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "AdultCouncils",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "AdultCouncils",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "RegionalCouncils",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "RegionalCouncils",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "RegionalCouncils",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "StateCouncils",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "StateCouncils",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "StateCouncils",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "SupremeCouncil",  OperationId = "Create", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "SupremeCouncil",  OperationId = "Edit", UserLogId = 1, CreatedOn = DateTime.Now},
                    new MenuOperation {MenuId = "SupremeCouncil",  OperationId = "Delete", UserLogId = 1, CreatedOn = DateTime.Now},

                    new MenuOperation {MenuId = "Reports",  OperationId = "View", UserLogId = 1, CreatedOn = DateTime.Now},

                });

                return moduleOperation;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<SubMenu> GetSubMenuList()
        {
            List<SubMenu> subMenu = new List<SubMenu>();

            //Submenu items for the main menu. Any main menu without submenu is not defined here

            subMenu.AddRange(new List<SubMenu>
            {
                new SubMenu {Id="AdminTasksUsers" , MenuId ="AdminTasks",  Name = "Admin Users", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="AdminTasksRoles" , MenuId ="AdminTasks",  Name = "Admin Roles", UserLogId = 1, CreatedOn = DateTime.Now},

                new SubMenu {Id="ConsecreationsJuniors", MenuId ="Consecreations",  Name = "Junior Council/Court Consecreation", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="ConsecreationsAdults", MenuId ="Consecreations",  Name = "Adult Council/Court Consecreation", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="ConsecreationsRegions", MenuId ="Consecreations",  Name = "Region Council/Court Consecreation", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="ConsecreationsStates", MenuId ="Consecreations",  Name = "State Council/Court Consecreation", UserLogId = 1, CreatedOn = DateTime.Now},

                new SubMenu {Id="ApplicationsJuniors", MenuId = "Applications",  Name = "Junior Applicants", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="ApplicationsAdults", MenuId = "Applications",  Name = "Adult Applicants", UserLogId = 1, CreatedOn = DateTime.Now},

                new SubMenu {Id="JuniorCouncilsMembers", MenuId = "JuniorCouncils",  Name = "Junior Council/Court Members", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="JuniorCouncilsMeetings", MenuId = "JuniorCouncils",  Name = "Junior Council/Court Meetings", UserLogId = 1, CreatedOn = DateTime.Now},

                new SubMenu {Id="AdultCouncilsMembers", MenuId = "AdultCouncils",  Name = "Adult Council/Court Members", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="AdultCouncilsMeetings", MenuId = "AdultCouncils",  Name = "Adult Council/Court Meetings", UserLogId = 1, CreatedOn = DateTime.Now},
                
                new SubMenu {Id="RegionalCouncilsMembers", MenuId = "RegionalCouncils",  Name = "Regional Council/Court Members", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="RegionalCouncilsMeetings", MenuId = "RegionalCouncils",  Name = "Regional Council/Court Meetings", UserLogId = 1, CreatedOn = DateTime.Now},
                
                new SubMenu {Id="StateCouncilsMembers", MenuId = "StateCouncils",  Name = "State Council/Court Members", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="StateCouncilsMeetings", MenuId = "StateCouncils",  Name = "State Council/Court Meetings", UserLogId = 1, CreatedOn = DateTime.Now},
                
                new SubMenu {Id="SupremeCouncilMembers", MenuId = "SupremeCouncil",  Name = "Supreme Council/Court Members", UserLogId = 1, CreatedOn = DateTime.Now},
                new SubMenu {Id="SupremeCouncilMeetings", MenuId = "SupremeCouncil",  Name = "Supreme Council/Court Meetings", UserLogId = 1, CreatedOn = DateTime.Now},
                
                new SubMenu {Id="UsersReports", MenuId = "Reports",  Name = "Users Reports", UserLogId = 1, CreatedOn = DateTime.Now},
                
             });

            return subMenu;
        }
    }
}
