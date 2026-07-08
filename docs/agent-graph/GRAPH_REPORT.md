# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `ITextToTextProvider` - 2 edges
3. `XPoster.Tests.Integration` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `XPoster.Tests.Integration` - 2 edges
6. `InstagramCredentialsValidator` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `IFeedUrlProvider` - 2 edges
9. `XPoster.Contracts` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_UnsupportedProvider_LogsError(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), AzureFoundryUrlJson() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), ChatCompletionJson(), BuildService(), MakeHandler(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_Returns429_ReturnsEmpty(), Parse_Returns429_LogsWarning(), Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactoryWithProfiles() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), BuildConfig(), AddPerplexityOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), BuildSender(), Constructor_InitializesCorrectly(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), IgSender(), MessageMaxLenght_Returns2200() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), PerplexityServiceTests, XPoster.Tests.Services, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSender_ImplementsISender(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), ValidPost(), XPoster.Tests.SenderPlugins (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), ChatCompletionJson() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), XPoster.Tests.Services, new(), FeedServiceTests, BuildRssXml(), FakeHttpMessageHandler() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, PublishContainerAsync_WhenOk_ReturnsPublishId(), MetaPublishingService(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), XPoster.Tests.Services, UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException() (+8 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured() (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_WhenStorageThrows_PropagatesException(), UploadAsync_SasUriExpiry_IsApproximately30Minutes() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleFinishedAsync(), foreach(), catch(), XPoster, PollPendingContainersAsync(), switch() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIImageResponse_CanBeCreated_WithData(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSender(), BuildSender(), Uri(), new(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithImage() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_DefaultOptions_Succeeds() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), InSenderMissingBranchTests(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), MessageMaxLenght_Returns2800(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingModelId_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetImagePromptAsync(), catch(), GenerateImageAsync(), XPoster.Services, GetSummaryAsync(), while() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, typeof(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), foreach(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, while(), var(), BuildImagePromptPayload(), if(), BuildSummaryPayload() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), FalAiImageServiceTests, BuildService(), XPoster.Tests.Services, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPoster.Tests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPosterContainerPollingFunctionTests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), CreateSut() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), new(), XPoster.Tests.Orchestrators, OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), PowerLawOrchestratorTests(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), BuildImagePromptPayload(), if(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), GetImagePromptAsync() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_NullPost_ReturnsFalse(), BuildSender() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, catch(), CredentialsStartupValidator(), foreach(), InvalidOperationException(), if(), XPoster.Credentials (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), ConfigurationFeedUrlProvider(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Build(), Name_IsNoOrchestrator(), SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, PublishContainerAsync(), MetaPublishingService(), HttpRequestException(), catch(), if(), GetContainerStatusAsync() (+2 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), XSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+2 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), InvalidOperationException(), generatePayLoad(), using(), SendAsync(), ResolveAuthorUrn(), XPoster.SenderPlugins (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), params(), BuildProviderWithHandler(), BuildSequenceHandler(), HttpResponseMessage(), XPoster.Tests.Integration (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), ValidOptions() (+1 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo(), PendingContainer(), RunAsync_WhenCancelled_StopsGracefully() (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Contracts, PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider(), CaptureLogger(), CreateLogger()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), BuildSummaryPayload(), AzureFoundryService(), GetImagePromptAsync(), GenerateImageAsync(), GetChatCompletionsEndpoint(), XPoster.Services

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), XPoster.Tests.Models, PostMissingBranchTests

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, OpenAIImageResponse, XPoster.Models, OpenAIResponse, Choice, ImageData

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, XPoster.Services, UploadAsync(), if(), BlobStorageService(), BlobUploadResult(), DeleteAsync()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, XPoster.Orchestrators, foreach(), FeedOrchestrator(), AcquireFeedContentAsync(), catch(), if()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, SaveAsync(), GetPendingAsync(), IContainerStateStore, XPoster.Contracts, UpdateStatusAsync()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Orchestrators, DryRunSlotProfileProvider(), GetProfiles(), typeof()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractFalAiBytesAsync(), ParseImageResponseAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty(), XPoster.Services, ExtractAzureFoundryBytesAsync()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), InMemoryContainerStateStore, UpdateStatusAsync(), GetPendingAsync(), XPoster.Services

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, if(), XFunction(), XPoster, catch(), Run()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), while(), var()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, if(), foreach(), Apply(), TagReplacementService()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), if(), SendAsync(), XPoster.SenderPlugins, catch()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, XFunctionTests()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, if(), FalAiImageService(), catch()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins

### Community 81 - "Entity (Community 81)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), var(), MakeNoOpClient(), HttpClient(), JsonResponse()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetImagePromptAsync(), GetSummaryAsync(), ITextToTextProvider

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), Uri(), DryRunSlotProfileProvider(), BlobServiceClient()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), XPoster.SenderPlugins, if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), InstagramCredentialsValidator

### Community 82 - "Entity (Community 82)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts, PublishContainerAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), XPoster.Models, if(), foreach()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), DeleteAsync(), IBlobStorageService

### Community 75 - "Entity (Community 75)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSenderTests()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), GetFeedsAsync(), XPoster.Services, Exception()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 93 - "Entity (Community 93)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, Apply(), XPoster.Contracts

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Orchestrators

### Community 97 - "Entity (Community 97)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, XPoster.Orchestrators, return(), Resolve(), foreach()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Contracts, PendingContainer()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 117 - "Entity (Community 117)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 126 - "Entity (Community 126)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 120 - "Entity (Community 120)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 122 - "Entity (Community 122)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Contracts

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, PostAsync(), BaseOrchestrator()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 141 - "Entity (Community 141)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 144 - "Entity (Community 144)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 143 - "Entity (Community 143)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

