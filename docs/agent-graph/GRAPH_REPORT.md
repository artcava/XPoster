# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 181 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Providers` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Credentials` - 2 edges
6. `XPoster.Credentials` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Contracts` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, FalAiJson(), ChatJson(), XPoster.Tests.Services, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), AiServiceHelperTests (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty(), OpenAiService(), XPoster.Tests.Services, OpenAiServiceTests (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_Returns429_LogsWarning(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, XPoster.Tests.Orchestrators, new(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), FeedProfile(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), CreateFactory() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, BuildConfig(), BuildProvider(), PerplexityOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory(), BuildSender(), Constructor_InitializesCorrectly(), FbSender_ImplementsISender(), Constructor_WithNullFactory_ThrowsArgumentNullException() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse() (+13 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), XPoster.Tests.Services (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), Uri(), IgSenderImageFlowTests (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FeedServiceTests, foreach(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), FeedService() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), HttpResponseMessage(), if(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), AzureFoundryService(), ChatCompletionJson() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), IgSender(), IgSenderResilienceTests, PostWithoutImage(), new(), PostWithImage() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_ContainLinkedInAndX() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageService(), BlobStorageServiceTests, UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, Constructor_WithNullConfiguration_ThrowsArgumentNullException(), BuildConfig(), ConfigurationBuilder(), SendAsync_WithImageBytes_ReturnsTrue(), new(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_ReturnsFalse() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess() (+6 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), AIResponse_CanBeCreated_WithChoices(), Choice_CanBeCreated_WithMessage(), RSSFeed_PublishDate_DefaultsToMinValue(), ModelsTests, Post_CanHold_ImageBytes() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPoster, XPosterContainerPollingFunction(), catch(), HandleFinishedAsync(), switch(), HandleTerminalFailureAsync() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_MissingModelId_Fails() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), XPoster.Tests.Models, Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), XPoster.Tests.Providers, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummaryAsync(), catch(), GetSummary(), GetImagePromptAsync(), GetPromptForImage(), GenerateImageAsync() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_LogsError(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_ReturnsIntMaxValue(), Platform_ReturnsDryRun(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WhenKeyWhitespace_ReturnsFalse() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), XPoster.Tests.Providers, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, BuildSummaryPayload(), BuildImagePromptPayload(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), XPoster.Services, var() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), var(), while(), XPoster.Services, GetSummaryAsync(), BuildSummaryPayload() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, typeof(), XPoster.Tests.Models, Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), ScheduledOrchestrationProfileTests, Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), new() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, InSenderTests(), Constructor_InitializesCorrectly(), InSender(), Platform_ReturnsLinkedIn(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPosterContainerPollingFunctionTests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenNoPendingContainers_DoesNothing() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSender(), XPoster.Tests.SenderPlugins, InSenderResilienceTests, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), new(), XPoster.Tests.SenderPlugins, Platform_ReturnsInstagram(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, XPoster.Tests.Providers, GetFeedUrls_Should_ReturnReadOnlyList(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, InvalidOperationException(), Validate(), ValidateOptions(), XPoster.Credentials, resolve(), if() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), XSender(), XSenderResilienceTests, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), FbSenderSendAsyncTests, BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests, Build() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), catch(), HttpRequestException(), MetaPublishingService(), if(), XPoster.Services (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, BuildSender(), IgSender(), SendAsync_WithEmptyImageArray_ReturnsFalse(), XPoster.Tests.SenderPlugins (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishPhotoAsync(), XPoster.SenderPlugins, SendAsync(), PublishTextOnlyAsync(), if(), FbSender() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), catch(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), XPoster.Tests.Integration (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, HttpResponseMessage(), FbSenderResilienceTests (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), XPoster.Tests.Extensions, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_CanCreateAllExpectedNamedClients(), HttpClientExtensionsTests, AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, using(), ResolveAuthorUrn(), catch(), InvalidOperationException(), Exception(), generatePayLoad() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildCreds(), InvalidImageBytes(), BuildFactory(), FbSenderImageFlowTests, HttpRequestException(), XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Orchestrators, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedTests (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, var(), params(), BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, DeleteAsync(), UploadAsync(), XPoster.Services, if(), BlobStorageService(), BlobUploadResult()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), XPoster.Tests.Integration, IsEnabled(), Dispose()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, OpenAIImageResponse, Message, AIResponse, ImageData, Choice, XPoster.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, XPoster.Orchestrators, foreach(), FeedOrchestrator(), catch(), AcquireFeedContentAsync(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), GenerateImageAsync(), AzureFoundryService(), XPoster.Services, GetSummaryAsync()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), AzureFoundryOptionsValidatorTests

### Community 69 - "Entity (Community 69)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, if(), catch(), Run(), XFunction()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), XPoster.Providers

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), if(), Uri(), BlobServiceClient(), DefaultAzureCredential()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, foreach(), if(), Apply()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, GetPendingAsync(), UpdateStatusAsync(), XPoster.Services, SaveAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, catch(), if(), FalAiImageService(), GenerateImageAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), ParseImageResponseAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GetImageGenerationEndpoint(), var(), while(), catch(), BuildImagePromptPayload(), if()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), GetPendingAsync(), IContainerStateStore, XPoster.Contracts, UpdateStatusAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, IgSender(), catch(), if()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Providers, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), HttpResponseMessage(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), XPoster.Credentials, if(), FacebookCredentialsValidator

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, UploadAsync(), IBlobStorageService, XPoster.Contracts, DeleteAsync()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, ITextToTextProvider, GetSummaryAsync(), GetImagePromptAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), Validate(), InstagramCredentialsValidator, XPoster.Credentials

### Community 95 - "Entity (Community 95)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), HttpClient(), JsonResponse(), var()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests(), IgSender_ImplementsISender(), IgSender()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), XPoster.Models, Validate(), foreach()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, XPoster.Contracts, GenerateImageAsync()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryInitializer.cs, MaskUrlTelemetryInitializer.cs, MaskUrlTelemetryInitializer(), Initialize(), if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, GetFeedsAsync(), Exception()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration

### Community 121 - "Entity (Community 121)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, XPoster.Orchestrators, return(), Resolve(), foreach()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Providers

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 136 - "Entity (Community 136)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 140 - "Entity (Community 140)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, FacebookCredentials.cs, FacebookCredentials.cs

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

