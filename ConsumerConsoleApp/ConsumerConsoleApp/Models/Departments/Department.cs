using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Commons.Model;
using Commons.RequestModel;
using Commons.ViewModel;

namespace ConsumerConsoleApp.Models.Departments
{
    public class Department : Entity
    {
        public string Name { get; set; }
    }

    public class DepartmetnViewModel : BaseViewModel<Department>
    {
        public DepartmetnViewModel(Department x) : base(x)
        {
            Name = x.Name;
        }

        public string Name { get; set; }
    }

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
