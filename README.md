# EtmilanAutomation
EtmilanAutomation project handles the automation  tests for Etmilan web application

### Features
- Parallel execution provided by Nunit
- Written entirely in C#
- Page Object Pattern
- Cross browser capability
- Possibility to change the browser/default user/default password from config file
- Possibility to set the loading time

### Tech tools
 - using the IDE: Microsoft Visual Studio  2017
 - NUnit 3.6.1
 - NUnit 3.6.1 console
 - Selenium WebDriver 3.3.0
 - Selenium Firefox WebDriver for Firefox execution
 - Selenium Chrome WebDriver for Chrome execution
 - Firefox Mozzila 47.0.1
 - Chrome

### How to install
___Step 1:___ Install Visual Studio Community 2017 https://www.visualstudio.com/downloads/
On Visual Studio Installer, go to "Individual components" tab and choose the specific components for C# language for each listed section.
Install them (it will take a while).
___Step 2:___
Launch Visual Studio 2017.
Go to Tools / Extensions and Updates / Online and search and install for:
 -NUnit 3 Test Adapter
 -NUnit VS Templates
These extensions are mandatory for test execution in Visual Studio.
___Step 3:___
Assure that the EtmilanAutomation code source is stored localy on your machine.
On the menu bar in Visual Studio, choose File, Open, Project/Solution.
Navigate to the EtmilanAutomation project folder and open it.
You don't need to install NUnit and Selenium WebDriver because Nuget handles the packages to the system (check packages.config file).

#### Setting PATH on Windows
In case you want to run the tests on Firefox, you should configure the PATH for Firefox: 
Open Control Panel > System > Advanced > Open Control Panel > System > Advanced System Settings > Environment Variables....In the Environment Variables window, highlight the Path variable in the System variables section and click the Edit button. Add the the directory containing 'firefox.exe'' to your PATH. e.g.: "c:\Program Files (x86)\Mozilla Firefox\"

### Running the tests
##### From Visual Studio
When you build the test project, the tests appear in Test Explorer. If Test Explorer is not visible, choose Test on the Visual Studio menu, choose Windows, and then choose Test Explorer.
 - To run all the tests in the solution, choose Run All.
 - To run a single test in the solution, click right on the test and choose 'Run Selected Tests
##### From the command line
Assure [Nunit console](https://github.com/nunit/nunit-console/releases/tag/3.6.1)  is installed on your local machine.
Navigate to your nunit console path (location where NUnit console package is installed) and execute the following command line in order to run the EtmilanAutomation tests:
>nunit3-console.exe <path to test.EtmilanAutomation.dll>
e.g.
>nunit3-console.exe c:\EtmilanAutomation\bin\Release\EtmilanAutomation.dll
##### Set the general properties
The project provides you the ability to change the general properties like: the default user, the password or the browser type where the tests will run.
App.config file contains the following settings: 
 -     <add key="url" value="https://app.com" /> is the URL of the web application
 -      <add key="profile" value="CHROME" /> is the type of the browser for the test execution. Currently only CHROME and FIREFOX browsers are supported.
 -      <add key="timeToLoad" value="50" /> is the default loading time(in seconds) of the application. The value can be increased in case the application is slow
 -      <add key="user" value="XXX" />  is the default user
 -      <add key="password" value="XXX" /> is the default password.
