using Domain.Common;
using System.ComponentModel;

namespace Infrastructure.Extentions;

public static class EnumExtensions {

    
    private static T GetAttribute<T>(this Province? value) where T : Attribute {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0
          ? (T)attributes[0]
          : null;
    }

    
    public static string GetDescription(this Province? value) {
        var attribute = value.GetAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

}


