using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Commons.Model;
using Commons.ViewModel;

namespace Commons.RequestModel
{
    public class OrderByRequest
    {
        public string PropertyName { get; set; }
        public bool IsAscending { get; set; }
    }


    public abstract class RequestModel<TModel> where TModel : Entity
    {
        protected Expression<Func<TModel, bool>> ExpressionObj = e => true;

        protected RequestModel(string keyword, string orderBy = "Modified", string isAscending = "False")
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            Page = 1;
            Keyword = keyword.ToLower();
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy;
            }
            if (!string.IsNullOrWhiteSpace(isAscending))
            {
                IsAscending = isAscending;
            }

            Request = new OrderByRequest
                          {
                              PropertyName = string.IsNullOrWhiteSpace(OrderBy) ? "Modified" : OrderBy,
                              IsAscending = IsAscending == "True"
                          };
        }

        public string OrderBy { get; set; }
        public string IsAscending { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PerPageCount => 10;
        public int Page { get; set; }
        public List<string> Tables { get; set; }
        public string Id { get; set; }
        public OrderByRequest Request { get; }
        public string Keyword { get; set; }
        public string ParentId { get; set; }
        public string ShopId { get; set; }

        protected Func<IQueryable<TSource>, IOrderedQueryable<TSource>> OrderByFunc<TSource>()
        {
            string propertyName = Request.PropertyName;
            bool ascending = Request.IsAscending;
            var source = Expression.Parameter(typeof(IQueryable<TSource>), "source");
            var item = Expression.Parameter(typeof(TSource), "item");
            var member = Expression.Property(item, propertyName);
            var selector = Expression.Quote(Expression.Lambda(member, item));
            var body = Expression.Call(
                typeof(Queryable), @ascending ? "OrderBy" : "OrderByDescending",
                new[] { item.Type, member.Type },
                source, selector);
            var expr = Expression.Lambda<Func<IQueryable<TSource>, IOrderedQueryable<TSource>>>(body, source);
            var func = expr.Compile();
            return func;
        }

        protected abstract Expression<Func<TModel, bool>> GetExpression();
        public virtual IQueryable<TModel> IncludeParents(IQueryable<TModel> queryable)
        {
            return queryable;
        }

        public abstract Expression<Func<TModel, DropdownViewModel>> Dropdown();

        public IQueryable<TModel> GetOrderedData(IQueryable<TModel> queryable)
        {
            queryable = queryable.Where(GetExpression());
            queryable = OrderByFunc<TModel>()(queryable);
            return queryable;
        }

        public IQueryable<TModel> SkipAndTake(IQueryable<TModel> queryable)
        {
            if (Page != -1)
            {
                queryable = queryable.Skip((Page - 1) * PerPageCount).Take(PerPageCount);
            }

            return queryable;
        }

        public IQueryable<TModel> GetData(IQueryable<TModel> queryable)
        {
            return queryable.Where(GetExpression());
        }

        public TModel GetFirstData(IQueryable<TModel> queryable)
        {
            return queryable.First(GetExpression());
        }

        protected Expression<Func<TModel, bool>> GenerateBaseEntityExpression()
        {
            if (Id.IdIsOk())
            {
                ExpressionObj = ExpressionObj.And(x => x.Id == Id);
            }

            if (StartDate != new DateTime())
            {
                StartDate = StartDate.Date;
                if (EndDate != new DateTime())
                {
                    EndDate = EndDate.Date.AddDays(1).AddMinutes(-1);
                }
                else
                {
                    EndDate = DateTime.Today.Date.AddDays(1).AddMinutes(-1);
                }
                ExpressionObj = ExpressionObj.And(x => x.Modified >= StartDate && x.Modified <= EndDate);
            }

            return ExpressionObj;
        }     
    }
}