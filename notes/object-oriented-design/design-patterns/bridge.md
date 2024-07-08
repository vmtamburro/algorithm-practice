The Bridge Pattern is a structural design pattern that decouples an abstraction from its implementation so that both can vary independently. It is useful when there are multiple dimensions of variation in a system, and it provides flexibility by allowing hierarchies to evolve independently.

### Example of Bridge Pattern:

Let's consider a scenario where we have a `Shape` abstraction and two different implementations (`DrawingAPI1` and `DrawingAPI2`) for drawing these shapes on different platforms (e.g., using different rendering engines).

#### Step 1: Define the Abstraction and Implementor Interfaces

```csharp
// Abstraction: Shape
public abstract class Shape
{
    protected IDrawingAPI drawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        this.drawingAPI = drawingAPI;
    }

    public abstract void Draw(); // Abstract method to be implemented by concrete shapes
}

// Implementor: IDrawingAPI interface
public interface IDrawingAPI
{
    void DrawCircle(int x, int y, int radius);
    void DrawRectangle(int x1, int y1, int x2, int y2);
}

// Concrete Implementor 1: DrawingAPI1
public class DrawingAPI1 : IDrawingAPI
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"DrawingAPI1: Circle at ({x}, {y}) with radius {radius}");
    }

    public void DrawRectangle(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"DrawingAPI1: Rectangle from ({x1}, {y1}) to ({x2}, {y2})");
    }
}

// Concrete Implementor 2: DrawingAPI2
public class DrawingAPI2 : IDrawingAPI
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"DrawingAPI2: Circle at ({x}, {y}) with radius {radius}");
    }

    public void DrawRectangle(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"DrawingAPI2: Rectangle from ({x1}, {y1}) to ({x2}, {y2})");
    }
}
```

#### Step 2: Implement Abstraction and Use the Bridge Pattern

```csharp
// Refined Abstraction: Circle
public class Circle : Shape
{
    private int x, y, radius;

    public Circle(int x, int y, int radius, IDrawingAPI drawingAPI) : base(drawingAPI)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawingAPI.DrawCircle(x, y, radius);
    }
}

// Refined Abstraction: Rectangle
public class Rectangle : Shape
{
    private int x1, y1, x2, y2;

    public Rectangle(int x1, int y1, int x2, int y2, IDrawingAPI drawingAPI) : base(drawingAPI)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public override void Draw()
    {
        drawingAPI.DrawRectangle(x1, y1, x2, y2);
    }
}

// Client Code
public class Client
{
    public static void Main(string[] args)
    {
        // DrawingAPI1
        IDrawingAPI drawingAPI1 = new DrawingAPI1();
        Shape circle1 = new Circle(1, 2, 3, drawingAPI1);
        Shape rectangle1 = new Rectangle(2, 3, 4, 5, drawingAPI1);

        circle1.Draw();
        rectangle1.Draw();

        // DrawingAPI2
        IDrawingAPI drawingAPI2 = new DrawingAPI2();
        Shape circle2 = new Circle(5, 6, 7, drawingAPI2);
        Shape rectangle2 = new Rectangle(4, 5, 6, 7, drawingAPI2);

        circle2.Draw();
        rectangle2.Draw();
    }
}
```

### Explanation:

- **Abstraction (`Shape`)**: Defines the interface for the shape objects (`Draw()` method).
- **Implementor (`IDrawingAPI`)**: Defines the interface for the implementation classes (`DrawCircle()` and `DrawRectangle()` methods).
- **Concrete Implementors (`DrawingAPI1` and `DrawingAPI2`)**: Provide specific implementations of the `IDrawingAPI` interface.
- **Refined Abstractions (`Circle` and `Rectangle`)**: Extend the `Shape` abstraction and use the `IDrawingAPI` interface to draw circles and rectangles.
- **Client Code (`Main` method)**: Demonstrates how the bridge pattern allows the client to use different implementations of `IDrawingAPI` (`DrawingAPI1` and `DrawingAPI2`) interchangeably with `Circle` and `Rectangle` objects, without modifying the shape classes.

The Bridge Pattern promotes loose coupling between abstraction and implementation, allowing both to vary independently. It's particularly useful in scenarios where multiple orthogonal variations exist in a system, such as different platforms or devices for rendering.