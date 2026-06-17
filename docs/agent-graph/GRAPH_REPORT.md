# Graph Report - XPoster  (2026-06-17)

## Summary
- 819 nodes · 1368 edges · 110 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `HybridAiServiceTests` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `XPoster.SenderPlugins` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Abstraction` - 2 edges
9. `IOrchestrator` - 2 edges
10. `XPoster.Tests.Integration` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiService(), OpenAiServiceTests, GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, AzureFoundryService(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithoutImage_DoesNotQueryKv(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), new(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError() (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, ChatCompletionJson(), DeepSeekServiceTests, DeepSeekService(), XPoster.Tests.Services, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildSender(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_DoesNotCallAnyOutboundSocialApi(), DryRunSenderTests(), MessageMaxLenght_ReturnsIntMaxValue() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, FalImageJson(), BuildService(), FalAiImageService(), FalAiImageServiceTests, GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), var(), AiServiceHelperTests, MakeResponse() (+10 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, GetSecretAsync_ReturnsExpectedValue(), GetSecretAsync_ThrowsWhenSecretNotFound(), HttpFactory(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), StubHttpMessageHandler(), XSender_SendAsync_RequestsAllFourXCredentials() (+8 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, GenerateImageAsync(), BuildImagePromptPayload(), DeepSeekService(), BuildSummaryPayload(), XPoster.Services, while() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ModelsTests, Choice_CanBeCreated_WithMessage(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), Post_Firm_ContainsExpectedHashtags(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, BuildKeyVaultMockWithOrg(), BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), Validate_DefaultOptions_Succeeds() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSender(), new(), IgSenderResilienceTests, BuildSender(), PostWithImage(), PostWithoutImage() (+4 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, MakeHandlerMock(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), HybridAiServiceTests, FalAiImageService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), DeepSeekService() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_WhitespaceContent_ReturnsFalse(), XSenderMissingBranchTests() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetImagePromptAsync(), AzureFoundryService(), BuildSummaryPayload(), GetImageGenerationEndpoint(), GenerateImageAsync(), catch(), GetChatCompletionsEndpoint() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvOnEachCall(), XSender_ImplementsISender(), XPoster.Tests.SenderPlugins, XSenderTests() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, ValidPost(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), Generate_Should_CreateFeedOrchestratorWithDryRunSender_At9AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), XPoster.Tests.Implementation, Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), SetupMocksForOrchestratorFactory() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Implementation, SendIt_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator(), SendIt_IsAlwaysFalse(), NoOrchestratorTests(), OrchestrateAsync_ReturnsNull() (+2 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, var(), params(), BuildSequenceHandler(), HttpResponseMessage(), BuildProviderWithHandler() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), XPoster.Tests.Implementation, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), XPoster.Tests.Services (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, XPoster.Services, GetImagePromptAsync(), GetPromptForImage(), GetSummary(), catch(), GenerateImageAsync(), while() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostMissingBranchTests

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), XPoster.Tests.Services

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), ArgumentException(), GetByProvider(), InvalidOperationException(), XPoster.Implementation, AiServiceFactory()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), IsEnabled(), Dispose(), XPoster.Tests.Integration, CreateLogger()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), InvalidOperationException(), ResolveAuthorUrnAsync(), generatePayLoad(), Exception(), XPoster.SenderPlugins, using()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, Message, OpenAIImageResponse, ImageData, Choice, OpenAIResponse

### Community 42 - "Entity (Community 42)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), IAiService, XPoster.Abstraction, GetImagePromptAsync(), GetSummaryAsync()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), XPoster.Services, GetImagePromptAsync(), GetSummaryAsync(), HybridAiService()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, if(), catch(), SendAsync(), DryRunSender()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, GetSecretAsync(), IKeyVaultService, XPoster.Abstraction, SetSecretAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, SetSecretAsync(), KeyVaultService(), GetSecretAsync(), XPoster.Services

### Community 54 - "Entity (Community 54)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildFalService(), BuildDeepSeekService(), HybridAiService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions, AddHttpClients()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), Validate(), if(), XPoster.Models

### Community 57 - "Entity (Community 57)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 55 - "Entity (Community 55)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, XPoster.Services, catch(), return(), if()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 47 - "Entity (Community 47)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, XPoster.Implementation, return(), Resolve(), foreach(), ResolveAiProvider()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Abstraction

### Community 65 - "Entity (Community 65)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, SendAsync(), catch(), UploadImageToPublicUrl()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), GetFeedsAsync(), Exception()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, PostAsync(), IOrchestrator

### Community 59 - "Entity (Community 59)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, GenerateMessage(), catch(), XPoster.Implementation, ReplaceEveryFirstOccurenceOf()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), OrchestratorFactory(), ScheduledOrchestrationProfile(), CreateOrchestratorInstance()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Abstraction

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Abstraction, Resolve()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Implementation

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Abstraction, GetCryptoValue(), ICryptoService

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Abstraction

### Community 83 - "Entity (Community 83)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), var(), OpenAiService()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), var(), if()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), FeedOrchestrator(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 76 - "Entity (Community 76)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), catch(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 75 - "Entity (Community 75)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 99 - "Entity (Community 99)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 97 - "Entity (Community 97)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 94 - "Entity (Community 94)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 108 - "Entity (Community 108)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 107 - "Entity (Community 107)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

