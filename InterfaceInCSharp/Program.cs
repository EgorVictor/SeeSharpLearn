using System;
using InterfaceInCSharp;
using InterfaceInCSharp.Service;


Console.WriteLine("Testing the overhead light");
var overhead = new OverheadLight();
await Test.TestLightCapabilities(overhead);
Console.WriteLine();

Console.WriteLine("Testing the halogen light");
var halogen = new HalogenLight();
await Test.TestLightCapabilities(halogen);
Console.WriteLine();

Console.WriteLine("Testing the LED light");
var led = new LEDLight();
await Test.TestLightCapabilities(led);
Console.WriteLine();

Console.WriteLine("Testing the fancy light");
var fancy = new ExtraFancyLight();
await Test.TestLightCapabilities(fancy);
Console.WriteLine();

