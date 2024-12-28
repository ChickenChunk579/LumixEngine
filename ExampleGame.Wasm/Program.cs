using ExampleGame;
using System;
using System.Runtime.InteropServices.JavaScript;

public partial class Program
{
    [JSImport("setMainLoop", "main.js")]
    internal static partial void SetMainLoop([JSMarshalAs<JSType.Function>] Action cb);

    public static void Main(string[] args)
    {
        Console.WriteLine("Running in WASM");

        SetMainLoop(new Game1().RunWebAssembly);
    }
}