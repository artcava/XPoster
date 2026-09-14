# Graph Report - XPoster  (2026-09-14)

## Summary
- 2035 nodes · 3455 edges · 248 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster.Workflows.Nodes` - 2 edges
3. `XPoster.Tests.Helpers` - 2 edges
4. `XPoster.Extensions` - 2 edges
5. `XPoster.Models` - 2 edges
6. `WorkflowDefinitionValidatorTests` - 2 edges
7. `XPoster.Tests.Workflows.Engine` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, OpenAiB64Json(), new(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, BuildImagePromptRequest(), ChatCompletionJson(), BuildService(), XPoster.Tests.Services, OpenAiService(), MakeHandlerMock() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_DownloadThrows_LogsError(), Parse_MalformedJson_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildMaxSender(), BuildConfig(), ConfigurationBuilder(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), MaxSender_ImplementsISender() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, XPoster.Tests.Models, SectionName_IsPerplexity(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddAzureFoundryOptions_RegistersValidator(), AddDeepSeekOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, PerplexityService(), MakeHandlerMock(), MakeSequentialHandlerMock(), new(), GenerateTextAsync_WhenTextExceedsMaxOutputLength_CallsApiAndReturnsContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildCreds(), BuildFactory(), Constructor_WithNullFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions(), DeepSeekServiceTests, GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenUsedForImagePromptDerivation_ReturnsPrompt() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_JsonElement_ToString(), GetParameter_JsonElement_ToBool(), GetParameter_JsonElement_ToInt(), GetParameter_JsonElement_ToList(), GetParameter_ReturnsDefault_WhenKeyMissing(), GetParameter_MalformedJson_ForList_ReturnsEmptyOrNull() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, foreach(), _onExecute(), MissingRef(), LinearChain(), XPoster.Tests.Workflows.Engine, WorkflowExecutionEngineTests, static() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), Constructor_WithNullApiClient_ThrowsArgumentNullException(), Constructor_InitializesSender_ImplementsISender(), XSenderTests, XPoster.Tests.SenderPlugins (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, if(), LogWasCalled(), SendAsync_2xx_LogsAtDebugLevel(), SendAsync_4xx_LogsResponseHeaders(), SendAsync_SanitizesSecretInBody(), StubResponse(), XPoster.Tests.Extensions (+11 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, IgSenderImageFlowTests, BuildSender(), IgSender(), CreateMalformedPngBytes(), Uri(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_ForwardsModelName(), BuildChatPayload_FirstMessageRoleIsSystem(), AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_MessagesContainsTwoEntries() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FakeHttpMessageHandler(), BuildFactory(), BuildRssXml(), BuildService(), SendAsync(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, ConcurrentSetData_DoesNotThrow(), ConcurrentReadWrite_DoesNotThrow(), catch(), TryGetData_ReturnsTrue_WhenKeyExists(), SetData_OverwritesExistingValue(), SlotKey_IsSetCorrectly() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ImplementsIAiProviderOptions(), XPoster.Tests.Models, PerplexityOptions_ModelCatalog_ExposesTextOnly(), OpenAiOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), ModelCatalog_UnsupportedCapability_GetRequired_Throws() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, BuildProvider(), AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_WithValidWorkflow_DoesNotThrow(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), ConfigurationBuilder() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), MetaPublishingService(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, PromptRequestTests, ImagePromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_BaseProperties_AreAccessible(), ImagePromptRequest_ImageProperties_AreSetCorrectly() (+9 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_ParseSenderPlatforms(), ConfigurationBuilder(), CreateProvider(), GetProfiles_Should_MapEachSlotToWorkflowOrchestrator(), GetProfiles_Should_OrderSlotsByHour(), ConfigurationSlotProfileProviderTests (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), WorkflowDefinitionValidatorTests, XPoster.Tests.Workflows.Engine, WorkflowDefinition(), TwoTerminals(), Cyclic(), Linear() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), InMemoryContainerStateStoreTests, UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_LeavesCleanTextUnchanged(), HttpResponseBodySanitizerTests, Sanitize_MasksAccessTokenJsonField(), Sanitize_MasksJsonApiKey(), Sanitize_MasksApiKeyHeaderWithColon(), Sanitize_MasksBearerTokenInJson() (+8 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, Uri(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), new() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests, XPoster.Tests.Services, Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, BuildAllProvidersConfig(), ConfigurationBuilder(), XPoster.Tests.Extensions, AddAiProviderOptionsTests, AddAiProviderOptions_RegistersAllFiveValidators(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection() (+7 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, ProcessContainerAsync(), foreach(), if(), HandleTerminalFailureAsync(), PollPendingContainersAsync(), HandleFinishedAsync() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_AppliesTagReplacements(), Execute_BridgesMediaAttachment_ToPostImage(), Execute_ShortText_NoResummary(), Input(), Execute_StoresSendResultsInContext(), FanOutSendNodeTests, Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Choice_CanBeCreated_WithMessage(), ModelsTests, ImageData_CanBeCreated_WithUrl(), OpenAIImageResponse_CanBeCreated_WithData(), Message_CanBeCreated_WithContent(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, MakeDefinition(), return(), static(), WorkflowOrchestratorTests, XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), ProduceImage_Set_ThrowsNotSupported() (+6 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), XPoster.Tests.Models, TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Supports_ReturnsFalseForMissingModelClass(), AiModelCatalogTests, GetRequired_Throws_WhenNotSupported() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, BuildAuthorizationHeader_MediaUploadInit_PercentEncodesOAuthValuesPerRfc5849(), XPoster.Tests.SenderPlugins, PercentEncode_InputValue_ReturnsExpectedEncoding(), BuildAuthorizationHeader_PostToTweetsEndpoint_SignsOAuthOnlyParameters(), ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), ComputeSignature_PhotoExample_ReturnsExpectedBase64() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), XApiClientTests, XPoster.Tests.SenderPlugins, UploadMediaAsync_SmallImage_UsesInitAppendFinalizeFlow(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), UploadMediaAsync_EmptyMedia_ThrowsArgumentException() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenValidProviderNotRegistered(), if(), WorkflowNodeInput(), return(), static(), Input() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), InSender_ImplementsISender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), BuildSender() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingModelId_Fails(), ValidOptions(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_BindsImageProperties_WhenPresent(), if(), foreach(), ConfigurationStepOptionsResolverTests, BuildConfig(), Resolve_ReturnsStepOptions_WhenSectionExists() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, while(), GenerateImageAsync(), var(), GenerateTextAsync(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Platform_ReturnsLinkedIn(), MessageMaxLength_Returns2800(), InSender(), InSenderTests(), Constructor_InitializesCorrectly(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, typeof(), XPoster.Tests.Orchestrators, Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing() (+4 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnReadOnlyDictionary(), foreach(), XPoster.Tests.Providers (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenCancelledDuringForEach_StopsGracefully(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, for(), ArgumentException(), BuildSignedRequest(), catch(), CreateTweetAsync(), InitializeMediaAsync(), XApiClient() (+4 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, MessageMaxLength_Returns2200(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), BuildCreds(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersFalAi_AsImageOnly() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, OrchestratorContextKey_Should_BeNull_WhenNotProvided(), Constructor_Should_SetAllFields(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), OrchestratorContextKey_Should_BeSet_WhenProvided(), ScheduledOrchestrationProfileTests (+3 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, BuildAuthorizationHeader(), foreach(), XPoster.SenderPlugins, ParseQueryString(), if(), GetBaseUri() (+3 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, BuildSender(), InSenderResilienceTests, InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), IgSender(), BuildSender(), IgSenderSendAsyncTests, SendAsync_WithEmptyImageArray_ReturnsFalse() (+2 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishPhotoAsync(), PublishTextOnlyAsync(), SendAsync(), XPoster.SenderPlugins, HandleResponseAsync(), FbSender() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests, Build(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models, Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), BuildCreds() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, MetaPublishingService(), PublishContainerAsync(), XPoster.Services, GetContainerStatusAsync(), GetApiVersion(), catch() (+2 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildCreds(), FbSenderImageFlowTests, XPoster.Tests.SenderPlugins, HttpRequestException(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), InvalidImageBytes() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), XPoster.SenderPlugins, using(), catch(), generatePayLoad(), Exception(), ResolveAuthorUrn() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), catch(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), XPoster.Tests.Integration, params() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionEngine(), WorkflowExecutionResult(), XPoster.Workflows.Engine, if(), foreach(), ExecuteAsync() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeedTests (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, XSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), BuildSender() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), HttpClientExtensionsTests, AddHttpClients_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, foreach() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, TryGet(), XPoster.Models, InvalidOperationException(), AiModelCatalog(), if(), GetRequired() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), WorkflowNodeInput(), Execute_UsesDefaultSymbol_WhenNotProvided(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse() (+1 more)

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), AiTextNodeTests, static(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenProviderNameIsUnknown(), return()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, XPoster.Tests.Workflows.Nodes, return(), Execute_ReturnsFailure_WhenNoContentRetrieved(), foreach(), Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, static()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), CaptureLoggerProvider(), CreateLogger(), Dispose(), XPoster.Tests.Integration, CaptureLogger()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, ImageData, Message, OpenAIImageResponse, Choice, AIResponse

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), DeleteAsync(), if(), BlobStorageService(), BlobUploadResult(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, foreach(), XPoster.Workflows.Nodes, if(), WorkflowNodeResult(), FanOutSendNode(), ExecuteAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactory(), OrchestratorFactoryTests(), new(), CreateFactoryWithProfiles(), WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), SetupMocksForOrchestratorFactory()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), BuildChatPayload()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), XPoster.Services, if(), GenerateImageAsync(), catch(), GetImageGenerationEndpoint()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, if(), FetchRssNode(), ExecuteAsync(), foreach()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, SetData(), WorkflowContext, XPoster.Workflows.Models, KeyNotFoundException(), HasData(), if()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), CreateNode(), XPoster.Tests.Workflows.Nodes, Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), new(), WorkflowNodeInput()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostTests, Firm_IsNotNullOrEmpty(), XPoster.Tests.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, AiImageNode(), if(), ExecuteAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, CapturedRequest(), BuildSequenceHandler(), XPoster.Tests.Helpers, if(), StubHttpMessageHandler(), var()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, foreach(), HttpResponseBodyLogger(), IsEnabledFor(), while(), XPoster.Services, Log()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XSender(), SendAsync(), XPoster.SenderPlugins, if(), catch()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), if(), TagReplacementService(), XPoster.Services, Apply()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, if(), foreach(), XPoster.Workflows.Configuration, InvalidOperationException(), AddWorkflows()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), XPoster.Credentials, catch(), InvalidOperationException(), if(), CredentialsStartupValidator()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, IgSender(), if(), catch()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), Run(), XFunction(), XPoster, if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), ValidOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, return(), static(), SendAsync_OptOutHeader_LogsNothing(), SendAsync_NotEnabled_SuccessNotLogged(), SendAsync(), var()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), WorkflowNodeResult(), if(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), XPoster.Contracts, SaveAsync(), GetPendingAsync(), IContainerStateStore

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, Resolve(), catch(), XPoster.Orchestrators, ResolveSenders(), NoOrchestrator(), WorkflowOrchestrator()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, GetPendingAsync(), InMemoryContainerStateStore, XPoster.Services, UpdateStatusAsync(), SaveAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), GenerateImageAsync(), while(), XPoster.Services, GenerateTextAsync(), var()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, ThrowIfNotSuccess(), AppendMediaSegmentsAsync(), FinalizeMediaAsync(), if(), SignRequest()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, ExecuteAsync(), if(), XPoster.Workflows.Nodes, BuildPowerLawPostNode()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), InstagramCredentialsValidator, Validate(), XPoster.Credentials

### Community 122 - "Entity (Community 122)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests(), if(), Input(), Execute_UsesSymbol_ForPostTag()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService, PublishContainerAsync()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, IsJsonLike(), GetProvider(), catch(), return(), XPoster.Workflows.Utilities

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models

### Community 131 - "Entity (Community 131)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, if(), Validate(), FacebookCredentialsValidator

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, nameof(), if(), Validate(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), XPoster.Contracts, UploadAsync()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), var(), MakeNoOpClient(), MakeDownloadClient(), HttpClient()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), foreach(), HasCycle(), XPoster.Workflows.Engine

### Community 135 - "Entity (Community 135)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, XPoster.Services, SendAsync(), HttpResponseBodyLoggingHandler(), IsBinaryMediaType(), foreach()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), BlobServiceClient(), if(), Uri()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.33
Nodes (6): XApiException.cs, catch(), foreach(), XApiException(), XPoster.SenderPlugins, BuildMessage()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), Validate(), nameof(), XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), XPoster.Models, nameof(), Validate()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, WorkflowNodeResult(), AcquireCryptoValueNode(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), ResolveWorkflowOrchestrator(), CreateEmptyNoOrchestrator(), if(), nameof()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, SetData(), IWorkflowContext, HasData(), XPoster.Workflows.Models

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), XPoster.SenderPlugins, SendAsync(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Input(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText(), var()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), var(), Execute_CallsFeedServiceForMultipleUrls(), Input(), Execute_ConcatenatesMultipleFeeds()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_Throws_WhenProviderNameIsUnknown(), var()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, if(), SanitizeAndTruncate(), TruncateUtf8(), FormatResponseHeaders()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 159 - "Entity (Community 159)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient(), AddHttpResponseBodyLogging()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, OkJson(), HttpResponseMessage(), if(), BuildApiClient()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Providers

### Community 166 - "Entity (Community 166)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 164 - "Entity (Community 164)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), var(), GenerateTextAsync(), XPoster.Services

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, IAiProviderSection, XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, Apply(), XPoster.Contracts

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, ToDefinition(), XPoster.Workflows.Configuration, WorkflowDefinition()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetImageGenerationEndpoint(), OpenAiService(), GetChatCompletionsEndpoint(), if()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Contracts, ICryptoService

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GenerateTextAsync()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, if(), WorkflowOrchestrator()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Providers, TimeProvider

### Community 171 - "Entity (Community 171)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, BuildFactory(), params(), SendAsync(), _responder()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Contracts

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), ITextToImageProvider, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, ICredentialsStartupValidator, Validate()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, ConfigurationStepOptionsResolver(), Resolve()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, XPoster.Models, PromptRequest

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 152 - "Entity (Community 152)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, XPoster.Tests.Integration, static(), return(), ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 207 - "Entity (Community 207)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 210 - "Entity (Community 210)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 214 - "Entity (Community 214)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, BaseOrchestrator(), PostAsync()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, SetupSender(), var(), if()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, new(), WorkflowExecutionResult(), var()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), ExecuteAsync(), new()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), ConfigurationSlotProfileProvider()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer(), var()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, XPoster.Services, foreach(), SanitizeUrl()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 244 - "Entity (Community 244)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 241 - "Entity (Community 241)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, if(), Sanitize()

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 233 - "Entity (Community 233)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 236 - "Entity (Community 236)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 238 - "Entity (Community 238)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 239 - "Entity (Community 239)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 237 - "Entity (Community 237)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 230 - "Entity (Community 230)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, InvalidOperationException(), if()

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, TryLogAsync(), if()

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

