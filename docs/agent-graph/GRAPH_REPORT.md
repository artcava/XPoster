# Graph Report - XPoster  (2026-06-16)

## Summary
- 791 nodes · 1318 edges · 109 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Services` - 2 edges
2. `HybridAiServiceTests` - 2 edges
3. `InSenderResilienceTests` - 2 edges
4. `XPoster.Tests` - 2 edges
5. `OpenAIResponse` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Models` - 2 edges
8. `Post` - 2 edges
9. `RSSFeed` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithImage_ReadsIgAccountIdFromKv(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), DeepSeekServiceTests, ChatCompletionJson() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), MakeHandlerMock(), XPoster.Tests.Services (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, GetSecretAsync_ReturnsExpectedValue(), GetSecretAsync_ThrowsWhenSecretNotFound(), HttpFactory(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), StubHttpMessageHandler(), XPoster.Tests.Services (+8 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, BuildImagePromptPayload(), while(), if(), NotSupportedException(), var(), DeepSeekService() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, ModelsTests, Choice_CanBeCreated_WithMessage(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent() (+6 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), MessageMaxLenght_Returns800(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), InSenderTests(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), BuildKeyVaultMockWithOrg() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingApiKey_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithoutImage() (+4 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), FeedOrchestratorTests() (+4 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, XPoster.Tests.Services, FalAiImageService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), MakeHandlerMock(), HybridAiServiceTests, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), Constructor_NullDeepSeekService_ThrowsArgumentNullException() (+3 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, InSender(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), catch(), GenerateImageAsync(), AzureFoundryService(), GetSummaryAsync() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XSenderTests(), XPoster.Tests.SenderPlugins, BuildKeyVaultMock(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_CalledTwice_QueriesKvOnEachCall() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Name_IsNoOrchestrator(), XPoster.Tests.Implementation, NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse() (+2 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, GetSummaryAsync(), catch(), GetSummary(), GetImagePromptAsync(), GetPromptForImage(), GenerateImageAsync(), while() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), HttpResponseMessage(), params(), var() (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), MakeService(), XPoster.Tests.Services (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), PowerLawOrchestratorTests(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Implementation (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), InvalidOperationException(), ResolveAuthorUrnAsync(), generatePayLoad(), Exception(), using(), XPoster.SenderPlugins

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, ImageData, Choice, OpenAIImageResponse, Message

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), XPoster.Implementation, InvalidOperationException(), AiServiceFactory(), GetByProvider(), ArgumentException()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), FeedServiceTests(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), XPoster.Tests.Services

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), Dispose(), CaptureLoggerProvider(), CreateLogger(), CaptureLogger(), XPoster.Tests.Integration

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Implementation, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), PostMissingBranchTests, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetImagePromptAsync(), GenerateImageAsync(), XPoster.Abstraction, IAiService, GetSummaryAsync()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync(), HybridAiService()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, XPoster.Abstraction, SetSecretAsync(), GetSecretAsync(), IKeyVaultService

### Community 43 - "Entity (Community 43)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildFalService(), HybridAiService()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), XPoster.Models, Validate(), if()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, SetSecretAsync(), KeyVaultService(), GetSecretAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, XPoster.Tests.Implementation, Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, return(), catch(), if(), XPoster.Services

### Community 45 - "Entity (Community 45)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), foreach(), ResolveAiProvider(), Resolve(), XPoster.Implementation

### Community 44 - "Entity (Community 44)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Abstraction, IOrchestrator

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Abstraction

### Community 70 - "Entity (Community 70)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), catch(), GenerateMessage()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 59 - "Entity (Community 59)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Services, GetCurrentTime()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, if(), PowerLawOrchestrator()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Abstraction

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, catch(), UploadImageToPublicUrl(), SendAsync()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 64 - "Entity (Community 64)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, Resolve(), IOrchestratorFactory

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), ScheduledOrchestrationProfile(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, GetByProvider(), XPoster.Abstraction

### Community 67 - "Entity (Community 67)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), foreach(), if()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 85 - "Entity (Community 85)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Abstraction

### Community 83 - "Entity (Community 83)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): InSender.cs, if(), catch(), InSender()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), OrchestratorFactoryTests()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, var(), OpenAiService(), if()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 78 - "Entity (Community 78)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), var(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (3): Program.cs, if(), Program.cs

### Community 94 - "Entity (Community 94)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 108 - "Entity (Community 108)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 107 - "Entity (Community 107)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

