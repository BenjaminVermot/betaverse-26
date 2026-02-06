# Betaverse 2026

ECAL M&ID Block Week, February 2026

Mixed reality with [Meta Quest 3](https://www.meta.com/de/quest/quest-3/).

## This project
This is a very basic sample project to get started with Quest 3 development in Unity. It is based on the "Universal 3D" Unity template and contains the Meta XR All in One SDK with the required settings. 

### Prerequisites
- If not installed already, install [Unity Hub](https://unity.com/unity-hub)
- Install Unity 6000.3.7 with _Android Support_ (including JDK/SDK/NDK)

### Building the application
- Open the project in Unity through Unity Hub
- Go to File → Build Profiles
- If Meta Quest is not yet the active platform: 
	- Select "Meta Quest"
	- If needed, click "enable platform"
	- Click "Switch Platform" to change the platform to Meta XR. It might take a while to reload the project.
- Check "development build". Building a "development build" is faster, but the resulting build is less optimized than a non-development build
- Make sure your headset is connected to the computer with a USB cable
- Click "build and run", select a location where the .apk build should go
The apk can be built to a location inside the project folder (e.g. ./Builds), but make sure to not add the .apk to the repository
- The project should run on the device when it's done. It can be closed and restarted on the device directly, or through Meta Quest Developer Hub.

## Tools

### Meta Quest Developer Hub
Tool to launch apps, watch the stream from the device etc.

Info: https://developers.meta.com/horizon/documentation/unity/ts-mqdh/

### Oculus Link 
For live preview on the headset, directly from the Unity Editor. 

**!! Windows only !!** (on Mac, use _Meta XR Simulator_ below)  

Instructions: https://developers.meta.com/horizon/documentation/unity/unity-link


### Meta XR Simulator
For simulating the headset and controllers directly in the Unity Editor. No headset is required when controlling with mouse and keyboard. 

Instructions: https://developers.meta.com/horizon/documentation/unity/xrsim-getting-started/

## Recreate this project

This is a basic Unity sample that can be recreated with the following steps:

- In Unity Hub, create a new project with Unity 6000.3.7
- Select "Universal 3D" (URP) template. This is a basic unity project prepared for 3D development, but without XR features.
- Open Package Manager
- Install Meta SDK and Open XR package. In Package Manager, click (+) → install package by name:
	- paste **com.meta.xr.sdk.all**, click "install"
	- paste **com.unity.xr.meta-openxr**, click "install"
- If there's a message that asks to "Enable Meta XR Feature Set", click Yes
Open Project Settings, Select Meta XR, fix all issues that are automatically fixable, then select the Android/meta tab and do the same again. If some errors can't be fixed, close and reopen the project
- Open Meta → Tools → Building Blocks, scroll down and click on "All Building Blocks"
- Drag at least the the Camera Rig to the scene (or click the + button)
- Optionally add any of these:
	- Passthrough (to see the environment for Mixed Reality experiences)
	- Controller Tracking (to see the tracked controllers, and to use interactions)
	- Scene Effect Mesh, setting: Global Mesh Only (to see the scanned room mesh)
	- Grab interaction (an example cube that can be grabbed with the controller)

To set up git for the project with GitHub desktop:
- Open GitHub desktop
- "Add an existing repository from your Local Drive" → select the folder → Add repository → click "create a repository instead"
- Select Git Ignore: Unity, confirm with "Create repository"
- Optional: Add these two items to the .gitignore file (one per line): **/TempAssembly.dll** and **.DS_Store**

More info about the project setup: https://developers.meta.com/horizon/documentation/unity/unity-project-setup/
