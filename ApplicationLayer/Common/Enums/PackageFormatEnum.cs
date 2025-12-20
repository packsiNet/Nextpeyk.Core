using Ardalis.SmartEnum;

namespace ApplicationLayer.Common.Enums;

public sealed class PackageFormatEnum : SmartEnum<PackageFormatEnum>
{
    #region Fields

    public static PackageFormatEnum Envelope = new(1, "پاکت", nameof(Envelope));

    public static PackageFormatEnum Box = new(2, "جعبه", nameof(Box));

    #endregion Fields

    #region Methods

    #region Constructors

    public string PersianName { get; }

    public string EnglishName { get; }

    private PackageFormatEnum(int id, string persianName, string englishName) : base(englishName, id)
    {
        PersianName = persianName;
        EnglishName = englishName;
    }

    #endregion Constructors

    #endregion Methods
}