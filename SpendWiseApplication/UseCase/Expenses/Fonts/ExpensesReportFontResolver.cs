using System.Reflection;
using PdfSharp.Charting;
using PdfSharp.Fonts;

namespace SpendWise.Application.UseCase.Expenses.Fonts
{
    public class ExpensesReportFontResolver : IFontResolver
    {
        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            new Font
            {
                Name = "Worksans-Regular",
            };
           return new FontResolverInfo(familyName, bold, italic);
        }

        public byte[]? GetFont(string faceName)
        {
            var stream = ReadFontFile(faceName);

            stream ??= ReadFontFile(FontHelper.DEFAULT_FONT);

            var lenght = (int)stream!.Length;
            var data = new byte[lenght];
            stream.Read(buffer: data, offset: 0, count: lenght);

            return data;
        }

        private Stream? ReadFontFile(string fontName)
        {
           var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetManifestResourceStream($"SpendWise.Application.UseCase.Expenses.Fonts.{fontName}.ttf");
        }
    }
}
