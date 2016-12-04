using System;
using Commons.Model;
using Commons.Repository;

namespace ConsumerWinFormsApp
{
    public static class Constants
    {
        public static string UserName { get; set; }

        public static void SetCommonValues(this Entity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            entity.CreatedBy = Constants.UserName;
            entity.ModifiedBy = Constants.UserName;
        }
    }
}