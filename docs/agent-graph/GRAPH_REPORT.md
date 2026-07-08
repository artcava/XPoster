# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `ITextToImageProvider` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `XPoster.Contracts` - 2 edges
4. `ICryptoService` - 2 edges
5. `XPoster.Orchestrators` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Tests.Models` - 2 edges
8. `Choice` - 2 edges
9. `OpenAIResponse` - 2 edges
10. `OpenAIImageResponse` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), OpenAiB64Json(), ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), MakeHandler(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags(), new(), OrchestrateAsync_AppliesHashtagsIndependently_PerSender(), CreateMultiSenderOrchestrator(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), AiServiceHelperImageTests, new(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_Returns429_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), PowerLawProfile(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildConfig(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, SectionName_IsAzureFoundry(), OptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), CreateMalformedPngBytes(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, ValidPost(), XPoster.Tests.SenderPlugins, DryRunSenderTests(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, AzureFoundryServiceTests, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), BuildFactory() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), ChatCompletionJson(), AzureFoundryService() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithValidInputs_StoresPendingEntry(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException() (+8 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, XPoster.Tests.Orchestrators, GetProfiles_Should_HaveUniqueHours(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_ReturnWellFormedProfiles(), GetProfiles_Should_NotContainDryRunSlot(), PowerLawSlot_Should_HaveNullTextAndImageProvider() (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, if(), TryDeleteBlobAsync(), switch(), Run(), ProcessContainerAsync(), PollPendingContainersAsync() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), MessageMaxLenght_Returns2800(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), Uri(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, if(), GetSummaryAsync(), GetImagePromptAsync(), GetSummary(), catch(), GetPromptForImage() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingModelId_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), typeof(), XPoster.Tests.Abstraction, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), CreateSut(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Orchestrators, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), foreach() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, XPoster.Tests.Services, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, XPoster.Services, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), PerplexityService(), BuildSummaryPayload() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, if(), GetSummaryAsync(), var(), XPoster.Services, while(), DeepSeekService() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), ConfigurationFeedUrlProviderTests (+3 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), BuildSender() (+3 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, ValidPost(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, ValidateOptions(), catch(), CredentialsStartupValidator(), Validate(), InvalidOperationException(), resolve() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), catch(), GetContainerStatusAsync(), GetApiVersion(), PublishContainerAsync(), XPoster.Services (+2 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests, Build(), OrchestrateAsync_ReturnsEmptyList() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), CreateTimerInfo(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), PendingContainer(), RunAsync_WhenCancelled_StopsGracefully() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.22
Nodes (9): InSender.cs, ResolveAuthorUrn(), Exception(), catch(), generatePayLoad(), InvalidOperationException(), using(), SendAsync() (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), var(), XPoster.Tests.Integration, BuildDelayedHandler(), BuildSequenceHandler(), params() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), CryptoServiceTests, MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), Dispose(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider(), CreateLogger()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), ValidOptions()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, OpenAIResponse, OpenAIImageResponse, Message, ImageData, XPoster.Models

### Community 55 - "Entity (Community 55)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostMissingBranchTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), BlobStorageService(), if(), DeleteAsync(), BlobUploadResult(), XPoster.Services

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), XPoster.Services, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync(), AzureFoundryService()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, XPoster.Orchestrators, foreach(), FeedOrchestrator(), AcquireFeedContentAsync(), catch(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractFalAiBytesAsync(), ParseImageResponseAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty(), XPoster.Services, ExtractAzureFoundryBytesAsync()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XFunctionMissingBranchTests(), XPoster.Tests

### Community 66 - "Entity (Community 66)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, XPoster.Contracts, SaveAsync(), IContainerStateStore, GetPendingAsync(), UpdateStatusAsync()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, BuildImagePromptPayload(), if(), GetImageGenerationEndpoint(), var(), while(), catch()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), foreach(), Apply(), XPoster.Services, TagReplacementService()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles(), XPoster.Orchestrators

### Community 63 - "Entity (Community 63)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), if(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 61 - "Entity (Community 61)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Orchestrators

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), InMemoryContainerStateStore, XPoster.Services, SaveAsync(), GetPendingAsync()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, XFunction(), if(), catch(), Run()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, FalAiImageService(), catch(), if()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, InSender_ImplementsISender(), Constructor_InitializesCorrectly(), BuildCreds()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSenderTests(), InSender(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), MakeNoOpClient(), var(), HttpClient(), JsonResponse()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GetSummaryAsync(), GetImagePromptAsync()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services

### Community 78 - "Entity (Community 78)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 76 - "Entity (Community 76)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), XPoster.SenderPlugins, SendAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, Validate(), if(), XPoster.Credentials

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), DeleteAsync(), IBlobStorageService

### Community 82 - "Entity (Community 82)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), BlobServiceClient(), if(), DryRunSlotProfileProvider()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), if(), XPoster.Credentials

### Community 95 - "Entity (Community 95)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), ITextToImageProvider, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Orchestrators

### Community 97 - "Entity (Community 97)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), XPoster.Orchestrators, return()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, Validate(), XPoster.Contracts

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Contracts

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators, ScheduledOrchestrationProfile()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Contracts, BlobUploadResult()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 122 - "Entity (Community 122)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 123 - "Entity (Community 123)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 125 - "Entity (Community 125)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), FeedOrchestratorFeedUrlProviderTests()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Contracts

### Community 116 - "Entity (Community 116)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 115 - "Entity (Community 115)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 113 - "Entity (Community 113)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 117 - "Entity (Community 117)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 135 - "Entity (Community 135)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 146 - "Entity (Community 146)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 144 - "Entity (Community 144)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 143 - "Entity (Community 143)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 147 - "Entity (Community 147)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

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
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

