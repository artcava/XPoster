# Graph Report - XPoster  (2026-06-15)

## Summary
- 768 nodes · 1278 edges · 107 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `ICryptoService` - 2 edges
2. `XPoster.Abstraction` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Implementation` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `XPoster.Tests.Models` - 2 edges
7. `IAiService` - 2 edges
8. `XPoster.Tests.SenderPlugins` - 2 edges
9. `ISender` - 2 edges
10. `XPoster.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, MakeHandlerMock(), OpenAiService(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.20
Nodes (19): IgSenderTests.cs, IgSenderTests.cs, MessageMaxLenght_Returns2200(), Constructor_WithNullLogger_ThrowsArgumentNullException(), IgSenderTests(), IgSender(), XPoster.Tests.SenderPlugins, SendAsync_WithWhitespaceContent_ReturnsFalse() (+11 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, var(), XPoster.Tests.Services, ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, StubHttpMessageHandler(), XSender_SendAsync_RequestsAllFourXCredentials(), XPoster.Tests.Services, InSender_SendAsync_RequestsLinkedInAccessToken(), InSender_SendAsync_RequestsLinkedInOwnerCode(), InSenderKv() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_CanBeCreated_WithAllProperties(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), OpenAIResponse_CanBeCreated_WithChoices(), ModelsTests (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), XPoster.Tests.SenderPlugins, MessageMaxLenght_Returns800() (+6 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, GenerateImageAsync(), BuildImagePromptPayload(), BuildSummaryPayload(), DeepSeekService(), while(), XPoster.Services (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), ValidOptions(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), InSender_ImplementsISender() (+5 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithoutImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), PostWithImage() (+4 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, FeedOrchestratorTests(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails() (+4 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, XPoster.Services, GenerateImageAsync(), GetChatCompletionsEndpoint(), while(), GetImagePromptAsync(), GetImageGenerationEndpoint(), GetSummaryAsync() (+3 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_InitializesCorrectly(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_CalledTwice_QueriesKvOnEachCall(), XSender_ImplementsISender() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, ChatCompletionJson(), BuildHybrid(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), MakeHandlerMock(), DeepSeekService(), FalAiImageService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator(), NoOrchestratorTests(), OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse() (+2 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Implementation, PowerLawOrchestratorTests(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), XPoster.Tests.Services, CryptoService() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, XPoster.Services, GenerateImageAsync(), GetImagePromptAsync(), while(), GetSummary(), GetSummaryAsync(), GetPromptForImage() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, BuildDelayedHandler(), var(), HttpResponseMessage(), BuildSequenceHandler(), params() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), PostMissingBranchTests, XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.25
Nodes (8): InSender.cs, InvalidOperationException(), ResolveAuthorUrnAsync(), XPoster.SenderPlugins, SendAsync(), using(), Exception(), generatePayLoad()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, Message, XPoster.Models, OpenAIResponse, OpenAIImageResponse

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, InvalidOperationException(), if(), ArgumentException(), AiServiceFactory(), XPoster.Implementation, GetByProvider()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), ValidOptions(), AzureFoundryOptionsValidatorTests

### Community 40 - "Entity (Community 40)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), XPoster.Abstraction, IAiService, GetImagePromptAsync(), GetSummaryAsync()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_SendIt_IsFalse()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), XPoster.Services

### Community 38 - "Entity (Community 38)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, return(), XPoster.Services, catch(), if()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, GetSecretAsync(), IKeyVaultService, XPoster.Abstraction, SetSecretAsync()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, if(), Validate(), foreach()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), XPoster.Tests.Implementation, Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, GetSecretAsync(), KeyVaultService(), XPoster.Services, SetSecretAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildDeepSeekService()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 45 - "Entity (Community 45)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsLocalTime()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, XPoster.Implementation, ResolveAiProvider(), foreach(), return(), Resolve()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, IsTransientHttpFailure(), AddHttpClients(), AddResilientHttpClient()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), XPoster.SenderPlugins, catch(), SendAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Implementation, catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Abstraction

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 58 - "Entity (Community 58)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Abstraction, IOrchestrator

### Community 55 - "Entity (Community 55)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Abstraction, GetFeedsAsync(), IFeedService

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Abstraction

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Abstraction, GetCurrentTime()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, OrchestratorFactory(), if(), CreateOrchestratorInstance(), ScheduledOrchestrationProfile()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), PowerLawOrchestrator(), XPoster.Implementation

### Community 62 - "Entity (Community 62)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, catch()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), OpenAiService(), var()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), BaseOrchestrator(), XPoster.Abstraction

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 76 - "Entity (Community 76)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), var(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), if(), FeedOrchestrator()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), if(), catch()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, FalAiImageService()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 96 - "Entity (Community 96)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 99 - "Entity (Community 99)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 100 - "Entity (Community 100)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 94 - "Entity (Community 94)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 88 - "Entity (Community 88)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 103 - "Entity (Community 103)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

