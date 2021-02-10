# UMVCS
Unity MVCS (Model-View-Controller-Service) Architecture

I created this from scratch for fun, for learning, and for teaching.

It is Unity-centric. Its designed for the unique aspects of game development in the Unity platform (Scenes, Prefabs, Serialization, GameObjects, MonoBehaviours, etc...)

It is MonoBehaviour-centric. There are pros and cons to this approach.

Enjoy!

<img src="https://github.com/SamuelAsherRivello/UMVCS/master/Unity/Assets/Documentation/Images/GameView.png?raw=true" width="500" />

**Details**

* <a href="https://www.unity3d.com/" target="_blank">Unity 2019.1</a>

**Features**

* A light-weight custom <a href="https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller" target="_blank">MVCS Architecture</a> - for high-level organization
* A custom <a href="https://en.wikipedia.org/wiki/Finite-state_machine" target="_blank">StateMachine</a> - For managing runtime complexity
* A custom <a href="http://www.samuelasherrivello.com/unity-project-structure/" target="_blank">Project Organization</a> - for assets best practices
* A custom CommandManager - For decoupled, global communication
* Project Organization - A prescriptive solution for structuring your work
* Code Template - A prescriptive solution for best practices

MVCS
=============

The high-level architecture is taken from the industry-standard MVCS. 

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/MVCS_Diagram.png" width="500" />

Project Organization
=============
  
I used my own <a href="http://www.samuelasherrivello.com/unity-project-structure/" target="_blank">Project Organization</a> for project structure.

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/ProjectWindow.png" width="500" />


Scene Hierarchy Organization
=============
  
The hierarchy structure mimics the MVCS code structure. The hierarchy structure is optional.



<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/HierarchyWindow.png" width="500" />

Approach #1 - I used this. (See screenshot above)
* App
  * Model
  * View
  * Controller
  * Service

Approach #2 - Here is an alternative approach
* App
  * Main
    * Model
    * View
    * Controller
    * Service
  * Audio
    * Model
    * View
    * Controller
    * Service

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/BouncyBallView.png" width="500" />


For prefabs I followed the same concept, however, I made exceptions.

Approach #1 - I wanted to use this, but there are challenges

* Prefab
  * Model
  * View
  * Controller
  * (Service)

Approach #2 - I used this (See screenshot above)

* Prefab/View
  * Model
  * Controller
  * (Service)


Decoupling
=============
  
### Unity-Friendly MVCS References

<img src="https://github.com/SamuelAsherRivello/UMVCS/master/UMCVS/Assets/Documentation/Images/Inspector_MainController.png?raw=true" width="500" />

The serialized references allow for high-level references in a Unity-friendly way. Of course these references do represent 'coupling' but each major class type has a specific responsibility and these major concerns are indeed separate the logic. (See screenshot above)

There is a nice concept where in the C# you can specify 'null' for the Model, View, Controller, Service and it will not appear in the inspector.

### C# Structure

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/Editor_MainController.png" width="500" />


 (See screenshot above)

 1. I structured the high level classes using generics
 1. The boilerplate superclass stucture does allow some (optional) recasting in the subclasses. 
 1. The CommandManager works like an "EventBus" or "EventDispatcher". To prevent naming confusion with the "UnityEvents" I use, I call this tier of communication "Commands".
 1. For View->Controller communication "UnityEvents" are used.

Model Serialization
=============

I chose for BaseModel to extend MonoBehaviour. There are pros and cons for this.

### C# BaseModel (MonoBehaviour) 

A project can have as many models as needed. Typically one for each major domain (Player, Enemy, World, Physics, Audio, etc...)

Your BaseModel sublass is meant for reading at **Runtime**.

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/Inspector_MainModel.png" width="500" />

One of the pros of MonoBehaviour is the serialization in the inspector for the data. This is very helpful for debugging and seeing the current state of the app while its running. (See screenshot above)

### C# BaseConfigData (ScriptableObject) 

<img src="https://raw.githubusercontent.com/srivello/UMVCS/master/UMCVS/Assets/Documentation/Images/Inspector_MainConfigData.png" width="500" />

There are many benefits for using ScriptableObjects for data storage. It is written to disk and easily editable at both editor time and run time. (See screenshot above)

Your BaseConfigData subclass is meant for writing at  **Edit Time** and reading at runtime.

Unit Tests
=============
  
I included Unit Tests (with limited coverage). In some cases I used TDD to develop sections and in other I added tests for academic (teaching) reasons. Generally, I recommend using Unit Tests for game projects and providing a coverage strategy

Coverage Strategy
* Use TDD (per developer preference)
* Increase coverage on higher-risk and/or highly-testable areas
* Add a failing test for reported bugs. Fix the bug. Leave the passing test.


<img src="https://github.com/SamuelAsherRivello/UMVCS/master/UMCVS/Assets/Documentation/Images/TestRunnerWindow.png?raw=true" width="500" />

Created By
=============

- Samuel Asher Rivello 
- Over 20 years XP with game development (2020)
- Over 8 years XP with Unity (2020)

Contact
=============

- Twitter - <a href="https://twitter.com/srivello/">@srivello</a>
- Resume & Portfolio - <a href="http://www.SamuelAsherRivello.com">SamuelAsherRivello.com</a>
- Git - <a href="https://github.com/SamuelAsherRivello/">Github.com/SamuelAsherRivello</a>
- LinkedIn - <a href="https://Linkedin.com/in/SamuelAsherRivello">Linkedin.com/in/SamuelAsherRivello</a> <--- Say Hello! :)

