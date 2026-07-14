# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 181 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests` - 2 edges
2. `XPoster.Tests.Orchestrators` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Credentials` - 2 edges
7. `XPoster.Credentials` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), AzureFoundryB64Json(), XPoster.Tests.Services, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_SharesImageBytes_AcrossSenders(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), MakeHandler(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, return(), Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_UnsupportedProvider_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, ConfigurationBuilder(), AzureFoundryOptionsExtensionsTests, BuildProvider(), BuildConfig(), AddDeepSeekOptions_RegistersValidator(), AddAzureFoundryOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, MessageMaxLength_Returns3000(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), return() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), PerplexityServiceTests, XPoster.Tests.Services (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, MessageMaxLength_Returns250(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse() (+13 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), XPoster.Tests.Services (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), SendAsync(), new(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, IgSenderImageFlowTests, IgSender(), BuildSender(), CreateMalformedPngBytes(), XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), AzureFoundryService(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), ChatCompletionJson(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_ReturnsOnlyPendingEntries(), InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), BuildSender(), IgSenderResilienceTests, IgSender(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithImage() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, PowerLawSlot_Should_ContainLinkedInAndX(), PowerLawSlot_Should_HaveNullTextAndImageProvider(), XPoster.Tests.Providers, GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenStorageThrows_PropagatesException(), XPoster.Tests.Services, BlobStorageServiceTests, CreateSut(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageService() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenKeyMissing_ReturnsFalse(), BuildConfig(), ConfigurationBuilder(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), DryRunSender(), new() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Choice_CanBeCreated_WithMessage(), Post_CanBeCreated_WithRequiredContent(), ModelsTests, OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, XPoster.Tests.Models, ValidOptions(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, ProcessContainerAsync(), XPosterContainerPollingFunction(), XPoster, switch(), Run(), TryDeleteBlobAsync() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, Validate_MissingModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), XPoster.Tests.Providers, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, var(), while(), XPoster.Services, if(), catch(), GetSummaryAsync() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, var(), BuildImagePromptPayload(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, Platform_ReturnsDryRun(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), CreateOrchestrator(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), PowerLawOrchestratorTests() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), var(), XPoster.Services, while(), GetSummaryAsync(), GetImagePromptAsync() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), foreach() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), BuildService(), FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Constructor_InitializesCorrectly(), InSender(), InSenderTests(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), MessageMaxLength_Returns2800(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), CreateSut(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, typeof(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests, XPoster.Tests.Models, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveHour_ForBoundaryValues() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), BuildCreds(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Platform_ReturnsInstagram(), MessageMaxLength_Returns2200(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, resolve(), Validate(), ValidateOptions(), XPoster.Credentials, foreach(), CredentialsStartupValidator() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), ValidPost(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, SendIt_IsAlwaysFalse(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), SendAsync(), XPoster.SenderPlugins, FbSender(), if(), HandleResponseAsync() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, IgSender() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XSender() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, if(), MetaPublishingService(), XPoster.Services, PublishContainerAsync(), GetContainerStatusAsync(), catch() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins, BuildCreds(), BuildFactory() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), Exception(), InvalidOperationException(), XPoster.SenderPlugins, generatePayLoad(), ResolveAuthorUrn(), using() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, BuildDelayedHandler(), params(), BuildProviderWithHandler(), BuildSequenceHandler() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), XPoster.Tests.Models (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, HttpRequestException(), BuildCreds(), FbSenderImageFlowTests (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, CryptoServiceTests, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), MakeService() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection(), HttpClientExtensionsTests (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), XPoster.Tests.Models, PostTests

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Choice, AIResponse, OpenAIImageResponse, XPoster.Models, Message, ImageData

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), Dispose(), CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), XPoster.Tests.Integration

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionDiffersFromEnumName()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, catch(), AcquireFeedContentAsync(), foreach(), if(), XPoster.Orchestrators, FeedOrchestrator()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), XPoster.Services, BlobStorageService(), BlobUploadResult(), DeleteAsync(), if()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, BuildSummaryPayload(), AzureFoundryService(), GenerateImageAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), new(), XPoster.Tests.Providers

### Community 80 - "Entity (Community 80)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ParseImageResponseAsync(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ExtractFalAiBytesAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, UpdateStatusAsync(), InMemoryContainerStateStore, SaveAsync(), GetPendingAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), Apply(), TagReplacementService(), XPoster.Services, if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), CreateValidJpegBytes(), if(), HttpResponseMessage()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), if(), Run(), XFunction(), XPoster

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), XPoster.Services, GenerateImageAsync(), if()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), BlobServiceClient(), Uri(), if(), DefaultAzureCredential()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles(), typeof(), XPoster.Providers

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), catch(), if(), SendAsync(), XPoster.SenderPlugins

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), GetPendingAsync(), UpdateStatusAsync(), IContainerStateStore, XPoster.Contracts

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), var(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), if(), catch()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, IBlobStorageService, UploadAsync(), DeleteAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), JsonResponse(), HttpClient()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync(), IMetaPublishingService

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GetImagePromptAsync(), GetSummaryAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSenderTests(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, Validate(), FacebookCredentialsValidator, if()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, foreach(), if(), Validate()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), XPoster.Credentials, Validate(), InstagramCredentialsValidator

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Providers

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Providers, ConfigurationFeedUrlProvider()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 108 - "Entity (Community 108)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, return(), XPoster.Orchestrators, Resolve(), foreach()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, Validate(), ICredentialsStartupValidator

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, GetCurrentTime(), TimeProvider

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, GetFeedUrls(), XPoster.Contracts

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), MaskUrlTelemetryProcessor(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), GetFeedsAsync(), Exception()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Providers, GetProfiles()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Orchestrators, BaseOrchestrator()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

