using System.Reflection;

namespace Api.MusicNotes._5___Config._5___Config_Enum
{
	public static class EnumExtensions
	{
		public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
		{
			FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

			if (fieldInfo.GetCustomAttribute(typeof(EnumDescriptionAttribute)) is EnumDescriptionAttribute attribute)
			{
				return attribute.Description;
			}

			return enumValue.ToString();
		}
	}
}
