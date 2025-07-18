﻿namespace AuroraControls;

internal sealed class SKTextRun
{
    private const string IconTemplateBegin = "{{";
    private const string IconTemplateEnd = "}}";

    public SKTextRun(string text) => Text = text;

    public string Text { get; }

    public SKTypeface Typeface { get; set; }

    public SKPoint Offset { get; set; }

    public float? FontSize { get; set; }

    public SKColor? Color { get; set; }

    public override string ToString() => Text;

    public static IEnumerable<SKTextRun> Create(string text, SKTextRunLookup lookup, bool toUppercase = false)
    {
        var runs = new List<SKTextRun>();

        if (string.IsNullOrEmpty(text))
        {
            return runs;
        }

        int start = 0;

        while (start < text.Length)
        {
            int startIndex = text.IndexOf(IconTemplateBegin, start, StringComparison.Ordinal);

            if (startIndex == -1)
            {
                break;
            }

            int endIndex = text.IndexOf(IconTemplateEnd, startIndex, StringComparison.Ordinal);

            if (endIndex == -1)
            {
                break;
            }

            string pre = text.Substring(start, startIndex - start);

            string expression = text.Substring(startIndex + IconTemplateBegin.Length, endIndex - startIndex - IconTemplateEnd.Length);
            string[] segments = expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            SKColor? color = null;
            float? fontSize = null;

            foreach (string item in segments)
            {
                string[] pair = item.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                switch (pair[0].ToLower())
                {
                    case "color":
                        if (pair.Length > 1 && !string.IsNullOrWhiteSpace(pair[1]))
                        {
                            color = SKColor.Parse(pair[1]);
                        }

                        break;
                    case "font-size":
                        if (pair.Length > 1 && !string.IsNullOrWhiteSpace(pair[1]))
                        {
                            fontSize = float.TryParse(pair[1], out float parsedFontSize) ? parsedFontSize : default(float?);
                        }

                        break;
                }
            }

            if (!string.IsNullOrEmpty(pre))
            {
                runs.Add(new SKTextRun(pre));
            }

            var typefaceStyle = new Topten.RichTextKit.Style { FontFamily = segments[0] };
            var typeface = FontCache.Instance.TypefaceFromStyle(typefaceStyle, false);

            uint intVal = Convert.ToUInt32(segments[1], 16);
            string converted = Convert.ToChar(intVal).ToString();

            runs.Add(
                new SKTextRun(converted)
                {
                    Typeface = typeface,
                    Color = color,
                    FontSize = fontSize,
                });

            start = endIndex + IconTemplateEnd.Length;
        }

        if (start < text.Length)
        {
            runs.Add(new SKTextRun(toUppercase ? text.Substring(start).ToUpperInvariant() : text.Substring(start)));
        }

        return runs;
    }
}
