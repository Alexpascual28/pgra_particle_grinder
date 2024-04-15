<p align="center">
  <img src="https://raw.githubusercontent.com/PKief/vscode-material-icon-theme/ec559a9f6bfd399b82bb44393651661b08aaf7ba/icons/folder-markdown-open.svg" width="100" alt="project-logo">
</p>
<p align="center">
    <h1 align="center">PGRA Particle Grinder</h1>
</p>
<p align="center">
    <em><code>Particle grinder robot interface and simulator using .NET WPF, C# and XAML.</code></em>
</p>

<br><!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary><br>

- [ Overview](#-overview)
- [ Features](#-features)
- [ Repository Structure](#-repository-structure)
- [ Modules](#-modules)
- [ Getting Started](#-getting-started)
  - [ Installation](#-installation)
  - [ Usage](#-usage)
  - [ Tests](#-tests)
- [ Project Roadmap](#-project-roadmap)
- [ Contributing](#-contributing)
- [ License](#-license)
- [ Acknowledgments](#-acknowledgments)
</details>
<hr>

##  Overview

<code>This project contains the code for a particle grinder robot interface and simulator built using .NET WPF, C#, and XAML. It implements the MVVM (Model-View-ViewModel) design pattern.</code>

---

##  File Structure

* **App.xaml / App.xaml.cs**: Application main entry and setup.
* **MainWindow.xaml / MainWindow.xaml.cs**: Main window of the application.
* **MVVM/**
   * **Model/**: Contains data model classes.
      * **RobotModel.cs**: Defines the robot's data model.
   * **ViewModel/**: Contains classes handling the business logic.
      * **RobotViewModel.cs**: Handles the interactions between the view and the model.
   * **Views/**: Contains the user interface files.
      * **RobotView.xaml / RobotView.xaml.cs**: User interface for the robot view.
* **Theme/**: Contains styles and themes.
   * **ButtonTheme.xaml**: Style definitions for buttons.
* **FinalGrinderRobotApp.csproj**: Project file for .NET.
* **FinalGrinderRobotApp.sln**: Solution file for the project.
* **AssemblyInfo.cs**: Contains assembly metadata.

---

##  Repository Structure

```sh
└── pgra_particle_grinder/
    ├── FinalGrinderRobotApp
    │   ├── App.xaml
    │   ├── App.xaml.cs
    │   ├── AssemblyInfo.cs
    │   ├── FinalGrinderRobotApp.csproj
    │   ├── MVVM
    │   ├── MainWindow.xaml
    │   ├── MainWindow.xaml.cs
    │   └── Theme
    ├── FinalGrinderRobotApp.sln
    └── README.md
```

---

##  Modules

<details closed><summary>All Modules</summary>

<details closed><summary>.</summary>

| File                                                                                                                        | Summary                         |
| ---                                                                                                                         | ---                             |
| [FinalGrinderRobotApp.sln](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp.sln) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>FinalGrinderRobotApp</summary>

| File                                                                                                                                                   | Summary                         |
| ---                                                                                                                                                    | ---                             |
| [MainWindow.xaml](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MainWindow.xaml)                         | <code>► INSERT-TEXT-HERE</code> |
| [MainWindow.xaml.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MainWindow.xaml.cs)                   | <code>► INSERT-TEXT-HERE</code> |
| [App.xaml.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/App.xaml.cs)                                 | <code>► INSERT-TEXT-HERE</code> |
| [AssemblyInfo.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/AssemblyInfo.cs)                         | <code>► INSERT-TEXT-HERE</code> |
| [App.xaml](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/App.xaml)                                       | <code>► INSERT-TEXT-HERE</code> |
| [FinalGrinderRobotApp.csproj](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/FinalGrinderRobotApp.csproj) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>FinalGrinderRobotApp.Theme</summary>

| File                                                                                                                                   | Summary                         |
| ---                                                                                                                                    | ---                             |
| [ButtonTheme.xaml](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/Theme/ButtonTheme.xaml) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>FinalGrinderRobotApp.MVVM.Model</summary>

| File                                                                                                                                  | Summary                         |
| ---                                                                                                                                   | ---                             |
| [RobotModel.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MVVM/Model/RobotModel.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>FinalGrinderRobotApp.MVVM.Views</summary>

| File                                                                                                                                          | Summary                         |
| ---                                                                                                                                           | ---                             |
| [RobotView.xaml.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MVVM/Views/RobotView.xaml.cs) | <code>► INSERT-TEXT-HERE</code> |
| [RobotView.xaml](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MVVM/Views/RobotView.xaml)       | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>FinalGrinderRobotApp.MVVM.ViewModel</summary>

| File                                                                                                                                              | Summary                         |
| ---                                                                                                                                               | ---                             |
| [RobotViewModel.cs](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/master/FinalGrinderRobotApp/MVVM/ViewModel/RobotViewModel.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

</details>

---

##  Getting Started

**Prerequisites**

* Microsoft .NET SDK (compatible with the version used in the project, e.g., .NET 5.0)
* A code editor that supports .NET development (e.g., Visual Studio).

**Required Libraries**

Make sure to have all necessary .NET libraries and any specific third-party libraries mentioned in the **.csproj** file included. The most typical libraries needed for a WPF application include but are not limited to:

* Microsoft.NET.Sdk.WindowsDesktop
* System.Windows.Controls

###  Installation

<h4>From <code>source</code></h4>

> 1. Clone the pgra_particle_grinder repository:
>
> ```console
> $ git clone https://github.com/Alexpascual28/pgra_particle_grinder.git
> ```
>
> 2. Change to the project directory:
> ```console
> $ cd pgra_particle_grinder
> ```

###  Usage

* Open the **FinalGrinderRobotApp.sln** file in Visual Studio.
* Restore the required packages by running **Restore NuGet Packages**.
* Build the solution by selecting **Build Solution** from the build menu.
* Run the application by pressing **Start** or **F5**.

---

##  Key Operations

- Initialization: **App.xaml.cs** initializes the main window and sets up any required startup configurations.
- User Interaction: User interactions are managed in **MainWindow.xaml** and **RobotView.xaml**, where commands are bound to the ViewModel which processes the logic and updates the Model.
- Data Handling: **RobotModel.cs** is central to managing the data representing the robot's state.
- UI Updates: **RobotViewModel.cs** observes changes in the model and updates the UI accordingly through data bindings in XAML files.

---

## RobotViewModel Code Explanation

The **RobotViewModel.cs** file is a core part of our particle grinder robot application, handling the robot's operational logic. Here's a detailed breakdown of how this code works:

### Class Definition

**RobotViewModel** is an internal class that orchestrates interactions between the model and the view, using various properties and methods to manage robot operations.

### Constructor

Upon instantiation:

*LoadData()* is called to initialize robot components with default settings and write a header to a CSV file for data export.
*MainLoop()* is encapsulated within a task that starts immediately, driving the robot's continuous operations.

### Properties

Each property, such as **dataPanel**, **inputRack**, **outputRack1**, etc., represents a component of the robot system. These properties are of custom types, defined in **RobotModel** in the application, corresponding to the specific hardware or logical units of the robot.

### LoadData Method

Initializes all robot components with default values:

Each rack and component is set with initial values, such as number of vials or busy states.
A **StreamWriter** is used to create or overwrite an existing CSV file at a specified path to log output data.

### MainLoop Method

Defines the main operational loop of the robot:

Continues until a predefined number of output vials is achieved.
Within the loop, various operations (**RobotAction0** to **RobotAction4**) are called depending on the robot's state, such as moving vials between racks and processing them.
Delays are used to simulate processing time.

### Action Methods (RobotAction0 to RobotAction4)

These methods simulate the actions of the robot arm moving items between different components:

* Each method updates component states, such as whether a grinder or dispenser is empty or busy.
* They also update the **dataPanel.RobotAction** property to reflect the current action, providing status updates that are displayed in the UI (**RobotView**).

### CheckStopStatus Method

Checks and handles the stop or reset conditions:

* On reset, all components are reinitialized.
* On stop, the application may shut down, and final data could be written to the file (currently commented out).

### DispenseAction and WeightAction Methods

Handle specific operations of dispensing material and weighing:

* Updates on component states and operation-specific actions are logged and displayed.
* In **WeightAction**, random weights are assigned to simulate the weighing process, with potential data logging.

### GrinderAction and grinder_Tick Methods

Control the grinding process:

* **GrinderAction** sets the grinder as busy and starts a timer that triggers **grinder_Tick**.
* **grinder_Tick** simulates the progress of grinding by incrementing progress until complete, then stops the timer and updates the status.

This code structure allows for simulating a complex sequence of robotic operations with various interdependent components, reflecting a realistic industrial automation scenario. The use of tasks, timers, and event-driven programming effectively models asynchronous operations of robotic systems.

---

##  Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Report Issues](https://github.com/Alexpascual28/pgra_particle_grinder.git/issues)**: Submit bugs found or log feature requests for the `pgra_particle_grinder` project.
- **[Submit Pull Requests](https://github.com/Alexpascual28/pgra_particle_grinder.git/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/Alexpascual28/pgra_particle_grinder.git/discussions)**: Share your insights, provide feedback, or ask questions.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/Alexpascual28/pgra_particle_grinder.git
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="center">
   <a href="https://github.com{/Alexpascual28/pgra_particle_grinder.git/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=Alexpascual28/pgra_particle_grinder.git">
   </a>
</p>
</details>

---
