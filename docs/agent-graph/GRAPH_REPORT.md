# Graph Report - XPoster  (2026-06-26)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster` - 2 edges
3. `XPoster.Tests` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Tests.Helpers` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Credentials` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Credentials` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, XPoster.Tests.Services, var(), ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError(), ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), BuildService(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, typeof(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), SetupMocksForOrchestratorFactory(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, new(), ConfigurationBuilder(), DeepSeekOptionsExtensionsTests, FalAiOptionsExtensionsTests, AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), MakeHandlerMock(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), IgSender(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_LogsPostContent(), new(), SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_DoesNotCallAnyOutboundSocialApi(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), XPoster.Tests.SenderPlugins (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), DeepSeekService(), ChatCompletionJson(), BuildService(), DeepSeekServiceTests (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildRssXml(), BuildFactory(), XPoster.Tests.Services, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), SendAsync(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), ChatCompletionJson(), AzureFoundryService(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_ReturnTwoActiveSlots(), PowerLawSlot_Should_ContainLinkedInAndX(), XPoster.Tests.Orchestrators, PowerLawSlot_Should_HaveNullTextAndImageProvider(), GetProfiles_Should_HaveUniqueHours(), FeedOrchestratorSlot_Should_ContainLinkedInAndX() (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), XPoster.Tests.Models, Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), ValidOptions(), Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+6 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIImageResponse_CanBeCreated_WithData(), Choice_CanBeCreated_WithMessage(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), ModelsTests, XPoster.Tests.Models (+6 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSenderMissingBranchTests(), BuildSender(), BuildCreds(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingModelId_Fails(), Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), LocalOverrideTimeProviderTests, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, if(), OpenAiService(), while(), var(), XPoster.Services, GetSummaryAsync() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), ConfigurationTagReplacementProvider(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), foreach(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, BuildService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, var(), BuildImagePromptPayload(), BuildSummaryPayload(), PerplexityService(), GetSummaryAsync(), if() (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), IgSender(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), IgSenderResilienceTests, new(), PostWithImage() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), new(), PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), typeof(), ScheduledOrchestrationProfileTests, XPoster.Tests.Abstraction, Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_PreserveHour_ForBoundaryValues() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, BuildSummaryPayload(), DeepSeekService(), BuildImagePromptPayload(), GetImagePromptAsync(), XPoster.Services, while() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLenght_Returns250() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+3 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Build(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), XPoster.Tests.SenderPlugins, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+2 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, if(), ApplyTagReplacements(), AcquireFeedContentAsync(), foreach(), FeedOrchestrator(), catch() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_SendIt_IsFalse() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.22
Nodes (9): InSender.cs, InvalidOperationException(), catch(), Exception(), generatePayLoad(), ResolveAuthorUrn(), using(), XPoster.SenderPlugins (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), var(), BuildSequenceHandler(), HttpResponseMessage(), params(), XPoster.Tests.Integration (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostMissingBranchTests

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, ImageData, OpenAIResponse, Message, OpenAIImageResponse, XPoster.Models

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), CreateLogger(), Dispose(), CaptureLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration

### Community 47 - "Entity (Community 47)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, AzureFoundryService(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync(), BuildSummaryPayload(), GenerateImageAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, catch(), XFunction(), if(), Run()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Orchestrators, new()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, FalAiImageService(), if(), GenerateImageAsync(), catch()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), while(), var(), catch(), GetImageGenerationEndpoint(), BuildImagePromptPayload()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), XPoster.Tests.SenderPlugins, Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), typeof(), XPoster.Orchestrators, GetProfiles()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), HttpClient(), MakeNoOpClient(), var(), MakeDownloadClient()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient(), IsTransientHttpFailure()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), Validate(), XPoster.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSenderTests(), InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), DryRunSlotProfileProvider(), DefaultAzureCredential(), Uri()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), XPoster.SenderPlugins, SendAsync()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GetSummaryAsync(), GetImagePromptAsync()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, return(), Resolve(), foreach(), XPoster.Orchestrators

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, XPoster.Contracts, GenerateImageAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 72 - "Entity (Community 72)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), XPoster.SenderPlugins, UploadImageToPublicUrl(), catch()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 75 - "Entity (Community 75)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, Exception(), GetFeedsAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, GetReplacements(), ConfigurationTagReplacementProvider(), XPoster.Orchestrators

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, Resolve(), XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Orchestrators

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, IgCredentials.cs, XPoster.Credentials

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

