using System;
using System.Linq.Expressions;
using Commons.RequestModel;

namespace ApplicationLibrary.Models.Departments
{
    public class DepartmentRequestModel : RequestModel<Department>
    {
        public DepartmentRequestModel(string keyword, string orderBy = "Modified", string isAscending="false") : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Department, bool>> GetExpression()
        {
            // by which property we want to query on this table? 
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }
    }
}