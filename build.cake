#addin "nuget:?package=Cake.MinVer"
#addin "nuget:?package=Cake.Args"

var slnFile = File("./Cake.MsDeploy.slnx");
var csprojFile = File("./src/Cake.MsDeploy/Cake.MsDeploy.csproj");
var testProjectFile = File("./src/Cake.MsDeploy.Tests/Cake.MsDeploy.Tests.csproj");

var target = ArgumentOrDefault<string>("Target") ?? "Default";
var configuration = ArgumentOrDefault<string>("Configuration") ?? "Release";
var buildVersion = MinVer(s => s.WithTagPrefix("v").WithDefaultPreReleasePhase("preview"));

Task("Clean")
    .Does(() =>
{
    EnsureDirectoryDoesNotExist("./artifact/");
    CleanDirectories("./**/^{bin,obj}");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetRestore(slnFile, new DotNetRestoreSettings
    {
        LockedMode = true,
    });
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(context => 
{
    DotNetBuild(slnFile, new DotNetBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
        NoIncremental = false,
        MSBuildSettings = new DotNetMSBuildSettings
        {
            Version = buildVersion.Version,
            AssemblyVersion = buildVersion.AssemblyVersion,
            FileVersion = buildVersion.FileVersion,
            ContinuousIntegrationBuild = BuildSystem.IsLocalBuild,
        },
    });
});

Task("Tests")
    .IsDependentOn("Build")
    .Does(context =>
{
    DotNetTest(testProjectFile, new DotNetTestSettings
    {
        NoBuild = true,
        NoRestore = true,
        Configuration = configuration
    });
});

Task("Pack")
    .IsDependentOn("Tests")
    .Does(() =>
{
    DotNetPack(csprojFile, new DotNetPackSettings
    {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
        OutputDirectory = "./artifact/nuget",
        MSBuildSettings = new DotNetMSBuildSettings
        {
            Version = buildVersion.Version,
            PackageReleaseNotes = $"https://github.com/cake-contrib/Cake.MsDeploy/releases/tag/v{buildVersion.Version}"
        }
    });
});

Task("Push")
    .IsDependentOn("Pack")
    .WithCriteria(() => ArgumentOrDefault<bool>("NUGET_PUSH"))
    .Does(context =>
{
    var url = context.ArgumentOrDefault<string>("NUGET_URL");
    if (string.IsNullOrWhiteSpace(url))
    {
        context.Information("No NuGet URL specified. Skipping publishing of NuGet packages");
        return;
    }

    var apiKey = context.ArgumentOrDefault<string>("NUGET_API_KEY");
    if (string.IsNullOrWhiteSpace(apiKey))
    {
        context.Information("No NuGet API key specified. Skipping publishing of NuGet packages");
        return;
    }

    var nugetPushSettings = new DotNetNuGetPushSettings
    {
        Source = url,
        ApiKey = apiKey,
    };

    foreach (var nugetPackageFile in GetFiles("./artifact/nuget/*.nupkg"))
        DotNetNuGetPush(nugetPackageFile.FullPath, nugetPushSettings);
});

Task("Publish")
    .IsDependentOn("Push")
    .WithCriteria(() => GetFiles("./artifact/nuget/**/*")?.Count > 0)
    .WithCriteria(() => GitHubActions.IsRunningOnGitHubActions)
    .WithCriteria(() => string.Equals("refs/heads/main", GitHubActions.Environment.Workflow.Ref, StringComparison.OrdinalIgnoreCase))
    .Does(async () =>
        await GitHubActions.Commands.UploadArtifact(Directory("./artifact/nuget"), $"Cake.MsDeploy.{buildVersion.Version}"));

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);
