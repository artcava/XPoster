# Graph Report - XPoster  (2026-09-06)

## Summary
- 1885 nodes · 3188 edges · 230 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Providers` - 2 edges
2. `XPoster.Workflows.Engine` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Tests.Workflows.Nodes` - 2 edges
5. `AiTextNodeTests` - 2 edges
6. `XPoster.Tests.Workflows.Nodes` - 2 edges
7. `WorkflowContext` - 2 edges
8. `XPoster.Workflows.Models` - 2 edges
9. `XPoster.Workflows.Nodes` - 2 edges
10. `XPoster.Workflows.Nodes` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), HttpClient(), FalAiJson(), ParseImageResponseAsync_FalAi_MissingImagesArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, BuildImagePromptRequest(), AzureFoundryServiceTests, AzureFoundryService(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, new(), MakeHandler(), MakeHandlerMock(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunMaxLengthSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MaxSender_MessageMaxLength_IsIntMaxValue(), DryRunShortLengthSender(), MaxSender_ImplementsISender() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, XPoster.Tests.Models, SectionName_IsFalAi(), SectionName_IsPerplexity(), SectionName_IsOpenAI(), AddFalAiOptions_RegistersValidator(), AddDeepSeekOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), XPoster.Tests.Services, PerplexityServiceTests, GenerateTextAsync_ImagePromptRole_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenApiReturnsValidResponse_ReturnsPrompt() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildFactory(), BuildSender(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), FbSenderTests(), NormalizeImage_WithValidJpeg_ReturnsSameBytes() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_ConvertChangeType_IntFromString(), GetParameter_ConversionFailure_ReturnsDefault(), GetParameter_JsonElement_ToBool(), GetParameter_DirectCast_Int(), GetParameter_DirectCast_String(), GetParameter_JsonArrayString_ToList() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), XPoster.Tests.Services, MakeHandlerMock() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, Platform_ReturnsX(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), MessageMaxLength_Returns250(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, EmptySenders(), Cyclic(), Diamond(), Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_EmptyNodesDefinition_Succeeds(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs() (+13 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, SlotKey_IsSetCorrectly(), HasData_ReturnsFalse_WhenKeyMissing(), SetData_AndGetData_RoundTrip(), lock(), HasData_ReturnsTrue_WhenKeyExists(), SetData_OverwritesExistingValue() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), new(), SendAsync(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_ForwardsTemperature(), BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, OpenAiOptions_ModelCatalog_ExposesTextAndImage(), PerplexityOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ModelCatalog_ExposesTextOnly(), XPoster.Tests.Models, FalAiOptions_ImplementsIAiProviderOptions(), AzureFoundryOptions_ImplementsIAiProviderOptions() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WhenCodecIsNull_ReturnsNull(), CreateMalformedPngBytes(), IgSender(), IgSenderImageFlowTests, NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, XPoster.Tests.Workflows.Configuration, AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), AddWorkflows_Registers_StepOptionsResolver(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequestTests, PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, ImagePromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_BaseProperties_AreAccessible(), ImagePromptRequest_ImageProperties_DefaultToNull() (+9 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_OrderSlotsByHour(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_ParseSenderPlatforms(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured(), GetProfiles_Should_MapEachSlotToWorkflowOrchestrator() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, MissingRef(), Linear(), Cyclic(), XPoster.Tests.Workflows.Engine, ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), WorkflowDefinitionValidatorTests, ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), XPoster.Tests.Services, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList() (+8 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenStorageThrows_PropagatesException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), PostWithoutImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, BuildAllProvidersConfig(), XPoster.Tests.Extensions, AddAiProviderOptionsTests, ConfigurationBuilder(), AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, Run(), HandleFinishedAsync(), HandleTerminalFailureAsync(), if(), PollPendingContainersAsync(), ProcessContainerAsync() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_ShortText_NoResummary(), Execute_LongText_WithFallback_Resummarises(), Execute_BridgesMediaAttachment_ToPostImage(), Execute_AppliesTagReplacements(), Execute_StoresSendResultsInContext(), FanOutSendNodeTests, Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, static(), WorkflowOrchestratorTests, XPoster.Tests.Orchestrators, return(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), Properties_AreConfigured(), ProduceImage_Set_ThrowsNotSupported() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, AIResponse_CanBeCreated_WithChoices(), RSSFeed_CanBeCreated_WithAllProperties(), XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), Post_CanHold_ImageBytes(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingApiKey_Fails(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_MissingModelId_Fails() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_ReturnsModelName_WhenSupported(), Empty_SupportsNoModelClass(), AiModelCatalogTests, Constructor_NullDictionary_Throws(), Constructor_ExcludesNullOrWhitespaceEntries(), Supports_ReturnsFalseForMissingModelClass() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, FalAiImageServiceTests, BuildService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, AiImageNodeTests, Input(), Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), Execute_ReturnsNullOutput_OnSoftFailure() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), InSender_ImplementsISender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenCancelledDuringForEach_StopsGracefully(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), XPosterContainerPollingFunctionTests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), XPoster.Tests (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, InSender(), Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), MessageMaxLength_Returns2800(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GenerateTextAsync(), XPoster.Services, GetChatCompletionsEndpoint(), if(), while(), var() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_BindsImageProperties_WhenPresent(), BuildConfig(), if(), foreach(), ConfigurationStepOptionsResolverTests (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersFalAi_AsImageOnly() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSender(), InSenderResilienceTests, BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildCreds(), BuildSender(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), new(), Platform_ReturnsInstagram() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields(), XPoster.Tests.Models, OrchestratorContextKey_Should_BeNull_WhenNotProvided(), OrchestratorContextKey_Should_BeSet_WhenProvided(), typeof(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys() (+3 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XFunctionTests() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), XPoster.Tests.Models, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WithValidOptions_ReturnsSuccess(), ValidOptions() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), XPoster.Tests.SenderPlugins, BuildSender() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators, SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty(), NoOrchestratorTests, Build() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), BuildSender(), XPoster.Tests.SenderPlugins, XSender(), XSenderResilienceTests (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), XPoster.SenderPlugins, PublishTextOnlyAsync(), PublishPhotoAsync(), catch(), FbSender() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, MetaPublishingService(), if(), catch(), HttpRequestException(), GetApiVersion(), GetContainerStatusAsync() (+2 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, ExecuteAsync(), WorkflowExecutionResult(), while(), WorkflowExecutionEngine(), if(), foreach() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), CreateTimerInfo(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), params(), XPoster.Tests.Integration, var(), BuildDelayedHandler(), BuildProviderWithHandler() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildFactory(), BuildCreds(), HttpRequestException(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeedTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), catch() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersIHttpClientFactory(), foreach(), XPoster.Tests.Extensions, HttpClientExtensionsTests (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Orchestrators, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, WorkflowNodeInput(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), AcquireCryptoValueNodeTests(), Input(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), Execute_UsesDefaultSymbol_WhenNotProvided() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, AiModelCatalog(), InvalidOperationException(), XPoster.Models, GetRequired(), Supports(), TryGet() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), InvalidOperationException(), XPoster.SenderPlugins, using(), generatePayLoad(), ResolveAuthorUrn(), Exception() (+1 more)

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, XPoster.Services, if(), UploadAsync(), BlobUploadResult(), DeleteAsync(), BlobStorageService()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, new(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), CreateNode(), Execute_OmitsDelta_WhenActualValueZeroOrMissing()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, static(), XPoster.Tests.Workflows.Nodes, FetchRssNodeTests, Execute_ReturnsFailure_WhenNoUrlsProvided(), Execute_ReturnsFailure_WhenNoContentRetrieved(), return(), foreach()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, AiTextNodeTests, Execute_Throws_WhenProviderNameIsUnknown(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, return(), static(), Execute_ReturnsFailure_WhenProviderReturnsEmpty()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, HasData(), WorkflowContext, SetData(), XPoster.Workflows.Models, KeyNotFoundException(), if()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CaptureLoggerProvider(), CaptureLogger(), CreateLogger(), Dispose(), IsEnabled()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, BuildChatPayload(), XPoster.Services, ParseImageResponseAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), foreach(), FetchRssNode(), if(), ExecuteAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GetImageGenerationEndpoint(), GenerateImageAsync(), if(), XPoster.Services, FalAiImageService(), catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, ImageData, Choice, OpenAIImageResponse, AIResponse, Message

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, if(), ExecuteAsync(), FanOutSendNode(), foreach()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactoryWithProfiles(), OrchestratorFactoryTests(), new(), SetupMocksForOrchestratorFactory(), CreateFactory()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), ValidOptions()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), if(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, XPoster.Credentials, InvalidOperationException(), CredentialsStartupValidator(), catch(), if(), Validate()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, XPoster.Services, while(), catch(), GenerateTextAsync(), var(), GenerateImageAsync()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync(), SaveAsync(), IContainerStateStore

### Community 91 - "Entity (Community 91)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, Resolve(), catch(), NoOrchestrator(), ResolveSenders(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), ExecuteAsync(), if(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), HttpResponseMessage()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, if(), XPoster.Workflows.Configuration, InvalidOperationException(), AddWorkflows(), foreach()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), TagReplacementService(), foreach(), XPoster.Services

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, if(), Run(), catch(), XPoster, XFunction()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), XPoster.Services

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, XPoster.Workflows.Nodes, AiImageNode(), WorkflowNodeResult(), if(), ExecuteAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, CreateEmptyNoOrchestrator(), nameof(), OrchestratorFactory(), ResolveWorkflowOrchestrator(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, BuildPowerLawPostNode(), ExecuteAsync(), if()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, HasCycle(), if(), XPoster.Workflows.Engine, foreach()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, XPoster.Workflows.Nodes, ExecuteAsync(), WorkflowNodeResult(), AcquireCryptoValueNode()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, var(), WorkflowNodeInput(), Input(), Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_UsesSymbol_ForPostTag(), BuildPowerLawPostNodeTests(), Execute_DateBeforeGenesis_ReturnsFailure(), if(), Input()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), HttpClient(), MakeNoOpClient(), MakeDownloadClient()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, return(), XPoster.Workflows.Utilities, catch(), GetProvider(), IsJsonLike()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), IWorkflowContext, SetData(), XPoster.Workflows.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSenderTests()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), XPoster.Models, Validate(), nameof()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), FacebookCredentialsValidator

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync(), IMetaPublishingService

### Community 101 - "Entity (Community 101)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_ReturnsGeneratedText(), var(), Input(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_PassesStepOptionsToPromptRequest()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, nameof(), if(), XPoster.Models, Validate()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), BlobServiceClient(), if(), DefaultAzureCredential()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_Throws_WhenProviderNameIsUnknown(), var(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), XPoster.SenderPlugins, SendAsync()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), IBlobStorageService, DeleteAsync()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), if(), XPoster.Credentials, InstagramCredentialsValidator

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 138 - "Entity (Community 138)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), MaskUrlTelemetryProcessor(), Process()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, Resolve(), IStepOptionsResolver, XPoster.Workflows.Services

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, WorkflowDefinition(), ToDefinition()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, XPoster.Workflows.Abstractions, IWorkflowNode, ExecuteAsync()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 131 - "Entity (Community 131)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), if(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, XPoster.Contracts, IAiProviderOptions, IAiProviderSection

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, if(), Validate()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, WorkflowOrchestrator(), XPoster.Orchestrators, if()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, GetCurrentTime(), TimeProvider

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 157 - "Entity (Community 157)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, XPoster.Services, var(), GenerateTextAsync(), if()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, XPoster.Models, ImagePromptRequest

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), new(), WorkflowExecutionResult()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, BaseOrchestrator(), PostAsync()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, new(), Node(), ExecuteAsync()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, if(), var(), SetupSender()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 176 - "Entity (Community 176)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), new(), StubNode()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 173 - "Entity (Community 173)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 171 - "Entity (Community 171)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): MediaType.cs, XPoster.Workflows.Models, MediaType.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Workflows.Models, PromptStepOptions.cs

### Community 199 - "Entity (Community 199)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 198 - "Entity (Community 198)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 200 - "Entity (Community 200)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 212 - "Entity (Community 212)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 203 - "Entity (Community 203)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 205 - "Entity (Community 205)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, SlotScheduleOptions.cs, XPoster.Models

### Community 204 - "Entity (Community 204)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 201 - "Entity (Community 201)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 202 - "Entity (Community 202)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

