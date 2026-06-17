# Graph Report - XPoster  (2026-06-17)

## Summary
- 855 nodes · 1428 edges · 117 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Models` - 2 edges
5. `XPoster.Implementation` - 2 edges
6. `XPoster.Implementation` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Abstraction` - 2 edges
10. `XPoster.Tests.Helpers` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), XPoster.Tests.Services, OpenAiServiceTests, GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), new(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError() (+16 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), MakeHandlerMock(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, ValidPost(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithImageBytes_LogsImagePresence(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue(), SendAsync_WhenKeyVaultProbeThrows_LogsError() (+12 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), FalAiImageServiceTests (+12 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ChatJson(), MakeResponse(), new(), AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), AzureFoundryServiceTests, BuildService(), GenerateImageAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint() (+9 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, StubHttpMessageHandler(), XSender_SendAsync_RequestsAllFourXCredentials(), XPoster.Tests.Services, GetSecretAsync_OnRotation_ReturnsNewValueOnNextCall(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), GetSecretAsync_ReturnsExpectedValue() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.13
Nodes (15): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), HttpResponseMessage(), if(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), ChatCompletionJson(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint() (+7 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), XPoster.Tests.SenderPlugins, MessageMaxLenght_Returns800() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), OpenAIImageResponse_CanBeCreated_WithData(), ModelsTests, Message_CanBeCreated_WithContent(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, BuildSummaryPayload(), DeepSeekService(), BuildImagePromptPayload(), GetChatCompletionsEndpoint(), GetImagePromptAsync() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), OpenAiOptionsValidatorTests, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), XPoster.Tests.Models (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), new(), PostWithImage(), PostWithoutImage() (+4 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), FeedOrchestratorTests(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_CalledTwice_QueriesKvOnEachCall(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildKeyVaultMock(), Constructor_InitializesCorrectly() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), XSenderMissingBranchTests(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), XPoster.Tests.SenderPlugins (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetImagePromptAsync(), BuildSummaryPayload(), catch(), GenerateImageAsync(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint(), XPoster.Services (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, FalAiImageService(), BuildHybrid(), DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), ChatCompletionJson(), HybridAiServiceTests, XPoster.Tests.Services (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), XPoster.Tests.Implementation, SendIt_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), XPoster.Tests.Implementation, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), OrchestratorFactory() (+2 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), CryptoService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), params(), BuildProviderWithHandler(), BuildDelayedHandler(), BuildSequenceHandler(), HttpResponseMessage() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, while(), catch(), GetSummaryAsync(), GetImagePromptAsync(), GenerateImageAsync(), GetPromptForImage(), GetSummary() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, XPoster.Tests.Implementation, GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), PowerLawOrchestratorTests() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), XPoster.Implementation, InvalidOperationException(), ArgumentException(), AiServiceFactory(), GetByProvider()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, FeedServiceTests(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_SetsCache_WhenFeedsFetched()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), XPoster.Tests.Models, Post_DefaultImageIsNull(), PostMissingBranchTests, Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.25
Nodes (8): InSender.cs, Exception(), generatePayLoad(), XPoster.SenderPlugins, SendAsync(), using(), InvalidOperationException(), ResolveAuthorUrnAsync()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), XPoster.Tests.Implementation, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIImageResponse, OpenAIResponse, Message, Choice, ImageData

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider(), Dispose(), CreateLogger()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests

### Community 48 - "Entity (Community 48)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), OrchestratorFactoryTests(), CreateFactoryWithProfiles(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), SetupMocksForOrchestratorFactory()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), IAiService, GetSummaryAsync(), GetImagePromptAsync(), XPoster.Abstraction

### Community 45 - "Entity (Community 45)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, DryRunSender(), catch(), SendAsync(), if()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), HybridAiService(), GetImagePromptAsync(), GenerateImageAsync(), XPoster.Services

### Community 44 - "Entity (Community 44)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions, IsTransientHttpFailure()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 56 - "Entity (Community 56)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, SetSecretAsync(), IKeyVaultService, GetSecretAsync(), XPoster.Abstraction

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, catch(), XPoster.Services, if(), return()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, if(), foreach(), Validate()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, XPoster.Implementation, return(), foreach(), Resolve(), ResolveAiProvider()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), XPoster.Tests.Integration

### Community 52 - "Entity (Community 52)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 50 - "Entity (Community 50)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, KeyVaultService(), GetSecretAsync(), SetSecretAsync()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Implementation, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration

### Community 49 - "Entity (Community 49)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), BuildFalService()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), UploadImageToPublicUrl(), SendAsync(), XPoster.SenderPlugins

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Abstraction, ITimeProvider

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Abstraction, ISender, SendAsync()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Abstraction, GetProfiles(), ISlotProfileProvider

### Community 68 - "Entity (Community 68)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Abstraction, IOrchestratorFactory

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Abstraction, IOrchestrator

### Community 63 - "Entity (Community 63)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Abstraction

### Community 62 - "Entity (Community 62)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), XPoster.Abstraction, IAiServiceFactory

### Community 66 - "Entity (Community 66)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, GenerateMessage(), ReplaceEveryFirstOccurenceOf(), catch(), XPoster.Implementation

### Community 65 - "Entity (Community 65)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 85 - "Entity (Community 85)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 82 - "Entity (Community 82)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), foreach(), if()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 89 - "Entity (Community 89)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), catch(), if()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, if(), DryRunSlotProfileProvider()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), catch(), XPoster

### Community 78 - "Entity (Community 78)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, if(), OpenAiService(), var()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, var(), if(), BuildImagePromptPayload()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 95 - "Entity (Community 95)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Implementation

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, AiProvider.cs, AiProvider.cs

### Community 100 - "Entity (Community 100)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 99 - "Entity (Community 99)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

