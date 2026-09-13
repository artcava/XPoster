# Graph Report - XPoster  (2026-09-13)

## Summary
- 2033 nodes · 3451 edges · 248 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Tests.Workflows.Nodes` - 2 edges
3. `LocalOverrideTimeProviderTests` - 2 edges
4. `XPoster.Tests.Providers` - 2 edges
5. `FalAiOptionsValidatorTests` - 2 edges
6. `InMemoryContainerStateStoreTests` - 2 edges
7. `XPoster.Workflows.Nodes` - 2 edges
8. `XPoster.Workflows.Nodes` - 2 edges
9. `FacebookCredentialsValidator` - 2 edges
10. `XPoster.Tests.Integration` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), MakeHttpClientThatThrows() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenInputTextIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_RequestBodyContainsTemperatureAndMaxTokensFromRequest(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, ChatCompletionJson(), BuildService(), new(), OpenAiServiceTests, OpenAiService(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenKeyMissing_ReturnsFalse(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WhenProbeKeyPresent_LogsPostContent() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, new(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_ValidB64_ReturnsBytes() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_RegistersValidator(), AddAzureFoundryOptions_RegistersValidator(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_ImagePromptRole_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution(), ChatCompletionJson(), BuildService() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), Platform_ReturnsFacebook(), return(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, ChatCompletionJson(), BuildService(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_JsonElement_ToString(), GetParameter_JsonElement_ToBool(), GetParameter_JsonElement_ToInt(), GetParameter_JsonElement_ToList(), NodeParameterExtractorTests, XPoster.Tests.Workflows.Utilities (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), SendAsync_WhenConnectionFails_ReturnsFalseAndLogsError(), SendAsync_WhenApiReturns402_ReturnsFalseAndLogsError(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), XSender(), XSenderTests (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, MissingRef(), ExecuteAsync(), foreach(), LinearChain(), static(), XPoster.Tests.Workflows.Engine, WorkflowExecutionEngineTests (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, HttpClient(), BinaryResponseHandler(), BuildClient(), FixedResponseHandler(), SendAsync_SanitizesSecretInBody(), StubResponse(), XPoster.Tests.Extensions (+11 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedService(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FeedServiceTests, foreach(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), XPoster.Tests.Services (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, DeepSeekOptions_ModelCatalog_ExposesTextOnly(), DeepSeekOptions_ImplementsIAiProviderOptions(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AiProviderOptionsAbstractionTests, AzureFoundryOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_SecondMessageRoleIsUser(), return(), BuildRequest() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, ConcurrentSetData_DoesNotThrow(), ConcurrentReadWrite_DoesNotThrow(), catch(), SetData_AndGetData_RoundTrip(), GetData_ThrowsOnTypeMismatch(), lock() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), IgSender(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), IgSenderImageFlowTests, CreateMalformedPngBytes(), BuildSender() (+10 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_IsImmutable_AfterConstruction(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_OptionalProperties_AreSetCorrectly(), PromptRequest_OptionalProperties_DefaultToNull() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, MakeConfiguration(), WorkflowServiceCollectionExtensionsTests, ServiceCollection(), XPoster.Tests.Workflows.Configuration, ConfigurationBuilder(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException() (+9 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), InMemoryContainerStateStoreTests (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_MapEachSlotToWorkflowOrchestrator(), ConfigurationBuilder(), ConfigurationSlotProfileProviderTests, CreateProvider(), BuildConfiguration(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateStructural_MissingNodeReference_ReturnsError(), MissingRef(), ValidateStructural_Cycle_ReturnsError(), TwoTerminals(), ValidateStructural_EmptyNodes_ReturnsNull(), XPoster.Tests.Workflows.Engine, WorkflowDefinitionValidatorTests (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, Sanitize_MasksRefreshTokenField(), Sanitize_MasksApiKeyHeaderWithColon(), Sanitize_MasksBearerTokenInHeader(), Sanitize_MasksJsonApiKey(), Sanitize_MasksBearerTokenInJson(), HttpResponseBodySanitizerTests (+8 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), PostWithoutImage(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), SendAsync_WhenBlobUploadFails_ReturnsFalse() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests, XPoster.Tests.Services, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), ConfigurationBuilder(), BuildAllProvidersConfig(), XPoster.Tests.Extensions (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), XPoster.Tests.Services, Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageService() (+7 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, MakeDefinitionWithoutImage(), MakeDefinition(), static(), WorkflowOrchestratorTests, XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyDictionary_OnFailure(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), AIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, Input(), Execute_ShortText_NoResummary(), Execute_StoresSendResultsInContext(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender(), Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), FanOutSendNodeTests, WorkflowNodeInput() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, switch(), XPosterContainerPollingFunction(), XPoster, TryDeleteBlobAsync(), ProcessContainerAsync(), HandleFinishedAsync() (+6 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), FalAiOptionsValidatorTests, XPoster.Tests.Models, Validate_MissingApiKey_Fails() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, UploadMediaAsync_SmallImage_UsesInitAppendFinalizeFlow(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), CreateTweetAsync_WithText_ReturnsTweetId(), UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments(), foreach(), UploadMediaAsync_EmptyMedia_ThrowsArgumentException(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_ReturnsModelName_WhenSupported(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), Supports_ReturnsTrueForRegisteredModelClass(), Supports_ReturnsFalseForMissingModelClass(), GetRequired_Throws_WhenNotSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), InSender_ImplementsISender(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildCreds(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), Input(), Execute_Throws_WhenValidProviderNotRegistered(), return(), if(), static(), Execute_ReturnsMediaAttachment_OnSuccess() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_ValidResponse_ReturnsImageBytes(), XPoster.Tests.Services, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), FalAiImageServiceTests, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+5 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, XApiClient(), UploadMediaAsync(), XPoster.SenderPlugins, XApiException(), ArgumentException(), for(), HasErrorPayload() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, XPoster.Tests.Providers, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), foreach() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), CreateSut(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPoster.Tests (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, MakeRequest(), MakeHandlerMock(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), NoOrchestrator_SupportedPlatforms_IsEmpty(), foreach(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, catch(), AzureFoundryService(), while(), GenerateImageAsync(), var(), GetImageGenerationEndpoint() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests, BuildConfig(), XPoster.Tests.Workflows.Services, if(), Resolve_Throws_WhenStepMissing(), Resolve_BindsImageProperties_WhenPresent() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), Constructor_InitializesCorrectly(), InSenderTests() (+4 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, foreach(), BuildAuthorizationHeader(), ComputeSignature(), ComputeSignatureBaseString(), if(), PercentEncode() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Platform_ReturnsInstagram(), XPoster.Tests.SenderPlugins, new(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, BuildSender(), InSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), ValidPost() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, ComputeSignature_PhotoExample_ReturnsExpectedBase64(), ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), XPoster.Tests.SenderPlugins, PercentEncode_InputValue_ReturnsExpectedEncoding(), XOAuth1SignerTests, BuildAuthorizationHeader_PostToTweetsEndpoint_SignsOAuthOnlyParameters() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), Constructor_Should_PreserveOrderOfSenderPlatforms(), ScheduledOrchestrationProfileTests, OrchestratorContextKey_Should_BeNull_WhenNotProvided(), Constructor_Should_PreserveHour_ForBoundaryValues(), OrchestratorContextKey_Should_BeSet_WhenProvided() (+3 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection() (+3 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), BuildFactory(), FbSenderSendAsyncTests (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), GetApiVersion(), if(), catch(), GetContainerStatusAsync(), MetaPublishingService() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), IgSenderSendAsyncTests, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), BuildSender(), IgSender() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, FbSender(), XPoster.SenderPlugins, if(), HandleResponseAsync(), SendAsync(), PublishPhotoAsync() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XFunctionTests(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyList(), Build(), Name_IsNoOrchestrator(), NoOrchestratorTests (+2 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, AiModelCatalog(), XPoster.Models, GetRequired(), InvalidOperationException(), if(), TryGet() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), CreateTimerInfo() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), BuildCreds(), InvalidImageBytes(), FbSenderImageFlowTests, BuildFactory(), HttpRequestException() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeedTests, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_RegistersExpectedNamedClients(), HttpClientExtensionsTests, XPoster.Tests.Extensions (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, XPoster.Workflows.Engine, ExecuteAsync(), while(), WorkflowExecutionResult(), WorkflowExecutionEngine(), foreach() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), var(), params(), XPoster.Tests.Integration, HttpResponseMessage() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), for(), XPoster.Tests.Integration, Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, generatePayLoad(), SendAsync(), Exception(), ResolveAuthorUrn(), catch(), InvalidOperationException() (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSenderResilienceTests, SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), XPoster.Tests.SenderPlugins (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests(), XPoster.Tests.Workflows.Nodes, Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), Input(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), Execute_UsesDefaultSymbol_WhenNotProvided() (+1 more)

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, static(), return(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), AiTextNodeTests

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostTests, XPoster.Tests.Models

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, foreach(), if(), XPoster.Workflows.Nodes, WorkflowNodeResult(), FetchRssNode(), ExecuteAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts

### Community 88 - "Entity (Community 88)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, new(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, HasData(), SetData(), XPoster.Workflows.Models, KeyNotFoundException(), WorkflowContext, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), Dispose(), XPoster.Tests.Integration, IsEnabled(), CreateLogger()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, XPoster.Services, DeleteAsync(), UploadAsync(), BlobStorageService(), BlobUploadResult(), if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), foreach(), if(), FanOutSendNode(), ExecuteAsync()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, catch(), GenerateImageAsync(), XPoster.Services, GetImageGenerationEndpoint(), FalAiImageService(), if()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, XPoster.Services, ExtractOpenAiBytes(), ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), BuildChatPayload()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Choice, ImageData, OpenAIImageResponse, XPoster.Models, Message, AIResponse

### Community 91 - "Entity (Community 91)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoUrlsProvided(), Execute_ReturnsFailure_WhenNoContentRetrieved(), static(), return(), foreach(), FetchRssNodeTests, XPoster.Tests.Workflows.Nodes

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactoryWithProfiles(), new(), WorkflowProfile(), CreateFactory()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, if(), CapturedRequest(), BuildSequenceHandler(), StubHttpMessageHandler()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, if(), ExecuteAsync(), AiImageNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 105 - "Entity (Community 105)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, SendAsync(), XSender(), XPoster.SenderPlugins, if(), catch()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, if(), catch(), XPoster.SenderPlugins, SendAsync(), IgSender()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, var(), SendAsync_OptOutHeader_LogsNothing(), SendAsync_NotEnabled_SuccessNotLogged(), return(), SendAsync(), static()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), XPoster.Contracts

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, catch(), NoOrchestrator(), Resolve(), ResolveSenders(), XPoster.Orchestrators, WorkflowOrchestrator()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), if()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, if(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), CreateValidJpegBytes(), HttpResponseMessage()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, XPoster.Services, SaveAsync(), GetPendingAsync(), UpdateStatusAsync()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, IsEnabledFor(), Log(), foreach(), HttpResponseBodyLogger(), XPoster.Services, while()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XPoster, if(), Run(), XFunction()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, AddWorkflows(), if(), foreach(), XPoster.Workflows.Configuration, InvalidOperationException()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, if(), Apply(), foreach()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, CredentialsStartupValidator(), catch(), InvalidOperationException(), Validate(), XPoster.Credentials, if()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, var(), XPoster.Services, while(), GenerateTextAsync(), GenerateImageAsync(), catch()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), if(), FacebookCredentialsValidator, XPoster.Credentials

### Community 136 - "Entity (Community 136)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), SendAsync(), DryRunSender()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, XPoster.Workflows.Nodes, AcquireCryptoValueNode(), ExecuteAsync(), WorkflowNodeResult()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, ExecuteAsync(), if(), BuildPowerLawPostNode()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Input(), var(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, Validate(), XPoster.Models, if(), nameof()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, XPoster.Workflows.Engine, HasCycle(), foreach(), if()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): XApiException.cs, BuildMessage(), XApiException(), XPoster.SenderPlugins, catch(), foreach()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), InstagramCredentialsValidator, XPoster.Credentials, Validate()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, SetData(), XPoster.Workflows.Models, HasData(), IWorkflowContext

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_UsesSymbol_ForPostTag(), BuildPowerLawPostNodeTests(), Execute_DateBeforeGenesis_ReturnsFailure(), if(), Input()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, if(), nameof(), Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_ReturnsNullOutput_OnEmptyArray(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_Throws_WhenProviderNameIsUnknown(), var()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, CreateEmptyNoOrchestrator(), ResolveWorkflowOrchestrator(), nameof(), OrchestratorFactory(), if()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), XPoster.Contracts, UploadAsync(), IBlobStorageService

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), MakeDownloadClient(), HttpClient(), MakeNoOpClient()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), PublishContainerAsync(), XPoster.Contracts, IMetaPublishingService

### Community 134 - "Entity (Community 134)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, if(), FinalizeMediaAsync(), SignRequest(), ThrowIfNotSuccess(), AppendMediaSegmentsAsync()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, SendAsync(), IsBinaryMediaType(), XPoster.Services, HttpResponseBodyLoggingHandler(), foreach()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSender()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests

### Community 130 - "Entity (Community 130)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, return(), catch(), GetProvider(), IsJsonLike(), XPoster.Workflows.Utilities

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_CallsFeedServiceForMultipleUrls(), Execute_ConcatenatesMultipleFeeds(), Input(), WorkflowNodeInput(), var()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), DefaultAzureCredential(), Uri(), BlobServiceClient()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), if(), OpenAiService()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, XPoster.Models, ImagePromptRequest, PromptRequest

### Community 149 - "Entity (Community 149)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, Resolve(), ConfigurationStepOptionsResolver(), XPoster.Workflows.Services

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, Resolve(), XPoster.Workflows.Services

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, WorkflowDefinition(), XPoster.Workflows.Configuration, ToDefinition()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpResponseBodyLogging(), AddHttpClients()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, HttpResponseMessage(), BuildApiClient(), OkJson(), if()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, Validate(), XPoster.Contracts

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), if(), XPoster.Credentials

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), XPoster.Contracts, ITextToTextProvider

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, ExecuteAsync(), XPoster.Workflows.Engine

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 177 - "Entity (Community 177)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Providers

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), XPoster.Models, ValidateConnectivity()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), return(), XPoster.Tests.Integration, static()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 176 - "Entity (Community 176)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, TruncateUtf8(), FormatResponseHeaders(), if(), SanitizeAndTruncate()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, SendAsync(), _responder(), params(), BuildFactory()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, if(), WorkflowOrchestrator(), XPoster.Orchestrators

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, IOrchestratorFactory, Resolve()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, GetChatCompletionsEndpoint(), while(), DeepSeekService()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, var(), ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 203 - "Entity (Community 203)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), new(), ExecuteAsync()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), WorkflowExecutionResult(), new()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 210 - "Entity (Community 210)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 214 - "Entity (Community 214)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 213 - "Entity (Community 213)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, resolve(), ValidateOptions(), foreach()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, WorkflowDefinition(), XPoster.Workflows.Engine

### Community 199 - "Entity (Community 199)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, SanitizeUrl(), foreach(), XPoster.Services

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), while(), GetChatCompletionsEndpoint()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, SetupSender(), if(), var()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 228 - "Entity (Community 228)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, TryLogAsync(), if()

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiModelClass.cs, AiModelClass.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, Sanitize(), if()

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, FacebookCredentials.cs, FacebookCredentials.cs

### Community 244 - "Entity (Community 244)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Workflows.Models, PromptStepOptions.cs

### Community 243 - "Entity (Community 243)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 240 - "Entity (Community 240)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 241 - "Entity (Community 241)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 234 - "Entity (Community 234)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 235 - "Entity (Community 235)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 238 - "Entity (Community 238)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 239 - "Entity (Community 239)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 237 - "Entity (Community 237)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

