# Graph Report - XPoster  (2026-07-14)

## Summary
- 1506 nodes · 2553 edges · 182 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `RSSFeedTests` - 2 edges
3. `XPoster.Tests.Providers` - 2 edges
4. `FbSenderImageFlowTests` - 2 edges
5. `FalAiImageServiceTests` - 2 edges
6. `IContainerStateStore` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Contracts` - 2 edges
9. `XPoster.Tests.Contracts` - 2 edges
10. `XPoster` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, FalAiJson(), ChatJson(), MakeHttpClient(), HttpClient(), XPoster.Tests.Services, ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray() (+41 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), OpenAiService(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), MakeHandlerMock() (+26 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot(), OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), CreateFactory() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddFalAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), BuildProvider(), AzureFoundryOptionsExtensionsTests, BuildConfig() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes(), XPoster.Tests.SenderPlugins, SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse() (+18 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), BuildService() (+15 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, BuildSender(), MessageMaxLength_Returns250(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), XPoster.Tests.Services, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), foreach(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), FeedServiceTests (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, BuildSender(), IgSender(), CreateMalformedPngBytes(), Uri(), return(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, if(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), HttpResponseMessage(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), AzureFoundryService() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), CreateSut(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_CanMoveEntryBackToPending(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending() (+8 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithImageBytes_ReturnsTrue(), new(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), XPoster.Tests.SenderPlugins (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryInitializerTests.cs, MaskUrlTelemetryInitializerTests.cs, Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), XPoster.Tests.Services, MaskUrlTelemetryInitializerTests, Initialize_WhenTelemetryIsNotDependency_DoesNothing() (+7 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveTextProviderConfigured() (+7 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, PostWithImage(), IgSender(), new(), IgSenderResilienceTests, BuildSender() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), XPoster.Tests.Services, UploadAsync_WhenStorageThrows_PropagatesException(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), CreateSut() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, if(), HandleTerminalFailureAsync(), HandleFinishedAsync(), catch(), foreach(), XPosterContainerPollingFunction() (+6 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Choice_CanBeCreated_WithMessage(), Post_CanBeCreated_WithRequiredContent(), ModelsTests, OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildSender() (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), LocalOverrideTimeProvider() (+5 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummary(), GenerateImageAsync(), catch(), GetPromptForImage(), GetImagePromptAsync(), if() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), BuildService(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WhenKeyWhitespace_ReturnsFalse(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi(), Platform_ReturnsDryRun(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSenderTests() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), InSender(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSenderTests(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, while(), BuildSummaryPayload(), var(), DeepSeekService(), GetChatCompletionsEndpoint(), GetImagePromptAsync() (+4 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), XPoster.Tests.Orchestrators, new(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders() (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, XPoster.Services, var(), BuildImagePromptPayload(), BuildSummaryPayload(), GetImagePromptAsync(), if() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenNoPendingContainers_DoesNothing(), CreateSut(), RunAsync_WhenCancelledDuringForEach_StopsGracefully(), RunAsync_WhenStatusIsInProgress_SkipsContainer() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), typeof(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), XPoster.Tests.Models, Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, BuildSender(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), Platform_ReturnsInstagram(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.35
Nodes (11): CredentialsStartupValidator.cs, CredentialsStartupValidator.cs, foreach(), if(), XPoster.Credentials, resolve(), ValidateOptions(), Validate() (+3 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests, XPoster.Tests.Providers, GetFeedUrls_Should_ReturnReadOnlyList(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, catch(), HandleResponseAsync(), FbSender(), if(), XPoster.SenderPlugins, PublishTextOnlyAsync() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), NoOrchestratorTests, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList() (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), XPoster.Services, GetContainerStatusAsync(), if(), HttpRequestException(), PublishContainerAsync() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, XSenderResilienceTests, XSender(), SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), XPoster.Tests.Models, RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), BuildFactory(), BuildCreds(), InvalidImageBytes(), FbSenderImageFlowTests, HttpRequestException(), XPoster.Tests.SenderPlugins (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), FbSenderResilienceTests, HttpResponseMessage() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), InvalidOperationException(), catch(), Exception(), generatePayLoad(), ResolveAuthorUrn(), XPoster.SenderPlugins (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), HttpResponseMessage(), params(), BuildDelayedHandler(), BuildProviderWithHandler(), BuildSequenceHandler() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, HttpClientExtensionsTests, AddHttpClients_RegistersIHttpClientFactory() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), XPoster.Services, GetChatCompletionsEndpoint(), GenerateImageAsync(), BuildSummaryPayload(), AzureFoundryService(), GetImagePromptAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), catch(), FeedOrchestrator(), foreach(), AcquireFeedContentAsync(), XPoster.Orchestrators

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled(), Dispose()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostTests

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, OpenAIImageResponse, Message, ImageData, Choice, AIResponse, XPoster.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), if(), DeleteAsync(), UploadAsync(), XPoster.Services, BlobUploadResult()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), XPoster.Providers, ScheduledOrchestrationProfile(), typeof()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, IContainerStateStore, SaveAsync(), UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync(), if(), catch()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), XPoster, if(), Run(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Providers, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage(), CreateValidJpegBytes(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, GetPendingAsync(), SaveAsync(), UpdateStatusAsync(), InMemoryContainerStateStore

### Community 80 - "Entity (Community 80)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), catch(), while(), var()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, catch(), SendAsync(), if(), IgSender()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, foreach(), Apply(), if(), TagReplacementService()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), BlobServiceClient(), DefaultAzureCredential(), if(), Uri()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ParseImageResponseAsync(), XPoster.Services, ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, GetContainerStatusAsync(), XPoster.Contracts, PublishContainerAsync(), IMetaPublishingService

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Providers, TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, XPoster.Credentials, Validate(), if(), InstagramCredentialsValidator

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), XPoster.Models, Validate()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSenderTests(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, IBlobStorageService, UploadAsync(), DeleteAsync()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, XPoster.Credentials, Validate(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), JsonResponse(), HttpClient()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), ITextToTextProvider, GetSummaryAsync(), XPoster.Contracts

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), XPoster.Orchestrators, return()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 105 - "Entity (Community 105)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Providers, ScheduledOrchestrationProfile()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, GetCurrentTime(), TimeProvider

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, Validate(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, GetFeedsAsync(), Exception()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 134 - "Entity (Community 134)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 132 - "Entity (Community 132)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 133 - "Entity (Community 133)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 136 - "Entity (Community 136)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 151 - "Entity (Community 151)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 150 - "Entity (Community 150)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 149 - "Entity (Community 149)"
Cohesion: 0.67
Nodes (3): MaskUrlTelemetryInitializer.cs, MaskUrlTelemetryInitializer, Initialize()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 148 - "Entity (Community 148)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, FacebookCredentials.cs, FacebookCredentials.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 167 - "Entity (Community 167)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 154 - "Entity (Community 154)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 159 - "Entity (Community 159)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 153 - "Entity (Community 153)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 157 - "Entity (Community 157)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 156 - "Entity (Community 156)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (2): MaskUrlTelemetryInitializer.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

