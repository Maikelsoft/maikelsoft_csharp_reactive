@echo off

echo Creating directories...
mkdir NuGet\lib\net6.0

echo Copying .NET libraries...
copy Maikelsoft.Reactive\bin\Release\net6.0\*.dll NuGet\lib\net6.0\
copy Maikelsoft.Reactive\bin\Release\net6.0\*.xml NuGet\lib\net6.0\

echo Building NuGet package...
NuGet.exe pack NuGet\Maikelsoft.Reactive.nuspec -OutputDirectory C:\Development\nuget_packages

pause
