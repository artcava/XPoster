# Graph Report - XPoster  (2026-09-13)

## Summary
- 1953 nodes · 3309 edges · 237 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `PostTests` - 2 edges
2. `AiTextNodeTests` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `XPoster.Tests.Workflows.Nodes` - 2 edges
5. `XPoster.Tests.Orchestrators` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Workflows.Utilities` - 2 edges
8. `XPoster.Workflows.Nodes` - 2 edges
9. `XPoster.Tests.Models` - 2 edges
10. `AzureFoundryOptionsTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, XPoster.Tests.Services, var(), ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateTextAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GenerateTextAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmpty() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, ConfigurationBuilder(), BuildShortSender(), BuildMaxSender(), BuildConfig(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_ReturnsTrue() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, BuildService(), BuildImagePromptRequest(), GenerateTextAsync_ImagePromptRole_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenApiReturnsValidResponse_ReturnsPrompt() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullFactory_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildCreds() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_JsonObjectString_ToDictionary(), GetParameter_JsonElement_ToBool(), GetParameter_JsonElement_ToString(), GetParameter_JsonElement_ToInt(), GetParameter_JsonElement_ToList(), NodeParameterExtractorTests (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_EmptyNodesDefinition_Succeeds(), EmptySenders(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_Cycle_ReturnsFailure_WithDescriptiveError(), _onExecute(), foreach(), MissingRef() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, if(), SendAsync_ImagePost_WhenUploadAndTweetSucceed_ReturnsTrue(), MessageMaxLength_Returns250(), Platform_ReturnsX(), XSenderTests, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+13 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, SetData_AndGetData_RoundTrip(), lock(), GetData_ThrowsOnMissingKey(), GetData_ThrowsOnTypeMismatch(), HasData_ReturnsTrue_WhenKeyExists(), HasData_ReturnsFalse_WhenKeyMissing() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), SendAsync(), new(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, return(), BuildRequest(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), GetContent(), GetRole(), BuildChatPayload_ForwardsMaxTokenBudget() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AiProviderOptionsAbstractionTests, AzureFoundryOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), DeepSeekOptions_ModelCatalog_ExposesTextOnly(), FalAiOptions_ModelCatalog_ExposesImageOnly() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, return(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), IgSender(), BuildSender() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_Registers_StepOptionsResolver(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_ConvertsParameters_ToObjectDictionary(), InMemory(), MakeConfiguration(), ServiceCollection() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_BaseProperties_AreAccessible(), ImagePromptRequest_ImageProperties_DefaultToNull(), PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequestTests (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), CreateSut(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException() (+9 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured(), GetProfiles_Should_OrderSlotsByHour(), GetProfiles_Should_ParseSenderPlatforms(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_SkipSlot_WithNoSenders() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, XPoster.Tests.Workflows.Engine, ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), WorkflowDefinitionValidatorTests, WorkflowDefinition(), ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateStructural_Cycle_ReturnsError() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), new(), PostWithoutImage() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenStorageThrows_PropagatesException(), XPoster.Tests.Services (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), XPoster, PollPendingContainersAsync(), TryDeleteBlobAsync(), ProcessContainerAsync(), switch() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl(), AIResponse_CanBeCreated_WithChoices(), Choice_CanBeCreated_WithMessage(), RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, WorkflowOrchestratorTests, ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), return(), Properties_AreConfigured(), static(), ProduceImage_Set_ThrowsNotSupported(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, FanOutSendNodeTests, static(), Input(), WorkflowNodeInput(), return(), XPoster.Tests.Workflows.Nodes, Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), foreach(), UploadMediaAsync_EmptyMedia_ThrowsArgumentException(), CreateTweetAsync_WithText_ReturnsTweetId() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, static(), return(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Input(), Execute_ReturnsMediaAttachment_OnSuccess(), if() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildCreds(), InSender_ImplementsISender(), BuildSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), LocalOverrideTimeProvider() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, ValidOptions(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_Throws_WhenNotSupported(), XPoster.Tests.Models, Supports_ReturnsFalseForMissingModelClass(), Supports_ReturnsTrueForRegisteredModelClass(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported() (+5 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), XPoster.Tests.Orchestrators, Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, foreach(), ConfigurationStepOptionsResolverTests, BuildConfig(), Resolve_BindsImageProperties_WhenPresent(), Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_Throws_WhenStepMissing() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), MessageMaxLength_Returns2800(), Constructor_InitializesCorrectly(), Platform_ReturnsLinkedIn() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), foreach() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), MakeHandlerMock(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenNoPendingContainers_DoesNothing() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, CreateTweetAsync(), catch(), BuildSignedRequest(), ArgumentException(), HasErrorPayload(), XApiException(), XApiClient() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, XPoster.Services, var(), if(), AzureFoundryService(), GenerateTextAsync(), GetImageGenerationEndpoint() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, ComputeSignature(), BuildAuthorizationHeader(), ComputeSignatureBaseString(), PercentEncode(), ParseQueryString(), GetBaseUri() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AiProviderServiceCollectionExtensionsTests (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, BuildSender(), InSenderResilienceTests, ValidPost(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, OrchestratorContextKey_Should_BeSet_WhenProvided(), ScheduledOrchestrationProfileTests, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), XPoster.Tests.Models, typeof(), Constructor_Should_SetAllFields() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, PercentEncode_InputValue_ReturnsExpectedEncoding(), XPoster.Tests.SenderPlugins, XOAuth1SignerTests, BuildPhotoParameters(), BuildCredentials(), BuildAuthorizationHeader_PostToTweetsEndpoint_SignsOAuthOnlyParameters() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, MessageMaxLength_Returns2200(), BuildCreds(), Constructor_InitializesCorrectly(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender() (+3 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), FbSenderSendAsyncTests, BuildCreds(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), XPoster.SenderPlugins, PublishPhotoAsync(), if(), FbSender(), HandleResponseAsync() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse(), IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, MetaPublishingService(), HttpRequestException(), if(), GetContainerStatusAsync(), catch(), GetApiVersion() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyList(), Build(), NoOrchestratorTests, Name_IsNoOrchestrator() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse() (+2 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, generatePayLoad(), catch(), Exception(), InvalidOperationException(), ResolveAuthorUrn(), using() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, HttpRequestException(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), BuildFactory(), FbSenderImageFlowTests, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine, WorkflowExecutionEngine(), if(), ExecuteAsync(), while() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), HttpClientExtensionsTests, AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, if(), TryGet(), InvalidOperationException(), XPoster.Models, Supports(), AiModelCatalog() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), var(), XPoster.Tests.Integration, BuildProviderWithHandler(), HttpResponseMessage(), params() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, PostTests, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, return(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), Execute_Throws_WhenProviderNameIsUnknown(), AiTextNodeTests, XPoster.Tests.Workflows.Nodes, static(), WorkflowNodeInput()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, XPoster.Services, LogAndReturnEmpty(), ExtractOpenAiBytes(), BuildChatPayload(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), CreateLogger(), IsEnabled(), XPoster.Tests.Integration, Dispose()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, static(), FetchRssNodeTests, Execute_ReturnsFailure_WhenNoUrlsProvided(), XPoster.Tests.Workflows.Nodes, return(), Execute_ReturnsFailure_WhenNoContentRetrieved(), foreach()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), BlobStorageService(), DeleteAsync(), if(), UploadAsync(), XPoster.Services

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, if(), foreach(), ExecuteAsync(), FanOutSendNode(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, OpenAIImageResponse, Choice, Message, AIResponse, XPoster.Models

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_OmitsDelta_WhenActualValueZeroOrMissing(), new(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, HasData(), SetData(), XPoster.Workflows.Models, if(), KeyNotFoundException(), WorkflowContext

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, ExecuteAsync(), FetchRssNode(), foreach(), WorkflowNodeResult(), if(), XPoster.Workflows.Nodes

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), new(), OrchestratorFactoryTests(), CreateFactoryWithProfiles(), CreateFactory()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, catch(), GenerateImageAsync(), GetImageGenerationEndpoint(), if(), FalAiImageService(), XPoster.Services

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, AddWorkflows(), InvalidOperationException(), if(), foreach(), XPoster.Workflows.Configuration

### Community 102 - "Entity (Community 102)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), var(), GenerateTextAsync(), while(), GenerateImageAsync(), XPoster.Services

### Community 103 - "Entity (Community 103)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, XPoster.Credentials, InvalidOperationException(), Validate(), CredentialsStartupValidator(), if(), catch()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XPoster.SenderPlugins, SendAsync(), if(), catch(), XSender()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), HttpResponseMessage()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, catch(), XPoster.Orchestrators, Resolve(), ResolveSenders(), WorkflowOrchestrator(), NoOrchestrator()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), if(), TagReplacementService(), XPoster.Services, Apply()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, SaveAsync(), XPoster.Contracts, UpdateStatusAsync()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), AiTextNode(), if(), ExecuteAsync()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, GetPendingAsync(), SaveAsync(), XPoster.Services, UpdateStatusAsync(), InMemoryContainerStateStore

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests

### Community 97 - "Entity (Community 97)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, var(), StubHttpMessageHandler(), if(), BuildSequenceHandler(), CapturedRequest(), XPoster.Tests.Helpers

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), IgSender(), if(), catch(), XPoster.SenderPlugins

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), XPoster.Workflows.Nodes, WorkflowNodeResult(), if(), ExecuteAsync()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), XPoster, XFunction(), if(), catch()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, XPoster.Models, nameof(), if(), Validate()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, return(), catch(), GetProvider(), IsJsonLike(), XPoster.Workflows.Utilities

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Input(), if(), Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), BuildPowerLawPostNodeTests()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, AzureFoundryOptionsTests

### Community 116 - "Entity (Community 116)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, AppendMediaSegmentsAsync(), FinalizeMediaAsync(), SignRequest(), ThrowIfNotSuccess(), if()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), XPoster.Workflows.Nodes, ExecuteAsync(), WorkflowNodeResult()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, if(), XPoster.Workflows.Nodes, BuildPowerLawPostNode(), ExecuteAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), SendAsync(), XPoster.SenderPlugins

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), MakeNoOpClient(), MakeDownloadClient(), HttpClient(), var()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), XPoster.Contracts, IMetaPublishingService, GetContainerStatusAsync()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, var(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, var(), WorkflowNodeInput(), Execute_CallsFeedServiceForMultipleUrls(), Execute_ConcatenatesMultipleFeeds(), Input()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, XPoster.Workflows.Models, HasData(), IWorkflowContext, SetData()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSender_ImplementsISender(), IgSenderTests(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, foreach(), HasCycle(), if(), XPoster.Workflows.Engine

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Providers

### Community 122 - "Entity (Community 122)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_PassesStepOptionsToPromptRequest(), var(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), Execute_ReturnsGeneratedText()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), nameof(), ResolveWorkflowOrchestrator(), if(), CreateEmptyNoOrchestrator()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), IBlobStorageService, DeleteAsync()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), FacebookCredentialsValidator

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 117 - "Entity (Community 117)"
Cohesion: 0.33
Nodes (6): XApiException.cs, XApiException(), XPoster.SenderPlugins, BuildMessage(), catch(), foreach()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), InstagramCredentialsValidator, if(), XPoster.Credentials

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), BlobServiceClient(), DefaultAzureCredential(), Uri()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, if(), Validate(), nameof()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), XPoster.Models, ValidateConnectivity()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, ToDefinition(), WorkflowDefinition(), XPoster.Workflows.Configuration

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, Apply(), XPoster.Contracts

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 146 - "Entity (Community 146)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, if(), var(), GenerateTextAsync(), XPoster.Services

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), XPoster.Workflows.Abstractions, IWorkflowNode

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, IStepOptionsResolver, Resolve()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 160 - "Entity (Community 160)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), if(), GetImageGenerationEndpoint(), OpenAiService()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, BuildApiClient(), OkJson(), if(), HttpResponseMessage()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), XPoster.Contracts, ITextToImageProvider

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, SendAsync(), BuildFactory(), params(), _responder()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), XPoster.Extensions, AddHttpClients()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), new(), var()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, GetProfiles(), ConfigurationSlotProfileProvider(), XPoster.Providers

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, new(), ExecuteAsync(), Node()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 171 - "Entity (Community 171)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), GetChatCompletionsEndpoint(), DeepSeekService()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 176 - "Entity (Community 176)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 178 - "Entity (Community 178)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), StubNode(), new()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 207 - "Entity (Community 207)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): MediaType.cs, XPoster.Workflows.Models, MediaType.cs

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Workflows.Models, PromptStepOptions.cs

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, XPoster.Models, SlotScheduleOptions.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 229 - "Entity (Community 229)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 230 - "Entity (Community 230)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiModelClass.cs, AiModelClass.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

