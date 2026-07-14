# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 181 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Services` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.Credentials` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Contracts` - 2 edges
7. `XPoster.Credentials` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Credentials` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_UnsupportedProvider_LogsError(), ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes(), FalAiJson() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, new(), OrchestrateAsync_AppliesHashtagsIndependently_PerSender(), foreach(), FeedOrchestratorTests(), CreateMultiSenderOrchestrator(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), MakeHandler(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, return(), Parse_UnsupportedProvider_LogsError(), Parse_UnsupportedProvider_ReturnsEmpty(), XPoster.Tests.Services, Parse_Returns429_LogsWarning(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_OpenAi_ValidB64_ReturnsBytes() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), CreateFactoryWithProfiles(), CreateFactory() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_RegistersValidator(), AddFalAiOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), OptionsExtensionsTests, FalAiOptionsExtensionsTests, OpenAiOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), return(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), XPoster.Tests.Services, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), BuildService(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, AzureFoundryServiceTests, GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, IgSender(), BuildSender(), CreateMalformedPngBytes(), Uri(), return(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), ChatCompletionJson(), AzureFoundryService(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GetSummaryAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, ValidPost(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), BuildConfig(), ConfigurationBuilder(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, CreateSut(), BlobStorageServiceTests, BlobStorageService(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, Uri() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), PowerLawSlot_Should_HaveNullTextAndImageProvider() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenTelemetryIsNotDependency_DoesNothing(), XPoster.Tests.Services, MaskUrlTelemetryInitializerTests, Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenDataIsNull_DoesNotThrow(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed() (+6 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPoster, if(), TryDeleteBlobAsync(), ProcessContainerAsync(), PollPendingContainersAsync(), switch() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), XPoster.Tests.Models, Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), var(), XPoster.Services, while(), GetSummaryAsync(), GetSummary() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_DefaultOptions_Succeeds(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi(), Platform_ReturnsDryRun(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), Platform_ReturnsLinkedIn() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests, ConfigurationTagReplacementProvider(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, if(), var(), while(), XPoster.Services, GetSummaryAsync(), BuildSummaryPayload() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, if(), GetImagePromptAsync(), BuildSummaryPayload(), BuildImagePromptPayload(), GetSummaryAsync(), GetChatCompletionsEndpoint() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), ScheduledOrchestrationProfileTests, Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenNoPendingContainers_DoesNothing(), XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPoster.Tests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, BuildService(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), ConfigurationFeedUrlProviderTests, XPoster.Tests.Providers, Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, resolve(), Validate(), ValidateOptions(), XPoster.Credentials, if(), catch() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), XPoster.Tests.Extensions (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildCreds(), Platform_ReturnsInstagram(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins, BuildSender(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), new() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, IgSender(), BuildSender(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), XPoster.Tests.SenderPlugins (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), XPoster.Tests.SenderPlugins, FbSenderSendAsyncTests (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), HttpRequestException(), PublishContainerAsync(), MetaPublishingService(), XPoster.Services, if() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishTextOnlyAsync(), catch(), HandleResponseAsync(), if(), FbSender(), PublishPhotoAsync() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators, SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), XSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), params(), XPoster.Tests.Integration, var(), HttpResponseMessage() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo(), PendingContainer() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), Exception(), ResolveAuthorUrn(), XPoster.SenderPlugins, catch(), generatePayLoad(), SendAsync() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildCreds(), InvalidImageBytes(), BuildFactory(), FbSenderImageFlowTests, HttpRequestException(), XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), catch(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedTests, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), DeepSeekOptionsValidatorTests (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), foreach(), HttpClientExtensionsTests, XPoster.Tests.Extensions, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), AzureFoundryService(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), GenerateImageAsync(), XPoster.Services

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), XPoster.Services, UploadAsync(), if(), DeleteAsync(), BlobUploadResult()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Message, OpenAIImageResponse, XPoster.Models, AIResponse, ImageData, Choice

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), XPoster.Orchestrators, FeedOrchestrator(), catch(), AcquireFeedContentAsync(), foreach()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled(), Dispose()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), SaveAsync(), XPoster.Contracts, UpdateStatusAsync(), IContainerStateStore

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), if(), XPoster.Services, FalAiImageService(), catch()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, var(), catch(), GetImageGenerationEndpoint(), while(), if(), BuildImagePromptPayload()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, if(), catch(), Run(), XFunction()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), catch(), if(), SendAsync(), XPoster.SenderPlugins

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, if(), DefaultAzureCredential(), DryRunSlotProfileProvider(), BlobServiceClient(), Uri()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), XPoster.Tests.Providers, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), ParseImageResponseAsync(), XPoster.Services

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, typeof(), GetProfiles(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), if(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), CreateValidJpegBytes(), HttpResponseMessage()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, TagReplacementService(), foreach(), Apply(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, UpdateStatusAsync(), XPoster.Services, GetPendingAsync(), SaveAsync()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSenderTests(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), var(), MakeNoOpClient(), MakeDownloadClient(), HttpClient()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, Validate(), InstagramCredentialsValidator, if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, if(), XPoster.Credentials, Validate()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, UploadAsync(), IBlobStorageService, DeleteAsync(), XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), XPoster.Models, Validate()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetSummaryAsync(), ITextToTextProvider, GetImagePromptAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), if(), XPoster.SenderPlugins, SendAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, GetFeedsAsync(), IFeedService

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, Apply(), ITagReplacementService

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, GetReplacements(), XPoster.Contracts

### Community 110 - "Entity (Community 110)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, GetFeedsAsync(), Exception()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Providers, GetCurrentTime()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), MaskUrlTelemetryProcessor(), Process()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, IOrchestratorFactory, Resolve()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), if(), CreateOrchestratorInstance()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Orchestrators, PostAsync()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 160 - "Entity (Community 160)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 165 - "Entity (Community 165)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

