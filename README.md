# Betaverse 2026

ECAL M&ID Block Week, February 2026

Mixed reality with [Meta Quest 3](https://www.meta.com/de/quest/quest-3/).

## This project
This is a very basic sample project to get started with Quest 3 development in Unity. It is based on the **Universal 3D** Unity template and includes the Meta XR All-in-One SDK with the required settings.

### Prerequisites
- If not already installed, install [Unity Hub](https://unity.com/unity-hub)
- Install **Unity 6000.3.7** with *Android Support* (including JDK, SDK, and NDK)

### Building the application
- Open the project in Unity through Unity Hub
- Go to **File → Build Profiles**
- If Meta Quest is not yet the active platform:
  - Select **Meta Quest**
  - If needed, click **Enable Platform**
  - Click **Switch Platform** to change the platform to Meta XR  
    (This may take a while while the project reloads.)
- Check **Development Build**  
  Building a development build is faster, but the resulting build is less optimized than a non-development build.
- Make sure your headset is connected to the computer via USB
- Click **Build and Run**, then select a location where the `.apk` build should be saved

The APK can be built to a location inside the project folder (e.g. `./Builds`), but make sure **not** to add the `.apk` file to the repository.

- Once the build is complete, the project should run on the device. It can be closed and restarted directly on the headset or via Meta Quest Developer Hub.

## Tools

### Meta Quest Developer Hub
A tool to launch apps, view the device stream, and more.

Info:  
https://developers.meta.com/horizon/documentation/unity/ts-mqdh/

### Oculus Link
For live preview on the headset directly from the Unity Editor.

**!! Windows only !!**  
(On macOS, use *Meta XR Simulator* instead.)

Instructions:  
https://developers.meta.com/horizon/documentation/unity/unity-link

### Meta XR Simulator
Simulates the headset and controllers directly in the Unity Editor. No headset is required when using mouse and keyboard controls.

Instructions:  
https://developers.meta.com/horizon/documentation/unity/xrsim-getting-started/

## Recreate this project
This is a basic Unity sample that can be recreated with the following steps:

- In Unity Hub, create a new project using **Unity 6000.3.7**
- Select the **Universal 3D (URP)** template  
  This is a basic Unity project prepared for 3D development, but without XR features.
- Open **Package Manager**
- Install the Meta SDK and OpenXR package  
  In Package Manager, click **(+) → Install package by name**:
  - Paste `com.meta.xr.sdk.all`, then click **Install**
  - Paste `com.unity.xr.meta-openxr`, then click **Install**
- If prompted to **Enable Meta XR Feature Set**, click **Yes**
- Open **Project Settings**, select **Meta XR**, and fix all issues that are automatically fixable  
  Then select the **Android / Meta** tab and repeat the process  
  If some errors cannot be fixed, close and reopen the project
- Open **Meta → Tools → Building Blocks**
- Scroll down and click **All Building Blocks**
- Drag at least the **Camera Rig** into the scene (or click the **+** button)
- Optionally add any of the following:
  - **Passthrough** (to see the environment for Mixed Reality experiences)
  - **Controller Tracking** (to visualize tracked controllers and enable interactions)
  - **Scene Effect Mesh** (setting: *Global Mesh Only*, to see the scanned room mesh)
  - **Grab Interaction** (an example cube that can be grabbed with the controller)

### Git setup with GitHub Desktop
- Open GitHub Desktop
- Select **Add an existing repository from your local drive**
- Choose the project folder → **Add Repository** → click **Create a repository instead**
- Select **Git Ignore: Unity**, then confirm with **Create Repository**
- Optional: Add the following items to the `.gitignore` file (one per line):
  - `/TempAssembly.dll`
  - `.DS_Store`

More information about project setup:  
https://developers.meta.com/horizon/documentation/unity/unity-project-setup/
