# Graph Report - XPoster  (2026-09-16)

## Summary
- 2037 nodes · 3459 edges · 249 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `ITimeProvider` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `ITagReplacementProvider` - 2 edges
7. `ITextToImageProvider` - 2 edges
8. `ISlotProfileProvider` - 2 edges
9. `XPoster.Workflows.Nodes` - 2 edges
10. `XPoster.Tests.Workflows.Nodes` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenInputTextIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), XPoster.Tests.Services, MakeHandlerMock(), if() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, new(), MakeHandlerMock(), MakeHandler(), HttpResponseMessage(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi() (+28 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, MaxSender_Platform_IsDryRunMaxLength(), MaxSender_ImplementsISender(), MaxSender_MessageMaxLength_IsIntMaxValue(), DryRunShortLengthSender(), ConfigurationBuilder(), BuildMaxSender() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AddDeepSeekOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), XPoster.Tests.Services, PerplexityServiceTests, MakeSequentialHandlerMock(), GenerateTextAsync_WhenTextExceedsMaxOutputLength_CallsApiAndReturnsContent(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), return(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, ChatCompletionJson(), GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate(), DeepSeekService(), DeepSeekServiceTests, GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, NodeParameterExtractorTests, GetProvider_Throws_WhenUnknownName(), GetProvider_UsesProvidedDefault_WhenMissing(), XPoster.Tests.Workflows.Utilities, GetProvider_ParsesValidName_CaseInsensitive(), GetParameter_ReturnsDefault_WhenKeyMissing() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, XSenderTests, XSender(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildSender() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Execute_MissingRef_ReturnsFailure_WithDescriptiveError(), Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies(), Execute_EmptyNodesDefinition_Succeeds(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs(), EmptySenders(), Cyclic(), Diamond() (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, SendAsync_CallerStillReadsBodyAfterLogging(), SendAsync_4xx_LogsResponseHeaders(), SendAsync_4xx5xx_LogsAtErrorLevel(), SendAsync_BodyLargerThanCap_LogsSummaryOnly(), XPoster.Tests.Extensions, SendAsync_SanitizesAccessTokenInUrl(), StubResponse() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildService(), BuildRssXml(), BuildFactory(), foreach(), FakeHttpMessageHandler(), FeedServiceTests (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, XPoster.Tests.Workflows.Models, catch(), ConcurrentReadWrite_DoesNotThrow(), ConcurrentSetData_DoesNotThrow(), GetData_ThrowsOnMissingKey(), SetData_AndGetData_RoundTrip() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests, GetRole(), XPoster.Tests.Services, return(), BuildChatPayload_FirstMessageRoleIsSystem(), BuildChatPayload_ForwardsTemperature() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), Uri(), XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WithValidJpeg_ReturnsSameBytes() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ImplementsIAiProviderOptions(), OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), OpenAiOptions_ModelCatalog_ExposesTextAndImage(), OpenAiOptions_ImplementsIAiProviderOptions(), AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AiProviderOptionsAbstractionTests (+10 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_Registers_KeyedNodes(), AddWorkflows_ConvertsParameters_ToObjectDictionary(), WorkflowServiceCollectionExtensionsTests, ServiceCollection(), BuildProvider(), ConfigurationBuilder() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, XPoster.Tests.Models, PromptRequest_OptionalProperties_AreSetCorrectly(), PromptRequest_OptionalProperties_DefaultToNull(), PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_Temperature_AcceptsZeroAndOne() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException() (+9 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, SanitizeUrl_MasksAccessTokenQuery(), SanitizeUrl_NoQuery_ReturnsAsIs(), XPoster.Tests.Extensions, Sanitize_MasksApiKeyHeaderWithColon(), HttpResponseBodySanitizerTests, Sanitize_MasksAccessTokenJsonField() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), XPoster.Tests.Providers, new(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), CreateProvider(), BuildConfiguration() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError(), MissingRef(), Cyclic() (+8 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), BlobStorageService(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageServiceTests, CreateSut() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests, BuildAllProvidersConfig(), XPoster.Tests.Extensions, ConfigurationBuilder(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), XPoster.Tests.Services, Initialize_WhenTelemetryIsNotDependency_DoesNothing() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, Uri(), new(), IgSender(), IgSenderResilienceTests, BuildSender() (+7 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ModelsTests, RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), Post_Firm_ContainsExpectedHashtags(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleTerminalFailureAsync(), HandleFinishedAsync(), foreach(), catch(), XPosterContainerPollingFunction(), PollPendingContainersAsync() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing(), MakeDefinitionWithoutImage(), OrchestrateAsync_ReturnsEmptyDictionary_OnFailure(), MakeDefinition(), ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode(), return(), Properties_AreConfigured() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, XPoster.Tests.Workflows.Nodes, FanOutSendNodeTests, WorkflowNodeInput(), Input(), return(), static(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, AiImageNodeTests, Execute_ReturnsNullOutput_OnSoftFailure(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), static(), Execute_Throws_WhenValidProviderNotRegistered(), Input(), return() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, ComputeSignature_PhotoExample_ReturnsExpectedBase64(), XPoster.Tests.SenderPlugins, PercentEncode_InputValue_ReturnsExpectedEncoding(), XOAuth1SignerTests, ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), ExtractHeaderValue() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, XApiClientTests, UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments(), CreateTweetAsync_WithText_ReturnsTweetId(), UploadMediaAsync_SmallImage_UsesInitAppendFinalizeFlow(), UploadMediaAsync_EmptyMedia_ThrowsArgumentException(), foreach(), UploadMediaAsync_WhenAppendRejected_ThrowsXApiException() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), XPoster.Tests.Services, BuildService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsFalseForMissingModelClass(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Supports_ReturnsTrueForRegisteredModelClass(), XPoster.Tests.Models, TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), Empty_SupportsNoModelClass() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildCreds(), XPoster.Tests.SenderPlugins, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingModelId_Fails(), FalAiOptionsValidatorTests, Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSenderTests(), Platform_ReturnsLinkedIn() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), XPoster.Tests.Providers, GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, foreach(), Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, XPoster.Tests.Workflows.Services, if(), Resolve_BindsImageProperties_WhenPresent(), Resolve_Throws_WhenStepMissing(), Resolve_ReturnsStepOptions_WhenSectionExists(), Resolve_Throws_OnNullOrWhitespaceStepId() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), MakeRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPosterContainerPollingFunctionTests, XPoster.Tests, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), CreateSut(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, InitializeMediaAsync(), ArgumentException(), HasErrorPayload(), catch(), BuildSignedRequest(), for(), CreateTweetAsync() (+4 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, ComputeSignatureBaseString(), PercentEncode(), if(), XPoster.SenderPlugins, GetBaseUri(), foreach() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), BuildSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), InSenderResilienceTests, InSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_PreserveOrderOfSenderPlatforms(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), XPoster.Tests.Models, typeof() (+3 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Platform_ReturnsInstagram(), XPoster.Tests.SenderPlugins, new(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly() (+3 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests, XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyList(), SupportedPlatforms_IsEmpty(), SendIt_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, XPoster.Tests.Models, ValidOptions(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishPhotoAsync(), if(), SendAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins, FbSender() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, IgSenderSendAsyncTests, BuildSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildCreds(), BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), FbSenderSendAsyncTests (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, XPoster.Services, catch(), if(), MetaPublishingService(), GetApiVersion(), GetContainerStatusAsync() (+2 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, BuildSender() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), foreach(), AddHttpClients_ReturnsSameServiceCollection(), HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_RegistersExpectedNamedClients() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, foreach(), if(), ExecuteAsync(), WorkflowExecutionResult(), XPoster.Workflows.Engine, while() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), params(), BuildSequenceHandler(), var(), XPoster.Tests.Integration, HttpResponseMessage() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildFactory(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, FbSenderImageFlowTests, InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), HttpRequestException() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), AcquireCryptoValueNodeTests(), Execute_UsesDefaultSymbol_WhenNotProvided() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), CreateTimerInfo(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, AiModelCatalog(), GetRequired(), XPoster.Models, InvalidOperationException(), TryGet(), Supports() (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), for(), catch() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), catch(), InvalidOperationException(), Exception(), SendAsync(), generatePayLoad(), ResolveAuthorUrn() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, FbSenderResilienceTests, XPoster.Tests.SenderPlugins, HttpResponseMessage(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse() (+1 more)

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, XPoster.Workflows.Nodes, foreach(), FanOutSendNode(), ExecuteAsync(), WorkflowNodeResult(), if()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput(), new()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, static(), Execute_ReturnsFailure_WhenNoUrlsProvided(), Execute_ReturnsFailure_WhenNoContentRetrieved(), foreach(), FetchRssNodeTests, return(), XPoster.Tests.Workflows.Nodes

### Community 89 - "Entity (Community 89)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, WorkflowProfile(), new(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), OrchestratorFactoryTests(), CreateFactory(), CreateFactoryWithProfiles(), SetupMocksForOrchestratorFactory()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GetImageGenerationEndpoint(), if(), XPoster.Services, GenerateImageAsync(), catch(), FalAiImageService()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), static(), AiTextNodeTests, Execute_Throws_WhenProviderNameIsUnknown(), return(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), IsEnabled(), Dispose(), XPoster.Tests.Integration

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, Message, OpenAIImageResponse, ImageData, XPoster.Models

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, foreach(), ExecuteAsync(), FetchRssNode(), if(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), BuildChatPayload()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, WorkflowContext, HasData(), SetData(), if(), KeyNotFoundException(), XPoster.Workflows.Models

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Post_DefaultImageIsNull(), PostTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), DeleteAsync(), UploadAsync(), if(), XPoster.Services, BlobUploadResult()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), AzureFoundryOptionsValidatorTests

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, ExecuteAsync(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes, AiTextNode()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, while(), catch(), GenerateTextAsync(), GenerateImageAsync(), var(), XPoster.Services

### Community 105 - "Entity (Community 105)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 106 - "Entity (Community 106)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), XPoster, if(), Run()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, catch(), ResolveSenders(), Resolve(), WorkflowOrchestrator(), NoOrchestrator(), XPoster.Orchestrators

### Community 109 - "Entity (Community 109)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), CreateValidJpegBytes(), HttpResponseMessage()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, if(), IgSender(), XPoster.SenderPlugins, SendAsync(), catch()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, XPoster.Contracts, SaveAsync(), UpdateStatusAsync(), IContainerStateStore, GetPendingAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, foreach(), HttpResponseBodyLogger(), IsEnabledFor(), XPoster.Services, while(), Log()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, InvalidOperationException(), if(), AddWorkflows(), foreach(), XPoster.Workflows.Configuration

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, Apply(), foreach(), TagReplacementService(), if(), XPoster.Services

### Community 101 - "Entity (Community 101)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, SendAsync_OptOutHeader_LogsNothing(), SendAsync_NotEnabled_SuccessNotLogged(), SendAsync(), return(), var(), static()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, WorkflowNodeResult(), if(), ExecuteAsync(), AiImageNode(), XPoster.Workflows.Nodes

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, StubHttpMessageHandler(), if(), CapturedRequest(), BuildSequenceHandler(), var()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, GetPendingAsync(), InMemoryContainerStateStore, SaveAsync(), UpdateStatusAsync()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XPoster.SenderPlugins, SendAsync(), catch(), if(), XSender()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GenerateImageAsync(), while(), XPoster.Services, GenerateTextAsync(), GetImageGenerationEndpoint(), AzureFoundryService()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), InvalidOperationException(), XPoster.Credentials, Validate(), if(), CredentialsStartupValidator()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, if(), InstagramCredentialsValidator, Validate()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), ResolveWorkflowOrchestrator(), CreateEmptyNoOrchestrator(), nameof(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, XPoster.Workflows.Models, HasData(), IWorkflowContext, SetData()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), JsonResponse(), HttpClient(), MakeDownloadClient(), var()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender(), IgSender_ImplementsISender()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, GetProvider(), XPoster.Workflows.Utilities, return(), IsJsonLike(), catch()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), BlobServiceClient(), if(), Uri()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), XPoster.Models, Validate(), nameof()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, XPoster.Tests.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), PublishContainerAsync(), IMetaPublishingService

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, XPoster.Models, nameof(), Validate(), if()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), XPoster.Credentials, FacebookCredentialsValidator, if()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), DryRunSender(), SendAsync()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync(), AcquireCryptoValueNode()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), if(), Input(), BuildPowerLawPostNodeTests(), Execute_UsesSymbol_ForPostTag()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, Validate(), XPoster.Models, if(), nameof()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, XPoster.Contracts, UploadAsync(), DeleteAsync()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, AppendMediaSegmentsAsync(), FinalizeMediaAsync(), if(), SignRequest(), ThrowIfNotSuccess()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, BuildPowerLawPostNode(), if(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, IsBinaryMediaType(), SendAsync(), HttpResponseBodyLoggingHandler(), foreach(), XPoster.Services

### Community 139 - "Entity (Community 139)"
Cohesion: 0.33
Nodes (6): XApiException.cs, catch(), XPoster.SenderPlugins, foreach(), XApiException(), BuildMessage()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_CallsFeedServiceForMultipleUrls(), Input(), Execute_ConcatenatesMultipleFeeds(), var(), WorkflowNodeInput()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, XPoster.Workflows.Engine, if(), foreach(), HasCycle()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, var(), Input(), Execute_Throws_WhenValidProviderNotRegistered(), Execute_ReturnsGeneratedText(), Execute_PassesStepOptionsToPromptRequest()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 163 - "Entity (Community 163)"
Cohesion: 0.40
Nodes (5): AzureFoundryService.cs, catch(), GetChatCompletionsEndpoint(), if(), var()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, ToDefinition(), WorkflowDefinition(), XPoster.Workflows.Configuration

### Community 179 - "Entity (Community 179)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), XPoster.Workflows.Abstractions, IWorkflowNode

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, IWorkflowEngine, XPoster.Workflows.Engine, ExecuteAsync()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 175 - "Entity (Community 175)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, XPoster.Tests.Integration, return(), ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), static()

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Contracts

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Providers, TimeProvider

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, OkJson(), if(), BuildApiClient(), HttpResponseMessage()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, ICredentialsStartupValidator, Validate()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, Resolve(), XPoster.Contracts

### Community 172 - "Entity (Community 172)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), var(), XPoster.Services, GenerateTextAsync()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, XPoster.Contracts, IAiProviderSection, IAiProviderOptions

### Community 171 - "Entity (Community 171)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), AddHttpResponseBodyLogging(), XPoster.Extensions

### Community 162 - "Entity (Community 162)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, params(), BuildFactory(), _responder(), SendAsync()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), OpenAiService(), if()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, if(), WorkflowOrchestrator()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, FormatResponseHeaders(), if(), TruncateUtf8(), SanitizeAndTruncate()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver(), Resolve(), XPoster.Workflows.Services

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Contracts

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, resolve(), foreach(), ValidateOptions()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 194 - "Entity (Community 194)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 196 - "Entity (Community 196)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 189 - "Entity (Community 189)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, var(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer(), ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders()

### Community 208 - "Entity (Community 208)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), new(), WorkflowExecutionResult()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), ExecuteAsync(), new()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 210 - "Entity (Community 210)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 212 - "Entity (Community 212)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, WorkflowExecutionResult(), XPoster.Workflows.Engine

### Community 214 - "Entity (Community 214)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, SanitizeUrl(), XPoster.Services, foreach()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, var(), StubNode(), new()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, XPoster.Workflows.Abstractions, WorkflowNodeResult()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, WorkflowNodeDefinition(), XPoster.Workflows.Engine

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 232 - "Entity (Community 232)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 244 - "Entity (Community 244)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 241 - "Entity (Community 241)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 242 - "Entity (Community 242)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, if(), TryLogAsync()

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, WorkflowContextKeys.cs, WorkflowContextKeys.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, Sanitize(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 237 - "Entity (Community 237)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 239 - "Entity (Community 239)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 240 - "Entity (Community 240)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 238 - "Entity (Community 238)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, SlotScheduleOptions.cs, XPoster.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, if(), InvalidOperationException()

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 220 - "Entity (Community 220)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): MediaType.cs, XPoster.Workflows.Models, MediaType.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 224 - "Entity (Community 224)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 248 - "Entity (Community 248)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

