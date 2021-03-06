A console spinner, inspired by [this tweet](https://twitter.com/dmagliola/status/1429124567109357577).

![An example using the pulsing corners spinner](example.gif)

## Example usage

### Asynchronous

```csharp
var spinner = new ConsoleSpinner(SpinnerType.PulsingCorners);

Console.Write("Loading");

// the spinner will spin until the cancellationToken is cancelled
await spinner.WriteAsync(cancellationToken);
```

### Synchronous

```csharp
var spinner = new ConsoleSpinner(SpinnerType.PulsingCorners);

Console.Write("Loading");

// the spinner will spin until the cancellationToken is cancelled
spinner.Write(cancellationToken);
```

## Available spinner types

(Run `ConsoleSpinner.Demo` to see them all in action)

- OneDot
- OneDotReverse
- TwoDot
- TwoDotReverse
- ThreeDot
- ThreeDotReverse
- FourDot
- FourDotReverse
- FiveDot
- FiveDotReverse
- SixDot
- SixDotReverse
- SevenDot
- SevenDotReverse
- OneDotSnake
- TwoDotSnake
- InverseOneDotSnake
- InverseTwoDotSnake
- AlternatingX
- AlternatingCorners
- RotatingCorners
- RotatingCornersReverse
- PulsingCorners
- PulsingBox
- Blinking
