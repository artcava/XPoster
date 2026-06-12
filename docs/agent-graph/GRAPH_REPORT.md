# Graph Report - XPoster  (2026-06-12)

## Summary
- 566 nodes · 925 edges · 89 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Models` - 2 edges
4. `XPoster.Implementation` - 2 edges
5. `ImageData` - 2 edges
6. `Choice` - 2 edges
7. `XPoster.Tests.Services` - 2 edges
8. `OpenAIImageResponse` - 2 edges
9. `OpenAIResponse` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.19
Nodes (21): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiServiceTests, ChatCompletionJson(), BuildService(), GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes() (+13 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+13 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.22
Nodes (18): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent() (+10 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, RSSFeed_CanBeCreated_WithAllProperties(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderMissingBranchTests, BuildSender(), InSender() (+5 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_Fails(), XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests, Validate_DefaultOptions_Succeeds(), Validate_AllPlaceholdersMissing_ReportsThreeFailures() (+5 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, XSender(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse() (+4 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.32
Nodes (12): FeedGeneratorTests.cs, FeedGeneratorTests.cs, GenerateAsync_Should_ReturnNull_When_SummaryGenerationFails(), GenerateAsync_Should_ReturnNull_When_SenderIsNull(), GenerateAsync_Should_ReturnNull_When_AiServiceIsNull(), GenerateAsync_Should_ReturnNull_When_NoFeedsFound(), XPoster.Tests.Implementation, GenerateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull() (+4 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, XPoster.Tests.Services, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), HybridAiServiceTests, MakeHandlerMock(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException() (+3 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, GetChatCompletionsEndpoint(), BuildImagePromptPayload(), GenerateImageAsync(), BuildSummaryPayload(), XPoster.Services, GetImagePromptAsync(), GetSummaryAsync() (+3 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.38
Nodes (10): NoGeneratorTests.cs, NoGeneratorTests.cs, Name_IsNoGenerator(), GenerateAsync_ReturnsNull(), ProduceImage_Set_ThrowsNotImplementedException(), XPoster.Tests.Implementation, SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse() (+2 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, catch(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), InSenderTests() (+2 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), catch(), XSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, SendAsync_WithOversizedCaption_StillExecutes(), SendAsync_WithNoImage_ReturnsFalse(), Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), Constructor_WithValidEnvVars_Succeeds(), XPoster.Tests.SenderPlugins (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.42
Nodes (9): PowerLawGeneratorTests.cs, PowerLawGeneratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Implementation, PowerLawGeneratorTests(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, BuildSummaryPayload(), while(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), NotSupportedException(), GetSummaryAsync(), GenerateImageAsync() (+1 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), CryptoServiceTests (+1 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, OpenAIImageResponse, OpenAIResponse, XPoster.Models, Message

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests()

### Community 23 - "Entity (Community 23)"
Cohesion: 0.25
Nodes (8): InSender.cs, Exception(), catch(), SendAsync(), using(), XPoster.SenderPlugins, generatePayLoad(), ResolveAuthorUrn()

### Community 22 - "Entity (Community 22)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GetPromptForImage(), GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync(), XPoster.Services, while(), GetSummary()

### Community 25 - "Entity (Community 25)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), XPoster.Implementation, InvalidOperationException(), GetByProvider(), ArgumentException(), AiServiceFactory()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostMissingBranchTests, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties()

### Community 30 - "Entity (Community 30)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_GenerateAsync_ReturnsNull(), XFunctionMissingBranchTests(), XPoster.Tests

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (7): BaseGeneratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Abstraction, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), IAiService

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetSummaryAsync(), HybridAiService(), XPoster.Services, GenerateImageAsync(), GetImagePromptAsync()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests

### Community 39 - "Entity (Community 39)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsLocalTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.33
Nodes (6): GeneratorFactoryTests.cs, Generate_Should_CreateNoGenerator_AtUnscheduledHours(), Generate_Should_CreateFeedGeneratorWithInSender_At6AM(), Generate_Should_CreateFeedGeneratorWithXSender_At8AM(), XPoster.Tests.Implementation, Generate_Should_ReturnCorrectGeneratorType_BasedOnHour()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.33
Nodes (6): GeneratorFactory.cs, ResolveAiProvider(), Generate(), return(), XPoster.Implementation, foreach()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), BuildFalService()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.33
Nodes (6): BaseGeneratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestGenerator(), BaseGeneratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 45 - "Entity (Community 45)"
Cohesion: 0.70
Nodes (5): PowerLawGenerator.cs, PowerLawGenerator.cs, if(), XPoster.Implementation, PowerLawGenerator()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Services

### Community 43 - "Entity (Community 43)"
Cohesion: 0.40
Nodes (5): FeedGenerator.cs, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Implementation

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, GetByProvider(), XPoster.Abstraction

### Community 49 - "Entity (Community 49)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, GetFeedsAsync(), XPoster.Abstraction

### Community 48 - "Entity (Community 48)"
Cohesion: 0.70
Nodes (5): IGenerator.cs, IGenerator.cs, IGenerator, PostAsync(), XPoster.Abstraction

### Community 50 - "Entity (Community 50)"
Cohesion: 0.40
Nodes (5): GeneratorFactory.cs, GeneratorFactory(), CreateGeneratorInstance(), ScheduledGenerationProfile(), if()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Abstraction, ISender, SendAsync()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Abstraction, GetCryptoValue(), ICryptoService

### Community 42 - "Entity (Community 42)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Abstraction

### Community 41 - "Entity (Community 41)"
Cohesion: 0.70
Nodes (5): IGeneratorFactory.cs, IGeneratorFactory.cs, Generate(), XPoster.Abstraction, IGeneratorFactory

### Community 52 - "Entity (Community 52)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), Exception(), GetFeedsAsync()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 60 - "Entity (Community 60)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), Run(), XPoster

### Community 62 - "Entity (Community 62)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 61 - "Entity (Community 61)"
Cohesion: 0.50
Nodes (4): GeneratorFactoryTests.cs, SetupMocksForGeneratorFactory(), Generate_Should_RequestOpenAiProvider_ForScheduledFeedSlot(), GeneratorFactoryTests()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.50
Nodes (4): BaseGenerator.cs, BaseGenerator(), PostAsync(), XPoster.Abstraction

### Community 58 - "Entity (Community 58)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, SetValidEnvVars(), IgSenderTests(), ClearEnvVars()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.83
Nodes (4): ScheduledGenerationProfile.cs, ScheduledGenerationProfile.cs, XPoster.Abstraction, ScheduledGenerationProfile()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.50
Nodes (4): FeedGenerator.cs, foreach(), if(), FeedGenerator()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, GetCryptoValue(), catch()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.83
Nodes (4): NoGenerator.cs, NoGenerator.cs, NoGenerator(), XPoster.Implementation

### Community 64 - "Entity (Community 64)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, if(), DeepSeekService(), BuildImagePromptPayload()

### Community 80 - "Entity (Community 80)"
Cohesion: 1.00
Nodes (3): Program.cs, if(), Program.cs

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, catch(), if()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 73 - "Entity (Community 73)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 67 - "Entity (Community 67)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 72 - "Entity (Community 72)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 68 - "Entity (Community 68)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 71 - "Entity (Community 71)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 69 - "Entity (Community 69)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 78 - "Entity (Community 78)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Abstraction, Enums.cs

### Community 79 - "Entity (Community 79)"
Cohesion: 0.67
Nodes (3): OpenAiService.cs, OpenAiService(), if()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 75 - "Entity (Community 75)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 77 - "Entity (Community 77)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 66 - "Entity (Community 66)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): AzureFoundryService.cs, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (2): BaseGenerator.cs, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

