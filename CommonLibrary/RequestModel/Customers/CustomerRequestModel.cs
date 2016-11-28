using System;
using System.Linq.Expressions;
using Model.Customers;

namespace RequestModel.Customers
{
    public class CustomerRequestModel : RequestModel<Customer>
    {
        public CustomerRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Customer, bool>> GetExpression()
        {
          
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword) || x.HouseNo.ToLower().Contains(Keyword) || x.RoadNo.ToLower().Contains(Keyword) || x.Area.ToLower().Contains(Keyword) || x.Thana.ToLower().Contains(Keyword) || x.District.ToLower().Contains(Keyword) || x.Country.ToLower().Contains(Keyword) || x.Phone.ToLower().Contains(Keyword) || x.Email.ToLower().Contains(Keyword);
            }
            ExpressionObj = ExpressionObj
                .And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        
    }
}