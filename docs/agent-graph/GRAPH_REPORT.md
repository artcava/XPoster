# Graph Report - XPoster  (2026-09-04)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Providers` - 2 edges
2. `XPoster.Providers` - 2 edges
3. `IFeedService` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Workflows.Configuration` - 2 edges
6. `ISender` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `ConfigurationTagReplacementProviderTests` - 2 edges
9. `XPoster.Tests.Providers` - 2 edges
10. `XPoster.Tests.Integration` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, new(), MakeResponse(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiService(), OpenAiServiceTests, new(), MakeHandler(), MakeHandlerMock() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, XPoster.Tests.Services, static(), Parse_UnsupportedProvider_ReturnsEmpty(), Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), ShortSender_MessageMaxLength_IsFifty(), ShortSender_ImplementsISender(), SendAsync_WithNullPost_LogsWarning() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddFalAiOptions_RegistersValidator(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, new(), PerplexityService(), PerplexityServiceTests, MakeSequentialHandlerMock(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_InitializesCorrectly(), BuildCreds(), BuildSender(), BuildFactory(), FbSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, NodeParameterExtractorTests, GetProvider_Throws_WhenEmptyName(), GetProvider_UsesProvidedDefault_WhenMissing(), GetProvider_Throws_WhenUnknownName(), GetParameter_MalformedJson_ForList_ReturnsEmptyOrNull(), GetParameter_JsonElement_ToList() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_Cycle_ReturnsFailure_WithDescriptiveError(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_EmptyNodesDefinition_Succeeds(), MissingRef(), static() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning() (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, XPoster.Tests.Models, OpenAiOptions_ModelCatalog_ExposesTextAndImage(), PerplexityOptions_ModelCatalog_ExposesTextOnly(), PerplexityOptions_ImplementsIAiProviderOptions(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FeedService(), FeedServiceTests, foreach(), SendAsync(), XPoster.Tests.Services (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, GetData_ThrowsOnMissingKey(), catch(), ConcurrentSetData_DoesNotThrow(), ConcurrentReadWrite_DoesNotThrow(), TryGetData_ReturnsFalse_WhenKeyMissing(), XPoster.Tests.Workflows.Models (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, GetContent(), GetRole(), return(), XPoster.Tests.Services, BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_MessagesContainsTwoEntries() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WhenCodecIsNull_ReturnsNull() (+10 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, XPoster.Tests.Workflows.Configuration, WorkflowServiceCollectionExtensionsTests, ServiceCollection(), AddWorkflows_WithValidWorkflow_DoesNotThrow(), ConfigurationBuilder(), InMemory() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequestTests, XPoster.Tests.Models, ImagePromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_InheritsFrom_PromptRequest() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), MetaPublishingService() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateStructural_Cycle_ReturnsError(), ValidateStructural_MissingNodeReference_ReturnsError(), TwoTerminals(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), MissingRef() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_SkipSlot_WithNoSenders(), BuildConfiguration() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), XPoster.Tests.Services, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageServiceTests, BlobStorageService(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), CreateSut(), XPoster.Tests.Services (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, ConfigurationBuilder(), XPoster.Tests.Extensions, AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), Uri() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, switch(), Run(), HandleFinishedAsync(), ProcessContainerAsync(), HandleTerminalFailureAsync(), PollPendingContainersAsync() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, Properties_AreConfigured(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), ProduceImage_Set_ThrowsNotSupported(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), MakeDefinition() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_LongText_WithFallback_Resummarises(), Execute_BridgesMediaAttachment_ToPostImage(), Execute_AppliesTagReplacements(), Execute_ShortText_NoResummary(), static(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), return() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_CanHold_ImageBytes(), ImageData_CanBeCreated_WithUrl(), ModelsTests, Message_CanBeCreated_WithContent() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), FalAiImageServiceTests, FalImageJson(), BuildService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildCreds(), InSender_ImplementsISender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Empty_SupportsNoModelClass(), Constructor_NullDictionary_Throws(), AiModelCatalogTests, Constructor_ExcludesNullOrWhitespaceEntries(), GetRequired_Throws_WhenNotSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_Throws_WhenValidProviderNotRegistered(), static(), if(), Input(), return(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes (+5 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GenerateImageAsync(), catch(), AzureFoundryService(), GenerateTextAsync(), GetImageGenerationEndpoint(), XPoster.Services (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, XPoster.Tests.Workflows.Services, Resolve_Throws_WhenStepMissing(), ConfigurationStepOptionsResolverTests, foreach(), if(), Resolve_BindsMaxOutputLength_WhenPresent() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), MessageMaxLength_Returns2800(), Platform_ReturnsLinkedIn(), InSender(), Constructor_InitializesCorrectly(), InSenderTests(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, typeof(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, MakeHandlerMock(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPoster.Tests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPosterContainerPollingFunctionTests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), XPoster.Tests.Models, typeof(), Constructor_Should_SetAllFields(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), Constructor_Should_PreserveHour_ForBoundaryValues() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), XPoster.Tests.Extensions (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, new(), BuildCreds(), BuildSender(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200() (+3 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), HttpRequestException(), PublishContainerAsync(), if(), MetaPublishingService(), GetContainerStatusAsync() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSender(), IgSenderSendAsyncTests, SendAsync_WithNoImage_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XSender(), XSenderResilienceTests, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), BuildCreds(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), BuildFactory() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XFunctionTests(), XPoster.Tests (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, Build(), Name_IsNoOrchestrator() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, SendAsync(), PublishPhotoAsync(), if(), FbSender(), HandleResponseAsync() (+2 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), CryptoServiceTests (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_CanCreateAllExpectedNamedClients(), foreach(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_RegistersExpectedNamedClients() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, ExecuteAsync(), XPoster.Workflows.Engine, WorkflowExecutionResult(), if(), while(), foreach() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, InvalidOperationException(), XPoster.Models, TryGet(), Supports(), GetRequired(), AiModelCatalog() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): InSender.cs, ResolveAuthorUrn(), Exception(), InvalidOperationException(), generatePayLoad(), catch(), XPoster.SenderPlugins, SendAsync() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, InvalidImageBytes(), HttpRequestException(), FbSenderImageFlowTests, BuildCreds() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), PendingContainer(), RunAsync_WhenCancelled_StopsGracefully(), CreateTimerInfo() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildSequenceHandler(), HttpResponseMessage(), XPoster.Tests.Integration, var(), params(), BuildDelayedHandler() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), XPoster.Tests.SenderPlugins, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, XPoster.Tests.Workflows.Nodes, static(), AiTextNodeTests, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), Execute_Throws_WhenProviderNameIsUnknown(), return(), WorkflowNodeInput()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), BuildChatPayload(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), new(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), CreateNode()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), new(), CreateFactory(), CreateFactoryWithProfiles(), WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, if(), catch(), GetImageGenerationEndpoint(), FalAiImageService(), GenerateImageAsync(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, foreach(), WorkflowNodeResult(), if(), ExecuteAsync(), FetchRssNode()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, if(), KeyNotFoundException(), WorkflowContext, XPoster.Workflows.Models, SetData(), HasData()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, PostTests, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), XPoster.Tests.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Choice, Message, AIResponse, ImageData, OpenAIImageResponse, XPoster.Models

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoContentRetrieved(), FetchRssNodeTests, foreach(), return(), static(), Execute_ReturnsFailure_WhenNoUrlsProvided(), XPoster.Tests.Workflows.Nodes

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, foreach(), ExecuteAsync(), FanOutSendNode(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, DeleteAsync(), UploadAsync(), BlobUploadResult(), if(), BlobStorageService(), XPoster.Services

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), ValidOptions(), XPoster.Tests.Models

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), Dispose(), IsEnabled(), CaptureLoggerProvider(), CreateLogger(), XPoster.Tests.Integration

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync(), IContainerStateStore

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateImageAsync(), catch(), while(), XPoster.Services, GenerateTextAsync(), var()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, InvalidOperationException(), XPoster.Workflows.Configuration, if(), foreach(), AddWorkflows()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, WorkflowOrchestrator(), XPoster.Orchestrators, NoOrchestrator(), catch(), ResolveSenders(), Resolve()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, if(), AiTextNode(), ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 90 - "Entity (Community 90)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), CredentialsStartupValidator(), if(), InvalidOperationException(), XPoster.Credentials, Validate()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), if(), catch(), XPoster, XFunction()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), foreach(), TagReplacementService(), XPoster.Services

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), UpdateStatusAsync(), GetPendingAsync(), XPoster.Services, InMemoryContainerStateStore

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, if(), ExecuteAsync(), WorkflowNodeResult(), AiImageNode(), XPoster.Workflows.Nodes

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), catch(), SendAsync(), if(), XPoster.SenderPlugins

### Community 91 - "Entity (Community 91)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, if(), BuildPowerLawPostNodeTests(), Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), Input()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), var(), HttpClient(), JsonResponse(), MakeDownloadClient()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender(), IgSender_ImplementsISender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Providers, GetCurrentTime_ReturnsUtcTime()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, if(), Validate(), XPoster.Credentials

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), SetData(), XPoster.Workflows.Models, IWorkflowContext

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), ExecuteAsync(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, var(), Execute_PassesStepOptionsToPromptRequest(), Input(), Execute_ReturnsGeneratedText(), Execute_Throws_WhenValidProviderNotRegistered()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), XPoster.Credentials, InstagramCredentialsValidator, Validate()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, UploadAsync(), XPoster.Contracts, DeleteAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, var(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, var(), Input(), WorkflowNodeInput(), Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, foreach(), HasCycle(), if(), XPoster.Workflows.Engine

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), IMetaPublishingService, PublishContainerAsync(), XPoster.Contracts

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), BlobServiceClient(), Uri(), DefaultAzureCredential()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, CreateEmptyNoOrchestrator(), ResolveWorkflowOrchestrator(), if(), nameof(), OrchestratorFactory()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), Validate(), nameof(), XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), SendAsync(), DryRunSender(), XPoster.SenderPlugins

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), nameof(), XPoster.Models, Validate()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, BuildPowerLawPostNode(), XPoster.Workflows.Nodes, ExecuteAsync(), if()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), catch(), IsJsonLike(), XPoster.Workflows.Utilities, return()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, WorkflowDefinition(), ToDefinition(), XPoster.Workflows.Configuration

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), XPoster.Services, if(), var()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, Resolve(), ConfigurationStepOptionsResolver(), XPoster.Workflows.Services

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 157 - "Entity (Community 157)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), catch(), GetFeedsAsync()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, ICredentialsStartupValidator, Validate()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, Resolve(), XPoster.Workflows.Services, IStepOptionsResolver

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, Apply(), ITagReplacementService

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, XPoster.Contracts, IAiProviderSection

### Community 136 - "Entity (Community 136)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 137 - "Entity (Community 137)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 139 - "Entity (Community 139)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), if(), OpenAiService(), GetImageGenerationEndpoint()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, ConfigurationSlotProfileProvider(), GetProfiles()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), WorkflowExecutionResult(), new()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 177 - "Entity (Community 177)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 179 - "Entity (Community 179)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), resolve(), ValidateOptions()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), new(), StubNode()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), while(), PerplexityService()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 199 - "Entity (Community 199)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 198 - "Entity (Community 198)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 200 - "Entity (Community 200)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 204 - "Entity (Community 204)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 201 - "Entity (Community 201)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 202 - "Entity (Community 202)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

