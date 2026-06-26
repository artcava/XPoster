# Graph Report - XPoster  (2026-06-26)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `XPoster.Orchestrators` - 2 edges
3. `ISlotProfileProvider` - 2 edges
4. `ITimeProvider` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `ITextToImageProvider` - 2 edges
7. `XPoster.Contracts` - 2 edges
8. `ITagReplacementProvider` - 2 edges
9. `XPoster.Contracts` - 2 edges
10. `XPoster` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_MissingB64JsonProperty_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), OpenAiB64Json(), MakeHttpClient() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), MakeHandler(), MakeHandlerMock(), OpenAiService() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_AppliesHashtagsIndependently_PerSender(), CreateOrchestrator(), new(), FeedOrchestratorTests(), OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildConfig(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, XPoster.Tests.Services, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, IgSenderTests(), MessageMaxLenght_Returns2200(), new(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, ValidPost(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenProbeKeyPresent_LogsPostContent() (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), XPoster.Tests.Services (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildRssXml(), BuildFactory(), XPoster.Tests.Services, SendAsync(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), AzureFoundryService(), ChatCompletionJson(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), if() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_NotContainDryRunSlot(), XPoster.Tests.Orchestrators, PowerLawSlot_Should_HaveNullTextAndImageProvider(), PowerLawSlot_Should_ContainLinkedInAndX(), GetProfiles_Should_ReturnTwoActiveSlots(), DefaultSlotProfileProviderTests (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), XPoster.Tests.Models, Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GenerateImageAsync(), OpenAiService(), GetImagePromptAsync(), GetPromptForImage(), GetSummaryAsync(), GetSummary() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_NullPost_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_ErrorNamesProperty(), XPoster.Tests.Models, ValidOptions(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithoutImage(), PostWithImage(), IgSender(), BuildSender(), IgSenderResilienceTests, new() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Abstraction, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), ScheduledOrchestrationProfileTests (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), CreateOrchestrator(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), PowerLawOrchestratorTests(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, BuildSummaryPayload(), BuildImagePromptPayload(), GetSummaryAsync(), var(), if(), PerplexityService() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, while(), var(), XPoster.Services, BuildImagePromptPayload(), GetImagePromptAsync(), GetSummaryAsync() (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, XPoster.Tests.Orchestrators, Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), foreach(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender(), InSender() (+3 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), XPoster.Tests.SenderPlugins, Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), Build(), Name_IsNoOrchestrator(), NoOrchestratorTests, SupportedPlatforms_IsEmpty() (+2 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), BuildProviderWithHandler(), HttpResponseMessage(), BuildSequenceHandler(), params(), XPoster.Tests.Integration (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, ApplyTagReplacements(), foreach(), XPoster.Orchestrators, catch(), FeedOrchestrator(), if() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), XPoster.Tests.Services (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), InvalidOperationException(), catch(), Exception(), generatePayLoad(), ResolveAuthorUrn(), SendAsync() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), Dispose(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_DescriptionMatchesEnumName()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), PostMissingBranchTests, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, OpenAIImageResponse, OpenAIResponse, XPoster.Models, Message

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), GenerateImageAsync(), BuildSummaryPayload(), GetSummaryAsync(), XPoster.Services, GetChatCompletionsEndpoint(), GetImagePromptAsync()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, Run(), if(), catch(), XFunction()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), while(), var(), catch(), GetImageGenerationEndpoint(), BuildImagePromptPayload()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, BuildCreds()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), XPoster.Services, LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ParseImageResponseAsync()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles(), typeof(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient(), IsTransientHttpFailure()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetSummaryAsync(), GetImagePromptAsync(), XPoster.Contracts, ITextToTextProvider

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeDownloadClient(), MakeNoOpClient(), JsonResponse(), HttpClient()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), DryRunSlotProfileProvider(), DefaultAzureCredential(), Uri()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), XPoster.SenderPlugins, if(), DryRunSender()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, ConfigurationTagReplacementProvider(), GetReplacements()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 74 - "Entity (Community 74)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), catch(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators, ScheduledOrchestrationProfile()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), catch(), Exception(), XPoster.Services

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), GetFeedUrls(), XPoster.Orchestrators

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Services

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), XPoster.Orchestrators, return(), Resolve()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, PostAsync(), BaseOrchestrator()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, IgCredentials.cs, XPoster.Credentials

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 111 - "Entity (Community 111)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

