# Graph Report - XPoster  (2026-09-14)

## Summary
- 2035 nodes · 3455 edges · 248 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `XPoster.Orchestrators` - 2 edges
4. `XPoster.Providers` - 2 edges
5. `XPoster.Services` - 2 edges
6. `XPoster.Providers` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `XPoster.Tests.Helpers` - 2 edges
9. `XPoster.Workflows.Engine` - 2 edges
10. `XPoster.Credentials` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_RequestBodyContainsSystemAndUserMessagesFromRequest(), GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateTextAsync_RequestBodyContainsModelFromOptions(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesNull_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateTextAsync_WhenApiReturns200_ReturnsTrimmedContent() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_MalformedJson_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WhenKeyWhitespace_ReturnsFalse() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, XPoster.Tests.Models, SectionName_IsPerplexity(), SectionName_IsFalAi(), SectionName_IsAzureFoundry(), SectionName_IsDeepSeek(), FalAiOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, GenerateTextAsync_ImagePromptRole_WhenApiReturnsValidResponse_ReturnsPrompt(), foreach(), GenerateTextAsync_ImagePromptRole_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildFactory(), BuildCreds(), Constructor_WithNullFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions(), DeepSeekService() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetProvider_Throws_WhenUnknownName(), GetProvider_MissingParameter_ReturnsDefaultProvider(), GetProvider_Throws_WhenEmptyName(), GetProvider_ParsesValidName_CaseInsensitive(), NodeParameterExtractorTests, XPoster.Tests.Workflows.Utilities (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), SendAsync_WhenConnectionFails_ReturnsFalseAndLogsError(), SendAsync_WhenApiReturns402_ReturnsFalseAndLogsError(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_TextPost_WhenApiSucceeds_ReturnsTrueAndLogsTweetId(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, LinearChain(), MissingRef(), _onExecute(), return(), ExecuteAsync(), Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_UnregisteredNodeType_ReturnsFailure() (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, SendAsync_SanitizesAccessTokenInUrl(), SendAsync_CallerStillReadsBodyAfterLogging(), SendAsync_ImageResponse_LogsSummaryWithoutBody(), SendAsync_OctetStreamResponse_LogsSummaryWithoutBody(), SendAsync_SanitizesSecretInBody(), XPoster.Tests.Extensions, StubResponse() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, return(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder(), BuildRequest(), GetContent(), GetRole(), BuildChatPayload_SubstitutesCustomLabelInUserMessage() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildService(), BuildFactory(), BuildRssXml(), SendAsync(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WithInvalidBytes_ReturnsNull(), IgSender() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, DeepSeekOptions_ModelCatalog_ExposesTextOnly(), AzureFoundryOptions_ImplementsIAiProviderOptions(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), DeepSeekOptions_ImplementsIAiProviderOptions(), ModelCatalog_UnsupportedCapability_GetRequired_Throws(), FalAiOptions_ModelCatalog_ExposesImageOnly() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, catch(), HasData_ReturnsFalse_WhenKeyMissing(), ConcurrentSetData_DoesNotThrow(), GetData_ThrowsOnMissingKey(), GetData_ThrowsOnTypeMismatch(), XPoster.Tests.Workflows.Models (+10 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), MetaPublishingService() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_Registers_WorkflowEngine(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_ConvertsParameters_ToObjectDictionary(), AddWorkflows_Registers_StepOptionsResolver(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons(), ConfigurationBuilder() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_OptionalProperties_DefaultToNull(), ImagePromptRequest_IsImmutable_AfterConstruction(), PromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_OptionalProperties_AreSetCorrectly() (+9 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), InMemoryContainerStateStoreTests, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, WorkflowDefinition(), WorkflowDefinitionValidatorTests, XPoster.Tests.Workflows.Engine, ValidateStructural_Cycle_ReturnsError(), Cyclic(), Linear(), MissingRef() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_LeavesCleanTextUnchanged(), HttpResponseBodySanitizerTests, Sanitize_MasksRefreshTokenField(), Sanitize_MasksApiKeyHeaderWithColon(), Sanitize_MasksBearerTokenInJson(), Sanitize_MasksBearerTokenInHeader() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, XPoster.Tests.Providers, GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), BlobStorageServiceTests (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), PostWithImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), new(), PostWithoutImage() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveValidators() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), MaskUrlTelemetryProcessorTests, XPoster.Tests.Services (+7 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, return(), XPoster.Tests.Orchestrators, WorkflowOrchestratorTests, static(), OrchestrateAsync_ReturnsEmptyDictionary_OnFailure(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), OrchestrateAsync_ReturnsPostMap_OnSuccess() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, switch(), XPosterContainerPollingFunction(), XPoster, TryDeleteBlobAsync(), ProcessContainerAsync(), HandleFinishedAsync() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent(), Choice_CanBeCreated_WithMessage(), OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl(), ModelsTests (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Execute_BridgesMediaAttachment_ToPostImage(), Execute_AppliesTagReplacements(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_ShortText_NoResummary(), Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), Execute_StoresSendResultsInContext() (+6 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), BuildService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageServiceTests (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, XPoster.Tests.SenderPlugins, Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildSender(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), Validate_MissingModelId_Fails() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), XApiClientTests, XPoster.Tests.SenderPlugins, UploadMediaAsync_WhenAppendRejected_ThrowsXApiException(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), UploadMediaAsync_SmallImage_UsesInitAppendFinalizeFlow(), CreateTweetAsync_WithText_ReturnsTweetId() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, XPoster.Tests.SenderPlugins, ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), BuildCredentials(), ExtractHeaderValue(), ComputeSignature_PhotoExample_ReturnsExpectedBase64(), BuildPhotoParameters() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, WorkflowNodeInput(), Execute_Throws_WhenValidProviderNotRegistered(), static(), return(), Input(), if(), Execute_ReturnsMediaAttachment_OnSuccess() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsFalseForMissingModelClass(), AiModelCatalogTests, GetRequired_Throws_WhenNotSupported(), Constructor_ExcludesNullOrWhitespaceEntries(), Constructor_NullDictionary_Throws(), Empty_SupportsNoModelClass() (+5 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), foreach(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), typeof() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), InSender(), InSenderTests(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), Platform_ReturnsLinkedIn(), MessageMaxLength_Returns2800(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageService(), MakeRequest(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_RequestUsesImageQuantityFromRequest() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_ReturnsStepOptions_WhenSectionExists(), Resolve_Throws_OnNullOrWhitespaceStepId(), Resolve_Throws_WhenStepMissing(), XPoster.Tests.Workflows.Services, Resolve_BindsImageProperties_WhenPresent(), BuildConfig() (+4 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, XPoster.SenderPlugins, for(), CreateTweetAsync(), XApiException(), InitializeMediaAsync(), XApiClient(), HasErrorPayload() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, if(), XPoster.Services, var(), while(), GetChatCompletionsEndpoint(), AzureFoundryService() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, if(), BuildAuthorizationHeader(), ComputeSignatureBaseString(), foreach(), ComputeSignature(), GetBaseUri() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_PreserveHour_ForBoundaryValues(), ScheduledOrchestrationProfileTests, typeof(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, BuildSender(), InSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins (+3 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly() (+3 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), XPoster.Tests.SenderPlugins, Platform_ReturnsInstagram(), new(), Constructor_InitializesCorrectly() (+3 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, PublishTextOnlyAsync(), if(), PublishPhotoAsync(), HandleResponseAsync(), catch() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), NoOrchestratorTests, Build(), OrchestrateAsync_ReturnsEmptyList(), SendIt_IsAlwaysFalse(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled() (+2 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests, BuildFactory(), BuildCreds(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WithValidOptions_ReturnsSuccess(), XPoster.Tests.Models, ValidOptions(), Validate_WhenEndpointIsEmpty_ReturnsFailed() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, if(), catch(), GetApiVersion(), GetContainerStatusAsync(), HttpRequestException(), XPoster.Services (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, IgSender(), BuildSender(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins (+2 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), XPoster.Tests.Extensions (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, using(), SendAsync(), InvalidOperationException(), catch(), Exception(), generatePayLoad() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), params(), var(), XPoster.Tests.Integration (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), catch(), for() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), XPoster.Tests.Orchestrators, PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, while(), XPoster.Workflows.Engine, WorkflowExecutionResult(), WorkflowExecutionEngine(), foreach(), ExecuteAsync() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, FbSenderImageFlowTests, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, BuildCreds(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), HttpRequestException(), InvalidImageBytes() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), PendingContainer(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests(), Execute_UsesDefaultSymbol_WhenNotProvided() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, GetRequired(), InvalidOperationException(), if(), Supports(), XPoster.Models, TryGet() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, BuildSender() (+1 more)

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, foreach(), ExecuteAsync(), FanOutSendNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactory(), WorkflowProfile(), CreateFactoryWithProfiles(), OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), new()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), PostTests, Post_EmptyContent_IsAllowed()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, OpenAIImageResponse, Choice, Message, AIResponse, XPoster.Models

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), if(), XPoster.Services, GetImageGenerationEndpoint(), catch(), FalAiImageService()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), CaptureLoggerProvider(), CreateLogger(), CaptureLogger(), IsEnabled(), XPoster.Tests.Integration

### Community 82 - "Entity (Community 82)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), BuildChatPayload(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), ParseImageResponseAsync(), LogAndReturnEmpty(), XPoster.Services

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, foreach(), XPoster.Workflows.Nodes, WorkflowNodeResult(), if(), FetchRssNode(), ExecuteAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), TestOrchestrator()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), new(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), CreateNode()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, foreach(), XPoster.Tests.Workflows.Nodes, return(), static(), Execute_ReturnsFailure_WhenNoUrlsProvided(), Execute_ReturnsFailure_WhenNoContentRetrieved(), FetchRssNodeTests

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), XPoster.Services, BlobStorageService(), if(), BlobUploadResult(), DeleteAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, WorkflowNodeInput(), static(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), AiTextNodeTests, Execute_Throws_WhenProviderNameIsUnknown(), return(), XPoster.Tests.Workflows.Nodes

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, WorkflowContext, XPoster.Workflows.Models, KeyNotFoundException(), SetData(), if(), HasData()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, NoOrchestrator(), catch(), XPoster.Orchestrators, Resolve(), ResolveSenders(), WorkflowOrchestrator()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, AddWorkflows(), foreach(), XPoster.Workflows.Configuration, InvalidOperationException(), if()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, Log(), IsEnabledFor(), XPoster.Services, while(), foreach(), HttpResponseBodyLogger()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), Apply(), TagReplacementService(), XPoster.Services, if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), XPoster.SenderPlugins, SendAsync(), if(), catch()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, static(), var(), SendAsync_OptOutHeader_LogsNothing(), SendAsync(), SendAsync_NotEnabled_SuccessNotLogged(), return()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, InvalidOperationException(), if(), CredentialsStartupValidator(), catch(), XPoster.Credentials, Validate()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), XPoster.Contracts

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), ExecuteAsync(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, SaveAsync(), UpdateStatusAsync(), XPoster.Services, GetPendingAsync()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, var(), XPoster.Services, while(), GenerateTextAsync(), GenerateImageAsync(), catch()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, if(), CapturedRequest(), BuildSequenceHandler(), XPoster.Tests.Helpers, var(), StubHttpMessageHandler()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XSender(), catch(), SendAsync(), if(), XPoster.SenderPlugins

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), Run(), if(), catch(), XPoster

### Community 102 - "Entity (Community 102)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, if(), CreateValidJpegBytes(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage(), SendAsync_WhenUploadThrows_FallsBackToTextOnly()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSenderTests()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.33
Nodes (6): XApiException.cs, XPoster.SenderPlugins, foreach(), BuildMessage(), catch(), XApiException()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), XPoster.Models, Validate(), nameof()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), AcquireCryptoValueNode(), ExecuteAsync()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), Execute_ConcatenatesMultipleFeeds(), Input(), Execute_CallsFeedServiceForMultipleUrls(), var()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), IMetaPublishingService, XPoster.Contracts, PublishContainerAsync()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), Validate(), XPoster.Credentials, InstagramCredentialsValidator

### Community 122 - "Entity (Community 122)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests(), Input(), Execute_UsesSymbol_ForPostTag(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, ThrowIfNotSuccess(), FinalizeMediaAsync(), if(), AppendMediaSegmentsAsync(), SignRequest()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 118 - "Entity (Community 118)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), IsJsonLike(), return(), XPoster.Workflows.Utilities, catch()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, XPoster.Workflows.Engine, HasCycle(), foreach(), if()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), XPoster.Workflows.Models, SetData(), IWorkflowContext

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, if(), OrchestratorFactory(), ResolveWorkflowOrchestrator(), nameof(), CreateEmptyNoOrchestrator()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, if(), BuildPowerLawPostNode(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, SendAsync(), XPoster.Services, foreach(), HttpResponseBodyLoggingHandler(), IsBinaryMediaType()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), BlobServiceClient(), DefaultAzureCredential(), Uri()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), UploadAsync(), XPoster.Contracts

### Community 138 - "Entity (Community 138)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), var(), JsonResponse(), HttpClient()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), SendAsync(), XPoster.SenderPlugins

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText(), var(), Input(), Execute_Throws_WhenValidProviderNotRegistered()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), XPoster.Providers, ConfigurationTagReplacementProvider()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetImageGenerationEndpoint(), OpenAiService(), GetChatCompletionsEndpoint(), if()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, GenerateTextAsync(), if(), var(), XPoster.Services

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, params(), BuildFactory(), _responder(), SendAsync()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, ExecuteAsync(), IWorkflowEngine, XPoster.Workflows.Engine

### Community 154 - "Entity (Community 154)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, XPoster.Workflows.Abstractions, IWorkflowNode, ExecuteAsync()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddHttpResponseBodyLogging(), AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 155 - "Entity (Community 155)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, FormatResponseHeaders(), SanitizeAndTruncate(), if(), TruncateUtf8()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, Resolve(), XPoster.Workflows.Services

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, if(), GenerateTextAsync(), var(), XPoster.Services

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), Validate(), XPoster.Credentials

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), ICredentialsStartupValidator, XPoster.Contracts

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, ImagePromptRequest, XPoster.Models

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 175 - "Entity (Community 175)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 173 - "Entity (Community 173)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, if(), OkJson(), BuildApiClient(), HttpResponseMessage()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), MaskUrlTelemetryProcessor(), if()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, WorkflowDefinition(), ToDefinition()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 171 - "Entity (Community 171)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 170 - "Entity (Community 170)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), static(), return(), XPoster.Tests.Integration

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, XPoster.Contracts, IAiProviderOptions, IAiProviderSection

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, SetupSender(), var(), if()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer(), var()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), ConfigurationSlotProfileProvider()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), GetChatCompletionsEndpoint(), DeepSeekService()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Orchestrators, PostAsync()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, foreach(), SanitizeUrl(), XPoster.Services

### Community 210 - "Entity (Community 210)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 214 - "Entity (Community 214)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, XPoster.Models, foreach(), Validate()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, WorkflowDefinition(), XPoster.Workflows.Engine

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), var(), StubNode()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 205 - "Entity (Community 205)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), WorkflowExecutionResult(), new()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, new(), ExecuteAsync(), Node()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, XPoster.Models, SlotScheduleOptions.cs

### Community 244 - "Entity (Community 244)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, TryLogAsync(), if()

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 241 - "Entity (Community 241)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 235 - "Entity (Community 235)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 238 - "Entity (Community 238)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 239 - "Entity (Community 239)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 237 - "Entity (Community 237)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 230 - "Entity (Community 230)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, Sanitize(), if()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

