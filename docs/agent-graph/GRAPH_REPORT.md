# Graph Report - XPoster  (2026-06-13)

## Summary
- 566 nodes · 925 edges · 89 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Models` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `RSSFeedMissingBranchTests` - 2 edges
4. `IGeneratorFactory` - 2 edges
5. `XPoster.Abstraction` - 2 edges
6. `ITimeProvider` - 2 edges
7. `XPoster.Abstraction` - 2 edges
8. `ICryptoService` - 2 edges
9. `ImageData` - 2 edges
10. `Choice` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 1 - "Entity (Community 1)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GenerateImageAsync_AlwaysThrows_NotSupportedException(), DeepSeekServiceTests, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 0 - "Entity (Community 0)"
Cohesion: 0.19
Nodes (21): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), ChatCompletionJson(), BuildService(), OpenAiServiceTests, XPoster.Tests.Services (+13 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.22
Nodes (18): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray() (+10 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), OpenAIImageResponse_CanBeCreated_WithData(), Message_CanBeCreated_WithContent(), ModelsTests (+6 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingTextPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), ValidOptions(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures() (+5 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), InSender(), MessageMaxLenght_Returns800(), InSenderMissingBranchTests (+5 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.32
Nodes (12): FeedGeneratorTests.cs, FeedGeneratorTests.cs, GenerateAsync_Should_ReturnNull_When_AiServiceIsNull(), GenerateAsync_Should_ReturnNull_When_NoFeedsFound(), GenerateAsync_Should_ReturnNull_When_SenderIsNull(), GenerateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), XPoster.Tests.Implementation, FeedGeneratorTests() (+4 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.32
Nodes (12): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), BuildSender() (+4 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), FalAiImageService() (+3 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.18
Nodes (11): AzureFoundryService.cs, AzureFoundryService(), GetChatCompletionsEndpoint(), BuildImagePromptPayload(), BuildSummaryPayload(), GenerateImageAsync(), XPoster.Services, GetImagePromptAsync() (+3 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.38
Nodes (10): NoGeneratorTests.cs, NoGeneratorTests.cs, Name_IsNoGenerator(), GenerateAsync_ReturnsNull(), ProduceImage_Set_ThrowsNotImplementedException(), XPoster.Tests.Implementation, SendIt_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse() (+2 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.38
Nodes (10): InSenderTests.cs, InSenderTests.cs, catch(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), InSenderTests() (+2 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, Constructor_InitializesCorrectly(), catch() (+2 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedMissingBranchTests, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual() (+1 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests (+1 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models (+1 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.22
Nodes (9): DeepSeekService.cs, GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, while(), NotSupportedException(), GenerateImageAsync(), BuildSummaryPayload() (+1 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.42
Nodes (9): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithMissingOwner_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse() (+1 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.42
Nodes (9): PowerLawGeneratorTests.cs, PowerLawGeneratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), XPoster.Tests.Implementation (+1 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (9): IgSenderTests.cs, Constructor_WithMissingAccountId_ThrowsInvalidOperationException(), Constructor_WithValidEnvVars_Succeeds(), Constructor_WithMissingAccessToken_ThrowsInvalidOperationException(), SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithOversizedCaption_StillExecutes(), XPoster.Tests.SenderPlugins (+1 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, PostMissingBranchTests, Post_DefaultImageIsNull()

### Community 29 - "Entity (Community 29)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, OpenAIResponse, XPoster.Models, Message, OpenAIImageResponse

### Community 28 - "Entity (Community 28)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services, GetFeedsAsync_FiltersByKeyword_AndDate(), FeedServiceTests(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed()

### Community 24 - "Entity (Community 24)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), ArgumentException(), AiServiceFactory(), if(), XPoster.Implementation, InvalidOperationException()

### Community 23 - "Entity (Community 23)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), using(), XPoster.SenderPlugins, generatePayLoad(), Exception(), catch(), ResolveAuthorUrn()

### Community 25 - "Entity (Community 25)"
Cohesion: 0.25
Nodes (8): OpenAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, while(), GetPromptForImage(), GetSummary()

### Community 27 - "Entity (Community 27)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Implementation, AiServiceFactoryTests(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 26 - "Entity (Community 26)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (7): BaseGeneratorTests.cs, XPoster.Tests.Abstraction, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse()

### Community 31 - "Entity (Community 31)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GetSummaryAsync(), HybridAiService(), GetImagePromptAsync(), GenerateImageAsync()

### Community 32 - "Entity (Community 32)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_GenerateAsync_ReturnsNull(), XFunctionMissingBranchTests(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws()

### Community 33 - "Entity (Community 33)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), IAiService, XPoster.Abstraction, GetSummaryAsync()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsLocalTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsCurrentDateTime()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.33
Nodes (6): BaseGeneratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseGeneratorTests(), TestGenerator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests()

### Community 35 - "Entity (Community 35)"
Cohesion: 0.33
Nodes (6): GeneratorFactoryTests.cs, Generate_Should_ReturnCorrectGeneratorType_BasedOnHour(), XPoster.Tests.Implementation, Generate_Should_CreateFeedGeneratorWithInSender_At6AM(), Generate_Should_CreateNoGenerator_AtUnscheduledHours(), Generate_Should_CreateFeedGeneratorWithXSender_At8AM()

### Community 34 - "Entity (Community 34)"
Cohesion: 0.33
Nodes (6): GeneratorFactory.cs, XPoster.Implementation, foreach(), ResolveAiProvider(), Generate(), return()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.70
Nodes (5): IGeneratorFactory.cs, IGeneratorFactory.cs, IGeneratorFactory, Generate(), XPoster.Abstraction

### Community 41 - "Entity (Community 41)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Abstraction, ITimeProvider

### Community 44 - "Entity (Community 44)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 43 - "Entity (Community 43)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Abstraction, ICryptoService

### Community 46 - "Entity (Community 46)"
Cohesion: 0.70
Nodes (5): PowerLawGenerator.cs, PowerLawGenerator.cs, PowerLawGenerator(), if(), XPoster.Implementation

### Community 45 - "Entity (Community 45)"
Cohesion: 0.40
Nodes (5): FeedGenerator.cs, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Implementation

### Community 49 - "Entity (Community 49)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.40
Nodes (5): GeneratorFactory.cs, GeneratorFactory(), CreateGeneratorInstance(), ScheduledGenerationProfile(), if()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.70
Nodes (5): IGenerator.cs, IGenerator.cs, XPoster.Abstraction, IGenerator, PostAsync()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Abstraction, GetFeedsAsync()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Abstraction, SendAsync(), ISender

### Community 47 - "Entity (Community 47)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, IAiServiceFactory, GetByProvider(), XPoster.Abstraction

### Community 48 - "Entity (Community 48)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 53 - "Entity (Community 53)"
Cohesion: 0.50
Nodes (4): IgSenderTests.cs, IgSenderTests(), ClearEnvVars(), SetValidEnvVars()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.50
Nodes (4): GeneratorFactoryTests.cs, GeneratorFactoryTests(), SetupMocksForGeneratorFactory(), Generate_Should_RequestOpenAiProvider_ForScheduledFeedSlot()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 64 - "Entity (Community 64)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 60 - "Entity (Community 60)"
Cohesion: 0.50
Nodes (4): FeedGenerator.cs, FeedGenerator(), foreach(), if()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.50
Nodes (4): FalAiImageService.cs, GenerateImageAsync(), XPoster.Services, FalAiImageService()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.83
Nodes (4): NoGenerator.cs, NoGenerator.cs, XPoster.Implementation, NoGenerator()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, BuildImagePromptPayload(), DeepSeekService(), if()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.83
Nodes (4): ScheduledGenerationProfile.cs, ScheduledGenerationProfile.cs, ScheduledGenerationProfile(), XPoster.Abstraction

### Community 56 - "Entity (Community 56)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.50
Nodes (4): BaseGenerator.cs, PostAsync(), XPoster.Abstraction, BaseGenerator()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.50
Nodes (4): XSender.cs, SendAsync(), XPoster.SenderPlugins, catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.67
Nodes (3): OpenAiService.cs, if(), OpenAiService()

### Community 83 - "Entity (Community 83)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 82 - "Entity (Community 82)"
Cohesion: 0.67
Nodes (3): FalAiImageService.cs, if(), catch()

### Community 66 - "Entity (Community 66)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 73 - "Entity (Community 73)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 68 - "Entity (Community 68)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 71 - "Entity (Community 71)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 69 - "Entity (Community 69)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 78 - "Entity (Community 78)"
Cohesion: 1.00
Nodes (3): if(), Program.cs, Program.cs

### Community 79 - "Entity (Community 79)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Abstraction

### Community 74 - "Entity (Community 74)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 77 - "Entity (Community 77)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Abstraction

### Community 88 - "Entity (Community 88)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 87 - "Entity (Community 87)"
Cohesion: 1.00
Nodes (2): AzureFoundryService.cs, if()

### Community 85 - "Entity (Community 85)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 84 - "Entity (Community 84)"
Cohesion: 1.00
Nodes (2): BaseGenerator.cs, if()

### Community 86 - "Entity (Community 86)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

