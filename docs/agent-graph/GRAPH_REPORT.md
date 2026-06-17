# Graph Report - XPoster  (2026-06-17)

## Summary
- 841 nodes · 1403 edges · 115 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Tests.SenderPlugins` - 2 edges
3. `PostMissingBranchTests` - 2 edges
4. `XPoster.Tests.Models` - 2 edges
5. `XPoster.Implementation` - 2 edges
6. `XPoster.Services` - 2 edges
7. `TimeProvider` - 2 edges
8. `XPoster.Services` - 2 edges
9. `XPoster.Tests.Integration` - 2 edges
10. `XPoster.Tests.Implementation` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), if(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithoutImage_DoesNotQueryKv(), SendAsync_WithWhitespaceContent_ReturnsFalse(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+16 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), DeepSeekService(), ChatCompletionJson(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, MessageMaxLenght_ReturnsIntMaxValue(), DryRunSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSenderTests(), SendAsync_WhenKeyVaultProbeSucceeds_ProbesXApiKey(), new() (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), BuildService(), FalImageJson(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, new(), AiServiceHelperTests, ChatJson(), MakeResponse(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty() (+10 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), GetSecretAsync_ReturnsExpectedValue(), HttpFactory(), GetSecretAsync_ThrowsWhenSecretNotFound(), KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), InSender_SendAsync_RequestsLinkedInAccessToken() (+8 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), Post_CanHold_ImageBytes(), XPoster.Tests.Models, OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), if() (+6 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, var(), GetSummaryAsync(), if(), NotSupportedException(), DeepSeekService() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails(), XPoster.Tests.Models (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), InSender_ImplementsISender() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, XPoster.Tests.Services, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull() (+4 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), new(), PostWithoutImage(), PostWithImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), BuildSender(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, XPoster.Services, AzureFoundryService(), BuildSummaryPayload(), GetSummaryAsync(), catch(), GenerateImageAsync(), GetChatCompletionsEndpoint() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, FalAiImageService(), DeepSeekService(), BuildHybrid(), ChatCompletionJson(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvOnEachCall(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender(), InSender(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsNull(), XPoster.Tests.Implementation, SendIt_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse() (+2 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), OrchestratorFactory(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, GenerateImageAsync(), catch(), GetPromptForImage(), GetSummaryAsync(), GetSummary(), while(), XPoster.Services (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Implementation, PowerLawOrchestratorTests(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), params(), var(), XPoster.Tests.Integration, BuildDelayedHandler(), BuildSequenceHandler() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoService() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), PostMissingBranchTests, XPoster.Tests.Models, Firm_IsNotNullOrEmpty()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, Dispose(), IsEnabled(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIResponse, OpenAIImageResponse, ImageData, Message, Choice

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_ValidOptions_Succeeds()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, AiServiceFactory(), XPoster.Implementation, GetByProvider(), InvalidOperationException(), ArgumentException(), if()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.25
Nodes (8): InSender.cs, ResolveAuthorUrnAsync(), SendAsync(), using(), XPoster.SenderPlugins, generatePayLoad(), Exception(), InvalidOperationException()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), CreateFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), SetupMocksForOrchestratorFactory()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GetImagePromptAsync(), GenerateImageAsync(), XPoster.Services, GetSummaryAsync()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), IAiService, XPoster.Abstraction, GetSummaryAsync(), GetImagePromptAsync()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, DryRunSender(), catch(), if(), SendAsync(), XPoster.SenderPlugins

### Community 49 - "Entity (Community 49)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), IsTransientHttpFailure(), XPoster.Extensions, AddResilientHttpClient()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, return(), XPoster.Services, if(), catch()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), HybridAiService(), BuildFalService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, XPoster.Implementation, ResolveAiProvider(), Resolve(), foreach(), return()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, GetSecretAsync(), XPoster.Abstraction, SetSecretAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), XPoster.Implementation, ScheduledOrchestrationProfile()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), BaseOrchestratorTests()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), foreach(), if()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, SetSecretAsync(), XPoster.Services, KeyVaultService(), GetSecretAsync()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Abstraction

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 70 - "Entity (Community 70)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), GetFeedsAsync(), Exception()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Abstraction

### Community 66 - "Entity (Community 66)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Abstraction

### Community 67 - "Entity (Community 67)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Abstraction, Resolve()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Abstraction, SendAsync()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, GetCurrentTime(), ITimeProvider

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Abstraction

### Community 61 - "Entity (Community 61)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync(), catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, DryRunSlotProfileProvider(), if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, BaseOrchestrator(), PostAsync()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), BuildImagePromptPayload(), if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), FeedOrchestrator(), foreach()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 90 - "Entity (Community 90)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 86 - "Entity (Community 86)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 85 - "Entity (Community 85)"
Cohesion: 0.50
Nodes (4): InSender.cs, if(), InSender(), catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), var(), OpenAiService()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, catch(), Run()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 104 - "Entity (Community 104)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 102 - "Entity (Community 102)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 95 - "Entity (Community 95)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 101 - "Entity (Community 101)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 96 - "Entity (Community 96)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Implementation, GetProfiles()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 99 - "Entity (Community 99)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 110 - "Entity (Community 110)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

