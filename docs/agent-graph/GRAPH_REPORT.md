# Graph Report - XPoster  (2026-07-09)

## Summary
- 1457 nodes · 2470 edges · 176 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Credentials` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Tests.Services` - 2 edges
9. `XPoster.Credentials` - 2 edges
10. `InstagramCredentialsValidator` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, MakeResponse(), MakeHttpClientThatThrows(), OpenAiB64Json(), new(), FalAiJson(), ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): IgSenderTests.cs, IgSenderTests.cs, NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), MessageMaxLenght_Returns2200(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiServiceTests, GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), ChatCompletionJson() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot(), XPoster.Tests.Orchestrators, OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace() (+26 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_MalformedJson_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), XPoster.Tests.Orchestrators, typeof(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveXSender_ForPowerLawOrchestrator() (+22 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, XPoster.Tests.Models, AddFalAiOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildFactory(), BuildCreds(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), SendAsync_WhenHttpClientThrows_ReturnsFalse() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, MakeHandlerMock(), MakeSequentialHandlerMock(), PerplexityService(), PerplexityServiceTests, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse() (+15 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, XSenderTests(), XPoster.Tests.SenderPlugins, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse(), BuildSender() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, BuildService(), AzureFoundryServiceTests, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+11 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests, BuildRssXml(), FakeHttpMessageHandler(), FeedService(), BuildService(), SendAsync() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), if(), HttpResponseMessage(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenRateLimited_Throws(), MetaPublishingService(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenOk_ReturnsPublishId(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_CanMoveEntryBackToPending(), SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending() (+8 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), GetProfiles_Should_ReturnWellFormedProfiles(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), GetProfiles_Should_NotContainDryRunSlot() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenTelemetryIsNotDependency_DoesNothing(), MaskUrlTelemetryInitializerTests, XPoster.Tests.Services, Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_ReturnsFalse(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), DryRunSender(), SendAsync_WhenKeyMissing_ReturnsFalse(), new(), DryRunSender_ImplementsISender(), ConfigurationBuilder() (+7 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), XPoster.Tests.Services, UploadAsync_WhenStorageThrows_PropagatesException(), BlobStorageService(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), ValidOptions(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Choice_CanBeCreated_WithMessage(), Post_Firm_ContainsExpectedHashtags(), Message_CanBeCreated_WithContent(), Post_CanHold_ImageBytes() (+6 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, switch(), XPosterContainerPollingFunction(), TryDeleteBlobAsync(), XPoster, PollPendingContainersAsync(), if() (+6 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender(), IgSender(), PostWithoutImage(), new(), PostWithImage() (+5 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), OpenAiOptionsValidatorTests (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, while(), XPoster.Services, var(), if(), GetSummary(), GetPromptForImage() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, XPoster.Tests.Services, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetSummaryAsync(), GetChatCompletionsEndpoint(), BuildImagePromptPayload(), if(), BuildSummaryPayload(), GetImagePromptAsync() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), ScheduledOrchestrationProfileTests, typeof(), XPoster.Tests.Abstraction (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetImagePromptAsync(), BuildSummaryPayload(), DeepSeekService(), BuildImagePromptPayload(), GetChatCompletionsEndpoint(), if() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests, ConfigurationTagReplacementProvider(), foreach(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), XPoster.Tests.Orchestrators (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, InSenderTests(), InSender(), Constructor_InitializesCorrectly(), Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenProbeKeyMissing_LogsError(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), MessageMaxLenght_ReturnsIntMaxValue() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, MakeHandlerMock(), FalAiImageService(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, CredentialsStartupValidator(), XPoster.Credentials, Validate(), foreach(), InvalidOperationException(), resolve() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, ValidPost(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetContainerStatusAsync(), GetApiVersion(), catch(), if(), HttpRequestException(), XPoster.Services (+2 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, NoOrchestratorTests, SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), SendIt_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, SendAsync(), PublishPhotoAsync(), catch(), if(), FbSender() (+2 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), XPoster.Tests.SenderPlugins, FbSenderSendAsyncTests, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, FbSenderImageFlowTests, BuildCreds(), BuildFactory(), InvalidImageBytes(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, BuildDelayedHandler(), HttpResponseMessage(), params(), var(), BuildProviderWithHandler() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), HttpResponseMessage(), FbSenderResilienceTests (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.22
Nodes (9): InSender.cs, generatePayLoad(), ResolveAuthorUrn(), SendAsync(), using(), XPoster.SenderPlugins, InvalidOperationException(), catch() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeedMissingBranchTests, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeed_CanSetPublishDate() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), foreach(), FeedOrchestrator(), XPoster.Orchestrators, if(), catch()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, UploadAsync(), BlobUploadResult(), BlobStorageService(), DeleteAsync(), XPoster.Services, if()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), BaseOrchestratorTests()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), Dispose(), CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), XPoster.Tests.Integration

### Community 59 - "Entity (Community 59)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, OpenAIImageResponse, XPoster.Models, OpenAIResponse, Message

### Community 58 - "Entity (Community 58)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostMissingBranchTests, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), BuildSummaryPayload(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), GetSummaryAsync(), XPoster.Services, GenerateImageAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), Run(), XPoster, XFunction(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, if(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), CreateValidJpegBytes(), HttpResponseMessage()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, foreach(), if(), Apply()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, InMemoryContainerStateStore, GetPendingAsync(), UpdateStatusAsync(), XPoster.Services, SaveAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XFunctionTests(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), GetImageGenerationEndpoint(), if(), BuildImagePromptPayload(), var(), catch()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), typeof()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), XPoster.Services, catch(), FalAiImageService(), GenerateImageAsync()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, XPoster.Contracts, SaveAsync(), UpdateStatusAsync()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), XPoster.Services

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, IgSender(), SendAsync(), if(), catch(), XPoster.SenderPlugins

### Community 73 - "Entity (Community 73)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, new(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DryRunSlotProfileProvider(), Uri(), if(), BlobServiceClient()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Null_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, if(), Validate(), InstagramCredentialsValidator

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), if(), DryRunSender(), XPoster.SenderPlugins

### Community 90 - "Entity (Community 90)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), MakeNoOpClient(), MakeDownloadClient(), HttpClient()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, XPoster.Contracts, PublishContainerAsync(), GetContainerStatusAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetImagePromptAsync(), GetSummaryAsync(), ITextToTextProvider

### Community 82 - "Entity (Community 82)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, foreach(), Validate(), if()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), XPoster.Contracts, UploadAsync()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, if(), Validate(), FacebookCredentialsValidator

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 97 - "Entity (Community 97)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), Exception(), XPoster.Services, GetFeedsAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), XPoster.Orchestrators, return(), Resolve()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Orchestrators

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 103 - "Entity (Community 103)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), GetProfiles()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), XPoster.Orchestrators, ConfigurationTagReplacementProvider()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, XPoster.Contracts, ITagReplacementService, Apply()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 136 - "Entity (Community 136)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 128 - "Entity (Community 128)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Contracts, BlobUploadResult()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 122 - "Entity (Community 122)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 119 - "Entity (Community 119)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Contracts, PendingContainer()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), XPoster.Extensions, AddHttpClients()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 146 - "Entity (Community 146)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 147 - "Entity (Community 147)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 153 - "Entity (Community 153)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): MaskUrlTelemetryInitializer.cs, Initialize(), MaskUrlTelemetryInitializer

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 142 - "Entity (Community 142)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (2): MaskUrlTelemetryInitializer.cs, if()

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

