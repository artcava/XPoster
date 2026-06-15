# Graph Report - XPoster  (2026-06-15)

## Summary
- 720 nodes · 1200 edges · 99 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Abstraction` - 2 edges
5. `HybridAiServiceTests` - 2 edges
6. `XPoster.Tests.Services` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Abstraction` - 2 edges
9. `ICryptoService` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, MakeHandlerMock(), OpenAiService(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, FalAiImageService(), FalImageJson(), FalAiImageServiceTests, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.20
Nodes (19): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), IgSenderTests(), IgSender(), SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithoutImage_DoesNotQueryKv() (+11 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), var(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, IgSender_SendAsync_WithoutImage_DoesNotRequestIgSecrets(), GetSecretAsync_ThrowsWhenSecretNotFound(), HttpFactory(), IgSender_SendAsync_WithImage_RequestsBothIgSecrets(), KeyVaultServiceTests, InSender_SendAsync_RequestsLinkedInOwnerCode() (+8 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), InSenderMissingBranchTests(), MessageMaxLenght_Returns800(), SendAsync_NullPost_ReturnsFalse(), if(), BuildSender() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, NotSupportedException(), GetChatCompletionsEndpoint(), GetSummaryAsync(), if(), GetImagePromptAsync() (+6 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ImageData_CanBeCreated_WithUrl(), ModelsTests, OpenAIImageResponse_CanBeCreated_WithData(), Message_CanBeCreated_WithContent(), RSSFeed_CanBeCreated_WithAllProperties(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), ValidOptions(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty() (+5 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildKeyVaultMock(), InSenderTests() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), BuildSender(), IgSender(), IgSenderResilienceTests, PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound() (+4 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, BuildKeyVaultMock(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_CalledTwice_QueriesKvOnEachCall() (+3 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), BuildHybrid(), Constructor_NullDeepSeekService_ThrowsArgumentNullException() (+3 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetSummaryAsync(), catch(), GenerateImageAsync(), GetImagePromptAsync(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), AzureFoundryService() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, BuildSender(), SendAsync_NullPost_ReturnsFalse(), XSenderMissingBranchTests(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Implementation, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), ProduceImage_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), NoOrchestratorTests() (+2 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, while(), XPoster.Services, GetSummary(), GetPromptForImage(), catch(), GenerateImageAsync(), GetImagePromptAsync() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), XPoster.Tests.Implementation, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, ArgumentException(), AiServiceFactory(), XPoster.Implementation, GetByProvider(), if(), InvalidOperationException()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), ResolveAuthorUrnAsync(), generatePayLoad(), InvalidOperationException(), Exception(), XPoster.SenderPlugins, using()

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, ValidOptions()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, OpenAIImageResponse, Message, ImageData, OpenAIResponse, Choice

### Community 35 - "Entity (Community 35)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, FeedServiceTests()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, PostMissingBranchTests, Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), XPoster.Tests.Implementation

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GenerateImageAsync(), GetSummaryAsync(), GetImagePromptAsync(), XPoster.Services

### Community 38 - "Entity (Community 38)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), XPoster.Abstraction, GetImagePromptAsync(), GetSummaryAsync(), IAiService

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsLocalTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services

### Community 48 - "Entity (Community 48)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, XPoster.Services, catch(), return(), if()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, GetSecretAsync(), SetSecretAsync(), XPoster.Abstraction

### Community 46 - "Entity (Community 46)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests, XFunctionTests()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, if(), foreach(), Validate()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, SetSecretAsync(), GetSecretAsync(), KeyVaultService()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), Resolve(), ResolveAiProvider(), return(), XPoster.Implementation

### Community 44 - "Entity (Community 44)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), XPoster.Tests.Implementation

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Abstraction, ICryptoService, GetCryptoValue()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), catch(), Exception()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, ReplaceEveryFirstOccurenceOf(), GenerateMessage(), catch(), XPoster.Implementation

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Abstraction

### Community 52 - "Entity (Community 52)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, OrchestratorFactory(), ScheduledOrchestrationProfile(), if(), CreateOrchestratorInstance()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Abstraction, GetByProvider(), IAiServiceFactory

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Abstraction, IFeedService, GetFeedsAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), UploadImageToPublicUrl(), catch(), XPoster.SenderPlugins

### Community 54 - "Entity (Community 54)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Abstraction, SendAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Implementation

### Community 58 - "Entity (Community 58)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Services, GetCurrentTime()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), Run(), XPoster

### Community 73 - "Entity (Community 73)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, OpenAiService(), var(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, if(), var(), BuildImagePromptPayload()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), foreach(), FeedOrchestrator()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 66 - "Entity (Community 66)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), XPoster.Tests.Helpers, var()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): InSender.cs, catch(), if(), InSender()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 75 - "Entity (Community 75)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 87 - "Entity (Community 87)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 92 - "Entity (Community 92)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 94 - "Entity (Community 94)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 86 - "Entity (Community 86)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 82 - "Entity (Community 82)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (3): Program.cs, Program.cs, if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 78 - "Entity (Community 78)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 98 - "Entity (Community 98)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 97 - "Entity (Community 97)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

