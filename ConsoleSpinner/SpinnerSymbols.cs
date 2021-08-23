using System.Collections.Generic;
using System.Linq;

namespace ConsoleSpinner
{
    internal static class SpinnerSymbols
    {
        public static string Blank => '\u2800'.ToString();

        public static IEnumerable<char> Get(SpinnerType spinnerType)
        {
            // https://www.unicode.org/charts/PDF/U2800.pdf
            return spinnerType switch
            {
                SpinnerType.OneDot                  => new[] { '\u2804', '\u2802', '\u2801', '\u2808', '\u2810', '\u2820', '\u2880', '\u2840' },
                SpinnerType.OneDotReverse           => Get(SpinnerType.OneDot).Reverse(),
                SpinnerType.TwoDot                  => new[] { '\u2806', '\u2803', '\u2809', '\u2818', '\u2830', '\u28A0', '\u28C0', '\u2844' },
                SpinnerType.TwoDotReverse           => Get(SpinnerType.TwoDot).Reverse(),
                SpinnerType.ThreeDot                => new[] { '\u2846', '\u2807', '\u280B', '\u2819', '\u2838', '\u28B0', '\u28E0', '\u28C4' },
                SpinnerType.ThreeDotReverse         => Get(SpinnerType.ThreeDot).Reverse(),
                SpinnerType.FourDot                 => new[] { '\u2847', '\u280F', '\u281B', '\u2839', '\u28B8', '\u28F0', '\u28E4', '\u28C6' },
                SpinnerType.FourDotReverse          => Get(SpinnerType.FourDot).Reverse(),
                SpinnerType.FiveDot                 => new[] { '\u284F', '\u281F', '\u283B', '\u28B9', '\u28F8', '\u28F4', '\u28E6', '\u28C7' },
                SpinnerType.FiveDotReverse          => Get(SpinnerType.FiveDot).Reverse(),
                SpinnerType.SixDot                  => new[] { '\u28CF', '\u285F', '\u283F', '\u28BB', '\u28F9', '\u28FC', '\u28F6', '\u28E7' },
                SpinnerType.SixDotReverse           => Get(SpinnerType.SixDot).Reverse(),
                SpinnerType.SevenDot                => new[] { '\u28FE', '\u28F7', '\u28EF', '\u28DF', '\u287F', '\u28BF', '\u28FB', '\u28FD' },
                SpinnerType.SevenDotReverse         => Get(SpinnerType.SevenDot).Reverse(),
                SpinnerType.OneDotSnake             => new[] { '\u2801', '\u2808', '\u2810', '\u2802', '\u2804', '\u2820', '\u2880', '\u2840', '\u2804', '\u2820', '\u2810', '\u2802' },
                SpinnerType.TwoDotSnake             => new[] { '\u2809', '\u2818', '\u2812', '\u2806', '\u2824', '\u28A0', '\u28C0', '\u2844', '\u2824', '\u2830', '\u2812', '\u2803' },
                SpinnerType.InverseOneDotSnake      => new[] { '\u28FE', '\u28F7', '\u28EF', '\u28FD', '\u28FB', '\u28DF', '\u287F', '\u28BF', '\u28FB', '\u28DF', '\u28EF', '\u28FD' },
                SpinnerType.InverseTwoDotSnake      => new[] { '\u28F6', '\u28E7', '\u28ED', '\u28F9', '\u28DB', '\u285F', '\u283F', '\u28BB', '\u28DB', '\u28CF', '\u28ED', '\u28FC' },
                SpinnerType.AlternatingX            => new[] { '\u28A3', '\u28A3', '\u28A3', '\u28A3', '\u285C', '\u285C', '\u285C', '\u285C' },
                SpinnerType.AlternatingCorners      => new[] { '\u2881', '\u2881', '\u2881', '\u2881', '\u2848', '\u2848', '\u2848', '\u2848' },
                SpinnerType.RotatingCorners         => new[] { '\u2848', '\u2814', '\u2822', '\u2881' },
                SpinnerType.RotatingCornersReverse  => Get(SpinnerType.RotatingCorners).Reverse(),
                SpinnerType.PulsingCorners          => new[] { '\u2881', '\u2822', '\u2814', '\u2848', '\u2814', '\u2822' },
                SpinnerType.PulsingBox              => new[] { '\u28C9', '\u28C9', '\u28C9', '\u28C9', '\u2836', '\u2836', '\u2836', '\u2836' },
                SpinnerType.Blinking                => new[] { '\u2800', '\u2800', '\u2800', '\u2800', '\u28FF', '\u28FF', '\u28FF', '\u28FF' },
                _                                   => new[] { '\u2800' } // blank
            };
        }
    }
}
