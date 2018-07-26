# Portfolio

This is a project created for the Epicodus code challenge for weeks 3 and 4 of .NET. It is a personal portfolio site with a blog section where users who are signed in can post comments to blog posts. Signing in also offers CRUD capabilities for blog posts and the ability to add and delete comments. It also features AJAX in the Create section and a Projects section displaying my top 3 starred Github repositories by using the Github API.

## Prerequisites

Prior to cloning, please ensure that you have VisualStudio 2017 and MAMP installed on your machine.


## Installing

Navigate to the project repository on Github: https://github.com/rpgandhi/DOTNETProfile.git

Select the green Clone button and copy the link

Open Terminal or your shell of choice

Navigate to your desktop and run the following command:
```
$ git clone
```
Navigate into the project directory and run the following commands:
```
$ dotnet restore
```
Ensure that MAMP is open and your server is running on port 8889 then run the following command in your terminal:
```
$ dotnet ef database update
```

You should now have a copy fully installed on your machine

Then in order to launch the project in your browser, run the following command which will launch the server then in your browser navigate to localhost:5000
```
$ dotnet run
```
Alternatively, you may open up the project in Visual Studio and press the "play" button

When you are ready to shut down your server press CTL + C, close your browser, and click the "Stop Servers" button on your MAMP window


## Built With

* .NET Core
* C#
* AJAX
* HTML/CSS
* MAMP
* Github API

## Authors

* **Rakhee Gandhi**

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
