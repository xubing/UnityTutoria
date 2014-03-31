Unity iPhone native code plugin sample application.

Description: this sample is aimed to demonstrate how objective-C code could be invoked
from Unity iPhone application. This application implements very simple Bonjour client.
Application consists of Unity iPhone project (Plugins/Bonjour.cs C# interface to the native code,
BonjourTest.js JS script that implements application logic) and native code (Assets/Code) 
that should be appended to built XCode project.

Simple instructions how to build this sample:

1. Open project with Unity iPhone 1.1 or later.
2. Open menu "File->Build Settings..".
3. Hit "Build".
4. Enter XCode project name and click "Save".
5. Open built project with XCode.
6. Inside XCode: expand "Unity-iPhone" in Groups & Files tree.
7. Right click on "Classes" subfolder and choose "Add->Existing files...".
8. In open dialog navigate to the ../Assests/Code folder and select "BonjourClientImpl.h"+"BonjourClientImpl.mm".
9. Click "Add".
10. Click "Add" once more again.
11. Click "Build and Go".
12. Check application running on device. 

Application manual:

1. Enter bonjour service name inside edit box. "_daap._tcp" is a good start as it describes 
iTunes music sharing service. 
2. Click "Query".
3. Found service hosts will be shown as buttons below. Clicking on these buttons does nothing ;)
4. Click "Stop" to stop browsing and enter another service name.
5. Continue 2-4