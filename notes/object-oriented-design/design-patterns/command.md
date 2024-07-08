The Command Pattern is a behavioral design pattern that encapsulates a request as an object, thereby allowing parameterization of clients with different requests, queuing of requests, and logging of requests. It also supports undoable operations.

### Example of Command Pattern:

Let's consider a scenario where we have a remote control that can execute different commands on electronic devices (e.g., turning on/off a television, changing channels, adjusting volume).

#### Step 1: Define the Command Interface

```csharp
// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}
```

#### Step 2: Implement Concrete Command Classes

```csharp
// Concrete Command 1: TurnOnCommand
public class TurnOnCommand : ICommand
{
    private readonly IElectronicDevice device;

    public TurnOnCommand(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        device.TurnOn();
    }

    public void Undo()
    {
        device.TurnOff(); // Assuming TurnOff method exists to undo turning on
    }
}

// Concrete Command 2: TurnOffCommand
public class TurnOffCommand : ICommand
{
    private readonly IElectronicDevice device;

    public TurnOffCommand(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        device.TurnOff();
    }

    public void Undo()
    {
        device.TurnOn(); // Assuming TurnOn method exists to undo turning off
    }
}
```

#### Step 3: Define the Receiver Interface

```csharp
// Receiver Interface
public interface IElectronicDevice
{
    void TurnOn();
    void TurnOff();
}
```

#### Step 4: Implement Concrete Receiver Classes

```csharp
// Concrete Receiver 1: Television
public class Television : IElectronicDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Turning on the Television");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turning off the Television");
    }
}

// Concrete Receiver 2: Radio
public class Radio : IElectronicDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Turning on the Radio");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turning off the Radio");
    }
}
```

#### Step 5: Implement the Invoker (Remote Control)

```csharp
// Invoker: RemoteControl
public class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }

    public void PressUndoButton()
    {
        command.Undo();
    }
}
```

#### Step 6: Client Code to Use the Command Pattern

```csharp
public class Client
{
    public static void Main(string[] args)
    {
        // Create receivers (electronic devices)
        IElectronicDevice tv = new Television();
        IElectronicDevice radio = new Radio();

        // Create commands
        ICommand turnOnTV = new TurnOnCommand(tv);
        ICommand turnOffTV = new TurnOffCommand(tv);
        ICommand turnOnRadio = new TurnOnCommand(radio);
        ICommand turnOffRadio = new TurnOffCommand(radio);

        // Create invoker (remote control)
        RemoteControl remote = new RemoteControl();

        // Set commands on the remote control
        remote.SetCommand(turnOnTV);

        // Press button to execute the command
        remote.PressButton(); // Output: Turning on the Television

        // Set a different command
        remote.SetCommand(turnOffRadio);

        // Press button to execute the command
        remote.PressButton(); // Output: Turning off the Radio

        // Press undo button to revert the last command
        remote.PressUndoButton(); // Output: Turning on the Radio
    }
}
```

### Explanation:

- **Command (`ICommand`)**: Defines the interface for executing and undoing operations.
- **Concrete Commands (`TurnOnCommand`, `TurnOffCommand`)**: Implements specific commands by delegating to the appropriate methods (`TurnOn`, `TurnOff`) of the receiver (`IElectronicDevice`).
- **Receiver (`IElectronicDevice`)**: Defines the interface for all devices that can be controlled (e.g., Television, Radio).
- **Concrete Receivers (`Television`, `Radio`)**: Implements the receiver interface with specific behaviors (`TurnOn`, `TurnOff`).
- **Invoker (`RemoteControl`)**: Issues commands to the receiver through a command interface (`ICommand`).
- **Client Code (`Main` method)**: Demonstrates how the Command Pattern allows decoupling between the sender (remote control) and the receiver (electronic devices). It also supports undoing commands through the `Undo` method defined in `ICommand`.

The Command Pattern promotes loose coupling and separation of concerns by encapsulating requests as objects. It allows requests to be parameterized, queued, logged, and supports undoable operations, making it useful in scenarios where commands need to be issued and executed independently of the context in which they were created.