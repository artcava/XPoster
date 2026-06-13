# Graph Report - XPoster  (2026-06-13)

## Summary
- 566 nodes · 925 edges · 89 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `XPoster.Abstraction` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `ICryptoService` - 2 edges
7. `ISender` - 2 edges
8. `PostMissingBranchTests` - 2 edges
9. `XPoster.Tests.Models` - 2 edges
10. `XPoster.Abstraction` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.19
Nodes (21): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), OpenAiService() (+13 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+13 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.22
Nodes (18): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, BuildService(), AzureFoundryServiceTests, AzureFoundryService(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+10 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), Message_CanBeCreated_WithContent(), ModelsTests (+6 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSender(), MessageMaxLenght_Returns800(), InSenderMissingBranchTests, XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+5 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingTextPlaceholder_Fails(), ValidOptions(), XPoster.Tests.Models (+5 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.32
Nodes (12): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Implementation (+4 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSender(), XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse() (+4 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, AzureFoundryService(), while(), XPoster.Services, GetImageGenerationEndpoint(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), GenerateImageAsync() (+3 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, BuildHybrid(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), DeepSeekService(), ChatCompletionJson(), MakeHandlerMock(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent() (+3 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+2 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, Constructor_InitializesCorrectly(), catch(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), InSenderTests() (+2 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsNull(), NoOrchestratorTests(), Name_IsNoOrchestrator(), SendIt_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService() (+1 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, GetImagePromptAsync(), GetSummaryAsync(), NotSupportedException(), while(), XPoster.Services, GenerateImageAsync(), BuildSummaryPayload() (+1 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), Constructor_WithValidEnvVars_Succeeds(), Constructor_WithMissingAccessToken_ThrowsInvalidOperationException(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithOversizedCaption_StillExecutes() (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Implementation, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), XPoster.Tests.Models (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), PostMissingBranchTests, XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull()

### Community 25 - "Entity (Community 25)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), XPoster.Tests.Implementation, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GetSummaryAsync(), XPoster.Services, while(), GenerateImageAsync(), GetImagePromptAsync(), GetSummary(), GetPromptForImage()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.25
Nodes (8): InSender.cs, catch(), Exception(), ResolveAuthorUrn(), SendAsync(), XPoster.SenderPlugins, using(), generatePayLoad()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), InvalidOperationException(), XPoster.Implementation, GetByProvider(), ArgumentException(), AiServiceFactory()

### Community 23 - "Entity (Community 23)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, Message, OpenAIResponse, OpenAIImageResponse, XPoster.Models

### Community 22 - "Entity (Community 22)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Abstraction

### Community 31 - "Entity (Community 31)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Abstraction, IAiService, GetImagePromptAsync(), GetSummaryAsync(), GenerateImageAsync()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), HybridAiService(), GetImagePromptAsync(), XPoster.Services, GetSummaryAsync()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.33
Nodes (6): OrchestratorFactoryTests.cs, Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(), Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours(), XPoster.Tests.Implementation, Generate_Should_CreateFeedOrchestratorWithXSender_At8AM(), Generate_Should_CreateFeedOrchestratorWithInSender_At6AM()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsLocalTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, XPoster.Implementation, foreach(), ResolveAiProvider(), Resolve(), return()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), BuildFalService(), HybridAiService()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Implementation

### Community 45 - "Entity (Community 45)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, if(), ScheduledOrchestrationProfile(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), ISender, XPoster.Abstraction

### Community 43 - "Entity (Community 43)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 42 - "Entity (Community 42)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Implementation, GenerateMessage(), catch(), ReplaceEveryFirstOccurenceOf()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Abstraction, ITimeProvider

### Community 40 - "Entity (Community 40)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Abstraction, IOrchestratorFactory, Resolve()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 50 - "Entity (Community 50)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Abstraction

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Abstraction

### Community 48 - "Entity (Community 48)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Abstraction, GetFeedsAsync()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), foreach(), FeedOrchestrator()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 58 - "Entity (Community 58)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Implementation

### Community 60 - "Entity (Community 60)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 62 - "Entity (Community 62)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, if(), BuildImagePromptPayload(), DeepSeekService()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 54 - "Entity (Community 54)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, IgSenderTests(), ClearEnvVars(), SetValidEnvVars()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), OrchestratorFactoryTests()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.67
Nodes (3): OpenAiService.cs, OpenAiService(), if()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 78 - "Entity (Community 78)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Abstraction, AiProvider.cs

### Community 79 - "Entity (Community 79)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 76 - "Entity (Community 76)"
Cohesion: 1.00
Nodes (3): Program.cs, if(), Program.cs

### Community 75 - "Entity (Community 75)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 77 - "Entity (Community 77)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 67 - "Entity (Community 67)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 72 - "Entity (Community 72)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 71 - "Entity (Community 71)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 69 - "Entity (Community 69)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 66 - "Entity (Community 66)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): AzureFoundryService.cs, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

