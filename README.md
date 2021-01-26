# nhsuk.base-application

[![Build Status](https://dev.azure.com/nhsuk/nhsuk.base-application/_apis/build/status/tomdoughty.nhsuk.base-application?branchName=main)](https://dev.azure.com/nhsuk/nhsuk.base-application/_build/latest?definitionId=658&branchName=main)

A .NET project which include some of the common things needed at NHS.UK.

[View the latest deployment of main branch](https://nhsuk-base-application-dev-uks.azurewebsites.net/service-name).

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

For dev the application will run on `https://localhost:5001/service-name` with the base path being configurable in `Startup.cs`

We always use base paths for applications so it is easier for infra to handle our application in higher environments and to ensure any assets are served from the correct application and not the domain root which would hit Wagtail.


### Build
Building the web application will automatically run `npm install && npm run build`.

The `npm install` command installs all NPM dependencies listed within the `package.json`.

The `npm run build` command runs the `gulp build` task.

### Gulp
The application contains 2 tasks in `gulpfile.js`.

The task `gulp build` will build CSS and JS assets and add them to `wwwroot/dist`. _These files are not commited to the repository._

The task `gulp` does the same as gulp build but adds a watch to recompile assets as they change in `wwwroot/src/**/*`.

### SCSS
A single SCSS file exists at `wwwroot/src/scss/main.scss`.

This file imports the required SCSS from NHS.UK frontend library.

Any custom SCSS can be added or imported into this file.

The Gulp tasks compile this file into CSS and minify it for production.

The resulting JavaScript is saved in `wwwroot/dist/main.css`. _This file is not commited to the repository_.

### JavaScript
A single JavaScript file exists at `wwwroot/src/js/main.js`.

This file imports the required JavaScript from NHS.UK frontend library.

Any custom ES2015 JavaScript can be added or imported into this file.

The Gulp tasks transpile this file into ES5 JavaScript using Babel and minify it for production. The resulting JavaScript is saved in `wwwroot/dist/main.js`. _This file is not commited to the repository_.

### NHS.UK header and footer Nuget package
The header and footer are dynamically built by the `nhsuk.header-and-footer-client` Nuget package.

NHS.UK header and footer Nuget package is available by [connecting to the Azure feed](https://dev.azure.com/nhsuk/nhsuk.header-footer-api-client/_packaging?_a=connect&feed=nhsuk.header.footer.api.client%40Release).

If you are from outside NHS.UK and want to use this repository please use the [transactional header branch](https://github.com/tomdoughty/nhsuk.base-application/tree/transactional-header) which does not use the private Nuget package.

### Adobe analytics
Adobe analytics script is loaded in based on `AdobeAnalyticsScriptUrl` set in `appsettings.json`.

Adobe analytics `digitalData` object is built dynamically from application URL.

### Cookie banner
NHS.UK cookier banner is loaded in based on `CookieScriptUrl` set in `appsettings.json`.

### Docker
To run the application with Docker you need to generate a Personal Access Token in Azure Devops and pass this to `docker-compose` to run the application.

## Examples

### Multi step form
https://nhsuk-base-application-dev-uks.azurewebsites.net/example-form

A lot of new services at NHS.UK are transactional. This form will store input in `TempData` across pages which can be used to display a summary page to check answers. This form also handles validation with `IValidateObject` as we have rewritten validation across many apps now. This is implemented with fully a accessible error summary, and error messages.

### Results from API
https://nhsuk-base-application-dev-uks.azurewebsites.net/example-async?org=nhsuk

This page gets an organisation's repositories from GitHub API and displays them on the page.
