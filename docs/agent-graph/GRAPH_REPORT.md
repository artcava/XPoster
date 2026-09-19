# Graph Report - XPoster  (2026-09-19)

## Summary
- 2041 nodes · 3467 edges · 250 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Tests.Providers` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `XPoster.Tests.Orchestrators` - 2 edges
5. `HttpResponseBodySanitizerTests` - 2 edges
6. `IgSenderSendAsyncTests` - 2 edges
7. `XPoster.Tests.Models` - 2 edges
8. `AzureFoundryOptionsTests` - 2 edges
9. `XPoster.Tests.Models` - 2 edges
10. `XPoster.Tests.Integration` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), AiServiceHelperTests, ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, HttpResponseMessage(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesNull_ReturnsEmptyString(), GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateImageAsync_WhenTimeoutRejectedExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenTimeoutRejectedExceptionOnPost_LogsError() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), XPoster.Tests.SenderPlugins, BuildShortSender(), BuildConfig() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, ConfigurationBuilder(), BuildConfig(), BuildProvider(), AddPerplexityOptions_RegistersValidator(), AddOpenAiOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, new(), PerplexityService(), PerplexityServiceTests, GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, FbSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullFactory_ThrowsArgumentNullException(), FbSender(), BuildCreds() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetProvider_ParsesValidName_CaseInsensitive(), GetParameter_ReturnsDefault_WhenKeyMissing(), GetParameter_ReturnsDefault_WhenValueIsNull(), GetProvider_MissingParameter_ReturnsDefaultProvider(), XPoster.Tests.Workflows.Utilities, GetProvider_Throws_WhenUnknownName() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), new(), SummaryRequest(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), HttpResponseMessage() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_EmptyNodesDefinition_Succeeds(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs(), foreach(), Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), Execute_UnregisteredNodeType_ReturnsFailure() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.11
Nodes (19): XSenderTests.cs, Constructor_WithNullApiClient_ThrowsArgumentNullException(), Constructor_InitializesSender_ImplementsISender(), XSender(), SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageFormatCannotBeDetected_FallsBackToTextOnly() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, HttpClient(), FixedResponseHandler(), BinaryResponseHandler(), BuildClient(), SendAsync_4xx_LogsResponseHeaders(), if(), SendAsync_2xx_LogsAtDebugLevel() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_FirstMessageRoleIsSystem(), AiServiceHelperChatPayloadTests, BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedService(), FakeHttpMessageHandler(), BuildService(), BuildFactory(), BuildRssXml(), GetFeedsAsync_FiltersOutItemsOutsideDateRange() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, GetData_ThrowsOnTypeMismatch(), catch(), ConcurrentSetData_DoesNotThrow(), ConcurrentReadWrite_DoesNotThrow(), GetData_ThrowsOnMissingKey(), TryGetData_ReturnsFalse_WhenKeyMissing() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ImplementsIAiProviderOptions(), XPoster.Tests.Models, PerplexityOptions_ModelCatalog_ExposesTextOnly(), FalAiOptions_ModelCatalog_ExposesImageOnly(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), FalAiOptions_ImplementsIAiProviderOptions() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, IgSender(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), IgSenderImageFlowTests, NormalizeImage_WhenCodecIsNull_ReturnsNull(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull() (+10 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), MetaPublishingService(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, XPoster.Tests.Models, ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_BaseProperties_AreAccessible(), PromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_InheritsFrom_PromptRequest() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, ServiceCollection(), XPoster.Tests.Workflows.Configuration, WorkflowServiceCollectionExtensionsTests, MakeConfiguration(), AddWorkflows_WithValidWorkflow_DoesNotThrow(), ConfigurationBuilder() (+9 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_MasksAccessTokenJsonField(), Sanitize_LeavesCleanTextUnchanged(), HttpResponseBodySanitizerTests, Sanitize_MasksRefreshTokenField(), Sanitize_MasksApiKeyHeaderWithColon(), Sanitize_MasksBearerTokenInHeader() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, XPoster.Tests.Providers, GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), new(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), WorkflowDefinition(), WorkflowDefinitionValidatorTests (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithValidInputs_StoresPendingEntry(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenHttpClientThrows_ReturnsFalse(), new(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), PostWithoutImage(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), PostWithImage() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_RegistersAllFiveValidators(), XPoster.Tests.Extensions, BuildAllProvidersConfig(), AddAiProviderOptions_ReturnsSameServiceCollection(), ConfigurationBuilder(), AddAiProviderOptionsTests (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageServiceTests, BlobStorageService(), CreateSut(), UploadAsync_WhenStorageThrows_PropagatesException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.13
Nodes (15): XApiClientTests.cs, CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), ContainsSequence(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), foreach(), CreateTweetAsync_WithText_ReturnsTweetId(), for() (+7 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, return(), Properties_AreConfigured(), OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), ProduceImage_Set_ThrowsNotSupported(), OrchestrateAsync_ReturnsPostMap_OnSuccess(), ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, catch(), HandleFinishedAsync(), PollPendingContainersAsync(), if(), HandleTerminalFailureAsync(), ProcessContainerAsync() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), Message_CanBeCreated_WithContent(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent(), OpenAIImageResponse_CanBeCreated_WithData(), ModelsTests (+6 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, return(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), Execute_StoresSendResultsInContext(), FanOutSendNodeTests, Input() (+6 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, BuildAuthorizationHeader_MediaUploadInit_PercentEncodesOAuthValuesPerRfc5849(), XOAuth1SignerTests, XPoster.Tests.SenderPlugins, PercentEncode_InputValue_ReturnsExpectedEncoding(), BuildAuthorizationHeader_PostToTweetsEndpoint_SignsOAuthOnlyParameters(), ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, BuildSender(), BuildCreds(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), InSender_ImplementsISender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_MissingModelId_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageServiceTests, FalImageJson(), BuildService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsTrueForRegisteredModelClass(), Constructor_ExcludesNullOrWhitespaceEntries(), GetRequired_Throws_WhenNotSupported(), GetRequired_ReturnsModelName_WhenSupported(), Constructor_NullDictionary_Throws(), Supports_ReturnsFalseForMissingModelClass() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), AiImageNodeTests, Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsNullOutput_OnSoftFailure(), XPoster.Tests.Workflows.Nodes, if() (+5 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), XPoster.Tests.Providers (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSenderTests() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, BuildConfig(), Resolve_ReturnsStepOptions_WhenSectionExists(), foreach(), if(), ConfigurationStepOptionsResolverTests, Resolve_BindsImageProperties_WhenPresent() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPosterContainerPollingFunctionTests, RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPoster.Tests, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeRequest(), MakeHandlerMock(), GenerateImageAsync_Returns429_LogsWarning(), FalAiImageService(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, XPoster.SenderPlugins, for(), XApiClient(), XApiException(), InitializeMediaAsync(), HasErrorPayload(), UploadMediaAsync() (+4 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), ScheduledOrchestrationProfileTests, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), Constructor_Should_SetAllFields(), OrchestratorContextKey_Should_BeNull_WhenNotProvided() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Platform_ReturnsInstagram(), XPoster.Tests.SenderPlugins, new(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, ValidPost(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, XPoster.SenderPlugins, PercentEncode(), if(), BuildAuthorizationHeader(), GetBaseUri(), ComputeSignatureBaseString() (+3 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, IgSender(), BuildSender(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenEndpointIsEmpty_ReturnsFailed() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishPhotoAsync(), SendAsync(), HandleResponseAsync(), PublishTextOnlyAsync(), FbSender(), catch() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildFactory(), FbSenderSendAsyncTests, BuildCreds(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), NoOrchestratorTests, XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), PublishContainerAsync(), GetContainerStatusAsync(), XPoster.Services, MetaPublishingService(), HttpRequestException() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XPoster.Tests, XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), XPoster.Tests.Integration, params(), HttpResponseMessage(), var(), BuildSequenceHandler() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, GetRequired(), if(), Supports(), XPoster.Models, TryGet(), InvalidOperationException() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), PendingContainer() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Execute_UsesDefaultSymbol_WhenNotProvided(), AcquireCryptoValueNodeTests(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_SendIt_IsFalse() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), BuildCreds(), HttpRequestException(), BuildFactory(), FbSenderImageFlowTests, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), HttpResponseMessage(), FbSenderResilienceTests, XPoster.Tests.SenderPlugins (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), foreach(), XPoster.Tests.Extensions (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedTests, XPoster.Tests.Models, RSSFeed_CanSetPublishDate() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, Exception(), ResolveAuthorUrn(), using(), SendAsync(), generatePayLoad(), InvalidOperationException() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSenderResilienceTests (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionResult(), WorkflowExecutionEngine(), foreach(), while(), if(), ExecuteAsync() (+1 more)

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, SetData(), WorkflowContext, XPoster.Workflows.Models, KeyNotFoundException(), if(), HasData()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoUrlsProvided(), static(), XPoster.Tests.Workflows.Nodes, foreach(), return(), FetchRssNodeTests, Execute_ReturnsFailure_WhenNoContentRetrieved()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), XPoster.Tests.Integration, Dispose(), IsEnabled(), CreateLogger(), CaptureLoggerProvider()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, return(), static(), AiTextNodeTests, Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile(), CreateFactory(), CreateFactoryWithProfiles(), OrchestratorFactoryTests(), new()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), XPoster.Services, UploadAsync(), if(), DeleteAsync(), BlobStorageService()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), BuildChatPayload(), LogAndReturnEmpty(), ExtractOpenAiBytes()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GetImageGenerationEndpoint(), if(), XPoster.Services, catch(), GenerateImageAsync(), FalAiImageService()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, FetchRssNode(), foreach(), if(), XPoster.Workflows.Nodes, ExecuteAsync(), WorkflowNodeResult()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, Message, ImageData, OpenAIImageResponse, AIResponse, Choice

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), PostTests, XPoster.Tests.Models

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, WorkflowNodeResult(), FanOutSendNode(), foreach(), if(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), WorkflowNodeInput(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), new(), XPoster.Tests.Workflows.Nodes

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, WorkflowOrchestrator(), XPoster.Orchestrators, ResolveSenders(), Resolve(), catch(), NoOrchestrator()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), XPoster, if(), Run()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, XPoster.Workflows.Nodes, AiTextNode(), if(), ExecuteAsync(), WorkflowNodeResult()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, StubHttpMessageHandler(), var(), XPoster.Tests.Helpers, CapturedRequest(), BuildSequenceHandler(), if()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, Apply(), if(), XPoster.Services, TagReplacementService(), foreach()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), CreateValidJpegBytes(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), if(), HttpResponseMessage()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, AzureFoundryService(), GetImageGenerationEndpoint(), GenerateTextAsync(), GenerateImageAsync(), XPoster.Services, while()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), SaveAsync(), XPoster.Contracts, UpdateStatusAsync(), IContainerStateStore

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, WorkflowNodeResult(), ExecuteAsync(), AiImageNode(), XPoster.Workflows.Nodes, if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, return(), SendAsync(), SendAsync_NotEnabled_SuccessNotLogged(), static(), SendAsync_OptOutHeader_LogsNothing(), var()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, while(), IsEnabledFor(), foreach(), Log(), HttpResponseBodyLogger(), XPoster.Services

### Community 106 - "Entity (Community 106)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, XPoster.Workflows.Configuration, foreach(), AddWorkflows(), InvalidOperationException(), if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), CredentialsStartupValidator(), Validate(), InvalidOperationException(), XPoster.Credentials, if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, if(), IgSender(), SendAsync(), XPoster.SenderPlugins, catch()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XPoster.SenderPlugins, if(), catch(), SendAsync(), XSender()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), XPoster.Services, SaveAsync(), GetPendingAsync(), InMemoryContainerStateStore

### Community 99 - "Entity (Community 99)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, catch(), GenerateTextAsync(), var(), GenerateImageAsync(), XPoster.Services, while()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_ReturnsNullOutput_OnEmptyArray()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender(), IgSender_ImplementsISender(), IgSenderTests(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_ReturnsGeneratedText(), Execute_Throws_WhenValidProviderNotRegistered(), var(), Input(), Execute_PassesStepOptionsToPromptRequest()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.33
Nodes (6): XApiException.cs, BuildMessage(), catch(), foreach(), XApiException(), XPoster.SenderPlugins

### Community 136 - "Entity (Community 136)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), XPoster.Credentials, InstagramCredentialsValidator, Validate()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, if(), ExecuteAsync(), BuildPowerLawPostNode()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), Uri(), if(), DefaultAzureCredential()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), DryRunSender(), SendAsync()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls(), var(), Input()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, WorkflowNodeResult(), AcquireCryptoValueNode(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), HttpClient(), MakeNoOpClient(), var(), MakeDownloadClient()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, IsBinaryMediaType(), SendAsync(), XPoster.Services, HttpResponseBodyLoggingHandler(), foreach()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_UsesSymbol_ForPostTag(), Execute_DateBeforeGenesis_ReturnsFailure(), BuildPowerLawPostNodeTests(), Input(), if()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, nameof(), Validate(), if(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), HasCycle(), foreach(), XPoster.Workflows.Engine

### Community 118 - "Entity (Community 118)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services

### Community 139 - "Entity (Community 139)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, AppendMediaSegmentsAsync(), if(), ThrowIfNotSuccess(), FinalizeMediaAsync(), SignRequest()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, HasData(), IWorkflowContext, XPoster.Workflows.Models, SetData()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, if(), Validate(), FacebookCredentialsValidator

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, UploadAsync(), XPoster.Contracts, DeleteAsync()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, XPoster.Workflows.Utilities, catch(), IsJsonLike(), GetProvider(), return()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, CreateEmptyNoOrchestrator(), nameof(), OrchestratorFactory(), if(), ResolveWorkflowOrchestrator()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, XPoster.Models, if(), nameof(), Validate()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), XPoster.Models, nameof(), if()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 148 - "Entity (Community 148)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, XPoster.Tests.Integration, ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), static(), return()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 151 - "Entity (Community 151)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, _responder(), SendAsync(), params(), BuildFactory()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 179 - "Entity (Community 179)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GenerateTextAsync(), ITextToTextProvider

### Community 165 - "Entity (Community 165)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, XPoster.Contracts, IAiProviderOptions, IAiProviderSection

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, WorkflowDefinition(), XPoster.Workflows.Configuration, ToDefinition()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, ExecuteAsync(), XPoster.Workflows.Engine

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), Validate(), XPoster.Credentials

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, IWorkflowNode, ExecuteAsync(), XPoster.Workflows.Abstractions

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 163 - "Entity (Community 163)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), ITextToImageProvider, XPoster.Contracts

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, Validate(), ICredentialsStartupValidator

### Community 178 - "Entity (Community 178)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.40
Nodes (5): AzureFoundryService.cs, catch(), if(), var(), GetChatCompletionsEndpoint()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Providers

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, XPoster.Models, ValidateConnectivity(), if()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), Process(), if()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddResilientHttpClient(), XPoster.Extensions, AddHttpResponseBodyLogging(), AddHttpClients()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 142 - "Entity (Community 142)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), OpenAiService(), if()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, TruncateUtf8(), SanitizeAndTruncate(), if(), FormatResponseHeaders()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), ConfigurationStepOptionsResolver()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, BuildApiClient(), HttpResponseMessage(), if(), OkJson()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, XPoster.Models, PromptRequest, ImagePromptRequest

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), new(), ExecuteAsync()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), XPoster.Models, Validate()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 216 - "Entity (Community 216)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, new(), WorkflowExecutionResult(), var()

### Community 214 - "Entity (Community 214)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), resolve(), ValidateOptions()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, foreach(), SanitizeUrl(), XPoster.Services

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, var(), ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, GetProfiles(), XPoster.Providers, ConfigurationSlotProfileProvider()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): XSenderTests.cs, BuildSender(), HttpResponseMessage(), if()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, if(), Sanitize()

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Workflows.Models, PromptStepOptions.cs

### Community 245 - "Entity (Community 245)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 244 - "Entity (Community 244)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, TryLogAsync(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 236 - "Entity (Community 236)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 237 - "Entity (Community 237)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 238 - "Entity (Community 238)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 241 - "Entity (Community 241)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 239 - "Entity (Community 239)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 230 - "Entity (Community 230)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 249 - "Entity (Community 249)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 248 - "Entity (Community 248)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

