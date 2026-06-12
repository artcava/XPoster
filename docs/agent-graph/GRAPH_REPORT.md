# Graph Report - XPoster  (2026-06-12)

## Summary
- 566 nodes · 925 edges · 89 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `DeepSeekOptionsTests` - 2 edges
2. `XPoster.Abstraction` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `IFeedService` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `ITimeProvider` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Tests.Services` - 2 edges
9. `TimeProviderTests` - 2 edges
10. `XPoster.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), ChatCompletionJson(), GenerateImageAsync_AlwaysThrows_NotSupportedException(), DeepSeekServiceTests, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.19
Nodes (21): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiServiceTests, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty() (+13 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.22
Nodes (18): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+10 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, ImageData_CanBeCreated_WithUrl(), Post_CanHold_ImageBytes(), Choice_CanBeCreated_WithMessage(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, BuildSender(), InSenderMissingBranchTests, InSender(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhitespaceContent_ReturnsFalse() (+5 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), ValidOptions(), Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models (+5 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XSenderMissingBranchTests, XPoster.Tests.SenderPlugins, SendAsync_WhitespaceContent_ReturnsFalse(), XSender(), SendAsync_NullPost_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse() (+4 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.32
Nodes (12): FeedGeneratorTests.cs, FeedGeneratorTests.cs, XPoster.Tests.Implementation, FeedGeneratorTests(), GenerateAsync_Should_ApplyHashtagsCorrectly(), GenerateAsync_Should_ReturnNull_When_SummaryGenerationFails(), GenerateAsync_Should_ReturnNull_When_AiServiceIsNull(), GenerateAsync_Should_ReturnNull_When_NoFeedsFound() (+4 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, AzureFoundryService(), BuildImagePromptPayload(), GenerateImageAsync(), GetImagePromptAsync(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint(), GetSummaryAsync() (+3 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), HybridAiServiceTests, MakeHandlerMock(), GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), FalAiImageService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), ChatCompletionJson() (+3 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, Constructor_InitializesCorrectly(), catch(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSenderTests(), InSender_ImplementsISender() (+2 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), catch(), XSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.38
Nodes (10): NoGeneratorTests.cs, NoGeneratorTests.cs, SendIt_Set_ThrowsNotImplementedException(), ProduceImage_IsAlwaysFalse(), SendIt_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException(), Name_IsNoGenerator(), GenerateAsync_ReturnsNull() (+2 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, NotSupportedException(), while(), XPoster.Services, GetImagePromptAsync(), BuildSummaryPayload(), GenerateImageAsync(), GetChatCompletionsEndpoint() (+1 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.42
Nodes (9): PowerLawGeneratorTests.cs, PowerLawGeneratorTests.cs, XPoster.Tests.Implementation, GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithOversizedCaption_StillExecutes(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImageArray_ReturnsFalse(), Constructor_WithValidEnvVars_Succeeds(), Constructor_WithMissingAccountId_ThrowsInvalidOperationException() (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GetPromptForImage(), GetImagePromptAsync(), GenerateImageAsync(), while(), GetSummaryAsync(), XPoster.Services, GetSummary()

### Community 28 - "Entity (Community 28)"
Cohesion: 0.25
Nodes (8): InSender.cs, ResolveAuthorUrn(), SendAsync(), using(), XPoster.SenderPlugins, Exception(), catch(), generatePayLoad()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests()

### Community 23 - "Entity (Community 23)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models

### Community 22 - "Entity (Community 22)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostMissingBranchTests, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties()

### Community 25 - "Entity (Community 25)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, InvalidOperationException(), XPoster.Implementation, ArgumentException(), AiServiceFactory(), if(), GetByProvider()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIImageResponse, OpenAIResponse, XPoster.Models, ImageData, Choice, Message

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (7): BaseGeneratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Abstraction, PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, IAiService, XPoster.Abstraction, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_GenerateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, XFunctionMissingBranchTests()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), HybridAiService(), XPoster.Services, GetSummaryAsync()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.33
Nodes (6): BaseGeneratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseGeneratorTests(), TestGenerator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, GetCurrentTime_ReturnsLocalTime(), TimeProviderTests

### Community 35 - "Entity (Community 35)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), XPoster.Tests

### Community 34 - "Entity (Community 34)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildFalService(), HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.33
Nodes (6): GeneratorFactoryTests.cs, Generate_Should_CreateNoGenerator_AtUnscheduledHours(), Generate_Should_ReturnCorrectGeneratorType_BasedOnHour(), XPoster.Tests.Implementation, Generate_Should_CreateFeedGeneratorWithInSender_At6AM(), Generate_Should_CreateFeedGeneratorWithXSender_At8AM()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.33
Nodes (6): GeneratorFactory.cs, return(), XPoster.Implementation, foreach(), ResolveAiProvider(), Generate()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Abstraction

### Community 41 - "Entity (Community 41)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Abstraction, ITimeProvider

### Community 46 - "Entity (Community 46)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Abstraction

### Community 45 - "Entity (Community 45)"
Cohesion: 0.70
Nodes (5): IGenerator.cs, IGenerator.cs, IGenerator, XPoster.Abstraction, PostAsync()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), XPoster.Abstraction, IAiServiceFactory

### Community 51 - "Entity (Community 51)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.40
Nodes (5): FeedGenerator.cs, catch(), XPoster.Implementation, ReplaceEveryFirstOccurenceOf(), GenerateMessage()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): IGeneratorFactory.cs, IGeneratorFactory.cs, IGeneratorFactory, XPoster.Abstraction, Generate()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), catch(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 48 - "Entity (Community 48)"
Cohesion: 0.40
Nodes (5): GeneratorFactory.cs, CreateGeneratorInstance(), ScheduledGenerationProfile(), if(), GeneratorFactory()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.70
Nodes (5): PowerLawGenerator.cs, PowerLawGenerator.cs, PowerLawGenerator(), if(), XPoster.Implementation

### Community 43 - "Entity (Community 43)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Abstraction, SendAsync()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), catch(), XPoster.SenderPlugins

### Community 54 - "Entity (Community 54)"
Cohesion: 0.50
Nodes (4): GeneratorFactoryTests.cs, GeneratorFactoryTests(), Generate_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), SetupMocksForGeneratorFactory()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): BaseGenerator.cs, BaseGenerator(), XPoster.Abstraction, PostAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.83
Nodes (4): NoGenerator.cs, NoGenerator.cs, NoGenerator(), XPoster.Implementation

### Community 58 - "Entity (Community 58)"
Cohesion: 0.83
Nodes (4): ScheduledGenerationProfile.cs, ScheduledGenerationProfile.cs, XPoster.Abstraction, ScheduledGenerationProfile()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 60 - "Entity (Community 60)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, ClearEnvVars(), IgSenderTests(), SetValidEnvVars()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 61 - "Entity (Community 61)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, if(), BuildImagePromptPayload(), DeepSeekService()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.50
Nodes (4): FeedGenerator.cs, foreach(), if(), FeedGenerator()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 81 - "Entity (Community 81)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 83 - "Entity (Community 83)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 82 - "Entity (Community 82)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 73 - "Entity (Community 73)"
Cohesion: 1.00
Nodes (3): Program.cs, if(), Program.cs

### Community 74 - "Entity (Community 74)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 75 - "Entity (Community 75)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 78 - "Entity (Community 78)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 77 - "Entity (Community 77)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 67 - "Entity (Community 67)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 72 - "Entity (Community 72)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.67
Nodes (3): OpenAiService.cs, OpenAiService(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (2): AzureFoundryService.cs, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (2): BaseGenerator.cs, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

