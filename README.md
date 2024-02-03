# EventApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.0.6.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## Step 02 – Environment setup and installations of the system
Install IIS Server.
• Go to Control Panel.
• Search “Turn Windows Features on or off” in the search bar
• Select “Web Management tools” and “World Wide Web Services” under
“Internet Information Services” and click on “Ok”.
• Installation could take a while.
Configure ISS Server
• Search “IIS” from the Start Menu and Select the “Internet Information Service
(ISS) Manager from the suggested list”.
• Expand “Sites” and “Default Web Site”
• You may find the copied published web application folder there.
• Right click on the published web application and Click on “Convert to
application”.
• Enter relevant Alias name and click on “Ok” and you are good to go.
## Step 03 – Install a Web Browser
• Download Google Chrome from
https://www.google.com/chrome/browser/desktop and install.
OR,
• Download Firefox from https://www.mozilla.org/en-US/firefox/new/ and install
## Step 04 – Copy the published Web application to the IIS server
• Copy the published web application and paste it “C:\inetpub\wwwroot”

• Launching the web application
1. Open the CD and copy the “EventProj.zip” paste it to a directory and extract it.
2. Double click run.bat file and wait until the server starts.
3. Open the installed web browser and type the URL http://localhost:5000 and press
“Enter” button to access the system in the server environment.
4. To access the system from any client machine on the network, type URL
http://<server-ip-address>:5000 and hit enter.
