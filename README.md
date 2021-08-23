A console spinner, inspired by [this tweet](https://twitter.com/dmagliola/status/1429124567109357577).

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
