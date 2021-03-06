﻿using Cake.MsDeploy.Parameters;
using Cake.MsDeploy.Providers;
using Cake.MsDeploy.Providers.MsDeployProviders;
using Cake.MsDeploy.Tests.Fixture;
using Cake.Testing;
using System.Collections.Generic;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit
{
    public sealed class MsDeployRunnerTests
    {
        public sealed class TheDeployMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.Settings = null;
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                AssertEx.IsArgumentNullException(result, "settings");
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                AssertEx.IsCakeException(result, "Web Deploy: Process was not started.");
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                AssertEx.IsCakeException(result, "Web Deploy: Process returned an error (exit code 1).");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new MsDeployFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-verb:sync", result.Args);
            }

            [Fact]
            public void Should_Add_Source_Path_And_Content_Providers()
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.Settings = new MsDeploySettings
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
                    UseCheckSum = true,
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
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("-verb:sync -source:package=\"./src/Application.zip\" -dest:auto,computerName=\"cake.computerName.com\",authtype=NTLM,includeAcls=false,tempAgent=true -setParam:name=\"IIS Web Application Name\",value=\"www.cake.com\" -retryAttempts:5 -retryInterval:5000 -whatif -allowUntrusted -useCheckSum -preSync:runCommand=\"%windir%\\System32\\inetsrv\\appcmd.exe stop APPPOOL NameOfAppPool\" -postSync:runCommand=\"%windir%\\System32\\inetsrv\\appcmd.exe start APPPOOL NameOfAppPool\"", result.Args);
            }

			[Fact]
			public void Should_Add_Command_Provider_Additional_Settings()
			{
				// Given
				var fixture = new MsDeployFixture();
				fixture.Settings = new MsDeploySettings
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
					UseCheckSum = true,
					PreSyncCommand = new CommandProvider
					{
						Path = "%windir%\\System32\\inetsrv\\appcmd.exe stop APPPOOL NameOfAppPool",
						WaitInterval = 60000
					},
					PostSyncCommand = new CommandProvider
					{
						Path = "%windir%\\System32\\inetsrv\\appcmd.exe start APPPOOL NameOfAppPool",
						WaitInterval = 15000
					},
					WhatIf = true,
					SetParams = new List<SetParameter>
					{
						new SetParameter
						{
						   Name = "IIS Web Application Name",
						   Value = "www.cake.com"
						}
					}
				};

				// When
				var result = fixture.Run();

				// Then
				Assert.Equal("-verb:sync -source:package=\"./src/Application.zip\" -dest:auto,computerName=\"cake.computerName.com\",authtype=NTLM,includeAcls=false,tempAgent=true -setParam:name=\"IIS Web Application Name\",value=\"www.cake.com\" -retryAttempts:5 -retryInterval:5000 -whatif -allowUntrusted -useCheckSum -preSync:runCommand=\"%windir%\\System32\\inetsrv\\appcmd.exe stop APPPOOL NameOfAppPool\",waitInterval=60000 -postSync:runCommand=\"%windir%\\System32\\inetsrv\\appcmd.exe start APPPOOL NameOfAppPool\",waitInterval=15000", result.Args);
			}


			[Fact]
			public void Should_Add_DisableLinks()
			{
				// Given
				var fixture = new MsDeployFixture();
				fixture.Settings = new MsDeploySettings
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
					UseCheckSum = true,
					WhatIf = true,
					SetParams = new List<SetParameter>
					{
						new SetParameter
						{
						   Name = "IIS Web Application Name",
						   Value = "www.cake.com"
						}
					},
					DisableLinks = new string[] { "AppPoolExtension", "ContentExtension", "CertificateExtension" },
				};

				// When
				var result = fixture.Run();

				// Then
				Assert.Equal("-verb:sync -source:package=\"./src/Application.zip\" -dest:auto,computerName=\"cake.computerName.com\",authtype=NTLM,includeAcls=false,tempAgent=true -setParam:name=\"IIS Web Application Name\",value=\"www.cake.com\" -disableLink:AppPoolExtension -disableLink:ContentExtension -disableLink:CertificateExtension -retryAttempts:5 -retryInterval:5000 -whatif -allowUntrusted -useCheckSum", result.Args);
			}

			[Fact]
			public void Should_Add_EnableLinks_DisableLinks()
			{
				// Given
				var fixture = new MsDeployFixture();
				fixture.Settings = new MsDeploySettings
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
					UseCheckSum = true,
					WhatIf = true,
					SetParams = new List<SetParameter>
					{
						new SetParameter
						{
						   Name = "IIS Web Application Name",
						   Value = "www.cake.com"
						}
					},
					EnableLinks = new string[] { "AppPoolExtension" },
					DisableLinks = new string[] { "ContentExtension", "CertificateExtension" },
				};

				// When
				var result = fixture.Run();

				// Then
				Assert.Equal("-verb:sync -source:package=\"./src/Application.zip\" -dest:auto,computerName=\"cake.computerName.com\",authtype=NTLM,includeAcls=false,tempAgent=true -setParam:name=\"IIS Web Application Name\",value=\"www.cake.com\" -enableLink:AppPoolExtension -disableLink:ContentExtension -disableLink:CertificateExtension -retryAttempts:5 -retryInterval:5000 -whatif -allowUntrusted -useCheckSum", result.Args);
			}

			[Fact]
			public void Should_Add_EnableLinks()
			{
				// Given
				var fixture = new MsDeployFixture();
				fixture.Settings = new MsDeploySettings
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
					UseCheckSum = true,
					WhatIf = true,
					SetParams = new List<SetParameter>
					{
						new SetParameter
						{
						   Name = "IIS Web Application Name",
						   Value = "www.cake.com"
						}
					},
					EnableLinks = new string[] { "AppPoolExtension" }
				};

				// When
				var result = fixture.Run();

				// Then
				Assert.Equal("-verb:sync -source:package=\"./src/Application.zip\" -dest:auto,computerName=\"cake.computerName.com\",authtype=NTLM,includeAcls=false,tempAgent=true -setParam:name=\"IIS Web Application Name\",value=\"www.cake.com\" -enableLink:AppPoolExtension -retryAttempts:5 -retryInterval:5000 -whatif -allowUntrusted -useCheckSum", result.Args);
			}

            [Theory]
            [InlineData(new[] { "AppOffline" }, "-verb:sync -source:dirPath=\"./Publish\" -dest:dirPath=\"./Deploy\" -enableRule:AppOffline -whatif")]
            [InlineData(new[] { "AppOffline", "DoNotDelete" }, "-verb:sync -source:dirPath=\"./Publish\" -dest:dirPath=\"./Deploy\" -enableRule:AppOffline -enableRule:DoNotDelete -whatif")]
            public void Should_Add_EnableRules(string[] rules, string expected)
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.Settings = new MsDeploySettings
                {
                    Verb = Operation.Sync,
                    Source = new DirPathProvider
                    {
                        Direction = Direction.source,
                        Path = "./Publish"
                    },
                    Destination = new DirPathProvider
                    {
                        Direction = Direction.dest,
                        Path = "./Deploy"
                    },
                    WhatIf = true,
                    EnableRules = rules
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Theory]
            [InlineData(new[] { "BackupRule" }, "-verb:sync -source:dirPath=\"./Publish\" -dest:dirPath=\"./Deploy\" -disableRule:BackupRule -whatif")]
            [InlineData(new[] { "BackupRule", "DefaultDependencyCheck" }, "-verb:sync -source:dirPath=\"./Publish\" -dest:dirPath=\"./Deploy\" -disableRule:BackupRule -disableRule:DefaultDependencyCheck -whatif")]
            public void Should_Add_DisableRules(string[] rules, string expected)
            {
                // Given
                var fixture = new MsDeployFixture();
                fixture.Settings = new MsDeploySettings
                {
                    Verb = Operation.Sync,
                    Source = new DirPathProvider
                    {
                        Direction = Direction.source,
                        Path = "./Publish"
                    },
                    Destination = new DirPathProvider
                    {
                        Direction = Direction.dest,
                        Path = "./Deploy"
                    },
                    WhatIf = true,
                    DisableRules = rules
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
	}
}
