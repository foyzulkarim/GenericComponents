namespace Commons.RequestModel
{
    using System.Linq.Expressions;

    public class ReplaceExpressionVisitor
        : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            this._oldValue = oldValue;
            this._newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            if (node == this._oldValue)
                return this._newValue;
            return base.Visit(node);
        }
    }
}