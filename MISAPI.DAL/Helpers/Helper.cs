using AutoMapper;
using MISAPI.DAL.Interfaces;
using System;

namespace MISAPI.DAL.Helpers
{
    public static class Helper
    {
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return (Math.Abs(monthsApart) +1);
        }
        
    }

    public class GeneralData//: ControllerBase
    {
        private readonly IRoleInterface _roleService;
        private readonly IMapper _mapper;

        //public ActionResult<IEnumerable<RoleResponse>> GetRoles()
        //{
        //    DataContext _context = new DataContext()
        //    var data = _roleService.GetAll();
        //    return Ok(data);
        //}
    }
}
