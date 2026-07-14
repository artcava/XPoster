# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 181 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Tests.Providers` - 2 edges
3. `XPoster.Providers` - 2 edges
4. `XPoster.Orchestrators` - 2 edges
5. `XPoster.Credentials` - 2 edges
6. `XPoster.Credentials` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, ParseImageResponseAsync_UnsupportedProvider_LogsError(), ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_MissingB64JsonProperty_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), MakeHandler(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_SharesImageBytes_AcrossSenders(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty(), Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_OpenAi_ValidB64_ReturnsBytes() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), CreateFactory(), CreateFactoryWithProfiles(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildProvider(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, BuildConfig(), SectionName_IsOpenAI(), XPoster.Tests.Models (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, NormalizeImage_WithValidPng_ReturnsOriginalBytes(), MessageMaxLength_Returns3000(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), FbSender_ImplementsISender(), Constructor_WithNullFactory_ThrowsArgumentNullException() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), BuildService() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekServiceTests (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, AzureFoundryServiceTests, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), new(), SendAsync(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), FeedService() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, IgSenderImageFlowTests, BuildSender(), CreateMalformedPngBytes(), IgSender(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), if(), HttpResponseMessage(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), ChatCompletionJson(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), MetaPublishingService(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_ReturnsOnlyPendingEntries(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException() (+8 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenKeyMissing_ReturnsFalse(), new(), BuildConfig(), DryRunSender_ImplementsISender(), ConfigurationBuilder(), DryRunSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), GetProfiles_Should_HaveUniqueHours(), GetProfiles_Should_ReturnWellFormedProfiles() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, Uri(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), new(), PostWithoutImage() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests, XPoster.Tests.Services, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenStorageThrows_PropagatesException(), XPoster.Tests.Services, BlobStorageService(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), CreateSut() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), ModelsTests, RSSFeed_CanBeCreated_WithAllProperties(), Post_CanBeCreated_WithRequiredContent(), OpenAIImageResponse_CanBeCreated_WithData(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPoster, XPosterContainerPollingFunction(), catch(), switch(), Run(), foreach() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), XPoster.Tests.Models, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), if(), var(), XPoster.Services, while(), GetPromptForImage() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models, ValidOptions(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), ValidOptions(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), BuildSender(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+5 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetSummaryAsync(), DeepSeekService(), BuildImagePromptPayload(), GetImagePromptAsync(), BuildSummaryPayload(), GetChatCompletionsEndpoint() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, while(), XPoster.Services, PerplexityService(), BuildImagePromptPayload(), if(), GetImagePromptAsync() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Platform_ReturnsLinkedIn(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), XPoster.Tests.Models (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_DoesNotCallAnyOutboundSocialApi(), MessageMaxLength_ReturnsIntMaxValue(), Platform_ReturnsDryRun(), DryRunSenderTests(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildCreds(), Constructor_InitializesCorrectly(), new(), XPoster.Tests.SenderPlugins, Platform_ReturnsInstagram(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList(), XPoster.Tests.Providers (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, CredentialsStartupValidator(), XPoster.Credentials, if(), foreach(), Validate(), resolve() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), ValidPost(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), IgSenderSendAsyncTests, IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), XPoster.Tests.SenderPlugins, SendAsync_WithNoImage_ReturnsFalse() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), SendAsync(), XPoster.SenderPlugins, FbSender(), if(), HandleResponseAsync() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests, BuildCreds(), BuildFactory(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), XSenderResilienceTests, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionTests() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyList(), XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), NoOrchestratorTests (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, PublishContainerAsync(), XPoster.Services, MetaPublishingService(), GetContainerStatusAsync(), catch(), GetApiVersion() (+2 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), HttpResponseMessage(), params(), var(), XPoster.Tests.Integration (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), BuildCreds(), HttpRequestException(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), BuildFactory(), FbSenderImageFlowTests (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, using(), ResolveAuthorUrn(), catch(), InvalidOperationException(), generatePayLoad(), Exception() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), HttpResponseMessage(), FbSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, for(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), foreach(), HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, foreach(), XPoster.Orchestrators, if(), AcquireFeedContentAsync(), FeedOrchestrator(), catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostTests, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, Post_DefaultImageIsNull()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, Choice, AIResponse, Message, OpenAIImageResponse, XPoster.Models

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), if(), DeleteAsync(), BlobUploadResult(), UploadAsync(), XPoster.Services

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, GetSummaryAsync(), GetChatCompletionsEndpoint(), GenerateImageAsync(), BuildSummaryPayload(), AzureFoundryService(), GetImagePromptAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, IsEnabled(), Dispose(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Providers

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), Apply(), foreach(), TagReplacementService(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), SaveAsync(), XPoster.Contracts, UpdateStatusAsync(), IContainerStateStore

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), typeof(), DryRunSlotProfileProvider(), GetProfiles()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, GetPendingAsync(), SaveAsync(), XPoster.Services, UpdateStatusAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services, ExtractFalAiBytesAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, if(), catch(), XFunction(), XPoster, Run()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), XPoster.SenderPlugins, IgSender(), catch(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), if(), FalAiImageService(), XPoster.Services, GenerateImageAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), CreateValidJpegBytes(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), catch(), BuildImagePromptPayload(), GetImageGenerationEndpoint(), while(), var()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), if(), BlobServiceClient(), Uri(), DefaultAzureCredential()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync(), IMetaPublishingService

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeDownloadClient(), MakeNoOpClient(), JsonResponse(), HttpClient()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, Validate(), InstagramCredentialsValidator, if()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, Validate(), FacebookCredentialsValidator, if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), XPoster.Models, Validate(), if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), ITextToTextProvider, XPoster.Contracts, GetSummaryAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), UploadAsync(), IBlobStorageService, XPoster.Contracts

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), SendAsync(), XPoster.SenderPlugins, DryRunSender()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), Process(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), ScheduledOrchestrationProfile()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), return(), XPoster.Orchestrators

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), GetFeedsAsync(), Exception()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, Apply(), ITagReplacementService

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 135 - "Entity (Community 135)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, PostAsync(), BaseOrchestrator()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, FacebookCredentials.cs, FacebookCredentials.cs

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

