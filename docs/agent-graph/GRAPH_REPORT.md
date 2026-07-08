# Graph Report - XPoster  (2026-07-08)

## Summary
- 1340 nodes · 2257 edges · 165 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `InMemoryContainerStateStoreTests` - 2 edges
2. `XPoster.Credentials` - 2 edges
3. `InstagramCredentialsValidator` - 2 edges
4. `XPoster.Tests.Integration` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `ITextToTextProvider` - 2 edges
7. `XPoster.SenderPlugins` - 2 edges
8. `XPoster.Orchestrators` - 2 edges
9. `XPoster.Credentials` - 2 edges
10. `IOrchestratorFactory` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes(), AzureFoundryUrlJson(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), AzureFoundryB64Json() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit(), OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, new(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_DownloadThrows_LogsError(), Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsDeepSeek(), PerplexityOptionsExtensionsTests, register(), SectionName_IsAzureFoundry(), OpenAiOptionsExtensionsTests, DeepSeekOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), return(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenBlobUploadCancelled_ReturnsFalse(), IgSender(), IgSenderTests (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityService(), XPoster.Tests.Services, PerplexityServiceTests, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageBytes_ReturnsTrue(), ValidPost(), XPoster.Tests.SenderPlugins (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), DeepSeekServiceTests, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), DeepSeekService() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildFactory(), foreach(), FakeHttpMessageHandler(), FeedServiceTests, FeedService(), BuildRssXml() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, HttpResponseMessage(), if(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), MetaPublishingService() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries() (+8 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, BlobStorageService(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), CreateSut(), BlobStorageServiceTests (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DefaultSlotProfileProviderTests, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), TryDeleteBlobAsync(), if(), PollPendingContainersAsync(), switch(), ProcessContainerAsync() (+6 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, catch(), var(), GetImagePromptAsync(), GetPromptForImage(), OpenAiService(), GetSummaryAsync() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), Validate_DefaultOptions_Succeeds(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), IgSender(), BuildSender(), IgSenderResilienceTests, PostWithoutImage(), XPoster.Tests.SenderPlugins (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, PerplexityService(), GetSummaryAsync(), BuildImagePromptPayload(), if(), GetImagePromptAsync(), BuildSummaryPayload() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), new() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests, ConfigurationTagReplacementProvider(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, if(), GetSummaryAsync(), var(), XPoster.Services, while(), GetChatCompletionsEndpoint() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, typeof(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_EmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), XSenderMissingBranchTests, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty() (+3 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, XPoster.Credentials, Validate(), catch(), resolve(), InvalidOperationException(), if() (+3 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, MetaPublishingService(), HttpRequestException(), GetApiVersion(), catch(), GetContainerStatusAsync(), if() (+2 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), NoOrchestratorTests (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), params(), BuildProviderWithHandler(), BuildSequenceHandler(), HttpResponseMessage(), XPoster.Tests.Integration (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_SkipsNullPost_ReturnsFalse(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsTrue_When_AllConditionsMet() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, CreateTimerInfo(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenUpdateStatusThrows_PropagatesException() (+1 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, ResolveAuthorUrn(), using(), SendAsync(), Exception(), catch(), InvalidOperationException() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), PostMissingBranchTests, XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, Message, ImageData, XPoster.Models, OpenAIImageResponse, OpenAIResponse

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, foreach(), if(), XPoster.Orchestrators, catch(), AcquireFeedContentAsync(), FeedOrchestrator()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 59 - "Entity (Community 59)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, BuildSummaryPayload(), AzureFoundryService(), GenerateImageAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, Dispose(), CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), IsEnabled()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, XPoster.Services, if(), UploadAsync(), BlobStorageService(), BlobUploadResult(), DeleteAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, XFunctionTests()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), catch(), GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 63 - "Entity (Community 63)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XFunctionMissingBranchTests(), XPoster.Tests

### Community 73 - "Entity (Community 73)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), catch(), if(), XFunction(), XPoster

### Community 71 - "Entity (Community 71)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractFalAiBytesAsync(), ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), XPoster.Services, ExtractAzureFoundryBytesAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), BuildImagePromptPayload(), catch(), if(), GetImageGenerationEndpoint(), var()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), ScheduledOrchestrationProfile(), GetProfiles(), DryRunSlotProfileProvider(), XPoster.Orchestrators

### Community 66 - "Entity (Community 66)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, XPoster.Tests.SenderPlugins, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), if(), SendAsync(), XPoster.SenderPlugins, catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), TagReplacementService(), XPoster.Services, if(), Apply()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), XPoster.Contracts

### Community 61 - "Entity (Community 61)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, GetPendingAsync(), InMemoryContainerStateStore, SaveAsync(), UpdateStatusAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), XPoster.SenderPlugins, DryRunSender(), if()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), BlobServiceClient(), DryRunSlotProfileProvider(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), XPoster.Credentials, InstagramCredentialsValidator, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models, if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSender(), InSenderTests()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetImagePromptAsync(), ITextToTextProvider, GetSummaryAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), UploadAsync(), XPoster.Contracts, IBlobStorageService

### Community 77 - "Entity (Community 77)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration

### Community 75 - "Entity (Community 75)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), XPoster.Tests.Services, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests

### Community 86 - "Entity (Community 86)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), var(), HttpClient(), MakeDownloadClient(), JsonResponse()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, XPoster.Orchestrators, Resolve(), foreach(), return()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), IOrchestratorFactory, XPoster.Contracts

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 102 - "Entity (Community 102)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, Validate(), ICredentialsStartupValidator

### Community 93 - "Entity (Community 93)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 97 - "Entity (Community 97)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), GetProfiles()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 126 - "Entity (Community 126)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 120 - "Entity (Community 120)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 116 - "Entity (Community 116)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Contracts, BlobUploadResult()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 113 - "Entity (Community 113)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 117 - "Entity (Community 117)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Contracts, PendingContainer()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 146 - "Entity (Community 146)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 136 - "Entity (Community 136)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 138 - "Entity (Community 138)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 141 - "Entity (Community 141)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 140 - "Entity (Community 140)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 147 - "Entity (Community 147)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 151 - "Entity (Community 151)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

