# Graph Report - XPoster  (2026-07-13)

## Summary
- 1505 nodes · 2551 edges · 182 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Credentials` - 2 edges
3. `InstagramCredentialsValidator` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Services` - 2 edges
6. `IContainerStateStore` - 2 edges
7. `Post` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Orchestrators` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeResponse(), MakeHttpClientThatThrows(), FalAiJson(), ChatJson(), OpenAiB64Json(), new() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), OpenAiServiceTests, XPoster.Tests.Services (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_FalAi_DownloadThrows_LogsError(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), NoOrchestrator_SupportedPlatforms_IsEmpty(), FeedProfile(), new() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, OpenAiOptionsExtensionsTests, DeepSeekOptionsExtensionsTests, FalAiOptionsExtensionsTests, new(), SectionName_IsDeepSeek(), PerplexityOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory(), BuildSender(), Constructor_InitializesCorrectly(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), MessageMaxLength_Returns3000() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), XPoster.Tests.Services, foreach() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender() (+13 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekService(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), DeepSeekServiceTests, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, Uri(), return(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WithValidJpeg_ReturnsSameBytes() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FakeHttpMessageHandler() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), CreateSut(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), PublishContainerAsync_WhenOk_ReturnsPublishId() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, if(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), HttpResponseMessage(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), AzureFoundryService() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, XPoster.Tests.Services, SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), DefaultSlotProfileProviderTests, PowerLawSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests, XPoster.Tests.Services, Initialize_WhenDataIsNull_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, ValidPost(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), DryRunSender_ImplementsISender(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_ReturnsFalse() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, BlobStorageService(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenStorageThrows_PropagatesException(), XPoster.Tests.Services, DeleteAsync_WithEmptyBlobName_ThrowsArgumentException() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenBlobUploadFails_ReturnsFalse(), IgSenderResilienceTests, PostWithImage(), new(), PostWithoutImage(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, TryDeleteBlobAsync(), HandleTerminalFailureAsync(), switch(), if(), PollPendingContainersAsync(), ProcessContainerAsync() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), XPoster.Tests.Models, RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), Post_CanHold_ImageBytes(), Choice_CanBeCreated_WithMessage() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, XPoster.Tests.Models, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetPromptForImage(), GenerateImageAsync(), GetImagePromptAsync(), catch(), if(), OpenAiService() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Providers, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_DefaultOptions_Succeeds() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), BuildCreds() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), typeof(), ScheduledOrchestrationProfileTests, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), XPoster.Tests.Models, Constructor_Should_PreserveHour_ForBoundaryValues() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, BuildImagePromptPayload(), XPoster.Services, GetChatCompletionsEndpoint(), var(), GetImagePromptAsync(), while() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetChatCompletionsEndpoint(), while(), if(), GetImagePromptAsync(), XPoster.Services, GetSummaryAsync() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, foreach(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, InSender(), Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSenderTests(), MessageMaxLength_Returns2800(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, BuildSender(), SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), DryRunSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPosterContainerPollingFunctionTests, XPoster.Tests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, foreach(), CredentialsStartupValidator(), catch(), InvalidOperationException(), ValidateOptions(), Validate() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, new(), BuildSender(), Platform_ReturnsInstagram(), BuildCreds(), Constructor_InitializesCorrectly(), MessageMaxLength_Returns2200(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, ValidPost(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), catch(), GetApiVersion(), if(), MetaPublishingService(), XPoster.Services (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyList(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), Name_IsNoOrchestrator() (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, FbSender(), SendAsync(), HandleResponseAsync(), PublishPhotoAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), FbSenderSendAsyncTests, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, XSender(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedTests (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), for(), catch() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildFactory(), BuildCreds(), HttpRequestException(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, InvalidImageBytes() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), XPoster.Tests.Services, CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), SendAsync(), XPoster.SenderPlugins, InvalidOperationException(), generatePayLoad(), Exception(), catch() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, foreach(), HttpClientExtensionsTests, AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersExpectedNamedClients() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), params(), BuildSequenceHandler(), HttpResponseMessage(), BuildProviderWithHandler(), BuildDelayedHandler() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetChatCompletionsEndpoint(), XPoster.Services, GetSummaryAsync(), GetImagePromptAsync(), AzureFoundryService(), GenerateImageAsync(), BuildSummaryPayload()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, DeleteAsync(), BlobStorageService(), XPoster.Services, if(), BlobUploadResult(), UploadAsync()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), PostTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, IsEnabled(), Dispose(), CreateLogger(), CaptureLoggerProvider(), CaptureLogger()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, XPoster.Orchestrators, if(), foreach(), catch(), AcquireFeedContentAsync(), FeedOrchestrator()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, Message, ImageData, Choice, AIResponse, OpenAIImageResponse

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), new(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Providers, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, XPoster.Contracts, SaveAsync(), UpdateStatusAsync(), GetPendingAsync(), IContainerStateStore

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), if(), CreateValidJpegBytes(), HttpResponseMessage(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, Apply(), if(), foreach()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), GenerateImageAsync(), if(), XPoster.Services, FalAiImageService()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, SaveAsync(), GetPendingAsync(), InMemoryContainerStateStore, UpdateStatusAsync()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), LogAndReturnEmpty(), ParseImageResponseAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GetImageGenerationEndpoint(), var(), while(), if(), catch(), BuildImagePromptPayload()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, IgSender(), SendAsync(), if(), catch()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), XPoster.Providers, DryRunSlotProfileProvider(), GetProfiles()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), XFunction(), catch(), XPoster, if()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), HttpClient(), JsonResponse(), MakeDownloadClient()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), XPoster.Credentials, Validate(), InstagramCredentialsValidator

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), XPoster.Models, if(), foreach()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync(), IMetaPublishingService

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetSummaryAsync(), XPoster.Contracts, ITextToTextProvider, GetImagePromptAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), XPoster.Contracts, UploadAsync(), IBlobStorageService

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), DryRunSender(), if(), XPoster.SenderPlugins

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), DryRunSlotProfileProvider(), if(), BlobServiceClient()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 110 - "Entity (Community 110)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), catch(), GetFeedsAsync()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), return(), XPoster.Orchestrators

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, GetCurrentTime(), TimeProvider

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, GetFeedUrls(), XPoster.Contracts

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), GetFeedUrls(), XPoster.Providers

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Providers, GetProfiles()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 165 - "Entity (Community 165)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): MaskUrlTelemetryInitializer.cs, Initialize(), MaskUrlTelemetryInitializer

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (2): MaskUrlTelemetryInitializer.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

