# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Orchestrators` - 2 edges
2. `IFeedUrlProvider` - 2 edges
3. `XPoster.Contracts` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `IOrchestrator` - 2 edges
7. `ITimeProvider` - 2 edges
8. `XPoster.Orchestrators` - 2 edges
9. `XPoster.Tests.Integration` - 2 edges
10. `XPoster.Tests.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeResponse(), MakeHttpClientThatThrows(), AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), AzureFoundryUrlJson() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_SharesImageBytes_AcrossSenders(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, MakeHandlerMock(), OpenAiService(), XPoster.Tests.Services, MakeHandler(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_MalformedJson_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, CreateFactory(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactoryWithProfiles(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), XPoster.Tests.Orchestrators (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, new(), ConfigurationBuilder(), FalAiOptionsExtensionsTests, DeepSeekOptionsExtensionsTests, AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), return() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), foreach(), BuildService() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSender_ImplementsISender(), BuildSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), ValidPost(), XPoster.Tests.SenderPlugins (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, ChatCompletionJson(), DeepSeekService(), DeepSeekServiceTests, GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), XPoster.Tests.Services (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, XPoster.Tests.Services, CreateSut(), PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), HttpResponseMessage(), if() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), GetPendingAsync_ReturnsOnlyPendingEntries(), UpdateStatusAsync_CanMoveEntryBackToPending(), XPoster.Tests.Services, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), XPoster.Tests.Services, UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_SasUriExpiry_IsApproximately30Minutes() (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, XPoster.Tests.Orchestrators, GetProfiles_Should_HaveUniqueHours(), GetProfiles_Should_NotContainDryRunSlot(), PowerLawSlot_Should_HaveNullTextAndImageProvider(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_ReturnWellFormedProfiles() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIImageResponse_CanBeCreated_WithData(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleTerminalFailureAsync(), foreach(), catch(), HandleFinishedAsync(), TryDeleteBlobAsync(), if() (+6 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, ValidOptions(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), BuildSender(), InSenderMissingBranchTests(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummaryAsync(), GetPromptForImage(), GetImagePromptAsync(), GenerateImageAsync(), GetSummary(), catch() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ValidOptions_Succeeds(), Validate_MissingApiKey_Fails() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), ConfigurationTagReplacementProvider(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), XPoster.Tests.Abstraction, typeof() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetImagePromptAsync(), BuildImagePromptPayload(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), if(), PerplexityService() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), new(), PowerLawOrchestratorTests(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, BuildSummaryPayload(), BuildImagePromptPayload(), GetChatCompletionsEndpoint(), while(), if(), GetImagePromptAsync() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender(), InSender() (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, ValidateOptions(), catch(), CredentialsStartupValidator(), Validate(), InvalidOperationException(), resolve() (+3 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), BuildSender(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, FalAiImageService(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), ConfigurationFeedUrlProvider() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), Build(), Name_IsNoOrchestrator(), NoOrchestratorTests, SupportedPlatforms_IsEmpty() (+2 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, PublishContainerAsync(), MetaPublishingService(), XPoster.Services, if(), GetContainerStatusAsync(), catch() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), HttpResponseMessage(), params(), var(), XPoster.Tests.Integration, BuildSequenceHandler() (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), XPoster.SenderPlugins, ResolveAuthorUrn(), InvalidOperationException(), using(), generatePayLoad(), Exception() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenCancelled_StopsGracefully(), CreateTimerInfo(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Contracts (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), BuildSummaryPayload(), XPoster.Services, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), UploadAsync(), if(), BlobUploadResult(), DeleteAsync(), XPoster.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, ImageData, Message, OpenAIResponse, OpenAIImageResponse, XPoster.Models

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), FeedOrchestrator(), XPoster.Orchestrators, foreach(), if(), catch()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CreateLogger(), Dispose(), IsEnabled(), CaptureLogger(), CaptureLoggerProvider()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), InSender_ImplementsISender(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, catch(), Run(), if(), XFunction()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), InMemoryContainerStateStore, GetPendingAsync(), UpdateStatusAsync(), XPoster.Services

### Community 66 - "Entity (Community 66)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), GenerateImageAsync(), FalAiImageService(), catch(), XPoster.Services

### Community 67 - "Entity (Community 67)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync(), LogAndReturnEmpty(), XPoster.Services, ExtractOpenAiBytes()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests, XFunctionMissingBranchTests()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, catch(), if(), IgSender(), SendAsync()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, if(), Apply(), TagReplacementService(), foreach()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), XPoster.Tests.Orchestrators

### Community 64 - "Entity (Community 64)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles(), XPoster.Orchestrators

### Community 63 - "Entity (Community 63)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), var(), while()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, UpdateStatusAsync(), XPoster.Contracts, SaveAsync(), GetPendingAsync()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService, PublishContainerAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach(), if()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSenderTests(), InSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), XPoster.SenderPlugins, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, DeleteAsync(), UploadAsync(), IBlobStorageService

### Community 77 - "Entity (Community 77)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DryRunSlotProfileProvider(), if(), Uri(), BlobServiceClient()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, ITextToTextProvider, GetImagePromptAsync(), GetSummaryAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), HttpClient(), JsonResponse(), MakeNoOpClient(), MakeDownloadClient()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), GetProfiles()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 97 - "Entity (Community 97)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 98 - "Entity (Community 98)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Orchestrators

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, GetReplacements(), XPoster.Contracts

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Services, GetCurrentTime()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), CreateValidJpeg(), XPoster.Tests.Helpers

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), GetFeedsAsync(), Exception(), XPoster.Services

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Contracts, BlobUploadResult()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 122 - "Entity (Community 122)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 124 - "Entity (Community 124)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Contracts, PendingContainer()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 117 - "Entity (Community 117)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 135 - "Entity (Community 135)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 141 - "Entity (Community 141)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 144 - "Entity (Community 144)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 143 - "Entity (Community 143)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

