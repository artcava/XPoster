# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `ICryptoService` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `XPoster.Contracts` - 2 edges
4. `XPoster.Tests.Integration` - 2 edges
5. `ITagReplacementService` - 2 edges
6. `XPoster.Contracts` - 2 edges
7. `ITagReplacementProvider` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), AzureFoundryB64Json(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), FalAiJson() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), AiServiceHelperImageTests, new(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), PowerLawProfile(), FeedProfile(), NoOrchestrator_SupportedPlatforms_IsEmpty() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, DeepSeekOptionsExtensionsTests, FalAiOptionsExtensionsTests, new(), OpenAiOptionsExtensionsTests, SectionName_IsFalAi(), SectionName_IsPerplexity() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), ChatCompletionJson(), BuildService() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSenderTests(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), ValidPost(), XPoster.Tests.SenderPlugins (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, new(), SendAsync(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenOk_ReturnsPublishId(), MetaPublishingService(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, HttpResponseMessage(), if(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, GetPendingAsync_ReturnsOnlyPendingEntries(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException() (+8 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), GetProfiles_Should_HaveUniqueHours() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), TryDeleteBlobAsync(), if(), Run(), ProcessContainerAsync(), switch() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GenerateImageAsync(), catch(), var(), GetImagePromptAsync(), OpenAiService(), GetSummaryAsync() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models, Validate_MissingTextPlaceholder_Fails(), ValidOptions(), OpenAiOptionsValidatorTests, Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, BuildCreds(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), BuildSender(), InSenderMissingBranchTests(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, Uri(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithImage(), new() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), BuildImagePromptPayload(), if(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), GetImagePromptAsync() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetChatCompletionsEndpoint(), while(), if(), GetImagePromptAsync(), XPoster.Services, GetSummaryAsync() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), typeof(), ScheduledOrchestrationProfileTests, XPoster.Tests.Abstraction, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), CreateSut(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPoster.Tests (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), BuildService() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, XPoster.Tests.Orchestrators, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), foreach() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender(), XPoster.Tests.SenderPlugins (+3 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), BuildSender(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, InvalidOperationException(), if(), foreach(), CredentialsStartupValidator(), catch(), ValidateOptions() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Build(), XPoster.Tests.Orchestrators (+2 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), XSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, XPoster.Services, MetaPublishingService(), if(), GetApiVersion(), GetContainerStatusAsync(), catch() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), CryptoServiceTests (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), var(), XPoster.Tests.Integration, BuildDelayedHandler(), BuildSequenceHandler(), params() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Contracts (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), using(), generatePayLoad(), ResolveAuthorUrn(), SendAsync(), XPoster.SenderPlugins, InvalidOperationException() (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), CreateTimerInfo() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), XPoster.Tests.Models

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), IsEnabled(), XPoster.Tests.Integration, Dispose(), CaptureLogger(), CaptureLoggerProvider()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), foreach(), catch(), AcquireFeedContentAsync(), FeedOrchestrator(), XPoster.Orchestrators

### Community 56 - "Entity (Community 56)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), BlobStorageService(), if(), DeleteAsync(), BlobUploadResult(), XPoster.Services

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, OpenAIImageResponse, Message, Choice, ImageData

### Community 55 - "Entity (Community 55)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, GetImagePromptAsync(), GenerateImageAsync(), GetChatCompletionsEndpoint(), AzureFoundryService(), BuildSummaryPayload(), GetSummaryAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), GetPendingAsync(), IContainerStateStore, UpdateStatusAsync(), XPoster.Contracts

### Community 70 - "Entity (Community 70)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_Rethrow_When_Factory_Throws()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), XPoster.Services, ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), ParseImageResponseAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), XPoster.Tests.Orchestrators

### Community 62 - "Entity (Community 62)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), if(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), catch(), var()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), foreach(), TagReplacementService(), XPoster.Services, Apply()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, catch(), IgSender(), if(), XPoster.SenderPlugins, SendAsync()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), typeof(), DryRunSlotProfileProvider(), GetProfiles()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), GenerateImageAsync(), FalAiImageService(), catch(), XPoster.Services

### Community 67 - "Entity (Community 67)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, UpdateStatusAsync(), XPoster.Services, SaveAsync(), GetPendingAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, XPoster.Tests.SenderPlugins, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildCreds(), Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), if(), catch(), XFunction(), XPoster

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), Validate(), XPoster.Models, foreach()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), Uri(), DryRunSlotProfileProvider(), BlobServiceClient()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), PublishContainerAsync(), XPoster.Contracts, IMetaPublishingService

### Community 74 - "Entity (Community 74)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, IBlobStorageService, DeleteAsync(), UploadAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), MakeNoOpClient(), var(), HttpClient(), JsonResponse()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, DryRunSender(), SendAsync(), if()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSenderTests(), InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, ITextToTextProvider, GetImagePromptAsync(), GetSummaryAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Services

### Community 95 - "Entity (Community 95)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, Apply(), ITagReplacementService

### Community 97 - "Entity (Community 97)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), XPoster.Contracts, ITextToImageProvider

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), GetProfiles()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Contracts

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 105 - "Entity (Community 105)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, GetFeedsAsync(), Exception()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Contracts

### Community 125 - "Entity (Community 125)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Contracts

### Community 116 - "Entity (Community 116)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 113 - "Entity (Community 113)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 114 - "Entity (Community 114)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 117 - "Entity (Community 117)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 144 - "Entity (Community 144)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 141 - "Entity (Community 141)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 143 - "Entity (Community 143)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 139 - "Entity (Community 139)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 135 - "Entity (Community 135)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

