# Build Script

You can reference Cake.MsDeploy in your build script as a cake addin:

```cake
#addin "Cake.MsDeploy"
```

or nuget reference:

```cake
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.MsDeploy"
```

Then some examples:

```cake
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
            Direction = Direction.source,
            Path = "./src/Application.zip"
        },
        Destination = new AutoProvider
        {
            Direction = Direction.dest,
            IncludeAcls = false,
            AuthenticationType = AuthenticationScheme.NTLM,
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