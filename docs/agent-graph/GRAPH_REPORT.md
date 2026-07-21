# Graph Report - XPoster  (2026-07-21)

## Summary
- 1619 nodes · 2749 edges · 194 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Credentials` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster` - 2 edges
5. `XPoster.Tests.Integration` - 2 edges
6. `XPoster.Tests.SenderPlugins` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Credentials` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), AzureFoundryB64Json(), ParseImageResponseAsync_WhenMalformedJson_LogsError(), ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray(), AiServiceHelperTests, FalAiJson() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent(), OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), XPoster.Tests.Services, BuildPromptRequest() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmpty(), GenerateTextAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateTextAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), XPoster.Tests.Services, OpenAiService() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, new(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), FeedProfile(), FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun() (+22 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddPerplexityOptions_RegistersValidator(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), XPoster.Tests.Models, SectionName_IsPerplexity() (+21 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, new(), PerplexityServiceTests, XPoster.Tests.Services, PerplexityService(), MakeHandlerMock(), GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce() (+20 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, NormalizeImage_WithValidJpeg_ReturnsSameBytes(), FbSenderTests(), NormalizeImage_WithInvalidBytes_ReturnsNull(), MessageMaxLength_Returns3000(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullFactory_ThrowsArgumentNullException() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, HttpResponseMessage(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), GenerateTextAsync_WhenUsedForImagePromptDerivation_ReturnsPrompt(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), new(), SummaryRequest() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, FeedPromptOptionsTests, FeedPromptOptions_ValueEquality_DifferentSteps_AreNotEqual(), FeedPromptOptions_ValueEquality_DifferentStepCount_AreNotEqual(), FeedPromptOptions_WithExpression_PreservesStepsReference(), FeedPromptOptions_ValueEquality_SameSteps_AreEqual(), FeedPromptOptions_Steps_PreservesOrder() (+11 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), return(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, return(), XPoster.Tests.Services, AiServiceHelperChatPayloadTests, BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_ForwardsModelName(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FakeHttpMessageHandler(), FeedService(), foreach(), FeedServiceTests, SendAsync() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), XPoster.Tests.Services, PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, ImagePromptRequest_ImageProperties_AreSetCorrectly(), ImagePromptRequest_BaseProperties_AreAccessible(), PromptRequestTests, PromptRequest_OptionalProperties_DefaultToNull(), PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_Temperature_AcceptsZeroAndOne() (+9 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, XPoster.Tests.Models, PromptStepOptions_SummaryStep_MaxOutputLength_IsNullByConvention(), PromptStepOptions_ValueEquality_DifferentRole_AreNotEqual(), PromptStepOptions_Temperature_AcceptsZeroAndOne(), PromptStepOptions_ValueEquality_SameValues_AreEqual(), PromptStepOptions_ValueEquality_DifferentOptionals_AreNotEqual() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithValidInputs_StoresPendingEntry(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, ValidPost(), ConfigurationBuilder(), BuildConfig(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), Constructor_WithNullConfiguration_ThrowsArgumentNullException() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), GetProfiles_Should_ReturnWellFormedProfiles(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, XPoster.Tests.Services, UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), CreateSut(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_TryParse_InvalidName_ReturnsFalse(), PromptRole_TryParse_ValidName_ReturnsTrue(), PromptRole_UsedAsDictionaryKey_LookupSucceeds(), XPoster.Tests.Models, PromptRoleTests, PromptRole_UndefinedValueNotPresentInMap_ThrowsKeyNotFound() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData() (+7 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), PostWithoutImage(), BuildSender(), PostWithImage(), IgSender(), new() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests, OrchestratorContextKey_Should_BeSet_WhenProvided(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), typeof() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), AIResponse_CanBeCreated_WithChoices(), Choice_CanBeCreated_WithMessage(), RSSFeed_PublishDate_DefaultsToMinValue(), ModelsTests, RSSFeed_CanBeCreated_WithAllProperties() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, if(), HandleFinishedAsync(), HandleTerminalFailureAsync(), foreach(), catch(), Run() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails() (+5 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+5 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), BuildProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, InSender_ImplementsISender(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, while(), AzureFoundryService(), GetImageGenerationEndpoint(), var(), if(), catch() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+4 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), foreach(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProvider(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), BuildSender(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), DryRunSenderTests(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WhenProbeKeyMissing_LogsError() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_RequestUsesImageQuantityFromRequest() (+4 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), XPoster.Tests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), MessageMaxLength_Returns2800(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), InSender(), Constructor_InitializesCorrectly() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSenderResilienceTests (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), XPoster.Tests.Extensions, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly() (+3 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), XPoster.Tests.SenderPlugins, new(), Platform_ReturnsInstagram(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, SendAsync(), PublishPhotoAsync(), FbSender(), if(), HandleResponseAsync() (+2 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WithValidOptions_ReturnsSuccess() (+2 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildCreds(), BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), XPoster.Tests.SenderPlugins, FbSenderSendAsyncTests, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, GetApiVersion(), catch(), GetContainerStatusAsync(), if(), HttpRequestException(), MetaPublishingService() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), BuildSender(), IgSender(), SendAsync_WithNoImage_ReturnsFalse() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedTests (+1 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), HttpResponseMessage(), BuildDelayedHandler(), BuildProviderWithHandler(), BuildSequenceHandler(), params() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo(), PendingContainer() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, FeedOrchestrator(), catch(), XPoster.Orchestrators, if(), foreach(), AcquireFeedContentAsync() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), FbSenderResilienceTests, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, XPoster.Tests.Extensions, HttpClientExtensionsTests, AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_ReturnsSameServiceCollection() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), InvalidOperationException(), generatePayLoad(), XPoster.SenderPlugins, SendAsync(), Exception(), catch() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), HttpRequestException(), FbSenderImageFlowTests, BuildFactory(), BuildCreds(), InvalidImageBytes() (+1 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), catch(), FalAiImageService(), if(), XPoster.Services, GetImageGenerationEndpoint()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CreateLogger(), CaptureLoggerProvider(), CaptureLogger(), IsEnabled(), Dispose()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently(), XPoster.Tests.Providers, OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), DeleteAsync(), if(), UploadAsync(), XPoster.Services, BlobStorageService()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), BaseOrchestratorTests()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, PostTests, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, XPoster.Models, ImageData, Message, OpenAIImageResponse, Choice, AIResponse

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), BuildChatPayload()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), IgSender(), catch(), if(), XPoster.SenderPlugins

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), XPoster.Services, UpdateStatusAsync(), GetPendingAsync(), InMemoryContainerStateStore

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), XPoster.Credentials, CredentialsStartupValidator(), catch(), InvalidOperationException(), if()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), if(), Run(), XPoster

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, Apply(), if(), foreach(), TagReplacementService()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, Uri(), BlobServiceClient(), if(), DryRunSlotProfileProvider(), DefaultAzureCredential()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateTextAsync(), XPoster.Services, catch(), var(), while(), GenerateImageAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, UpdateStatusAsync(), XPoster.Contracts, GetPendingAsync(), IContainerStateStore, SaveAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), HttpResponseMessage(), if(), CreateValidJpegBytes()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), XPoster.Credentials, if(), InstagramCredentialsValidator

### Community 88 - "Entity (Community 88)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, PublishContainerAsync(), XPoster.Contracts, GetContainerStatusAsync()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), MakeNoOpClient(), var(), JsonResponse(), HttpClient()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, if(), XPoster.Credentials, Validate(), FacebookCredentialsValidator

### Community 85 - "Entity (Community 85)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), XPoster.SenderPlugins, SendAsync()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSenderTests(), IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsUtcTime()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), Resolve(), return(), typeof(), XPoster.Orchestrators

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, SetupHappyPathProviders(), BuildContext(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), new()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 94 - "Entity (Community 94)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests, XPoster.Tests.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), IBlobStorageService, XPoster.Contracts, UploadAsync()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptionsTests

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), if(), MaskUrlTelemetryProcessor()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Providers

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Providers

### Community 121 - "Entity (Community 121)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), OpenAiService(), if(), GetImageGenerationEndpoint()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Providers, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), InvalidOperationException(), OrchestratorFactory()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 101 - "Entity (Community 101)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), var(), XPoster.Services, if()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), catch(), GetFeedsAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, XPoster.Models, PromptRequest

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Providers

### Community 113 - "Entity (Community 113)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 127 - "Entity (Community 127)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Providers

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), var(), XPoster.Services, GenerateTextAsync()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), XPoster.Tests.Helpers, CreateValidJpeg()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 150 - "Entity (Community 150)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, XPoster.Models, FeedOrchestratorContext

### Community 154 - "Entity (Community 154)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 151 - "Entity (Community 151)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 153 - "Entity (Community 153)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 155 - "Entity (Community 155)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 132 - "Entity (Community 132)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, resolve(), foreach(), ValidateOptions()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 142 - "Entity (Community 142)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), GetChatCompletionsEndpoint(), while()

### Community 148 - "Entity (Community 148)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), catch(), if()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, XPoster.Models, GetStep()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 136 - "Entity (Community 136)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 137 - "Entity (Community 137)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 138 - "Entity (Community 138)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 161 - "Entity (Community 161)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 160 - "Entity (Community 160)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 159 - "Entity (Community 159)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 158 - "Entity (Community 158)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 162 - "Entity (Community 162)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 172 - "Entity (Community 172)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, XPoster.Models, PromptRole.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 164 - "Entity (Community 164)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 163 - "Entity (Community 163)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): XPoster.Models, BlobStorageOptions.cs, BlobStorageOptions.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 185 - "Entity (Community 185)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 187 - "Entity (Community 187)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 186 - "Entity (Community 186)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 184 - "Entity (Community 184)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 179 - "Entity (Community 179)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 180 - "Entity (Community 180)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 182 - "Entity (Community 182)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 183 - "Entity (Community 183)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (2): FalAiOptionsValidator.cs, if()

### Community 189 - "Entity (Community 189)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 191 - "Entity (Community 191)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 190 - "Entity (Community 190)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

