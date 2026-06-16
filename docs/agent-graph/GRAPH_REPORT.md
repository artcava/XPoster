# Graph Report - XPoster  (2026-06-16)

## Summary
- 819 nodes · 1368 edges · 110 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Tests.SenderPlugins` - 2 edges
3. `ImageData` - 2 edges
4. `Choice` - 2 edges
5. `XPoster.Models` - 2 edges
6. `OpenAIResponse` - 2 edges
7. `AzureFoundryOptionsValidatorTests` - 2 edges
8. `Message` - 2 edges
9. `OpenAIImageResponse` - 2 edges
10. `RSSFeed` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiService(), MakeHandlerMock(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), ChatCompletionJson(), BuildService() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), BuildSenderWithFactory(), BuildSender(), Constructor_InitializesCorrectly(), SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), DeepSeekServiceTests, ChatCompletionJson() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithImageBytes_LogsImagePresence(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), SendAsync_WhenKeyVaultProbeThrows_LogsError(), SendAsync_WhenKeyVaultProbeThrows_ReturnsFalse(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), DryRunSenderTests() (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, XPoster.Tests.Services, ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), new() (+10 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, StubHttpMessageHandler(), XPoster.Tests.Services, XSender_SendAsync_RequestsAllFourXCredentials(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), GetSecretAsync_ReturnsExpectedValue(), GetSecretAsync_ThrowsWhenSecretNotFound() (+8 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, GenerateImageAsync(), BuildImagePromptPayload(), DeepSeekService(), BuildSummaryPayload(), while(), GetSummaryAsync() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), XPoster.Tests.Services, LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), InSenderTests(), Constructor_InitializesCorrectly() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), ValidOptions(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull() (+4 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, PostWithImage() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, Constructor_NullDeepSeekService_ThrowsArgumentNullException(), ChatCompletionJson(), BuildHybrid(), XPoster.Tests.Services, DeepSeekService(), FalAiImageService(), MakeHandlerMock() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, while(), XPoster.Services, GetImagePromptAsync(), AzureFoundryService(), GetImageGenerationEndpoint(), GenerateImageAsync(), GetChatCompletionsEndpoint() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), OrchestratorFactoryTests() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), BuildSender() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), BuildSender(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSender() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_CalledTwice_QueriesKvOnEachCall(), XSenderTests(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator(), ProduceImage_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), SendIt_IsAlwaysFalse() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, XPoster.Services, while(), GetSummary(), GetImagePromptAsync(), GenerateImageAsync(), GetPromptForImage(), catch() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), XPoster.Tests.Services (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeedMissingBranchTests (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildProviderWithHandler(), BuildSequenceHandler(), HttpResponseMessage(), BuildDelayedHandler(), XPoster.Tests.Integration, params() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Implementation, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), PowerLawOrchestratorTests() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, XPoster.Models, OpenAIResponse, Message, OpenAIImageResponse

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), ArgumentException(), AiServiceFactory(), XPoster.Implementation, InvalidOperationException(), if()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), PostMissingBranchTests

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), FeedServiceTests(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, IsEnabled(), Dispose(), CaptureLogger(), CreateLogger(), XPoster.Tests.Integration, CaptureLoggerProvider()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.25
Nodes (8): InSender.cs, XPoster.SenderPlugins, using(), ResolveAuthorUrnAsync(), SendAsync(), InvalidOperationException(), Exception(), generatePayLoad()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), IAiService, XPoster.Abstraction, GetImagePromptAsync(), GetSummaryAsync()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, DryRunSender(), SendAsync(), if(), catch()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), XPoster.Services, GetImagePromptAsync(), GetSummaryAsync(), HybridAiService()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, XPoster.Services, if(), catch(), return()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, GetSecretAsync(), KeyVaultService(), SetSecretAsync(), XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), XPoster.Models, Validate()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), IsTransientHttpFailure(), XPoster.Extensions

### Community 51 - "Entity (Community 51)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration

### Community 53 - "Entity (Community 53)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, Resolve(), ResolveAiProvider(), XPoster.Implementation, return(), foreach()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, SetSecretAsync(), IKeyVaultService, GetSecretAsync(), XPoster.Abstraction

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Abstraction

### Community 72 - "Entity (Community 72)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Abstraction, GetFeedsAsync()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, if(), PowerLawOrchestrator()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Services

### Community 59 - "Entity (Community 59)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, CreateOrchestratorInstance(), ScheduledOrchestrationProfile(), if(), OrchestratorFactory()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Abstraction

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, SendAsync(), UploadImageToPublicUrl()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Abstraction, SendAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Abstraction, IOrchestratorFactory

### Community 67 - "Entity (Community 67)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Abstraction, IAiServiceFactory, GetByProvider()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 79 - "Entity (Community 79)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 73 - "Entity (Community 73)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), Run(), XPoster

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, var(), OpenAiService(), if()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), if(), foreach()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, BaseOrchestrator(), PostAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), if(), catch()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), if(), BuildImagePromptPayload()

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 99 - "Entity (Community 99)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 92 - "Entity (Community 92)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 108 - "Entity (Community 108)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 107 - "Entity (Community 107)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

