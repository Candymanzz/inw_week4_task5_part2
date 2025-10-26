using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Task.Db.Converters
{
    public static class Converters
    {
        public static readonly ValueConverter<DateOnly, DateTime> DateOnlyToDateTimeConverter = new ValueConverter<DateOnly, DateTime>(
            d => d.ToDateTime(TimeOnly.MinValue),
            dt => DateOnly.FromDateTime(dt));
    }
}
