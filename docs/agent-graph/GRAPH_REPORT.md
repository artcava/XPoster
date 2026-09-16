# Graph Report - XPoster  (2026-09-16)

## Summary
- 2037 nodes · 3459 edges · 249 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Workflows.Nodes` - 2 edges
3. `FbSenderSendAsyncTests` - 2 edges
4. `XPoster.Tests.Contracts` - 2 edges
5. `XPoster.Tests.Services` - 2 edges
6. `LocalOverrideTimeProviderTests` - 2 edges
7. `XPoster.Tests.Services` - 2 edges
8. `MaskUrlTelemetryProcessorTests` - 2 edges
9. `XPoster.SenderPlugins` - 2 edges
10. `IBlobStorageService` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, HttpClient(), FalAiJson(), ChatJson(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), new(), OpenAiB64Json() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, XPoster.Tests.Services, if(), MakeHandlerMock(), GenerateImageAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), ChatCompletionJson() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, BuildService(), BuildPromptRequest(), BuildImagePromptRequest(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, ShortSender_ImplementsISender(), ShortSender_MessageMaxLength_IsFifty(), ShortSender_Platform_IsDryRunShortLength(), ConfigurationBuilder(), BuildShortSender(), BuildMaxSender() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_MalformedJson_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, OptionsExtensionsTests, new(), OpenAiOptionsExtensionsTests, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_ImagePromptRole_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateTextAsync_ImagePromptRole_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), BuildFactory(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, new(), SummaryRequest(), XPoster.Tests.Services, GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetProvider_Throws_WhenUnknownName(), GetProvider_UsesProvidedDefault_WhenMissing(), NodeParameterExtractorTests, XPoster.Tests.Workflows.Utilities, GetParameter_ReturnsDefault_WhenKeyMissing(), GetParameter_ReturnsDefault_WhenValueIsNull() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullApiClient_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesSender_ImplementsISender(), XSenderTests, XPoster.Tests.SenderPlugins, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_UnregisteredNodeType_ReturnsFailure(), LinearChain(), foreach(), ExecuteAsync(), Execute_NodeFailure_StopsExecution_AndReturnsError(), Execute_EmptyNodesDefinition_Succeeds(), Execute_MissingRef_ReturnsFailure_WithDescriptiveError() (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, StubResponse(), SendAsync_OctetStreamResponse_LogsSummaryWithoutBody(), SendAsync_SanitizesAccessTokenInUrl(), SendAsync_SanitizesSecretInBody(), BuildClient(), BinaryResponseHandler(), LogWasCalled() (+11 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), return(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), Uri() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, SlotKey_IsSetCorrectly(), HasData_ReturnsTrue_WhenKeyExists(), SetData_AndGetData_RoundTrip(), lock(), SetData_OverwritesExistingValue(), TryGetData_ReturnsTrue_WhenKeyExists() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, return(), BuildRequest(), GetContent(), GetRole(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildChatPayload_MessagesContainsTwoEntries() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, OpenAiOptions_ModelCatalog_ExposesTextAndImage(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), ModelCatalog_UnsupportedCapability_GetRequired_Throws(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), OpenAiOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ImplementsIAiProviderOptions() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, foreach(), FakeHttpMessageHandler(), FeedService(), FeedServiceTests, BuildRssXml(), BuildFactory() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, MakeConfiguration(), AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), BuildProvider(), ConfigurationBuilder(), InMemory(), AddWorkflows_WithValidWorkflow_DoesNotThrow() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_OptionalProperties_DefaultToNull(), PromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_Temperature_AcceptsZeroAndOne(), ImagePromptRequest_ImageProperties_AreSetCorrectly() (+9 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_LeavesCleanTextUnchanged(), HttpResponseBodySanitizerTests, Sanitize_MasksRefreshTokenField(), Sanitize_MasksApiKeyHeaderWithColon(), Sanitize_MasksBearerTokenInHeader(), Sanitize_MasksBearerTokenInJson() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, XPoster.Tests.Workflows.Engine, WorkflowDefinitionValidatorTests, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), WorkflowDefinition(), Linear() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), GetPendingAsync_ReturnsOnlyPendingEntries(), XPoster.Tests.Services, UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_OrderSlotsByHour(), ConfigurationBuilder(), ConfigurationSlotProfileProviderTests, GetProfiles_Should_MapEachSlotToWorkflowOrchestrator(), CreateProvider(), XPoster.Tests.Providers (+8 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), XPoster.Tests.Services, Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), MaskUrlTelemetryProcessorTests (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, DeleteAsync_WhenBlobExists_DeletesSuccessfully(), BlobStorageServiceTests, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), CreateSut() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), BuildSender(), IgSender(), IgSenderResilienceTests, new(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, ConfigurationBuilder(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptionsTests, AddAiProviderOptions_ReturnsSameServiceCollection(), BuildAllProvidersConfig(), AddAiProviderOptions_RegistersAllFiveValidators() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleTerminalFailureAsync(), HandleFinishedAsync(), foreach(), catch(), XPosterContainerPollingFunction(), if() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIImageResponse_CanBeCreated_WithData(), RSSFeed_CanBeCreated_WithAllProperties(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, WorkflowNodeInput(), Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), Input(), FanOutSendNodeTests, return(), static(), Execute_LongText_WithFallback_Resummarises() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), return(), Properties_AreConfigured(), ProduceImage_Set_ThrowsNotSupported(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), static(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing() (+6 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), LocalOverrideTimeProvider() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), InSender_ImplementsISender(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, CreateTweetAsync_WithText_ReturnsTweetId(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), UploadMediaAsync_EmptyMedia_ThrowsArgumentException(), XPoster.Tests.SenderPlugins, UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Supports_ReturnsFalseForMissingModelClass(), XPoster.Tests.Models, GetRequired_Throws_WhenNotSupported(), Supports_ReturnsTrueForRegisteredModelClass(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, static(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Input(), Execute_ReturnsMediaAttachment_OnSuccess(), if(), Execute_Throws_WhenValidProviderNotRegistered() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, XPoster.Tests.SenderPlugins, ComputeSignature_PhotoExample_ReturnsExpectedBase64(), ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), ExtractHeaderValue(), PercentEncode_InputValue_ReturnsExpectedEncoding(), XOAuth1SignerTests (+5 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), CreateSut(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), foreach(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, XApiClient(), XPoster.SenderPlugins, XApiException(), InitializeMediaAsync(), ArgumentException(), HasErrorPayload(), for() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSenderTests(), Platform_ReturnsLinkedIn(), Constructor_InitializesCorrectly(), MessageMaxLength_Returns2800(), InSender() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, foreach(), ConfigurationStepOptionsResolverTests, BuildConfig(), Resolve_BindsImageProperties_WhenPresent(), XPoster.Tests.Workflows.Services, Resolve_BindsMaxOutputLength_WhenPresent() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers (+4 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), XPoster.Tests.Models, typeof() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, GetBaseUri(), foreach(), ComputeSignature(), ComputeSignatureBaseString(), BuildAuthorizationHeader(), PercentEncode() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, ValidPost(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildCreds(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Platform_ReturnsInstagram(), XPoster.Tests.SenderPlugins, new() (+3 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, BuildCreds(), BuildFactory(), FbSenderSendAsyncTests, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, if(), PublishTextOnlyAsync(), PublishPhotoAsync(), SendAsync(), XPoster.SenderPlugins, catch() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, IgSender() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), Build(), NoOrchestratorTests, OrchestrateAsync_ReturnsEmptyList(), SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), PerplexityOptionsValidatorTests (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), catch(), MetaPublishingService(), PublishContainerAsync(), GetContainerStatusAsync(), HttpRequestException() (+2 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), params(), BuildSequenceHandler(), var(), XPoster.Tests.Integration, HttpResponseMessage() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, Supports(), TryGet(), XPoster.Models, if(), GetRequired(), AiModelCatalog() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedTests (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_UsesDefaultSymbol_WhenNotProvided(), XPoster.Tests.Workflows.Nodes, Input(), WorkflowNodeInput(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionEngine(), while(), ExecuteAsync(), if(), foreach(), XPoster.Workflows.Engine (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), HttpResponseMessage() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), XPoster.Tests.Extensions, HttpClientExtensionsTests, AddHttpClients_RegistersIHttpClientFactory(), foreach(), AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), CreateTimerInfo(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, FbSenderImageFlowTests, BuildFactory(), BuildCreds(), InvalidImageBytes() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, Exception(), ResolveAuthorUrn(), generatePayLoad(), using(), InvalidOperationException(), catch() (+1 more)

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, FetchRssNode(), ExecuteAsync(), WorkflowNodeResult(), foreach(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile(), CreateFactory(), new(), CreateFactoryWithProfiles(), OrchestratorFactoryTests()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), new(), CreateNode(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_OmitsDelta_WhenActualValueZeroOrMissing()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), XPoster.Tests.Integration, Dispose(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, catch(), GetImageGenerationEndpoint(), FalAiImageService(), GenerateImageAsync(), if(), XPoster.Services

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), if(), XPoster.Services, BlobUploadResult(), DeleteAsync(), UploadAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, return(), Execute_Throws_WhenProviderNameIsUnknown(), AiTextNodeTests, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), static(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), PostTests

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes, foreach(), if(), FanOutSendNode()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, XPoster.Models, Choice, OpenAIImageResponse, AIResponse, Message

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, SetData(), XPoster.Workflows.Models, WorkflowContext, HasData(), KeyNotFoundException(), if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, BuildChatPayload(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ParseImageResponseAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), XPoster.Services

### Community 89 - "Entity (Community 89)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoContentRetrieved(), Execute_ReturnsFailure_WhenNoUrlsProvided(), foreach(), FetchRssNodeTests, XPoster.Tests.Workflows.Nodes, static(), return()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), InvalidOperationException(), catch(), if(), CredentialsStartupValidator(), XPoster.Credentials

### Community 100 - "Entity (Community 100)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 97 - "Entity (Community 97)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, XPoster.Services, while(), GenerateImageAsync(), GenerateTextAsync(), GetImageGenerationEndpoint(), AzureFoundryService()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, return(), SendAsync_OptOutHeader_LogsNothing(), static(), SendAsync(), SendAsync_NotEnabled_SuccessNotLogged(), var()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), if(), HttpResponseMessage(), CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, if(), var(), XPoster.Tests.Helpers, StubHttpMessageHandler(), CapturedRequest(), BuildSequenceHandler()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, XPoster.Services, GenerateImageAsync(), GenerateTextAsync(), var(), while(), catch()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XSender(), if(), XPoster.SenderPlugins, SendAsync(), catch()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, NoOrchestrator(), Resolve(), WorkflowOrchestrator(), XPoster.Orchestrators, ResolveSenders(), catch()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), catch(), if(), IgSender(), XPoster.SenderPlugins

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), InMemoryContainerStateStore, GetPendingAsync(), SaveAsync(), XPoster.Services

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), if(), XFunction(), XPoster, Run()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, foreach(), HttpResponseBodyLogger(), IsEnabledFor(), XPoster.Services, while(), Log()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), if(), XPoster.Services, TagReplacementService(), Apply()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, ExecuteAsync(), AiTextNode(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, ExecuteAsync(), XPoster.Workflows.Nodes, WorkflowNodeResult(), if(), AiImageNode()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), XPoster.Contracts, UpdateStatusAsync(), SaveAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, AddWorkflows(), XPoster.Workflows.Configuration, InvalidOperationException(), if(), foreach()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, nameof(), OrchestratorFactory(), ResolveWorkflowOrchestrator(), CreateEmptyNoOrchestrator(), if()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSenderTests(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, UploadAsync(), DeleteAsync(), XPoster.Contracts

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, ExecuteAsync(), AcquireCryptoValueNode(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, if(), BuildPowerLawPostNode(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, return(), XPoster.Workflows.Utilities, catch(), GetProvider(), IsJsonLike()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), XPoster.Workflows.Engine, HasCycle(), foreach()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_ReturnsGeneratedText(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), var(), Execute_PassesStepOptionsToPromptRequest()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, IWorkflowContext, XPoster.Workflows.Models, HasData(), SetData()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), XPoster.Tests.Integration

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), DefaultAzureCredential(), BlobServiceClient(), if()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, AppendMediaSegmentsAsync(), SignRequest(), ThrowIfNotSuccess(), FinalizeMediaAsync(), if()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls(), WorkflowNodeInput(), Input(), var()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, BuildPowerLawPostNodeTests(), Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), if(), Input()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, SendAsync(), foreach(), HttpResponseBodyLoggingHandler(), XPoster.Services, IsBinaryMediaType()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, nameof(), Validate(), if(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, if(), Validate(), FacebookCredentialsValidator

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown(), var()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), JsonResponse(), HttpClient()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): XApiException.cs, BuildMessage(), catch(), XApiException(), foreach(), XPoster.SenderPlugins

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), SendAsync(), XPoster.SenderPlugins

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): AzureFoundryService.cs, catch(), GetChatCompletionsEndpoint(), var(), if()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, ToDefinition(), WorkflowDefinition(), XPoster.Workflows.Configuration

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), OpenAiService(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Providers, TimeProvider

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, ICredentialsStartupValidator, Validate()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpResponseBodyLogging(), AddHttpClients(), XPoster.Extensions

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Contracts

### Community 168 - "Entity (Community 168)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 167 - "Entity (Community 167)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, BuildFactory(), SendAsync(), params(), _responder()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, BuildApiClient(), OkJson(), if(), HttpResponseMessage()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), OpenAiOptionsValidatorTests, XPoster.Tests.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, XPoster.Models, ValidateConnectivity(), if()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Providers, LocalOverrideTimeProvider()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), CreateValidJpeg(), XPoster.Tests.Helpers

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, XPoster.Tests.Integration, static(), return(), ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 178 - "Entity (Community 178)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, if(), FormatResponseHeaders(), TruncateUtf8(), SanitizeAndTruncate()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, ExecuteAsync(), IWorkflowEngine, XPoster.Workflows.Engine

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 177 - "Entity (Community 177)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), if(), MaskUrlTelemetryProcessor()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), while(), GetChatCompletionsEndpoint()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, WorkflowDefinition(), XPoster.Workflows.Engine

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 207 - "Entity (Community 207)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 203 - "Entity (Community 203)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, SetupSender(), if(), var()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 212 - "Entity (Community 212)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), var(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 214 - "Entity (Community 214)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), GetChatCompletionsEndpoint(), DeepSeekService()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), new(), var()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 194 - "Entity (Community 194)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, SanitizeUrl(), XPoster.Services, foreach()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), ConfigurationSlotProfileProvider()

### Community 231 - "Entity (Community 231)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, if(), TryLogAsync()

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 229 - "Entity (Community 229)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, XPoster.Models, SlotScheduleOptions.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, Sanitize(), if()

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 245 - "Entity (Community 245)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 244 - "Entity (Community 244)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 246 - "Entity (Community 246)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 241 - "Entity (Community 241)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, WorkflowContextKeys.cs, WorkflowContextKeys.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 235 - "Entity (Community 235)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 237 - "Entity (Community 237)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 239 - "Entity (Community 239)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 238 - "Entity (Community 238)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 248 - "Entity (Community 248)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

