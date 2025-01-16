## Basic Types related
* `var x` - sometheing like auto.
* `System.Convert` - everything from basic type could be converted to other basic types.
### Strings
* `@"text"` - Verbatim strings, raw string just text without escape sequence.
* `$$"text with {{x}}` - Interpolated, $$ means how many {{ should be for variable.
### Floating points
They have got IsInfinity and etc. So its possible to use it with higher math's uncertainties.
* `decimal z` - introduced, 16 bytes represents as int.
### Int
* `Int16, Int32, Int64, Int128 and etc` - Just addition to int with new ranges. Like long, long long and etc.
### Array
* `string[,] grid` - Two (or more) dimensinal array like `new int[5][4]`.
* `string [][] jag` - Its like put in array another array. Like a `int[3] = new int[5]`.
* Pattern matchings - like [], [..] and etc (C# 11).


## Memory
### new
Could be used with type or without - `Person pers = new()` and `Person pers = new Person();` Both right.


## Attributes
### [Flag]
Before enum will make it like an ordinal enum from C++. Use it for bitwise operations. Better to use enums with byte like: `public enum Vals : byte` and with each val go through the byte range 0 to 128 (256 not included). 

## Operators
* `x ?? 30` or `x ??= 30` - Null-coalescing. Means if input null accept as value following.
* `nameof()` - returns name of a var.
* `var? x` - signaling that x - a nullable type and need to handle null exceptions on ur own.
* `name!.Length` - Null forgiving. Means no more warnings about nullable varibale.

## Keywords
### Pre-Code
* `using static System.Console` - like `using namespace std`.
### Functions && Params
* `x is int i` - Check if x is int then assign to variable i.
* `x = z switch { z == 4 => doSmth() }` - Switch without using break and case. Also `_` - default statemet. C++ switch could be used too (C# 8).
* `foreach(var z in variables)` - range loop, like `for(const auto& z : varibales)`. IEnumerable need to be omplemented for the used type.
* `in` and `out` - `in` in C++ is `(const int value)` and C# dont support const in params, `out` - reuired output param in C++ is `(int &val)` , but not required.
### Exceptions
* `checked {}` - Causing runtime exceptions related to overflow to be thrown. `unchecked {}` - opposive, disable compile time checks.
### Access modificators
* `public` - YEAH, its a bit different. Here it is like dllexported public function in C++.
* `internal` - Public within same assembly. It is just public function not accesible using LoadLibrary. Classic public.
* `private` - Only same class within same assembly.
* `protected` - Same class and the derived classes from other assemblies.
* `protected internal` - Ist like protected + internal, Class + Derived for other assemblies, but not other classes in other asseblies
* `file` - type could be used within its .cs file. Use it when there are multiple classes in .cs and you need them to wrok all with each other (.NET 7).
### Class related
* `record Program` - immutable value based (not ref) structure. Used for Data modeling. Basicly its a struct with const params with only initializing. Supports equlity checks with `==`.
* `abstract class Program` - Interface. Like having a pure virtual functions in class.
* `partial class Program` - just like header files, but function are inlined in it.
### Field related
* `required` - must have params of the class when initialising. In C++ its basicly constructors' work (C# 11).
* `get; set;` - Getters and setters. Also can be used with lambdas. Also could be `init` means only one setting works great with `record`(C# 9).
* `public Preson this[int index]` - Indexers, use in a pair with get and set. In C++ using with overloading `[]` operator.

## Generics (Data structrues)
All these stuff is like stl, mfc types.
### List
`List<T>`
Data Structure: Array
C++: std::vector

## Features
### Less {} for using and namspace (C# 10)
You allowed not to put all the code in brackets for `using` and `namespace`.
### Tuples
`public (string Name, int Number) doSmth(){}` - like a std::tuple but syntax is different.
### Pattern Mathcing (C# 8)
Allows to feed the pattern in order to get what you want to find in value or class. In classes used with keyword `when` and switch statements like:
```cs
foreach (Passenger passenger in passengers)
{
  int out = passenger switch
  {
    FirstClassPass p when p.AirMiles > 35000 => 140, // C# 8
    ...
    // Or C# 9:
    FirstClassPass p => p.AirMiles switch
    {
      > 35000 => 140
      ...
    }
    ...
  }
}
```