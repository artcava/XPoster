# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 181 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Integration` - 2 edges
2. `XPoster.Tests.Integration` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `XPoster.SenderPlugins` - 2 edges
6. `ITextToTextProvider` - 2 edges
7. `InstagramCredentialsValidator` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Providers` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), AzureFoundryB64Json(), MakeResponse(), ParseImageResponseAsync_WhenMalformedJson_LogsError(), ParseImageResponseAsync_WhenMalformedJson_ReturnsEmptyArray(), MakeHttpClientThatThrows() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, new(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), FeedProfile(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactory(), CreateFactoryWithProfiles() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_RegistersValidator(), AddAzureFoundryOptions_RegistersValidator(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_RegistersValidator(), AddFalAiOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, Platform_ReturnsFacebook(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), FbSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLength_Returns250(), Constructor_InitializesCorrectly() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), MakeHandlerMock(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), XPoster.Tests.Services, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), IgSenderImageFlowTests (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), XPoster.Tests.Services (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), HttpResponseMessage(), if(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), MetaPublishingService(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), XPoster.Tests.Services, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), GetProfiles_Should_HaveUniqueHours(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), DryRunSender_ImplementsISender(), new(), SendAsync_WhenProbeKeyPresent_ReturnsTrue() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), BlobStorageServiceTests, CreateSut(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageService(), UploadAsync_WhenStorageThrows_PropagatesException() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), new(), PostWithImage(), PostWithoutImage(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, ValidOptions(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), ImageData_CanBeCreated_WithUrl(), Post_CanHold_ImageBytes(), ModelsTests (+6 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), PollPendingContainersAsync(), XPoster, switch(), TryDeleteBlobAsync(), ProcessContainerAsync() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildCreds(), InSender_ImplementsISender() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, ValidOptions(), Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), XPoster.Tests.Models, Validate_MissingTextPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, OpenAiService(), var(), XPoster.Services, while(), if(), catch() (+5 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, InSender(), Constructor_InitializesCorrectly(), Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, new(), CreateOrchestrator(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), XPoster.Tests.Models, typeof(), ScheduledOrchestrationProfileTests, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, DeepSeekService(), BuildSummaryPayload(), BuildImagePromptPayload(), GetImagePromptAsync(), if(), GetSummaryAsync() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetSummaryAsync(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), BuildImagePromptPayload(), GetImagePromptAsync(), PerplexityService() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, XPoster.Tests.Services, BuildService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), Platform_ReturnsDryRun(), DryRunSenderTests(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, foreach(), catch(), CredentialsStartupValidator(), if(), XPoster.Credentials, InvalidOperationException() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, BuildCreds(), Platform_ReturnsInstagram(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins, BuildSender(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), new() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), XPoster.Tests.SenderPlugins, InSenderResilienceTests, InSender() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, FalAiImageService(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, BuildSender(), IgSenderSendAsyncTests, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, XSenderResilienceTests, XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), BuildSender(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, SendIt_Set_ThrowsNotImplementedException(), NoOrchestratorTests, Name_IsNoOrchestrator() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, HandleResponseAsync(), catch(), FbSender(), PublishPhotoAsync(), PublishTextOnlyAsync(), XPoster.SenderPlugins (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), FbSenderSendAsyncTests, BuildFactory(), BuildCreds(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, catch(), XPoster.Services, MetaPublishingService(), GetApiVersion(), HttpRequestException(), if() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeedTests, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, FbSenderResilienceTests, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), XPoster.Tests.SenderPlugins (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), BuildDelayedHandler(), HttpResponseMessage(), var(), XPoster.Tests.Integration (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), ResolveAuthorUrn(), InvalidOperationException(), generatePayLoad(), Exception(), catch(), using() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, FbSenderImageFlowTests, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), HttpRequestException(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), BuildFactory() (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Orchestrators, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, HttpClientExtensionsTests, AddHttpClients_ReturnsSameServiceCollection(), foreach(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, Choice, AIResponse, OpenAIImageResponse, XPoster.Models, Message

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), if(), DeleteAsync(), BlobUploadResult(), BlobStorageService(), XPoster.Services

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), Dispose(), CreateLogger(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), foreach(), catch(), AcquireFeedContentAsync(), FeedOrchestrator(), XPoster.Orchestrators

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), AzureFoundryService(), GetImagePromptAsync(), XPoster.Services, GetSummaryAsync(), GenerateImageAsync(), GetChatCompletionsEndpoint()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostTests, Post_CanSetAndGetAllProperties()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, GetPendingAsync(), XPoster.Contracts, SaveAsync(), UpdateStatusAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), HttpResponseMessage(), CreateValidJpegBytes()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, var(), while(), if(), catch(), GetImageGenerationEndpoint(), BuildImagePromptPayload()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), XFunction(), XPoster, catch(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), if(), XPoster.Services, Apply(), foreach()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), ParseImageResponseAsync(), XPoster.Services

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), catch(), if(), SendAsync(), XPoster.SenderPlugins

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, if(), DefaultAzureCredential(), BlobServiceClient(), DryRunSlotProfileProvider(), Uri()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Providers, OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), new()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, GetPendingAsync(), UpdateStatusAsync(), XPoster.Services, InMemoryContainerStateStore, SaveAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), GetProfiles(), ScheduledOrchestrationProfile(), typeof(), XPoster.Providers

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetSummaryAsync(), ITextToTextProvider, GetImagePromptAsync()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), InstagramCredentialsValidator, XPoster.Credentials, if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Providers

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, UploadAsync(), DeleteAsync(), IBlobStorageService

### Community 87 - "Entity (Community 87)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), IMetaPublishingService, XPoster.Contracts, PublishContainerAsync()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), HttpClient(), JsonResponse(), var()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, FacebookCredentialsValidator, if(), Validate()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), XPoster.Models, Validate()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), MaskUrlTelemetryProcessor(), if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), Resolve(), XPoster.Orchestrators, return()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Providers, GetProfiles()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Providers, ConfigurationFeedUrlProvider()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Providers

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 126 - "Entity (Community 126)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Orchestrators, BaseOrchestrator()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 162 - "Entity (Community 162)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 152 - "Entity (Community 152)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 158 - "Entity (Community 158)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 154 - "Entity (Community 154)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 155 - "Entity (Community 155)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 163 - "Entity (Community 163)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 166 - "Entity (Community 166)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

