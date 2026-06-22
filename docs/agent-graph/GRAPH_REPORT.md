# Graph Report - XPoster  (2026-06-22)

## Summary
- 1073 nodes · 1807 edges · 141 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `IFeedUrlProvider` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `XPoster.Orchestrators` - 2 edges
4. `XPoster.Services` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `XPoster.Tests.Integration` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Tests.SenderPlugins` - 2 edges
9. `XPoster.Abstraction` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_UnsupportedProvider_LogsError(), ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), OpenAiServiceTests, XPoster.Tests.Services, ChatCompletionJson() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_Returns429_ReturnsEmpty(), Parse_UnsupportedProvider_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, DeepSeekOptionsExtensionsTests, FalAiOptionsExtensionsTests, new(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateImageAsync_AlwaysReturnsEmptyByteArray(), ChatCompletionJson(), GenerateImageAsync_AlwaysLogsWarning(), foreach(), GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+18 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins (+13 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), MakeHandlerMock(), XPoster.Tests.Services (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildSender(), DryRunSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalse(), ValidPost() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), ChatCompletionJson() (+9 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models, Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIResponse_CanBeCreated_WithChoices(), ImageData_CanBeCreated_WithUrl(), OpenAIImageResponse_CanBeCreated_WithData(), ModelsTests, Message_CanBeCreated_WithContent(), XPoster.Tests.Models (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ApplyHashtagsCorrectly(), CreateOrchestrator(), new(), FeedOrchestratorTests(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GenerateImageAsync(), GetSummary(), GetImagePromptAsync(), GetPromptForImage(), GetSummaryAsync(), if() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), BuildCreds(), BuildSender() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, Validate_WhitespaceApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ValidOptions_Succeeds() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSenderResilienceTests, IgSender(), BuildSender(), XPoster.Tests.SenderPlugins, PostWithImage(), PostWithoutImage() (+4 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), FalImageJson(), BuildService(), FalAiImageServiceTests, XPoster.Tests.Services, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), XPoster.Tests.SenderPlugins, SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, new(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, XPoster.Tests.Services, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), DeepSeekService(), FalAiImageService(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), HybridAiServiceTests, MakeHandlerMock() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, ConfigurationFeedUrlProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider(), OrchestratorFactory(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour() (+2 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse() (+2 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), params(), XPoster.Tests.Integration, HttpResponseMessage(), BuildSequenceHandler(), BuildDelayedHandler() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), CryptoServiceTests (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.22
Nodes (9): InSender.cs, using(), XPoster.SenderPlugins, ResolveAuthorUrn(), InvalidOperationException(), catch(), Exception(), generatePayLoad() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), CaptureLoggerProvider(), CreateLogger(), CaptureLogger(), XPoster.Tests.Integration, IsEnabled()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Message, Choice, ImageData, OpenAIImageResponse, XPoster.Models, OpenAIResponse

### Community 45 - "Entity (Community 45)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, GetSummaryAsync(), nameof(), XPoster.Services, while(), if(), GetImagePromptAsync(), GenerateImageAsync()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, XPoster.Orchestrators, InvalidOperationException(), if(), GetByProvider(), AiServiceFactory(), ArgumentException()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), GetImagePromptAsync(), GetSummaryAsync(), BuildSummaryPayload(), GenerateImageAsync(), GetChatCompletionsEndpoint(), XPoster.Services

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), PostMissingBranchTests

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), XPoster.Tests.Services, GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_ReturnsEmpty_WhenCacheMissAndFetchFails()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, HybridAiService()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, GetImageGenerationEndpoint(), while(), if(), var(), BuildImagePromptPayload(), catch()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, GenerateImageAsync(), BuildSummaryPayload(), while(), XPoster.Services, GetSummaryAsync(), if()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), CreateFactory(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), OrchestratorFactoryTests()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), GenerateImageAsync(), XPoster.Services, FalAiImageService(), if()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XPoster.Tests, XFunctionMissingBranchTests()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Contracts, IAiService, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), ParseImageResponseAsync(), ExtractAzureFoundryBytesAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), BuildCreds(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Services

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), if(), Uri(), DryRunSlotProfileProvider()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), Validate(), XPoster.Models, foreach()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender(), InSenderTests()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildFalService(), BuildDeepSeekService()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), XPoster.Orchestrators

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, BuildImagePromptPayload(), PerplexityService(), var(), BuildSummaryPayload(), GetChatCompletionsEndpoint()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), XPoster.Orchestrators, ResolveAiProvider(), Resolve(), foreach()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient(), IsTransientHttpFailure()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, DeepSeekService(), GetImagePromptAsync(), BuildImagePromptPayload(), var(), GetChatCompletionsEndpoint()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), XPoster.SenderPlugins, SendAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), MakeNoOpClient(), JsonResponse(), HttpClient(), var()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Services

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Contracts, GetCurrentTime()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Orchestrators, GetFeedUrls()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), PowerLawOrchestrator(), XPoster.Orchestrators

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Contracts, GetByProvider(), IAiServiceFactory

### Community 81 - "Entity (Community 81)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Orchestrators, ReplaceEveryFirstOccurenceOf(), GenerateMessage(), catch()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, GetFeedsAsync(), IFeedService

### Community 75 - "Entity (Community 75)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, BaseOrchestrator(), PostAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), foreach(), if()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), catch(), XPoster

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

