using Cake.MsDeploy.Providers;
using Cake.MsDeploy.Providers.MsDeployProviders;
using Cake.MsDeploy.Tests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit.Providers
{
    public sealed class MsDeployProviderTests
    {
        public sealed class TheToCommandLineArgument
        {
            [Fact]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                var obj = new MsDeployProviderFixture();

                // When
                var result = Record.Exception(() => obj.AppendCommandLineArgument(null));

                // Then
                Assert.IsArgumentNullException(result, "sb");
            }

            [Theory]
            [MemberData("MsDeployProviderData")]
            public void Should_Append_Options(MsDeployProvider msdeployProvider, string expected)
            {
                //Given --> When
                var actual = msdeployProvider.ToCommandLineArgument();

                //Then
                Assert.Equal(expected, msdeployProvider.ToCommandLineArgument(), ignoreCase: true);
            }

            public static IEnumerable<object[]> MsDeployProviderData()
            {
                return new List<object[]>
                {
                    //Source
                    new object[]
                    {

                        new MsDeployProviderFixture
                        {
                                Path = @"d:\web\wwwroot",
                                AppendQuotesToPath = true,
                                Direction = Direction.source

                        },   // <------------- Indivdual Property to test
                        "-source:msdeploy-fixture=\"d:\\web\\wwwroot\""   // <------------- Expected  Result
                        
                    },
                    //Destination
                    new object[]
                    {
                        new MsDeployProviderFixture
                        {
                                AppendQuotesToPath = true,
                                AuthenticationType = AuthenticationScheme.NTLM,
                                ComputerName = "mycomputer.name.ext",
                                Direction = Direction.dest,
                                IncludeAcls = false,
                                Password = "tiger",
                                Username = "scott",
                                Path = "src/Application",
                                TempAgent = true

                        },   // <------------- Indivdual Property to test
                        "-dest:msdeploy-fixture=\"src/Application\",computerName=\"mycomputer.name.ext\",authtype=NTLM,userName=scott,password=tiger,includeAcls=false,tempAgent=true"   // <------------- Expected  Result
                    },
                    //Publish Settings
                    new object[]
                    {
                        new MsDeployProviderFixture
                        {
                             Path = "siteName",
                             AppendQuotesToPath = false,
                             Direction = Direction.dest,
                             PublishSettings = "d:\\dev.PublishSettings"

                        },   // <------------- Indivdual Property to test
                        "-dest:msdeploy-fixture=siteName,publishSettings=\"d:\\dev.PublishSettings\""   // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new AppHostAuthOverrideProvider
                        {
                                AppendQuotesToPath = true,
                                AuthenticationType = AuthenticationScheme.NTLM,
                                ComputerName = "mycomputer.name.ext",
                                Direction = Direction.dest,
                                IncludeAcls = false,
                                Password = "tiger",
                                Username = "scott",
                                Path = "src/Application",
                                TempAgent = true,
                                NetFxVersion = ""

                        },   // <------------- Indivdual Property to test
                        "-dest:appHostAuthOverride=\"src/Application\",computerName=\"mycomputer.name.ext\",authtype=NTLM,userName=scott,password=tiger,includeAcls=false,tempAgent=true"   // <------------- Expected  Result
                    },


    new object[]
    {
      new AppHostAuthOverrideProvider
      {
        Direction = Direction.dest,
        NetFxVersion = "RJ5NK4JAIG",

      },
      "-dest:appHostAuthOverride=,netFxVersion=\"RJ5NK4JAIG\""
    },

    new object[]
    {
      new AppHostConfigProvider
      {
        Direction = Direction.dest,
        AppOfflineTemplate = "UFCD7K6J2B",
    WebConfigEncryptProvider = "0OVC809HFC",

      },
      "-dest:appHostConfig=,appOfflineTemplate=\"UFCD7K6J2B\",webConfigEncryptProvider=\"0OVC809HFC\""
    },

    new object[]
    {
      new AppHostSchemaProvider
      {
        Direction = Direction.dest,

      },
      "-dest:appHostSchema="
    },

    new object[]
    {
      new AppPoolConfigProvider
      {
        Direction = Direction.dest,

      },
      "-dest:appPoolConfig="
    },

    new object[]
    {
      new AppPoolEnable32BitProvider
      {
        Direction = Direction.dest,
        Enable32Bit = false,

      },
      "-dest:appPoolEnable32Bit=,enable32Bit=false"
    },

    new object[]
    {
      new AppPoolNetFxProvider
      {
        Direction = Direction.dest,
        NetFxVersion = "4ENCQSPGJT",

      },
      "-dest:appPoolNetFx=,netFxVersion=\"4ENCQSPGJT\""
    },

    new object[]
    {
      new AppPoolPipelineProvider
      {
        Direction = Direction.dest,
        PipelineMode =  null,

      },
      "-dest:appPoolPipeline="
    },

    new object[]
    {
      new ArchiveDirProvider
      {
        Direction = Direction.dest,

      },
      "-dest:archiveDir="
    },

    new object[]
    {
      new AutoProvider
      {
        Direction = Direction.dest,

      },
      "-dest:auto"
    },

    new object[]
    {
      new BackupManagerProvider
      {
        Direction = Direction.dest,
        ConnectionString = "FGGIK1RUUF",
    UseLatest = false,

      },
      "-dest:backupManager=,connectionString=\"FGGIK1RUUF\",useLatest=false"
    },

    new object[]
    {
      new BackupSettingsProvider
      {
        Direction = Direction.dest,
        Enabled = false,
    NumberOfBackups = 10,
    ContinueSyncOnBackupFailure = false,
    AddExcludedProviders = new string[] { "430YVDY3PT", "ASDFASDFASDFA" },

      },
      "-dest:backupSettings=,enabled=false,numberOfBackups=10,continueSyncOnBackupFailure=false,addExcludedProviders=430YVDY3PT;ASDFASDFASDFA"
    },

    new object[]
    {
      new CertProvider
      {
        Direction = Direction.dest,

      },
      "-dest:cert="
    },

    new object[]
    {
      new CertStoreSettingsProvider
      {
        Direction = Direction.dest,

      },
      "-dest:certStoreSettings="
    },

    new object[]
    {
      new ComObject32Provider
      {
        Direction = Direction.dest,

      },
      "-dest:comObject32="
    },

    new object[]
    {
      new ComObject64Provider
      {
        Direction = Direction.dest,

      },
      "-dest:comObject64="
    },

    new object[]
    {
      new ContentPathAspNetCoreProvider
      {
        Direction = Direction.dest,

      },
      "-dest:contentPathAspNetCore="
    },

    new object[]
    {
      new ContentPathLibProvider
      {
        Direction = Direction.dest,
        SyncPackageTimeStamps = false,

      },
      "-dest:contentPathLib=,syncPackageTimeStamps=false"
    },

    new object[]
    {
      new ContentPathProvider
      {
        Direction = Direction.dest,
        AppOfflineTemplate = "5C4FLQ1AXO",
    WebConfigEncryptProvider = "509J5THN1G",
    SyncPackageTimeStamps = false,

      },
      "-dest:contentPath=,appOfflineTemplate=\"5C4FLQ1AXO\",webConfigEncryptProvider=\"509J5THN1G\",syncPackageTimeStamps=false"
    },

    new object[]
    {
      new CreateAppProvider
      {
        Direction = Direction.dest,
        ManagedRuntimeVersion = "JPWAIBOYQM",
    Enable32BitAppOnWin64 = false,
    ManagedPipelineMode =  null,

      },
      "-dest:createApp=,managedRuntimeVersion=\"JPWAIBOYQM\",enable32BitAppOnWin64=false"
    },

    new object[]
    {
      new DbDacFxProvider
      {
        Direction = Direction.dest,
        DropDestinationDatabase = false,
    DacpacAction =  DacpacAction.Script,
    IncludeData = false,
    CommandTimeout = 10,
    AllowDropBlockingAssemblies = false,
    AllowIncompatiblePlatform = false,
    BackupDatabaseBeforeChanges = false,
    BlockOnPossibleDataLoss = false,
    BlockWhenDriftDetected = false,
    CommentOutSetVarDeclarations = false,
    CompareUsingTargetCollation = false,
    CreateNewDatabase = false,
    DeployDatabaseInSingleUserMode = false,
    DisableAndReenableDdlTriggers = false,
    DoNotAlterChangeDataCaptureObjects = false,
    DoNotAlterReplicatedObjects = false,
    DropConstraintsNotInSource = false,
    DropDmlTriggersNotInSource = false,
    DropExtendedPropertiesNotInSource = false,
    DropIndexesNotInSource = false,
    DropObjectsNotInSource = false,
    DropPermissionsNotInSource = false,
    DropRoleMembersNotInSource = false,
    DropStatisticsNotInSource = false,
    GenerateSmartDefaults = false,
    IgnoreAnsiNulls = false,
    IgnoreAuthorizer = false,
    IgnoreColumnCollation = false,
    IgnoreComments = false,
    IgnoreCryptographicProviderFilePath = false,
    IgnoreDdlTriggerOrder = false,
    IgnoreDdlTriggerState = false,
    IgnoreDefaultSchema = false,
    IgnoreDmlTriggerOrder = false,
    IgnoreDmlTriggerState = false,
    IgnoreExtendedProperties = false,
    IgnoreFileAndLogFilePath = false,
    IgnoreFilegroupPlacement = false,
    IgnoreFileSize = false,
    IgnoreFillFactor = false,
    IgnoreFullTextCatalogFilePath = false,
    IgnoreIdentitySeed = false,
    IgnoreIncrement = false,
    IgnoreIndexOptions = false,
    IgnoreIndexPadding = false,
    IgnoreKeywordCasing = false,
    IgnoreLockHintsOnIndexes = false,
    IgnoreLoginSids = false,
    IgnoreNotForReplication = false,
    IgnoreObjectPlacementOnPartitionScheme = false,
    IgnorePartitionSchemes = false,
    IgnorePermissions = false,
    IgnoreQuotedIdentifiers = false,
    IgnoreRoleMembership = false,
    IgnoreRouteLifetime = false,
    IgnoreSemicolonBetweenStatements = false,
    IgnoreTableOptions = false,
    IgnoreUserSettingsObjects = false,
    IgnoreWhitespace = false,
    IgnoreWithNocheckOnCheckConstraints = false,
    IgnoreWithNocheckOnForeignKeys = false,
    IncludeCompositeObjects = false,
    IncludeTransactionalScripts = false,
    NoAlterStatementsToChangeClrTypes = false,
    PopulateFilesOnFileGroups = false,
    RegisterDataTierApplication = false,
    RunDeploymentPlanExecutors = false,
    ScriptDatabaseCollation = false,
    ScriptDatabaseCompatibility = false,
    ScriptDatabaseOptions = false,
    ScriptDeployStateChecks = false,
    ScriptFileSize = false,
    ScriptNewConstraintValidation = false,
    ScriptRefreshModule = false,
    TreatVerificationErrorsAsWarnings = false,
    UnmodifiableObjectWarnings = false,
    VerifyCollationCompatibility = false,
    VerifyDeployment = false,

      },
      "-dest:dbDacFx=,dropDestinationDatabase=false,dacpacAction=Script,includeData=false,commandTimeout=10,allowDropBlockingAssemblies=false,allowIncompatiblePlatform=false,backupDatabaseBeforeChanges=false,blockOnPossibleDataLoss=false,blockWhenDriftDetected=false,commentOutSetVarDeclarations=false,compareUsingTargetCollation=false,createNewDatabase=false,deployDatabaseInSingleUserMode=false,disableAndReenableDdlTriggers=false,doNotAlterChangeDataCaptureObjects=false,doNotAlterReplicatedObjects=false,dropConstraintsNotInSource=false,dropDmlTriggersNotInSource=false,dropExtendedPropertiesNotInSource=false,dropIndexesNotInSource=false,dropObjectsNotInSource=false,dropPermissionsNotInSource=false,dropRoleMembersNotInSource=false,dropStatisticsNotInSource=false,generateSmartDefaults=false,ignoreAnsiNulls=false,ignoreAuthorizer=false,ignoreColumnCollation=false,ignoreComments=false,ignoreCryptographicProviderFilePath=false,ignoreDdlTriggerOrder=false,ignoreDdlTriggerState=false,ignoreDefaultSchema=false,ignoreDmlTriggerOrder=false,ignoreDmlTriggerState=false,ignoreExtendedProperties=false,ignoreFileAndLogFilePath=false,ignoreFilegroupPlacement=false,ignoreFileSize=false,ignoreFillFactor=false,ignoreFullTextCatalogFilePath=false,ignoreIdentitySeed=false,ignoreIncrement=false,ignoreIndexOptions=false,ignoreIndexPadding=false,ignoreKeywordCasing=false,ignoreLockHintsOnIndexes=false,ignoreLoginSids=false,ignoreNotForReplication=false,ignoreObjectPlacementOnPartitionScheme=false,ignorePartitionSchemes=false,ignorePermissions=false,ignoreQuotedIdentifiers=false,ignoreRoleMembership=false,ignoreRouteLifetime=false,ignoreSemicolonBetweenStatements=false,ignoreTableOptions=false,ignoreUserSettingsObjects=false,ignoreWhitespace=false,ignoreWithNocheckOnCheckConstraints=false,ignoreWithNocheckOnForeignKeys=false,includeCompositeObjects=false,includeTransactionalScripts=false,noAlterStatementsToChangeClrTypes=false,populateFilesOnFileGroups=false,registerDataTierApplication=false,runDeploymentPlanExecutors=false,scriptDatabaseCollation=false,scriptDatabaseCompatibility=false,scriptDatabaseOptions=false,scriptDeployStateChecks=false,scriptFileSize=false,scriptNewConstraintValidation=false,scriptRefreshModule=false,treatVerificationErrorsAsWarnings=false,unmodifiableObjectWarnings=false,verifyCollationCompatibility=false,verifyDeployment=false"
    },

    new object[]
    {
      new DbFullSqlProvider
      {
        Direction = Direction.dest,
        DropDestinationDatabase = false,
    ForceScriptDatabase = false,
    ScriptDropsFirst = false,
    Transacted = false,
    SqlCe = false,
    SkipSqlCmdParsing = false,
    ObjectList = "4V0ZYDMA64",
    CreateDBConnectionString = "9Q6GJD3Q3B",
    CommandDelimiter = "5KCIKPP47J",
    RemoveCommandDelimiter = false,
    StoreConnectionStringPassword = false,
    CommandTimeout = 10,

      },
      "-dest:dbFullSql=,dropDestinationDatabase=false,forceScriptDatabase=false,scriptDropsFirst=false,transacted=false,sqlCe=false,skipSqlCmdParsing=false,objectList=\"4V0ZYDMA64\",createDBConnectionString=\"9Q6GJD3Q3B\",commandDelimiter=\"5KCIKPP47J\",removeCommandDelimiter=false,storeConnectionStringPassword=false,commandTimeout=10"
    },

    new object[]
    {
      new DbMySqlProvider
      {
        Direction = Direction.dest,
        CreateDBConnectionString = "CDUKTK9KV1",
    IncludeData = false,
    Transacted = false,
    CommandDelimiter = "HGQ6G2SQ0E",
    RemoveCommandDelimiter = false,
    WaitAttempts = 10,
    WaitInterval = 10,
    CommandTimeout = 10,
    IncludeSchema = false,

      },
      "-dest:dbMySql=,createDBConnectionString=\"CDUKTK9KV1\",includeData=false,transacted=false,commandDelimiter=\"HGQ6G2SQ0E\",removeCommandDelimiter=false,waitAttempts=10,waitInterval=10,commandTimeout=10,includeSchema=false"
    },

    new object[]
    {
      new DbSqliteProvider
      {
        Direction = Direction.dest,
        CreateDBConnectionString = "I75OQTSSPI",
    IncludeData = false,
    Transacted = false,
    CommandDelimiter = "YRDX266WW9",
    RemoveCommandDelimiter = false,
    WaitAttempts = 10,
    WaitInterval = 10,
    CommandTimeout = 10,

      },
      "-dest:dbSqlite=,createDBConnectionString=\"I75OQTSSPI\",includeData=false,transacted=false,commandDelimiter=\"YRDX266WW9\",removeCommandDelimiter=false,waitAttempts=10,waitInterval=10,commandTimeout=10"
    },

    new object[]
    {
      new DirPathProvider
      {
        Direction = Direction.dest,
        IgnoreErrors = "DT5B4Z4GBR",
    FirstChangeUSN = 10,
    Incremental = false,

      },
      "-dest:dirPath=,ignoreErrors=\"DT5B4Z4GBR\",firstChangeUSN=10,incremental=false"
    },

    new object[]
    {
      new FilePathProvider
      {
        Direction = Direction.dest,
        IgnoreErrors = "79D2BEHF49",

      },
      "-dest:filePath=,ignoreErrors=\"79D2BEHF49\""
    },

    new object[]
    {
      new GacAssemblyProvider
      {
        Direction = Direction.dest,

      },
      "-dest:gacAssembly="
    },

    new object[]
    {
      new GacInstallProvider
      {
        Direction = Direction.dest,

      },
      "-dest:gacInstall="
    },

    new object[]
    {
      new IisAppProvider
      {
        Direction = Direction.dest,
        SkipAppCreation = false,
    ManagedRuntimeVersion = "1R4MDZD2DK",
    Enable32BitAppOnWin64 = false,
    ManagedPipelineMode = "6631AZB4U1",
    AppOfflineTemplate = "YLQ7LYOLVX",
    WebConfigEncryptProvider = "Y01WHWYS7E",
    SyncPackageTimeStamps = "VBD1VAFM2M",

      },
      "-dest:iisApp=,skipAppCreation=false,managedRuntimeVersion=\"1R4MDZD2DK\",enable32BitAppOnWin64=false,managedPipelineMode=\"6631AZB4U1\",appOfflineTemplate=\"YLQ7LYOLVX\",webConfigEncryptProvider=\"Y01WHWYS7E\",syncPackageTimeStamps=\"VBD1VAFM2M\""
    },

    new object[]
    {
      new MachineConfig32Provider
      {
        Direction = Direction.dest,
        NetFxVersion = "DNVDKPA7BO",

      },
      "-dest:machineConfig32=,netFxVersion=\"DNVDKPA7BO\""
    },

    new object[]
    {
      new MachineConfig64Provider
      {
        Direction = Direction.dest,
        NetFxVersion = "L2GPVFEGTO",

      },
      "-dest:machineConfig64=,netFxVersion=\"L2GPVFEGTO\""
    },

    new object[]
    {
      new ManifestProvider
      {
        Direction = Direction.dest,
        SkipInvalid = false,

      },
      "-dest:manifest=,skipInvalid=false"
    },

    new object[]
    {
      new MetaKeyProvider
      {
        Direction = Direction.dest,
        MetadataGetInherited = false,
    UseRealAbo = false,

      },
      "-dest:metaKey=,metadataGetInherited=false,useRealAbo=false"
    },

    new object[]
    {
      new PackageProvider
      {
        Direction = Direction.dest,

      },
      "-dest:package="
    },

    new object[]
    {
      new RecycleAppProvider
      {
        Direction = Direction.dest,
        RecycleMode =  null,
    Timeout = 10,

      },
      "-dest:recycleApp=,timeout=10"
    },

    new object[]
    {
      new RegKeyProvider
      {
        Direction = Direction.dest,

      },
      "-dest:regKey="
    },

    new object[]
    {
      new RegValueProvider
      {
        Direction = Direction.dest,

      },
      "-dest:regValue="
    },

    new object[]
    {
      new RootWebConfig32Provider
      {
        Direction = Direction.dest,
        NetFxVersion = "AS6PFWIZMK",

      },
      "-dest:rootWebConfig32=,netFxVersion=\"AS6PFWIZMK\""
    },

    new object[]
    {
      new RootWebConfig64Provider
      {
        Direction = Direction.dest,
        NetFxVersion = "SCSJULFYM1",

      },
      "-dest:rootWebConfig64=,netFxVersion=\"SCSJULFYM1\""
    },

    new object[]
    {
      new RunCommandProvider
      {
        Direction = Direction.dest,
        DontUseCommandExe = false,
    DontUseJobObject = false,
    WaitAttempts = 10,
    WaitInterval = 10,
    SuccessReturnCodes = "V1RS335XGQ",

      },
      "-dest:runCommand=,dontUseCommandExe=false,dontUseJobObject=false,waitAttempts=10,waitInterval=10,successReturnCodes=\"V1RS335XGQ\""
    },

    new object[]
    {
      new SetAclProvider
      {
        Direction = Direction.dest,
        SetAclUser = "692NLURF7X",
    SetAclAccess = "GLU05IJ74J",
    SetAclResourceType =  null,

      },
      "-dest:setAcl=,setAclUser=\"692NLURF7X\",setAclAccess=\"GLU05IJ74J\""
    },

    new object[]
    {
      new UrlScanConfigProvider
      {
        Direction = Direction.dest,

      },
      "-dest:urlScanConfig="
    },

    new object[]
    {
      new WebServer60Provider
      {
        Direction = Direction.dest,

      },
      "-dest:webServer60="
    },

    new object[]
    {
      new WebServerProvider
      {
        Direction = Direction.dest,

      },
      "-dest:webServer="
    }


                };
            }
        }
    }
}