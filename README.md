# nhsuk.base-application
A .NET project which include some of the common things needed at NHS.UK.

## Overview

### ASP .NET Core web application
- ASP .NET Core MVC Views using .NET 3.1 Framework
- NHS.UK frontend library
- NHS.UK header and footer Nuget package

### NUnit test project
Setup for NUnit unit tests.

### Azure pipeline
Automated CI pipeline to deploy pushes to `main` to nhsuk development environment.
- Checkout
- Nuget - restore packages including 
- Test - runs tests in NUnit test project
- Build - build web application
- Publish - publish web application
- Deploy - deploy to Azure web service


## ASP .NET Core web application
The application runs on Windows and Linux using either Visual Studio or CLI.

### Build
Building the web application will automatically run `npm install && npm run build`.

The script `npm install` installs all NPM dependencies listed within the `package.json`.

The script `npm run build` runs the `gulp build` task.

### Gulp
The application contains 2 tasks in `gulpfile.js`.

The task `gulp build` will build CSS and JS assets and add them to `wwwroot/dist`.

The task `gulp` does the same as gulp build but adds a watch to recompile assets as they change in `wwwroot/src/**/*`.

### SCSS
A single file `wwwroot/src/main.scss` gets compiled into CSS and saved as `wwwroot/dist/main.css`.

Any custom SCSS can be added to this file or imported into this file.

### JavaScript
A single file `wwwroot/src/main.js` gets transpiled by Babel into ES5 and saved as `wwwroot/dist/main.css`.

Any custom ES6 JavaScript can be added to this file or imported into this file.

### NHS.UK header and footer Nuget package
The header and footer are dynamically built by the `nhsuk.header-and-footer-client` Nuget package.
