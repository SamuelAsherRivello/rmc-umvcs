[![npm package](https://img.shields.io/npm/v/com.rmc.rmc-umvcs)](https://www.npmjs.com/package/com.rmc.rmc-umvcs)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# RMC Architectures

Rivello Multimedia Consulting has multiple frameworks for MVC in Unity.


| --              | Requires MonoBehaviour?  | Lightweight?       | More Info    | Created    | Updated    |
|-----------------|--------------------------|--------------------|--------------|------------|------------|
| uMVCS           | ✔️                      | ✔️ (Light)         | See Below    | 2018       | 2023       |
| Mini MVCS       | ❌                       | ✔️ (Even Lighter!)  | [rmc-mini-mvcs](https://github.com/SamuelAsherRivello/rmc-mini-mvcs/)    | 2023   | 2023   |

# RMC Umvcs Architecture - For Unity

The UMVCS library for Unity is a custom framework embracing the [MVCS architecture](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller).

MVCS is one of many solutions for organizing a Unity projec efficiently. It may or may not be the best solution for you.

## UMVCS MVCS Is Light

The UMVCS library a solution for MVCS architecture within Unity. It is **heavily-dependent** on **MonoBehaviour** as a It has no dependencies on 3rd party libraries.

## UMVCS Is Free

The UMVCS MVCS library for Unity Development is free. Created by Rivello Multimedia Consulting.

## UMVCS Is Simple & Proven

<img width="200" src="./RMC UMVCS/Documentation~/simplicity-chart.jpg"/>


## UMVCS is Flexible

It has few classes and a flexible pattern. Following the conventions of MVCS requires discipline as the system is purposefully light and flexible. For example the a model instance **can** access another model instance, but it is recommended not to do so.

## UMVCS Best Practices

### Communication

UMVCS is flexible and does not prevent actor-actor communication. However, best practices are to limit communication.

**Communication Channels**

* Methods - The caller scope has a reference to the called scope and "calls a method" in the typical sense. This is the most coupled communication channel
* Events - [Observer pattern](https://www.dofactory.com/net/observer-design-pattern) where the reciever **has** a reference to the sender
* Commands - [Observer pattern](https://www.dofactory.com/net/observer-design-pattern) where the reciever **has no** reference to the sender. This is the least coupled communication channel

**Communication Suggestions**

| --              | To Model     | To View                 | To Controller | To Service     |
|-----------------|--------------|-------------------------|---------------|----------------|
| From Model      | ❌           | ❌                     | ✔️(Events)    | ❌           |
| From View       | ❌           | ❌                     | ✔️(Events)    | ❌           |
| From Controller | ✔️(Methods)  | ✔️(Methods/Commands)  | ✔️(Commands)  | ✔️(Methods)  |
| From Service    | ❌           | ❌                    | ✔️(Events)    | ❌           |

**Communication Diagram**

<img width="700" src="./RMC UMVCS/Documentation~/mvcs_diagram.png"/>


## UMVCS Appropriateness

MVCS is one of many solutions for organizing a Unity projec efficiently. It may or may not be the best solution for you.


| MVCS Pros                         | MVCS Cons     |
|-----------------------------------|---------------|
| Code is highly maintainable       | Code is highly repetitive                                   | 
| Code is highly extensible         | Project navigation requires more time                       | 
| Faster to update an existing project    | Slower To start a new project                         | 
| Adding a new feature is prescriptive          | Adding a new feature may require more classes     | 
| Faster learning curve to onboard veterans     | Slower learning curve to onboard newbies          | 
| Suggested for projects of medium/large scope  | Not Suggested for projects of small scope         | 
| Model is highly testable (TDD)                |                                                  | 
| Coding invites less debate                   | Coding requires more discipline                  | 

**Appropriateness For Games**

For projects where runtime optimization is essential, coding directly (without MVCS), may yield better performance.

However, that is likely a subsection of a game. The rest of the game may still benefit from MVCS. There is indeed flexibility for such a hybrid solution.


<img width = "400" src="https://raw.githubusercontent.com/SamuelAsherRivello/rmc-core/main/RMC%20Core/Documentation~/com.rmc_namespace_logo.png" />

# RMC UMVCS

- [How To Use](#how-to-use)
- [Install](#install)
  - [Via NPM](#via-npm)
  - [Via Git URL](#via-git-url)
  - [Tests](#tests)
  - [Samples](#samples)
- [Configuration](#configuration)

<!-- toc -->

## How to use

The UMVCS library for Unity is a custom framework embracing the [MVCS architecture](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller).

MVCS is one of many solutions for organizing a Unity projec efficiently. It may or may not be the best solution for you. Enjoy!

## Install

### Via NPM

You can either use the Unity Package Manager Window (UPM) or directly edit the manifest file. The result will be the same.

**UPM**

To use the [Package Manager Window](https://docs.unity3d.com/Manual/upm-ui.html), first add a [Scoped Registry](https://docs.unity3d.com/2023.1/Documentation/Manual/upm-scoped.html), then click on the interface menu ( `Status Bar → (+) Icon → Add Package By Name ...` ).

**Manifest File**

Or to edit the `Packages/manifest.json` directly with your favorite text editor, add a scoped registry then the following line(s) to dependencies block:

```json
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "com.rmc"
      ]
    }
  ],
  "dependencies": {
    "com.rmc.rmc-umvcs": "1.5.6"
  }
}
```
Package should now appear in package manager.


### Via Git URL

You can either use the Unity Package Manager (UPM) Window or directly edit the manifest file. The result will be the same.

**UPM**

To use the [Package Manager Window](https://docs.unity3d.com/Manual/upm-ui.html) click on the interface menu ( `Status Bar → (+) Icon → Add Package From Git Url ...` ).

**Manifest File**

Or to edit the `Packages/manifest.json` directly with your favorite text editor, add following line(s) to the dependencies block:
```json
{
  "dependencies": {
      "com.rmc.rmc-umvcs": "https://github.com/SamuelAsherRivello/rmc-umvcs.git"
  }
}
```

### Tests

The package can optionally be set as *testable*.
In practice this means that tests in the package will be visible in the [Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).

Open `Packages/manifest.json` with your favorite text editor. Add following line **after** the dependencies block:
```json
{
  "dependencies": {
  },
  "testables": [ "com.rmc.rmc-umvcs" ]
}
```

### Samples

Some packages include optional samples with clear use cases. To import and run the samples:

1. Open Unity 
1. Complete the package installation (See above)
1. Open the [Package Manager Window](https://docs.unity3d.com/Manual/upm-ui.html)
1. Select this package 
1. Select samples
1. Import

## Configuration

* `Unity Target` - [Standalone MAC/PC](https://support.unity.com/hc/en-us/articles/206336795-What-platforms-are-supported-by-Unity-)
* `Unity Version` - Any [Unity Editor](https://unity.com/download) 2021.x or higher
* `Unity Rendering` - Any [Unity Render Pipeline](https://docs.unity3d.com/Manual/universal-render-pipeline.html)
* `Unity Aspect Ratio` - Any [Unity Game View](https://docs.unity3d.com/Manual/GameView.html)


Created By
=============

- Samuel Asher Rivello 
- Over 23 years XP with game development (2023)
- Over 10 years XP with Unity (2023)

Contact
=============

- Twitter - <a href="https://twitter.com/srivello/">@srivello</a>
- Resume & Portfolio - <a href="http://www.SamuelAsherRivello.com">SamuelAsherRivello.com</a>
- Source Code on Git - <a href="https://github.com/SamuelAsherRivello/">Github.com/SamuelAsherRivello</a>
- LinkedIn - <a href="https://Linkedin.com/in/SamuelAsherRivello">Linkedin.com/in/SamuelAsherRivello</a> <--- Say Hello! :)

License
=============

Provided as-is under MIT License | Copyright © 2023 Rivello Multimedia Consulting, LLC




