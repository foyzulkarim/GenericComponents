using System;
using System.Linq.Expressions;
using Commons.RequestModel;

namespace ConsumerConsoleApp.Models.Students
{
    public class StudentRequestModel : RequestModel<Student>
    {
        public StudentRequestModel(string keyword, string orderBy="Modified", string isAscending="false") : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Student, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword) || x.Phone.ToLower().Contains(Keyword);
            }
            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }
    }
}