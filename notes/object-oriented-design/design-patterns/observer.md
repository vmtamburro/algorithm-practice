The Observer Pattern is a behavioral design pattern where an object (known as the subject) maintains a list of its dependents (observers) and notifies them automatically of any state changes, usually by calling one of their methods. This pattern is used when there is a one-to-many relationship between objects, and changes to one object (the subject) need to be reflected in other objects (the observers) without them being tightly coupled.

### Example of Observer Pattern:

Let's consider an example of a weather monitoring system where multiple displays need to show real-time updates of weather data whenever it changes.

#### Step 1: Define the Subject Interface

```csharp
// Subject Interface: WeatherStation
public interface IWeatherStation
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

#### Step 2: Implement the Concrete Subject

```csharp
// Concrete Subject: WeatherData
public class WeatherData : IWeatherStation
{
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }

    private void MeasurementsChanged()
    {
        NotifyObservers();
    }
}
```

#### Step 3: Define the Observer Interface

```csharp
// Observer Interface: IObserver
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}
```

#### Step 4: Implement Concrete Observers

```csharp
// Concrete Observer 1: CurrentConditionsDisplay
public class CurrentConditionsDisplay : IObserver
{
    private float temperature;
    private float humidity;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
    }
}

// Concrete Observer 2: ForecastDisplay
public class ForecastDisplay : IObserver
{
    private float pressure;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.pressure = pressure;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Forecast: Pressure is {pressure}");
    }
}
```

#### Step 5: Client Code to Use the Observer Pattern

```csharp
public class Client
{
    public static void Main(string[] args)
    {
        // Create a weather station
        WeatherData weatherData = new WeatherData();

        // Create observers
        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();
        ForecastDisplay forecastDisplay = new ForecastDisplay();

        // Register observers with the weather station
        weatherData.AddObserver(currentDisplay);
        weatherData.AddObserver(forecastDisplay);

        // Simulate new weather measurements
        weatherData.SetMeasurements(80, 65, 30.4f);

        // Output:
        // Current conditions: 80F degrees and 65% humidity
        // Forecast: Pressure is 30.4
    }
}
```

### Explanation:

- **Subject (`WeatherData`)**: Maintains a list of observers (`IObserver` objects) and notifies them of changes in weather measurements (`temperature`, `humidity`, `pressure`) by calling their `Update` method.
- **Observer (`IObserver`)**: Defines an interface for objects that should be notified of changes in the subject (`Update` method).
- **Concrete Observers (`CurrentConditionsDisplay`, `ForecastDisplay`)**: Implement the `IObserver` interface to receive updates from the subject (`WeatherData`) and display weather information (`CurrentConditionsDisplay` shows current temperature and humidity, `ForecastDisplay` shows pressure forecast).
- **Client Code (`Main` method)**: Demonstrates how the Observer Pattern decouples the subject (`WeatherData`) from its observers (`CurrentConditionsDisplay`, `ForecastDisplay`), allowing new display modules to be added or removed dynamically without modifying the subject.

### Benefits of Observer Pattern:

- **Loose Coupling**: Subject and observers are loosely coupled; they can interact without needing to know much about each other.
- **Supports Broadcast Communication**: Allows one subject to notify multiple observers simultaneously.
- **Dynamic Relationship**: Observers can be added or removed at runtime, allowing for dynamic change in the number and types of observers.

The Observer Pattern is commonly used in GUI frameworks, event handling systems, and any scenario where multiple objects need to react to changes in another object's state.