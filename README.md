# AutoCOL

Automation of web application using Selenium WebDriver and C# language. This project performs automation of the www.circles.life.com and www.facebook.com site using POM based model and configurable approach to run various test cases.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See detailed notes below to setup project and running automation.

### Prerequisites

```
* Visual Studio 2013
* Windows 10 OS
```

### Installing

```
* Clone or download this project
* Build project in VS2013
* Configure TestData (more details below)
* Add MSTest.exe to your PATH environment
* Add ChromeDriver.exe parent directory to your PATH environment
* Mount E drive using below DOS command (in admin mode) to avoid ChromeDriver error "no disk there is no disk in the drive. please insert a disk into drive e:"
  mountvol e: /d
```

### Configurations

You need to setup few environment variables to run the test. It's designed to be able to easily configure test data and store it individually, so that test data management is easy. Just configure following environment variables.
Either set below environment variables on the Windows Environment Variable or in the DOS shell using command 'SET <variable_name> <value>'

#### COLTestConfigFilePath
Set environment variable with name 'COLTestConfigFilePath' and point it to a json file with below structure.
```
{
	"COL_URL": "https://pages.circles.life/",
	"FB_URL": "https://www.facebook.com/",
	"Browser": "Chrome",
}
```
A sample of this this file is avaible in TestData/Config.json file.
Loading AutoCOL.dll...
Starting execution...

Results               Top Level Tests
-------               ---------------
Passed                AutoCOL.src.Tests.FacebookSignInPageTest.TestFacebookPostComment
Passed                AutoCOL.src.Tests.SignInPageTest.TestSignIn
2/2 test(s) Passed

Summary
-------
Test Run Completed.
  Passed  2
  ---------
  Total   2
Results file:  C:\Users\khushbu\TestResults.trx
Test Settings: Default Test Settings
```

## Coding/Design guidelines

```
* Modular classes with single responsibility
* Use classes and inheritence to maintain code reusability
* Decoupled functionalities to organize code
* Configurable approach to change external factors
* Configurable test data
* Use camel casing for variable names
* blah blah blah ...
```

## Authors

* **Khushbu Agrawal** - (https://github.com/Khushbu-Agrawal)
