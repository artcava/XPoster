# Graph Report - XPoster  (2026-09-06)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `AiProviderExtensionsTests` - 2 edges
2. `DeepSeekOptionsValidatorTests` - 2 edges
3. `IgSenderSendAsyncTests` - 2 edges
4. `XPoster.Tests.SenderPlugins` - 2 edges
5. `XPoster.Tests.Models` - 2 edges
6. `XPoster.Tests.Workflows.Services` - 2 edges
7. `ConfigurationStepOptionsResolverTests` - 2 edges
8. `XPoster.Tests.Orchestrators` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_FalAi_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray(), XPoster.Tests.Services, ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray(), ParseImageResponseAsync_UnsupportedProvider_LogsError() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateTextAsync_RequestBodyContainsTemperatureAndMaxTokensFromRequest(), GenerateTextAsync_RequestBodyContainsModelFromOptions(), GenerateTextAsync_RequestBodyContainsSystemAndUserMessagesFromRequest() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetry(), GenerateTextAsync_WhenOutputFitsWithinMaxOutputLength_ReturnsSingleCallResult() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), BuildShortSender(), BuildConfig(), BuildMaxSender() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_UnsupportedProvider_ReturnsEmpty(), Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), static(), XPoster.Tests.Services, Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_FalAi_DownloadThrows_LogsError() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, DeepSeekOptionsExtensionsTests, ConfigurationBuilder(), BuildProvider(), BuildConfig(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, BuildService(), BuildImagePromptRequest(), MakeSequentialHandlerMock(), MakeHandlerMock(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GenerateTextAsync_WhenTextExceedsMaxOutputLength_CallsApiAndReturnsContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, NormalizeImage_WithValidJpeg_ReturnsSameBytes(), FbSenderTests(), NormalizeImage_WithInvalidBytes_ReturnsNull(), MessageMaxLength_Returns3000(), FbSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, HttpResponseMessage(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), GenerateTextAsync_WhenUsedForImagePromptDerivation_ReturnsPrompt(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), new(), SummaryRequest() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_JsonElement_ToBool(), GetParameter_DirectCast_Int(), GetParameter_DirectCast_String(), GetParameter_JsonArrayString_ToList(), GetProvider_ParsesValidName_CaseInsensitive(), GetParameter_ReturnsDefault_WhenKeyMissing() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLength_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), Platform_ReturnsX() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, return(), LinearChain(), MissingRef(), _onExecute(), ExecuteAsync(), Execute_NodeFailure_StopsExecution_AndReturnsError(), Execute_UnregisteredNodeType_ReturnsFailure() (+13 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, GetData_ThrowsOnTypeMismatch(), ConcurrentReadWrite_DoesNotThrow(), catch(), ConcurrentSetData_DoesNotThrow(), GetData_ThrowsOnMissingKey(), XPoster.Tests.Workflows.Models (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildRequest(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_SubstitutesCustomLabelInUserMessage() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, OpenAiOptions_ModelCatalog_ExposesTextAndImage(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), ModelCatalog_UnsupportedCapability_GetRequired_Throws(), OpenAiOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), DeepSeekOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, BuildSender(), CreateMalformedPngBytes(), IgSender(), IgSenderImageFlowTests, return(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FeedServiceTests, BuildService() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequestTests, XPoster.Tests.Models, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_OptionalProperties_AreSetCorrectly(), PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_Temperature_AcceptsZeroAndOne() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), XPoster.Tests.Services, PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), MetaPublishingService() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_ConvertsParameters_ToObjectDictionary(), MakeConfiguration(), BuildProvider(), AddWorkflows_WithValidWorkflow_DoesNotThrow(), ConfigurationBuilder(), InMemory() (+9 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), TwoTerminals(), Cyclic() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_ParseSenderPlatforms(), ConfigurationSlotProfileProviderTests, CreateProvider(), GetProfiles_Should_MapEachSlotToWorkflowOrchestrator(), GetProfiles_Should_OrderSlotsByHour(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, ConfigurationBuilder(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), BuildAllProvidersConfig(), AddAiProviderOptionsTests, AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_RegistersAllFiveValidators() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, BuildSender(), IgSender(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), new(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), PostWithoutImage() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), CreateSut(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_LongText_WithFallback_Resummarises(), Execute_AppliesTagReplacements(), Execute_BridgesMediaAttachment_ToPostImage(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, static(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyDictionary_OnFailure(), MakeDefinitionWithoutImage(), MakeDefinition(), WorkflowOrchestratorTests, XPoster.Tests.Orchestrators, Properties_AreConfigured(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, foreach(), catch(), XPoster, XPosterContainerPollingFunction(), switch(), HandleTerminalFailureAsync() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, AIResponse_CanBeCreated_WithChoices(), Choice_CanBeCreated_WithMessage(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_CanHold_ImageBytes(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsFailure_WhenRequired_AndImageMissing(), AiImageNodeTests, static(), Execute_ReturnsNullOutput_OnSoftFailure(), return(), if() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider(), XPoster.Tests.Providers, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Constructor_NullDictionary_Throws(), AiModelCatalogTests, Constructor_ExcludesNullOrWhitespaceEntries(), XPoster.Tests.Models, GetRequired_ReturnsModelName_WhenSupported(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, if(), Resolve_Throws_OnNullOrWhitespaceStepId(), Resolve_BindsImageProperties_WhenPresent(), Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_ReturnsStepOptions_WhenSectionExists(), Resolve_Throws_WhenStepMissing() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), MessageMaxLength_Returns2800(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeRequest(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProvider(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), foreach() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GetChatCompletionsEndpoint(), GenerateTextAsync(), catch(), GenerateImageAsync(), AzureFoundryService(), var() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, XPoster.Tests.SenderPlugins, BuildSender(), MessageMaxLength_Returns2200(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), new(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, ValidPost(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields(), typeof(), ScheduledOrchestrationProfileTests, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), BuildSender(), IgSenderSendAsyncTests, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSender(), SendAsync_WithEmptyImageArray_ReturnsFalse() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, if(), HttpRequestException(), GetContainerStatusAsync(), GetApiVersion(), catch(), PublishContainerAsync() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), XPoster.Tests.Models (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins, PublishPhotoAsync(), HandleResponseAsync(), if() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, XPoster.Tests.SenderPlugins (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XPoster.Tests (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), NoOrchestratorTests, SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, while(), if(), WorkflowExecutionEngine(), XPoster.Workflows.Engine, WorkflowExecutionResult(), foreach() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, BuildDelayedHandler(), params(), BuildProviderWithHandler(), BuildSequenceHandler() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), Execute_UsesDefaultSymbol_WhenNotProvided(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), AcquireCryptoValueNodeTests(), XPoster.Tests.Workflows.Nodes (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), generatePayLoad(), InvalidOperationException(), ResolveAuthorUrn(), catch(), Exception(), SendAsync() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildFactory(), BuildCreds(), HttpRequestException(), InvalidImageBytes(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), for() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection(), foreach(), XPoster.Tests.Extensions, HttpClientExtensionsTests, AddHttpClients_CanCreateAllExpectedNamedClients() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, Supports(), GetRequired(), InvalidOperationException(), AiModelCatalog(), if(), XPoster.Models (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), FbSenderResilienceTests (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), CreateTimerInfo(), PendingContainer() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, XPoster.Tests.Models

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, foreach(), ExecuteAsync(), FetchRssNode(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, OpenAIImageResponse, ImageData, Choice, Message, AIResponse

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), XPoster.Services, UploadAsync(), if(), DeleteAsync(), BlobStorageService()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GetImageGenerationEndpoint(), if(), GenerateImageAsync(), catch(), FalAiImageService(), XPoster.Services

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, ExecuteAsync(), foreach(), WorkflowNodeResult(), if(), XPoster.Workflows.Nodes, FanOutSendNode()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, return(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), AiTextNodeTests, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, static()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_OmitsDelta_WhenActualValueZeroOrMissing(), new(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, new(), CreateFactoryWithProfiles(), CreateFactory(), SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile(), OrchestratorFactoryTests()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), Dispose(), CaptureLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, PostTests, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), XPoster.Tests.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoContentRetrieved(), XPoster.Tests.Workflows.Nodes, foreach(), static(), Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, return()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractFalAiBytesAsync(), BuildChatPayload(), ExtractAzureFoundryBytesAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, WorkflowContext, SetData(), if(), HasData(), KeyNotFoundException(), XPoster.Workflows.Models

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), AiImageNode(), if()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, IgSender(), if(), catch()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), ValidOptions(), XPoster.Tests.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, SaveAsync(), XPoster.Contracts, UpdateStatusAsync()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), foreach(), TagReplacementService(), XPoster.Services

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, WorkflowOrchestrator(), XPoster.Orchestrators, Resolve(), NoOrchestrator(), catch(), ResolveSenders()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), var(), while(), GenerateImageAsync(), XPoster.Services, GenerateTextAsync()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), XPoster.Services, SaveAsync(), GetPendingAsync(), InMemoryContainerStateStore

### Community 88 - "Entity (Community 88)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, if(), CredentialsStartupValidator(), catch(), XPoster.Credentials, Validate(), InvalidOperationException()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), catch(), XFunction(), if(), XPoster

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), if(), WorkflowNodeResult(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, foreach(), AddWorkflows(), XPoster.Workflows.Configuration, InvalidOperationException(), if()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), Execute_CallsFeedServiceForMultipleUrls(), Execute_ConcatenatesMultipleFeeds(), var(), Input()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), IsJsonLike(), return(), XPoster.Workflows.Utilities, catch()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, HasCycle(), foreach(), if(), XPoster.Workflows.Engine

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, WorkflowNodeResult(), AcquireCryptoValueNode(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), XPoster.Workflows.Models, SetData(), IWorkflowContext

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, IBlobStorageService, UploadAsync(), DeleteAsync()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptionsTests

### Community 109 - "Entity (Community 109)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, if(), Validate(), FacebookCredentialsValidator, XPoster.Credentials

### Community 121 - "Entity (Community 121)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), BuildPowerLawPostNodeTests(), Input(), if()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService, PublishContainerAsync()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, nameof(), if(), Validate(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), XPoster.SenderPlugins, if()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), if(), Uri(), BlobServiceClient()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests(), IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), HttpClient(), JsonResponse(), MakeDownloadClient()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), InstagramCredentialsValidator, Validate(), XPoster.Credentials

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, if(), nameof(), OrchestratorFactory(), ResolveWorkflowOrchestrator(), CreateEmptyNoOrchestrator()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_ReturnsGeneratedText(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), Execute_PassesStepOptionsToPromptRequest(), var()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, ExecuteAsync(), XPoster.Workflows.Nodes, if(), BuildPowerLawPostNode()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, WorkflowOrchestrator(), if()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), var(), XPoster.Services, GenerateTextAsync()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, ToDefinition(), WorkflowDefinition()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), catch(), Exception(), XPoster.Services

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, IAiProviderSection, XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, ExecuteAsync(), IWorkflowEngine, XPoster.Workflows.Engine

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), ConfigurationStepOptionsResolver()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), XPoster.Workflows.Abstractions, IWorkflowNode

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Providers

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), XPoster.Providers, ConfigurationTagReplacementProvider()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), if(), XPoster.Services, var()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), MaskUrlTelemetryProcessor(), Process()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), if(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, Resolve(), IStepOptionsResolver, XPoster.Workflows.Services

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, XPoster.Models, ValidateConnectivity(), if()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), PerplexityService(), GetChatCompletionsEndpoint()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 174 - "Entity (Community 174)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddHttpClients(), AddResilientHttpClient()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 166 - "Entity (Community 166)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, new(), ExecuteAsync(), Node()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, new(), WorkflowExecutionResult(), var()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, GetProfiles(), XPoster.Providers, ConfigurationSlotProfileProvider()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, WorkflowDefinition(), XPoster.Workflows.Engine

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Orchestrators, BaseOrchestrator()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), resolve(), ValidateOptions()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 200 - "Entity (Community 200)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 203 - "Entity (Community 203)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 205 - "Entity (Community 205)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 204 - "Entity (Community 204)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 201 - "Entity (Community 201)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 202 - "Entity (Community 202)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 207 - "Entity (Community 207)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 215 - "Entity (Community 215)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 199 - "Entity (Community 199)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 198 - "Entity (Community 198)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, SlotScheduleOptions.cs, XPoster.Models

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

