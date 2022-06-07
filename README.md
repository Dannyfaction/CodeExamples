# CodeExamples
A repository full of code examples from different C++ / C# projects I have worked on.  
All projects include a Visual Studio solution (.sln) which can be build and run to launch the application.

## [DataFlow](https://github.com/Dannyfaction/CodeExamples/tree/main/DataFlow)
C++ Windows based game made in a Custom Game Engine.

Note: Set the "TDGame" project as startup project to build and launch the game. 

Results and details of the project can be found [**here**](https://dannykruiswijk.com/projects/DataFlow.html).

Noteworthy contributions:  

**Engine programming**
- Project set-up, clean structure with SolutionProperties and discrepancy between the Game and Engine by making use of static and dynamic libraries.
- IO Filesystem: [FileIO.h](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/include/Core/FileIO.h) [FileIO.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/src/Core/FileIO.cpp)
- FMOD audio system implementation: [AudioManager.h](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/include/Audio/AudioManager.h) [AudioManager.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/src/Audio/AudioManager.cpp)
- Porting engine to Nintendo Switch.

**Tools Programming**
- ImGui interface with Entity list and component viewer/editor: [GraphicalUserInterface.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/src/Tools/PC/GraphicalUserInterface.cpp) [EntityList.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/src/Tools/PC/Window/EntityList.cpp) [ComponentInspector.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/FracEngine/src/Tools/PC/Window/ComponentInspector.cpp)
- Build versioning system based off source-control changelist: [Version.cpp](https://github.com/Dannyfaction/CodeExamples/blob/main/DataFlow/FracTowerDefenseSolution/TDGame/src/Tools/Version.cpp)


![DataFlow Banner](https://dannykruiswijk.com/images/dataflow-banner.png)

## [PipelineToolApplication](https://github.com/Dannyfaction/CodeExamples/tree/main/PipelineToolApplication)
C# project for automating repetitive tasks in DCC software (Maya & Houdini) using Python scripts.  
Results and details of the project can be found [**here**](https://dannykruiswijk.com/projects/PipelineToolApplication.html)  

![PipelineToolApplication Banner](https://dannykruiswijk.com/images/PipelineToolsApplication1280x720.png)

## [BugReporter](https://github.com/Dannyfaction/CodeExamples/tree/main/DataFlow/FracTowerDefenseSolution/BugReporter)
C++ Standalone application for sending BugReports with input and engine logs to a Jira board through a Rest API call.  

Note: Visual Studio solution can be found at [/DataFlow/](https://github.com/Dannyfaction/CodeExamples/tree/main/DataFlow), the BugReporter is made as a part of the DataFlow custom game engine.  
After building the engine, the executable can be found in the /bin/ directory as BugReporter.exe  
The engine launches this .exe when the engine has been terminated via an assert.  

Results and details of the project can be found [**here**](https://dannykruiswijk.com/projects/DataFlow.html).

![BugReporter Banner](https://dannykruiswijk.com/images/BugReporterBanner.png)