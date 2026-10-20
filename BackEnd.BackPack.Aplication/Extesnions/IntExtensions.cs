using BackEnd.BackPack.Aplication.Exeptions;
using System.ComponentModel;
using static BackEnd.BackPack.Aplication.Helpers.ValidationsHelper;

namespace BackEnd.BackPack.Aplication.Extesnions;

public static class IntExtensions
{
    public static string GetEnumDescription<TEnum>(this int enumValue) where TEnum : Enum
    {
        if (!EnumIsValid<TEnum>(enumValue))
            throw new ApiException(EnumIsNotDefined<TEnum>(enumValue));

        var typeOfEnum = typeof(TEnum);

        var enumName = Enum.GetName(typeOfEnum, enumValue);
        var fieldInfo = typeOfEnum.GetField(enumName);

        var attribute = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                      .Cast<DescriptionAttribute>()
                      .FirstOrDefault();

        return attribute?.Description ?? enumName;
    }

}
