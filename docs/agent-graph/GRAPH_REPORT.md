# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Extensions` - 2 edges
2. `XPoster.SenderPlugins` - 2 edges
3. `XPoster.Contracts` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Tests.Services` - 2 edges
8. `IMetaPublishingService` - 2 edges
9. `XPoster.Contracts` - 2 edges
10. `XPoster.Orchestrators` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, XPoster.Tests.Services, var(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray(), MakeHttpClient() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_SharesImageBytes_AcrossSenders(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_UnsupportedProvider_LogsError(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_Returns429_LogsWarning(), Parse_Returns429_ReturnsEmpty(), static(), Parse_UnsupportedProvider_ReturnsEmpty(), return() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsDeepSeek(), PerplexityOptionsExtensionsTests, SectionName_IsAzureFoundry(), register(), BuildProvider(), AddPerplexityOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), Uri(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), BuildSender() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), PerplexityServiceTests, XPoster.Tests.Services, GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSender_ImplementsISender(), BuildSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), ValidPost(), XPoster.Tests.SenderPlugins (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), DeepSeekService(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekServiceTests (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), XPoster.Tests.Services, FeedServiceTests, BuildService(), BuildRssXml(), FakeHttpMessageHandler() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, AzureFoundryService(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), SaveAsync_WithValidInputs_StoresPendingEntry() (+8 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobExists_DeletesSuccessfully(), BlobStorageService(), CreateSut(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageServiceTests (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, PowerLawSlot_Should_HaveNullTextAndImageProvider(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), GetProfiles_Should_HaveUniqueHours(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_ReturnWellFormedProfiles(), GetProfiles_Should_NotContainDryRunSlot() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPoster, PollPendingContainersAsync(), switch(), Run(), ProcessContainerAsync(), TryDeleteBlobAsync() (+6 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIResponse_CanBeCreated_WithChoices(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), XPoster.Tests.Services (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, BuildSender(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), IgSender(), IgSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummaryAsync(), GetSummary(), GenerateImageAsync(), GetPromptForImage(), GetImagePromptAsync(), catch() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhitespaceContent_ReturnsFalse() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingTextPlaceholder_Fails(), Validate_DefaultOptions_Succeeds(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), new(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), BuildImagePromptPayload(), BuildSummaryPayload(), GetImagePromptAsync(), GetSummaryAsync(), GetChatCompletionsEndpoint() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), foreach(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, CreateSut(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenNoPendingContainers_DoesNothing() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), typeof(), XPoster.Tests.Abstraction, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), DeepSeekService(), BuildImagePromptPayload(), var() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), ConfigurationFeedUrlProvider() (+3 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), MessageMaxLenght_Returns250(), BuildSender(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, XPoster.Credentials, Validate(), if(), resolve(), CredentialsStartupValidator(), catch() (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, InSenderResilienceTests, InSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, if(), GetContainerStatusAsync(), catch(), GetApiVersion(), HttpRequestException(), PublishContainerAsync() (+2 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XSenderTests() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, SupportedPlatforms_IsEmpty(), SendIt_IsAlwaysFalse(), NoOrchestratorTests, Name_IsNoOrchestrator(), Build() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptionsTests (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Contracts, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), Exception(), InvalidOperationException(), using(), SendAsync(), XPoster.SenderPlugins, generatePayLoad() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), ValidOptions() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), PendingContainer(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), CreateTimerInfo(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), var(), XPoster.Tests.Integration, BuildDelayedHandler(), BuildSequenceHandler(), params() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), BlobUploadResult(), DeleteAsync(), UploadAsync(), if(), XPoster.Services

### Community 54 - "Entity (Community 54)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, PostMissingBranchTests, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), GenerateImageAsync(), AzureFoundryService(), GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, GetChatCompletionsEndpoint()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), TestOrchestrator()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, Message, OpenAIImageResponse, ImageData, Choice

### Community 55 - "Entity (Community 55)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), if(), foreach(), catch(), FeedOrchestrator(), XPoster.Orchestrators

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), foreach(), Apply(), TagReplacementService(), XPoster.Services

### Community 66 - "Entity (Community 66)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, XPoster.Tests.SenderPlugins, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), GetProfiles(), DryRunSlotProfileProvider(), XPoster.Orchestrators

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), XPoster.Tests.Orchestrators, new()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), IContainerStateStore, UpdateStatusAsync(), GetPendingAsync(), XPoster.Contracts

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), InMemoryContainerStateStore, XPoster.Services, SaveAsync(), GetPendingAsync()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), if(), catch(), XPoster, XFunction()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, catch(), if(), IgSender(), SendAsync()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), var(), BuildImagePromptPayload(), GetImageGenerationEndpoint(), catch(), if()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests, XFunctionMissingBranchTests()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync(), LogAndReturnEmpty(), XPoster.Services, ExtractOpenAiBytes()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, if(), FalAiImageService(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSenderTests(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), XPoster.SenderPlugins, if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetImagePromptAsync(), GetSummaryAsync(), ITextToTextProvider

### Community 78 - "Entity (Community 78)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), if(), BlobServiceClient(), DryRunSlotProfileProvider()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), HttpClient(), JsonResponse(), MakeNoOpClient(), MakeDownloadClient()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, DeleteAsync(), UploadAsync(), IBlobStorageService

### Community 77 - "Entity (Community 77)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, Validate(), XPoster.Credentials, if()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), Validate(), if(), XPoster.Models

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), XPoster.Orchestrators, return()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Orchestrators, GetProfiles()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, XPoster.Contracts, GenerateImageAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 95 - "Entity (Community 95)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 96 - "Entity (Community 96)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), GetFeedsAsync(), XPoster.Services

### Community 97 - "Entity (Community 97)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Orchestrators

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Contracts

### Community 118 - "Entity (Community 118)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 117 - "Entity (Community 117)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Contracts, PendingContainer()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 120 - "Entity (Community 120)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 124 - "Entity (Community 124)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 135 - "Entity (Community 135)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 147 - "Entity (Community 147)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 146 - "Entity (Community 146)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 143 - "Entity (Community 143)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 142 - "Entity (Community 142)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 139 - "Entity (Community 139)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

