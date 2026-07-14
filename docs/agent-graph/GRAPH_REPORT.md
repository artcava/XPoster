# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 182 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Integration` - 2 edges
2. `XPoster.Credentials` - 2 edges
3. `XPoster.Tests.Providers` - 2 edges
4. `TimeProviderTests` - 2 edges
5. `FacebookCredentialsValidator` - 2 edges
6. `XPoster.SenderPlugins` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Providers` - 2 edges
9. `XPoster.Services` - 2 edges
10. `XPoster.Tests.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, XPoster.Tests.Services, var(), ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), AzureFoundryUrlJson(), AzureFoundryB64Json(), ParseImageResponseAsync_WhenMalformedJson_LogsError() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit(), OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, XPoster.Tests.Services, static(), Parse_UnsupportedProvider_ReturnsEmpty(), return(), new(), AiServiceHelperImageTests, Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), SectionName_IsOpenAI(), SectionName_IsPerplexity(), XPoster.Tests.Models (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, FbSender_ImplementsISender(), Constructor_WithNullFactory_ThrowsArgumentNullException(), FbSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), PerplexityServiceTests, XPoster.Tests.Services (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderTests() (+13 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekService(), DeepSeekServiceTests, GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), new(), SendAsync(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), FakeHttpMessageHandler() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WithInvalidBytes_ReturnsNull(), IgSenderImageFlowTests (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), AzureFoundryService() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), MetaPublishingService(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_CanMoveEntryBackToPending(), XPoster.Tests.Services, UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName() (+8 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenDataIsNull_DoesNotThrow(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, Uri(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithoutImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), SendAsync_WhenHttpClientThrows_ReturnsFalse() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WhenKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), SendAsync_WithImageBytes_ReturnsTrue(), XPoster.Tests.SenderPlugins (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_ReturnWellFormedProfiles(), PowerLawSlot_Should_ContainLinkedInAndX(), XPoster.Tests.Providers, PowerLawSlot_Should_HaveNullTextAndImageProvider(), GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleFinishedAsync(), foreach(), catch(), XPoster, if(), TryDeleteBlobAsync() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), ImageData_CanBeCreated_WithUrl(), Post_CanHold_ImageBytes(), Message_CanBeCreated_WithContent() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, BuildSender(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, if(), OpenAiService(), var(), XPoster.Services, GetSummaryAsync(), while() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingApiKey_Fails(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), ValidOptions() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), XPoster.Tests.Providers, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_DefaultOptions_Succeeds(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingTextPlaceholder_ErrorNamesProperty() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveHour_ForBoundaryValues() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), new(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), XPoster.Tests.Providers, GetReplacements_Should_ReturnReadOnlyDictionary(), foreach(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_LogsPostContent(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSenderTests(), SendAsync_WhenProbeKeyMissing_LogsError(), Platform_ReturnsDryRun(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPosterContainerPollingFunctionTests, XPoster.Tests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, var(), while(), XPoster.Services, GetSummaryAsync(), GetChatCompletionsEndpoint(), GetImagePromptAsync() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), Constructor_InitializesCorrectly(), InSenderTests(), InSender(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), MessageMaxLength_Returns2800() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetImagePromptAsync(), XPoster.Services, if(), GetSummaryAsync(), PerplexityService(), while() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnReadOnlyList(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, if(), XPoster.Credentials, InvalidOperationException(), resolve(), Validate(), ValidateOptions() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), new(), XPoster.Tests.SenderPlugins, MessageMaxLength_Returns2200(), Platform_ReturnsInstagram() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), BuildSender(), InSenderResilienceTests (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), XPoster.Services, PublishContainerAsync(), MetaPublishingService(), if(), GetContainerStatusAsync() (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XSender(), XPoster.Tests.SenderPlugins (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), OrchestrateAsync_ReturnsEmptyList(), SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishTextOnlyAsync(), FbSender(), catch(), PublishPhotoAsync(), HandleResponseAsync(), if() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), FbSenderSendAsyncTests, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WithNoImage_ReturnsFalse(), IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithEmptyImageArray_ReturnsFalse() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptionsTests (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), HttpClientExtensionsTests, XPoster.Tests.Extensions, foreach() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), CreateTimerInfo() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for(), catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), XPoster.Tests.SenderPlugins (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), XPoster.SenderPlugins, using(), InvalidOperationException(), ResolveAuthorUrn(), generatePayLoad(), catch() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), BuildCreds(), FbSenderImageFlowTests, InvalidImageBytes(), HttpRequestException(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), BuildSequenceHandler(), XPoster.Tests.Integration, BuildProviderWithHandler(), HttpResponseMessage(), var() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), catch(), FeedOrchestrator(), foreach(), AcquireFeedContentAsync(), XPoster.Orchestrators

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, PostTests, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), GetImagePromptAsync(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), GenerateImageAsync(), AzureFoundryService(), XPoster.Services

### Community 69 - "Entity (Community 69)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), Dispose(), IsEnabled(), XPoster.Tests.Integration

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Message, ImageData, Choice, OpenAIImageResponse, XPoster.Models

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, DeleteAsync(), UploadAsync(), XPoster.Services, if(), BlobUploadResult(), BlobStorageService()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, GetPendingAsync(), UpdateStatusAsync(), XPoster.Services, InMemoryContainerStateStore, SaveAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GetImageGenerationEndpoint(), if(), var(), while(), catch(), BuildImagePromptPayload()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), catch(), if(), XPoster.SenderPlugins, IgSender()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), foreach(), XPoster.Services, TagReplacementService()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), GetProfiles(), XPoster.Providers, ScheduledOrchestrationProfile(), typeof()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), GenerateImageAsync(), if(), XPoster.Services

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Providers

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), BlobServiceClient(), DefaultAzureCredential(), if(), Uri()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ExtractOpenAiBytes(), ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, XPoster.Contracts, UpdateStatusAsync(), SaveAsync(), GetPendingAsync(), IContainerStateStore

### Community 83 - "Entity (Community 83)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), CreateValidJpegBytes(), HttpResponseMessage(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, if(), XPoster, Run(), catch(), XFunction()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), XPoster.Credentials, if(), FacebookCredentialsValidator

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), ITextToTextProvider, GetSummaryAsync(), XPoster.Contracts

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, IMetaPublishingService, PublishContainerAsync(), GetContainerStatusAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), IBlobStorageService, DeleteAsync()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), HttpClient(), JsonResponse()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach(), if()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), InstagramCredentialsValidator

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), XPoster.SenderPlugins, SendAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, Apply(), ITagReplacementService

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Providers, TimeProvider

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, Validate(), ICredentialsStartupValidator

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), catch(), if()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 140 - "Entity (Community 140)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 150 - "Entity (Community 150)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): MaskUrlTelemetryInitializer.cs, MaskUrlTelemetryInitializer, Initialize()

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): MaskUrlTelemetryInitializer.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

