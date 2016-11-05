# Cake.MsDeploy

Cake.MsDeploy is an Addin that extends [Cake](http://cakebuild.net/) for executing commands with the MsDeploy.exe (Web Deploy) command line interface (cli). 
In order to use this extension, [MsDeploy v3.6](https://www.microsoft.com/en-us/download/details.aspx?id=43717) will already have to be installed on the computer the cake build script is being executed on.

## Build Status

![AppVeyor](https://ci.appveyor.com/api/projects/status/github/louisfischer/Cake.MsDeploy)

## Referencing

You can reference Cake.MsDeploy in your build script as a cake addin:
```cake
#addin "Cake.MsDeploy"
```  

or nuget reference:

```cake
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.MsDeploy"
```

## Usage

```csharp
#addin "Cake.MsDeploy"

var target = Argument("target", "Default");

Task("MsDeploy-Package")
  .Does(() =>
{
    MsDeploy(new MsDeploySettings
    {
        Verb = Operation.Sync,
        RetryAttempts = 5,
        RetryInterval = 5000,
        Source = new PackageProvider
        {
            Direction = MsDeploy.Providers.Direction.source,
            Path = "./src/Application.zip"
        },
        Destination = new AutoProvider
        {
            Direction = MsDeploy.Providers.Direction.dest,
            IncludeAcls = false,
            AuthenticationType = MsDeploy.Providers.AuthenticationScheme.NTLM,
            ComputerName = "cake.computerName.com",
            TempAgent = true
        },
        AllowUntrusted = true,
        PreSyncCommand = "%windir%\\System32\\inetsrv\\appcmd.exe stop APPPOOL NameOfAppPool",
        PostSyncCommand = "%windir%\\System32\\inetsrv\\appcmd.exe start APPPOOL NameOfAppPool",
        WhatIf = true,
        SetParams = new List<SetParameter>
        {
            new SetParameter
            {
                Name = "IIS Web Application Name",
                Value = "www.cake.com"
            }
        }
    });
});

RunTarget(target);
```

## Documention

Please visit the Cake Documentation site for a list of available Aliases:
[http://cakebuild.net/dsl/cake.msdeploy](http://cakebuild.net/dsl/cake.msdeploy)

## Tests

Cake.MsDeploy is covered by set of xUnit tests.

## License

Copyright (c) 2016 Louis Fischer

Cake.MsDeploy is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/louisfischer/Cake.MsDeploy/blob/master/LICENSE).