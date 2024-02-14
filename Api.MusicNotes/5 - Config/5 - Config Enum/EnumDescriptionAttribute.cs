namespace Api.MusicNotes._5___Config._5___Config_Enum
{
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumDescriptionAttribute : Attribute
	{
		public string Description { get; }

		public EnumDescriptionAttribute(string description)
		{
			Description = description;
		}
	}
}