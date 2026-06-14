# Graph Report - XPoster  (2026-06-14)

## Summary
- 688 nodes · 1145 edges · 97 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Abstraction` - 2 edges
2. `XPoster.Models` - 2 edges
3. `DeepSeekOptionsTests` - 2 edges
4. `XPoster.Tests.Models` - 2 edges
5. `XPoster.Tests.SenderPlugins` - 2 edges
6. `XPoster.Implementation` - 2 edges
7. `XPoster.SenderPlugins` - 2 edges
8. `XPoster.Implementation` - 2 edges
9. `IAiServiceFactory` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.13
Nodes (30): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty() (+22 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.15
Nodes (27): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), AzureFoundryService() (+19 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), MakeHandlerMock(), XPoster.Tests.Services (+13 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.19
Nodes (20): FalAiImageServiceTests.cs, FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeHandlerMock(), XPoster.Tests.Services, FalAiImageService(), BuildService(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+12 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.22
Nodes (18): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ChatJson(), AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty() (+10 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.27
Nodes (14): DeepSeekService.cs, DeepSeekService.cs, BuildImagePromptPayload(), GetImagePromptAsync(), DeepSeekService(), GenerateImageAsync(), GetChatCompletionsEndpoint(), while() (+6 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes() (+6 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), InSender(), BuildSender() (+5 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), ValidOptions(), FalAiOptionsValidatorTests, Validate_MissingModelId_Fails() (+5 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.17
Nodes (12): IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), Constructor_WithMissingAccountId_ThrowsOrHandlesGracefully(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+4 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), BuildSender(), XSenderMissingBranchTests, XSender(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+4 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), IgSenderResilienceTests, IgSender(), BuildSender(), XPoster.Tests.SenderPlugins, PostWithoutImage() (+4 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Implementation, OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ApplyHashtagsCorrectly() (+4 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, XPoster.Services, GetImageGenerationEndpoint(), GenerateImageAsync(), GetSummaryAsync(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), while() (+3 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, FalAiImageService(), BuildHybrid(), ChatCompletionJson(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), HybridAiServiceTests, XPoster.Tests.Services (+3 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, BuildSender(), InSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), XPoster.Tests.SenderPlugins (+3 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), Constructor_InitializesCorrectly(), XSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully(), catch(), XPoster.Tests.SenderPlugins (+2 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, ProduceImage_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), Name_IsNoOrchestrator(), NoOrchestratorTests(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), CryptoServiceTests, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), XPoster.Tests.Models, RSSFeedMissingBranchTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.22
Nodes (9): OpenAiService.cs, GetImagePromptAsync(), XPoster.Services, GetSummaryAsync(), GetSummary(), while(), GetPromptForImage(), catch() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), PowerLawOrchestratorTests(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), XPoster.Tests.Implementation, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, ValidOptions()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.25
Nodes (8): InSender.cs, ResolveAuthorUrn(), using(), SendAsync(), XPoster.SenderPlugins, Exception(), catch(), generatePayLoad()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_EmptyContent_IsAllowed(), XPoster.Tests.Models

### Community 30 - "Entity (Community 30)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Message, OpenAIImageResponse, OpenAIResponse, XPoster.Models, Choice

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, AiServiceFactory(), GetByProvider(), ArgumentException(), XPoster.Implementation, if(), InvalidOperationException()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersByKeyword_AndDate(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), FeedServiceTests(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_SetsCache_WhenFeedsFetched()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests

### Community 38 - "Entity (Community 38)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), HybridAiService(), GetSummaryAsync(), GetImagePromptAsync(), XPoster.Services

### Community 36 - "Entity (Community 36)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetSummaryAsync(), GetImagePromptAsync(), GenerateImageAsync(), IAiService, XPoster.Abstraction

### Community 37 - "Entity (Community 37)"
Cohesion: 0.29
Nodes (7): IgSenderTests.cs, ClearEnvVars(), catch(), Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully(), SetValidEnvVars(), SendAsync_WithNoImage_TriesHttpAndReturnsFalse(), IgSenderTests()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.60
Nodes (6): AiServiceHelper.cs, AiServiceHelper.cs, if(), XPoster.Services, catch(), return()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 47 - "Entity (Community 47)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), ResolveAiProvider(), foreach(), Resolve(), XPoster.Implementation

### Community 46 - "Entity (Community 46)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, XPoster.Tests.Implementation, Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsLocalTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services

### Community 45 - "Entity (Community 45)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildFalService(), HybridAiService()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, foreach(), if(), Validate()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory(), ScheduledOrchestrationProfile()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 54 - "Entity (Community 54)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), catch(), GenerateMessage()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Implementation, PowerLawOrchestrator(), if()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, XPoster.Abstraction, GetByProvider()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Abstraction, IOrchestrator, PostAsync()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Abstraction, IFeedService

### Community 49 - "Entity (Community 49)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, Exception(), GetFeedsAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Abstraction

### Community 56 - "Entity (Community 56)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 57 - "Entity (Community 57)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Abstraction, ITimeProvider, GetCurrentTime()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 65 - "Entity (Community 65)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Implementation, NoOrchestrator()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.50
Nodes (4): AzureFoundryService.cs, BuildImagePromptPayload(), if(), var()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, FalAiImageService()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), XPoster.Services, GetCryptoValue()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.50
Nodes (4): OpenAiService.cs, var(), OpenAiService(), if()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 66 - "Entity (Community 66)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), Run(), XPoster

### Community 69 - "Entity (Community 69)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 67 - "Entity (Community 67)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 68 - "Entity (Community 68)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), foreach(), FeedOrchestrator()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (3): if(), Program.cs, Program.cs

### Community 78 - "Entity (Community 78)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): XPoster.Abstraction, Enums.cs, Enums.cs

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 87 - "Entity (Community 87)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 89 - "Entity (Community 89)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 91 - "Entity (Community 91)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 90 - "Entity (Community 90)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 92 - "Entity (Community 92)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 96 - "Entity (Community 96)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 95 - "Entity (Community 95)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 94 - "Entity (Community 94)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 93 - "Entity (Community 93)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

