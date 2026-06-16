# Graph Report - XPoster  (2026-06-16)

## Summary
- 773 nodes · 1288 edges · 107 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `PostMissingBranchTests` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Tests.SenderPlugins` - 2 edges
5. `RSSFeed` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Tests.Helpers` - 2 edges
8. `XPoster.Implementation` - 2 edges
9. `IAiService` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), ChatCompletionJson(), BuildService() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithImage_ReadsIgAccessTokenFromKv(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError() (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalImageJson() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), new(), MakeResponse() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, StubHttpMessageHandler(), XPoster.Tests.Services, XSender_SendAsync_RequestsAllFourXCredentials(), KeyVaultServiceTests, GetSecretAsync_ReturnsExpectedValue(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, GetChatCompletionsEndpoint(), BuildSummaryPayload(), DeepSeekService(), GenerateImageAsync(), XPoster.Services, var() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, MessageMaxLenght_Returns800(), BuildSender(), if(), InSenderMissingBranchTests(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+6 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), OpenAIImageResponse_CanBeCreated_WithData(), Post_CanBeCreated_WithRequiredContent(), OpenAIResponse_CanBeCreated_WithChoices(), Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), InSender_ImplementsISender(), InSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds(), Validate_WhitespaceModelId_Fails() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull() (+4 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithImage(), BuildSender() (+4 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, while(), GenerateImageAsync(), GetChatCompletionsEndpoint(), GetSummaryAsync(), GetImagePromptAsync(), GetImageGenerationEndpoint(), catch() (+3 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderMissingBranchTests(), BuildSender(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), XPoster.Tests.SenderPlugins, ValidPost() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), ChatCompletionJson(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), FalAiImageService() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, BuildKeyVaultMock(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_CalledTwice_QueriesKvOnEachCall(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Implementation, NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildDelayedHandler(), BuildSequenceHandler(), HttpResponseMessage(), params(), XPoster.Tests.Integration (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, GetImagePromptAsync(), GenerateImageAsync(), catch(), GetSummaryAsync(), XPoster.Services, while(), GetPromptForImage() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, CryptoService(), MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), XPoster.Tests.Implementation, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, ArgumentException(), AiServiceFactory(), if(), XPoster.Implementation, InvalidOperationException(), GetByProvider()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), XPoster.Tests.Implementation, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, ImageData, OpenAIResponse, OpenAIImageResponse, XPoster.Models, Message

### Community 31 - "Entity (Community 31)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), FeedServiceTests(), XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), Dispose(), CaptureLoggerProvider(), CreateLogger(), CaptureLogger(), XPoster.Tests.Integration

### Community 34 - "Entity (Community 34)"
Cohesion: 0.25
Nodes (8): InSender.cs, Exception(), generatePayLoad(), XPoster.SenderPlugins, ResolveAuthorUrnAsync(), InvalidOperationException(), SendAsync(), using()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), GetImagePromptAsync(), XPoster.Services, GenerateImageAsync(), HybridAiService()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), IAiService, XPoster.Abstraction

### Community 40 - "Entity (Community 40)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Abstraction

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, XPoster.Abstraction, SetSecretAsync(), GetSecretAsync()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), HybridAiService(), BuildFalService(), BuildDeepSeekService()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, XPoster.Tests.Implementation, Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients(), IsTransientHttpFailure()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, if(), catch(), XPoster.Services, return()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, ResolveAiProvider(), return(), XPoster.Implementation, Resolve(), foreach()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), XPoster.Models, if(), Validate()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsLocalTime(), TimeProviderTests, XPoster.Tests.Services

### Community 45 - "Entity (Community 45)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, GetSecretAsync(), SetSecretAsync(), KeyVaultService(), XPoster.Services

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), PowerLawOrchestrator(), XPoster.Implementation

### Community 55 - "Entity (Community 55)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Abstraction, IFeedService

### Community 59 - "Entity (Community 59)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 58 - "Entity (Community 58)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, XPoster.Abstraction, GetByProvider()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), ScheduledOrchestrationProfile(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, GenerateMessage(), XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), catch()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), XPoster.Tests.Integration

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Abstraction, GetCryptoValue()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, Resolve(), IOrchestratorFactory

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 75 - "Entity (Community 75)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 76 - "Entity (Community 76)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, OpenAiService(), if(), var()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), FeedOrchestrator(), foreach()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), if(), BuildImagePromptPayload()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), if(), InSender()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), catch(), XPoster

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 87 - "Entity (Community 87)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (3): if(), Program.cs, Program.cs

### Community 96 - "Entity (Community 96)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 99 - "Entity (Community 99)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 98 - "Entity (Community 98)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 101 - "Entity (Community 101)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 100 - "Entity (Community 100)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

