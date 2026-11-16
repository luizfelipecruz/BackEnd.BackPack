using System.ComponentModel;

namespace BackEnd.BackPack.Aplication.Extesnions;

public static class EnumExtension
{
    public static string GetEnumDescription<TEnum>(this TEnum enumValue)
    where TEnum : Enum
    {
        var typeOfEnum = typeof(TEnum);

        var enumName = Enum.GetName(typeOfEnum, enumValue);

        var fieldInfo = typeOfEnum.GetField(enumName!);

        var attribute = fieldInfo?
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .Cast<DescriptionAttribute>()
            .FirstOrDefault();

        return attribute?.Description ?? enumName!;
    }

}
