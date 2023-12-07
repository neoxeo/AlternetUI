# AlterNET UI

AlterNET UI is a cross-platform .NET UI framework that allows the development of light-footprint .NET desktop 
applications that runs on Windows, macOS, and Linux with Microsoft Visual Studio or Visual Studio Code.

It is built on top of the .NET Framework and uses a XAML-like approach to define user interface and layout. 
It provides a set of standard controls that looks native on the target OS, such as Text Box, Label, CheckBox, Button, 
Image, TreeView, ListView, WebBrowser and more.

The framework includes a platform-independent graphic device interface for rendering graphical objects, such as fonts, 
brushes, images, and a layout engine.

For increased developer productivity, 
AlterNET UI [extension](https://marketplace.visualstudio.com/items?itemName=AlternetSoftwarePTYLTD.AlternetUIForVS2022) 
for Visual Studio is available.

## Useful links:

- [Home Page](https://www.alternet-ui.com/)
- [Documentation](https://docs.alternet-ui.com/)
- [Blog](https://www.alternet-ui.com/blog)
- [Forum](https://forum.alternet-ui.com/)

## Download:

- [AlterNET UI NuGet](https://www.nuget.org/packages/Alternet.UI)
- [Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=AlternetSoftwarePTYLTD.AlternetUIForVS2022)

## How to use:

- [Visual Studio](https://docs.alternet-ui.com/tutorials/hello-world/visual-studio/hello-world-visual-studio.html)
- [Command-Line and Visual Studio Code](https://docs.alternet-ui.com/tutorials/hello-world/command-line/hello-world-command-line.html)

------------

## How to build:

It is better to use AlterNET UI from [NuGet](https://www.nuget.org/packages/Alternet.UI). If you need a custom build, 
here is step by step instructions:

- 3 build machines are needed: Windows, macOS, Linux.
- On all machines installations of .NET SDK [6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0),
 [7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0), [8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) 
are required.
- If you want to use UI on single platform, skip installation steps for other platforms.

<b>STEP 1.</b> Windows Machine Setup:

- Install Visual Studio 2022 Version 17.8.0 or later, with C# Desktop development, C++ Desktop development workloads, 
VS Extenstion Development installed. Net 8.0, 6.0, 7.0, 4.62, 4.81 targeting packs are required.
- Clone the AlterNET UI repo.
- Use the "C:\Alternet.UI" folder or any other root folder. The folder name should not contain any spaces or non-English letters.

<b>STEP 2.</b> macOS Machine Setup:

- macOS 10.15 (Catalina) or newer is required.
- Install appropriate XCode version (for example Xcode 12.4 for macOS 10.15). See 
this [page](https://developer.apple.com/support/xcode/).
- Install [CMake](https://cmake.org/download/). Copy CMake.app into /Applications (or another location), double click to run it.
 Follow the "How to Install For Command Line Use" menu item.
- Make folder with Windows Alternet.UI installation accessible for macOS Machine.

<b>STEP 3.</b> Linux Machine Setup:

- Install Ubuntu 20.04 or newer.
- Install CMake and C compilers.
- Install required packages, run Install.Scripts/Ubuntu.Install.Packages.sh.
- Make folder with Windows Alternet.UI installation accessible for Linux Machine.

<b>STEP 4.</b> (Optional) Specify target frameworks:
You can modify list of target frameworks in files
"Source\Samples\CommonData\TargetFrameworks.props" and "Source\Version\TargetFrameworks.props".
This will speed up the build process.

<b>STEP 5.</b> Build:

If you want to use UI on single platform, run install script only there.

- Exit Visual Studio before running Install script.
- Run Install.sh (or Install.ps1) on macOs Machine.
- Run Install.sh (or Install.ps1) on Linux Machine.
- Run Install.bat (or Install.ps1) on Windows Machine.
- Now you can open solution "\Source\Alternet.UI.sln".

<b>STEP 6.</b> (Optional) Build NuGet packages on Windows Machine:

- Run Install.Scripts/MSW.Publish.1.Build.Nuget.Pal.bat.
- Run Install.Scripts/MSW.Publish.2.Build.NuGet.Managed.bat.
- The results will be in Publish/Packages.

## Important:

Please run the Install script each time you switch development platform 
(for example, when you switch from Linux to MSW, run Install.bat on MSW).

## How to use with latest source from GitHub:

If you want to develop with latest AlterNET.UI source from GitHub instead of using it from 
[NuGet](https://www.nuget.org/packages/Alternet.UI), you can use 
[MinMasterTemplate](https://github.com/alternetsoft/AlternetUI/tree/master/Install.Scripts/MinMasterTemplate).

## How to create new control:

- In the NativeApi project, add a new control class using some existing control as an example.
- Run NativeApi.Generator to generate to interop code.
- Add new managed classes and their respective control handlers in the AlterNET.UI project, using 
some existing controls as an example.
- In the C++ project (Alternet.UI.Pal), include the generated source files (MyNewControl.cpp and MyNewControl.h) to the project.
Also in "Api" sub-folder include the generated source files (MyNewControl.Api.h and MyNewControl.inc) to the project.
- Make sure the C++ class is inherited from the Control class.
- The generated public methods definitions are in Api/MyNewControl.inc.
- You will need to create the corresponding implementations of this methods in the MyNewControl.cpp.
- Each of the controls is based on the corresponding wxWidgets control, see the existing controls for how they are implemented
- To check what functionality is supported by wxWidgets, inspect the documentation at https://docs.wxwidgets.org/3.2/ .
- After you created new UI control or added new event, call Install.Scripts\UpdateWellKnownApiInfo.bat.
This script allows to use new control in uixml. If you create controls in cs, you don't need to run it.