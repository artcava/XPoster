# Graph Report - XPoster  (2026-06-22)

## Summary
- 1083 nodes · 1827 edges · 141 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Credentials` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Credentials` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Orchestrators` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), var(), AzureFoundryB64Json(), XPoster.Tests.Services, ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), BuildService(), ChatCompletionJson() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, new(), AiServiceHelperImageTests, Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_ReturnsBytes() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsAzureFoundry(), OptionsExtensionsTests, PerplexityOptionsExtensionsTests, register(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_RegistersValidator() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, BuildService(), PerplexityServiceTests, XPoster.Tests.Services, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+18 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), IgSenderTests(), MessageMaxLenght_Returns2200(), new() (+13 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_DoesNotCallAnyOutboundSocialApi(), DryRunSenderTests(), MessageMaxLenght_ReturnsIntMaxValue(), new(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildConfig() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), BuildService(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildFactory(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FakeHttpMessageHandler(), foreach(), FeedServiceTests, FeedService() (+10 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), HttpResponseMessage() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), XPoster.Tests.Models (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue(), Post_CanHold_ImageBytes(), OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), new(), CreateOrchestrator(), FeedOrchestratorTests(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), XPoster.Tests.Orchestrators (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, BuildCreds(), BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), InSenderMissingBranchTests(), MessageMaxLenght_Returns800() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, catch(), OpenAiService(), GetPromptForImage(), GetSummary(), GetSummaryAsync(), if() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageServiceTests, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, PostWithoutImage(), BuildSender(), IgSender() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), FeedOrchestratorFeedUrlProviderTests() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), XPoster.Tests.SenderPlugins, InSenderResilienceTests, InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, MessageMaxLenght_Returns250(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), MakeHandlerMock(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), BuildHybrid() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), XPoster.Tests.SenderPlugins (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException(), NoOrchestratorTests(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsNull() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), OrchestratorFactory(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Orchestrators, PowerLawOrchestratorTests(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, XPoster.Tests.Models (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, ResolveAuthorUrn(), InvalidOperationException(), Exception(), generatePayLoad(), catch(), using() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildDelayedHandler(), BuildSequenceHandler(), HttpResponseMessage(), var(), params() (+1 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), AzureFoundryService(), GetChatCompletionsEndpoint(), GetSummaryAsync(), GetImagePromptAsync(), XPoster.Services, GenerateImageAsync()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 42 - "Entity (Community 42)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, while(), GetSummaryAsync(), nameof(), if(), GetImagePromptAsync(), GenerateImageAsync(), XPoster.Services

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), PostMissingBranchTests, XPoster.Tests.Models, Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, ImageData, Choice, XPoster.Models, OpenAIImageResponse, OpenAIResponse

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, ArgumentException(), XPoster.Orchestrators, InvalidOperationException(), AiServiceFactory(), GetByProvider(), if()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, Dispose(), CaptureLoggerProvider(), CreateLogger(), IsEnabled(), CaptureLogger()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), var(), if(), BuildImagePromptPayload(), catch(), GetImageGenerationEndpoint()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services, ExtractFalAiBytesAsync(), ExtractOpenAiBytes()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetSummaryAsync(), XPoster.Contracts, IAiService, GenerateImageAsync(), GetImagePromptAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), SetupMocksForOrchestratorFactory(), CreateFactory(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), OrchestratorFactoryTests()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GetSummaryAsync(), GetImagePromptAsync(), GenerateImageAsync(), HybridAiService()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, XPoster.Services, while(), GetSummaryAsync(), GenerateImageAsync(), if(), BuildSummaryPayload()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), GenerateImageAsync(), if(), XPoster.Services

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildFalService(), HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), XPoster.SenderPlugins, SendAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), XPoster.Orchestrators, Resolve(), foreach(), ResolveAiProvider()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), DeepSeekService(), BuildImagePromptPayload()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, PerplexityService(), BuildSummaryPayload(), BuildImagePromptPayload(), var(), GetChatCompletionsEndpoint()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, HttpClient(), JsonResponse(), var(), MakeNoOpClient(), MakeDownloadClient()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions

### Community 73 - "Entity (Community 73)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), XPoster.Orchestrators

### Community 72 - "Entity (Community 72)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), DryRunSlotProfileProvider(), Uri(), if()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, GetFeedUrls(), IFeedUrlProvider

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), XPoster.Tests.Integration

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Contracts, IAiServiceFactory, GetByProvider()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync(), catch()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 86 - "Entity (Community 86)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), GetFeedsAsync(), XPoster.Services

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 83 - "Entity (Community 83)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), XPoster.Orchestrators, ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Orchestrators, ConfigurationFeedUrlProvider()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, Resolve(), XPoster.Contracts

### Community 111 - "Entity (Community 111)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), XPoster, Run()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), FeedOrchestrator(), if()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), if(), CreateOrchestratorInstance()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, PostAsync(), BaseOrchestrator()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, IgCredentials.cs, XPoster.Credentials

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 130 - "Entity (Community 130)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

