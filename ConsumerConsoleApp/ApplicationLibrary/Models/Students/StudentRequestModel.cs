using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Commons.RequestModel;
using Commons.ViewModel;

namespace ApplicationLibrary.Models.Students
{
    public class StudentRequestModel : RequestModel<Student>
    {
        public StudentRequestModel(string keyword="", string orderBy="Modified", string isAscending="false") : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Student, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword) || x.Phone.ToLower().Contains(Keyword);
            }
            if (ParentId.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.DepartmentId == ParentId);
            }
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }
 
        public override Expression<Func<Student, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel(x.Id, x.Name);
        }

        public override IQueryable<Student> IncludeParents(IQueryable<Student> students)
        {
            return students.Include(x => x.Department).AsQueryable();
        }
    }
}