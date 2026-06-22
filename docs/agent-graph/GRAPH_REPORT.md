# Graph Report - XPoster  (2026-06-22)

## Summary
- 1083 nodes · 1827 edges · 141 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `PostMissingBranchTests` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Tests.SenderPlugins` - 2 edges
6. `OpenAIResponse` - 2 edges
7. `Message` - 2 edges
8. `XPoster.Tests` - 2 edges
9. `OpenAIImageResponse` - 2 edges
10. `ImageData` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseImageResponseAsync_UnsupportedProvider_LogsError(), ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), BuildService(), ChatCompletionJson(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_UnsupportedProvider_LogsError(), Parse_Returns429_LogsWarning(), Parse_Returns429_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsPerplexity(), SectionName_IsDeepSeek(), SectionName_IsOpenAI(), SectionName_IsFalAi(), BuildConfig(), ConfigurationBuilder() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi() (+18 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhitespaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError() (+13 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), DeepSeekServiceTests, GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_ExceptionMessage_MentionsHybridAiService(), GenerateImageAsync_AlwaysThrows_NotSupportedException(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_LogsPostContent(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildFactory(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml() (+10 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), FeedOrchestratorTests(), new(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), CreateOrchestrator() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), ImageData_CanBeCreated_WithUrl(), Choice_CanBeCreated_WithMessage() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), XPoster.Tests.Models, Validate_WithMultipleInvalidFields_ReturnsAllFailures() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetImagePromptAsync(), GetSummary(), if(), GetSummaryAsync(), GetPromptForImage(), OpenAiService() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingApiKey_Fails(), FalAiOptionsValidatorTests, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, BuildService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalImageJson(), FalAiImageServiceTests, GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSender(), IgSenderResilienceTests, PostWithImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), PostWithoutImage(), new() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), new(), CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, MakeHandlerMock(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), HybridAiServiceTests, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), FalAiImageService() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), OrchestratorFactory(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), XSenderTests() (+2 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), SendIt_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), ResolveAuthorUrn(), catch(), Exception(), generatePayLoad(), InvalidOperationException(), XPoster.SenderPlugins (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, params(), HttpResponseMessage(), BuildDelayedHandler(), BuildProviderWithHandler(), BuildSequenceHandler(), var() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeedMissingBranchTests, XPoster.Tests.Models (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), XPoster.Tests.Orchestrators (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), PostMissingBranchTests, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), XPoster.Tests.Models

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, GenerateImageAsync(), if(), while(), XPoster.Services, nameof(), GetImagePromptAsync(), GetSummaryAsync()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIResponse, Message, OpenAIImageResponse, ImageData, Choice

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), ArgumentException(), if(), InvalidOperationException(), XPoster.Orchestrators, AiServiceFactory()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), XPoster.Services, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), BuildSummaryPayload(), GetChatCompletionsEndpoint()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CreateLogger(), IsEnabled(), XPoster.Tests.Integration, Dispose(), CaptureLogger()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, InSender_ImplementsISender(), Constructor_InitializesCorrectly(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), GenerateImageAsync(), catch(), FalAiImageService(), XPoster.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), HybridAiService()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, GetSummaryAsync(), GenerateImageAsync(), BuildSummaryPayload(), while(), XPoster.Services, if()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, IAiService, XPoster.Contracts, GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, catch(), BuildImagePromptPayload(), while(), var(), if(), GetImageGenerationEndpoint()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), SetupMocksForOrchestratorFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), CreateFactoryWithProfiles()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), BuildFalService(), HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), return(), ResolveAiProvider(), Resolve(), XPoster.Orchestrators

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), MakeDownloadClient(), JsonResponse(), HttpClient(), var()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), IsTransientHttpFailure(), XPoster.Extensions

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, BuildSummaryPayload(), BuildImagePromptPayload(), PerplexityService(), var(), GetChatCompletionsEndpoint()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, GetImagePromptAsync(), BuildImagePromptPayload(), DeepSeekService(), var(), GetChatCompletionsEndpoint()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), DryRunSender(), SendAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), Uri(), DryRunSlotProfileProvider(), if()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), GetProfiles()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), TestOrchestrator()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Orchestrators, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins, catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), GetFeedsAsync(), XPoster.Services, Exception()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Orchestrators

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Contracts, IAiServiceFactory, GetByProvider()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), foreach(), FeedOrchestrator()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, BaseOrchestrator(), PostAsync()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, IgCredentials.cs, XPoster.Credentials

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

