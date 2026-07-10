# Graph Report - XPoster  (2026-07-10)

## Summary
- 1505 nodes · 2551 edges · 182 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `DeepSeekOptionsValidatorTests` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `XPoster.Tests.Providers` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `InstagramCredentialsValidator` - 2 edges
6. `XPoster.SenderPlugins` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `XPoster.Tests.Helpers` - 2 edges
9. `ICryptoService` - 2 edges
10. `ITimeProvider` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, FalAiJson(), ChatJson(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_WhenStatusIs429_LogsWarning(), ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, ChatCompletionJson(), BuildService(), OpenAiServiceTests, XPoster.Tests.Services, MakeHandlerMock(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Orchestrators (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_DownloadThrows_LogsError(), Parse_AzureFoundry_ValidB64_ReturnsBytes() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), typeof(), XPoster.Tests.Orchestrators, FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), FeedProfile(), new() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_RegistersValidator(), AddFalAiOptions_RegistersValidator(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory(), BuildSender(), Constructor_InitializesCorrectly(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes(), XPoster.Tests.SenderPlugins (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, MessageMaxLength_Returns250(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), AzureFoundryServiceTests, BuildService() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), Uri(), IgSender() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), XPoster.Tests.Services (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), AzureFoundryService(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), ChatCompletionJson(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, XPoster.Tests.Services, SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), GetPendingAsync_ReturnsOnlyPendingEntries(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_HaveUniqueHours(), GetProfiles_Should_ReturnWellFormedProfiles(), GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenStorageThrows_PropagatesException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, ConfigurationBuilder(), BuildConfig(), SendAsync_WithImageBytes_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), ValidPost(), DryRunSender() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), XPoster.Tests.Services, MaskUrlTelemetryInitializerTests, Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenBlobUploadFails_ReturnsFalse(), IgSenderResilienceTests, new(), PostWithImage(), PostWithoutImage(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage(), AIResponse_CanBeCreated_WithChoices(), RSSFeed_PublishDate_DefaultsToMinValue(), ModelsTests, RSSFeed_CanBeCreated_WithAllProperties() (+6 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess(), Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, TryDeleteBlobAsync(), XPoster, XPosterContainerPollingFunction(), Run(), foreach(), ProcessContainerAsync() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), BuildSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender_ImplementsISender(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingModelId_Fails(), Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetPromptForImage(), GenerateImageAsync(), catch(), GetImagePromptAsync(), GetSummary(), if() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models, Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), XPoster.Tests.Providers, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), DryRunSenderTests(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), SendAsync_WhenKeyWhitespace_ReturnsFalse() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), XPoster.Tests.Providers, Constructor_Should_Throw_When_OptionsIsNull() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), new(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetChatCompletionsEndpoint(), XPoster.Services, GetSummaryAsync(), GetImagePromptAsync(), if(), while() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), BuildService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), FalImageJson(), FalAiImageServiceTests, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPosterContainerPollingFunctionTests, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), XPoster.Tests, RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), BuildImagePromptPayload(), GetChatCompletionsEndpoint(), GetSummaryAsync(), if(), GetImagePromptAsync() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), Platform_ReturnsLinkedIn(), MessageMaxLength_Returns2800() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), InSender(), BuildSender() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, foreach(), CredentialsStartupValidator(), catch(), Validate(), InvalidOperationException(), resolve() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, MakeHandlerMock(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), XPoster.Tests.Extensions, AddXPosterAiProviders_ReturnsSameServiceCollection() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, XPoster.Tests.SenderPlugins, BuildSender(), MessageMaxLength_Returns2200(), Platform_ReturnsInstagram(), new(), Constructor_InitializesCorrectly(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, XPoster.Tests.Orchestrators, SendIt_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), XPoster.SenderPlugins, PublishPhotoAsync(), if(), FbSender(), HandleResponseAsync() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), BuildSender(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XSenderResilienceTests (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), HttpRequestException(), PublishContainerAsync(), MetaPublishingService(), XPoster.Services, if() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests, BuildSender(), IgSender(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, BuildFactory(), BuildCreds(), FbSenderSendAsyncTests, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Orchestrators, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, params(), BuildSequenceHandler(), BuildProviderWithHandler(), HttpResponseMessage() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), FbSenderImageFlowTests, BuildCreds(), BuildFactory(), HttpRequestException() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), ResolveAuthorUrn(), using(), generatePayLoad(), InvalidOperationException(), SendAsync(), XPoster.SenderPlugins (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, HttpClientExtensionsTests, foreach(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, PendingContainer(), CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), PostTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, FeedOrchestrator(), foreach(), if(), XPoster.Orchestrators, catch(), AcquireFeedContentAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), CreateLogger(), Dispose(), IsEnabled(), XPoster.Tests.Integration

### Community 65 - "Entity (Community 65)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetImagePromptAsync(), BuildSummaryPayload(), GenerateImageAsync(), GetChatCompletionsEndpoint(), AzureFoundryService(), XPoster.Services, GetSummaryAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), DeleteAsync(), XPoster.Services, BlobStorageService(), UploadAsync(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, OpenAIImageResponse, ImageData, Choice, AIResponse, Message

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, SendAsync(), if(), IgSender(), catch()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync(), IContainerStateStore, SaveAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, BuildImagePromptPayload(), catch(), GetImageGenerationEndpoint(), if(), var(), while()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, LogAndReturnEmpty(), ExtractOpenAiBytes(), ParseImageResponseAsync(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, Apply(), if(), foreach()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Providers, new(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), if(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), GetPendingAsync(), XPoster.Services, UpdateStatusAsync(), InMemoryContainerStateStore

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, Run(), XFunction(), if(), catch()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, InstagramCredentialsValidator, Validate(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), DryRunSlotProfileProvider(), Uri(), BlobServiceClient()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GetSummaryAsync(), GetImagePromptAsync(), XPoster.Contracts

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSenderTests()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), UploadAsync(), IBlobStorageService, XPoster.Contracts

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, foreach(), if(), Validate()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, HttpClient(), JsonResponse(), var(), MakeNoOpClient(), MakeDownloadClient()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, ISender, SendAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), Validate(), XPoster.Credentials

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Providers

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 115 - "Entity (Community 115)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, catch(), Exception()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), XPoster.Orchestrators, return(), foreach()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Orchestrators

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): MaskUrlTelemetryInitializer.cs, MaskUrlTelemetryInitializer, Initialize()

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 170 - "Entity (Community 170)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 147 - "Entity (Community 147)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): MaskUrlTelemetryInitializer.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

