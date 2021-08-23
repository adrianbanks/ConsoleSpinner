using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleSpinner
{
    internal static class SpinnerSymbols
    {
        public static string Blank => '\u2800'.ToString();

        public static ICollection<string> Get(SpinnerType spinnerType)
        {
            return GetHexCodes(spinnerType)
                .Select(code => code.ToString("X"))
                .Select(code => int.Parse(code, NumberStyles.HexNumber))
                .Select(char.ConvertFromUtf32)
                .ToList();
        }

        private static IEnumerable<int> GetHexCodes(SpinnerType spinnerType)
        {
            return spinnerType switch
            {
                SpinnerType.OneDot                 => new[] { 10244, 10242, 10241, 10248, 10256, 10272, 10368, 10304 },
                SpinnerType.OneDotReverse          => GetHexCodes(SpinnerType.OneDot).Reverse(),
                SpinnerType.TwoDot                 => new[] { 10246, 10243, 10249, 10264, 10288, 10400, 10432, 10308 },
                SpinnerType.TwoDotReverse          => GetHexCodes(SpinnerType.TwoDot).Reverse(),
                SpinnerType.ThreeDot               => new[] { 10310, 10247, 10251, 10265, 10296, 10416, 10464, 10436 },
                SpinnerType.ThreeDotReverse        => GetHexCodes(SpinnerType.ThreeDot).Reverse(),
                SpinnerType.FourDot                => new[] { 10311, 10255, 10267, 10297, 10424, 10480, 10468, 10438 },
                SpinnerType.FourDotReverse         => GetHexCodes(SpinnerType.FourDot).Reverse(),
                SpinnerType.FiveDot                => new[] { 10319, 10271, 10299, 10425, 10488, 10484, 10470, 10439 },
                SpinnerType.FiveDotReverse         => GetHexCodes(SpinnerType.FiveDot).Reverse(),
                SpinnerType.SixDot                 => new[] { 10447, 10335, 10303, 10427, 10489, 10492, 10486, 10471 },
                SpinnerType.SixDotReverse          => GetHexCodes(SpinnerType.SixDot).Reverse(),
                SpinnerType.SevenDot               => new[] { 10494, 10487, 10479, 10463, 10367, 10431, 10491, 10493 },
                SpinnerType.SevenDotReverse        => GetHexCodes(SpinnerType.SevenDot).Reverse(),
                SpinnerType.OneDotSnake            => new[] { 10241, 10248, 10256, 10242, 10244, 10272, 10368, 10304, 10244, 10272, 10256, 10242 },
                SpinnerType.TwoDotSnake            => new[] { 10249, 10264, 10258, 10246, 10276, 10400, 10432, 10308, 10276, 10288, 10258, 10243 },
                SpinnerType.InverseOneDotSnake     => new[] { 10494, 10487, 10479, 10493, 10491, 10463, 10367, 10431, 10491, 10463, 10479, 10493 },
                SpinnerType.InverseTwoDotSnake     => new[] { 10486, 10471, 10477, 10489, 10459, 10335, 10303, 10427, 10459, 10447, 10477, 10492 },
                SpinnerType.AlternatingX           => new[] { 10403, 10403, 10403, 10403, 10332, 10332, 10332, 10332 },
                SpinnerType.AlternatingCorners     => new[] { 10369, 10369, 10369, 10369, 10312, 10312, 10312, 10312 },
                SpinnerType.RotatingCorners        => new[] { 10312, 10260, 10274, 10369 },
                SpinnerType.RotatingCornersReverse => GetHexCodes(SpinnerType.RotatingCorners).Reverse(),
                SpinnerType.PulsingCorners         => new[] { 10369, 10274, 10260, 10312, 10260, 10274 },
                SpinnerType.PulsingBox             => new[] { 10441, 10441, 10441, 10441, 10294, 10294, 10294, 10294 },
                SpinnerType.Blinking               => new[] { 10240, 10240, 10240, 10240, 10495, 10495, 10495, 10495 },
                _                                  => new[] { 10240 } // blank
            };
        }
    }
}
