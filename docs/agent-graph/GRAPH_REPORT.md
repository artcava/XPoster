# Graph Report - XPoster  (2026-06-17)

## Summary
- 841 nodes · 1403 edges · 115 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `OpenAiOptionsValidatorTests` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.SenderPlugins` - 2 edges
4. `XPoster.Tests.Integration` - 2 edges
5. `XPoster.Tests.Integration` - 2 edges
6. `XPoster.Abstraction` - 2 edges
7. `XPoster.Abstraction` - 2 edges
8. `IFeedService` - 2 edges
9. `ITimeProvider` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), OpenAiService() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), if(), BuildService(), AzureFoundryServiceTests, GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, BuildSenderWithFactory(), BuildSender(), SendAsync_WithoutImage_DoesNotQueryKv(), XPoster.Tests.SenderPlugins, SendAsync_WithWhitespaceContent_ReturnsFalse(), IgSender() (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), SendAsync_WhenKeyVaultProbeThrows_LogsError(), SendAsync_WhenKeyVaultProbeThrows_ReturnsFalse(), MessageMaxLenght_ReturnsIntMaxValue(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSender_ImplementsISender() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), MakeHandlerMock(), XPoster.Tests.Services (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), XPoster.Tests.Services, new() (+10 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, StubHttpMessageHandler(), XPoster.Tests.Services, XSender_SendAsync_RequestsAllFourXCredentials(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), GetSecretAsync_ReturnsExpectedValue(), GetSecretAsync_ThrowsWhenSecretNotFound() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, var(), GetSummaryAsync(), if(), NotSupportedException(), GetChatCompletionsEndpoint(), BuildSummaryPayload() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, if(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), InSenderMissingBranchTests(), MessageMaxLenght_Returns800(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIImageResponse_CanBeCreated_WithData(), ImageData_CanBeCreated_WithUrl(), ModelsTests, Message_CanBeCreated_WithContent(), RSSFeed_CanBeCreated_WithAllProperties(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), InSenderTests(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), Validate_MissingTextPlaceholder_ErrorNamesProperty() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Services, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSender(), BuildSender(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), new() (+4 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull() (+4 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, ChatCompletionJson(), DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), BuildHybrid(), FalAiImageService(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), XPoster.Tests.Services (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), BuildSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSenderResilienceTests, InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetImageGenerationEndpoint(), GetImagePromptAsync(), XPoster.Services, while(), GetSummaryAsync(), GenerateImageAsync(), AzureFoundryService() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), BuildKeyVaultMock(), Constructor_InitializesCorrectly(), SendAsync_CalledTwice_QueriesKvOnEachCall(), XSender_ImplementsISender() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Implementation, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), ProduceImage_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse() (+2 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), XPoster.Tests.Implementation, Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile() (+2 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, params(), XPoster.Tests.Integration, var(), BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails() (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), XPoster.Tests.Services, CryptoServiceTests, CryptoService() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), XPoster.Tests.Implementation, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, GetSummary(), GetPromptForImage(), GenerateImageAsync(), GetImagePromptAsync(), catch(), while(), XPoster.Services (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedMissingBranchTests (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, Message, OpenAIResponse, OpenAIImageResponse, ImageData, Choice

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), AiServiceFactory(), ArgumentException(), InvalidOperationException(), XPoster.Implementation, if()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), InvalidOperationException(), ResolveAuthorUrnAsync(), generatePayLoad(), Exception(), XPoster.SenderPlugins, using()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Implementation, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), IsEnabled(), Dispose(), XPoster.Tests.Integration

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), PostMissingBranchTests, Firm_IsNotNullOrEmpty()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests(), XPoster.Tests

### Community 42 - "Entity (Community 42)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), XPoster.Services, HybridAiService()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), if(), XPoster.SenderPlugins, catch()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Abstraction

### Community 43 - "Entity (Community 43)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Abstraction, GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync(), IAiService

### Community 46 - "Entity (Community 46)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), CreateFactory(), SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildFalService(), BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService(), Constructor_NullFalAiService_ThrowsArgumentNullException()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, SetSecretAsync(), XPoster.Services, KeyVaultService(), GetSecretAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, return(), XPoster.Services, if(), catch()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, for()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, IsTransientHttpFailure(), AddResilientHttpClient()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, GetSecretAsync(), XPoster.Abstraction, SetSecretAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), XPoster.Implementation, ScheduledOrchestrationProfile()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), if(), foreach()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), XPoster.Implementation, ResolveAiProvider(), Resolve(), foreach()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, catch()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), catch(), XPoster.SenderPlugins, UploadImageToPublicUrl()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), GetFeedsAsync(), XPoster.Services, Exception()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Abstraction, GetFeedsAsync(), IFeedService

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, XPoster.Abstraction, GetCurrentTime()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), XPoster.Implementation, GenerateMessage(), ReplaceEveryFirstOccurenceOf()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Abstraction

### Community 64 - "Entity (Community 64)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Abstraction

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, PostAsync(), IOrchestrator

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, FalAiImageService(), GenerateImageAsync(), XPoster.Services

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, if(), DryRunSlotProfileProvider()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), catch(), if()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), FeedOrchestrator(), foreach()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 86 - "Entity (Community 86)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), OrchestratorFactory(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), BuildImagePromptPayload(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, catch(), Run()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 76 - "Entity (Community 76)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, OpenAiService(), if(), var()

### Community 103 - "Entity (Community 103)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 104 - "Entity (Community 104)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Implementation, GetProfiles()

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 95 - "Entity (Community 95)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 101 - "Entity (Community 101)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 97 - "Entity (Community 97)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 110 - "Entity (Community 110)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

