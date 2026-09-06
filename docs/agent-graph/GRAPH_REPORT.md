# Graph Report - XPoster  (2026-09-06)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Tests.Helpers` - 2 edges
3. `IFeedService` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `IStepOptionsResolver` - 2 edges
6. `XPoster.Workflows.Services` - 2 edges
7. `XPoster.Tests.Models` - 2 edges
8. `XPoster.Services` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Services` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeHttpClient(), HttpClient(), FalAiJson(), new(), MakeHttpClientThatThrows(), MakeResponse() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), XPoster.Tests.Services, if(), MakeHandlerMock() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, ConfigurationBuilder(), BuildMaxSender(), BuildConfig(), BuildShortSender(), SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WhenProbeKeyMissing_ReturnsFalse() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), XPoster.Tests.Services (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, new(), PerplexityService(), PerplexityServiceTests, BuildService(), BuildImagePromptRequest() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes(), FbSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), ChatCompletionJson(), BuildService(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_ConvertChangeType_IntFromString(), GetParameter_ConversionFailure_ReturnsDefault(), GetParameter_JsonElement_ToBool(), GetParameter_DirectCast_Int(), GetParameter_JsonArrayString_ToList(), GetParameter_DirectCast_String() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_EmptyContent_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Platform_ReturnsX(), MessageMaxLength_Returns250(), Constructor_InitializesCorrectly(), BuildSender() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, EmptySenders(), Diamond(), Cyclic(), Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), Execute_UnregisteredNodeType_ReturnsFailure(), ExecuteAsync(), foreach() (+13 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, CreateMalformedPngBytes(), BuildSender(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), return() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_ForwardsModelName(), BuildChatPayload_ForwardsTemperature(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_SecondMessageRoleIsUser() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ModelCatalog_ExposesTextOnly(), XPoster.Tests.Models, DeepSeekOptions_ModelCatalog_ExposesTextOnly(), AiProviderOptionsAbstractionTests, AzureFoundryOptions_ModelCatalog_ExposesTextAndImage() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, TryGetData_ReturnsFalse_OnTypeMismatch(), TryGetData_ReturnsTrue_WhenKeyExists(), WorkflowContextTests, XPoster.Tests.Workflows.Models, TryGetData_ReturnsFalse_WhenKeyMissing(), GetData_ThrowsOnMissingKey() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), FeedService() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_IsImmutable_AfterConstruction(), PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_OptionalProperties_DefaultToNull(), PromptRequest_OptionalProperties_AreSetCorrectly(), PromptRequest_Temperature_AcceptsZeroAndOne() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), AddWorkflows_Registers_StepOptionsResolver(), AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), XPoster.Tests.Services, GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), CreateSut() (+9 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, Linear(), MissingRef(), TwoTerminals(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_Cycle_ReturnsError(), WorkflowDefinitionValidatorTests, XPoster.Tests.Workflows.Engine (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, XPoster.Tests.Providers, GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), new(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), UpdateStatusAsync_CanMoveEntryBackToPending(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithValidInputs_StoresPendingEntry(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), ConfigurationBuilder() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), XPoster.Tests.Services, MaskUrlTelemetryProcessorTests, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, CreateSut(), BlobStorageServiceTests, BlobStorageService(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenBlobUploadFails_ReturnsFalse(), new(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), PostWithImage(), PostWithoutImage(), BuildSender() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, switch(), HandleTerminalFailureAsync(), Run(), ProcessContainerAsync(), PollPendingContainersAsync(), if() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_LongText_WithFallback_Resummarises(), Execute_BridgesMediaAttachment_ToPostImage(), Execute_AppliesTagReplacements(), static(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), return(), Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, MakeDefinition(), MakeDefinitionWithoutImage(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), Properties_AreConfigured(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), ProduceImage_Set_ThrowsNotSupported(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes(), ImageData_CanBeCreated_WithUrl(), Post_CanBeCreated_WithRequiredContent(), Message_CanBeCreated_WithContent(), OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Input(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), if(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_ReturnsNullOutput_OnSoftFailure() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildCreds(), BuildSender(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, XPoster.Tests.Services, FalImageJson(), FalAiImageServiceTests, BuildService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Providers, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Constructor_ExcludesNullOrWhitespaceEntries(), AiModelCatalogTests, Constructor_NullDictionary_Throws(), Empty_SupportsNoModelClass(), GetRequired_Throws_WhenNotSupported(), Supports_ReturnsFalseForMissingModelClass() (+5 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, catch(), AzureFoundryService(), while(), GenerateImageAsync(), GenerateTextAsync(), var() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, MakeHandlerMock(), GenerateImageAsync_Returns429_LogsWarning(), MakeRequest(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenBlobDeleteFails_LogsError(), CreateSut(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, foreach(), XPoster.Tests.Providers, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), MessageMaxLength_Returns2800(), Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_Throws_OnNullOrWhitespaceStepId(), Resolve_Throws_WhenStepMissing(), XPoster.Tests.Workflows.Services, Resolve_BindsMaxOutputLength_WhenPresent(), if(), foreach() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), BuildSender(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_PreserveOrderOfSenderPlatforms(), OrchestratorContextKey_Should_BeSet_WhenProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), ScheduledOrchestrationProfileTests (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildSender(), BuildCreds(), XPoster.Tests.SenderPlugins, Constructor_InitializesCorrectly(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Platform_ReturnsInstagram(), MessageMaxLength_Returns2200() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, catch(), GetApiVersion(), GetContainerStatusAsync(), if(), MetaPublishingService(), PublishContainerAsync() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, SendAsync(), catch(), HandleResponseAsync(), PublishPhotoAsync(), PublishTextOnlyAsync() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), Build(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, IgSender(), IgSenderSendAsyncTests, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse() (+2 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, GetRequired(), AiModelCatalog(), InvalidOperationException(), TryGet(), XPoster.Models, Supports() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), WorkflowNodeInput(), Execute_UsesDefaultSymbol_WhenNotProvided(), XPoster.Tests.Workflows.Nodes, Input(), AcquireCryptoValueNodeTests() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): InSender.cs, InvalidOperationException(), generatePayLoad(), catch(), Exception(), XPoster.SenderPlugins, SendAsync(), using() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), HttpRequestException(), BuildCreds(), FbSenderImageFlowTests (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), XPoster.Tests.Integration, params() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, foreach(), ExecuteAsync(), if(), XPoster.Workflows.Engine, WorkflowExecutionEngine(), while() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), catch(), for(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeedTests, XPoster.Tests.Models, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, AddHttpClients_ReturnsSameServiceCollection(), HttpClientExtensionsTests, foreach(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory() (+1 more)

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, BuildChatPayload(), ExtractAzureFoundryBytesAsync(), ParseImageResponseAsync(), LogAndReturnEmpty(), XPoster.Services, ExtractOpenAiBytes(), ExtractFalAiBytesAsync()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, WorkflowNodeResult(), ExecuteAsync(), if(), FanOutSendNode(), foreach(), XPoster.Workflows.Nodes

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, GetImageGenerationEndpoint(), if(), FalAiImageService(), GenerateImageAsync(), catch()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, if(), UploadAsync(), XPoster.Services, BlobUploadResult(), BlobStorageService(), DeleteAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), BaseOrchestratorTests(), TestOrchestrator()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), new(), SetupMocksForOrchestratorFactory(), WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactoryWithProfiles(), CreateFactory()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, AiTextNodeTests, static(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenProviderNameIsUnknown(), return(), Execute_ReturnsFailure_WhenProviderReturnsEmpty()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, static(), XPoster.Tests.Workflows.Nodes, return(), foreach(), Execute_ReturnsFailure_WhenNoContentRetrieved(), Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, PostTests, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models, Post_DefaultImageIsNull()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, Message, XPoster.Models, OpenAIImageResponse, ImageData

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, FetchRssNode(), ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes, foreach(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, if(), HasData(), XPoster.Workflows.Models, WorkflowContext, SetData(), KeyNotFoundException()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), Dispose(), IsEnabled(), XPoster.Tests.Integration

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), new(), WorkflowNodeInput(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), XPoster.Tests.Workflows.Nodes, CreateNode()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), Apply(), XPoster.Services, if(), TagReplacementService()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, var(), while(), XPoster.Services, GenerateImageAsync(), catch(), GenerateTextAsync()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, XPoster.Orchestrators, Resolve(), ResolveSenders(), catch(), WorkflowOrchestrator(), NoOrchestrator()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, ExecuteAsync(), AiImageNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, InvalidOperationException(), if(), XPoster.Workflows.Configuration, AddWorkflows(), foreach()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), if(), WorkflowNodeResult(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), IContainerStateStore, SaveAsync(), GetPendingAsync(), XPoster.Contracts

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, catch(), if(), XPoster.SenderPlugins, IgSender(), SendAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), XPoster, if(), Run()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), ValidOptions(), XPoster.Tests.Models

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), XPoster.Credentials, CredentialsStartupValidator(), Validate(), InvalidOperationException(), if()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, GetPendingAsync(), XPoster.Services, UpdateStatusAsync(), SaveAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, if(), Input(), Execute_UsesSymbol_ForPostTag(), Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), if(), ResolveWorkflowOrchestrator(), nameof(), CreateEmptyNoOrchestrator()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSender_ImplementsISender(), IgSenderTests()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, XPoster.Workflows.Models, SetData(), IWorkflowContext, HasData()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, XPoster.Credentials, if(), Validate()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, BuildPowerLawPostNode(), ExecuteAsync(), if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), XPoster.Contracts, UploadAsync(), IBlobStorageService

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, Validate(), XPoster.Models, nameof(), if()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), if(), InstagramCredentialsValidator, XPoster.Credentials

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), MakeDownloadClient(), var(), MakeNoOpClient(), HttpClient()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown(), var(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), DefaultAzureCredential(), if(), Uri()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), return(), XPoster.Workflows.Utilities, catch(), IsJsonLike()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService

### Community 105 - "Entity (Community 105)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, ExecuteAsync(), XPoster.Workflows.Nodes, WorkflowNodeResult(), AcquireCryptoValueNode()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, if(), Validate(), nameof()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_PassesStepOptionsToPromptRequest(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), var(), Execute_ReturnsGeneratedText()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), XPoster.SenderPlugins, if(), DryRunSender()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), var(), Execute_ConcatenatesMultipleFeeds(), Input(), Execute_CallsFeedServiceForMultipleUrls()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, foreach(), XPoster.Workflows.Engine, if(), HasCycle()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, XPoster.Workflows.Services, Resolve()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, XPoster.Models, ValidateConnectivity(), if()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Providers

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, XPoster.Tests.Models, ValidOptions()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), XPoster.Contracts, ITextToTextProvider

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, IWorkflowNode, ExecuteAsync(), XPoster.Workflows.Abstractions

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Providers

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, ConfigurationStepOptionsResolver(), Resolve()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 138 - "Entity (Community 138)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, WorkflowDefinition(), ToDefinition()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 148 - "Entity (Community 148)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), if(), OpenAiService()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), var(), if(), XPoster.Services

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, IAiProviderSection, XPoster.Contracts

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), new(), WorkflowExecutionResult()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 165 - "Entity (Community 165)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, if(), SetupSender(), var()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), var(), StubNode()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 174 - "Entity (Community 174)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, PostAsync(), BaseOrchestrator()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), ValidateOptions(), resolve()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 176 - "Entity (Community 176)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 177 - "Entity (Community 177)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddHttpClients(), AddResilientHttpClient()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), new(), ExecuteAsync()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 169 - "Entity (Community 169)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), while(), PerplexityService()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 214 - "Entity (Community 214)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 199 - "Entity (Community 199)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 198 - "Entity (Community 198)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 200 - "Entity (Community 200)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 203 - "Entity (Community 203)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 205 - "Entity (Community 205)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 204 - "Entity (Community 204)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 201 - "Entity (Community 201)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 202 - "Entity (Community 202)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

