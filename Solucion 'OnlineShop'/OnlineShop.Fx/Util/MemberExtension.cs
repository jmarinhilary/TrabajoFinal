using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Fx.Util
{
    public static class MemberExtension
    {
        public static string GetMemberName(this LambdaExpression expr)
        {
            var lexpr = expr;
            MemberExpression mexpr = null;
            if (lexpr.Body is MemberExpression)
            {
                mexpr = (MemberExpression)lexpr.Body;
            }
            else if (lexpr.Body is UnaryExpression)
            {
                mexpr = (MemberExpression)((UnaryExpression)lexpr.Body).Operand;
            }
            if (mexpr == null)
            {
                return null;
            }
            return mexpr.Member.Name;
        }

        public static string GetDisplayName<TModel>(string propertyName)
        {
            Type type = typeof(TModel);
            // First look into attributes on a type and it's parents
            DisplayAttribute attr;
            attr = (DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
            // Look for [MetadataType] attribute in type hierarchy
            if (attr == null)
            {
                MetadataTypeAttribute metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null)
                    {
                        attr = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.Name : propertyName;
        }

        public static string GetDisplayName<TModel>(Expression<Func<TModel, object>> expression)
        {
            Type type = typeof(TModel);

            string propertyName = expression.GetMemberName();
            // First look into attributes on a type and it's parents
            DisplayAttribute attr;
            attr = (DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
            // Look for [MetadataType] attribute in type hierarchy
            if (attr == null)
            {
                MetadataTypeAttribute metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null)
                    {
                        attr = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.Name : propertyName;
        }

        public static bool GetReguiredAttr<TModel>(string propertyName)
        {
            Type type = typeof(TModel);
            //MemberExpression memberExpression = (MemberExpression)expression.Body;
            //string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);
            // First look into attributes on a type and it's parents
            RequiredAttribute attr;
            attr = (RequiredAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(RequiredAttribute), true).SingleOrDefault();
            return (attr != null) ? true : false;
        }
    }
}
