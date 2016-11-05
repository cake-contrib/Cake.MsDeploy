using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    ///  Deploy SQL database using DACFx API
    /// </summary>
    /// <code>
    ///   msdeploy.exe -verb:sync -source:dbDacFx="Data Source=.;Integrated Security=SSPI;Initial Catalog=Northwind" -dest:dbDacFx=c:\Northwind.dacpac
    /// </code>
    public class DbDacFxProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "dbDacFx";
            }
        }


        /// <summary>
        /// A true or false value for the 'dropDestinationDatabase' setting.
        /// </summary>
        public bool? DropDestinationDatabase { get; set; }

        /// <summary>
        /// A value that is one of 'Deploy, Script, Report'.
        /// </summary>
        public DacpacAction DacpacAction { get; set; }

        /// <summary>
        /// A true or false value for the 'includeData' setting.
        /// </summary>
        public bool? IncludeData { get; set; }

        /// <summary>
        /// An integer value for the 'commandTimeout' setting.
        /// </summary>
        public int? CommandTimeout { get; set; }

        /// <summary>
        /// A true or false value for the 'AllowDropBlockingAssemblies' setting.
        /// </summary>
        public bool? AllowDropBlockingAssemblies { get; set; }

        /// <summary>
        /// A true or false value for the 'AllowIncompatiblePlatform' setting.
        /// </summary>
        public bool? AllowIncompatiblePlatform { get; set; }

        /// <summary>
        /// A true or false value for the 'BackupDatabaseBeforeChanges' setting.
        /// </summary>
        public bool? BackupDatabaseBeforeChanges { get; set; }

        /// <summary>
        /// A true or false value for the 'BlockOnPossibleDataLoss' setting.
        /// </summary>
        public bool? BlockOnPossibleDataLoss { get; set; }

        /// <summary>
        /// A true or false value for the 'BlockWhenDriftDetected' setting.
        /// </summary>
        public bool? BlockWhenDriftDetected { get; set; }

        /// <summary>
        /// A true or false value for the 'CommentOutSetVarDeclarations' setting.
        /// </summary>
        public bool? CommentOutSetVarDeclarations { get; set; }

        /// <summary>
        /// A true or false value for the 'CompareUsingTargetCollation' setting.
        /// </summary>
        public bool? CompareUsingTargetCollation { get; set; }

        /// <summary>
        /// A true or false value for the 'CreateNewDatabase' setting.
        /// </summary>
        public bool? CreateNewDatabase { get; set; }

        /// <summary>
        /// A true or false value for the 'DeployDatabaseInSingleUserMode' setting.
        /// </summary>
        public bool? DeployDatabaseInSingleUserMode { get; set; }

        /// <summary>
        /// A true or false value for the 'DisableAndReenableDdlTriggers' setting.
        /// </summary>
        public bool? DisableAndReenableDdlTriggers { get; set; }

        /// <summary>
        /// A true or false value for the 'DoNotAlterChangeDataCaptureObjects' setting.
        /// </summary>
        public bool? DoNotAlterChangeDataCaptureObjects { get; set; }

        /// <summary>
        /// A true or false value for the 'DoNotAlterReplicatedObjects' setting.
        /// </summary>
        public bool? DoNotAlterReplicatedObjects { get; set; }

        /// <summary>
        /// A true or false value for the 'DropConstraintsNotInSource' setting.
        /// </summary>
        public bool? DropConstraintsNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropDmlTriggersNotInSource' setting.
        /// </summary>
        public bool? DropDmlTriggersNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropExtendedPropertiesNotInSource' setting.
        /// </summary>
        public bool? DropExtendedPropertiesNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropIndexesNotInSource' setting.
        /// </summary>
        public bool? DropIndexesNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropObjectsNotInSource' setting.
        /// </summary>
        public bool? DropObjectsNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropPermissionsNotInSource' setting.
        /// </summary>
        public bool? DropPermissionsNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropRoleMembersNotInSource' setting.
        /// </summary>
        public bool? DropRoleMembersNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'DropStatisticsNotInSource' setting.
        /// </summary>
        public bool? DropStatisticsNotInSource { get; set; }

        /// <summary>
        /// A true or false value for the 'GenerateSmartDefaults' setting.
        /// </summary>
        public bool? GenerateSmartDefaults { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreAnsiNulls' setting.
        /// </summary>
        public bool? IgnoreAnsiNulls { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreAuthorizer' setting.
        /// </summary>
        public bool? IgnoreAuthorizer { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreColumnCollation' setting.
        /// </summary>
        public bool? IgnoreColumnCollation { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreComments' setting.
        /// </summary>
        public bool? IgnoreComments { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreCryptographicProviderFilePath' setting.
        /// </summary>
        public bool? IgnoreCryptographicProviderFilePath { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreDdlTriggerOrder' setting.
        /// </summary>
        public bool? IgnoreDdlTriggerOrder { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreDdlTriggerState' setting.
        /// </summary>
        public bool? IgnoreDdlTriggerState { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreDefaultSchema' setting.
        /// </summary>
        public bool? IgnoreDefaultSchema { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreDmlTriggerOrder' setting.
        /// </summary>
        public bool? IgnoreDmlTriggerOrder { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreDmlTriggerState' setting.
        /// </summary>
        public bool? IgnoreDmlTriggerState { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreExtendedProperties' setting.
        /// </summary>
        public bool? IgnoreExtendedProperties { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreFileAndLogFilePath' setting.
        /// </summary>
        public bool? IgnoreFileAndLogFilePath { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreFilegroupPlacement' setting.
        /// </summary>
        public bool? IgnoreFilegroupPlacement { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreFileSize' setting.
        /// </summary>
        public bool? IgnoreFileSize { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreFillFactor' setting.
        /// </summary>
        public bool? IgnoreFillFactor { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreFullTextCatalogFilePath' setting.
        /// </summary>
        public bool? IgnoreFullTextCatalogFilePath { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreIdentitySeed' setting.
        /// </summary>
        public bool? IgnoreIdentitySeed { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreIncrement' setting.
        /// </summary>
        public bool? IgnoreIncrement { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreIndexOptions' setting.
        /// </summary>
        public bool? IgnoreIndexOptions { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreIndexPadding' setting.
        /// </summary>
        public bool? IgnoreIndexPadding { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreKeywordCasing' setting.
        /// </summary>
        public bool? IgnoreKeywordCasing { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreLockHintsOnIndexes' setting.
        /// </summary>
        public bool? IgnoreLockHintsOnIndexes { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreLoginSids' setting.
        /// </summary>
        public bool? IgnoreLoginSids { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreNotForReplication' setting.
        /// </summary>
        public bool? IgnoreNotForReplication { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreObjectPlacementOnPartitionScheme' setting.
        /// </summary>
        public bool? IgnoreObjectPlacementOnPartitionScheme { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnorePartitionSchemes' setting.
        /// </summary>
        public bool? IgnorePartitionSchemes { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnorePermissions' setting.
        /// </summary>
        public bool? IgnorePermissions { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreQuotedIdentifiers' setting.
        /// </summary>
        public bool? IgnoreQuotedIdentifiers { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreRoleMembership' setting.
        /// </summary>
        public bool? IgnoreRoleMembership { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreRouteLifetime' setting.
        /// </summary>
        public bool? IgnoreRouteLifetime { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreSemicolonBetweenStatements' setting.
        /// </summary>
        public bool? IgnoreSemicolonBetweenStatements { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreTableOptions' setting.
        /// </summary>
        public bool? IgnoreTableOptions { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreUserSettingsObjects' setting.
        /// </summary>
        public bool? IgnoreUserSettingsObjects { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreWhitespace' setting.
        /// </summary>
        public bool? IgnoreWhitespace { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreWithNocheckOnCheckConstraints' setting.
        /// </summary>
        public bool? IgnoreWithNocheckOnCheckConstraints { get; set; }

        /// <summary>
        /// A true or false value for the 'IgnoreWithNocheckOnForeignKeys' setting.
        /// </summary>
        public bool? IgnoreWithNocheckOnForeignKeys { get; set; }

        /// <summary>
        /// A true or false value for the 'IncludeCompositeObjects' setting.
        /// </summary>
        public bool? IncludeCompositeObjects { get; set; }

        /// <summary>
        /// A true or false value for the 'IncludeTransactionalScripts' setting.
        /// </summary>
        public bool? IncludeTransactionalScripts { get; set; }

        /// <summary>
        /// A true or false value for the 'NoAlterStatementsToChangeClrTypes' setting.
        /// </summary>
        public bool? NoAlterStatementsToChangeClrTypes { get; set; }

        /// <summary>
        /// A true or false value for the 'PopulateFilesOnFileGroups' setting.
        /// </summary>
        public bool? PopulateFilesOnFileGroups { get; set; }

        /// <summary>
        /// A true or false value for the 'RegisterDataTierApplication' setting.
        /// </summary>
        public bool? RegisterDataTierApplication { get; set; }

        /// <summary>
        /// A true or false value for the 'RunDeploymentPlanExecutors' setting.
        /// </summary>
        public bool? RunDeploymentPlanExecutors { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptDatabaseCollation' setting.
        /// </summary>
        public bool? ScriptDatabaseCollation { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptDatabaseCompatibility' setting.
        /// </summary>
        public bool? ScriptDatabaseCompatibility { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptDatabaseOptions' setting.
        /// </summary>
        public bool? ScriptDatabaseOptions { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptDeployStateChecks' setting.
        /// </summary>
        public bool? ScriptDeployStateChecks { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptFileSize' setting.
        /// </summary>
        public bool? ScriptFileSize { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptNewConstraintValidation' setting.
        /// </summary>
        public bool? ScriptNewConstraintValidation { get; set; }

        /// <summary>
        /// A true or false value for the 'ScriptRefreshModule' setting.
        /// </summary>
        public bool? ScriptRefreshModule { get; set; }

        /// <summary>
        /// A true or false value for the 'TreatVerificationErrorsAsWarnings' setting.
        /// </summary>
        public bool? TreatVerificationErrorsAsWarnings { get; set; }

        /// <summary>
        /// A true or false value for the 'UnmodifiableObjectWarnings' setting.
        /// </summary>
        public bool? UnmodifiableObjectWarnings { get; set; }

        /// <summary>
        /// A true or false value for the 'VerifyCollationCompatibility' setting.
        /// </summary>
        public bool? VerifyCollationCompatibility { get; set; }

        /// <summary>
        /// A true or false value for the 'VerifyDeployment' setting.
        /// </summary>
        public bool? VerifyDeployment { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (DropDestinationDatabase.HasValue)
                sb.AppendFormat(",dropDestinationDatabase={0}", DropDestinationDatabase);
            
             sb.AppendFormat(",dacpacAction={0}", DacpacAction);

            if (IncludeData.HasValue)
                sb.AppendFormat(",includeData={0}", IncludeData);

            if (CommandTimeout.HasValue)
                sb.AppendFormat(",commandTimeout={0}", CommandTimeout);

            if (AllowDropBlockingAssemblies.HasValue)
                sb.AppendFormat(",allowDropBlockingAssemblies={0}", AllowDropBlockingAssemblies);

            if (AllowIncompatiblePlatform.HasValue)
                sb.AppendFormat(",allowIncompatiblePlatform={0}", AllowIncompatiblePlatform);

            if (BackupDatabaseBeforeChanges.HasValue)
                sb.AppendFormat(",backupDatabaseBeforeChanges={0}", BackupDatabaseBeforeChanges);

            if (BlockOnPossibleDataLoss.HasValue)
                sb.AppendFormat(",blockOnPossibleDataLoss={0}", BlockOnPossibleDataLoss);

            if (BlockWhenDriftDetected.HasValue)
                sb.AppendFormat(",blockWhenDriftDetected={0}", BlockWhenDriftDetected);

            if (CommentOutSetVarDeclarations.HasValue)
                sb.AppendFormat(",commentOutSetVarDeclarations={0}", CommentOutSetVarDeclarations);

            if (CompareUsingTargetCollation.HasValue)
                sb.AppendFormat(",compareUsingTargetCollation={0}", CompareUsingTargetCollation);

            if (CreateNewDatabase.HasValue)
                sb.AppendFormat(",createNewDatabase={0}", CreateNewDatabase);

            if (DeployDatabaseInSingleUserMode.HasValue)
                sb.AppendFormat(",deployDatabaseInSingleUserMode={0}", DeployDatabaseInSingleUserMode);

            if (DisableAndReenableDdlTriggers.HasValue)
                sb.AppendFormat(",disableAndReenableDdlTriggers={0}", DisableAndReenableDdlTriggers);

            if (DoNotAlterChangeDataCaptureObjects.HasValue)
                sb.AppendFormat(",doNotAlterChangeDataCaptureObjects={0}", DoNotAlterChangeDataCaptureObjects);

            if (DoNotAlterReplicatedObjects.HasValue)
                sb.AppendFormat(",doNotAlterReplicatedObjects={0}", DoNotAlterReplicatedObjects);

            if (DropConstraintsNotInSource.HasValue)
                sb.AppendFormat(",dropConstraintsNotInSource={0}", DropConstraintsNotInSource);

            if (DropDmlTriggersNotInSource.HasValue)
                sb.AppendFormat(",dropDmlTriggersNotInSource={0}", DropDmlTriggersNotInSource);

            if (DropExtendedPropertiesNotInSource.HasValue)
                sb.AppendFormat(",dropExtendedPropertiesNotInSource={0}", DropExtendedPropertiesNotInSource);

            if (DropIndexesNotInSource.HasValue)
                sb.AppendFormat(",dropIndexesNotInSource={0}", DropIndexesNotInSource);

            if (DropObjectsNotInSource.HasValue)
                sb.AppendFormat(",dropObjectsNotInSource={0}", DropObjectsNotInSource);

            if (DropPermissionsNotInSource.HasValue)
                sb.AppendFormat(",dropPermissionsNotInSource={0}", DropPermissionsNotInSource);

            if (DropRoleMembersNotInSource.HasValue)
                sb.AppendFormat(",dropRoleMembersNotInSource={0}", DropRoleMembersNotInSource);

            if (DropStatisticsNotInSource.HasValue)
                sb.AppendFormat(",dropStatisticsNotInSource={0}", DropStatisticsNotInSource);

            if (GenerateSmartDefaults.HasValue)
                sb.AppendFormat(",generateSmartDefaults={0}", GenerateSmartDefaults);

            if (IgnoreAnsiNulls.HasValue)
                sb.AppendFormat(",ignoreAnsiNulls={0}", IgnoreAnsiNulls);

            if (IgnoreAuthorizer.HasValue)
                sb.AppendFormat(",ignoreAuthorizer={0}", IgnoreAuthorizer);

            if (IgnoreColumnCollation.HasValue)
                sb.AppendFormat(",ignoreColumnCollation={0}", IgnoreColumnCollation);

            if (IgnoreComments.HasValue)
                sb.AppendFormat(",ignoreComments={0}", IgnoreComments);

            if (IgnoreCryptographicProviderFilePath.HasValue)
                sb.AppendFormat(",ignoreCryptographicProviderFilePath={0}", IgnoreCryptographicProviderFilePath);

            if (IgnoreDdlTriggerOrder.HasValue)
                sb.AppendFormat(",ignoreDdlTriggerOrder={0}", IgnoreDdlTriggerOrder);

            if (IgnoreDdlTriggerState.HasValue)
                sb.AppendFormat(",ignoreDdlTriggerState={0}", IgnoreDdlTriggerState);

            if (IgnoreDefaultSchema.HasValue)
                sb.AppendFormat(",ignoreDefaultSchema={0}", IgnoreDefaultSchema);

            if (IgnoreDmlTriggerOrder.HasValue)
                sb.AppendFormat(",ignoreDmlTriggerOrder={0}", IgnoreDmlTriggerOrder);

            if (IgnoreDmlTriggerState.HasValue)
                sb.AppendFormat(",ignoreDmlTriggerState={0}", IgnoreDmlTriggerState);

            if (IgnoreExtendedProperties.HasValue)
                sb.AppendFormat(",ignoreExtendedProperties={0}", IgnoreExtendedProperties);

            if (IgnoreFileAndLogFilePath.HasValue)
                sb.AppendFormat(",ignoreFileAndLogFilePath={0}", IgnoreFileAndLogFilePath);

            if (IgnoreFilegroupPlacement.HasValue)
                sb.AppendFormat(",ignoreFilegroupPlacement={0}", IgnoreFilegroupPlacement);

            if (IgnoreFileSize.HasValue)
                sb.AppendFormat(",ignoreFileSize={0}", IgnoreFileSize);

            if (IgnoreFillFactor.HasValue)
                sb.AppendFormat(",ignoreFillFactor={0}", IgnoreFillFactor);

            if (IgnoreFullTextCatalogFilePath.HasValue)
                sb.AppendFormat(",ignoreFullTextCatalogFilePath={0}", IgnoreFullTextCatalogFilePath);

            if (IgnoreIdentitySeed.HasValue)
                sb.AppendFormat(",ignoreIdentitySeed={0}", IgnoreIdentitySeed);

            if (IgnoreIncrement.HasValue)
                sb.AppendFormat(",ignoreIncrement={0}", IgnoreIncrement);

            if (IgnoreIndexOptions.HasValue)
                sb.AppendFormat(",ignoreIndexOptions={0}", IgnoreIndexOptions);

            if (IgnoreIndexPadding.HasValue)
                sb.AppendFormat(",ignoreIndexPadding={0}", IgnoreIndexPadding);

            if (IgnoreKeywordCasing.HasValue)
                sb.AppendFormat(",ignoreKeywordCasing={0}", IgnoreKeywordCasing);

            if (IgnoreLockHintsOnIndexes.HasValue)
                sb.AppendFormat(",ignoreLockHintsOnIndexes={0}", IgnoreLockHintsOnIndexes);

            if (IgnoreLoginSids.HasValue)
                sb.AppendFormat(",ignoreLoginSids={0}", IgnoreLoginSids);

            if (IgnoreNotForReplication.HasValue)
                sb.AppendFormat(",ignoreNotForReplication={0}", IgnoreNotForReplication);

            if (IgnoreObjectPlacementOnPartitionScheme.HasValue)
                sb.AppendFormat(",ignoreObjectPlacementOnPartitionScheme={0}", IgnoreObjectPlacementOnPartitionScheme);

            if (IgnorePartitionSchemes.HasValue)
                sb.AppendFormat(",ignorePartitionSchemes={0}", IgnorePartitionSchemes);

            if (IgnorePermissions.HasValue)
                sb.AppendFormat(",ignorePermissions={0}", IgnorePermissions);

            if (IgnoreQuotedIdentifiers.HasValue)
                sb.AppendFormat(",ignoreQuotedIdentifiers={0}", IgnoreQuotedIdentifiers);

            if (IgnoreRoleMembership.HasValue)
                sb.AppendFormat(",ignoreRoleMembership={0}", IgnoreRoleMembership);

            if (IgnoreRouteLifetime.HasValue)
                sb.AppendFormat(",ignoreRouteLifetime={0}", IgnoreRouteLifetime);

            if (IgnoreSemicolonBetweenStatements.HasValue)
                sb.AppendFormat(",ignoreSemicolonBetweenStatements={0}", IgnoreSemicolonBetweenStatements);

            if (IgnoreTableOptions.HasValue)
                sb.AppendFormat(",ignoreTableOptions={0}", IgnoreTableOptions);

            if (IgnoreUserSettingsObjects.HasValue)
                sb.AppendFormat(",ignoreUserSettingsObjects={0}", IgnoreUserSettingsObjects);

            if (IgnoreWhitespace.HasValue)
                sb.AppendFormat(",ignoreWhitespace={0}", IgnoreWhitespace);

            if (IgnoreWithNocheckOnCheckConstraints.HasValue)
                sb.AppendFormat(",ignoreWithNocheckOnCheckConstraints={0}", IgnoreWithNocheckOnCheckConstraints);

            if (IgnoreWithNocheckOnForeignKeys.HasValue)
                sb.AppendFormat(",ignoreWithNocheckOnForeignKeys={0}", IgnoreWithNocheckOnForeignKeys);

            if (IncludeCompositeObjects.HasValue)
                sb.AppendFormat(",includeCompositeObjects={0}", IncludeCompositeObjects);

            if (IncludeTransactionalScripts.HasValue)
                sb.AppendFormat(",includeTransactionalScripts={0}", IncludeTransactionalScripts);

            if (NoAlterStatementsToChangeClrTypes.HasValue)
                sb.AppendFormat(",noAlterStatementsToChangeClrTypes={0}", NoAlterStatementsToChangeClrTypes);

            if (PopulateFilesOnFileGroups.HasValue)
                sb.AppendFormat(",populateFilesOnFileGroups={0}", PopulateFilesOnFileGroups);

            if (RegisterDataTierApplication.HasValue)
                sb.AppendFormat(",registerDataTierApplication={0}", RegisterDataTierApplication);

            if (RunDeploymentPlanExecutors.HasValue)
                sb.AppendFormat(",runDeploymentPlanExecutors={0}", RunDeploymentPlanExecutors);

            if (ScriptDatabaseCollation.HasValue)
                sb.AppendFormat(",scriptDatabaseCollation={0}", ScriptDatabaseCollation);

            if (ScriptDatabaseCompatibility.HasValue)
                sb.AppendFormat(",scriptDatabaseCompatibility={0}", ScriptDatabaseCompatibility);

            if (ScriptDatabaseOptions.HasValue)
                sb.AppendFormat(",scriptDatabaseOptions={0}", ScriptDatabaseOptions);

            if (ScriptDeployStateChecks.HasValue)
                sb.AppendFormat(",scriptDeployStateChecks={0}", ScriptDeployStateChecks);

            if (ScriptFileSize.HasValue)
                sb.AppendFormat(",scriptFileSize={0}", ScriptFileSize);

            if (ScriptNewConstraintValidation.HasValue)
                sb.AppendFormat(",scriptNewConstraintValidation={0}", ScriptNewConstraintValidation);

            if (ScriptRefreshModule.HasValue)
                sb.AppendFormat(",scriptRefreshModule={0}", ScriptRefreshModule);

            if (TreatVerificationErrorsAsWarnings.HasValue)
                sb.AppendFormat(",treatVerificationErrorsAsWarnings={0}", TreatVerificationErrorsAsWarnings);

            if (UnmodifiableObjectWarnings.HasValue)
                sb.AppendFormat(",unmodifiableObjectWarnings={0}", UnmodifiableObjectWarnings);

            if (VerifyCollationCompatibility.HasValue)
                sb.AppendFormat(",verifyCollationCompatibility={0}", VerifyCollationCompatibility);

            if (VerifyDeployment.HasValue)
                sb.AppendFormat(",verifyDeployment={0}", VerifyDeployment);

        }
    }
}
