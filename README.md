This document covers following aspects of code build and run in C#. 

* [Build](#build)
* [Unit tests](#unit-tests)

# Supported Versions

* 3.1

# Build

A. Visual Studio 2019

- Load Application using "SEDOL.Checker.sln" in Visual Studio 2019.
- Build application
```
 Build >> Build Solution (Ctrl+Shift+B)
```
- Run application
```
  Press F5
```

 B. CMD

 - Open CMD
 - Go till "SEDOL.Checker" folder
 ```
  cd SEDOL.Checker
 ```
 - Build Application
 ```
  dotnet build -o SEDOL.Checker
 ```
- Run Application
```
 dotnet SEDOL.Checker/SEDOL.Checker.dll
```

It will show following text:

```
----------------- Welcome To SEDOL Checker --------------


Please provide SEDOL to validate.

```

Please type any SEDOL code to validate
```
 9123458
```
It will validate and show output like
```
InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
---|--|--|--|
9123458|True|True|Null
```
Then it will ask to continue to valdiate again yes or no (y/n)
```
Do you wish to validate another SEDOL? (y/n)
```

Type "y" to continue else tpye "n" or any key other than "y"

--------------------------------------------------------

# Unit tests

To execute the test cases go to path 
```
 cd SEDOL.Service.Tests
```
Run following command to execute Test Cases

```
dotnet test
```
It will show following text after executing test cases
```
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    15, Skipped:     0, Total:    15, Duration: 11 ms - SEDOL.Service.Tests.dll (netcoreapp3.1)
```

For calculating the coverage we run the command

```
dotnet test --collect="XPlat Code Coverage"
```
It will show following output
```
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Attachments:
  D:\study\code\SEDOL\SEDOL.Service.Tests\TestResults\326cde9e-2615-4561-8a70-f28d8d4488ba\coverage.cobertura.xml
Passed!  - Failed:     0, Passed:    15, Skipped:     0, Total:    15, Duration: 14 ms - SEDOL.Service.Tests.dll (netcoreapp3.1)
```
Test coverage file will create under following path
```
SEDOL.Service.Tests\TestResults\326cde9e-2615-4561-8a70-f28d8d4488ba\coverage.cobertura.xml
```